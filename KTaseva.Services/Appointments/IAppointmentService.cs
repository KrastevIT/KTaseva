using KTaseva.ViewModels.Appointments;

namespace KTaseva.Services.Appointments
{
    public interface IAppointmentService
    {
        void Add(AppointmentInputModel model, string userId);

        AppointmentInputModel GetBusyAppointment();
    }
}
