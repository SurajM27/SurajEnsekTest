CREATE TABLE [dbo].[MeterReading]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[AccountId] INT NOT NULL FOREIGN KEY REFERENCES Account(Id),
	[MeterReadingDateTime] DateTime NOT NULL,
	[MeterReadValue] int NOT NULL
)
