using Charity.Mvc.Models.Selects;
using System.Collections.Generic;

namespace Charity.Mvc.Services.Interfaces
{
    public interface ICategoryService
    {
        IList<CategorySelect1> GetAllSelect1();
    }
}
