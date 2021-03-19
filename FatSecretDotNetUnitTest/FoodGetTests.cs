using FatSecretDotNet;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNetUnitTest.Helpers;
using Xunit;

namespace FatSecretDotNetUnitTest
{
    public class FoodGetTests : BaseTest
    {
        private int foodId = 6000;

        [Fact]
        public void FoodGetWorks()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = foodId
            };
            var response = client.FoodGet(request);
            AssertSuccessfulResponse(response);
            Assert.NotNull(response.Food);
        }
        
        [Fact]
        public void FoodGetReturnsCorrectItem()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = foodId
            };
            var response = client.FoodGet(request);
            AssertSuccessfulResponse(response);
            Assert.Equal(int.Parse(response.Food.FoodId), foodId);
        }
        
        [Fact]
        public void CanProduceError()
        {
            var client = GetClient();
            var request = new FoodGetRequest()
            {
                FoodId = 0
            };
            var response = client.FoodGet(request);
            AssertFailedResponseWithError(response);
        }
        
    }
}