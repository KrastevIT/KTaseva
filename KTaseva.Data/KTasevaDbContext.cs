using KTaseva.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KTaseva.Data
{
    public class KTasevaDbContext : IdentityDbContext<User>
    {
        public KTasevaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<DisableDate> DisableDates { get; set; }

        public DbSet<AboutMe> AboutMe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
