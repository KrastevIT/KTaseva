using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace KTaseva.Services.Cloudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        public Task<string> UploadImageAsync(IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}
