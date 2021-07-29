using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RESTfulBookingAPI.Models.Domain;
using System.Reflection;

namespace RESTfulBookingAPI.Models
{
    public class BookingContext : DbContext
    {

        public DbSet<Trip> CompanyInformations { get; set; }
        public DbSet<Reservation> Customers { get; set; }
        public DbSet<User> UsersCompany { get; set; }

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
