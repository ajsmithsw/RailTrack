using System;
using RailTrack.Models;

namespace RailTrack.ViewModels
{
	public delegate void StationSelectedEvent(Station station);

	public class ChooseStationViewModel : BaseViewModel
	{
		public StationSelectedEvent OnStationSelected;

		public ChooseStationViewModel(StationSelectedEvent del)
		{
			if (del != null)
			{
				OnStationSelected += del;
			}
		}
	}
}
