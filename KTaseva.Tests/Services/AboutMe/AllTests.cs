using KTaseva.Data;
using KTaseva.Services.AboutMe;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels.AboutMe;
using System.Linq;
using Xunit;

namespace KTaseva.Tests.Services.AboutMe
{
    public class AllTests
    {
        private readonly KTasevaDbContext db;
        private readonly AboutMeService aboutMeService;

        public AllTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.aboutMeService = new AboutMeService(db);
        }

        [Fact]
        public void AllReturnCorrectly()
        {
            var about = new KTaseva.Models.AboutMe
            {
                Id = 1
            };
            this.db.AboutMe.Add(about);
            this.db.SaveChanges();

            var actual = this.aboutMeService.All<AboutMeViewModel>().Count();

            Assert.Equal(1, actual);
        }
    }
}
