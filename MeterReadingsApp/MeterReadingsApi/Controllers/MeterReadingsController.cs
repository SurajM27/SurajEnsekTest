using MeterReadingsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeterReadingsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingsController : ControllerBase
    {
        private readonly ICSVService _csvService;
        private readonly IMeterReadingService _meterReadingService;
        private readonly IAccountData _accountData;
        private readonly IMeterReadingData _meterReadingData;
        public MeterReadingsController(ICSVService csvService, IAccountData accountData, IMeterReadingData meterReadingData, IMeterReadingService meterReadingService)
        {
            _csvService = csvService;
            _accountData = accountData;
            _meterReadingData = meterReadingData;
            _meterReadingService = meterReadingService;
        }

        [Route("meter-reading-uploads")]
        [HttpPost]
        public IActionResult MeterReadingUpload([FromForm] IFormFileCollection file)
        {
            if(file == null)
            {
               return BadRequest();
            }

            try
            {               
                var meterReadings = _csvService.ReadCSV<MeterReadingModel>(file[0].OpenReadStream()).ToList();
                var accounts = _accountData.GetAccounts()?.Result.ToList();
                var existingMeterReadings = _meterReadingData.GetMeterReadings()?.Result.ToList();

                if (accounts == null || accounts.Count == 0 || existingMeterReadings == null || meterReadings.Count == 0) {
                    return NotFound();
                }

                var processResult = _meterReadingService.ProcessMeterReadings(accounts, meterReadings, existingMeterReadings);
                return Ok(processResult);

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);       
            }
        }        
    } 
}
