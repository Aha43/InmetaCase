namespace InMetaCase.Specification.Domain.Model;

public interface ICustomer
{
    int Id { get; }

    string? Email { get; }
    string? Phone { get; }

    string? Title { get; }

    string? FirstName { get; }
    string? LastName { get; }

    int AddressId { get; }
}
