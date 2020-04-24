using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.ViewModels.Admin
{
    public class AdminPhotoInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        public IFormFile Photo { get; set; }
    }
}
