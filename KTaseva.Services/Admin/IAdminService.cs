using KTaseva.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTaseva.Services.Admin
{
    public interface IAdminService
    {
        void AddPhoto(AdminInputAddPhoto model);
    }
}
