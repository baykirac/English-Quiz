using Microsoft.EntityFrameworkCore;

namespace GenericRepository.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<>
    }
}
