package crc64fcf28c0e24b4cc31;


public class EntryHandler_EntryFocusChangeListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnFocusChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFocusChange:(Landroid/view/View;Z)V:GetOnFocusChange_Landroid_view_View_ZHandler:Android.Views.View/IOnFocusChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Handlers.EntryHandler+EntryFocusChangeListener, Microsoft.Maui", EntryHandler_EntryFocusChangeListener.class, __md_methods);
	}


	public EntryHandler_EntryFocusChangeListener ()
	{
		super ();
		if (getClass () == EntryHandler_EntryFocusChangeListener.class)
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.EntryHandler+EntryFocusChangeListener, Microsoft.Maui", "", this, new java.lang.Object[] {  });
	}


	public void onFocusChange (android.view.View p0, boolean p1)
	{
		n_onFocusChange (p0, p1);
	}

	private native void n_onFocusChange (android.view.View p0, boolean p1);

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
