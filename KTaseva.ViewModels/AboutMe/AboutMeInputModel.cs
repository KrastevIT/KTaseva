using KTaseva.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.ViewModels.AboutMe
{
    public class AboutMeInputModel : IMapFrom<KTaseva.Models.AboutMe>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето заглавие е задължително")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето описание е задължително")]
        public string Description { get; set; }
    }
}
