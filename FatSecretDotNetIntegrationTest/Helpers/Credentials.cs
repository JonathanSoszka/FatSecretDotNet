using System.IO;
using FatSecretDotNet.Authentication;
using Microsoft.Extensions.Configuration;

namespace FatSecretDotNetIntegrationTest.Helpers
{
    //store your credentials in appsettings.json wherever the app is compiled to
    //this is most likely bin/Debug/net5.0
    public class Credentials
    {
        public static FatSecretCredentials GetCredentials()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var credentials = new FatSecretCredentials();
            credentials = config.GetSection("Credentials").Get<FatSecretCredentials>();

            return credentials;
        }
    }
}