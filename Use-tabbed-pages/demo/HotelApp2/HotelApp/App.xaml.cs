﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace HotelApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new MainPage());
			MainPage = new MainPage();
		}
	}
}
