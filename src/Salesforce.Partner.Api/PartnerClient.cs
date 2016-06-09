using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Salesforce.Partner.Api.Models;

namespace Salesforce.Partner.Api
{
    public class PartnerClient
    {
        public async Task<LoginResult> Login(string userName, string password, string version = "36.0")
        {
            var url = string.Format("https://login.salesforce.com/services/Soap/u/{0}", version);
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Body>
        <login xmlns=""urn:partner.soap.sforce.com"">
            <username>{0}</username>
            <password>{1}</password>
        </login>
    </soapenv:Body>
</soapenv:Envelope>", userName, password);

            var content = new StringContent(soap, Encoding.UTF8, "text/xml");

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage();

                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Post;
                request.Content = content;

                request.Headers.Add("SOAPAction", "login");

                var responseMessage = await httpClient.SendAsync(request);
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultXml = XDocument.Parse(response);
                    var result = resultXml.Descendants(XNamespace.Get("urn:partner.soap.sforce.com") + "result").First();
                    var serializer = new XmlSerializer(typeof(LoginResult));

                    using (var stringReader = new StringReader(result.ToString()))
                    {
                        var loginResult = (LoginResult)serializer.Deserialize(stringReader);
                        return loginResult;
                    }
                }

                throw new Exception("Failed login");
            }
        }
    }
}
