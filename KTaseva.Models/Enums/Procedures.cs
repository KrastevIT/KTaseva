using System.ComponentModel.DataAnnotations;

namespace KTaseva.Models.Enums
{
    public enum Procedures
    {
        [Display(Name = "Маникюр")]
        Manicure = 1,

        [Display(Name = "Маникюр с гел лак")]
        ManicureWithGelPolish = 2,

        [Display(Name = "Ноктопластика с гел")]
        NailArtWithGel = 3,

        [Display(Name = "Педикюр")]
        Pedicure = 4
    }
}
