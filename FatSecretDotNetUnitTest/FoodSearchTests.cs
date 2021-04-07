using System.Linq;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNet.ResponseObjects;
using FatSecretDotNetUnitTest.Helpers;
using Xunit;

namespace FatSecretDotNetUnitTest
{
    public class FoodSearchTests : BaseTest
    {
        [Fact]
        public void SearchFoodYieldsResults()
        {
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple"
            };
            var response = client.FoodsSearch(request);
            Assert.True(response.Foods.Food.Count > 1);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public void SearchMaxResultsWorks()
        {
            var maxResults = 20;
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple",
                MaxResults = maxResults
            };
            var response = client.FoodsSearch(request);
            Assert.Equal(response.Foods.Food.Count, maxResults);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public void SearchPaganationWorks()
        {
            var maxResults = 20;
            var pageNumber = 3;
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple",
                MaxResults = maxResults,
                PageNumber = pageNumber
            };
            var response = client.FoodsSearch(request);
            Assert.Equal(int.Parse(response.Foods.PageNumber), pageNumber);
            AssertSuccessfulResponse(response);
        }

        [Fact]
        public void PremierParametersWork()
        {
            var request = new FoodsSearchRequest
            {
                SearchExpression = "Apple",
                GenericDescription = GenericDescription.Portion
            };
            var client = GetClient();
            var response = client.FoodsSearch(request);
            Assert.IsType<FoodsSearchResponse>(response);
            Assert.Contains("Per 1 medium", response.Foods.Food.First().FoodDescription);

        }
        
        [Fact]
        public void CanProduceError()
        {
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple",
                PageNumber = 0,
                MaxResults = 0
            };
            var response = client.FoodsSearch(request);
            AssertFailedResponseWithError(response);
        }
    }
}