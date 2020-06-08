using Charity.Mvc.Models.Selects;
using System.Collections.Generic;

namespace Charity.Mvc.Models.Views
{
    public class DonationDonate
    {
        public List<CategorySelect1> Categories { get; set; }
        public DonationSelect1 Donation { get; set; }
        public List<InstitutionSelect2> Institutions { get; set; }

        
    }
}
