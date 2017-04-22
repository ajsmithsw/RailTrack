using System;
using System.IO;
using System.Net;
using System.Xml;

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
			HttpWebRequest request = CreateWebRequest();

			System.Xml.XmlDocument soapEnvelopeXml = new XmlDocument();
			soapEnvelopeXml.LoadXml(@"<?xml version=""1.0""?>
<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns1=""http://thalesgroup.com/RTTI/2014-02-20/ldb/"" xmlns:ns2=""http://thalesgroup.com/RTTI/2010-11-01/ldb/commontypes"">
  <SOAP-ENV:Header>
    <ns2:AccessToken>
      <ns2:TokenValue>8c8f1a84-393b-42d2-8f06-482af8ec824a</ns2:TokenValue>
    </ns2:AccessToken>
  </SOAP-ENV:Header>
  <SOAP-ENV:Body>
    <ns1:GetDepartureBoardRequest>
      <ns1:numRows>10</ns1:numRows>
      <ns1:crs>DMK</ns1:crs>
    </ns1:GetDepartureBoardRequest>
  </SOAP-ENV:Body>
</SOAP-ENV:Envelope>");

			using (Stream stream = request.GetRequestStream()) 
			{ 
			soapEnvelopeXml.Save(stream); 
			}
			using (WebResponse response = request.GetResponse())
			{
				using (StreamReader rd = new StreamReader(response.GetResponseStream()))
				{

					string soapResult = rd.ReadToEnd();
					Console.WriteLine(soapResult);
				}
			}
		}

		public HttpWebRequest CreateWebRequest()
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Constants.DarwinApiEndpoint);
			webRequest.Headers.Add(@"SOAP:Action");
			webRequest.ContentType = "text/xml;charset=\"utf-8\"";
			webRequest.Accept = "text/xml";
			webRequest.Method = "POST";
			return webRequest; 
		}
	}
}
