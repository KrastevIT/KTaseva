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

        [Theory]
        [InlineData("27.04.2020", 1, 9)]
        [InlineData("27.04.2020", 2, 9)]
        [InlineData("27.04.2020", 3, 10)]
        public void GetFreeAppointmentByDateReturnCorrectly(string date, int procedureId, int hour)
        {
            var procedures = new List<Procedure>
            {
               new Procedure
               {
                   Id = 1,
                   Duration = TimeSpan.FromMinutes(20)
               },
               new Procedure
               {
                   Id = 2,
                   Duration = TimeSpan.FromMinutes(40)
               },
                new Procedure
               {
                   Id = 3,
                   Duration = TimeSpan.FromMinutes(20)
               }
            };

            var appointment = new Appointment
            {
                Id = 1,
                Date = DateTime.Parse(date),
                Hour = TimeSpan.FromHours(hour),
                ProcedureId = procedureId
            };

            this.db.Procedures.AddRange(procedures);
            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();

            var freeDates = this.appointmentService.GetFreeAppointmentByDate(date, procedureId);

            if (procedureId == 1)
            {
                Assert.DoesNotContain("09:00:00", freeDates);
                Assert.Contains("09:30:00", freeDates);

            }
            else if (procedureId == 2)
            {
                Assert.DoesNotContain("09:00:00", freeDates);
                Assert.DoesNotContain("09:30:00", freeDates);
            }
            else if (procedureId == 3)
            {
                Assert.DoesNotContain("10:00:00", freeDates);
                Assert.Contains("09:30:00", freeDates);
                Assert.Contains("10:30:00", freeDates);
            }
        }

        [Theory]
        [InlineData("27.04.2020", 1, 10, 11)]
        [InlineData("27.04.2020", 2, 10, 11)]
        [InlineData("27.04.2020", 3, 10, 11)]
        public void GetFreeAppointmentByDateWithTwoBusyTimeReturnCorrectly(string date, int procedureId, int oneHour, int twoHour)
        {
            var procedures = new List<Procedure>
            {
               new Procedure
               {
                   Id = 1,
                   Duration = TimeSpan.FromMinutes(60)
               },
               new Procedure
               {
                   Id = 2,
                   Duration = TimeSpan.FromMinutes(90)
               },
                new Procedure
               {
                   Id = 3,
                   Duration = TimeSpan.FromMinutes(120)
               }
            };

            var appointment = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Date = DateTime.Parse(date),
                    Hour = TimeSpan.FromHours(oneHour),
                    ProcedureId = procedureId
                },
                new Appointment
                {
                    Id = 2,
                    Date = DateTime.Parse(date),
                    Hour = TimeSpan.FromHours(twoHour),
                    ProcedureId = procedureId
                }
            };

            this.db.Procedures.AddRange(procedures);
            this.db.Appointments.AddRange(appointment);
            this.db.SaveChanges();

            var freeDates = this.appointmentService.GetFreeAppointmentByDate(date, procedureId);

            if (procedureId == 1)
            {
                Assert.DoesNotContain("10:00:00", freeDates);
                Assert.DoesNotContain("11:00:00", freeDates);
                Assert.DoesNotContain("09:30:00", freeDates);
                Assert.DoesNotContain("10:30:00", freeDates);
                Assert.Contains("09:00:00", freeDates);
                Assert.Contains("12:00:00", freeDates);
            }
            else if (procedureId == 2)
            {
                Assert.DoesNotContain("10:00:00", freeDates);
                Assert.DoesNotContain("11:00:00", freeDates);
                Assert.DoesNotContain("09:00:00", freeDates);
                Assert.DoesNotContain("09:30:00", freeDates);
                Assert.DoesNotContain("10:30:00", freeDates);
                Assert.DoesNotContain("11:30:00", freeDates);
                Assert.DoesNotContain("12:00:00", freeDates);
            }
            else if (procedureId == 3)
            {
                Assert.DoesNotContain("10:00:00", freeDates);
                Assert.DoesNotContain("11:00:00", freeDates);
                Assert.DoesNotContain("09:00:00", freeDates);
                Assert.DoesNotContain("09:30:00", freeDates);
                Assert.DoesNotContain("10:30:00", freeDates);
                Assert.DoesNotContain("11:30:00", freeDates);
                Assert.DoesNotContain("12:00:00", freeDates);
                Assert.DoesNotContain("12:30:00", freeDates);
            }
        }
    }
}
