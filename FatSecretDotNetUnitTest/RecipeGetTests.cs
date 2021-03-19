using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetUnitTest.Helpers;
using Xunit;

namespace FatSecretDotNetUnitTest
{
    public class RecipeGetTests : BaseTest
    {
        private int recipeId = 91;

        [Fact]
        public void RecipeGetWorks()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = recipeId
            };
            var response = client.RecipeGet(request);
            Assert.NotNull(response.Recipe);
            AssertSuccessfulResponse(response);
       

        }

        [Fact]
        public void RecipeGetReturnsCorrectItem()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = recipeId
            };
            var response = client.RecipeGet(request);
            Assert.Equal(recipeId, int.Parse(response.Recipe.RecipeId));
            AssertSuccessfulResponse(response);
        }
        
        
        [Fact]
        public void CanProduceError()
        {
            var client = GetClient();
            var request = new RecipeGetRequest()
            {
                RecipeId = 0
            };
            var response = client.RecipeGet(request);
            AssertFailedResponseWithError(response);
        }
    }
}