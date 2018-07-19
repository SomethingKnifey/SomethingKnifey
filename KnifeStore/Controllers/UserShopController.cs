using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KnifeStore.Models;

namespace KnifeStore.Controllers
{
    public class UserShopController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// sets internal DbContext variable
        /// </summary>
        private KnifeDbContext _context;

		/// <summary>
		/// sets internal variable to DbContext of Knife Model
		/// </summary>
		/// <param name="context">context to set for internal variable</param>
		public UserShopController(KnifeDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// default index action, not currently being used
		/// </summary>
		/// <returns>view</returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// method to view all products as a list, action triggered by browse button on home index page
		/// </summary>
		/// <returns>ViewAllProducts view with list of products</returns>
		[HttpGet]
        public async Task<IActionResult> ViewAllProducts()
        {
			var AllProducts = await _context.Knives.ToListAsync();
            return View(AllProducts);
        }

		/// <summary>
		/// method to get an individual knife and display details, action triggered by view details button on list page
		/// </summary>
		/// <param name="id">nullable integer ID corresponding to knife DB primary key</param>
		/// <returns>view with specific knife</returns>
		[HttpGet]
		public async Task<IActionResult> ViewDetails(int? id)
		{
			if (id.HasValue)
			{
				var chosenBlade = await _context.Knives.FirstOrDefaultAsync(k => k.ID == id);

                if (chosenBlade.Style.ToString() != "Tactical" ||
                   (User.Identity.Name != null && User.Claims.First(c => c.Type == "MilitaryOrLE").Value == "True"))
                {
                    return View(chosenBlade);
                }

                return RedirectToAction("ViewAllProducts", "UserShop");                
            }

            return RedirectToAction("Index" , "Home");
		}

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int? id)
        {
            if (id.HasValue && _signInManager.IsSignedIn(User))
            {
                var chosenBlade = await _context.Knives.FirstOrDefaultAsync(k => k.ID == id);
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);

                user.Basket.Items.Add(chosenBlade);
            }
            
            return RedirectToAction("ViewAllProducts", "UserShop");
        }
    }
}
