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
			//results.ItemsSource = await GetCampaignCustomObjectsAsync();
			results.ItemsSource = await GetSearchResultsAsync();
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

		async Task<List<string>> GetSearchResultsAsync()
		{
			string search = "FIND {International} IN NAME FIELDS RETURNING Campaign, Lead";

			IEnumerable<SearchResult> results = await App.Client.SearchAsync(search);

			var strings = results.Select(r => ToString(r));

			return strings.ToList();
		}

		string ToString(SearchResult result)
		{
			return string.Format("[SearchResult: Type={0}, Url={1}, Id={2}]", result.Type, result.Url, result.Id);
		}
	}
}