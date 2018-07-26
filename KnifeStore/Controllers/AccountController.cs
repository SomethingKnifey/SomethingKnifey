using System;
using System.Collections.Generic;
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
        /// Method to begin external login. Takes the provider info from the login page and executes the callback.
        /// </summary>
        /// <param name="provider">string input of provider taken from login.cshtml page button</param>
        /// <returns>external login page from microsoft or google.</returns>
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        /// <summary>
        /// callback method after challenge from third party API is executed.
        /// </summary>
        /// <param name="remoteError">if the challenge from the external login completes, this inputs a null value for a remote error, allowing the callback to continue</param>
        /// <returns>returns user to external login view to confirm email and password. If user is already registered they are redirected to the login page</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string remoteError = null)
        {
            //this immediately catches an error from the returned challenge and redirects back to login page.
            if(remoteError != null)
            {
                TempData["ErrorMessage"] = "Something went wrong";
                return RedirectToAction(nameof(Login));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            //returned result from third party
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            //gets the name and email returned from Google or Microsoft
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);
            string[] fullname = name.Split(" ");

            //this takes the provided information and checks to see if the user exists. If the user exists, they are logged in and returned to home index. If the user does not exist they are taken to the registration confirmation page to answer the claim question about military or law enforcement.
            try
            {

                ApplicationUser thisUser = await _userManager.FindByEmailAsync(email);

                await _signInManager.SignInAsync(thisUser, false);

                if (await _userManager.IsInRoleAsync(thisUser, ApplicationUserRoles.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }

                if(await _userManager.IsInRoleAsync(thisUser, ApplicationUserRoles.Member))
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch(Exception)
            {
                TempData["ErrorMessage"] = "Something went wrong";
                return RedirectToAction(nameof(Login));
            }

            //returns user to registration view if they do not currently exist
            return View("ExternalLogin", new ExternalLoginViewModel {
                Email = email,
                FirstName = fullname[0],
                LastName = fullname[1]
            });
        }

        /// <summary>
        /// post method for external login. The user is sent here to answer the claims question and finish registration.
        /// </summary>
        /// <param name="elvm">View model taken from the ExternalLogin form</param>
        /// <returns>Creates user in database and returns them to appropriate home index based on role of Member or Admin</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {

                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information.";
                }

                //if model is valid, instantiate new claim list
                List<Claim> claims = new List<Claim>();

                //instantiate new user with info from form
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = elvm.FirstName,
                    LastName = elvm.LastName,
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    
                };

                //creates new user
                var result = await _userManager.CreateAsync(user);

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

            return View(elvm);
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