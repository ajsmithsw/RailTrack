using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RailTrack
{
	public partial class StationBoardPage : ContentPage
	{
		public StationBoardPage()
		{
			InitializeComponent();
			BindingContext = new StationBoardViewModel();
		}
	}
}
