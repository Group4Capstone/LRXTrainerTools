/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LRXTrainerTools
{
	[Activity (Label = "stopwatch")]			
	public class stopwatchGUI : Activity
	{
		private Button startButton;
		private Button stopButton;
		private Stopwatch stopwatch;
		private Int64 time;

		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);
		}

		public stopwatchGUI()
		{
			startButton = FindViewById<Button>(Resource.Id.startButton);
			startButton.Click += StartButton_Click;

			stopButton = FindViewById<Button>(Resource.Id.stopButton);
			stopButton.Click += StopButton_Click;

			time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine (time);
		}

		void StopButton_Click (object sender, EventArgs e)
		{
			stopwatch.Stop();
		}


		void StartButton_Click (object sender, EventArgs e)
		{
			stopwatch = new Stopwatch ();
			startButton.Enabled = false;
			stopButton.Enabled = true;
			stopwatch.Start();
		}
	}
}
*/