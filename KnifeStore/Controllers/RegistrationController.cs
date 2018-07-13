using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
    public class RegistrationController : Controller
    {
        // Registration/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        





    }
}