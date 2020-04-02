using System;

namespace KTaseva.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
