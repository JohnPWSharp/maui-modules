using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace HotelApp.Pages
{
	public partial class SelectRoomPage: ContentPage
	{
		public SelectRoomPage()
		{
			InitializeComponent();
		}

		async void OnProvideContactDetails(object sender, EventArgs args)
		{
			await this.Navigation.PushAsync(new ContactDetailsPage());
		}
	}
}
