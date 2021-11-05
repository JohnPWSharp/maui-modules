using Microsoft.Maui.Essentials;
using System;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.Maui.Essentials;
=======

namespace Astronomy;
>>>>>>> cc190544a1644613ae4db26985bfe6d790266c36

public class LatLongService : ILatLongService
{
	public async Task<(double Latitude, double Longitude)> GetLatLong()
	{
		try
		{
			var location = await Geolocation.GetLastKnownLocationAsync();
			if (location == null)
			{
				var request = new GeolocationRequest(GeolocationAccuracy.Low);
				location = await Geolocation.GetLocationAsync(request);
			}

<<<<<<< HEAD
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);
                latLoc = location.Latitude;
                longLoc = location.Longitude;
            }
            return (latLoc, longLoc);
        }
    }
}
=======
			return (location?.Latitude ?? 0.0, location?.Longitude ?? 0.0);
		}
		catch (Exception)
		{
			return (0.0, 0.0);
		}
	}
}
>>>>>>> cc190544a1644613ae4db26985bfe6d790266c36
