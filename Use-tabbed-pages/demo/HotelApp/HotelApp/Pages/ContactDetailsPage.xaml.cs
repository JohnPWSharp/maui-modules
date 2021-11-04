using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace HotelApp.Pages
{
	public partial class ContactDetailsPage : ContentPage
	{
		public ContactDetailsPage()
		{
			InitializeComponent();
		}

		async void OnMakeReservation(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new ReservationPage());
		}
	}
}
