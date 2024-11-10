using MeterReadingApiTests.Helpers;
using MeterReadingsApp.Services;
using MeterReadingsDataAccess.Models;

namespace MeterReadingApiTests
{
    public class MeterReadingServiceTests
    {

        [Fact]
        public void IsDuplicateReading_GivenReadingInExisingMeterReadingList_ReturnTrue()
        {
            //Arrange
            var expectedResult = true;
            var meterReadingService = new MeterReadingService();           

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(1, DateTime.Now, 10001);
            var existingMeterReadings = MeterReadingServiceTestHelper.SetupMeterReadingList();

            //Act
            var actualResult = meterReadingService.IsDuplicateReading(meterReading, existingMeterReadings);

            //Assert
            Assert.Equal(expectedResult, actualResult);
         
        }

        [Fact]
        public void IsDuplicateReading_GivenReadingNotInExisingMeterReadingList_ReturnFalse()
        {
            //Arrange
            var expectedResult = false;
            var meterReadingService = new MeterReadingService();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(3, DateTime.Now, 10003);
            var existingMeterReadings = MeterReadingServiceTestHelper.SetupMeterReadingList();

            //Act
            var actualResult = meterReadingService.IsDuplicateReading(meterReading, existingMeterReadings);

            //Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void IsAccountValid_GivenReadingAccountInAccountList_ReturnTrue()
        {
            //Arrange
            var expectedResult = true;
            var meterReadingService = new MeterReadingService();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(2, DateTime.Now, 10002);
            var accounts = MeterReadingServiceTestHelper.SetupAccountList();

            //Act
            var actualResult = meterReadingService.IsAccountValid(meterReading, accounts);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }


        [Fact]
        public void IsAccountValid_GivenReadingAccountNotInAccountList_ReturnFalse()
        {
            //Arrange
            var expectedResult = false;
            var meterReadingService = new MeterReadingService();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(4, DateTime.Now, 10004);
            var accounts = MeterReadingServiceTestHelper.SetupAccountList();

            //Act
            var actualResult = meterReadingService.IsAccountValid(meterReading, accounts);

            //Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void IsValidMeterReadingValue_GivenMeterReadValueIs5Digits_ReturnTrue()
        {
            //Arrange
            var expectedResult = true;
            var meterReadingService = new MeterReadingService();
            var meterReadValue = 12345;

            //Act
            var actualResult = meterReadingService.IsValidMeterReadingValue(meterReadValue);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void IsValidMeterReadingValue_GivenMeterReadValueIsNot5Digits_ReturnFalse()
        {
            //Arrange
            var expectedResult = false;
            var meterReadingService = new MeterReadingService();
            var meterReadValue = 1234;

            //Act
            var actualResult = meterReadingService.IsValidMeterReadingValue(meterReadValue);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void IsValidMeterReading_GivenValidAccountAndNonDuplicateMeterReadingAndValidMeterReading_ReturnTrue()
        {
            //Arrange
            var expectedResult = true;
            var meterReadingService = new MeterReadingService();

            var accounts = MeterReadingServiceTestHelper.SetupAccountList();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(3, DateTime.Now, 10003);
            var existingMeterReadings = MeterReadingServiceTestHelper.SetupMeterReadingList();

            //Act
            var actualResult = meterReadingService.IsValidMeterReading(accounts, existingMeterReadings, meterReading);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void IsValidMeterReading_GivenValidAccountAndDuplicateMeterReadingAndValidMeterReading_ReturnFalse()
        {
            //Arrange
            var expectedResult = false;
            var meterReadingService = new MeterReadingService();

            var accounts = MeterReadingServiceTestHelper.SetupAccountList();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(1, DateTime.Now, 10001);
            var existingMeterReadings = MeterReadingServiceTestHelper.SetupMeterReadingList();

            //Act
            var actualResult = meterReadingService.IsValidMeterReading(accounts, existingMeterReadings, meterReading);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void IsValidMeterReading_GivenValidAccountAndNonDuplicateMeterReadingAndInvalidMeterReading_ReturnFalse()
        {
            //Arrange
            var expectedResult = false;
            var meterReadingService = new MeterReadingService();

            var accounts = MeterReadingServiceTestHelper.SetupAccountList();

            var meterReading = MeterReadingServiceTestHelper.CreateMeterReading(2, DateTime.Now, 1000);
            var existingMeterReadings = MeterReadingServiceTestHelper.SetupMeterReadingList();

            //Act
            var actualResult = meterReadingService.IsValidMeterReading(accounts, existingMeterReadings, meterReading);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}