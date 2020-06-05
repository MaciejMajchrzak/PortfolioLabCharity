using System.ComponentModel.DataAnnotations.Schema;

namespace Charity.Mvc.Models.CharityDonation
{
    public class CategoryDonation
    {
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Donation")]
        public int DontaionId { get; set; }
        public Donation Donation { get; set; }
    }
}
