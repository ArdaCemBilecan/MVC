using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Product
    {
        public int id { get;   set; }
        public string Image { get;   set; }
        public string ProductName { get;   set; }
        public string CategoryName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get;   set; }
    }
}
