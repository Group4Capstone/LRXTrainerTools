using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LRXTrainerTools
{
	[Activity (Label = "LRX Trainer Tools", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		string tab1_text = "Metronome";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView (Resource.Layout.Main); 

			ActionBar.Tab metronomeTab = ActionBar.NewTab();
			metronomeTab.SetText(Resources.GetString(Resource.String.tab1_text));
			metronomeTab.SetIcon(Resource.Drawable.tab1_icon);
			//metronomeTab.TabSelected += (sender, args) => {
				// Do something when tab is selected
			//}
				ActionBar.AddTab(metronomeTab);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			
			//button.Click += delegate {
			//	button.Text = string.Format ("{0} clicks!", count++);
			//};
		}
	}
}


