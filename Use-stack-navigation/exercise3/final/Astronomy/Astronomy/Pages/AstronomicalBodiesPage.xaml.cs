using Microsoft.Maui.Controls;

namespace Astronomy.Pages;

public partial class AstronomicalBodiesPage : ContentPage
{
	public AstronomicalBodiesPage()
	{
		InitializeComponent();

		btnEarth.Clicked += async (s, e) => await Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Earth));
		btnMoon.Clicked += async (s, e) => await Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Moon));
		btnSun.Clicked += async (s, e) => await Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Sun));
		btnComet.Clicked += async (s, e) => await Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.HalleysComet));
	}
}
