using System;
using System.Collections.Generic;

namespace KTaseva.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
