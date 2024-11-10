using MeterReadingsDataAccess.Models;

namespace MeterReadingApiTests.Helpers
{
    public class MeterReadingServiceTestHelper
    {
        public static MeterReadingModel CreateMeterReading(int accountId, DateTime meterReadingDateTime, int meterReadValue)
        {
            return new MeterReadingModel { AccountId = accountId, MeterReadingDateTime = meterReadingDateTime, MeterReadValue = meterReadValue };
        }

        public static List<MeterReadingModel> SetupMeterReadingList()
        {
            return [
                 CreateMeterReading(1, DateTime.Now, 10001),
                 CreateMeterReading(2, DateTime.Now, 10002)
             ];
        }

        public static List<AccountModel> SetupAccountList()
        {
            return
            [
                new()
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName1"
                },
                new()
                {
                    Id = 3,
                    FirstName = "FirstName3",
                    LastName = "LastName3"
                }
            ];
        }
    }
}
