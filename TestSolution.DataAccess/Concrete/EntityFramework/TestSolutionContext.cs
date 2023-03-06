using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Entities.Concrete;

namespace TestSolution.DataAccess.Concrete.EntityFramework
{
    public class TestSolutionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Database=TestSolution; Trusted_Connection=True");
        }

        public DbSet<Test> Tests { get; set; }
    }
}
