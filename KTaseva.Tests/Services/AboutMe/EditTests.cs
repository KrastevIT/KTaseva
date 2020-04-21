using KTaseva.Data;
using KTaseva.Services.AboutMe;
using KTaseva.Tests.Configurations;
using KTaseva.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace KTaseva.Tests.Services.AboutMe
{
    public class EditTests
    {
        private readonly KTasevaDbContext db;
        private readonly AboutMeService aboutMeService;

        public EditTests()
        {
            this.db = new KTasevaDbContext(MemoryDatabase.OptionBuilder());
            this.aboutMeService = new AboutMeService(db);
        }

        [Fact]
        public void EditReturntCorrectly()
        {
            var about = new KTaseva.Models.AboutMe
            {
                Id = 1,
                Title = "Test"
            };
            this.db.AboutMe.Add(about);
            this.db.SaveChanges();

            var model = new AboutMeInputModel
            {
                Id = 1,
                Title = "NewTest"
            };

            this.aboutMeService.Edit(model);

            var actual = this.db.AboutMe.FirstOrDefault(x => x.Id == model.Id);

            Assert.Equal("NewTest", actual.Title);
        }
    }
}
