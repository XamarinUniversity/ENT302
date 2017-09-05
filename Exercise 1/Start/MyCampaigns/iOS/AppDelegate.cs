using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MyCampaigns.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, MyCampaigns.IAdapter
	{
		UIWindow _window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			//
			// Make the AppDelegate available to the Shared Project
			//
			App.Platform = this;

			//
			// Standard Xamarin Forms initialization code.
			//
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		//
		// iOS-specific code to show a native UIViewController in Xamarin Forms
		//
		public void ShowUI(object ui)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);
			_window.RootViewController = ui as UIViewController;
			_window.MakeKeyAndVisible();
		}

		//
		// iOS-specific code to dispose of the temporary Window used to display the UIViewController
		//
		public void DisposeUI()
		{
			_window.Dispose();
			_window = null;
		}
	}
}

