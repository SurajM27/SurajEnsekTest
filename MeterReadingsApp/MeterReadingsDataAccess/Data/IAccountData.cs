using MeterReadingsDataAccess.Models;

namespace MeterReadingsDataAccess.Data
{
    public interface IAccountData
    {
        Task<IEnumerable<AccountModel>> GetAccounts();
    }
}