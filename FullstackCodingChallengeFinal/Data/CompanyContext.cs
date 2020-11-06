using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullstackCodingChallengeFinal.Models;

namespace FullstackCodingChallengeFinal.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext (DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<FullstackCodingChallengeFinal.Models.PersonModel> PersonModel { get; set; }

        public DbSet<FullstackCodingChallengeFinal.Models.EmployeeModel> EmployeeModel { get; set; }
    }
}
