using System;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetUnitTest.Helpers;
using Xunit;

namespace FatSecretDotNetUnitTest
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
        public void AuthManagerProducesBearerToken()
        {
            var credentials = GetCredentials();
            var authManager = new FatSecretAuthManager(credentials);

            Assert.Contains("Bearer ", authManager.AuthHeader);
            Assert.True(authManager.AuthHeader.Length > "Bearer ".Length);
        }
        
    }
}