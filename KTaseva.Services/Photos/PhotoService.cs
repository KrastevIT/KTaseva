using KTaseva.Data;
using KTaseva.ViewModels.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTaseva.Services.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly KTasevaDbContext db;

        public PhotoService(KTasevaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PhotoViewModel> GetAllPhotos()
        {
            var photos = this.db.Photos.ToList();
            var models = new List<PhotoViewModel>();
            foreach (var photo in photos)
            {
                var model = new PhotoViewModel { Url = photo.Url };
                models.Add(model);
            }

            return models;
        }
    }
}
