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
