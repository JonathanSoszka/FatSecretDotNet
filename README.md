# FatSecretDotNet
.Net 5.0 Class Library to wrap the [Fat Secret public REST API.](https://platform.fatsecret.com/api/Default.aspx?screen=rapiref2)

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

See more usage examples here

## Examples

### [Foods Search](https://platform.fatsecret.com/api/Default.aspx?screen=rapiref2&method=foods.search)

```

```


