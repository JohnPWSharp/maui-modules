using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace People
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("people.db3");
        public static PersonRepository PersonRepo { get; private set; }

        public App()
        {
            InitializeComponent();
            PersonRepo = new PersonRepository(dbPath);
            MainPage = new MainPage();
        }
    }
}
