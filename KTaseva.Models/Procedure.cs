using System;

namespace KTaseva.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }
    }
}
