using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.Admin;
using KTaseva.ViewModels.Procedures;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace KTaseva.Services.Procedures
{
    public class ProcedureService : IProcedureService
    {
        private readonly KTasevaDbContext db;

        public ProcedureService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public void Add(AdminProcedureInputModel model)
        {
            var procedure = new Procedure
            {
                Name = model.Name,
                Duration = model.Duration,
                Price = model.Price
            };

            this.db.Procedures.Add(procedure);
            this.db.SaveChanges();
        }

        public IEnumerable<ProcedureViewModel> All()
        {
            var models = this.db.Procedures.To<ProcedureViewModel>().ToList();
            return models;
        }

        public List<SelectListItem> GetProceduresDropDownList()
        {
            var procedureItems = new List<SelectListItem>();
            var procedures = this.db.Procedures.ToList();

            foreach (var procedure in procedures)
            {
                var item = new SelectListItem
                {
                    Text = procedure.Name + $" {procedure.Price}лв.",
                    Value = procedure.Id.ToString()
                };
                procedureItems.Add(item);
            }

            return procedureItems;
        }
    }
}
