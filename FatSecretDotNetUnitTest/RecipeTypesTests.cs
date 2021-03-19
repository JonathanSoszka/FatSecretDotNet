using Xunit;

namespace FatSecretDotNetUnitTest
{
    public class RecipeTypesTests : BaseTest
    {
        [Fact]
        public void GetRecipeTypesYieldsResults()
        {
            var client = GetClient();
            var response = client.GetRecipieTypes();
            AssertSuccessfulResponse(response);
            Assert.True(response.RecipeTypes.RecipeType.Count > 0);
        }
    }
}