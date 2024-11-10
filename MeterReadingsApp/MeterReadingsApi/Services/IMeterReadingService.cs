
namespace MeterReadingsApp.Services
{
    public interface IMeterReadingService
    {
        bool IsAccountValid(MeterReadingModel meterReading, List<AccountModel> accounts);
        bool IsDuplicateReading(MeterReadingModel meterReading, List<MeterReadingModel> existingMeterReading);
        bool IsValidMeterReading(List<AccountModel> accounts, List<MeterReadingModel> existingMeterReading, MeterReadingModel meterReading);
        bool IsValidMeterReadingValue(int meterReadingValue);
        ProcessResult ProcessMeterReadings(List<AccountModel> accounts, List<MeterReadingModel> meterReadings, List<MeterReadingModel> existingMeterReading);
    }
}