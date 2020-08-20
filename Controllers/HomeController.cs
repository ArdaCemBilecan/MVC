using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DbPratik.Models;

namespace DbPratik.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentContext _context;
        public HomeController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id=0)
        {
            if(id == 0)
            {
                var result = _context.Students.ToList();
                return View(result);
            }
            else
            {
                var result = _context.Students.Find(id);
                _context.Students.Remove(result);
                _context.SaveChanges();
                return View(_context.Students.ToList());
                
            }

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
 
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _context.Students.Find(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(int id,Student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
