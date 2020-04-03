using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Models.Enums;
using KTaseva.ViewModels.Appointments;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTaseva.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly KTasevaDbContext db;

        public AppointmentService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public void Add(AppointmentInputModel model, string userId)
        {
            var appointment = new Appointment
            {
                Procedure = model.Procedure,
                NailPolish = model.NailPolish,
                Date = model.Date,
                UserId = userId,
                Hour = "09:00"
            };

            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();
        }
    }
}
