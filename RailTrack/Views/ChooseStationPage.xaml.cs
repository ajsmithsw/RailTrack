using System;
using System.Collections.Generic;

using Xamarin.Forms;
using RailTrack.ViewModels;

namespace RailTrack.Views
{
	public partial class ChooseStationPage : ContentPage
	{
		public ChooseStationPage(StationSelectedEvent del)
		{
			InitializeComponent();
			BindingContext = new ChooseStationViewModel(del);
		}
	}
}
