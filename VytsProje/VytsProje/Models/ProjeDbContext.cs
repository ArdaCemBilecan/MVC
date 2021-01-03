using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VytsProje.Models
{
    public class ProjeDbContext:DbContext
    {
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options)
        {

        }

        public DbSet<employee> Employees { get; set; }
        public DbSet<car> Car { get; set; }

        public DbSet<company> Company { get; set; }

        public DbSet<customer> Customer { get; set; }

       
    }
}
