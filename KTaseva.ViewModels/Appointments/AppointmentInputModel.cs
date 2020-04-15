using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public string ProcedureId { get; set; }

        public string OldPolish { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today.AddDays(-1);

        public TimeSpan Hour { get; set; }

        public List<SelectListItem> Procedures { get; set; }

    }
}
