using DataAccessLibrary;
using DataAccessLibrary.Models;
using static Marketplaces.Helpers.Helpers;
namespace Marketplaces
{
    public class CreditCardLogic : ICreditCardLogic
    {

        private readonly ICreditCardData _creditCardData;
        

        public CreditCardLogic(ICreditCardData creditCardData)
        {
            _creditCardData = creditCardData;
        }
        public async Task<List<EligibleCreditCardsResponse>> ReturnElegibleCreditCards(ApplicantObj applicantObj)
        {
            List<EligibleCreditCardsResponse> eligibleCreditCardsResponse = new List<EligibleCreditCardsResponse>();

            var creditCards = await _creditCardData.LoadEligibleCreditCards(applicantObj);

            if (CalculateAge(applicantObj.DateOfBirth) >= 18) //underage
            {
                foreach (var creditCard in creditCards)
                {
                    eligibleCreditCardsResponse.Add(new EligibleCreditCardsResponse
                    {
                           CreditCardID = creditCard.CreditCardID,
                           CreditCardName = creditCard.CreditCardName,
                           CreditCardDescription = creditCard.CreditCardDescription,
                           ResponseMessage = "You are eligible for this card!"
                    });
                }

               

            }
            else
            {
                eligibleCreditCardsResponse.Add(new EligibleCreditCardsResponse
                {
                    ResponseMessage = "Sorry, you are not Eligible for any cards at this moment."
                });

            }


           
            return eligibleCreditCardsResponse;
        }
    }
}
