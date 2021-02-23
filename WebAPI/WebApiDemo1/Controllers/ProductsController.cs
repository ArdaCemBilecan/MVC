using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo1.DataAccess;
using WebApiDemo1.Entities;

namespace WebApiDemo1.Controllers
{
    [Route("api/products")]
    public class ProductsController:Controller
    {
        IProductDal _productDal;
        public ProductsController(IProductDal proDal)
        {
            _productDal = proDal;
        }

        [HttpGet("")] //default oalrak bunu çalıştır demek
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }

        // Parametreli Veri döndürmek
        [HttpGet("{proId}")]
        public IActionResult Get(int proId)
        {
            try
            {
                var product = _productDal.Get(p => p.Id == proId);
                if(product == null)
                {
                    return NotFound("There is no Product");
                }
                return Ok(product);
            }
            catch
            {}
            return BadRequest();
        }

        public IActionResult Post(Product product)
        { // [FromBody] Product product ile JSon formatında getireceğimizi söyleriz.
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);

            }
            catch { }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);

            }
            catch { }
            return BadRequest();
        }


        [HttpDelete("{proId}")]
        public IActionResult Delete(int proId)
        {
            try
            {
                var product = _productDal.Get(i=>i.Id==proId);
                _productDal.Delete(product);
                return Ok();

            }
            catch { }
            return BadRequest();
        }


    }
}
