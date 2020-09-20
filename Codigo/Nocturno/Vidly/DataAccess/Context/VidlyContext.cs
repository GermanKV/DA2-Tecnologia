using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    public class VidlyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public VidlyContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
        public VidlyContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ENVY15\\DANIELACEVEDO; Database=VidlyDB; Integrated Security=True; Trusted_Connection=True; MultipleActiveResultSets=True");
            }
        }
    }
}
