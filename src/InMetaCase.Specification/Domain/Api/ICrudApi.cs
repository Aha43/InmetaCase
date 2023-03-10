namespace InMetaCase.Specification.Domain.Api
{
    public interface ICrudApi<T> where T : class
    {
        Task<T> CreateAsync<P>(P param, CancellationToken cancellationToken) where P : class;
        Task<IEnumerable<T>> ReadAsync<P>(P param, CancellationToken cancellationToken) where P : class;
        Task<T> UpdateAsync<P>(P param, CancellationToken cancellationToken) where P : class;
        Task<T> DeleteAsync<P>(P param, CancellationToken cancellationToken) where P : class;
    }
}
