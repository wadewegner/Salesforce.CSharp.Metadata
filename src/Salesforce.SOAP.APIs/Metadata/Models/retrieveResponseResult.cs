using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs.Metadata.Models
{
    [XmlRoot(Namespace = "http://soap.sforce.com/2006/04/metadata", ElementName = "result", IsNullable = true)]
    public partial class RetrieveResponseResult
    {
        [XmlElement(ElementName = "done")]
        public bool Done;

        [XmlElement(ElementName = "id")]
        public string Id;

        [XmlElement(ElementName = "state")]
        public string State;
    }
}