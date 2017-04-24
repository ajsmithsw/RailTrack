using System;
using System.Collections.Generic;
using RailTrack.Models;
using RailTrack.Utils.Darwin;

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		private List<Station> _allStations;

		private string _testString = "Hello macOS!!!";
		public string TestString 
		{
			get { return _testString; }
			set { SetValue(ref _testString, value); }
		}

		public StationBoardViewModel(List<Station> allUkStations)
		{
			if (_allStations == null)
			{
				_allStations = allUkStations;
			}

			//var _test_result = new DarwinApiClient().GetData(RTRequestType.DEPARTURES, "DMK", 5, Constants.DarwinApiKey);
		}
	}
}
