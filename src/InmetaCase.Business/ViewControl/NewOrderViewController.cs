using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmetaCase.Business.ViewControl
{
    public class NewOrderViewController
    {
        private readonly ILogger _logger;

        private readonly ICustomerApi _customerApi;
        private readonly IOrderApi _orderApi;
        private readonly IAddressApi _addressApi;

        public Customer Customer { get; private set; } = new();
        public Address CustomerAddress { get; private set; } = new();
        public Address OrderAddress { get; private set; } = new();

        public Order Order { get; private set; } = new();

        public NewOrderViewController(
            ILogger<NewOrderViewController> logger,
            ICustomerApi customerApi,
            IOrderApi orderApi,
            IAddressApi addressApi)
        {
            _logger = logger;
            _customerApi = customerApi;
            _orderApi = orderApi;
            _addressApi = addressApi;
        }

        public async Task Load(int customerId)
        {
            var customers = await _customerApi.ReadAsync(customerId, default);
            var customer = customers.FirstOrDefault();
            if (customer != null) 
            {
                Customer = customer;
                var addresses = await _addressApi.ReadAsync(customer.AddressId, default);
                var customerAddress = addresses.FirstOrDefault();
                if (customerAddress != null) 
                {
                    CustomerAddress = customerAddress;
                }

                Order = new()
                {
                    CustomerId = customer.Id,
                    OrderDate = DateTime.Now,
                    ServiceType = (int)ServiceType.Moving
                };
            }
        }

        public async Task SaveOrder(Order order)
        {
            var created = await _orderApi.CreateAsync(order, default);
            if (created != null) 
            {
                Order = created;
            }
        }

        public async Task SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                var created = await _customerApi.CreateAsync(customer, default);
                if (created != null)
                {
                    Customer = created;
                }
            }
            else
            {
                var updated = await _customerApi.UpdateAsync(customer, default);
                if (updated != null)
                {
                    Customer = updated;
                }
            }
        }

        public async Task SaveOrderAddress(Address address)
        {
            if (Order.Id == 0) return;

            if (address.Id == 0)
            {
                var created = await _addressApi.CreateAsync(address, default);
                if (created != null)
                {
                    Order.AddressId = created.Id;
                    var updated = await _orderApi.UpdateAsync(Order, default);
                    if (updated != null)
                    {
                        Order = updated;
                        OrderAddress = created;
                    }
                }
            }
            else
            {
                var updated = await _addressApi.UpdateAsync(address, default);
                if (updated != null)
                {
                    OrderAddress = updated;
                }
            }
        }

        public async Task SaveCustomerAddress(Address address)
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
                        CustomerAddress = created;
                    }
                }
            }
            else
            {
                var updated = await _addressApi.UpdateAsync(address, default);
                if (updated != null)
                {
                    CustomerAddress = updated;
                }
            }
        }

    }

}
