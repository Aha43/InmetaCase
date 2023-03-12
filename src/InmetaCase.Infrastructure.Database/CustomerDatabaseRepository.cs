using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Infrastructure.Database;

public class CustomerDatabaseRepository : ICustomerApi
{
    private ILogger _logger;

    private readonly DataContext _dataContext;

    public CustomerDatabaseRepository(
        ILogger<CustomerDatabaseRepository> logger, 
        DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public async Task<Customer> CreateAsync(Customer param, CancellationToken cancellationToken)
    {
        var created = param; // rely on being record type
        _dataContext.Customer.Add(created);
        await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return created;
    }

    public async Task<Customer?> DeleteAsync(int param, CancellationToken cancellationToken)
    {
        var retVal = _dataContext.Customer.Where(e => e.Id == param).FirstOrDefault();
        if (retVal != null)
        {
            _dataContext.Customer.Remove(retVal);
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return retVal;
    }

    public async Task<IEnumerable<Customer>> ReadAsync(int? param, CancellationToken cancellationToken)
    {
        if (param == null)
        {
            return await _dataContext.Customer.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        return await _dataContext.Customer.Where(e => e.Id == param).ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<Customer?> UpdateAsync(Customer param, CancellationToken cancellationToken)
    {
        var updated = _dataContext.Customer.Where(e => e.Id == param.Id).FirstOrDefault();
        if (updated != null)
        {
            updated.AddressId = param.AddressId;
            updated.LastName = param.LastName;
            updated.FirstName = param.FirstName;
            updated.Email = param.Email;
            updated.Phone = param.Phone;
            updated.Title = param.Title;

            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return updated;
    }

}
