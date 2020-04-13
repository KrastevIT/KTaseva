﻿using KTaseva.Data;
using KTaseva.Models;
using KTaseva.ViewModels.Appointments;
using Newtonsoft.Json;
using System;
using System.Linq;

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
            var isExist = this.db.Appointments
                .Select(x => x.Date)
                .Contains(model.Date);

            if (isExist)
            {
                return false;
            }

            var appointment = new Appointment
            {
                Procedure = model.Procedure,
                NailPolish = model.OldPolish,
                Date = model.Date,
                UserId = userId,
            };

            this.db.Appointments.Add(appointment);
            this.db.SaveChanges();
            return true;
        }

        public AppointmentInputModel GetBusyAppointment()
        {
            var busyAppointment = this.db.Appointments
                .Select(x => x.Date)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Hour)
                .ToList();

            var busy = busyAppointment
                .Select(x => x.ToString("yyyy/MM/dd HH:mm")
                .Replace('.', '/'))
                .ToArray();

            var busyJson = JsonConvert.SerializeObject(busy);

            var model = new AppointmentInputModel
            {
                BusyAppointment = busyJson,
            };

            return model;
        }

        public AppointmentInputModel GetFreeAppointment()
        {
            var busyAppointment = this.db.Appointments
               .Select(x => x.Date.ToString("d/MM/yyyy HH:mm"))
               .ToList();

            var jsonAppointment = JsonConvert.SerializeObject(busyAppointment);

            var model = new AppointmentInputModel
            {
               FreeAppointment = jsonAppointment
            };

            return model;
        }
    }
}
