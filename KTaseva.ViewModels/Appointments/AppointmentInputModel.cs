using KTaseva.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        [Required]
        public int ProcedureId { get; set; }

        [Required]
        public string OldPolish { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today.AddDays(-1);

        [Range(typeof(TimeSpan), "09:00", "18:00",
            ErrorMessage = ErrorMessages.AppointmentTimeRange)]
        public TimeSpan Hour { get; set; }

        public List<SelectListItem> Procedures { get; set; }

        public string DisabledDates { get; set; }

        [Required]
        public string Token { get; set; }

        public bool isTest { get; set; }

        public string GetData { get; set; } = DateTime.Today.AddDays(-1).ToShortDateString();

    }
}
