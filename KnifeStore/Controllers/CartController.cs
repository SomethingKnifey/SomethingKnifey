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
        private BasketDbContext _basketContext;
        private KnifeDbContext _knifeContext;
        private ApplicationDbContext _appContext;

        public CartController(BasketDbContext basketContext, KnifeDbContext knifeContext, ApplicationDbContext appContext)
        {
            _basketContext = basketContext;
            _knifeContext = knifeContext;
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id.HasValue && User.Identity.Name != null)
            {
                var chosenBlade = await _knifeContext.Knives.FirstOrDefaultAsync(k => k.ID == id);
                var user = await _appContext.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var basket = await _basketContext.Baskets.FirstOrDefaultAsync(b => b.ID == user.BasketID);

                basket.Items.Add(chosenBlade);

                await _basketContext.SaveChangesAsync();
            }

            return RedirectToAction("ViewAllProducts", "UserShop");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id.HasValue && User.Identity.Name != null)
            {
                var chosenBlade = await _knifeContext.Knives.FirstOrDefaultAsync(k => k.ID == id);
                var user = await _appContext.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var basket = await _basketContext.Baskets.FirstOrDefaultAsync(b => b.ID == user.BasketID);

                if (basket.Items.Contains(chosenBlade))
                {
                    basket.Items.Remove(chosenBlade);

                    await _basketContext.SaveChangesAsync();
                }
            }

            return RedirectToAction("ViewAllProducts", "UserShop");
        }
    }
}