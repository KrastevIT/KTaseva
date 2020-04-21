using KTaseva.Data;
using KTaseva.Services.AboutMe;
using KTaseva.Tests.Configurations;
using Xunit;

namespace KTaseva.Tests.Services.AboutMe
{
    public class GetByIdTests
    {
        private readonly KTasevaDbContext db;
        private readonly AboutMeService aboutMeService;

        public GetByIdTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.aboutMeService = new AboutMeService(db);
        }

        [Fact]
        public void GetByIdReturnCorrectly()
        {
            var about = new KTaseva.Models.AboutMe
            {
                Id = 1
            };
            this.db.AboutMe.Add(about);
            this.db.SaveChanges();

            var actual = this.aboutMeService.GetById("1");

            Assert.True(actual.Id == 1);
        }
    }
}
