using KTaseva.Common;
using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.ReCaptcha;
using KTaseva.ViewModels.Appointments;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KTaseva.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly KTasevaDbContext db;
        private readonly IReCAPTCHAService reCAPTCHAService;

        public AppointmentService(KTasevaDbContext db, IReCAPTCHAService reCAPTCHAService)
        {
            this.db = db;
            this.reCAPTCHAService = reCAPTCHAService;
        }

        public bool Add(AppointmentInputModel model, string userId)
        {
            var ReCaptcha = this.reCAPTCHAService.Verify(model.Token);
            if (!model.isTest && !ReCaptcha.Result.Success && ReCaptcha.Result.Score <= 0.5)
            {
                return false;
            }

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
            if (date == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidDate, date));
            }

            if (!this.db.Procedures.Any(x => x.Id == procedureId))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidProcedureId, procedureId));
            }
            var all = new List<TimeSpan>();
            var time = TimeSpan.FromHours(9);

            while (!all.Contains(TimeSpan.FromHours(18)))
            {
                all.Add(time);
                time += TimeSpan.FromMinutes(30);
            }

            var free = new List<string>();

            var dateFormat = date.Replace(".", "/");
            var currentDate = DateTime.ParseExact(
                dateFormat, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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

                var between = all.FindAll(x => x > app.Hour && x < app.Hour + app.Procedure.Duration);
                between.ForEach(x => all.Remove(x));
            }

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
