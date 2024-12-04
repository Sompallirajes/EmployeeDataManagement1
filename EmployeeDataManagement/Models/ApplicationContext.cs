using Microsoft.EntityFrameworkCore;

namespace EmployeeDataManagement.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set;}
    }
}
