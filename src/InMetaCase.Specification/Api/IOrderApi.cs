using InMetaCase.Domain.Model;

namespace InMetaCase.Specification.Api
{
    public interface IOrderApi : ICrudApi<Order, Order, int?, Order, int>
    {
    }
}
