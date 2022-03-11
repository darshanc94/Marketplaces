using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
namespace DataAccessLibrary
{
    public class LogData : ILogData
    {
        private readonly ISqlDataAccess _db;


        public LogData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<int> InsertLog(Log log)
        {

            string sql = @"INSERT INTO dbo.Log (LogType, LogRequest, ApplicantID, LogSubmitted, LogRequestStatus, CreditCardID, LogResponseMessage)
                            VALUES (@LogType, @LogRequest, @ApplicantID, @LogSubmitted, @LogRequestStatus, @CreditCardID, @LogResponseMessage);";

            return _db.SaveDataID(sql, log);
        }

    }
}
