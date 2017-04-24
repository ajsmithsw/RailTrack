using System;
using RailTrack.Models;

namespace RailTrack.Utils.Persistance
{
	public interface IDefaultsManager
	{
		void CreateOrUpdate(Defaults defaults);

		Defaults GetDefaults();
	}
}
