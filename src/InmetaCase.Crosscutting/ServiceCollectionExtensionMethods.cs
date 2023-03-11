using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmetaCase.Crosscutting
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IServiceCollection AddFromConfigurationAs<T>(IServiceCollection services, IConfiguration configuration) where T : class
        {
            var service = configuration.GetAs<T>();
            if (service != null) services.AddSingleton(service);
            return services;
        }

        public static IServiceCollection AddFromConfigurationRequiredAs<T>(IServiceCollection services, IConfiguration configuration) where T : class
        {
            var service = configuration.GetRequiredAs<T>();
            return services.AddSingleton(service);
        }

    }

}
