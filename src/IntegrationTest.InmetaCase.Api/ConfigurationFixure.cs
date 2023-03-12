using InmetaCase.Infrastructure.Database;
using InmetaCase.Infrastructure.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IntegrationTest.InmetaCase.Api
{
    public class ConfigurationFixure : IDisposable
    {
        private Dictionary<string, ServiceProvider> _serviceProviders = new();

        public ConfigurationFixure() 
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddJsonFile("appsettings.json", true)
                .Build();

            var dbServices = new ServiceCollection()
                .AddLogging()
                .AddInmetaCaseDatabase(configuration);

            _serviceProviders.Add("db", dbServices.BuildServiceProvider());

            var httpServices = new ServiceCollection()
                .AddLogging()
                .AddInmetaCaseHttpClients(configuration);

            _serviceProviders.Add("http", httpServices.BuildServiceProvider());
        }

        public IServiceProvider GetServiceProviderFor(string system) => _serviceProviders[system];

        public void Dispose() { }

    }

    [CollectionDefinition("Configuration collection")]
    public class ConfigurationCollection : ICollectionFixture<ConfigurationFixure> { }

}
