using KTaseva.Data;
using KTaseva.Models;
using KTaseva.Services.Mapping;
using KTaseva.Services.Procedures;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels;
using System.Linq;
using System.Reflection;
using Xunit;

namespace KTaseva.Tests.Services.Procedures
{
    public class GetProceduresDropDownListTests
    {
        private readonly KTasevaDbContext db;
        private readonly ProcedureService procedureService;

        public GetProceduresDropDownListTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.procedureService = new ProcedureService(db);
        }

        [Fact]
        public void GetProceduresDropDownListReturnCorrectly()
        {
            var procedure = new Procedure
            {
                Id = 1
            };
            this.db.Procedures.Add(procedure);
            this.db.SaveChanges();

            var procedures = this.procedureService.GetProceduresDropDownList();

            var actual = procedures.Select(x => x.Value);

            Assert.Contains("1", actual);
        }
    }
}
