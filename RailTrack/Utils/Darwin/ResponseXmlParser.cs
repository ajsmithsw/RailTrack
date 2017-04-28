using System.Xml;

using RailTrack.Models;
using System;
using System.Linq;

namespace RailTrack.Utils.Darwin
{
	/// <summary>
	/// Response parser.
	/// </summary>
	public class ResponseXmlParser
	{
		public ServicesResponse Parse(string xmlResult)
		{
			var servicesResponse = new ServicesResponse();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlResult);

			XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
			manager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
			manager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
			manager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
			manager.AddNamespace("lt", "http://thalesgroup.com/RTTI/2012-01-13/ldb/types");
			manager.AddNamespace("lt2", "http://thalesgroup.com/RTTI/2014-02-20/ldb/types");
			manager.AddNamespace("lt3", "http://thalesgroup.com/RTTI/2015-05-14/ldb/types");
			manager.AddNamespace("lt4", "http://thalesgroup.com/RTTI/2015-11-27/ldb/types");
			manager.AddNamespace("lt5", "http://thalesgroup.com/RTTI/2016-02-16/ldb/types");

			XmlNode body = doc.SelectSingleNode("soap:Envelope/soap:Body", manager);
			XmlNode stationBoardResult = body.ChildNodes[0];

			servicesResponse.GeneratedAt = DateTime.Parse(
				stationBoardResult.SelectSingleNode("//lt2:generatedAt", manager).InnerText);
			servicesResponse.Station.Name = 
				stationBoardResult.SelectSingleNode("//lt2:locationName", manager).InnerText;
			servicesResponse.Station.CRS = 
				stationBoardResult.SelectSingleNode("//lt2:crs", manager).InnerText;
			servicesResponse.PlatformAvailable = 
				stationBoardResult.SelectSingleNode("//lt2:platformAvailable", manager).InnerText == "true";

			XmlNode servicesListNode =
				stationBoardResult.SelectSingleNode("//lt2:trainServices", manager);
			XmlNodeList servicesNodeList =
				servicesListNode.SelectNodes("//lt2:service", manager);

			foreach (XmlNode node in servicesNodeList)
			{
				var service = new TrainService();

				var origin = new Station();
				XmlNode originNode = node.SelectSingleNode("lt2:origin", manager);
				origin.Name = originNode.SelectSingleNode("lt2:location", manager)
					.SelectSingleNode("lt2:locationName", manager).InnerText;
				origin.CRS = originNode.SelectSingleNode("lt2:location", manager)
					.SelectSingleNode("lt2:crs", manager).InnerText;
				service.Origin = origin;

				var destination = new Station();
				XmlNode destinationNode = node.SelectSingleNode("lt2:destination", manager);
				destination.Name = destinationNode.SelectSingleNode("lt2:location", manager)
					.SelectSingleNode("lt2:locationName", manager).InnerText;
				destination.CRS = destinationNode.SelectSingleNode("lt2:location", manager)
					.SelectSingleNode("lt2:crs", manager).InnerText;
				service.Destination = destination;

				service.ScheduledTime = node.SelectSingleNode("lt2:std", manager).InnerText;
				service.DelayStatus = node.SelectSingleNode("lt2:etd", manager).InnerText;
				//service.Platform = int.Parse(node.SelectSingleNode("lt2:platform", manager).InnerText);

				var serviceOperator = new Operator();
				serviceOperator.Name = node.SelectSingleNode("lt2:operator", manager).InnerText;
				serviceOperator.Code = node.SelectSingleNode("lt2:operatorCode", manager).InnerText;
				service.Operator = serviceOperator;

				service.ServiceID = node.SelectSingleNode("lt2:serviceID", manager).InnerText;

				servicesResponse.Services.Add(service);
			}

			return servicesResponse;
		}
	}

}