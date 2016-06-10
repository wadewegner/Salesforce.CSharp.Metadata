# Salesforce.CSharp.Metadata

A simple C# SDK for interacting with the Salesforce Metadata API.

## Usage

Below you'll find some sample codes for using this library. You can also [review the functional tests](https://github.com/wadewegner/Salesforce.CSharp.Metadata/blob/master/src/Salesforce.SOAP.APIs.Tests/Tests.cs) for cues on usage.

### Login

```csharp
var partnerClient = new PartnerClient();
var loginResult = await partnerClient.Login(Username, Password, ApiVersion);
```

###  Describe Metadata

```csharp
var metadataClient = new MetadataClient(loginResult.MetadataServerUrl, loginResult.SessionId);
var describeMetadataResult = await metadataClient.DescribeMetadata();
```

### List Metadata

```csharp
var customObjects = await metadataClient.ListMetadata("CustomObject");
var apexClasses = await metadataClient.ListMetadata("ApexClass");
var auraDefinitionBundle = await metadataClient.ListMetadata("AuraDefinitionBundle");
```

### Retrieve Metadata

```csharp
var retrieveResult = await metadataClient.Retrieve();
```

### Check Retrieve Metadata Status

```csharp
var checkRetrieveStatusResult = await metadataClient.CheckRetrieveStatus(retrieveResult.Id);

if (checkRetrieveStatusResult.Status == "Succeeded")
{
  var toBytes = Convert.FromBase64String(checkRetrieveStatusResult.ZipFile);
  var fileName = checkRetrieveStatusResult.Id + ".zip";
  var extractPath = checkRetrieveStatusResult.Id;
  
  using (var fs = new FileStream(fileName, FileMode.Create))
  {
    fs.Write(toBytes, 0, toBytes.Length);
  }
  
  ZipFile.ExtractToDirectory(fileName, extractPath);
}
```





