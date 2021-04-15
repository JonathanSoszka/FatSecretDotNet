using System.Threading.Tasks;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class RecipeSearchTests : BaseTest
    {
        [Fact]
        public async Task  SearchRecipesYieldsResults()
        {
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake"
            };
            var response = await client.RecipesSearchAsync(request);
            Assert.True(response.Recipes.Recipe.Count > 1);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public async Task  SearchMaxResultsWorks()
        {
            var maxResults = 20;
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = maxResults
            };
            var response = await client.RecipesSearchAsync(request);
            Assert.Equal(response.Recipes.Recipe.Count, maxResults);
            AssertSuccessfulResponse(response);
        }

        [Fact]
        public async Task  SearchPaganationWorks()
        {
            var maxResults = 20;
            var pageNumber = 3;
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = maxResults,
                PageNumber = pageNumber
            };
            var response = await client.RecipesSearchAsync(request);
            Assert.Equal(pageNumber, int.Parse(response.Recipes.PageNumber));
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public async Task  CanProduceError()
        {
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = 0,
                PageNumber = 0
            };
            var response = await client.RecipesSearchAsync(request);
            AssertFailedResponseWithError(response);
        }
    }
}