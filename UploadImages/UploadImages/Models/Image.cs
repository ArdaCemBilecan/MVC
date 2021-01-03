using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ResimYolu { get; set; }
        public string ResimYorum { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
