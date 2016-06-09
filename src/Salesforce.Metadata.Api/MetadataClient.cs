using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Salesforce.Metadata.Api.Models;

namespace Salesforce.CSharp.Metadata
{
    public class MetadataClient
    {
//POST https://na30.salesforce.com/services/Soap/m/31.0/00D36000000vx1P HTTP/1.1
//Accept-Encoding: identity
//Content-Length: 670
//Soapaction: ""
//Host: na30.salesforce.com
//User-Agent: MavensMate
//Connection: close
//Content-Type: text/xml; charset=utf-8

//<?xml version="1.0" encoding="UTF-8"?>
//<SOAP-ENV:Envelope xmlns:ns0="http://soap.sforce.com/2006/04/metadata" 
//xmlns:ns1="http://schemas.xmlsoap.org/soap/envelope/"
//xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
//xmlns:tns="http://soap.sforce.com/2006/04/metadata" 
//xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
//<SOAP-ENV:Header>
//<tns:SessionHeader>
//<tns:sessionId>00D36000000vx1P!ARYAQEpkgv1L1cdeRLuWtboG4371wO561g6gotzO.Pr3X67aJKW6bDA8QWWH.s5cJQolBWWY6XZTEKCHxgeNavIQouMTM5mp</tns:sessionId>
//</tns:SessionHeader>
//</SOAP-ENV:Header>
//<ns1:Body>
//<ns0:describeMetadata>
//<ns0:asOfVersion>31.0</ns0:asOfVersion>
//</ns0:describeMetadata>
//</ns1:Body>
//</SOAP-ENV:Envelope>

        public async Task<dynamic> DescribeMetadata(string url, string sessionId, string apiVersion)
        {
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Header>
        <SessionHeader xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <sessionId>{0}</sessionId>
        </SessionHeader>
    </soapenv:Header>
    <soapenv:Body>
        <describeMetadata xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <asOfVersion>{1}</asOfVersion>
        </describeMetadata>
    </soapenv:Body>
</soapenv:Envelope>", sessionId, apiVersion);

            var content = new StringContent(soap, Encoding.UTF8, "text/xml");

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage();
                 
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Post;
                request.Content = content;

                request.Headers.Add("SOAPAction", "blah");

                var responseMessage = await httpClient.SendAsync(request);
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultXml = XDocument.Parse(response);
                    var result = resultXml.Descendants(XNamespace.Get("http://soap.sforce.com/2006/04/metadata") + "result").First();
                    var serializer = new XmlSerializer(typeof(DescribeMetadataResponseResult));

                    using (var stringReader = new StringReader(result.ToString()))
                    {
                        var loginResult = (DescribeMetadataResponseResult)serializer.Deserialize(stringReader);
                        return loginResult;
                    }
                }

                throw new Exception("Failed request");
            }
        }
    }
}
