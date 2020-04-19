using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Procedures;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace KTaseva.Tests.Services.Procedures
{
    public class AddTests
    {
        private readonly KTasevaDbContext db;
        private readonly ProcedureService procedureService;

        public AddTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.procedureService = new ProcedureService(db);
        }

        [Fact]
        public void AddReturnCorrectly()
        {
            var model = new AdminProcedureInputModel
            {
                Name = "Test"
            };

            this.procedureService.Add(model);

            Assert.Equal(1, this.db.Procedures.Count());
        }
    }
}
