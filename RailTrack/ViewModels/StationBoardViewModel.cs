using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RailTrack.Models;
using RailTrack.Services;
using RailTrack.Utils.Persistance;
using RailTrack.Utils.Stations;
using RailTrack.Utils.Darwin;
using System;

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		private List<Station> _allStations;
		private Defaults _userDefaults;
		private Station _station;
		private string _lastUpdated;
		private ObservableCollection<TrainService> _services;
		private readonly DarwinApiClient client;

		public string StationName
		{
			get 
			{ 
				return _station.Name; 
			}
			set 
			{ 
				_station = _allStations.Where(x => x.Name == value).FirstOrDefault();
				OnPropertyChanged(StationName);
			}
		}

		public string LastUpdated
		{
			get { return _lastUpdated; }
			set { SetValue(ref _lastUpdated, value); }
		}

		public ObservableCollection<TrainService> Services
		{
			get { return _services; }
			set { SetValue(ref _services, value); }
		}

		public StationBoardViewModel()
		{
			_allStations = new Stations().GetAll();
			_userDefaults = new DefaultsManager().GetDefaults();
			_station = _allStations.Where(x => x.CRS == _userDefaults.DefaultStationCRS).FirstOrDefault();
			LastUpdated = "offline";
			Services = new ObservableCollection<TrainService>();
			client = new DarwinApiClient();
			InitializeUpdates();
		}

		void InitializeUpdates()
		{
			var service = new RefreshService();
			service.OnRefresh += Update;
			service.Begin(5);
		}

		void Update()
		{
			var response = client.GetData(RTRequestType.DEPARTURES, _station.CRS, 10, Constants.DarwinApiKey, "PMR");
			if (response != null)
			{
				Services = response.Services;
				LastUpdated = string.Format("Last updated: {0}", response.GeneratedAt.ToString());
			}
			else
			{
				LastUpdated = "Error updating departure board";
			}
		}
	}
}
