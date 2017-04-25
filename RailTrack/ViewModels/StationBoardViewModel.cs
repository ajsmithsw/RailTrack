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

namespace RailTrack.ViewModels
{
	public class StationBoardViewModel : BaseViewModel
	{
		private List<Station> _allStations;
		private Defaults _userDefaults;
		private Station _station;
		private Station _destination;
		private string _lastUpdated;
		private ObservableCollection<TrainService> _services;
		private readonly DarwinApiClient _client;

		public List<Station> AllStations
		{
			get
			{
				return _allStations;
			}
		}

		public Station Station
		{
			get
			{
				return _station;
			}
			set
			{
				_station = value;
				SetValue(ref _station, value);
			}
		}

		public Station Destination
		{
			get
			{
				return _destination;
			}
			set
			{
				_destination = value;
				SetValue(ref _destination, value);
			}
		}

		public string LastUpdated
		{
			get
			{
				return _lastUpdated;
			}
			set
			{
				SetValue(ref _lastUpdated, value);
			}
		}

		public ObservableCollection<TrainService> Services
		{
			get
			{
				return _services;
			}
			set
			{
				SetValue(ref _services, value);
			}
		}

		public ICommand ChooseStation
		{
			get
			{
				return new Command(() => 
				{
					var page = new ChooseStationPage(UpdateStation);
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
					var page = new ChooseStationPage(UpdateDestination);
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
				response = _client.GetData(RTRequestType.DEPARTURES, 5, Constants.DarwinApiKey, _station.CRS);
			}
			else
			{
				response = _client.GetData(RTRequestType.DEPARTURES, 5, Constants.DarwinApiKey, _station.CRS, _destination.CRS);
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