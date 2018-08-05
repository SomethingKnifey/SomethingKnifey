using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Controllers
{
    public class CartController : Controller
    {
        private KnifeDbContext _knifeContext;
        private ApplicationDbContext _appContext;

        public CartController(KnifeDbContext knifeContext, ApplicationDbContext appContext)
        {
            _knifeContext = knifeContext;
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<RedirectToActionResult> AddToCart(int? id)
        {
            if (id.HasValue && User.Identity.Name != null)
            {
                var chosenBlade = await _knifeContext.Knives.FirstOrDefaultAsync(k => k.ID == id);
                var user = await _appContext.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

                Basket basket = new Basket
                {
                    Username = user.UserName,
                    KnifeModel = chosenBlade.Model
                };
                
                await _appContext.Baskets.AddAsync(basket);
                await _appContext.SaveChangesAsync();
            }

            return RedirectToAction("ViewAllProducts", "UserShop");
        }

        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            if (User.Identity.Name == null)
            {
                return View();
            }

            List<Knife> knivesInBasket = new List<Knife>();

            foreach (var basket in _appContext.Baskets)
            {
                if (basket.Username == User.Identity.Name)
                {
                    var knife = await _knifeContext.Knives.FirstOrDefaultAsync(k => basket.KnifeModel == k.Model);
                    knivesInBasket.Add(knife);
                }
            }

            return View(knivesInBasket);            
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(string knifeModel)
        {
            if (User.Identity.Name != null && !String.IsNullOrEmpty(knifeModel))
            {
                var basket = await _appContext.Baskets.FirstOrDefaultAsync(b => b.Username == User.Identity.Name && b.KnifeModel == knifeModel);
                _appContext.Baskets.Remove(basket);

                await _appContext.SaveChangesAsync();
            }

            return RedirectToAction("ViewAllProducts", "UserShop");
        }
    }
}