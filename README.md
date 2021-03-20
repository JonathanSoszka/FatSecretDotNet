# FatSecretDotNet
.Net 5.0 Class Library to wrap the [Fat Secret public REST API.](https://platform.fatsecret.com/api/Default.aspx?screen=rapiref2)

**As of V1.0 only the methods granted under the basic scope are implemented. Premier scope methods coming soon.**

## Summary
FatSecretDotNet is a a .Net 5.0 class library which makes it super simple to access the FatSecret [Fat Secret public REST API.](https://platform.fatsecret.com/api/Default.aspx?screen=rapiref2)

## Getting Started

### Prerequisites
To begin using this library in your project first make sure you [Register for a FatSecret developer account](https://platform.fatsecret.com/api/Default.aspx?screen=r) once registered apply for API access to retrieve your client id and client secret, these will be needed to authenticate.

### Instalation 
FatSecretDotNet is hosted on [Nuget](https://www.nuget.org/packages/FatSecretDotNet/) and can easily be added to your project by using a nuget package managger or by using a command line tool.

`Install-Package FatSecretDotNet -Version 1.0.0`

## Usage
The fat secret API is accessed through an instance of the `FatSecretClient` class. This classes constructor takes your credentials and will automatically manage authentication for your requests

### Creating an instance of the client
The client must be instanciated before a request is made. Each client contains its own AuthManager scheme which means each client will try to get its own access token. For this reason it is recommened to reuse the client when possible, and to register it with your DI container if you are using one.
```
  var credentials = new FatSecretCredentials()
  {
     ClientId = "Your Client Id",
     ClientSecret = "Your Client Secret",
     Scope = "your scope" // basic or premier
  };

  var client = new FatSecretClient(credentials);
```
**Note: It is not recommended to ever store your secret in plain text, please use a secure method to store your secret in your application**

### Using the client
The client has a method for each FatSecret API resource. Each Method takes a Request Object that is used to form the paramaters of the reques
```
var foodSearchRequest = new FoodsSearchRequest()
{
  SearchExpression = "Apples"
};

var foods = client.FoodsSearch(foodSearchRequest);
```

See more usage examples [here](docs/UsageExamples.md)

## Technical Details
### Client Methods
Each client method is modeled after the [Fat Secret REST API Documentation](https://platform.fatsecret.com/api/Default.aspx?screen=rapiref2) The method names should match the name of the method in the docs.

### Request Objects
Each client method takes a unique request object, the request object is modeled after the required and optional paramaters as documented in the FatSecret API Docs

### Response Objects
Each client method returns a unique response object, the response object is modeled exactly after the example responses in the FatSecret API Docs. Two Additional properties are added to each response object, `Successful` and `Error` which are populated with information regarding any errors returned by the API.
