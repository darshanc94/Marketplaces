using DataAccessLibrary.Models;

namespace Marketplaces
{
    public interface ICreditCardLogic
    {
        Task<List<EligibleCreditCardsResponse>> ReturnElegibleCreditCards(ApplicantObj applicantObj);
    }
}