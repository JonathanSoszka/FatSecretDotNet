using System.Linq;
using System.Threading.Tasks;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNet.ResponseObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class FoodSearchTests : BaseTest
    {
        [Fact]
        public async Task  SearchFoodYieldsResults()
        {
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple"
            };
            var response = await client.FoodsSearchAsync(request);
            Assert.True(response.Foods.Food.Count > 1);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public async Task  SearchMaxResultsWorks()
        {
            var maxResults = 20;
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple",
                MaxResults = maxResults
            };
            var response = await client.FoodsSearchAsync(request);
            Assert.Equal(response.Foods.Food.Count, maxResults);
            AssertSuccessfulResponse(response);
        }
        
        [Fact]
        public async Task  SearchPaganationWorks()
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
            var response = await client.FoodsSearchAsync(request);
            Assert.Equal(int.Parse(response.Foods.PageNumber), pageNumber);
            AssertSuccessfulResponse(response);
        }

        [Fact]
        public async Task  PremierParametersWork()
        {
            var request = new FoodsSearchRequest
            {
                SearchExpression = "Apple",
                GenericDescription = GenericDescription.Portion
            };
            var client = GetClient();
            var response = await  client.FoodsSearchAsync(request);
            Assert.IsType<FoodsSearchResponse>(response);
            Assert.Contains("Per 1 medium", response.Foods.Food.First().FoodDescription);

        }
        
        [Fact]
        public async Task  CanProduceError()
        {
            var client = GetClient();
            var request = new FoodsSearchRequest()
            {
                SearchExpression = "Apple",
                PageNumber = 0,
                MaxResults = 0
            };
            var response = await client.FoodsSearchAsync(request);
            AssertFailedResponseWithError(response);
        }
    }
}