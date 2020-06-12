using Microsoft.AspNetCore.Identity;

namespace Charity.Mvc.Models.CharityDonation
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
