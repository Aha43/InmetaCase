using FluentAssertions;
using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest.InmetaCase.Api;

[Collection("Configuration collection")]
public class AddressApiTest
{
    private readonly ConfigurationFixure _fixure;

    public AddressApiTest(ConfigurationFixure fixure) => _fixure = fixure;

    [Fact]
    public async Task CrudAddressAsync()
    {
        var api = _fixure.ServiceProvider.GetRequiredService<IAddressApi>();

        var address = await AddressShouldBeCreated(api).ConfigureAwait(false);
        address = await AddressShouldBeRead(api, address.Id).ConfigureAwait(false);
        address = await AddressShouldBeUpdated(api, address, "Heldalsåsen").ConfigureAwait(false);
        await AddressShouldBeDeleted(api, address).ConfigureAwait(false);
    }

    private async Task<Address> AddressShouldBeCreated(IAddressApi api)
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
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);

        var expected = address with { Id = created.Id };
        created.Should().Be(expected);

        return created;
    }

    private async Task<Address> AddressShouldBeRead(IAddressApi api, int id)
    {
        // Act
        var read = await api.ReadAsync(id, default).ConfigureAwait(false);

        // Assert
        read.Should().NotBeNull().And.HaveCount(1);

        var address = read.First();
        address.Id.Should().Be(id);

        return address;
    }

    private async Task<Address> AddressShouldBeUpdated(IAddressApi api, Address address, string newStreet)
    {
        // Act
        var updatedAddress = address with { StreetName = newStreet };
        var updated = await api.UpdateAsync(updatedAddress, default).ConfigureAwait(false);

        // Assert
        updated.Should().NotBeNull().And.Be(updatedAddress);

        var fetched = await api.ReadAsync(updated!.Id, default).ConfigureAwait(false);
        fetched.First().Should().Be(updatedAddress);

        return updated!;
    }

    private async Task AddressShouldBeDeleted(IAddressApi api, Address address)
    {
        // Act
        var deleted = await api.DeleteAsync(address.Id, default).ConfigureAwait(false);

        // Assert
        deleted.Should().NotBeNull().And.Be(address);

        var fetched = await api.ReadAsync(address.Id, default).ConfigureAwait(false);
        fetched.Any().Should().Be(false);
    }

}
