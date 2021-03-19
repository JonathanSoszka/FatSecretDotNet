using FatSecretDotNet.ResponseObjects;
using RestSharp;

namespace FatSecretDotNet.Authentication
{
    public class FatSecretAuthManager
    {
        private readonly FatSecretAuthToken _authToken;
        private RestClient _client;
        private readonly FatSecretCredentials _credentials;

        public FatSecretAuthManager(FatSecretCredentials credentials)
        {
            _credentials = credentials;
            _client = new RestClient("https://oauth.fatsecret.com/connect/token");
            _authToken = new FatSecretAuthToken();
            GetNewToken();
        }

        private void GetNewToken()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={_credentials.ClientId}&client_secret={_credentials.ClientSecret}&scope={_credentials.Scope}", ParameterType.RequestBody);
            var authTokenResponse = _client.Execute<AuthResponse>(request).Data;
            _authToken.SetToken(authTokenResponse);
        }

        public string AuthHeader
        {
            get
            {
                if (_authToken.IsExpired)
                {
                    GetNewToken();
                }

                return $"Bearer {_authToken.AccessToken}";
            }
        }
        
        
    }
}