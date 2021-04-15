using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class DocumentationTests : BaseTest
    {
        [Fact]
        public void ClientCreationTest()
        {
            var credentials = new FatSecretCredentials()
            {
                ClientId = "Your Client Id",
                ClientSecret = "Your Client Secret",
                Scope = "basic"
            };

            var client = new FatSecretClient(credentials);
            Assert.NotNull(client);
        }

        [Fact]
        public void FoodsSearchDocTest()
        {
            var client = GetClient();
            var foodSearchRequest = new FoodsSearchRequest()
            {
                SearchExpression = "Apples"
            };
            var foods = client.FoodsSearchAsync(foodSearchRequest);
        }
        
        
    }
}