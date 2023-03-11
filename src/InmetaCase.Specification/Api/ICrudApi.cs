namespace InmetaCase.Specification.Api;

public interface ICrudApi<T, C, R, U, D> where T : class
{
    Task<T> CreateAsync(C param, CancellationToken cancellationToken);
    Task<IEnumerable<T>> ReadAsync(R param, CancellationToken cancellationToken);
    Task<T?> UpdateAsync(U param, CancellationToken cancellationToken);
    Task<T?> DeleteAsync(D param, CancellationToken cancellationToken);
}
