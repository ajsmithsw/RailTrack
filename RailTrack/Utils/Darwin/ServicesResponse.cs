using System;
using System.Collections.Generic;
using System.Xml;
using RailTrack.Models;

namespace RailTrack.Utils.Darwin
{

	public class ServicesResponse
	{
		public DateTime GeneratedAt { get; set; }

		public Station Station { get; set; }

		public bool PlatformAvailable { get; set; }

		public List<TrainService> Services { get; set; }

		public ServicesResponse()
		{
			GeneratedAt = new DateTime(1970, 1, 1);
			Station = new Station();
			PlatformAvailable = true;
			Services = new List<TrainService>();
		}
	}

}