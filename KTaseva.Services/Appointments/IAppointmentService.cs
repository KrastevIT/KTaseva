using KTaseva.ViewModels.Appointments;
using System.Collections.Generic;

namespace KTaseva.Services.Appointments
{
    public interface IAppointmentService
    {
        bool Add(AppointmentInputModel model, string userId);

        List<string> GetFreeAppointmentByDate(string date, string procedureId);
    }
}
