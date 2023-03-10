namespace InMetaCase.Specification.Model;

public interface IOrder
{
    int Id { get; }
    int CustomerId { get; }
    int? AddressId { get; }
    int ServiceType { get; }
    DateTime OrderDate { get; }
    string? Note { get; }
}
