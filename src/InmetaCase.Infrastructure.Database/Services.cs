using InmetaCase.Specification.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmetaCase.Infrastructure.Database;

public static class Services
{
    public static IServiceCollection AddInmetaCaseDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSingleton(configuration)
            .AddSingleton<DataContext>()
            .AddSingleton<IAddressApi, AddressDatabaseRepository>();
    }
}
