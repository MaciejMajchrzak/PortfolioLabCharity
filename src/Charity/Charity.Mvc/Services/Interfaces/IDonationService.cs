using Charity.Mvc.Models.CharityDonation;

namespace Charity.Mvc.Services.Interfaces
{
    public interface IDonationService
    {
        int CountOfCompletedBags();
        int CountOfSupportedOrganizations();

        bool Create(Donation donation);
    }
}
