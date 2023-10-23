using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-K9RNB1L;database=AspNetCoreBlogApi; integrated security=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
