using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class EmployeeDepartmentModel
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

    }
}
