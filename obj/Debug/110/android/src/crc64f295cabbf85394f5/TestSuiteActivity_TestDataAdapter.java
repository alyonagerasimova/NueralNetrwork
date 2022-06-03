package crc64f295cabbf85394f5;


public class TestSuiteActivity_TestDataAdapter
	extends android.widget.SimpleAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Android.NUnitLite.TestSuiteActivity+TestDataAdapter, Xamarin.Android.NUnitLite", TestSuiteActivity_TestDataAdapter.class, __md_methods);
	}


	public TestSuiteActivity_TestDataAdapter (android.content.Context p0, java.util.List p1, int p2, java.lang.String[] p3, int[] p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == TestSuiteActivity_TestDataAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Android.NUnitLite.TestSuiteActivity+TestDataAdapter, Xamarin.Android.NUnitLite", "Android.Content.Context, Mono.Android:System.Collections.Generic.IList`1<System.Collections.Generic.IDictionary`2<System.String,System.Object>>, mscorlib:System.Int32, mscorlib:System.String[], mscorlib:System.Int32[], mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

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
