using Microsoft.EntityFrameworkCore;
using TranslatedValueApi.Domain.Entites;

namespace TranslatedValueApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<Translations> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translations>(entity =>
            {
                entity.ToTable("translations");
                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.CreatedDate).HasColumnName("created_date");
                entity.Property(x => x.WordId).HasColumnName("word_id");
                entity.Property(x => x.TranslatedValue).HasMaxLength(100).HasColumnName("translated_value");
            });
        }
    }
}
