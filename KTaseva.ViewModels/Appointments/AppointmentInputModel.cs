using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KTaseva.ViewModels.Appointments
{
    public class AppointmentInputModel
    {
        public int Procedure { get; set; }

        public string NailPolish { get; set; }

        public DateTime Date { get; set; }

        public string BusyAppointment { get; set; }

    }
}
