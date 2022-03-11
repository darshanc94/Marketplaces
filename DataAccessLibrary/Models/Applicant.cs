using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ApplicantObj
    {
        public int ApplicantID { get; set; }
        [MinLength(3)]
        public string? FirstName { get; set; }
        [MinLength(3)]
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AnnualIncome { get; set; }
      
    }
}
