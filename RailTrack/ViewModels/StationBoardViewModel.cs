using System;
using RailTrack.Utils.Darwin;
using RailTrack.Utils.Stations;

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		private Stations _allStations;


		private string _testString = "Hello macOS!!!";
		public string TestString 
		{
			get { return _testString; }
			set { SetValue(ref _testString, value); }
		}

		public StationBoardViewModel()
		{
			if (_allStations == null)
			{
				_allStations = new Stations();
			}

			var result = new DarwinApiClient().GetData(RTRequestType.DEPARTURES, "DMK", 5, Constants.DarwinApiKey);

			var parsedResult = new ResponseXmlParser().Parse(result);

			var time = parsedResult.GeneratedAt.ToString(@"MM\/dd\/yyyy HH:mm");


			Console.WriteLine(
				"\nresult / Station name: {0}\nresult / Generated at: {1}\nresult / firstservice>operator: {2}",
				parsedResult.Station.Name, parsedResult.GeneratedAt, parsedResult.Services[0].Operator.Name);


		}
	}
}
