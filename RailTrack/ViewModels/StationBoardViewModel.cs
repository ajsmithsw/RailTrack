using System;

namespace RailTrack
{
	public class StationBoardViewModel : BaseViewModel
	{
		private string _testString = "Hello macOS!!!";
		public string TestString 
		{
			get { return _testString; }
			set { SetValue(ref _testString, value); }
		}

		public StationBoardViewModel()
		{
		}
	}
}
