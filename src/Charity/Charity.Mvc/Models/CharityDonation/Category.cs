using System.Collections.Generic;

namespace Charity.Mvc.Models.CharityDonation
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryDonation> CategoryDonations { get; set; }
    }
}
