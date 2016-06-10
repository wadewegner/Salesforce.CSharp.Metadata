using System.Threading.Tasks;
using System.Xml.Linq;
using Salesforce.SOAP.APIs.Metadata.Models;

namespace Salesforce.SOAP.APIs.Metadata
{
    public class MetadataClient
    {
        public async Task<DescribeMetadataResponseResult> DescribeMetadata(string url, string sessionId, string apiVersion)
        {
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Header>
        <SessionHeader xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <sessionId>{0}</sessionId>
        </SessionHeader>
    </soapenv:Header>
    <soapenv:Body>
        <describeMetadata xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <asOfVersion>{1}</asOfVersion>
        </describeMetadata>
    </soapenv:Body>
</soapenv:Envelope>", sessionId, apiVersion);

            var xmlDescendants = XNamespace.Get("http://soap.sforce.com/2006/04/metadata") + "result";
            var result = await HttpUtility.Post<DescribeMetadataResponseResult>(url, soap, xmlDescendants);

            return result;
        }
        
        public async Task<ListMetadataResponse> ListMetadata(string type, string url, string sessionId, string apiVersion)
        {
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Header>
        <SessionHeader xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <sessionId>{0}</sessionId>
        </SessionHeader>
    </soapenv:Header>
    <soapenv:Body>
        <listMetadata xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <queries>
                <type>{1}</type>
            </queries>
            <asOfVersion>{2}</asOfVersion>
        </listMetadata>
    </soapenv:Body>
</soapenv:Envelope>", sessionId, type, apiVersion);

            var xmlDescendants = XNamespace.Get("http://soap.sforce.com/2006/04/metadata") + "listMetadataResponse";
            var result = await HttpUtility.Post<ListMetadataResponse>(url, soap, xmlDescendants);

            return result;
        }

        public async Task<RetrieveResponseResult> Retrieve(string url, string sessionId, string apiVersion)
        {
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Header>
        <SessionHeader xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <sessionId>{0}</sessionId>
        </SessionHeader>
    </soapenv:Header>
    <soapenv:Body>
        <retrieve xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <retrieveRequest>
                <apiVersion>{1}</apiVersion>
                <unpackaged>
                    <types>
                        <members>CampaignMember</members>
                        <members>OrderItem</members>
                        <members>Case</members>
                        <members>Macro</members>
                        <members>Pricebook2</members>
                        <members>ForecastingCategoryMapping</members>
                        <members>Site</members>
                        <members>PartnerRole</members>
                        <members>OpportunityCompetitor</members>
                        <members>DuplicateRecordSet</members>
                        <members>Lead</members>
                        <members>MacroInstruction</members>
                        <members>CaseContactRole</members>
                        <members>UserProvisioningRequest</members>
                        <members>SocialPersona</members>
                        <members>Idea</members>
                        <members>Task</members>
                        <members>ContentVersion</members>
                        <members>FeedItem</members>
                        <members>DuplicateRecordItem</members>
                        <members>PricebookEntry</members>
                        <members>MacroAction</members>
                        <members>StreamingChannel</members>
                        <members>Contact</members>
                        <members>Activity</members>
                        <members>AccountContactRole</members>
                        <members>DandBCompany</members>
                        <members>AccountCleanInfo</members>
                        <members>LeadCleanInfo</members>
                        <members>ContactCleanInfo</members>
                        <members>Solution</members>
                        <members>User</members>
                        <members>Campaign</members>
                        <members>Opportunity</members>
                        <members>Asset</members>
                        <members>Event</members>
                        <members>AssistantProgress</members>
                        <members>Product2</members>
                        <members>OpportunityLineItem</members>
                        <members>ContractContactRole</members>
                        <members>Account</members>
                        <members>Order</members>
                        <members>OpportunityContactRole</members>
                        <members>Contract</members>
                        <name>CustomObject</name>
                    </types>
                </unpackaged>
            </retrieveRequest>
        </retrieve>
    </soapenv:Body>
</soapenv:Envelope>", sessionId, apiVersion);

            var xmlDescendants = XNamespace.Get("http://soap.sforce.com/2006/04/metadata") + "result";
            var result = await HttpUtility.Post<RetrieveResponseResult>(url, soap, xmlDescendants);

            return result;
        }


        public async Task<CheckRetrieveStatusResponseResult> CheckRetrieveStatus(string url, string sessionId, string processId)
        {
            var soap = string.Format(@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soapenv:Header>
        <SessionHeader xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <sessionId>{0}</sessionId>
        </SessionHeader>
    </soapenv:Header>
    <soapenv:Body>
        <checkRetrieveStatus xmlns=""http://soap.sforce.com/2006/04/metadata"">
            <asyncProcessId>{1}</asyncProcessId>
        </checkRetrieveStatus>
    </soapenv:Body>
</soapenv:Envelope>", sessionId, processId);

            var xmlDescendants = XNamespace.Get("http://soap.sforce.com/2006/04/metadata") + "result";
            var result = await HttpUtility.Post<CheckRetrieveStatusResponseResult>(url, soap, xmlDescendants);

            return result;
        }
    }
}
