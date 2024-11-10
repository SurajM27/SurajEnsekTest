CREATE PROCEDURE [dbo].[spMeterReading_GetAll]
AS
BEGIN
	SELECT AccountId, MeterReadingDateTime, MeterReadValue 
	FROM dbo.[MeterReading];
END
