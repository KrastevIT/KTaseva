using KTaseva.Services.Appointments;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace KTaseva.App.Hubs
{
    public class AppointmentHub : Hub
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentHub(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public async Task GetUpdateAppointment(string date, string procedureId)
        {
            var freeHours = this.appointmentService.GetFreeAppointmentByDate(date, int.Parse(procedureId));
            await this.Clients.Caller.SendAsync("Get", freeHours);
        }

    }
}
