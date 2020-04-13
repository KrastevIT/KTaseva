using KTaseva.ViewModels.Appointments;

namespace KTaseva.Services.Appointments
{
    public interface IAppointmentService
    {
        bool Add(AppointmentInputModel model, string userId);

        AppointmentInputModel GetBusyAppointment();

        AppointmentInputModel GetFreeAppointment();
    }
}
