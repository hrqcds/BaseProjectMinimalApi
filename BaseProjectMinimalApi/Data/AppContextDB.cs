using BaseProjectMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectMinimalApi.Data
{
    public class AppContextDB : DbContext
    {
        public AppContextDB(DbContextOptions<AppContextDB> options): base(options) { }
        
        public DbSet<ExampleModel> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<ExampleModel>()
                .HasKey(e => e.Id);

            m.Entity<ExampleModel>()
                .Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            m.Entity<ExampleModel>()
                .Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(100)");

            m.Entity<ExampleModel>().ToTable("Examples");
        }

    }
}
