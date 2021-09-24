package crc64338477404e88479c;


public class ModalNavigationManager_BackButtonCallBack
	extends androidx.activity.OnBackPressedCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleOnBackPressed:()V:GetHandleOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Controls.Platform.ModalNavigationManager+BackButtonCallBack, Microsoft.Maui.Controls", ModalNavigationManager_BackButtonCallBack.class, __md_methods);
	}


	public ModalNavigationManager_BackButtonCallBack (boolean p0)
	{
		super (p0);
		if (getClass () == ModalNavigationManager_BackButtonCallBack.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.ModalNavigationManager+BackButtonCallBack, Microsoft.Maui.Controls", "System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
	}


	public void handleOnBackPressed ()
	{
		n_handleOnBackPressed ();
	}

	private native void n_handleOnBackPressed ();

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
