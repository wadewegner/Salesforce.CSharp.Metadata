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
var metadataClient = new MetadataClient();
var describeMetadataResult = await metadataClient.DescribeMetadata(
  loginResult.MetadataServerUrl,
  loginResult.SessionId);
```

### List Metadata

```csharp
var listMetadataResult = await metadataClient.ListMetadata(
  "CustomObject",
  loginResult.MetadataServerUrl,
  loginResult.SessionId);
    
listMetadataResult = await metadataClient.ListMetadata(
  "ApexClass",
  loginResult.MetadataServerUrl,
  loginResult.SessionId);
  
listMetadataResult = await metadataClient.ListMetadata(
  "AuraDefinitionBundle",
  loginResult.MetadataServerUrl,
  loginResult.SessionId);
```

### Retrieve Metadata

```csharp
var retrieveResult = await metadataClient.Retrieve(
  loginResult.MetadataServerUrl,
  loginResult.SessionId);
```

### Check Retrieve Metadata Status

```csharp
var checkRetrieveStatusResult = await metadataClient.CheckRetrieveStatus(
  loginResult.MetadataServerUrl,
  loginResult.SessionId,
  retrieveResult.Id);
```





