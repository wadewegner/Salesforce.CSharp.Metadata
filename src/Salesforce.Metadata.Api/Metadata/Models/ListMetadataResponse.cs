using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs.Metadata.Models
{
    [XmlRoot(Namespace = "http://soap.sforce.com/2006/04/metadata", ElementName = "listMetadataResponse", IsNullable = true)]
    public class ListMetadataResponse
    {
        [XmlElement(ElementName = "result")]
        public ListMetadataResponseResult[] Result;
    }
}
