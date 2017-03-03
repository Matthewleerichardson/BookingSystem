using FinalTeamProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTeamProject.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Staff>().ToTable("Staff");
        }
    }
}