using KTaseva.Data;
using KTaseva.Models;
using KTaseva.ViewModels.Appointments;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            var isExistHour = this.db.Appointments
                .Where(x => x.Date == model.Date)
                .Any(x => x.Hour == model.Hour);

            var procedureDuration = this.db.Procedures
                .Where(x => x.Id == model.ProcedureId)
                .Select(x => x.Duration)
                .FirstOrDefault();

            var previous = this.db.Appointments
                .OrderByDescending(x => x.Hour)
                .Where(x => x.Date == model.Date && x.Hour < model.Hour)
                .Select(x => x.Hour)
                .FirstOrDefault();

            var next = this.db.Appointments
                .OrderBy(x => x.Hour)
                .Where(x => x.Date == model.Date && x.Hour > model.Hour)
                .Select(x => x.Hour)
                .FirstOrDefault();

            if (isExistHour || model.Hour + procedureDuration > next && next > TimeSpan.Zero)
            {
                return false;
            }
            else if (previous + procedureDuration > model.Hour)
            {
                return false;
            }

            if (!this.db.Procedures.Any(x => x.Id == model.ProcedureId)
                || model.OldPolish != "Да"
                && model.OldPolish != "Не"
                || model.Hour < TimeSpan.FromHours(9)
                || model.Hour > TimeSpan.FromHours(18))
            {
                return false;
            }

            var appointment = new Appointment
            {
                NailPolish = model.OldPolish,
                Date = model.Date,
                Hour = model.Hour,
                UserId = userId,
                ProcedureId = model.ProcedureId
            };

            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();
            return true;
        }

        public List<string> GetFreeAppointmentByDate(string date, int procedureId)
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
                .Where(x => x.Id == procedureId)
                .Select(x => x.Duration)
                .FirstOrDefault();

            var appointment = this.db.Appointments
                .Where(x => x.Date == currentDate)
                .Include(x => x.Procedure)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Hour)
                .ToList();

            foreach (var app in appointment)
            {
                all.RemoveAll(x => x == app.Hour);
                if (app.Hour == TimeSpan.FromHours(18))
                {
                    break;
                }

                var nextHour = app.Hour + app.Procedure.Duration;
                var isBetweenDelete = all.FindAll(x => x > app.Hour && x < nextHour);
                if (isBetweenDelete.Any(x => x == TimeSpan.Zero))
                {
                    var next = all.Find(x => x > nextHour);
                    all[all.FindIndex(ind => ind.Equals(next))] = nextHour;
                    continue;
                }
                isBetweenDelete.ForEach(x => all.Remove(x));
            }

            all = all.Distinct().ToList();

            foreach (var hour in appointment.Select(x => x.Hour))
            {
                var previous = all.FindAll(x => x < hour && x > hour - procedureDuration);
                previous.ForEach(x => all.RemoveAll(y => y == x));
            }

            all.ForEach(x => free.Add(x.ToString()));

            return free;
        }

        public string GetDisabledDates()
        {
            var dates = this.db.DisableDates
                .Select(x => x.DisabledDates.ToString("dd.MM.yyyy"))
                .ToArray();

            var json = JsonConvert.SerializeObject(dates);

            return json;
        }
    }
}
