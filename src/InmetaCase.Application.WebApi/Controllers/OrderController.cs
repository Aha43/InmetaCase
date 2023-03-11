using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.AspNetCore.Mvc;

namespace InmetaCase.Application.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger _logger;

    private readonly IOrderApi _api;

    public OrderController(ILogger<OrderController> logger, IOrderApi api)
    {
        _logger = logger;
        _api = api;
    }

    [HttpPost()]
    public async Task<Order> CreateAsync([FromBody] Order order) =>
        await _api.CreateAsync(order, default).ConfigureAwait(false);

    [HttpGet()]
    [HttpGet("{id}")]
    public async Task<IEnumerable<Order>> ReadAsync([FromRoute] int? id) =>
        await _api.ReadAsync(id, default).ConfigureAwait(false);

    [HttpPut()]
    public async Task<Order?> UpdateAsync([FromBody] Order order) =>
        await _api.UpdateAsync(order, default).ConfigureAwait(false);

    [HttpDelete("{id}")]
    public async Task<Order?> DeleteAsync([FromRoute] int id) =>
        await _api.DeleteAsync(id, default).ConfigureAwait(false);
}
