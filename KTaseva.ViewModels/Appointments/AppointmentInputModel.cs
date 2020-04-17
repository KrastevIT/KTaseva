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
            ErrorMessage = "Часът трябва да е между 09:00 и 18:00")]
        public TimeSpan Hour { get; set; }

        public List<SelectListItem> Procedures { get; set; }

        public string DisabledDates { get; set; }

    }
}
