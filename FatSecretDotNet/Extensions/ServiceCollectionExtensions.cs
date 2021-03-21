using FatSecretDotNet.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace FatSecretDotNet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFatSecretClient(this IServiceCollection services, FatSecretCredentials credentials)
        {
            services.AddSingleton<IFatSecretClient>(x=> new FatSecretClient(credentials));
            return services;
        }
    }
}