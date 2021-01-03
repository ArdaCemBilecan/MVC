using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNET
{
    public class ProductDal
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade; integrated security=true");
        public List<Product> GetAll()
        {
            // Bu  daha çok tercih ediliyor
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader(); // retrun yaptığı için atama yaptık

            List<Product> products = new List<Product>();

            while (reader.Read())   // For i in liste      mantığı ile çalışır
            {
                Product product = new Product { 
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                UnitPrice=Convert.ToDecimal(reader["UnitPrice"]),
                StockAmount = Convert.ToInt32(reader["StockAmount"])

                };

                products.Add(product);

            }

            reader.Close();
            connection.Close();
            return products;
        }


        public DataTable GetAll2()
        {
            // Bu kullanılmıyor
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Select * from Products",connection);
            SqlDataReader reader =  command.ExecuteReader(); // retrun yaptığı için atama yaptık

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }

        private void ConnectionControl()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Add(Product product)  // Verilen prodcutu listeye ekleyecek
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Insert into Products values(@name,@unitPrice,@stockAmount)",connection);
            command.Parameters.AddWithValue("@name",product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            connection.Close();
            // EntityFramework'de bunların hiçbir yazılmıyor
            // Sadece şu anlık nasıl olduğunu öğrenmek için yazıyoruz.

        }

        public void Update(Product product) 
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Update Products set Name=@name, UnitPrice=@unitPrice, StockAmount = @stockAmount where Id = @id", connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();
            connection.Close();
            // EntityFramework'de bunların hiçbir yazılmıyor
            // Sadece şu anlık nasıl olduğunu öğrenmek için yazıyoruz.

        }

        public void Delete(int id)  // id 'ye göre sileceğiz
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Delete from Products where Id = @id",connection);
            command.Parameters.AddWithValue("@id",id); 
            command.ExecuteNonQuery();
            connection.Close();
            // EntityFramework'de bunların hiçbir yazılmıyor
            // Sadece şu anlık nasıl olduğunu öğrenmek için yazıyoruz.

        }



    }
}
