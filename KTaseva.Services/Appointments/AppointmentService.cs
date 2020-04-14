using KTaseva.Data;
using KTaseva.Models;
using KTaseva.ViewModels.Appointments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTaseva.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly KTasevaDbContext db;

        public AppointmentService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public bool Add(AppointmentInputModel model, string userId)
        {
            var appointment = new Appointment
            {
                NailPolish = model.OldPolish,
                Date = model.Date,
                Hour = model.Hour,
                UserId = userId,
                ProcedureId = int.Parse(model.ProcedureId)
            };

            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();
            return true;
        }

        public List<string> GetFreeAppointmentByDate(string date, string procedureId)
        {
            var all = new List<TimeSpan>();
            var time = TimeSpan.FromHours(9);

            while (!all.Contains(TimeSpan.FromHours(18)))
            {
                all.Add(time);
                time += TimeSpan.FromMinutes(30);
            }

            var free = new List<string>();
            var currentDate = DateTime.Parse(date);

            var procedureDuration = this.db.Procedures
                .Where(x => x.Id == int.Parse(procedureId))
                .Select(x => x.Duration)
                .FirstOrDefault();

            var busyHours = this.db.Appointments
                .Where(x => x.Date == currentDate)
                .Select(x => x.Hour)
                .ToList();

            var thirty = TimeSpan.FromMinutes(30);
            var start = TimeSpan.FromHours(9);

            foreach (var hour in busyHours)
            {


                if (start != hour)
                {
                    free.Add(start.ToString());
                }
                else
                {
                    start += thirty;
                }
            }


            ;

            return free;
        }
    }
}
