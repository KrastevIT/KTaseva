using KTaseva.Data;
using KTaseva.ViewModels.Admin;
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
                .ToList();

            var models = new List<AdminAppointmentViewModel>();

            foreach (var appointment in appointments)
            {
                var user = this.db.Users.FirstOrDefault(x => x.Id == appointment.UserId);
                models.Add(new AdminAppointmentViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    OldPolish = appointment.NailPolish,
                    Date = appointment.Date.ToShortDateString(),
                    Hour = appointment.Date.ToShortTimeString()
                });
            }

            return models;
        }
    }
}
