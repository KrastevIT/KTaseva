using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
                .ToList();

            var models = new List<AdminAppointmentViewModel>();

            foreach (var appointment in appointments)
            {
                var user = this.db.Users.FirstOrDefault(x => x.Id == appointment.UserId);
                models.Add(new AdminAppointmentViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Procedure = appointment.Procedure,
                    Date = appointment.Date.ToShortDateString(),
                    Hour = appointment.Hour
                });
            }

            return models;
        }
    }
}
