using KTaseva.Services.Mapping;

namespace KTaseva.ViewModels.AboutMe
{
    public class AboutMeViewModel : IMapFrom<KTaseva.Models.AboutMe>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
