using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Business.ViewControl
{
    public class CustomersViewControl
    {
        private readonly ILogger _logger;

        private readonly ICustomerApi _customerApi;

        public List<Customer> Customers { get; private set; } = new();

        public CustomersViewControl(
            ILogger<CustomersViewControl> logger,
            ICustomerApi customerApi)
        {
            _logger = logger;
            _customerApi = customerApi;
        }

        public async Task Load()
        {
            var fetched = await _customerApi.ReadAsync(null, default);
            Customers = fetched.ToList();
        }

    }

}
