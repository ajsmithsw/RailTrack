using System.Collections.Generic;
using RailTrack.Models;
using RailTrack.Utils.Stations;
using Xamarin.Forms;

namespace RailTrack
{
	public partial class App : Application
	{
		public List<Station> AllUkStations;

		public App()
		{
			InitializeComponent();

			AllUkStations = new Stations().GetAll();

			MainPage = new StationBoardPage(AllUkStations);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
