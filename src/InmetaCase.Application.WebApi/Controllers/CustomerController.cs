using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.AspNetCore.Mvc;

namespace InmetaCase.Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger _logger;

        private readonly ICustomerApi _api;

        public CustomerController(ILogger<CustomerController> logger, ICustomerApi api)
        {
            _logger = logger;
            _api = api;
        }

        [HttpPost()]
        public async Task<Customer> CreateAsync([FromBody] Customer customer) =>
            await _api.CreateAsync(customer, default).ConfigureAwait(false);

        [HttpGet()]
        [HttpGet("{id}")]
        public async Task<IEnumerable<Customer>> ReadAsync([FromRoute] int? id) => 
            await _api.ReadAsync(id, default).ConfigureAwait(false);

        [HttpPut()]
        public async Task<Customer?> UpdateAsync([FromBody] Customer customer) => 
            await _api.UpdateAsync(customer, default).ConfigureAwait(false);

        [HttpDelete("{id}")]
        public async Task<Customer?> DeleteAsync([FromRoute] int id) => 
            await _api.DeleteAsync(id, default).ConfigureAwait(false);

    }

}
