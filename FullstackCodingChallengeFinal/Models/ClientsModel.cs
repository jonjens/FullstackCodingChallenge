using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class ClientsModel
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public IList<CompanyModel> Company { get; set; }

    }
}
