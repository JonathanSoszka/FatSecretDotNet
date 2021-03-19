using System;
using FatSecretDotNet.ResponseObjects;

namespace FatSecretDotNet.Authentication
{
    public class FatSecretAuthToken
    {
        private DateTime _expiresAt;
        public string AccessToken { get; set; }
        public bool IsExpired => DateTime.UtcNow >= _expiresAt;

        public FatSecretAuthToken()
        {
            _expiresAt = DateTime.MinValue;
        }
        
        public void SetToken(AuthResponse authResponse)
        {
            AccessToken = authResponse.AccessToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(authResponse.ExpiresIn);
        }
    }
}