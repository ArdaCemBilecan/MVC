using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VytsProje.Models;

namespace VytsProje.Controllers
{
    public class HomeController : Controller
    {
        readonly ProjeDbContext _context;

        public HomeController(ProjeDbContext context)
        {
            _context = context;
        }

        // index sayfasında müşteriler sıralansın
        public IActionResult Index()
        {
            var result = _context.Customer.ToList();
            return View(result);
        }


        public IActionResult Company(string name)
        {
            CompanyViewModel model = new CompanyViewModel();
            model.Sirketler = _context.Company.Where(i => i.CompanyName == name).ToList();
            model.Calisanlar = _context.Employees.Where(i => i.ComName == name).ToList();
            model.Arabalar = _context.Car.Where(i => i.ComName == name).ToList();
            return View(model);
        }

        public IActionResult Car(string carModel)
        {
            var result = _context.Car.Where(i => i.ComName == carModel).ToList();
            return View(result);
        }

        public IActionResult NewCustomer()
        {
            var result = _context.Car.ToList();
            return View(result);
        }
        [HttpPost]
        public IActionResult NewCustomer(IFormCollection form)
        {
            var araba = form["CarModel"].ToString();
            var isim = form["Name"].ToString();
            var soyisim = form["Surname"].ToString();
            var item = _context.Car.FirstOrDefault(i => i.CarModel == araba);
            customer c1 = new customer
            {
                CarModel = item.CarModel,
                CarName = item.CarName,
                Name = isim,
                Surname = soyisim,
                ComName = item.ComName
            };

            _context.Customer.Add(c1);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var result = _context.Customer.FirstOrDefault(i => i.Id == id);
            _context.Customer.Remove(result);
            _context.SaveChanges();
            ModelState.AddModelError(String.Empty, "Başarıyla Silindi");
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]

        public IActionResult Update(int id,IFormCollection form)
        {
            var result = _context.Customer.FirstOrDefault(i => i.Id == id);
            var araba = form["CarModel"].ToString();
            var isim = form["Name"].ToString();
            var soyisim = form["Surname"].ToString();

            var item = _context.Car.FirstOrDefault(i => i.CarModel == araba);

            result.Name = isim;
            result.Surname = soyisim;
            result.CarModel = araba;
            result.ComName = item.ComName;
            result.CarName = item.CarName;
            _context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}
