using KTaseva.ViewModels.Admin;
using KTaseva.ViewModels.Procedures;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KTaseva.Services.Procedures
{
    public interface IProcedureService
    {
        void Add(AdminProcedureInputModel model);

        IEnumerable<ProcedureViewModel> All();

        List<SelectListItem> GetProceduresDropDownList();
    }
}
