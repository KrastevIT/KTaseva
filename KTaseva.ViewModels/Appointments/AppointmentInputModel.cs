using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public string Procedure { get; set; }

        public string OldPolish { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Hour { get; set; }

        public string BusyAppointment { get; set; }

        public List<SelectListItem> Procedures { get; set; }

    }
}
