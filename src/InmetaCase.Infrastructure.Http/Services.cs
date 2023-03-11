using InmetaCase.Specification.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InmetaCase.Infrastructure.Http
{
    public static class Services
    {
        public static IServiceCollection AddInmetaCaseHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddInmetaCaseHttpClients(configuration)
                .AddApis();
        }

        private static IServiceCollection AddApis(this IServiceCollection services)
        {
            return services.AddSingleton<IAddressApi, AddressHttpRepository>()
                .AddSingleton<IAddressApi, AddressHttpRepository>()
                .AddSingleton<ICustomerApi, CustomerHttpRepository>();
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) 
        {
            var uri = configuration["InmetaCaseWebApiUri"];
            if (uri != null) 
            { 
                var baseUri = new Uri(uri);

                services.AddHttpClient(nameof(AddressHttpRepository), client =>
                {
                    client.BaseAddress = new Uri(baseUri, "Address");
                });
                services.AddHttpClient(nameof(CustomerHttpRepository), client =>
                {
                    client.BaseAddress = new Uri(baseUri, "Customer");
                });
                services.AddHttpClient(nameof(CustomerHttpRepository), client =>
                {
                    client.BaseAddress = new Uri(baseUri, "Customer");
                });
            }

            return services;
        }

    }

}
