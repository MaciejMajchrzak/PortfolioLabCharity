using Charity.Mvc.Services.Interfaces;
using System.Linq;

namespace Charity.Mvc.Services
{
    public class UserService : IUserService
    {
        private readonly CharityDonationContext _context;

        public UserService(CharityDonationContext context)
        {
            _context = context;
        }

        public string GetUserFirstName(string id)
        {
            return _context.Users
                .Where(a => a.Id == id)
                .Select(a => a.FirstName)
                .SingleOrDefault();
        }
    }
}
