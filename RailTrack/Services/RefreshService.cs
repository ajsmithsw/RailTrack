using System;
using System.Timers;
namespace RailTrack.Services
{
	public delegate void Refresh();

	public class RefreshService
	{
		private Timer _timer;

		public bool IsUpdating 
		{ 
			get 
			{ 
				return _timer != null ? _timer.Enabled : false; 
			} 
		}

		public Refresh OnRefresh;

		public RefreshService()
		{
			_timer = new Timer();
			_timer.Elapsed += Refresh;
		}

		public void Begin(int seconds) 
		{
            Refresh(this, null);
			_timer.Interval = seconds * 1000;
			_timer.Enabled = true;
			_timer.Start();
		}

		public void Stop()
		{
			_timer.Stop();
			_timer.Enabled = false;
		}

		private void Refresh(object sender, ElapsedEventArgs eventArgs)
		{
			if (OnRefresh != null)
				OnRefresh();
		}
	}
}
