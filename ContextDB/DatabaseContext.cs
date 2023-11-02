using ApiGestionCliente.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiGestionCliente.ContextDB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        //protected readonly IConfiguration Configuration;

        //public DatabaseContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            // connect to sqlite database
            optionsBuilder.UseSqlite(configuration.GetConnectionString("WebApiDatabase"),
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                        );
                });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Client>(entity => { 
                entity.HasKey(c => c.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
