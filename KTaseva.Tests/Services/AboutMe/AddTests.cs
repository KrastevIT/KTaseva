using KTaseva.Data;
using KTaseva.Services.AboutMe;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels.AboutMe;
using System.Linq;
using Xunit;

namespace KTaseva.Tests.Services.AboutMe
{
    public class AddTests
    {
        private readonly KTasevaDbContext db;
        private readonly AboutMeService aboutMeService;

        public AddTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.aboutMeService = new AboutMeService(db);
        }

        [Fact]
        public void AddReturnCorrectly()
        {
            var model = new AboutMeInputModel
            {
                Id = 1
            };

            this.aboutMeService.Add(model);

            Assert.Equal(1, this.db.AboutMe.Count());
        }
    }
}
