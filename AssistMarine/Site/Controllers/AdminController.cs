using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Site.Controllers
{
    public class AdminController : Controller
    {
        readonly private ProductRepository _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AdminController(ProductRepository context, IWebHostEnvironment Environment)
        {
            _context = context;
            _hostEnvironment = Environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string id = form["id"].ToString();
            string psw = form["password"].ToString();

            HttpContext.Session.SetString("Id", id);
            HttpContext.Session.SetString("Password", psw);

            return RedirectToAction("ShowMessage");
        }

        public IActionResult ShowMessage(int cId = 0)
        {
            var id = HttpContext.Session.GetString("Id");
            var psw = HttpContext.Session.GetString("Password");

            if (id == "admin" && psw == "admin")
            {
                if (cId == 0)
                {
                    var result1 = _context.Customers.OrderByDescending(a => a.id).ToList();
                    return View(result1);
                }
                var result = _context.Customers.Find(cId);
                _context.Customers.Remove(result);
                _context.SaveChanges();
                return View(_context.Customers.OrderByDescending(a => a.id).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ImageFile,ProductName,CategoryName")] Product product)
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

        public IActionResult ShowAll(int id = 0)
        {
            if (id == 0)
            {
                var result = _context.Products.OrderBy(a => a.CategoryName).ToList();

                return View(result);
            }
            else
            {
                var result = _context.Products.Find(id);
                var category = result.CategoryName;
                string wwwRoot = _hostEnvironment.WebRootPath;
                System.IO.File.Delete(Path.Combine(wwwRoot + "/img/" + category + "/" + result.Image));


                _context.Products.Remove(result);
                _context.SaveChanges();
                return View(_context.Products.OrderBy(a => a.CategoryName).ToList());
            }

        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var pro = await _context.Products.FindAsync(id);

            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ProductName,CategoryName,ImageFile,Image")] Product product)
        {

            if (id != product.id)
            {
                return NotFound();
            }

            if (product.ImageFile == null || product.ImageFile.Length == 0)
            {

                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowAll));
            }


            ResimSil(id);

            // Burda ise yeni resmi ekliyoruz
            string fileNameNew = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string wwwRootPath = _hostEnvironment.WebRootPath;

            string extension = Path.GetExtension(product.ImageFile.FileName);
            string categoryNew = product.CategoryName;

            product.Image = fileNameNew += extension;
            string path = Path.Combine(wwwRootPath + "/img/" + categoryNew, fileNameNew);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }
            SqlConnection connection = new SqlConnection(@"workstation id=ProductDb.mssql.somee.com;packet size=4096;user id=batu;pwd=123456Bb;data source=ProductDb.mssql.somee.com;persist security info=False;initial catalog=ProductDb");
            // Yeni resmi veritabanýna ekliyoruz.
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand(
            "Update Products set ProductName=@ProductName, Image=@Image, CategoryName = @CategoryName where id = @id", connection);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Image", product.Image);
            command.Parameters.AddWithValue("@CategoryName", product.CategoryName);
            command.Parameters.AddWithValue("@id", product.id);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction(nameof(ShowAll));




        }
        public void ResimSil(int id)
        {
            // Burada resimi siliyoruz.
            var result = _context.Products.Find(id);
            var category = result.CategoryName;
            string wwwRoot = _hostEnvironment.WebRootPath;
            System.IO.File.Delete(Path.Combine(wwwRoot + "/img/" + category + "/" + result.Image));
        }

    }
}
