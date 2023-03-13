using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Business.ViewControl
{
    public class OrderViewController
    {
        private readonly ILogger _logger;

        private readonly IOrderApi _orderApi;

        public Order? Order { get; private set; } = new();

        public OrderViewController(
            ILogger<OrderViewController> logger, 
            IOrderApi orderApi)
        {
            _logger = logger;
            _orderApi = orderApi;
        }

        public async Task Load(int id)
        {
            var orders = await _orderApi.ReadAsync(id, default);
            var order = orders.FirstOrDefault();
            if (order != null)
            {
                Order = order;
            }
        }

        public async Task Delete()
        {
            if (Order != null) 
            {
                await _orderApi.DeleteAsync(Order.Id, default);
                Order = null;
            }
        }

    }

}
