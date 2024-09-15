using api_cinema_challenge.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_cinema_challenge.Data
{
    public class CinemaContext : DbContext
    {
        private string _connectionString;
        public CinemaContext() 
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.example.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>().HasKey(x => x.Id);
            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Screenings)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.movieId);

            modelBuilder.Entity<Screening>().HasKey(t => t.Id);
            modelBuilder.Entity<Screening>()
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Screening)
                .HasForeignKey(x => x.screeningId);

            modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.customerId);

            modelBuilder.Entity<Customer>().HasKey(t => t.Id);
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Tickets)
                .WithOne(x=> x.Customer)
                .HasForeignKey(x => x.customerId);


        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet <Ticket> Tickets { get; set; }

    }
}
