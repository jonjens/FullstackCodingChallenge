using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ClientsModel Clients { get; set; }
        public CompetitorsModel Competitors { get; set; }
    }
}
