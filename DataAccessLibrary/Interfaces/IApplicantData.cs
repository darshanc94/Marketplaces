using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IApplicantData
    {
        Task<int> InsertApplicant(ApplicantObj applicantObj);
        Task<ApplicantObj> LoadApplicant(ApplicantObj applicantObj);
        Task<List<ApplicantObj>> LoadApplicantList();
    }
}