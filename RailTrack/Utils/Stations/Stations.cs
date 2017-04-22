using System;
using System.Collections.Generic;
using RailTrack.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace RailTrack.Utils.Stations
{
	/// <summary>
	/// Provides full list of UK stations from embedded resource.
	/// </summary>
	public class Stations
	{
		/// <summary>
		/// The stations.
		/// </summary>
		private List<Station> _stations;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RailTrack.Utils.Stations.Stations"/> class.
		/// </summary>
		public Stations()
		{
			if (_stations == null)
			{
				var json = GetJsonResource();
				_stations = JsonConvert.DeserializeObject<List<Station>>(json);
			}
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		public List<Station> GetAll()
		{
			return _stations ?? null;
		}

		/// <summary>
		/// Gets the crs.
		/// </summary>
		/// <returns>The crs.</returns>
		/// <param name="stationName">Station name.</param>
		public Station GetCRS(string stationName)
		{
			return _stations.Where(x => x.Name == stationName).First() ?? null;
		}

		/// <summary>
		/// Gets the name of the station.
		/// </summary>
		/// <returns>The station name.</returns>
		/// <param name="CRS">Crs.</param>
		public Station GetStationName(string CRS)
		{
			return _stations.Where(x => x.CRS == CRS).First() ?? null;
		}

		/// <summary>
		/// Gets the json resource.
		/// </summary>
		/// <returns>The json resource.</returns>
		private string GetJsonResource()
		{
			var resource = "";
#if __MACOS__
			resource = "RailTrack.macOS.stationcodes.json";
#endif
#if __IOS__
			resource = "RailTrack.iOS.stationcodes.json";
#endif
#if __ANDROID__
			resource = "RailTrack.Droid.stationcodes.json";
#endif

			var assembly = typeof(Stations).GetTypeInfo().Assembly;

			Stream stream = assembly.GetManifestResourceStream(resource);

			using (var reader = new StreamReader(stream)) {
				return reader.ReadToEnd();
			}
		}

	}
}
