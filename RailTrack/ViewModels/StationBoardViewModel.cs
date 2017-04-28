using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RailTrack.Models;
using RailTrack.Services;
using RailTrack.Utils.Persistance;
using RailTrack.Utils.Stations;
using RailTrack.Utils.Darwin;
using System.Windows.Input;
using Xamarin.Forms;
using RailTrack.Views;
using RailTrack.Events;

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		
		private Defaults _userDefaults;
		private readonly DarwinApiClient _client;

		private List<Station> _allStations;
		public List<Station> AllStations
		{
			get { return _allStations; }
		}

		private Station _station;
		public Station Station
		{
			get { return _station; }
			set { SetValue(ref _station, value); }
		}

		private Station _destination;
		public Station Destination
		{
			get { return _destination; }
			set { SetValue(ref _destination, value); }
		}

		private string _lastUpdated;
		public string LastUpdated
		{
			get { return _lastUpdated; }
			set { SetValue(ref _lastUpdated, value); }
		}

		private ObservableCollection<TrainService> _services;
		public ObservableCollection<TrainService> Services
		{
			get { return _services; }
			set { SetValue(ref _services, value); }
		}

		public ICommand ChooseStation
		{
			get
			{
				return new Command(() => 
				{
					var page = new ChooseStationPage(AllStations, UpdateStation);
					Application.Current.MainPage.Navigation.PushAsync(page);
				});
			}
		}

		public ICommand ChooseDestination
		{
			get
			{
				return new Command(() =>
				{
					var page = new ChooseStationPage(AllStations, UpdateDestination);
					Application.Current.MainPage.Navigation.PushAsync(page);
				});
			}
		}

		public void UpdateStation(Station station)
		{
			Station = station;
			Update();
		}

		public void UpdateDestination(Station station)
		{
			Destination = station;
			Update();
		}

		public StationBoardViewModel()
		{
			_allStations = new Stations().GetAll();
			_userDefaults = new DefaultsManager().GetDefaults();
			_station = _allStations.Where(x => x.CRS == _userDefaults.DefaultStationCRS).FirstOrDefault();
			_client = new DarwinApiClient();
			LastUpdated = "offline";
			Services = new ObservableCollection<TrainService>();

			InitializeUpdates();
		}

		void InitializeUpdates()
		{
			var service = new RefreshService();
			service.OnRefresh += Update;
			service.Begin(15);
		}

		void Update()
		{
			ServicesResponse response;

			if (_destination == null)
			{
				response = _client.GetData(RTRequestType.DEPARTURES, 5, Constants.DarwinApiKey, Station.CRS);
			}
			else
			{
				response = _client.GetData(RTRequestType.DEPARTURES, 5, Constants.DarwinApiKey, Station.CRS, Destination.CRS);
			}

			UpdateUI(response);
		}

		void UpdateUI(ServicesResponse response)
		{
			if (response != null)
			{
				Services = new ObservableCollection<TrainService>(response.Services);
				LastUpdated = string.Format("Last updated: {0}", response.GeneratedAt.ToString());
			}
			else
			{
				Services = new ObservableCollection<TrainService>();
				LastUpdated = "No services found";
			}
		}
	}
}