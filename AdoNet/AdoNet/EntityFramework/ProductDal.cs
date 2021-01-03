using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Data.Entity;

namespace EntityFramework
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                // Using şu işe yarar: iş bittiğinde contexti direk bellekter atar. Fazla yer kaplatmaz.
                // Tabloya ulaşma kodu bu:  GetAll ile yapacağımıza kısaca böyle bitiyor.
                return context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                // Contexteki Product'a parametreden gelen product'u ekle.
                //var entity = context.Entry(product);
                //entity.State = EntityState.Added;   Şeklinde de yazılabilir.
                context.SaveChanges();  // Değişiklikleir kaydet demek.
            }

        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();  // Değişiklikleir kaydet demek.
            }

        }


        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();  // Değişiklikleir kaydet demek.
            }

        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
                // Eğer çok fazla data varsa bu kullanılır. Bütün datayı getirip sonra rama yapmak yerine
                // Sadece istelineli arar ve getirir.
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result= context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }


    }
}
