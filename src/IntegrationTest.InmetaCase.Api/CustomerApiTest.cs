using FluentAssertions;
using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest.InmetaCase.Api;

[Collection("Configuration collection")]
public class CustomerApiTest
{
    private readonly ConfigurationFixure _fixure;

    public CustomerApiTest(ConfigurationFixure fixure) => _fixure = fixure;

    [Theory]
    [InlineData("db")]
    [InlineData("http")]
    public async Task CrudCustomerAsync(string system)
    {
        var api = _fixure.GetServiceProviderFor(system).GetRequiredService<ICustomerApi>();

        var customer = await CustomerShouldBeCreated(api).ConfigureAwait(false);
        customer = await CustomerShouldBeRead(api, customer.Id).ConfigureAwait(false);
        customer = await CustomerShouldBeUpdated(api, customer).ConfigureAwait(false);
        await CustomerShouldBeDeleted(api, customer).ConfigureAwait(false);
    }

    private async Task<Customer> CustomerShouldBeCreated(ICustomerApi api)
    {
        // Act
        var customer = new Customer
        {
            AddressId = 10,
            Email = "arne@online.no",
            FirstName = "Arne",
            LastName = "Halvorsen",
            Phone = "+47 48048261",
            Title = "Hr",
        };

        var created = await api.CreateAsync(customer, default).ConfigureAwait(false);

        // Assert
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);

        var expected = customer with { Id = created.Id };
        created.Should().Be(expected);

        return created;
    }

    private async Task<Customer> CustomerShouldBeRead(ICustomerApi api, int id)
    {
        // Act
        var read = await api.ReadAsync(id, default).ConfigureAwait(false);

        // Assert
        read.Should().NotBeNull().And.HaveCount(1);

        var customer = read.First();
        customer.Id.Should().Be(id);

        return customer;
    }

    private async Task<Customer> CustomerShouldBeUpdated(ICustomerApi api, Customer customer)
    {
        // Act
        var updatedCustomer = customer with { Title = "Sir" };
        var updated = await api.UpdateAsync(updatedCustomer, default).ConfigureAwait(false);

        // Assert
        updated.Should().NotBeNull().And.Be(updated);

        var fetched = await api.ReadAsync(updated!.Id, default).ConfigureAwait(false);
        fetched.First().Should().Be(updatedCustomer);

        return updated!;
    }

    private async Task CustomerShouldBeDeleted(ICustomerApi api, Customer customer)
    {
        // Act
        var deleted = await api.DeleteAsync(customer.Id, default).ConfigureAwait(false);

        // Assert
        deleted.Should().NotBeNull().And.Be(customer);

        var fetched = await api.ReadAsync(customer.Id, default).ConfigureAwait(false);
        fetched.Any().Should().Be(false);
    }

}
