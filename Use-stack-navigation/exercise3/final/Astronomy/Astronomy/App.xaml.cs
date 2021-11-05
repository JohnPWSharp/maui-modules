using Microsoft.Maui.Controls;
using MauiApplication = Microsoft.Maui.Controls.Application;

namespace Astronomy;

public partial class App : MauiApplication
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
