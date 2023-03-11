CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetNumber] NVARCHAR(10) NULL, 
    [BuildingName] NVARCHAR(50) NULL, 
    [StreetName] NVARCHAR(50) NULL, 
    [StreetType] NVARCHAR(50) NULL, 
    [Direction] NVARCHAR(10) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Region] NVARCHAR(50) NULL, 
    [PostalCode] NVARCHAR(10) NULL, 
    [Country] NVARCHAR(50) NULL
)
