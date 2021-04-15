using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.ResponseObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class BaseTest
    {
        protected FatSecretClient GetClient()
        {
            return new FatSecretClient(Credentials.GetCredentials());
        }

        protected FatSecretCredentials GetCredentials()
        {
            return Credentials.GetCredentials();
        }

        protected void AssertSuccessfulResponse(FatSecretResponse response)
        {
            Assert.True(response.Successful);
            Assert.Null(response.Error);
        }

        protected void AssertFailedResponseWithError(FatSecretResponse response)
        {
            Assert.False(response.Successful);
            Assert.NotEqual(0, response.Error.Code);
            Assert.NotNull(response.Error.Message);
        }
    }
}