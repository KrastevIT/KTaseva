using KTaseva.ViewModels.Admin;
using System.Collections.Generic;

namespace KTaseva.Services.Admin
{
    public interface IAdminService
    {
        IEnumerable<AdminAppointmentViewModel> GetAppointment();

        void AddDisableDate(AdminDisableDateInputModel model);
    }
}
