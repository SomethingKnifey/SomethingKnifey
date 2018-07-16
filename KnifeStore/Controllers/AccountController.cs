using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
	
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

		
        [HttpGet("/account/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

			List<Claim> claims = new List<Claim>();

            var user = new ApplicationUser
            {
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                UserName = rvm.Email,
                Email = rvm.Email
            };

            var result = await _userManager.CreateAsync(user, rvm.Password);

            if (result.Succeeded)
            {
				Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
				claims.Add(emailClaim);

				await _userManager.AddClaimAsync(user, emailClaim);

				if(user.Email == "silentbob@bob.com")
				{
					await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
					await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
				}
				else
				{
					await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
				}

                await _context.SaveChangesAsync();
				await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            return View(rvm);
        }

		
        [HttpGet("/account/login")]
        public IActionResult Login()
        {
            return View();
        }

		
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel lvm)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

				if (result.Succeeded)
				{
					if (User.IsInRole(ApplicationRoles.Admin))
					{
						return RedirectToAction("Index", "Admin");
					}

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Incorrect name/password combination");
				}
			}

			return View(lvm);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			TempData["LoggedOut"] = "User Logged Out";

			return RedirectToAction("Index", "Home");
		}
    }
}