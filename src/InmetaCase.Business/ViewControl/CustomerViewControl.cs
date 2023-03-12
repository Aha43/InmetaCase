using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;

namespace InmetaCase.Business.ViewControl
{
    public class CustomerViewControl
    {
        private ICustomerApi _customerApi;
        private IAddressApi _addressApi;
        private IOrderApi _orderApi;

        public Customer Customer { get; private set; } = new();
        public Address Address { get; private set; } = new();

        public CustomerViewControl(
            ICustomerApi customerApi,
            IAddressApi addressApi,
            IOrderApi orderApi)
        { 
            _customerApi = customerApi;
            _addressApi = addressApi;
            _orderApi = orderApi;
        }

        public async Task LoadAsync(int id)
        {
            var customers = await _customerApi.ReadAsync(id, default);
            var customer = customers.FirstOrDefault();
            if (customer != null)
            {
                Customer = customer;
                var addresses = await _addressApi.ReadAsync(customer.AddressId, default);
                var address = addresses.FirstOrDefault();
                if (address != null) 
                {
                    Address = address; 
                }
            }
        }

        public async Task SaveAddress(Address address)
        {
            if (address.Id == 0)
            {
                var created = await _addressApi.CreateAsync(address, default);
                if (created != null) 
                {
                    Customer.AddressId = created.Id;
                    var updated = await _customerApi.UpdateAsync(Customer, default);
                    if (updated != null) 
                    {
                        Customer = updated;
                        Address = created;
                    }
                }
            }
            else
            {
                var updated = await _addressApi.UpdateAsync(address, default);
                if (updated != null)
                {
                    Address = updated;
                }
            }
        }

    }

}
