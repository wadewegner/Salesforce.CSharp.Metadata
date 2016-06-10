using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs.Metadata.Models
{
    [XmlType(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public class ListMetadataResponseResult
    {
        [XmlElement(ElementName = "createdById")]
        public string CreatedById;

        [XmlElement(ElementName = "createdByName")]
        public string CreatedByName;

        [XmlElement(ElementName = "createdDate")]
        public System.DateTime CreatedDate;

        [XmlElement(ElementName = "fileName")]
        public string FileName;

        [XmlElement(ElementName = "fullName")]
        public string FullName;

        [XmlElement(ElementName = "id")]
        public object Id;

        [XmlElement(ElementName = "lastModifiedById")]
        public string IastModifiedById;

        [XmlElement(ElementName = "lastModifiedByName")]
        public string LastModifiedByName;

        [XmlElement(ElementName = "lastModifiedDate")]
        public System.DateTime LastModifiedDate;

        [XmlElement(ElementName = "namespacePrefix")]
        public object NamespacePrefix;

        [XmlElement(ElementName = "type")]
        public string Type;

    }
}