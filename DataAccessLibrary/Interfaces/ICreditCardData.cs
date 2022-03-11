using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICreditCardData
    {
        Task<List<CreditCard>> LoadEligibleCreditCards(ApplicantObj applicantObj);
    }
}