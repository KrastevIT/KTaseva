using AutoMapper;
using KTaseva.Models;
using KTaseva.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTaseva.ViewModels.Admin
{
    public class AdminAppointmentViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Procedure { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Hour { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Procedure, AdminAppointmentViewModel>()
                .ForMember(x => x.Procedure, j =>
               {
                   j.MapFrom(p => p.Name);
               });
        }
    }
}
