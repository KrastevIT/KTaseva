using System;

namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public string Procedure { get; set; }

        public string NailPolish { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Hour { get; set; }

        public string BusyAppointment { get; set; }
    }
}
