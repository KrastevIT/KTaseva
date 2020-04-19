using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Appointments;
using KTaseva.Tests.Configurations;
using Newtonsoft.Json;
using System;
using Xunit;

namespace KTaseva.Tests.Services.Appointments
{
    public class GetDisabledDatesTests
    {
        private readonly KTasevaDbContext db;
        private readonly AppointmentService appointmentService;

        public GetDisabledDatesTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.appointmentService = new AppointmentService(db);
        }

        [Fact]
        public void GetDisabledDatesReturnCorrectly()
        {
            var disabledDate = new DisableDate
            {
                Id = 1,
                DisabledDates = DateTime.Today.AddDays(+1)
            };

            this.db.DisableDates.Add(disabledDate);
            this.db.SaveChanges();

            var dates = this.appointmentService.GetDisabledDates();

            var date = DateTime.Today.AddDays(+1).ToString("dd.MM.yyyy");
            var expected = JsonConvert.SerializeObject(date);

            Assert.Contains(expected, dates);
        }

        [Theory]
        [InlineData(-1, "dd.MM.yyyy")]
        [InlineData(+2, "dd.MM.yyyy")]
        [InlineData(-1, "yyyy.dd.MM")]
        public void GetDisabledDatesReturnInvalid(int addDays, string dateFormat)
        {
            var disabledDate = new DisableDate
            {
                Id = 1,
                DisabledDates = DateTime.Today.AddDays(+1)
            };

            this.db.DisableDates.Add(disabledDate);
            this.db.SaveChanges();

            var dates = this.appointmentService.GetDisabledDates();

            var date = DateTime.Today.AddDays(addDays).ToString(dateFormat);
            var expected = JsonConvert.SerializeObject(date);

            Assert.DoesNotContain(expected, dates);
        }
    }
}

