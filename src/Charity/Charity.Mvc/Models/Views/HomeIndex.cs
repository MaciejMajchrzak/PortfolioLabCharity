using Charity.Mvc.Models.Selects;
using System.Collections.Generic;

namespace Charity.Mvc.Models.Views
{
    public class HomeIndex
    {
        public int CompletedBags { get; set; }
        public List<InstitutionSelect1> Institutions { get; set; }
        public int SupportedOrganizations { get; set; }
    }
}
