using System;
using System.Threading.Tasks;

#if __ANDROID__ || __IOS__
using XPlat.Device.Geolocation;
#elif WINDOWS
using Windows.Devices.Geolocation;
#endif

namespace Astronomy
{
    public class LatLongService : ILatLongService
    {
        public async Task<(double Latitude, double Longitude)> GetLatLong()
        {
            var latLoc = 0.0;
            var longLoc = 0.0;

#if __ANDROID__ || __IOS__
            var geolocator = new Geolocator { DesiredAccuracyInMeters = 25 };
            var accessStatus = await geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                await geolocator.GetGeopositionAsync();
                var geoposition = geolocator.LastKnownPosition;
                var geocoordinate = geoposition.Coordinate;
                latLoc = geocoordinate.Latitude;
                longLoc = geocoordinate.Longitude;
            }

#elif WINDOWS
            var accessStatus = Geolocator.RequestAccessAsync().AsTask().Result;
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                var geolocator = new Geolocator { DesiredAccuracyInMeters = 25 };                
                var geoposition = geolocator.GetGeopositionAsync().AsTask().Result;
                var geocoordinate = geoposition.Coordinate;
                latLoc = geocoordinate.Latitude;
                longLoc = geocoordinate.Longitude;
            }
#endif
            return (latLoc, longLoc);
        }
    }
}