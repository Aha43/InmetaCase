namespace InMetaCase.Specification.Api
{
    public interface ICrudApi<T> where T : class
    {
        Task<T> CreateAsync<P>(P param, CancellationToken cancellationToken);
        Task<IEnumerable<T>> ReadAsync<P>(P param, CancellationToken cancellationToken);
        Task<T> UpdateAsync<P>(P param, CancellationToken cancellationToken);
        Task<T> DeleteAsync<P>(P param, CancellationToken cancellationToken);
    }
}
