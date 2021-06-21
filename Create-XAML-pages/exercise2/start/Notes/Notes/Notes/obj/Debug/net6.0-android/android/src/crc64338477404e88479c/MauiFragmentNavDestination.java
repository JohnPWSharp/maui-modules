package crc64338477404e88479c;


public class MauiFragmentNavDestination
	extends androidx.navigation.fragment.FragmentNavigator.Destination
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Controls.Platform.MauiFragmentNavDestination, Microsoft.Maui.Controls", MauiFragmentNavDestination.class, __md_methods);
	}


	public MauiFragmentNavDestination (androidx.navigation.Navigator p0)
	{
		super (p0);
		if (getClass () == MauiFragmentNavDestination.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.MauiFragmentNavDestination, Microsoft.Maui.Controls", "AndroidX.Navigation.Navigator, Xamarin.AndroidX.Navigation.Common", this, new java.lang.Object[] { p0 });
	}


	public MauiFragmentNavDestination (androidx.navigation.NavigatorProvider p0)
	{
		super (p0);
		if (getClass () == MauiFragmentNavDestination.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.MauiFragmentNavDestination, Microsoft.Maui.Controls", "AndroidX.Navigation.NavigatorProvider, Xamarin.AndroidX.Navigation.Common", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
