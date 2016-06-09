using System.Xml.Serialization;

namespace Salesforce.Metadata.Api.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public partial class DescribeMetadataResponseResultMetadataObjects
    {
        [XmlElement(ElementName = "childXmlNames")]
        public string[] childXmlNames;

        [XmlElement(ElementName = "directoryName")]
        public string directoryName;

        [XmlElement(ElementName = "inFolder")]
        public bool inFolder;

        [XmlElement(ElementName = "metaFile")]
        public bool metaFile;

        [XmlElement(ElementName = "suffix")]
        public string suffix;

        [XmlElement(ElementName = "xmlName")]
        public string xmlName;
    }
}