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
        public async Task<IActionResult> AddToCart(int? id)
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

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id.HasValue && User.Identity.Name != null)
            {
                var chosenBlade = await _knifeContext.Knives.FirstOrDefaultAsync(k => k.ID == id);
                var user = await _appContext.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

                //if (user.Basket.Items.Contains(chosenBlade))
                //{
                //    try
                //    {
                //        user.Basket.Items.Remove(chosenBlade);

                //        await _appContext.SaveChangesAsync();
                //    }
                //    catch
                //    {

                //    }                    
                //}
            }

            return RedirectToAction("ViewAllProducts", "UserShop");
        }
    }
}