using InmetaCase.Business.ViewControl;
using Microsoft.Extensions.DependencyInjection;

namespace InmetaCase.Business
{
    public static class Services
    {
        public static IServiceCollection AddInmetaBusiness(this IServiceCollection services)
        {
            return services.AddSingleton<CustomersViewControl>();
        }
    }
}
