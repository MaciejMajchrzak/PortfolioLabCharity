using System;
using System.Collections.Generic;

namespace Charity.Mvc.Models.Selects
{
    public class DonationSelect1
    {
        public int Quantity { get; set; }
        public int InstitutionId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime PickUpDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public string PickUpComment { get; set; }
        public string Phone { get; set; }
        
        public List<CategorySelect2> Categorys { get; set; }
    }
}
