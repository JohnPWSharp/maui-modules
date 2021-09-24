package crc6488302ad6e9e4df1a;


public class MauiAccessibilityDelegateCompat
	extends crc6488302ad6e9e4df1a.AccessibilityDelegateCompatWrapper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializeAccessibilityNodeInfo:(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V:GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.MauiAccessibilityDelegateCompat, Microsoft.Maui", MauiAccessibilityDelegateCompat.class, __md_methods);
	}


	public MauiAccessibilityDelegateCompat ()
	{
		super ();
		if (getClass () == MauiAccessibilityDelegateCompat.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.MauiAccessibilityDelegateCompat, Microsoft.Maui", "", this, new java.lang.Object[] {  });
	}


	public MauiAccessibilityDelegateCompat (android.view.View.AccessibilityDelegate p0)
	{
		super (p0);
		if (getClass () == MauiAccessibilityDelegateCompat.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.MauiAccessibilityDelegateCompat, Microsoft.Maui", "Android.Views.View+AccessibilityDelegate, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public MauiAccessibilityDelegateCompat (androidx.core.view.AccessibilityDelegateCompat p0)
	{
		super ();
		if (getClass () == MauiAccessibilityDelegateCompat.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.MauiAccessibilityDelegateCompat, Microsoft.Maui", "AndroidX.Core.View.AccessibilityDelegateCompat, Xamarin.AndroidX.Core", this, new java.lang.Object[] { p0 });
	}


	public void onInitializeAccessibilityNodeInfo (android.view.View p0, androidx.core.view.accessibility.AccessibilityNodeInfoCompat p1)
	{
		n_onInitializeAccessibilityNodeInfo (p0, p1);
	}

	private native void n_onInitializeAccessibilityNodeInfo (android.view.View p0, androidx.core.view.accessibility.AccessibilityNodeInfoCompat p1);

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
