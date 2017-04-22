using Newtonsoft.Json;

namespace RailTrack.Models
{
	public class Station
	{
		[JsonProperty("station_name")]
		public string Name { get; set; }

		[JsonProperty("crs")]
		public string CRS { get; set; }
	}
}
