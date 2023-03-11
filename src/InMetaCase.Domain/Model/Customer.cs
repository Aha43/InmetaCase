namespace InmetaCase.Domain.Model;

public record class Customer
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int AddressId { get; set; }
}
