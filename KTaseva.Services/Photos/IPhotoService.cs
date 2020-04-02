using KTaseva.ViewModels.Photos;
using System.Collections.Generic;

namespace KTaseva.Services.Photos
{
    public interface IPhotoService
    {
        IEnumerable<PhotoViewModel> GetAllPhotos();
    }
}
