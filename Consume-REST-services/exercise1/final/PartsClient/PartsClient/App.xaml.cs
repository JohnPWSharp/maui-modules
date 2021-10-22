using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace PartsClient
{
	public partial class App : Application
	{
		public App(AppShell shell)
		{
			InitializeComponent();

			MainPage = shell;
		}
	}
}
