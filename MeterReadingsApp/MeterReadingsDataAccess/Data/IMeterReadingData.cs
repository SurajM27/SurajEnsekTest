using MeterReadingsDataAccess.Models;

namespace MeterReadingsDataAccess.Data
{
    public interface IMeterReadingData
    {
        Task<IEnumerable<MeterReadingModel>> GetMeterReadings();
        Task InsertMeterReading(MeterReadingModel meterReading);
    }
}