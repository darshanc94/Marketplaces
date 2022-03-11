using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ILogData
    {
        Task<int> InsertLog(Log log);
    }
}