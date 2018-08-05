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
    public class CheckoutController : Controller
    {
        private ApplicationDbContext _appContext;
        private UserManager<ApplicationUser> _userManager;

        public CheckoutController(
            ApplicationDbContext appContext,
            UserManager<ApplicationUser> userManager)
        {
            _appContext = appContext;
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
                EmailAddress = currentUser.Email
            };

            return View(cvm);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Review(CheckoutViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Review", "Checkout");
            }

            int.TryParse(cvm.ZipCode, out int zip);
            if (zip == 0)
            {
                return RedirectToAction("Review", "Checkout");
            }

            Order customerOrder = new Order
            {
                Username = User.Identity.Name,
                FirstName = cvm.FirstName,
                LastName = cvm.LastName,
                EmailAddress = cvm.EmailAddress,
                StreetAddress = cvm.StreetAddress,
                City = cvm.City,
                State = cvm.State.ToString(),
                ZipCode = zip
            };

            var customerBaskets = from baskets in _appContext.Baskets
                              where baskets.Username == User.Identity.Name
                              select baskets;
                        
            await _appContext.Orders.AddAsync(customerOrder);
            _appContext.Baskets.RemoveRange(customerBaskets);
            await _appContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}