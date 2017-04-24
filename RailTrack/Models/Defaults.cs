using Newtonsoft.Json;

namespace RailTrack.Models
{
	public class Defaults
	{
		[JsonProperty("station")]
		public string DefaultStation { get; set; }

		[JsonProperty("req_type")]
		public string DefaultRequestType { get; set; }

		[JsonProperty("result_count")]
		public int DefaultResultsCount { get; set; }
	}
}