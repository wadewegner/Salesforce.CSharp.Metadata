using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.SOAP.APIs.Metadata.Models
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/04/metadata")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/04/metadata", IsNullable = false)]
    public partial class result
    {

        private resultMetadataObjects[] metadataObjectsField;

        private object organizationNamespaceField;

        private bool partialSaveAllowedField;

        private bool testRequiredField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("metadataObjects")]
        public resultMetadataObjects[] metadataObjects
        {
            get
            {
                return this.metadataObjectsField;
            }
            set
            {
                this.metadataObjectsField = value;
            }
        }

        /// <remarks/>
        public object organizationNamespace
        {
            get
            {
                return this.organizationNamespaceField;
            }
            set
            {
                this.organizationNamespaceField = value;
            }
        }

        /// <remarks/>
        public bool partialSaveAllowed
        {
            get
            {
                return this.partialSaveAllowedField;
            }
            set
            {
                this.partialSaveAllowedField = value;
            }
        }

        /// <remarks/>
        public bool testRequired
        {
            get
            {
                return this.testRequiredField;
            }
            set
            {
                this.testRequiredField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public partial class resultMetadataObjects
    {

        private string[] childXmlNamesField;

        private string directoryNameField;

        private bool inFolderField;

        private bool metaFileField;

        private string suffixField;

        private string xmlNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("childXmlNames")]
        public string[] childXmlNames
        {
            get
            {
                return this.childXmlNamesField;
            }
            set
            {
                this.childXmlNamesField = value;
            }
        }

        /// <remarks/>
        public string directoryName
        {
            get
            {
                return this.directoryNameField;
            }
            set
            {
                this.directoryNameField = value;
            }
        }

        /// <remarks/>
        public bool inFolder
        {
            get
            {
                return this.inFolderField;
            }
            set
            {
                this.inFolderField = value;
            }
        }

        /// <remarks/>
        public bool metaFile
        {
            get
            {
                return this.metaFileField;
            }
            set
            {
                this.metaFileField = value;
            }
        }

        /// <remarks/>
        public string suffix
        {
            get
            {
                return this.suffixField;
            }
            set
            {
                this.suffixField = value;
            }
        }

        /// <remarks/>
        public string xmlName
        {
            get
            {
                return this.xmlNameField;
            }
            set
            {
                this.xmlNameField = value;
            }
        }
    }


}
