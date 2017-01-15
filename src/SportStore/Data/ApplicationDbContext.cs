using Microsoft.EntityFrameworkCore;

namespace SportStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=SportStore;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
}
