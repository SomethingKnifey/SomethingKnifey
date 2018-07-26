using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
    public class CheckoutController : Controller
    {
        public CheckoutController()
        {

        }

        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Review()
        {

        }

    }
}