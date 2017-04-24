using System;
using RailTrack.Models;

namespace RailTrack.Utils.Persistance
{
	public interface IDefaultsManager
	{
		void Create(Defaults defaults);

		Defaults GetDefaults();

		void Update(Defaults defaults);
	}
}
