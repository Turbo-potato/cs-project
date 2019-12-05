using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Services;
using DiasApp.Session;
using DiasApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiasApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserService _userService;

        const string SessionKeyName = "_Name";
        const string SessionKeyAge = "_Age";
        const string SessionKeyTime = "_Time";
        const string SessionKeyUser = "_DefaultUser";

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year, Username = model.Username };
                // add user
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //assign a default user role
                    await _userManager.AddToRoleAsync(user, "user");
                    // set cookie 
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        //three       
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpGet]
        public IActionResult Profile()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName) ?? "Anonymous";
            //ViewBag.Age = HttpContext.Session.GetInt32(SessionKeyAge) ?? 0;
            ViewBag.Time = HttpContext.Session.GetString(SessionKeyTime.ToString()) ?? ""; 

            ViewBag.DefaultUser = HttpContext.Session.GetObject<User>(SessionKeyUser);
            //Temp data for anonymous 
            TempData["userState"] = "authorized" ?? "Anonymous";
            TempData["authInfo"] = "You can use the site's full features!" ?? "Authorize to get the site's full features!";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //remove if user exists
                    HttpContext.Session.Remove(SessionKeyUser);

                    User user = new User();
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    // var dbUser = await _userService.SearchByEmail(model.Email);
                    user.Username = model.Email;
                    //session user                
                    HttpContext.Session.SetObject<User>(SessionKeyUser, user);

                    //default name and year
                        HttpContext.Session.SetString(SessionKeyName, "Authorized");
                        //HttpContext.Session.SetInt32(SessionKeyAge, 21);
                    

                    //default time login
                    if (HttpContext.Session.GetObject<DateTime>(SessionKeyTime) == default(DateTime))
                    {
                        HttpContext.Session.SetObject<DateTime>(SessionKeyTime, DateTime.Now);
                    }

                    //extend cookies to 72 hours
                    if (model.RememberMe)
                    {
                        string ASPCookie = Request.Cookies["ASP.NET_SessionId"];
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddHours(72);
                    }

                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {                      
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            //remove if user exists
            HttpContext.Session.Remove(SessionKeyUser);
            //remove if status exists
            HttpContext.Session.Remove(SessionKeyName);
            //remove if time exists
            HttpContext.Session.Remove(SessionKeyTime);
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}