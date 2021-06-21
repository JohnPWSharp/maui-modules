package crc64fcf28c0e24b4cc31;


public class ViewHandler_MauiAccessibilityDelegate
	extends androidx.core.view.AccessibilityDelegateCompat
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializeAccessibilityNodeInfo:(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V:GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Handlers.ViewHandler+MauiAccessibilityDelegate, Microsoft.Maui", ViewHandler_MauiAccessibilityDelegate.class, __md_methods);
	}


	public ViewHandler_MauiAccessibilityDelegate ()
	{
		super ();
		if (getClass () == ViewHandler_MauiAccessibilityDelegate.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.ViewHandler+MauiAccessibilityDelegate, Microsoft.Maui", "", this, new java.lang.Object[] {  });
	}


	public ViewHandler_MauiAccessibilityDelegate (android.view.View.AccessibilityDelegate p0)
	{
		super (p0);
		if (getClass () == ViewHandler_MauiAccessibilityDelegate.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.ViewHandler+MauiAccessibilityDelegate, Microsoft.Maui", "Android.Views.View+AccessibilityDelegate, Mono.Android", this, new java.lang.Object[] { p0 });
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
