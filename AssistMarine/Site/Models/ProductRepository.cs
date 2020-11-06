using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class ProductRepository:DbContext
    {
        public ProductRepository(DbContextOptions<ProductRepository> options) : base(options)
        {

        }

        public DbSet<Product> Products { get;   set; }
        public DbSet<Category> Category { get;   set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
