using KTaseva.ViewModels.Appointments;
using System;
using Xunit;

namespace KTaseva.Tests.Services.Appointments
{
    public class AddTests
    {
        [Fact]
        public void AddReturnCorrectly()
        {
            var model = new AppointmentInputModel
            {
                ProcedureId = "10",
                OldPolish = "Да",
                Date = DateTime.Today,
                Hour = TimeSpan.FromHours(9)
            };
        }
    }
}
