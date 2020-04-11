using System;

namespace KTaseva.ViewModels.Admin
{
    public class AdminAppointmentViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Procedure { get; set; }

        public string Date { get; set; }

        public TimeSpan Hour { get; set; }
    }
}
