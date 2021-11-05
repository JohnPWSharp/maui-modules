using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Astronomy.Pages;

public partial class SunrisePage : ContentPage
{
<<<<<<< HEAD
    public partial class SunrisePage : ContentPage
    {
        ILatLongService LatLongService { get; set; }
        public SunrisePage()
        {
            InitializeComponent();
            LatLongService = new LatLongService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            activityWaiting.IsRunning = true;
            var sunriseSunsetData = await GetSunriseSunsetData();
            InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
            activityWaiting.IsRunning = false;
        }

        async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
        {

            var latLongData = await LatLongService.GetLatLong();
            var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

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
=======
	ILatLongService LatLongService { get; set; }
	public SunrisePage()
	{
		InitializeComponent();
		LatLongService = new LatLongService();
	}


	protected override async void OnAppearing()
	{
		base.OnAppearing();
		activityWaiting.IsRunning = true;
		var sunriseSunsetData = await GetSunriseSunsetData();
		InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
		activityWaiting.IsRunning = false;
	}

	async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
	{

		var latLongData = await LatLongService.GetLatLong();

		var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

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
>>>>>>> cc190544a1644613ae4db26985bfe6d790266c36
}
