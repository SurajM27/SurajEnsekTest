CREATE PROCEDURE [dbo].[spMeterReading_Insert]
	@AccountId int,
	@MeterReadingDateTime datetime,
	@MeterReadValue int
AS
BEGIN
	INSERT INTO dbo.[MeterReading] (AccountId, MeterReadingDateTime, MeterReadValue)
	Values (@AccountId, @MeterReadingDateTime, @MeterReadValue);
END
