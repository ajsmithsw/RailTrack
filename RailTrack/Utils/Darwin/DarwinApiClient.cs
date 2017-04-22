using System;
using System.Net;
using System.Xml;

namespace RailTrack
{
	public class DarwinApiClient
	{
		private string _apiKey { get { return Constants.DarwinApiKey; } }
		private string _apiEndpoint { get { return Constants.DarwinApiEndpoint; } }

		public DarwinApiClient()
		{
		}

		public string GetResponse()
		{
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(_apiEndpoint);



			return "";
		}


	}
}
