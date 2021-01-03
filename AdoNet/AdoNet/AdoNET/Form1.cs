using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal pDal = new ProductDal(); // Sürekli newlememek için gloabalde oluşturduk
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts(); // Bunu method haline getiriyoruz
            // Böylece add fonksiyonunda yeni eklediğmizi anında ekranda görebileceğiz
            // Yoksa sürekli kapatıp açmak zorunda kalırız 

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            MessageBox.Show("Product Added!");
            LoadProducts();


        }
        private void LoadProducts()
        {
            dgwProducts.DataSource = pDal.GetAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product {
            Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            Name = tbxNameUpdate.Text,
            UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
            StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
        };

            pDal.Update(product);
            LoadProducts();
            MessageBox.Show("Updated");

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            pDal.Delete(id);
            MessageBox.Show("Deleted");
            LoadProducts();
        }
    }
}
