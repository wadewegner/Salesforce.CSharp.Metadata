using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs
{
    public static class HttpUtility
    {
        public static async Task<T> Post<T>(string url, string soap, XName xmlDescendants, string soapAction = "blah")
        {
            var content = new StringContent(soap, Encoding.UTF8, "text/xml");

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = content
                };
                    
                request.Headers.Add("SOAPAction", soapAction);

                var responseMessage = await httpClient.SendAsync(request);
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultXml = XDocument.Parse(response);
                    var xmlString = resultXml.ToString();
                    if (xmlDescendants != null)
                    {
                        var result = resultXml.Descendants(xmlDescendants).First();
                        xmlString = result.ToString();
                    }

                    var serializer = new XmlSerializer(typeof(T));

                    using (var stringReader = new StringReader(xmlString))
                    {
                        var loginResult = (T)serializer.Deserialize(stringReader);
                        return loginResult;
                    }
                }

                throw new Exception("Failed request");
            }
        }
    }
}
