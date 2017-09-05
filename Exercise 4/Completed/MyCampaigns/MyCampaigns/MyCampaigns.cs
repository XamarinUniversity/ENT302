using System;
using Xamarin.Forms;
using Xamarin.Auth;
using Salesforce;

namespace MyCampaigns
{
	public class App : Application
	{
		//
		// This is set by the platform-specific projects.
		// When run on Android, it will be your main activity.
		// When run on iOS, it will be your application delegate.
		// The starter code ensures that both the main activity and the application delegate implement the IAdapter interface.
		//
		public static IAdapter Platform { get; set; }

		public const string        ConsumerKey    = "";
		public const string        ConsumerSecret = "";
		public static readonly Uri CallbackUrl    = new Uri("");

		//
		// This is public so it can be used by the CampaignsPage to run queries, searches, etc.
		//
		public static SalesforceClient Client { get; private set; }

		public App()
		{
			// 
			// Setting the MainPage property does some required Xamarin Forms initialization.
			// The ContentPage created here will not be visible to the user and will be replaced in the UI once the user has authenticated.
			//
			this.MainPage = new ContentPage(); 
		}

		protected override void OnStart()
		{
			Client = new SalesforceClient(ConsumerKey, ConsumerSecret, CallbackUrl);
			Client.AuthenticationComplete += OnComplete;

			Client.LoadUsers();	// Load any user tokens that were saved to disk in a previous run

			if (Client.CurrentUser == null)
			{
				Platform.ShowUI(Client.GetLoginInterface()); // no current user, show login UI
			}
			else
			{
				this.MainPage = new CampaignsPage(); // user already logged in, show data page
			}
		}

		void OnComplete(object sender, AuthenticatorCompletedEventArgs e)
		{
			Platform.DisposeUI(); // on iOS we need to replace the Window that was used to display the login UI, on Android this is a no-op

			if (e.IsAuthenticated)
			{
				this.MainPage = new CampaignsPage(); // user successfully logged in, show data page
			}
		}
	}
}