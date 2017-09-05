using System;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using Salesforce;
using System.Collections.Generic;

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
			//results.ItemsSource = await GetCampaignSObjectsAsync();
			results.ItemsSource = await GetCampaignCustomObjectsAsync();
		}

		async Task<List<SObject>> GetCampaignSObjectsAsync()
		{
			var sobjects = await App.Client.QueryAsync("SELECT Id,Name,CreatedDate FROM CAMPAIGN");

			return sobjects.ToList();
		}

		async Task<List<Campaign>> GetCampaignCustomObjectsAsync()
		{
			var sobjects = await GetCampaignSObjectsAsync();

			var campaigns = sobjects.Select(c => c.As<Campaign>());

			return campaigns.ToList();
		}
	}
}