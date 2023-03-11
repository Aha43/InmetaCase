using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.AspNetCore.Mvc;

namespace InmetaCase.Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger _logger;

        private readonly IAddressApi _api;

        public AddressController(ILogger<CustomerController> logger, IAddressApi api)
        {
            _logger = logger;
            _api = api;
        }

        [HttpPost()]
        public async Task<Address> CreateAsync([FromBody] Address address) =>
            await _api.CreateAsync(address, default).ConfigureAwait(false);

        [HttpGet()]
        [HttpGet("{id}")]
        public async Task<IEnumerable<Address>> ReadAsync([FromRoute] int? id) => 
            await _api.ReadAsync(id, default).ConfigureAwait(false);

        [HttpPut()]
        public async Task<Address?> UpdateAsync([FromBody] Address customer) => 
            await _api.UpdateAsync(customer, default).ConfigureAwait(false);

        [HttpDelete("{id}")]
        public async Task<Address?> DeleteAsync([FromRoute] int id) => 
            await _api.DeleteAsync(id, default).ConfigureAwait(false);

    }

}
