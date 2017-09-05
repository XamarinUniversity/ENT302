using System;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Salesforce;

namespace MyCampaigns
{
	public class CampaignsPage : ContentPage
	{
		ListView results;

		public CampaignsPage()
		{
			results = new ListView();
			var layout = new StackLayout();
			layout.Padding = Device.OnPlatform(new Thickness(5,20,5,5), new Thickness(0), new Thickness(0));
			layout.Children.Add(results);
			Content = layout;
		}

		protected override void OnAppearing()
		{
			Run();
		}

		async void Run()
		{
		}
	}
}