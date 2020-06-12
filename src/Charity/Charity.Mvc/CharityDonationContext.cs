using Charity.Mvc.Models.CharityDonation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Charity.Mvc
{
    public class CharityDonationContext : IdentityDbContext
    {
        public CharityDonationContext(DbContextOptions<CharityDonationContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDonation> CategorysDonations { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public new DbSet<User> Users { get; set; }
    }
}
