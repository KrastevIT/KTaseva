using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public string Procedure { get; set; }

        public string OldPolish { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today.AddDays(-1);

        public TimeSpan Hour { get; set; } = TimeSpan.FromHours(9);

        public string BusyAppointment { get; set; }

        public string FreeAppointment { get; set; }

        public List<SelectListItem> Procedures { get; set; }

    }
}
