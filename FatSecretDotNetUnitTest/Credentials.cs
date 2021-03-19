using FatSecretDotNet.Authentication;

namespace FatSecretDotNetUnitTest
{
    //Use this class to store the test credentials. This clas is not git tracked but make sure you don't commit any secrets.
    public class Credentials
    {
        public FatSecretCredentials GetCredentials()
        {
            return new FatSecretCredentials()
            {
                ClientId = "",
                ClientSecret = "",
                Scope = ""
            };
        }
    }
}