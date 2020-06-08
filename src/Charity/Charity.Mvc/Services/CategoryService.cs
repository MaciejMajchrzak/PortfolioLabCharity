using Charity.Mvc.Models.Selects;
using Charity.Mvc.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Charity.Mvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CharityDonationContext _context;

        public CategoryService(CharityDonationContext context)
        {
            _context = context;
        }

        public IList<CategorySelect1> GetAllSelect1() 
        {
            return _context.Categories
                .Select(a => new CategorySelect1
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }
    }
}
