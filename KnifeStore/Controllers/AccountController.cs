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

            ApplicationUser user = new ApplicationUser
            {
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                UserName = rvm.Email,
                Email = rvm.Email
            };

            var result = await _userManager.CreateAsync(user, rvm.Password);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


    }
}