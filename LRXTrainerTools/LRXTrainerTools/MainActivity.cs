using System;
using System.Diagnostics;

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

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.actionBar);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("", Resource.Drawable.metronomeIcon, new metronomeFragment ());
			AddTab ("", Resource.Drawable.stopwatchIcon, new stopwatchFragment ());

			if (bundle != null)
				this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));

		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);
			base.OnSaveInstanceState(outState);
		}

		void AddTab (string tabText, int iconResourceId, Fragment view)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
			tab.SetIcon (iconResourceId);

			// must set event handler before adding tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);         
				e.FragmentTransaction.Add (Resource.Id.fragmentContainer, view);
			};

			tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs e) {
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab (tab);
		}
	}
}