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

        public CompanyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB; " +
                @"Database = CompanyContext-df8b8282-2937-4644-94fd-63d7e32490a1; " +
                @"Trusted_Connection = True; ");

            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<EmployeeModel> EmployeeModel { get; set; }
        public DbSet<CompanyModel> CompanyModel { get; set; }
        public DbSet<DepartmentModel> DepartmentModel { get; set; }
        public DbSet<EmployeeDepartmentModel> EmployeeDepartmentModel { get; set; }
        public DbSet<PersonModel> PersonModel { get; set; }
        public DbSet<ClientsModel> ClientsModel { get; set; }

    }
}
