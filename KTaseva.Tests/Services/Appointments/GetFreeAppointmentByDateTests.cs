using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Appointments;
using KTaseva.Tests.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KTaseva.Tests.Services.Appointments
{
    public class GetFreeAppointmentByDateTests
    {
        private readonly KTasevaDbContext db;
        private readonly AppointmentService appointmentService;

        public GetFreeAppointmentByDateTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.appointmentService = new AppointmentService(db);
        }

        [Theory]
        [InlineData("27.04.2020", 1)]
        [InlineData("27.04.2022", 2)]
        public void GetFreeAppointmentByDateReturnAllFreeCorrectly(string date, int procedureId)
        {
            var procedures = new List<Procedure>
            {
               new Procedure
               {
                   Id = 1,
                   Duration = TimeSpan.FromMinutes(40)
               },
               new Procedure
               {
                   Id = 2,
                   Duration = TimeSpan.FromHours(1)
               }
            };
            this.db.Procedures.AddRange(procedures);
            this.db.SaveChanges();

            var freeDates = this.appointmentService.GetFreeAppointmentByDate(date, procedureId);
            Assert.Equal(19, freeDates.Count);
        }

        
    }
}
