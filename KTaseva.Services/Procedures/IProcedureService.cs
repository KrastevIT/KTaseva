using KTaseva.ViewModels.Procedures;
using System.Collections.Generic;

namespace KTaseva.Services.Procedures
{
    public interface IProcedureService
    {
        IEnumerable<T> All<T>();
    }
}
