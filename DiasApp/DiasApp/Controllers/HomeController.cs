using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiasApp.Models;
using Microsoft.AspNetCore.Http;
using DiasApp.Session;
using Microsoft.AspNetCore.SignalR;
using DiasApp.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace DiasApp.Controllers
{
    public class HomeController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyAge = "_Age";
        const string SessionKeyTime = "_Time";
        const string SessionKeyUser = "_DefaultUser";
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {           
            // HttpContext.Session.SetString(SessionKeyName, "Jack");
            //HttpContext.Session.SetInt32(SessionKeyAge, 24);

            //default name and age
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Anonymous");
                //HttpContext.Session.SetInt32(SessionKeyAge, 0);
            }

            //default time
            if (HttpContext.Session.GetObject<DateTime>(SessionKeyTime) == default(DateTime))
            {
                HttpContext.Session.SetObject<DateTime>(SessionKeyTime, DateTime.Now);
            }

            //default user
            if (HttpContext.Session.GetObject<User>(SessionKeyUser) == null) {
                User user = new User();
                user.UserName = "none";
                user.Email = "none";
                HttpContext.Session.SetObject<User>(SessionKeyUser, user);
            }

            //Temp data for anonymous 
            TempData["userState"] = "anonymous";
            TempData["authInfo"] = "Authorize to get the site's full features!";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            /* if (TempData.ContainsKey("user"))
             {
                 ViewBag.UserState = TempData["user"] as string;
             }

             if (TempData.ContainsKey("authInfo"))
             {
                 ViewBag.AuthInfo = TempData["authInfo"] as string;
             }*/

            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName) ?? "Anonymous";

            if (HttpContext.Session.GetString(SessionKeyTime) != null)
                ViewBag.Time = HttpContext.Session.GetString(SessionKeyTime).ToString() ?? DateTime.Now.ToString();
            else
                ViewBag.Time = "none";
            //ViewBag.Age = HttpContext.Session.GetInt32(SessionKeyAge) ?? 0;

            ViewBag.DefaultUser = HttpContext.Session.GetObject<User>(SessionKeyUser);

            return View();
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult Chat()
        {
            _hubContext.Clients.All.SendAsync("Notify", $"Chat loaded at: {DateTime.Now}");
            ViewData["Message"] = "Online chat to talk to others";
            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName) ?? "Anonymous";

            if (HttpContext.Session.GetString(SessionKeyTime) != null)
                ViewBag.Time = HttpContext.Session.GetString(SessionKeyTime).ToString() ?? DateTime.Now.ToString();
            else
                ViewBag.Time = "none";

            ViewBag.DefaultUser = HttpContext.Session.GetObject<User>(SessionKeyUser);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            /* if (TempData.ContainsKey("user"))
             {
                 ViewBag.User = TempData["user"] as string;
             }

             if (TempData.ContainsKey("authInfo"))
             {
                 ViewBag.AuthInfo = TempData["authInfo"] as string;
             }*/

            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName) ?? "Anonymous";

            if (HttpContext.Session.GetString(SessionKeyTime) != null)
                ViewBag.Time = HttpContext.Session.GetString(SessionKeyTime).ToString() ?? DateTime.Now.ToString();
            else
                ViewBag.Time = "none";

            ViewBag.DefaultUser = HttpContext.Session.GetObject<User>(SessionKeyUser);

            return View();
        }

        public IActionResult Privacy()
        {
            /*if (TempData.ContainsKey("user"))
            {
                ViewBag.User = TempData["user"] as string;
            }

            if (TempData.ContainsKey("authInfo"))
            {
                ViewBag.AuthInfo = TempData["authInfo"] as string;
            }*/

            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName) ?? "Anonymous";

            if (HttpContext.Session.GetString(SessionKeyTime) != null)
                ViewBag.Time = HttpContext.Session.GetString(SessionKeyTime).ToString() ?? DateTime.Now.ToString();
            else
                ViewBag.Time = "none";

            ViewBag.DefaultUser = HttpContext.Session.GetObject<User>(SessionKeyUser);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
