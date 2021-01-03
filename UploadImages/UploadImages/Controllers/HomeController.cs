using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UploadImages.Models;

namespace UploadImages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageContext _context;
        private readonly IHostingEnvironment Environment;

        public HomeController(ImageContext context , IHostingEnvironment environment)
        {
            _context = context;
            Environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Ekle([Bind("id,ImageFile,ProductName,CategoryName")] Product product)
        {
            if (ModelState.IsValid)
            {

                string wwwRoot = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                string category = product.CategoryName;

                product.Image = fileName += extension;
                string path = Path.Combine(wwwRoot + "/img/" + category, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }

            return View(product);
        }


    }
}
