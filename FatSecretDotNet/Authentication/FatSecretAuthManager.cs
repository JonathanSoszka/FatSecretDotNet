using System;
using System.Threading.Tasks;
using FatSecretDotNet.ResponseObjects;
using RestSharp;

namespace FatSecretDotNet.Authentication
{
    public class FatSecretAuthManager
    {
        private readonly FatSecretAuthToken _authToken;
        private RestClient _client;
        private readonly FatSecretCredentials _credentials;

        public bool IsPremier => _credentials.Scope.Equals("premier", StringComparison.OrdinalIgnoreCase);

        public FatSecretAuthManager(FatSecretCredentials credentials)
        {
            _credentials = credentials;
            _client = new RestClient("https://oauth.fatsecret.com/connect/token");
            _authToken = new FatSecretAuthToken();
        }

        private async Task GetNewTokenAsync()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded",
                $"grant_type=client_credentials&client_id={_credentials.ClientId}&client_secret={_credentials.ClientSecret}&scope={_credentials.Scope}",
                ParameterType.RequestBody);
            var authTokenResponse = await _client.ExecuteAsync<AuthResponse>(request);
            var authToken = authTokenResponse.Data;
            _authToken.SetToken(authToken);
        }

        public async Task<string> GetAuthHeaderAsync()
        {
          
                if (_authToken.IsExpired)
                {
                    await GetNewTokenAsync();
                }

                return $"Bearer {_authToken.AccessToken}";
            
        }
    }
}