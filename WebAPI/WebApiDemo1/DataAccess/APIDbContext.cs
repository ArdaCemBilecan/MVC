using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo1.Entities;

namespace WebApiDemo1.DataAccess
{
    public class APIDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=WebApiDB; Trusted_Connection=true");
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
