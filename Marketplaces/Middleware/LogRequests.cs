using Microsoft.AspNetCore.Mvc.Filters;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Marketplaces.Middleware
{
    public class LogRequests : IActionFilter
    {
        private readonly ILogData _logData;
     

        public LogRequests(ILogData logData)
        {
            _logData = logData;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {


           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Method == "PUT")
            {
                if (context.Result != null)
                {
                    if (context.Result.GetType().Equals(typeof(OkObjectResult)))
                    {
                        var res = ((OkObjectResult)context.Result);

                        List<EligibleCreditCardsResponse> creditCards = JsonSerializer.Deserialize<List<EligibleCreditCardsResponse>>(res.Value.ToString());

                        var logDetails = new Log();

                        logDetails.LogRequest = context.HttpContext.Request.Path;
                        logDetails.LogType = "request";
                        logDetails.ApplicantID = Int32.Parse(context.HttpContext.Request.RouteValues["ApplicantID"].ToString());
                        logDetails.LogSubmitted = DateTime.Now;
                        logDetails.LogRequestStatus = context.HttpContext.Response.StatusCode;

                        if (creditCards != null)
                        {
                            foreach (var creditCard in creditCards)
                            {

                                logDetails.CreditCardID = creditCard.CreditCardID;
                                logDetails.LogResponseMessage = creditCard.ResponseMessage;


                                _logData.InsertLog(logDetails);

                            }
                        }

                    }
                }
            }
        }
    }
}
