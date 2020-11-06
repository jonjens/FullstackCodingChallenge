using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "Need to be 6 digits")]
        public int SSN { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; }


    }
}
