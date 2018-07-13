using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Controllers
{
    public class UserShopController : Controller
    {

		private KnifeDbContext _context;

		public UserShopController(KnifeDbContext context)
		{
			_context = context;
		}

        public async Task<IActionResult> ViewAllProducts()
        {

			var AllProducts = await _context.Knives.ToListAsync();
            return View();
        }
    }
}
