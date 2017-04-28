using System;
using System.Collections.Generic;
using Xamarin.Forms;
using RailTrack.ViewModels;
using RailTrack.Models;
using RailTrack.Events;

namespace RailTrack.Views
{
	public partial class ChooseStationPage : ContentPage
	{
		public ChooseStationPage(List<Station> stations, StationSelectedEvent del)
		{
			InitializeComponent();
			BindingContext = new ChooseStationViewModel(stations, del);
		}
	}
}
