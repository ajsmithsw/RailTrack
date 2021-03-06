﻿using System;
using RailTrack.Models;
using RailTrack.Utils.Persistance;

namespace RailTrack.Droid.Utils.Persistance
{
	public class AndroidDefaultsManager : IDefaultsManager
	{
		public AndroidDefaultsManager()
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
