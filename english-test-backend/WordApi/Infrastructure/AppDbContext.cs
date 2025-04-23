using Microsoft.EntityFrameworkCore;
using WordApi.Domain.Entities;

namespace WordApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Words>(entity =>
            {
                entity.ToTable("words");
                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.CreatedDate).HasColumnName("created_date");
                entity.Property(x => x.Word).HasMaxLength(100).HasColumnName("word");
            });
        }
    }
}
