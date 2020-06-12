using Charity.Mvc.Models.CharityDonation;
using Charity.Mvc.Models.Selects;
using Charity.Mvc.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Charity.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<IdentityUser> _signInManager,
            UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSelect1 user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };

                if (!await roleManager.RoleExistsAsync("ActiveUser")) { await roleManager.CreateAsync(new IdentityRole("ActiveUser")); }
                if (!await roleManager.RoleExistsAsync("Admin")) { await roleManager.CreateAsync(new IdentityRole("Admin")); }

                var result = await userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    var login = await signInManager.PasswordSignInAsync(user.Login, user.Password, true, false);

                    if (login.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user.Login), "ActiveUser");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user.Login), "Admin");

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nie można się zalogować!");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            AccountRegister accountRegister = new AccountRegister()
            {
                User = user
            };

            return View(accountRegister);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserSelect2 user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);

                var isInRole = await userManager.IsInRoleAsync(
                    await userManager.FindByNameAsync(
                        user.UserName), "ActiveUser");

                if (result.Succeeded && isInRole)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.Succeeded && !isInRole)
                {
                    ModelState.AddModelError("", "Jesteś zablokowany!");
                }
                else
                {
                    ModelState.AddModelError("", "Nie można się zalogować!");
                }
            }

            AccountLogIn accountLogIn = new AccountLogIn()
            {
                User = user
            };

            return View(accountLogIn);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
