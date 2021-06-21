package crc6488302ad6e9e4df1a;


public class NavigationLayout
	extends androidx.coordinatorlayout.widget.CoordinatorLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Microsoft.Maui.NavigationLayout, Microsoft.Maui", NavigationLayout.class, __md_methods);
	}


	public NavigationLayout (android.content.Context p0)
	{
		super (p0);
		if (getClass () == NavigationLayout.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.NavigationLayout, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public NavigationLayout (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == NavigationLayout.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.NavigationLayout, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public NavigationLayout (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == NavigationLayout.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.NavigationLayout, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
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
