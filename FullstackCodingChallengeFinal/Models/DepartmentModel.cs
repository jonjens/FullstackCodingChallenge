using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class DepartmentModel
    {

        [Key]
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public IList<EmployeeDepartmentModel> Employee { get; set; }

    }
}
