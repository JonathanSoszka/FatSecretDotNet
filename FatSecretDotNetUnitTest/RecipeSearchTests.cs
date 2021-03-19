using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetUnitTest.Helpers;
using Xunit;

namespace FatSecretDotNetUnitTest
{
    public class RecipeSearchTests : BaseTest
    {
        [Fact]
        public void SearchRecipesYieldsResults()
        {
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake"
            };
            var response = client.RecipesSearch(request);
            Assert.True(response.Recipes.Recipe.Count > 1);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public void SearchMaxResultsWorks()
        {
            var maxResults = 20;
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = maxResults
            };
            var response = client.RecipesSearch(request);
            Assert.Equal(response.Recipes.Recipe.Count, maxResults);
            AssertSuccessfulResponse(response);
        }

        [Fact]
        public void SearchPaganationWorks()
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
            var response = client.RecipesSearch(request);
            Assert.Equal(pageNumber, int.Parse(response.Recipes.PageNumber));
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public void CanProduceError()
        {
            var client = GetClient();
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = 0,
                PageNumber = 0
            };
            var response = client.RecipesSearch(request);
            AssertFailedResponseWithError(response);
        }
    }
}