using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace HotelApp.Pages
{
	public partial class ReservationPage : ContentPage
	{
		public ReservationPage()
		{
			InitializeComponent();
		}
		async void OnFinish(object sender, EventArgs args)
		{
			await Navigation.PopToRootAsync();
		}
	}
}
