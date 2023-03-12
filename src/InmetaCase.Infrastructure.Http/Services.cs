using InmetaCase.Specification.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmetaCase.Infrastructure.Http
{
    public static class Services
    {
        public static IServiceCollection AddInmetaCaseHttpClientsApi(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddHttpClients(configuration)
                .AddApis();
        }

        private static IServiceCollection AddApis(this IServiceCollection services)
        {
            return services.AddSingleton<IAddressApi, AddressHttpRepository>()
                .AddSingleton<IOrderApi, OrderHttpRepository>()
                .AddSingleton<ICustomerApi, CustomerHttpRepository>();
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) 
        {
            var uri = configuration["InmetaCaseWebApiUri"];
            if (uri != null) 
            { 
                services.AddHttpClient(nameof(AddressHttpRepository), client =>
                {
                    var baseAddress = $"{uri}/Address/";
                    client.BaseAddress = new Uri(baseAddress);
                });
                services.AddHttpClient(nameof(CustomerHttpRepository), client =>
                {
                    var baseAddress = $"{uri}/Customer/";
                    client.BaseAddress = new Uri(baseAddress);
                });
                services.AddHttpClient(nameof(OrderHttpRepository), client =>
                {
                    var baseAddress = $"{uri}/Order/";
                    client.BaseAddress = new Uri(baseAddress);
                });
            }

            return services;
        }

    }

}
