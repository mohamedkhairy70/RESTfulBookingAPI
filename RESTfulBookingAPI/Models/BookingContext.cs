using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RESTfulBookingAPI.Models.Domain;
using System.Reflection;

namespace RESTfulBookingAPI.Models
{
    public class BookingContext : DbContext
    {

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User>  Users { get; set; }

        public BookingContext(DbContextOptions<BookingContext> options) : base(options) 
        {
            //this.Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
        }
    }
}
