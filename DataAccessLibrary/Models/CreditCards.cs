using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardApr { get; set; }
        public string CreditCardDescription { get; set; }
        public string CreditCardMinimumAge { get; set; }
        public string CreditCardMinimumIncome { get; set; }


    }
    public class EligibleCreditCardsResponse
    {
        public int CreditCardID { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardApr { get; set; }
        public string CreditCardDescription { get; set; }
        public string CreditCardMinimumAge { get; set; }
        public string CreditCardMinimumIncome { get; set; }
        public string ResponseMessage { get; set; }

    }

    public class CreditCardResult
    {
       public List<EligibleCreditCardsResponse> Result { get; set; }

    }
}
