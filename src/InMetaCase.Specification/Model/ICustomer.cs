namespace InMetaCase.Specification.Model
{
    public interface ICustomer
    {
        int Id { get; }

        string? Email { get; }

        string? Title { get; }

        string? FirstName { get; }
        string? LastName { get; }

        string? StreetNumber { get; }
        string? BuildingName { get; }
        string? StreetName { get; }
        string? StreetType { get; }
        string? Direction { get; }
        string? City { get; }
        string? Region { get; }
        string? PostalCode { get; }
        string? Country { get; }
        string? Phone { get; }
    }
}
