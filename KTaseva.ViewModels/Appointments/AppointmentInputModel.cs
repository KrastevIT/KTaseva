using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public string Procedure { get; set; }

        public string OldPolish { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        public TimeSpan Hour { get; set; }

        public string BusyAppointment { get; set; }

        public string FreeAppointment { get; set; }

        public List<SelectListItem> Procedures { get; set; }

    }
}
