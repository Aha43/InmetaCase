namespace InmetaCase.Domain.Model;

public record class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int? AddressId { get; set; }
    public int ServiceType { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Note { get; set; }
}
