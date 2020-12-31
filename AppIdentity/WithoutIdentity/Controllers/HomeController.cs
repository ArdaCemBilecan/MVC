using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Islemler2.Models;
using Microsoft.AspNetCore.Http;

namespace Islemler2.Controllers
{
    public class HomeController : Controller
    {
        CustomerDbContext _context;
        
        public HomeController(CustomerDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var uName = loginViewModel.Username;
            var psw = loginViewModel.Password;
            var kontrol = _context.Customers.FirstOrDefault(x => x.UserName == uName && x.Password == psw);

            if(kontrol == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı Adı ya da Parola yanlış!");
                return View(loginViewModel);
            }
            
            var control = "true";
            HttpContext.Session.SetString("login", control);
            HttpContext.Session.SetString("username", uName);


            return RedirectToAction("Index",new {@uName=HttpContext.Session.GetString("username")});
            

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new Customer
            {
                UserName = registerViewModel.UserName,
                EMail = registerViewModel.EMail,
                Password = registerViewModel.Password
            };

            var kayit = registerViewModel.UserName;
            var usr = _context.Customers.Where(i => i.UserName.Equals(kayit)).ToList();
            if(usr != null)
            {
                ModelState.AddModelError(String.Empty, "Böyle Bir Kullanıcı Adı zaten var ! ");
                return View(registerViewModel);
            }

            _context.AddAsync(user);
            _context.SaveChangesAsync();

            return View();
        }

        public IActionResult Index(string uName)
        {
            
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "false")
            {
                ModelState.AddModelError(String.Empty, "Lütfen Giriş Yapınız");
               return RedirectToAction("Login");
            }
            
            var result = _context.Articles.Where(i => i.Author == uName).ToList();
            ViewBag.session = HttpContext.Session.GetString("login");
            return View(result);
        }


        public IActionResult Contents(string title)
        {
            if (HttpContext.Session.GetString("login") != "true")
            {
                ModelState.AddModelError(String.Empty, "Lütfen Giriş Yapınız");
                return RedirectToAction("Login");
            }
            ViewBag.session = HttpContext.Session.GetString("login");
            var result = _context.Articles.Where(i => i.Title.Equals(title)).ToList();
            return View(result);
        }

        public IActionResult Exit()
        {
            string kontrol = "false";
            HttpContext.Session.SetString("login", kontrol);

            return RedirectToAction("Login");
        }

           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
