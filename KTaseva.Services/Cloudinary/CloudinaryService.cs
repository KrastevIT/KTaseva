using CloudinaryDotNet.Actions;
using KTaseva.Data;
using KTaseva.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace KTaseva.Services.Cloudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly CloudinaryDotNet.Cloudinary cloudinary;
        private readonly KTasevaDbContext db;

        public CloudinaryService(CloudinaryDotNet.Cloudinary cloudinary, KTasevaDbContext db)
        {
            this.cloudinary = cloudinary;
            this.db = db;
        }

        public async Task UploadImageAsync(IFormFile image, string userId)
        {
            byte[] imageByte;
            string path = string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                imageByte = memoryStream.ToArray();
            }

            using (var destinationSteam = new MemoryStream(imageByte))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.Name, destinationSteam)
                };
                var uploadResult = await cloudinary.UploadAsync(uploadParams);
                path = uploadResult.Uri.AbsoluteUri;
            }

            var photo = new Photo
            {
                Url = path,
                UserId = userId
            };

            this.db.Photos.Add(photo);
            this.db.SaveChanges();
        }
    }
}
