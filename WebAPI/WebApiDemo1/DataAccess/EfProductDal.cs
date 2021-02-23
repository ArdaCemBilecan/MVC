using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiDemo1.Entities;
using WebApiDemo1.Models;

namespace WebApiDemo1.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, APIDbContext>, IProductDal
    {
    }
}
