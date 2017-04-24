using System;
using System.Collections.Generic;
using RailTrack.Models;
using RailTrack.Utils.Persistance;

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		private List<Station> _allStations;
		private Defaults _userDefaults;

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

			if (_userDefaults == null)
			{
				_userDefaults = new DefaultsManager().GetDefaults();
			}

			//var _test_result = new DarwinApiClient().GetData(RTRequestType.DEPARTURES, "DMK", 5, Constants.DarwinApiKey);
		}
	}
}
