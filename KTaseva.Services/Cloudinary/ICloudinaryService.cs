using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KTaseva.Services.Cloudinary
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
