using System.Threading.Tasks;
using Xunit;

namespace FatSecretDotNetIntegrationTest
{
    public class RecipeTypesTests : BaseTest
    {
        [Fact]
        public async Task  GetRecipeTypesYieldsResults()
        {
            var client = GetClient();
            var response = await client.RecipeTypesGetAsync();
            AssertSuccessfulResponse(response);
            Assert.True(response.RecipeTypes.RecipeType.Count > 0);
        }
    }
}