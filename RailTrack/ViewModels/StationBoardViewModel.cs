using System;
using System.Collections.Generic;
using RailTrack.Models;
using RailTrack.Utils.Persistance;
using RailTrack.Utils.Stations;
using RailTrack.Services;

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

		public StationBoardViewModel()
		{
			_allStations = new Stations().GetAll();
			_userDefaults = new DefaultsManager().GetDefaults();
			Console.WriteLine("Default station is {0}", _userDefaults.DefaultStationCRS);
			//var _test_result = new DarwinApiClient().GetData(RTRequestType.DEPARTURES, "DMK", 5, Constants.DarwinApiKey);


			int count = 0;
			var test = new RefreshService();
			test.OnRefresh += () => {
				Console.WriteLine("Tick {0}", count);

				TestString = string.Format("Refreshed {0} times.", count);

				count++;
				if (count >= 10)
				{ 
					test.Stop();
				}
			};
			test.Begin(5);

		}
	}
}
