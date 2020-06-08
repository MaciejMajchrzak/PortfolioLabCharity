using Charity.Mvc.Models.CharityDonation;
using Charity.Mvc.Models.Selects;
using Charity.Mvc.Models.Views;
using Charity.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Charity.Mvc.Controllers
{
    public class DonationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDonationService _donationService;
        private readonly IInstitutionService _institutionService;

        public DonationController(ICategoryService categoryService,
            IDonationService donationService,
            IInstitutionService institutionService)
        {
            _categoryService = categoryService;
            _donationService = donationService;
            _institutionService = institutionService;
        }

        [HttpGet]
        public IActionResult Donate()
        {
            DonationDonate donationDonate = new DonationDonate()
            {
                Categories = _categoryService.GetAllSelect1().ToList(),
                Donation = new DonationSelect1()
                {
                    PickUpDate = DateTime.Now,
                    Categorys = new List<CategorySelect2>()
                },
                Institutions = _institutionService.GetAllSelect2().ToList()
            };

            return View(donationDonate);
        }

        [HttpPost]
        public IActionResult DonateConfirmation(DonationSelect1 donation)
        {
            if(ModelState.IsValid)
            {
                Donation newDonation = new Donation()
                {
                    Quantity = donation.Quantity,
                    InstitutionId = donation.InstitutionId,
                    Street = donation.Street,
                    City = donation.City,
                    ZipCode = donation.ZipCode,
                    PickUpDate = donation.PickUpDate,
                    PickUpTime = donation.PickUpTime,
                    PickUpComment = donation.PickUpComment,
                    CategoryDonations = new List<CategoryDonation>()
                };

                foreach(var category in donation.Categorys)
                {
                    if(category.Checked)
                    {
                        newDonation.CategoryDonations.Add(new CategoryDonation()
                        {
                            CategoryId = category.Id
                        });
                    }
                }

                _donationService.Create(newDonation);

                return View();
            }

            return RedirectToAction("Donte", "Donation", donation);
        }
    }
}
