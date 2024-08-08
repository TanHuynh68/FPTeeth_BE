using FPTeeth_BE.Enity;
using Microsoft.EntityFrameworkCore;

namespace FPTeeth_BE.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Clinics> Clinics { get; set; }
        public DbSet<ClinicService> ClinicServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }



        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
