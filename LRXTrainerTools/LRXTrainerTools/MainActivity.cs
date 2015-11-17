using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LRXTrainerTools
{
	[Activity (Label = "LRX Trainer Tools", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/CustomActionBarTheme")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ActionBar.SetDisplayShowHomeEnabled (false);
			ActionBar.SetDisplayShowTitleEnabled (false);
			ActionBar.SetCustomView (Resource.Layout.Main);
			ActionBar.SetDisplayShowCustomEnabled (true);

			//Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
		}
	}
}