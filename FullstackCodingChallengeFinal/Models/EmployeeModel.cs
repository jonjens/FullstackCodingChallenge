using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public int Salary { get; set; }
        public int PersonId { get; set; }
        public PersonModel Person { get; set; }
        public IList<EmployeeDepartmentModel> Department { get; set; }


    }
}
