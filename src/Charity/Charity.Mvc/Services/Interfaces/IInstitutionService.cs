using Charity.Mvc.Models.Selects;
using System.Collections.Generic;

namespace Charity.Mvc.Services.Interfaces
{
    public interface IInstitutionService
    {
        IList<InstitutionSelect1> GetAllSelect1();
        IList<InstitutionSelect2> GetAllSelect2();
    }
}
