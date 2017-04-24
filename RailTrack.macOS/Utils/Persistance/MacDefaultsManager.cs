using System;
using RailTrack.Models;
using RailTrack.Utils.Persistance;

namespace RailTrack.macOS.Utils.Persistance
{
	public class MacDefaultsManager : IDefaultsManager
	{
		public MacDefaultsManager()
		{
		}

		public void CreateOrUpdate(Defaults defaults)
		{
			throw new NotImplementedException();
		}

		public Defaults GetDefaults()
		{
			throw new NotImplementedException();
			// 'if cannot find defaults, call CreateOrUpdate with generic defaults'
		}

	}
}
