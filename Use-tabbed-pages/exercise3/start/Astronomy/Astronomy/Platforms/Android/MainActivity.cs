using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using Microsoft.Maui;

namespace Astronomy
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{
		protected override void OnCreate(Bundle? savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Microsoft.Maui.Essentials.Platform.Init(this, savedInstanceState);
			//this.Window.AddFlags(Android.Views.WindowManagerFlags.LayoutNoLimits | Android.Views.WindowManagerFlags.Fullscreen);
			//this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.HideNavigation;
			//WindowCompat.SetDecorFitsSystemWindows(this.Window, false);
			//this.Window.InsetsController.Hide(WindowInsetsCompat.Type.SystemBars());
			//this.Window.InsetsController.SystemBarsBehavior = WindowInsetsControllerCompat.BehaviorShowTransientBarsBySwipe;
		}
	}
}