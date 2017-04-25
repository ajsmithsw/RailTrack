using System;
using RailTrack.Models;
using RailTrack.Utils.Persistance;

namespace RailTrack.iOS.Utils.Persistance
{
	public class IOSDefaultsManager : IDefaultsManager
	{
		public IOSDefaultsManager()
		{
		}

		public void CreateOrUpdate(Defaults defaults)
		{
			throw new NotImplementedException();
		}

		public Defaults GetDefaults()
		{
			return new Defaults()
			{
				DefaultStationCRS = "DMK",
				DefaultRequestType = "DEPARTURES",
				DefaultResultsCount = 10
			};
		}
	}
}
