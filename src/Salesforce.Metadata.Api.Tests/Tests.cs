using NUnit.Framework;
using Salesforce.SOAP.APIs.Metadata;
using Salesforce.SOAP.APIs.Partner;

namespace Salesforce.SOAP.APIs.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string Username = "";
        private const string Password = "";
        private const string ApiVersion = "36.0";

        [Test]
        public async void Login()
        {
            var partnerClient = new PartnerClient();
            var loginResult = await partnerClient.Login(Username, Password, ApiVersion);

            Assert.IsNotNull(loginResult);
            Assert.IsNotNull(loginResult.MetadataServerUrl);
            Assert.IsNotNull(loginResult.SessionId);
        }

        [Test]
        public async void DescribeMetadata()
        {
            var partnerClient = new PartnerClient();
            var loginResult = await partnerClient.Login(Username, Password);

            var metadataClient = new MetadataClient();
            var describeMetadataResult = await metadataClient.DescribeMetadata(
                loginResult.MetadataServerUrl,
                loginResult.SessionId,
                ApiVersion);

            Assert.IsNotNull(describeMetadataResult);
            Assert.IsNotNull(describeMetadataResult.MetadataObjects);
            Assert.IsNotNull(describeMetadataResult.OrganizationNamespace);
            Assert.IsNotNull(describeMetadataResult.PartialSaveAllowed);
            Assert.IsNotNull(describeMetadataResult.TestRequired);
        }

        [Test]
        public async void ListMetadata()
        {
            var partnerClient = new PartnerClient();
            var loginResult = await partnerClient.Login(Username, Password);

            var metadataClient = new MetadataClient();
            var listMetadataResult = await metadataClient.ListMetadata(
                loginResult.MetadataServerUrl,
                loginResult.SessionId,
                ApiVersion);

            Assert.IsNotNull(listMetadataResult);
            Assert.IsNotNull(listMetadataResult.Result);
        }

        [Test]
        public async void Retrieve()
        {
            var partnerClient = new PartnerClient();
            var loginResult = await partnerClient.Login(Username, Password);

            var metadataClient = new MetadataClient();
            var retrieveResult = await metadataClient.Retrieve(
                loginResult.MetadataServerUrl,
                loginResult.SessionId,
                ApiVersion);

            Assert.IsNotNull(retrieveResult);
            Assert.IsNotNull(retrieveResult.Done);
            Assert.IsNotNull(retrieveResult.Id);
            Assert.IsNotNull(retrieveResult.State);
            Assert.AreEqual(retrieveResult.Done, false);
            Assert.AreEqual(retrieveResult.State, "Queued");
        }
    }
}
