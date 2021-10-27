using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Astronomy.Pages
{
    public partial class SunrisePage : ContentPage
	{
        bool awaitConfig = true;
        ILatLongService LatLongService { get; set; }
        public SunrisePage()
        {
            InitializeComponent();
            LatLongService = new LatLongService();
#if WINDOWS
            awaitConfig = false;
            activityWaiting.IsRunning = true;
            var sunriseSunsetData = Task.Run(() =>  GetSunriseSunsetData()).Result;
            InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
            activityWaiting.IsRunning = false;
#endif
        }

#if __ANDROID__ || __IOS__
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            activityWaiting.IsRunning = true;
            var sunriseSunsetData = await GetSunriseSunsetData();
            InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
            activityWaiting.IsRunning = false;
        }
#endif

        async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
        {
            
            var latLongData = await LatLongService.GetLatLong().ConfigureAwait(awaitConfig);
            var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude).ConfigureAwait(awaitConfig);

            var riseTime = sunData.Sunrise.ToLocalTime();
            var setTime = sunData.Sunset.ToLocalTime();
            var span = setTime.TimeOfDay - riseTime.TimeOfDay;
            return (riseTime, setTime, span);
        }

        void InitializeUI(DateTime riseTime, DateTime setTime, TimeSpan span)
        { 
            lblDate.Text = DateTime.Today.ToString("D");            
            lblSunrise.Text = riseTime.ToString("h:mm tt");
            lblDaylight.Text = $"{span.Hours} hours, {span.Minutes} minutes";
            lblSunset.Text = setTime.ToString("h:mm tt");
        }
    }
}
