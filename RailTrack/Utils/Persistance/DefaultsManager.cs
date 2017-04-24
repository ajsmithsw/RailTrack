using System;
using RailTrack.Models;

#if __MACOS__
using RailTrack.macOS.Utils.Persistance;
#endif
#if __ANDROID__
using RailTrack.Droid.Utils.Persistance;
#endif
#if __IOS__
using RailTrack.iOS.Utils.Persistance;
#endif

namespace RailTrack.Utils.Persistance
{
	public class DefaultsManager : IDefaultsManager
	{
		private IDefaultsManager _manager;

		public DefaultsManager()
		{
			if (_manager == null)
			{
#if __MACOS__
				_manager = new MacDefaultsManager();
#endif
#if __ANDROID__
				_manager = new AndroidDefaultsManager();
#endif
#if __IOS__
				_manager = new IOSDefaultsManager();
#endif
			}
		}

		public void CreateOrUpdate(Defaults defaults)
		{
			_manager.CreateOrUpdate(defaults);
		}

		public Defaults GetDefaults()
		{
			return _manager.GetDefaults();
		}
	}
}
