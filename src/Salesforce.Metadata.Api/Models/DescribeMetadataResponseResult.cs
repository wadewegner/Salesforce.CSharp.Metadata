using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Salesforce.Metadata.Api.Models
{
    [XmlRoot(Namespace = "http://soap.sforce.com/2006/04/metadata", ElementName = "result", IsNullable = true)]
    public partial class DescribeMetadataResponseResult
    {
        [XmlElement(ElementName = "metadataObjects")]
        public DescribeMetadataResponseResultMetadataObjects[] MetadataObjects;

        [XmlElement(ElementName = "organizationNamespace")]
        public object OrganizationNamespace;

        [XmlElement(ElementName = "partialSaveAllowed")]
        public object PartialSaveAllowed;

        [XmlElement(ElementName = "testRequired")]
        public object TestRequired;
    }
}
