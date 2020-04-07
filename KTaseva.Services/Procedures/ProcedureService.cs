using KTaseva.Data;
using KTaseva.ViewModels.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.db.Procedures.ToList();

            return null;
        }
    }
}
