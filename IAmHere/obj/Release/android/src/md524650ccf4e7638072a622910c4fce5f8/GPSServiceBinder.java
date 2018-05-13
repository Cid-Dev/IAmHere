package md524650ccf4e7638072a622910c4fce5f8;


public class GPSServiceBinder
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("IAmHere.GPSServiceBinder, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GPSServiceBinder.class, __md_methods);
	}


	public GPSServiceBinder ()
	{
		super ();
		if (getClass () == GPSServiceBinder.class)
			mono.android.TypeManager.Activate ("IAmHere.GPSServiceBinder, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public GPSServiceBinder (md524650ccf4e7638072a622910c4fce5f8.GPSService p0)
	{
		super ();
		if (getClass () == GPSServiceBinder.class)
			mono.android.TypeManager.Activate ("IAmHere.GPSServiceBinder, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "IAmHere.GPSService, IAmHere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
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
