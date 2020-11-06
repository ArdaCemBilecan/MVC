using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ProductRepository _context;
        public ServicesController(ProductRepository context)
        {
            _context = context;
        }

        public IActionResult Ais()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Ais").ToList();
            return View(result);
        }

        public IActionResult Anemometer()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Anemometer").ToList();
            return View(result);
        }
        public IActionResult Autopilot()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Autopilot").ToList();
            return View(result);
        }
        public IActionResult Bnwas()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Bnwas").ToList();
            return View(result);
        }
        public IActionResult Ecdis()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Ecdis").ToList();
            return View(result);
        }
        public IActionResult Echosounder()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Echosounder").ToList();
            return View(result);
        }
        public IActionResult Gps()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Gps").ToList();
            return View(result);
        }
        public IActionResult Gyro()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Gyro").ToList();
            return View(result);
        }
        public IActionResult Inmarsat()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Inmarsat").ToList();
            return View(result);
        }
        public IActionResult Navtex()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Navtex").ToList();
            return View(result);
        }
        public IActionResult Radar()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Radar").ToList();
            return View(result);
        }
        public IActionResult SatelliteSystem()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Satellite_System").ToList();
            return View(result);
        }
        public IActionResult SoundReceptionSystem()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Sound_Reception_System").ToList();
            return View(result);
        }
        public IActionResult Speedlog()
        { 
            var result = _context.Products.Where(i => i.CategoryName == "Speedlog").ToList();
            return View(result);
        }
        public IActionResult Vdr()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Vdr").ToList();
            return View(result);
        }
        public IActionResult Vhf_Mf_Hf()
        {
            var result = _context.Products.Where(i => i.CategoryName == "Vhf_Mf_Hf").ToList();
            return View(result);
        }

    }
}
