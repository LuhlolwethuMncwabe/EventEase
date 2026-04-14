using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Models
{
    // This class represents the session with the database
    // It is responsible for querying and saving data
    public class ApplicationDbContext : DbContext
    {
        // Constructor receives configuration for example, a connection string.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet represents a table in the database
        public DbSet<Venue> Venues { get; set; }// this is the Venues table 
        public DbSet<Event> Events { get; set; } //this is the events table
        public DbSet<Customer> Customers { get; set; } //this is the customers table
        public DbSet<Booking> Bookings { get; set; } //this is the bookings table
    }
}
