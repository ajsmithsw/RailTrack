using Newtonsoft.Json;

namespace RailTrack.Models
{
	public class Station
	{
		[JsonProperty("station_name")]
		public string Name { get; set; }

		[JsonProperty("crs")]
		public string CRS { get; set; }

		public override string ToString()
		{
			return string.Format("{0} ({1})", Name, CRS);
		}
	}
}
