using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VytsProje.Models
{
    public class CompanyViewModel
    {
        public List<company> Sirketler { get; set; }
        public List<employee> Calisanlar { get; set; }
        public List<car> Arabalar { get; set; }
    }
}
