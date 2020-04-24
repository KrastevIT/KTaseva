using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Admin;
using KTaseva.Tests.Configurations;
using System;
using System.Linq;
using Xunit;

namespace KTaseva.Tests.Services.Admin
{
    public class GetAppointmentTests
    {
        private readonly KTasevaDbContext db;
        private readonly AdminService adminService;

        public GetAppointmentTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.adminService = new AdminService(db);
        }

        [Fact]
        public void GetAppointmentReturnCorrectly()
        {
            var appointment = new Appointment
            {
                Id = 1,
                Date = DateTime.Today,
                Hour = TimeSpan.FromHours(9),
                Procedure = new Procedure { Id = 1 },
                User = new User { Id = "1"}
            };
            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();

            var actual = this.adminService.GetAppointment().Count();

            Assert.Equal(1, actual);
        }
    }
}
