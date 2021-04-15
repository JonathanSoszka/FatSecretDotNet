using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FatSecretDotNet.Authentication;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNet.ResponseObjects;
using Newtonsoft.Json;
using RestSharp;

namespace FatSecretDotNet
{
    public class FatSecretClient : IFatSecretClient
    {
        private readonly FatSecretAuthManager _authManager;
        private readonly IRestClient _client;

        public FatSecretClient(FatSecretCredentials credentials)
        {
            _authManager = new FatSecretAuthManager(credentials);
            _client = new RestClient("https://platform.fatsecret.com/rest/server.api");
        }

        public async Task<GetFoodResponse> FoodGetAsync(FoodGetRequest request)
        {
            return await FatSecretRequest<GetFoodResponse>(request);
        }

        public async Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request)
        {
            return await FatSecretRequest<FoodsSearchResponse>(request);
        }

        public async Task<RecipieTypesResponse> RecipeTypesGetAsync()
        {
            return await FatSecretRequest<RecipieTypesResponse>(new RecipieTypesRequest());
        }

        public async Task<RecipesSearchResponse> RecipesSearchAsync(RecipesSearchRequest request)
        {
            return await FatSecretRequest<RecipesSearchResponse>(request);
        }

        public async Task<RecipeGetResponse> RecipeGetAsync(RecipeGetRequest request)
        {
            return await FatSecretRequest<RecipeGetResponse>(request);
        }

        private async Task<T> FatSecretRequest<T>(IFatSecretRequest fatSecretRequest) where T : FatSecretResponse
        {
            var request = new RestRequest(Method.GET);
            var authToken = await _authManager.GetAuthHeaderAsync();
            request.AddHeader("Authorization", authToken);

            foreach (var parameter in fatSecretRequest.GetParameters(_authManager.IsPremier))
            {
                request.AddParameter(parameter.Item1, parameter.Item2);
            }

            request.AddParameter("format", "json");

            var response = await _client.ExecuteAsync<T>(request);
            var fatSecretResponse = response.Data;

            var fatSecretErrorResponse = JsonConvert.DeserializeObject<FatSecretErrorResponse>(response.Content);
            if (fatSecretErrorResponse.Error != null)
            {
                fatSecretResponse.Error = fatSecretErrorResponse.Error;
            }

            return fatSecretResponse;
        }
    }

    public interface IFatSecretClient
    {
        Task<GetFoodResponse> FoodGetAsync(FoodGetRequest request);
        Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request);
        Task<RecipieTypesResponse> RecipeTypesGetAsync();
        Task<RecipesSearchResponse> RecipesSearchAsync(RecipesSearchRequest request);
        Task<RecipeGetResponse> RecipeGetAsync(RecipeGetRequest request);
    }
}