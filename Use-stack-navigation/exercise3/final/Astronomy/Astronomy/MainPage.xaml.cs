using Microsoft.Maui.Controls;
using Astronomy.Pages;

namespace Astronomy;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		btnSunrise.Clicked += async (s, e) => await Navigation.PushAsync(new SunrisePage());
		btnMoonPhase.Clicked += async (s, e) => await Navigation.PushAsync(new MoonPhasePage());
		btnSpaceInfo.Clicked += async (s, e) => await Navigation.PushAsync(new AstronomicalBodiesPage());
		btnAbout.Clicked += async (s, e) => await Navigation.PushAsync(new AboutPage());
	}
}
