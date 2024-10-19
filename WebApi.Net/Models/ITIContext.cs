using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Net.Models
{
    public class ITIContext :IdentityDbContext<ApplicationUser>
    {
        public DbSet<Department> Department { get; set; }   

        public DbSet<Employee> Employees { get; set; }

        public ITIContext(DbContextOptions<ITIContext> options) :base(options) {

        }

    }
}
