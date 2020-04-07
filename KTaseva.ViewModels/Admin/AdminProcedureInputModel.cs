using KTaseva.Models;
using KTaseva.Services.Mapping;
using System;

namespace KTaseva.ViewModels.Admin
{
    public class AdminProcedureInputModel : IMapFrom<Procedure> ,IMapTo<Procedure>
    {
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }
    }
}

