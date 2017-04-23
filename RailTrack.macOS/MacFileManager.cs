using System;
using RailTrack.Utils.Persistance;
using Foundation;

namespace RailTrack.macOS
{
	public class MacFileManager : IFileManager
	{
		public MacFileManager()
		{
		}

		public bool CreateOrUpdate()
		{
			var bundleID = NSBundle.MainBundle.BundleIdentifier;

			var fileManager = NSFileManager.DefaultManager;

			return true;
		}
	}
}
