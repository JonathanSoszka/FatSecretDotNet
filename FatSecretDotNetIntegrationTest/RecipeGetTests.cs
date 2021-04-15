using System.Threading.Tasks;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class RecipeGetTests : BaseTest
    {
        private int recipeId = 91;

        [Fact]
        public async Task RecipeGetWorks()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = recipeId
            };
            var response = await client.RecipeGetAsync(request);
            Assert.NotNull(response.Recipe);
            AssertSuccessfulResponse(response);
       

        }

        [Fact]
        public async Task  RecipeGetReturnsCorrectItem()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = recipeId
            };
            var response = await client.RecipeGetAsync(request);
            Assert.Equal(recipeId, int.Parse(response.Recipe.RecipeId));
            AssertSuccessfulResponse(response);
        }
        
        
        [Fact]
        public async Task  CanProduceError()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = 0
            };
            var response = await client.RecipeGetAsync(request);
            AssertFailedResponseWithError(response);
        }
    }
}