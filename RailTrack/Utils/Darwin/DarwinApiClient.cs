﻿using System;
using System.IO;
using System.Net;
using System.Xml;

namespace RailTrack.Utils.Darwin
{
	public class DarwinApiClient
	{
		private string _apiKey { get { return Constants.DarwinApiKey; } }
		private string _apiEndpoint { get { return Constants.DarwinApiEndpoint; } }

		public ServicesResponse GetData(RTRequestType type, int numRows, string token, string fromStationCRS, string toStationCRS = null)
		{
			try
			{
				HttpWebRequest request = CreateWebRequest();

				XmlDocument soapEnvelopeXml = new XmlDocument();

				soapEnvelopeXml.LoadXml(SoapXml.Generate(type, numRows, token, fromStationCRS, toStationCRS));

				using (Stream stream = request.GetRequestStream())
				{
					soapEnvelopeXml.Save(stream);
				}

				using (WebResponse response = request.GetResponse())
				{
					using (StreamReader rd = new StreamReader(response.GetResponseStream()))
					{
						string soapResult = rd.ReadToEnd();
						return new ResponseXmlParser().Parse(soapResult);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return null;
		}

		HttpWebRequest CreateWebRequest()
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_apiEndpoint);
			webRequest.Headers.Add(@"SOAP:Action");
			webRequest.ContentType = "text/xml;charset=\"utf-8\"";
			webRequest.Accept = "text/xml";
			webRequest.Method = "POST";
			return webRequest;
		}

	}
}
