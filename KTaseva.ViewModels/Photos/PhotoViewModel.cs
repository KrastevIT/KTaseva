using KTaseva.Models;
using KTaseva.Services.Mapping;

namespace KTaseva.ViewModels.Photos
{
    public class PhotoViewModel : IMapFrom<Photo>
    {
        public string Url { get; set; }
    }
}
