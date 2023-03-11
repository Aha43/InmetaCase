using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Infrastructure.Database;

public class OrderDatabaseRepository : IOrderApi
{
    private ILogger _logger;

    private readonly DataContext _dataContext;

    public OrderDatabaseRepository(
        ILogger<OrderDatabaseRepository> logger, 
        DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public async Task<Order> CreateAsync(Order param, CancellationToken cancellationToken)
    {
        var created = param; // rely on being record type
        _dataContext.Order.Add(created);
        await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return created;
    }

    public async Task<Order?> DeleteAsync(int param, CancellationToken cancellationToken)
    {
        var retVal = _dataContext.Order.Where(e => e.Id == param).FirstOrDefault();
        if (retVal != null)
        {
            _dataContext.Order.Remove(retVal);
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return retVal;
    }

    public async Task<IEnumerable<Order>> ReadAsync(int? param, CancellationToken cancellationToken)
    {
        if (param == null)
        {
            return await _dataContext.Order.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        return await _dataContext.Order.Where(e => e.Id == param).ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<Order?> UpdateAsync(Order param, CancellationToken cancellationToken)
    {
        var updated = _dataContext.Order.Where(e => e.Id == param.Id).FirstOrDefault();
        if (updated != null)
        {
            if (!param.Equals(updated))
            {
                updated.OrderDate = param.OrderDate;
                updated.AddressId = param.AddressId;
                updated.CustomerId = param.CustomerId;
                updated.Note = param.Note;
                updated.ServiceType = param.ServiceType;
                
                await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        return updated;
    }

}
