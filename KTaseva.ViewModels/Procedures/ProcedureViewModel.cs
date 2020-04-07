using KTaseva.Models;
using KTaseva.Services.Mapping;
using System;

namespace KTaseva.ViewModels.Procedures
{
    public class ProcedureViewModel : IMapFrom<Procedure>
    {
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }
    }
}
