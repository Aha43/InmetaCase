using InMetaCase.Specification.Model;

namespace InMetaCase.Domain.Model;

public record class Customer : ICustomer
{
    public int Id { get; set; }
    public string? Email { get; set; }

    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? StreetNumber { get; set; }
    public string? BuildingName { get; set; }
    public string? StreetName { get; set; }
    public string? StreetType { get; set; }
    public string? Direction { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
}
