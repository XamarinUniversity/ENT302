using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyCampaigns.Droid
{
	[Activity(Label = "MyCampaigns.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, MyCampaigns.IAdapter
	{
		protected override void OnCreate(Bundle bundle)
		{
			//
			// Make the Activity available to the Shared Project
			//
			App.Platform = this;

			//
			// Standard Xamarin Forms initialization code.
			//
			base.OnCreate(bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}

		//
		// Android-specific code to start an Activity
		//
		public void ShowUI(object ui)
		{
			StartActivity(ui as Intent);
		}

		//
		// No cleanup needed in Android
		//
		public void DisposeUI()
		{
		}
	}
}
