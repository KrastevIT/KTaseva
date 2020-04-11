using KTaseva.Data;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace KTaseva.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly KTasevaDbContext db;

        public AdminService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminAppointmentViewModel> GetAppointment(string userId)
        {
            var models = this.db.Users.Where(x => x.Id == userId)
                .To<AdminAppointmentViewModel>().ToList();

            //models = this.db.Procedures.ToList();

            return models;
        }
    }
}
