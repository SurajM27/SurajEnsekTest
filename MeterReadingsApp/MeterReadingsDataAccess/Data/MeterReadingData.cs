using MeterReadingsDataAccess.DbAccess;
using MeterReadingsDataAccess.Models;

namespace MeterReadingsDataAccess.Data
{
    public class MeterReadingData : IMeterReadingData
    {
        private readonly ISqlDataAccess _db;

        public MeterReadingData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<MeterReadingModel>> GetMeterReadings() =>
            _db.LoadData<MeterReadingModel, dynamic>("spMeterReading_GetAll", new {});

        public Task InsertMeterReading(MeterReadingModel meterReading) =>
            _db.SaveData("dbo.spMeterReading_Insert", new { meterReading.AccountId, meterReading.MeterReadingDateTime, meterReading.MeterReadValue });
    }
}
