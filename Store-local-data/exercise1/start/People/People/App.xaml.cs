using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace People
{
	public partial class App : Application
	{
		// TODO: Add a public static PersonRepository property

		public App(MainPage page /* TODO: Add a parameter for the PersonRepository singleton object */ )
		{
			InitializeComponent();

			MainPage = page;

			// TODO: Initialize the PersonRepository property with the PersonRespository singleton object
		}
	}
}
