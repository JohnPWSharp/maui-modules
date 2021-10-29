using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Astronomy.Pages;

namespace Astronomy
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			btnSunrise.Clicked += (s, e) => Navigation.PushAsync(new SunrisePage());
			btnMoonPhase.Clicked += (s, e) => Navigation.PushAsync(new MoonPhasePage());
			btnSpaceInfo.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodiesPage());
			btnAbout.Clicked += (s, e) => Navigation.PushAsync(new AboutPage());
		}
	}
}
