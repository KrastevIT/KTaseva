using System;

namespace KTaseva.ViewModels.Admin
{
    public class AdminDisableDateInputModel
    {
        public int Id { get; set; }

        public DateTime DisabledDates { get; set; }

        public string GetData { get; set; } = DateTime.Today.AddDays(-1).ToShortDateString();
    }
}
