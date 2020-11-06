using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site.Models;
namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository _context;
         public HomeController(ProductRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            var result = _context.Products.Where(i  =>  i.CategoryName == "Gallery").ToList();
              return View(result);
        }
        public IActionResult Services()
        {
            var result = _context.Category.OrderBy(a=>a.PageName);
            return View(result);
        }
        public IActionResult Certificate()
        {
            var result = _context.Products.Where(i  => i.CategoryName == "Certificate").ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Support()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Support(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Supports");
        }

    }
}
