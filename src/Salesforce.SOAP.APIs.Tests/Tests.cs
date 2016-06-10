using NUnit.Framework;
using Salesforce.SOAP.APIs.Metadata;
using Salesforce.SOAP.APIs.Metadata.Models;
using Salesforce.SOAP.APIs.Partner;
using Salesforce.SOAP.APIs.Partner.Models;

namespace Salesforce.SOAP.APIs.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string Username = "";
        private const string Password = "";

        private LoginResult _loginResult;
        private MetadataClient _metadataClient;

        [TestFixtureSetUp]
        public void Init()
        {
            var partnerClient = new PartnerClient();

            _loginResult = partnerClient.Login(Username, Password).Result;
            _metadataClient = new MetadataClient(_loginResult.MetadataServerUrl, _loginResult.SessionId);
        }

        [Test]
        public async void Login()
        {
            var partnerClient = new PartnerClient();
            var loginResult = await partnerClient.Login(Username, Password);

            Assert.IsNotNull(loginResult);
            Assert.IsNotNull(loginResult.MetadataServerUrl);
            Assert.IsNotNull(loginResult.SessionId);
        }

        [Test]
        public async void DescribeMetadata()
        {
            var describeMetadataResult = await _metadataClient.DescribeMetadata();

            Assert.IsNotNull(describeMetadataResult);
            Assert.IsNotNull(describeMetadataResult.MetadataObjects);
            Assert.IsNotNull(describeMetadataResult.OrganizationNamespace);
            Assert.IsNotNull(describeMetadataResult.PartialSaveAllowed);
            Assert.IsNotNull(describeMetadataResult.TestRequired);
        }

        [Test]
        public async void ListMetadata()
        {
            var listMetadataResult = await _metadataClient.ListMetadata("CustomObject");

            Assert.IsNotNull(listMetadataResult);
            Assert.IsNotNull(listMetadataResult.Result);

            listMetadataResult = await _metadataClient.ListMetadata("ApexClass");

            Assert.IsNotNull(listMetadataResult);
            Assert.IsNotNull(listMetadataResult.Result);

            listMetadataResult = await _metadataClient.ListMetadata("Profile");

            Assert.IsNotNull(listMetadataResult);
            Assert.IsNotNull(listMetadataResult.Result);

            //AuraDefinitionBundle
            listMetadataResult = await _metadataClient.ListMetadata("AuraDefinitionBundle");

            Assert.IsNotNull(listMetadataResult);
            Assert.IsNotNull(listMetadataResult.Result);
        }

        [Test]
        public async void Retrieve()
        {
            var retrieveResult = await _metadataClient.Retrieve();

            Assert.IsNotNull(retrieveResult);
            Assert.IsNotNull(retrieveResult.Done);
            Assert.IsNotNull(retrieveResult.Id);
            Assert.IsNotNull(retrieveResult.State);
            Assert.AreEqual(retrieveResult.Done, false);
            Assert.AreEqual(retrieveResult.State, "Queued");
        }

        [Test]
        public async void CheckRetrieveStatus()
        {
            var retrieveResult = await _metadataClient.Retrieve();

            var status = "InProgress";
            CheckRetrieveStatusResponseResult checkRetrieveStatusResult = null;

            while (status != "Succeeded")
            {
                checkRetrieveStatusResult = await _metadataClient.CheckRetrieveStatus(retrieveResult.Id);

                Assert.IsNotNull(checkRetrieveStatusResult);

                status = checkRetrieveStatusResult.Status;
            }

            if (checkRetrieveStatusResult != null)
            {
                Assert.AreEqual("Succeeded", checkRetrieveStatusResult.Status);
                Assert.AreEqual(true, checkRetrieveStatusResult.Success);
                Assert.IsNotNull(checkRetrieveStatusResult.ZipFile);
            }
        }
    }
}
