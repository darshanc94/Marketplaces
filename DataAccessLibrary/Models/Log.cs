using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public string LogType { get; set; }
        public string LogRequest { get; set; }
        public int ApplicantID { get; set; }
        public DateTime LogSubmitted { get; set; }
        public int LogRequestStatus { get; set; }

        public int CreditCardID { get; set; }
        public string LogResponseMessage { get; set; }


    }
}
