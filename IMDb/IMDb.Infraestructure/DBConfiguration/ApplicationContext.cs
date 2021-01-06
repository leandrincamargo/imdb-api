using IMDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IMDb.Infraestructure.DBConfiguration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Cast> Cast { get; set; }
        public DbSet<CastOfMovie> CastOfMovie { get; set; }
        public DbSet<CastType> CastType { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieClassification> MovieClassification { get; set; }
        public DbSet<MovieScale> MovieScale { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
    }
}
