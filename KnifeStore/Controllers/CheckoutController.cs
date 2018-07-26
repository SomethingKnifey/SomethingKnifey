using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Models;
using KnifeStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public CheckoutController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Review()
        {
            if (User.Identity.Name == null)
            {
                RedirectToAction("Login", "Account");
            }

            var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);

            CheckoutViewModel cvm = new CheckoutViewModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email
            };

            return View(cvm);
        }

        //[HttpPost]
        //public async Task<IActionResult> Review(CheckoutViewModel cvm)
        //{
            
        //    RedirectToAction("Index", "Home");
        //}

    }
}