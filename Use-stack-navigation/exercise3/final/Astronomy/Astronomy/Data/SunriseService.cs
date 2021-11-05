using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Astronomy;

public class SunriseService
{
	const string SunriseSunsetServiceUrl = "https://api.sunrise-sunset.org";

	public async Task<(DateTime Sunrise, DateTime Sunset)> GetSunriseSunsetTimes(double latitude, double longitude)
	{
		var query = $"{SunriseSunsetServiceUrl}/json?lat={latitude}&lng={longitude}&date=today";

		var client = new HttpClient();
		client.DefaultRequestHeaders.Add("Accept", "application/json");

		var json = await client.GetStringAsync(query);
		var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		var data = JsonSerializer.Deserialize<SunriseSunsetData>(json, options);

		return (DateTime.Parse(data.Results.Sunrise), DateTime.Parse(data.Results.Sunset));
	}

	class SunriseSunsetData
	{
		public SunriseSunsetResults Results { get; set; }
	}

	class SunriseSunsetResults
	{
		public string Sunrise { get; set; }
		public string Sunset { get; set; }
	}
}
