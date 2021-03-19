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
    public class FatSecretClient
    {
        private readonly FatSecretAuthManager _authManager;
        private readonly IRestClient _client;

        public FatSecretClient(FatSecretCredentials credentials)
        {
            _authManager = new FatSecretAuthManager(credentials);
            _client = new RestClient("https://platform.fatsecret.com/rest/server.api");
        }

        public GetFoodResponse GetFood(GetFoodRequest request)
        {
            return FatSecretRequest<GetFoodResponse>(request);
        }

        public SearchFoodResponse SearchFood(SearchFoodsRequest request)
        {
            return FatSecretRequest<SearchFoodResponse>(request);
        }

        public RecipieTypesResponse GetRecipieTypes()
        {
            return FatSecretRequest<RecipieTypesResponse>(new RecipieTypesRequest());
        }

        public RecipesSearchResponse RecipesSearch(RecipesSearchRequest request)
        {
            return FatSecretRequest<RecipesSearchResponse>(request);
        }

        public RecipeGetResponse RecipeGet(RecipeGetRequest request)
        {
            return FatSecretRequest<RecipeGetResponse>(request);
        }

        private T FatSecretRequest<T>(IFatSecretRequest fatSecretRequest) where T : FatSecretResponse
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _authManager.AuthHeader);

            foreach (var header in fatSecretRequest.GetHeaders())
            {
                request.AddParameter(header.Item1, header.Item2);
            }

            request.AddParameter("format", "json");

            var response = _client.Execute<T>(request);
            var fatSecretResponse = response.Data;

            var fatSecretErrorResponse = JsonConvert.DeserializeObject<FatSecretErrorResponse>(response.Content);
            if (fatSecretErrorResponse.Error != null)
            {
                fatSecretResponse.Error = fatSecretErrorResponse.Error;
            }

            return fatSecretResponse;
        }
    }
}