using KTaseva.Data;
using KTaseva.Services.Mapping;
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

        public IEnumerable<T> All<T>()
        {
            var procedures = this.db.Procedures.To<T>().ToList();

            return null;
        }
    }
}
