using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs.Metadata.Models
{
    [XmlRoot(Namespace = "http://soap.sforce.com/2006/04/metadata", ElementName = "result", IsNullable = true)]
    public class CheckRetrieveStatusResponseResult
    {
        [XmlElement(ElementName = "done")]
        public bool Done;

        [XmlElement(ElementName = "fileProperties")]
        public CheckRetrieveStatusResponseResultFileProperties[] FileProperties;

        [XmlElement(ElementName = "id")]
        public string Id;

        [XmlElement(ElementName = "status")]
        public string Status;

        [XmlElement(ElementName = "success")]
        public bool Success;

        [XmlElement(ElementName = "zipFile")]
        public string ZipFile;
    }
}