using Microsoft.EntityFrameworkCore;
using TextSaverWebApp.Models;

namespace TextSaverWebApp.DataBase
{
    public class TextDbContext : DbContext
    {
        public TextDbContext(DbContextOptions<TextDbContext> options) : base(options)
        {

        }

        public DbSet<TextEntity> TextEntities { get; set; }
        public DbSet<PartedText> PartedTexts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartedText>().Property(p=>p.Text).HasColumnType("NVARCHAR(500)");
        }
    }
}
