using InmetaCase.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IntegrationTest.InmetaCase.Api
{
    public class ConfigurationFixure : IDisposable
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public ConfigurationFixure() 
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddJsonFile("appsettings.json", true)
                .Build();

            var services = new ServiceCollection()
                .AddLogging()
                .AddInmetaCaseDatabase(configuration);

            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose() { }

    }

    [CollectionDefinition("Configuration collection")]
    public class ConfigurationCollection : ICollectionFixture<ConfigurationFixure> { }

}
