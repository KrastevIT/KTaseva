using KTaseva.Data;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.AboutMe;
using System.Collections.Generic;
using System.Linq;

namespace KTaseva.Services.AboutMe
{
    public class AboutMeService : IAboutMeService
    {
        private readonly KTasevaDbContext db;

        public AboutMeService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public void Add(AboutMeInputModel model)
        {
            var aboutMe = new KTaseva.Models.AboutMe
            {
                Title = model.Title,
                Description = model.Description
            };

            this.db.AboutMe.Add(aboutMe);
            this.db.SaveChanges();
        }

        public IEnumerable<T> All<T>()
        {
            var models = this.db.AboutMe
                .To<T>()
                .ToList();

            return models;
        }

        public void Edit(AboutMeInputModel model)
        {
            var about = this.db.AboutMe.FirstOrDefault(x => x.Id == model.Id);

            this.db.Entry(about).CurrentValues.SetValues(model);
            this.db.SaveChanges();
        }

        public AboutMeInputModel GetById(string id)
        {
            var about = this.db.AboutMe
                .To<AboutMeInputModel>()
                .FirstOrDefault(x => x.Id == int.Parse(id));

            return about;
        }

        public void Delete(string id)
        {
            var about = this.db.AboutMe.FirstOrDefault(x => x.Id == int.Parse(id));

            this.db.Remove(about);
            this.db.SaveChanges();
        }
    }
}
