using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Mvc.Models.CharityDonation
{
    public class Donation
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime PickUpDate { get; set; }
        
        public DateTime PickUpTime { get; set; }
        
        public string PickUpComment { get; set; }

        public ICollection<CategoryDonation> CategoryDonations { get; set; }
    }
}
