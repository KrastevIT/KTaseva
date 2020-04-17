using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Appointments;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels.Appointments;
using System;
using System.Collections.Generic;
using Xunit;

namespace KTaseva.Tests.Services.Appointments
{
    public class AddTests
    {
        private readonly KTasevaDbContext db;
        private readonly AppointmentService appointmentService;

        public AddTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.appointmentService = new AppointmentService(db);
        }

        [Theory]
        [InlineData("1", "Да", 9)]
        [InlineData("2", "Не", 18)]
        public void AddReturnCorrectly(string procedureId, string oldPolish, int time)
        {
            var procedures = new List<Procedure>
            {
                new Procedure
                {
                    Id = 1
                },
                new Procedure
                {
                    Id = 2
                }
            };
            this.db.Procedures.AddRange(procedures);
            this.db.SaveChanges();

            var model = new AppointmentInputModel
            {
                ProcedureId = procedureId,
                OldPolish = oldPolish,
                Date = DateTime.Today,
                Hour = TimeSpan.FromHours(time)
            };

            var userId = "1";

            var isValid = this.appointmentService.Add(model, userId);

            Assert.True(isValid);
        }
    }
}
