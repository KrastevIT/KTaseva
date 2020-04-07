using KTaseva.Data;
using KTaseva.Services.Mapping;
using KTaseva.ViewModels.Photos;
using System.Collections.Generic;
using System.Linq;

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
            var models = this.db.Photos.To<PhotoViewModel>().ToList();
            return models;
        }
    }
}
