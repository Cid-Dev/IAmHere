package md524650ccf4e7638072a622910c4fce5f8;


public class MainActivity_GPSServiceReciever
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("IAmHere.MainActivity+GPSServiceReciever, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_GPSServiceReciever.class, __md_methods);
	}


	public MainActivity_GPSServiceReciever ()
	{
		super ();
		if (getClass () == MainActivity_GPSServiceReciever.class)
			mono.android.TypeManager.Activate ("IAmHere.MainActivity+GPSServiceReciever, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
