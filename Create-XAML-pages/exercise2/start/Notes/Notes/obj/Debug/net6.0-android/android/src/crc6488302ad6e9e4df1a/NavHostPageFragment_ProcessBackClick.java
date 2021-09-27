package crc6488302ad6e9e4df1a;


public class NavHostPageFragment_ProcessBackClick
	extends androidx.activity.OnBackPressedCallback
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleOnBackPressed:()V:GetHandleOnBackPressedHandler\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.NavHostPageFragment+ProcessBackClick, Microsoft.Maui", NavHostPageFragment_ProcessBackClick.class, __md_methods);
	}


	public NavHostPageFragment_ProcessBackClick (boolean p0)
	{
		super (p0);
		if (getClass () == NavHostPageFragment_ProcessBackClick.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.NavHostPageFragment+ProcessBackClick, Microsoft.Maui", "System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
	}


	public void handleOnBackPressed ()
	{
		n_handleOnBackPressed ();
	}

	private native void n_handleOnBackPressed ();


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
