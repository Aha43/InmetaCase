CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [AddressId] INT NULL, 
    [ServiceType] INT NOT NULL, 
    [OrderDate] DATE NOT NULL, 
    [Note] NVARCHAR(MAX) NULL
)
