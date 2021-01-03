using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialForLesson
{
    public class ProductDal
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade; integrated security=true");
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            // Bu  daha çok tercih ediliyor
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader(); // retrun yaptığı için atama yaptık

            while (reader.Read())   // For i in liste      mantığı ile çalışır
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"])

                };

                products.Add(product);

            }

            reader.Close();
            connection.Close();
            return products;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values(@name,@unitprice,@stockamount)", connection);

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockamount", product.StockAmount);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name,UnitPrice=@unitprice," +
                "StockAmount=@stockamount Where Id=@id",connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockamount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Products Where Id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ConnectionControl()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

    }
}
