using System;
using System.Threading.Tasks;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class AuthTests : BaseTest
    {
        
        [Fact]
        public void CredentialsShouldNotBeNull()
        {
            var credentials = GetCredentials();
            Assert.NotNull(credentials);
        }
        
        [Fact]
        public async Task AuthManagerProducesBearerToken()
        {
            var credentials = GetCredentials();
            var authManager = new FatSecretAuthManager(credentials);
            var authToken = await authManager.GetAuthHeaderAsync();

            Assert.Contains("Bearer ", authToken);
            Assert.True(authToken.Replace("Bearer ","").Length > 0);
        }
        
    }
}