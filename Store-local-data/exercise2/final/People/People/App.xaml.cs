using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace People
{
	public partial class App : Application
	{
		public static PersonRepository PersonRepo { get; private set; }

		public App(MainPage page, PersonRepository repo)
		{
			InitializeComponent();

			MainPage = page;
			PersonRepo = repo;
		}
	}
}
