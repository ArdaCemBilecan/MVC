using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.Models
{
    public class ImageContext:DbContext
    {
        public ImageContext(DbContextOptions<ImageContext>options):base(options)
        {

        }

        DbSet<Image> Uzantilar { get; set; }

    }
}
