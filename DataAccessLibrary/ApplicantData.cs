using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
namespace DataAccessLibrary
{
    public class ApplicantData : IApplicantData
    {
        private readonly ISqlDataAccess _db;


        public ApplicantData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicantObj>> LoadApplicantList()
        {

            string sql = "SELECT * FROM dbo.Applicant";
            return _db.LoadData<ApplicantObj, dynamic>(sql, new { });
        }
        public Task<int> InsertApplicant(ApplicantObj applicantObj)
        {

            string sql = @"INSERT INTO dbo.Applicant (FirstName, LastName, DateOfBirth, AnnualIncome)
                            VALUES (@FirstName, @LastName, @DateOfBirth, @AnnualIncome);";
            return _db.SaveDataID(sql, applicantObj);
        }

        public Task<ApplicantObj> LoadApplicant(ApplicantObj applicantObj)
        {

            string sql = "SELECT * FROM dbo.Applicant WHERE ApplicantID = @ApplicantID";

            return _db.LoadDataSingular<ApplicantObj, dynamic>(sql, applicantObj);
        }

    }
}
