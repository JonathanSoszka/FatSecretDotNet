using System.Threading.Tasks;
using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetIntegrationTest.Helpers;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class FoodGetTests : BaseTest
    {
        private int foodId = 44226;

        [Fact]
        public async Task FoodGetWorks()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = foodId
            };
            var response = await client.FoodGetAsync(request);
            AssertSuccessfulResponse(response);
            Assert.NotNull(response.Food);
        }
        
        [Fact]
        public async Task FoodGetReturnsCorrectItem()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = foodId,
                FlagDefaultServing = true
            };
            var response = await client.FoodGetAsync(request);
            AssertSuccessfulResponse(response);
            Assert.Equal(int.Parse(response.Food.FoodId), foodId);
        }
        
        [Fact]
        public async Task CanProduceError()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = 0
            };
            var response = await client.FoodGetAsync(request);
            AssertFailedResponseWithError(response);
        }
        
    }
}