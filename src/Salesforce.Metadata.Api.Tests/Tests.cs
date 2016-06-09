using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Salesforce.CSharp.Metadata;
using Salesforce.Partner.Api;

namespace FunctionalTests
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
        }
    }
}
