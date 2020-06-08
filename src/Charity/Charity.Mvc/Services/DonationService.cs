using Charity.Mvc.Models.CharityDonation;
using Charity.Mvc.Services.Interfaces;
using System.Linq;

namespace Charity.Mvc.Services
{
    public class DonationService : IDonationService
    {
        private readonly CharityDonationContext _context;

        public DonationService(CharityDonationContext context)
        {
            _context = context;
        }

        public int CountOfCompletedBags()
        {
            return _context.Donations
                .Select(a => a.Quantity)
                .Sum();
        }

        public int CountOfSupportedOrganizations()
        {
            return _context.Donations
                .Select(a => a.InstitutionId)
                .Distinct()
                .Count();
        }

        public bool Create(Donation donation)
        {
            _context.Donations.Add(donation);

            return _context.SaveChanges() > 0;
        }
    }
}
