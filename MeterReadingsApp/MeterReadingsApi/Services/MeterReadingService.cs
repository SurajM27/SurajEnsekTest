namespace MeterReadingsApp.Services
{
    public class MeterReadingService : IMeterReadingService
    {

        private readonly IMeterReadingData _meterReadingData;
        public MeterReadingService()
        {

        }
        public MeterReadingService(IMeterReadingData meterReadingData)
        {
            _meterReadingData = meterReadingData;
        }

        public ProcessResult ProcessMeterReadings(List<AccountModel> accounts, List<MeterReadingModel> meterReadings, List<MeterReadingModel> existingMeterReading)
        {
            var processResult = new ProcessResult
            {
                SuccessfulReadings = 0,
                FailedReadings = 0
            };


            foreach (var meterReading in meterReadings)
            {
                if (IsValidMeterReading(accounts, existingMeterReading, meterReading))
                {
                    _meterReadingData.InsertMeterReading(meterReading);

                    processResult.SuccessfulReadings++;
                }
                else
                {
                    processResult.FailedReadings++;
                }
            }

            return processResult;
        }

        public bool IsValidMeterReading(List<AccountModel> accounts, List<MeterReadingModel> existingMeterReading, MeterReadingModel meterReading)
        {
            var isValidMeterReading = !IsDuplicateReading(meterReading, existingMeterReading)
                                    && IsAccountValid(meterReading, accounts)
                                    && IsValidMeterReadingValue(meterReading.MeterReadValue);

            return isValidMeterReading;
        }

        public bool IsDuplicateReading(MeterReadingModel meterReading, List<MeterReadingModel> existingMeterReading)
        {
            var IsduplicateReading = existingMeterReading.Exists(x => x.AccountId == meterReading.AccountId && x.MeterReadValue == meterReading.MeterReadValue);

            return IsduplicateReading;
        }

        public bool IsAccountValid(MeterReadingModel meterReading, List<AccountModel> accounts)
        {
            var accountValid = accounts.Exists(x => x.Id == meterReading.AccountId);
            return accountValid;
        }

        public bool IsValidMeterReadingValue(int meterReadingValue)
        {
            var validMeterReadingValue = false;

            if (meterReadingValue > 0)
            {
                validMeterReadingValue = meterReadingValue.ToString()?.Length == 5;
            }

            return validMeterReadingValue;
        }
    }
}
