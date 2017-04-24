namespace RailTrack.Models
{
	public class TrainService
	{
		public Station Origin { get; set; }

		public Station Destination { get; set; }

		public string ScheduledTime { get; set; }

		public string DelayStatus { get; set; }

		public int Platform { get; set; }

		public Operator Operator { get; set; }

		public string ServiceID { get; set; }

		public string Details
		{
			get 
			{
				return string.Format("{0} {1} ({2})", ScheduledTime, Destination.Name, DelayStatus);
			}
		}
	}
}
