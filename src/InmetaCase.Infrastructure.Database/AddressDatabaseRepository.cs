using InmetaCase.Domain.Model;
using InmetaCase.Specification.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InmetaCase.Infrastructure.Database;

public class AddressDatabaseRepository : IAddressApi
{
    private ILogger _logger;

    private readonly DataContext _dataContext;

    public AddressDatabaseRepository(
        ILogger<AddressDatabaseRepository> logger,
        DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public async Task<Address> CreateAsync(Address param, CancellationToken cancellationToken)
    {
        var created = param; // rely on being record type
        _dataContext.Address.Add(created);
        await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return created;
    }

    public async Task<Address?> DeleteAsync(int param, CancellationToken cancellationToken)
    {
        var retVal = _dataContext.Address.Where(e => e.Id == param).FirstOrDefault();
        if (retVal != null)
        {
            _dataContext.Address.Remove(retVal);
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return retVal;
    }

    public async Task<IEnumerable<Address>> ReadAsync(int? param, CancellationToken cancellationToken)
    {
        if (param == null)
        {
            return await _dataContext.Address.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        return await _dataContext.Address.Where(e => e.Id == param).ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<Address?> UpdateAsync(Address param, CancellationToken cancellationToken)
    {
        var updated = _dataContext.Address.Where(e => e.Id == param.Id).FirstOrDefault();
        if (updated != null)
        {
            updated.StreetNumber = param.StreetNumber;
            updated.City = param.City;
            updated.Country = param.Country;
            updated.StreetName = param.StreetName;
            updated.PostalCode = param.PostalCode;
            updated.BuildingName = param.BuildingName;
            updated.Direction = param.Direction;
            updated.Region = param.Region;
            updated.StreetType = param.StreetType;
                
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return updated;
    }

}
