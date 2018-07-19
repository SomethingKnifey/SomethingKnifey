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
    // By default, users must be authorized to access url paths
    [Authorize]
    public class AccountController : Controller
    {
        //gets contexts
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Constructor method for AccountController
        /// Sets database contexts and AspNetCore.Identity properties 
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

        /// <summary>
        /// Method to accept requests to access the registration page
        /// </summary>
        /// <returns>Registration page View</returns>
        [AllowAnonymous]
        [HttpGet("/account/register")]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Method which creates a new ApplicationUser based on the values entered into the form
        /// on the registration page
        /// Claims for the user are generated based on various values entered into the form as well
        /// </summary>
        /// <param name="rvm">RegisterViewModel taken from form</param>
        /// <returns>Success: Redirect to home page; Failure: registration View</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //if model is valid, instantiate new claim list
                List<Claim> claims = new List<Claim>();

                //instantiate new user with info from form
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    IsMilitaryOrLE = rvm.IsMilitaryOrLE,
                    Basket = new Basket()
                };

                //creates new user
                var result = await _userManager.CreateAsync(user, rvm.Password);

                //if creation succeeds
                if (result.Succeeded)
                {
                    //add new Claims
                    string fullName = $"{user.FirstName} {user.LastName}";                    
                    Claim nameClaim = new Claim("FullName", fullName, ClaimValueTypes.String);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim milOrLEClaim = new Claim("MilitaryOrLE", user.IsMilitaryOrLE.ToString(), ClaimValueTypes.Boolean);

                    claims.Add(nameClaim);
                    claims.Add(emailClaim);
                    claims.Add(milOrLEClaim);

                    //adds claims to user, adds user to database
                    await _userManager.AddClaimsAsync(user, claims);

                    await _userManager.AddToRoleAsync(user, ApplicationUserRoles.Member);

                    if (user.Email == "rick@rickandmorty.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationUserRoles.Admin);
                    }

                    await _context.SaveChangesAsync();
                    
                    await _signInManager.SignInAsync(user, false);

                    if (await _userManager.IsInRoleAsync(user, ApplicationUserRoles.Admin))
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        /// <summary>
        /// Method to route users to the login page
        /// </summary>
        /// <returns>login View</returns>
        [AllowAnonymous]
        [HttpGet("/account/login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Method to validate users' login credentials based on the values input into the form
        /// on the login page
        /// </summary>
        /// <param name="lvm">LoginViewModel taken from form</param>
        /// <returns>Success: Redirect to home page; Failure: login View</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    ApplicationUser thisUser = await _userManager.FindByEmailAsync(lvm.Email);

                    if (await _userManager.IsInRoleAsync(thisUser, ApplicationUserRoles.Admin))
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
                        
            return View();
        }

        /// <summary>
        /// Method to log out the signed in user
        /// </summary>
        /// <returns>Redirect to home page</returns>
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