using KTaseva.Data;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.Procedures;
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

        public IEnumerable<ProcedureViewModel> All()
        {
            var models = this.db.Procedures.To<ProcedureViewModel>().ToList();
            return models;
        }
    }
}
