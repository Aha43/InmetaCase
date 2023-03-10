﻿namespace InMetaCase.Specification.Model
{
    public interface IAddress
    {
        string? StreetNumber { get; }
        string? BuildingName { get; }
        string? StreetName { get; }
        string? StreetType { get; }
        string? Direction { get; }
        string? City { get; }
        string? Region { get; }
        string? PostalCode { get; }
        string? Country { get; }
    }
}
