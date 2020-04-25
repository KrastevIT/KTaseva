using KTaseva.Common;
using KTaseva.Data;
using KTaseva.Models;
using KTaseva.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KTaseva.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly KTasevaDbContext db;

        public AdminService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminAppointmentViewModel> GetAppointment()
        {
            var appointments = this.db.Appointments
                .Where(x => x.Date >= DateTime.Today)
                .Include(x => x.Procedure)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Hour)
                .ToList();

            appointments.Select(x => x.Date.ToShortDateString());

            var models = new List<AdminAppointmentViewModel>();

            foreach (var appointment in appointments)
            {
                var user = this.db.Users.FirstOrDefault(x => x.Id == appointment.UserId);
                models.Add(new AdminAppointmentViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Procedure = appointment.Procedure.Name,
                    OldPolish = appointment.NailPolish,
                    Date = appointment.Date.ToShortDateString(),
                    Hour = appointment.Hour,
                    EndHour = appointment.Hour + appointment.Procedure.Duration
                });
            }

            return models;
        }

        public void AddDisableDate(AdminDisableDateInputModel model)
        {
            DateTime currentDate;
            try
            {
                currentDate = DateTime.Parse(model.DisabledDates);
            }
            catch (Exception e)
            {
                throw new InvalidCastException(
                   string.Format(ExceptionMessages.InvalidCastDisableDate, model.DisabledDates, e));
            }

            var disabledDate = new DisableDate
            {
                DisabledDates = currentDate
            };

            this.db.DisableDates.Add(disabledDate);
            this.db.SaveChanges();
        }
    }
}
