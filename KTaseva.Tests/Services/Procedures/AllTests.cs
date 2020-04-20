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
    public class AllTests
    {
        private readonly KTasevaDbContext db;
        private readonly ProcedureService procedureService;

        public AllTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.procedureService = new ProcedureService(db);
        }

        [Fact]
        public void AllReturnCorrectly()
        {
            var procedure = new Procedure
            {
                Id = 1,
                Name = "TestProcedure"
            };

            this.db.Procedures.Add(procedure);
            this.db.SaveChanges();

            var actual = this.procedureService.All().Count();

            Assert.Equal(1, actual);
        }
    }
}
