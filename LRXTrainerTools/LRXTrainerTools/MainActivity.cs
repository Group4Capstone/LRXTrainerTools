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

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.actionBar);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("Metronome", Resource.Drawable.metronomeIcon, new SampleTabFragment ());
			AddTab ("Stopwatch", Resource.Drawable.stopwatchIcon, new SampleTabFragment2 ());

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
			tab.SetIcon (Resource.Drawable.metronomeIcon);

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

		class SampleTabFragment: Fragment
		{            
			public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				base.OnCreateView (inflater, container, savedInstanceState);

				var view = inflater.Inflate (Resource.Layout.metronomeView, container, false);

				return view;
			}
		}

		class SampleTabFragment2 : Fragment
		{
			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				base.OnCreateView(inflater, container, savedInstanceState);

				var view = inflater.Inflate(Resource.Layout.stopwatchView, container, false);

				return view;
			}
		}

		/*
			//ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.actionBar);

			var trans = FragmentManager.BeginTransaction ();
			trans.Add (Resource.Id.fragmentContainer, new metronomeFragment (), "metronomeFragment");
			trans.Commit ();

			var trans2 = FragmentManager.BeginTransaction ();
			trans2.Add (Resource.Id.fragmentContainer, new stopwatchFragment (), "stopwatchFragment");
			trans2.Commit ();
		*/
			//ActionBar.Tab tab = ActionBar.NewTab();
			//tab.SetText(Resources.GetString(Resource.String.metTabText));
			//tab.SetIcon(Resource.Drawable.metronomeIcon);
			//tab.TabSelected += (sender, args) => {
				// Do something when tab is selected
			//};
			//	ActionBar.AddTab(tab);

			//tab = ActionBar.NewTab();
			//tab.SetText(Resources.GetString(Resource.String.stopwatchTabText));
			//tab.SetIcon(Resource.Drawable.stopwatchIcon);
			//tab.TabSelected += (sender, args) => {
				// Do something when tab is selected
			//};
			//	ActionBar.AddTab(tab);

			/*ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			base.OnCreate (bundle);

			ActionBar.SetCustomView (Resource.Layout.actionBar);
			ActionBar.SetDisplayShowCustomEnabled (true);

			ActionBar.Tab metTab = ActionBar.NewTab ();
			metTab.TabSelected += (sender, e) => 
			{
				//gkg
			};
			ActionBar.AddTab(metTab);

			ActionBar.Tab watchTab = ActionBar.NewTab ();
			watchTab.TabSelected += (sender, e) => 
			{
				//Do something
			};
			ActionBar.AddTab (watchTab);
		*/
	}
}