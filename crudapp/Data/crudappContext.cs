using Microsoft.EntityFrameworkCore;

namespace crudapp.Data
{
    public class crudappContext : DbContext
    {
        public crudappContext(DbContextOptions<crudappContext> options)
            : base(options)
        {
        }

        public DbSet<crudapp.Models.Employee> Employees { get; set; } = default!;
        public DbSet<crudapp.Models.Department> Departments { get; set; } = default!;
    }
}
