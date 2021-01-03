using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
   public class ETradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }   // ETrade içinde Products'u arar.

    }
}
