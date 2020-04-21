using KTaseva.ViewModels.AboutMe;
using System.Collections.Generic;

namespace KTaseva.Services.AboutMe
{
    public interface IAboutMeService
    {
        void Add(AboutMeInputModel model);

        IEnumerable<T> All<T>();

        AboutMeInputModel GetById(string id);

        void Edit(AboutMeInputModel model);

        void Delete(string id);
    }
}
