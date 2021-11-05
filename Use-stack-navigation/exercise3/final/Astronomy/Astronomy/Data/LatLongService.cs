using Microsoft.Maui.Essentials;
using System;
using System.Threading.Tasks;

namespace Astronomy;

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

			return (location?.Latitude ?? 0.0, location?.Longitude ?? 0.0);
		}
		catch (Exception)
		{
			return (0.0, 0.0);
		}
	}
}
