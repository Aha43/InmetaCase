using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest.InmetaCase.Api
{
    [Collection("Configuration collection")]
    public class AddressApiTest
    {
        private readonly ConfigurationFixure _fixure;

        public AddressApiTest(ConfigurationFixure fixure) => _fixure = fixure;

        [Fact]
        public async Task CrudAddressAsync()
        {
            var api = _fixure.ServiceProvider.GetRequiredService<IAddressApi>();

            await AddressShouldBeCreated(api).ConfigureAwait(false);
        }

        private async Task AddressShouldBeCreated(IAddressApi api)
        {
            // Act
            var address = new Address
            {
                StreetName = "Midtunbrekka",
                StreetNumber = "6",
                PostalCode= "1234",
                City = "Nesttun",
                Country = "Norway"
            };

            var created = await api.CreateAsync(address, default).ConfigureAwait(false);

            // Assert
        }

    }

}
