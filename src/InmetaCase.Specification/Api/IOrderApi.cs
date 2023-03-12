using InmetaCase.Domain.Model;

namespace InmetaCase.Specification.Api;

public interface IOrderApi : ICrudApi<Order, Order, int?, Order, int>
{
    public Task<IEnumerable<Order>> Search(OrderSearchParam param, CancellationToken cancellationToken);
}
