using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using Marketplaces.Middleware;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marketplaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogRequests))]
    public class ApplicantCardsController : ControllerBase
    {

        private readonly IApplicantData _applicantData;
        private readonly ICreditCardData _creditCardData;
        private readonly ICreditCardLogic _creditCardLogic;

        public ApplicantCardsController(IApplicantData applicantData, ICreditCardData creditCardData, ICreditCardLogic creditCardLogic)
        {
            _applicantData = applicantData;
            _creditCardData = creditCardData;
            _creditCardLogic = creditCardLogic;
        }

        [HttpGet]
        public async Task<List<ApplicantObj>> Get()
        {

            var test = await _applicantData.LoadApplicantList();

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicantObj applicantObj)
        {

            if (!TryValidateModel(applicantObj, nameof(ApplicantObj)))
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    int insertedAppliant = await _applicantData.InsertApplicant(applicantObj);
                    if(insertedAppliant == 0)
                    {
                        return Ok("User sucessfully created");

                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (SqlException e)
                {
                    return BadRequest("Issue with SQL data: " + e.Message);
                }
            }

        }
    
        // PUT api/<ApplicantCardsController>/5
        [HttpPut("{applicantID}")]
        public async Task<IActionResult> Put(int applicantID)
        {

                List<EligibleCreditCardsResponse> eligibleCreditCardsResponse = new List<EligibleCreditCardsResponse>();

                try
                {
                    ApplicantObj applicantDetails = await _applicantData.LoadApplicant(new ApplicantObj { ApplicantID = applicantID });

                if (applicantDetails != null)
                {
                    eligibleCreditCardsResponse = await _creditCardLogic.ReturnElegibleCreditCards(applicantDetails);
                    return Ok(JsonSerializer.Serialize(eligibleCreditCardsResponse));

                }
                else
                {
                    eligibleCreditCardsResponse.Add(new EligibleCreditCardsResponse
                    {
                        ResponseMessage = "User not found"
                    });

                    return Ok(JsonSerializer.Serialize(eligibleCreditCardsResponse));

                }

            }
                catch (SqlException e)
                {
                    return BadRequest("Issue with SQL data: " + e.Message);
                }
            
        }

       
    }
}
