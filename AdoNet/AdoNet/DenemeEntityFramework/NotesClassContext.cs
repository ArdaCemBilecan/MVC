using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DenemeEntityFramework
{
    public class NotesClassContext:DbContext
    {

        public DbSet<Student> Students { get; set; } 
        
    }
}
