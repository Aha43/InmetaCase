using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Infrastructure.Http
{
    public class AddressHttpRepository : HttpClientApiBase<Address>, IAddressApi
    {
        public AddressHttpRepository(
            ILogger<AddressHttpRepository> logger, 
            IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }

        public async Task<Address> CreateAsync(Address param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Address?> DeleteAsync(int param, CancellationToken cancellationToken)
        {
            return await DeleteAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Address>> ReadAsync(int? param, CancellationToken cancellationToken)
        {
            if (param == null)
            {
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            return await GetAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<Address?> UpdateAsync(Address param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

    }

    public class CustomerHttpRepository : HttpClientApiBase<Customer>, ICustomerApi
    {
        public CustomerHttpRepository(
            ILogger<CustomerHttpRepository> logger,
            IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }

        public async Task<Customer> CreateAsync(Customer param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Customer?> DeleteAsync(int param, CancellationToken cancellationToken)
        {
            return await DeleteAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Customer>> ReadAsync(int? param, CancellationToken cancellationToken)
        {
            if (param == null)
            {
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            return await GetAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<Customer?> UpdateAsync(Customer param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

    }

    public class OrderHttpRepository : HttpClientApiBase<Order>, IOrderApi
    {
        public OrderHttpRepository(
            ILogger<OrderHttpRepository> logger,
            IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }

        public async Task<Order> CreateAsync(Order param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Order?> DeleteAsync(int param, CancellationToken cancellationToken)
        {
            return await DeleteAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Order>> ReadAsync(int? param, CancellationToken cancellationToken)
        {
            if (param == null)
            {
                return await GetAsync(cancellationToken).ConfigureAwait(false);
            }

            return await GetAsync($"{param}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<Order?> UpdateAsync(Order param, CancellationToken cancellationToken)
        {
            return await PostAsync(param, cancellationToken).ConfigureAwait(false);
        }

    }

}
