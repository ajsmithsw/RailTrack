using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RailTrack.Events;
using RailTrack.Models;
using Xamarin.Forms;

namespace RailTrack.ViewModels
{
	public class ChooseStationViewModel : BaseViewModel
	{
		public StationSelectedEvent OnStationSelected;
		public bool mctestbool;

		private ObservableCollection<Station> _allStations;

		private ObservableCollection<Station> _foundStations;
		public ObservableCollection<Station> FoundStations 
		{
			get { return _foundStations; }
			set { SetValue(ref _foundStations, value); }
		}

		private string _searchInput;
		public string SearchInput
		{
			get { return _searchInput; }
			set 
			{
				SetValue(ref _searchInput, value);
				if (_searchInput == null || _searchInput == "")
					FoundStations = new ObservableCollection<Station>();
				else
				{
					FoundStations = new ObservableCollection<Station> (
						_allStations.Where(
							x => ((x.Name.Length >= _searchInput.Length
							       && x.Name.Substring(0, _searchInput.Length).ToLower() == _searchInput.ToLower()) 
							      || (x.CRS.Length >= _searchInput.Length
							       && x.CRS.Substring(0, _searchInput.Length).ToLower() == _searchInput.ToLower()) 
							     )
						));
				}
			}
		}

		private Station _selectedStation;
		public Station SelectedStation
		{
			get { return _selectedStation; }
			set
			{
				SetValue(ref _selectedStation, value);
				if (OnStationSelected != null)
					OnStationSelected(_selectedStation);
				Application.Current.MainPage.Navigation.PopAsync();
			}
		}

		public ChooseStationViewModel(List<Station> stations, StationSelectedEvent del)
		{
			if (del != null)
			{
				OnStationSelected += del;
			}
			_allStations = new ObservableCollection<Station>(stations);
			FoundStations = new ObservableCollection<Station>();
		}
	}
}
