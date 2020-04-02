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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
