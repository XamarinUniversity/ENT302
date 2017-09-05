using Salesforce;

namespace MyCampaigns
{
	public class Campaign : SObject
	{
		public Campaign()
		{
			this.PreparingUpdateRequest += OnPreparingUpdateRequest;
		}

		void OnPreparingUpdateRequest(object sender, UpdateRequestEventArgs e)
		{
			e.UpdateData.Remove("CreatedDate");
		}

		public string Name
		{
			get { return this.Options["Name"]; }
			set { this.Options["Name"] = value; }
		}

		public string CreatedDate
		{
			get { return this.Options["CreatedDate"]; }
		}

		public override string ToString()
		{
			return string.Format("[Campaign: Name={0}, CreatedDate={1}]", Name, CreatedDate);
		}
	}
}

