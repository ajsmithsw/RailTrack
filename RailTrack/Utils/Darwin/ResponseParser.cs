using System;
namespace RailTrack.Utils.Darwin
{
	/// <summary>
	/// Response parser.
	/// </summary>
	public class ResponseParser
	{
		private string _xmlResponse;

		public ResponseParser(string xmlResponse)
		{
			if (_xmlResponse == null)
				_xmlResponse = xmlResponse;
		}
	}
}
