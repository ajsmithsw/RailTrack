﻿using System;
using System.Text;

namespace RailTrack.Utils.Darwin
{
	public static class SoapXml
	{
		public static string Generate(RTRequestType type, int numRows, string token, string fromStationCRS, string toStationCRS = null)
		{
			string requestType = type == RTRequestType.DEPARTURES ? 
			                                          "GetDepartureBoardRequest" : "GetArrivalBoardRequest";

			var addDestination = toStationCRS != null ? 
				string.Format("<ns1:filterCrs>{0}</ns1:filterCrs>", toStationCRS) 
			          : "";

			var xml = string.Format(@"<?xml version=""1.0""?>
			<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" 
				xmlns:ns1=""http://thalesgroup.com/RTTI/2014-02-20/ldb/"" 
				xmlns:ns2=""http://thalesgroup.com/RTTI/2010-11-01/ldb/commontypes"">
			  <SOAP-ENV:Header>
			    <ns2:AccessToken>
			      <ns2:TokenValue>{0}</ns2:TokenValue>
			    </ns2:AccessToken>
			  </SOAP-ENV:Header>
			  <SOAP-ENV:Body>
			    <ns1:{1}>
			      <ns1:numRows>{2}</ns1:numRows>
			      <ns1:crs>{3}</ns1:crs>{4}
			    </ns1:{1}>
			  </SOAP-ENV:Body>
			</SOAP-ENV:Envelope>", token, requestType, numRows, fromStationCRS, addDestination);

			return xml;
		}
	}
}
