using System.Xml.Serialization;

namespace Salesforce.SOAP.APIs.Metadata.Models
{
    [XmlType(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public class DescribeMetadataResponseResultMetadataObjects
    {
        [XmlElement(ElementName = "childXmlNames")]
        public string[] ChildXmlNames;

        [XmlElement(ElementName = "directoryName")]
        public string DirectoryName;

        [XmlElement(ElementName = "inFolder")]
        public bool InFolder;

        [XmlElement(ElementName = "metaFile")]
        public bool MetaFile;

        [XmlElement(ElementName = "suffix")]
        public string Suffix;

        [XmlElement(ElementName = "xmlName")]
        public string XmlName;
    }
}