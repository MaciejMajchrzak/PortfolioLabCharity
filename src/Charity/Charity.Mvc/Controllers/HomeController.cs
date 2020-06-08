using Charity.Mvc.Models;
using Charity.Mvc.Models.Views;
using Charity.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Charity.Mvc.Controllers
{
    public class HomeController : Controller
	{
		private readonly IInstitutionService _institutionService;
		private readonly IDonationService _donationService;

        public HomeController(IInstitutionService institutionService,
			IDonationService donationService)
        {
			_institutionService = institutionService;
			_donationService = donationService;
        }

		public IActionResult Index()
		{
			HomeIndex homeIndex = new HomeIndex()
			{
				CompletedBags = _donationService.CountOfCompletedBags(),
				Institutions = _institutionService.GetAllSelect1().ToList(),
				SupportedOrganizations = _donationService.CountOfSupportedOrganizations()
			};

			return View(homeIndex);
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
