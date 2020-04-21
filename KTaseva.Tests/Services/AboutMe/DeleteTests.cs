using KTaseva.Data;
using KTaseva.Services.AboutMe;
using KTaseva.Tests.Configurations;
using System.Linq;
using Xunit;

namespace KTaseva.Tests.Services.AboutMe
{
    public class DeleteTests
    {
        private readonly KTasevaDbContext db;
        private AboutMeService aboutMeService;

        public DeleteTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.aboutMeService = new AboutMeService(db);
        }

        [Fact]
        public void DeleteReturnCorrectly()
        {
            var about = new KTaseva.Models.AboutMe
            {
                Id = 1
            };
            this.db.AboutMe.Add(about);
            this.db.SaveChanges();

            this.aboutMeService.Delete("1");

            Assert.DoesNotContain(about, this.db.AboutMe.ToList());
        }
    }
}
