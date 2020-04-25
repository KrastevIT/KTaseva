using System;

namespace KTaseva.ViewModels.Admin
{
    public class AdminDisableDateInputModel
    {
        public int Id { get; set; }

        public string DisabledDates { get; set; } = DateTime.Today.AddDays(-1).ToShortDateString();
    }
}
