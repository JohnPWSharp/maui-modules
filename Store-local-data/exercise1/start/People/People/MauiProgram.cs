using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace People
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
			
			builder.Services.AddSingleton<MainPage>();

			// TODO: Create the dbPath string variable and initialize it with the location of the people.db3 database file.

			// TODO: Use DI to add the PersonRepository as a Singelton service to the app. Pass the dbPath as a parameter to the constructor for the PersonRepository instance
			
			return builder.Build();
		}
	}
}