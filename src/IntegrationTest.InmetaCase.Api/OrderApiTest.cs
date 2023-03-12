using FluentAssertions;
using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest.InmetaCase.Api;

[Collection("Configuration collection")]
public class OrderApiTest
{
    private readonly ConfigurationFixure _fixure;

    public OrderApiTest(ConfigurationFixure fixure) => _fixure = fixure;

    [Theory]
    [InlineData("http")]
    [InlineData("db")]
    public async Task CrudOrderAsync(string system)
    {
        var api = _fixure.GetServiceProviderFor(system).GetRequiredService<IOrderApi>();

        var order = await OrderShouldBeCreated(api).ConfigureAwait(false);
        order = await OrderShouldBeRead(api, order.Id).ConfigureAwait(false);
        order = await OrderShouldBeUpdated(api, order).ConfigureAwait(false);
        await OrderShouldBeDeleted(api, order).ConfigureAwait(false);
    }

    private async Task<Order> OrderShouldBeCreated(IOrderApi api)
    {
        // Act
        var order = new Order
        {
            AddressId = 1,
            ServiceType = (int)ServiceType.Moving,
            Note = "test order",
            OrderDate = DateTime.Now
        };

        var created = await api.CreateAsync(order, default).ConfigureAwait(false);

        // Assert
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);

        var expected = order with { Id = created.Id };
        created.Should().Be(expected);

        return created;
    }

    private async Task<Order> OrderShouldBeRead(IOrderApi api, int id)
    {
        // Act
        var read = await api.ReadAsync(id, default).ConfigureAwait(false);

        // Assert
        read.Should().NotBeNull().And.HaveCount(1);

        var order = read.First();
        order.Id.Should().Be(id);

        return order;
    }

    private async Task<Order> OrderShouldBeUpdated(IOrderApi api, Order address)
    {
        // Act
        var updatedOrder = address with { ServiceType = (int)ServiceType.Packing };
        var updated = await api.UpdateAsync(updatedOrder, default).ConfigureAwait(false);

        // Assert
        updated.Should().NotBeNull().And.Be(updatedOrder);

        var fetched = await api.ReadAsync(updated!.Id, default).ConfigureAwait(false);
        fetched.First().Should().Be(updatedOrder);

        return updated!;
    }

    private async Task OrderShouldBeDeleted(IOrderApi api, Order order)
    {
        // Act
        var deleted = await api.DeleteAsync(order.Id, default).ConfigureAwait(false);

        // Assert
        deleted.Should().NotBeNull().And.Be(order);

        var fetched = await api.ReadAsync(order.Id, default).ConfigureAwait(false);
        fetched.Any().Should().Be(false);
    }

}
