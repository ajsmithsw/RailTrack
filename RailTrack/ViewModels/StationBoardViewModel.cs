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

			//var result = new DarwinApiClient().GetData(RTRequestType.DEPARTURES, "DMK", 5, Constants.DarwinApiKey);

		}
	}
}
