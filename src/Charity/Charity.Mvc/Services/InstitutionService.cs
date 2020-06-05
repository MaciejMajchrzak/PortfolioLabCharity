using Charity.Mvc.Models.Selects;
using Charity.Mvc.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Charity.Mvc.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly CharityDonationContext _context;

        public InstitutionService(CharityDonationContext context)
        {
            _context = context;
        }

        public IList<InstitutionSelect1> GetSelect1()
        {
            return _context.Institutions
                .Select(a => new InstitutionSelect1
                {
                    Name = a.Name,
                    Description = a.Description
                })
                .ToList();
        }
    }
}
