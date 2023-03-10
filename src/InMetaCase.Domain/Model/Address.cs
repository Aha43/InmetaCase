using InMetaCase.Specification.Model;

namespace InMetaCase.Domain.Model
{
    public class Address : IAddress
    {
        public string? StreetNumber { get; set; }
        public string? BuildingName { get; set; }
        public string? StreetName { get; set; }
        public string? StreetType { get; set; }
        public string? Direction { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
