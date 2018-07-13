using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
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
            ApplicationUser user = new ApplicationUser
            {
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                UserName = rvm.Email,
                Email = rvm.Email
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction();
        }





    }
}