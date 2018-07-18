using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnifeStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //gets contexts
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// sets contexts
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet("/account/register")]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //if model is valid, instantiate new claim list
                List<Claim> claims = new List<Claim>();

                //instantiate new user with info from form
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    UserName = rvm.Email,
                    Email = rvm.Email
                };

                //creates new user
                var result = await _userManager.CreateAsync(user, rvm.Password);

                //if creation succeeds
                if (result.Succeeded)
                {
                    //adds new email claim
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    claims.Add(emailClaim);

                    //adds claims to user, adds user to database
                    await _userManager.AddClaimsAsync(user, claims);
                    await _context.SaveChangesAsync();

                    //test admin role entry
                    if(user.Email.ToLower() == "rick@rickandmorty.com")
                    {
                        //await _userManager.AddToRoleAsync(user, ApplicationUserRoles.Member);
                        await _userManager.AddToRoleAsync(user, ApplicationUserRoles.Admin);
                    }
                    //sets users to members by default
                    else
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationUserRoles.Member);
                    }

                    await _signInManager.SignInAsync(user, false);

                    if (await _userManager.IsInRoleAsync(user, ApplicationUserRoles.Admin))
                    {
                        TempData["thisUserName"] = $"{user.FirstName} {user.LastName}";
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        /// <summary>
        /// method to direct user to login page
        /// </summary>
        /// <returns>user sent to login view</returns>
        [AllowAnonymous]
        [HttpGet("/account/login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// method to post and validate login form data
        /// </summary>
        /// <param name="lvm">login view model taken from form</param>
        /// <returns>user to home page if successful, or message if not</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(lvm.Email);

                    if (await _userManager.IsInRoleAsync(user, ApplicationUserRoles.Admin))
                    {
                        TempData["thisUserName"] = $"{user.FirstName} {user.LastName}";
                        return RedirectToAction("Index", "Admin");
                    }

                    ApplicationUser thisUser = await _userManager.FindByEmailAsync(lvm.Email);
                    
                    TempData["thisUserName"] = $"{thisUser.FirstName} {thisUser.LastName}";

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
                        
            return View();
        }

        /// <summary>
        /// method to log out
        /// </summary>
        /// <returns>when user logged out, returns home index view</returns>
        [AllowAnonymous]
        [HttpGet("/account/logout")]
        public async Task<RedirectToActionResult> Logout()
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                TempData["LoggedOut"] = "Logout successful.";
            }

            return RedirectToAction("Index", "Home");
        }



    }
}