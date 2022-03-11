using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
namespace DataAccessLibrary
{
    public class CreditCardData : ICreditCardData
    {
        private readonly ISqlDataAccess _db;


        public CreditCardData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<CreditCard>> LoadEligibleCreditCards(ApplicantObj applicantObj)
        {

            string sql = @"SELECT top(1)
                            CreditCardID,
                            CreditCardName, 
                            CreditCardApr,
                            CreditCardDescription,
                            CreditCardMinimumAge,
                            CreditCardMinimumIncome
                            FROM dbo.CreditCards
                            WHERE CreditCardMinimumIncome <= @AnnualIncome
                            ORDER BY CreditCardMinimumIncome Desc";

            return _db.LoadData<CreditCard, dynamic>(sql, applicantObj);
        }
      
    }
}
