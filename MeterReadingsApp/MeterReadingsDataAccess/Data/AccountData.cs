using MeterReadingsDataAccess.DbAccess;
using MeterReadingsDataAccess.Models;

namespace MeterReadingsDataAccess.Data
{
    public class AccountData : IAccountData
    {
        private readonly ISqlDataAccess _db;

        public AccountData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<AccountModel>> GetAccounts() =>
            _db.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });
    }
}
