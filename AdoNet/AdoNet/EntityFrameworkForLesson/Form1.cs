using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkForLesson
{
    public partial class Form1 : Form
    {
        StudentDal pDal = new StudentDal();
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowAll()
        {
            dgwStudent.DataSource = pDal.GetAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Name = tbxName.Text.ToString(),
                Number = Convert.ToInt32(tbxNumber.Text),
                Note = Convert.ToInt32(tbxNote.Text)
            };
            pDal.Add(student);
            MessageBox.Show("Eklendi!");
            ShowAll();
        }

        private void dgwStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwStudent.CurrentRow.Cells[1].Value.ToString();
            tbxNumberUpdate.Text = dgwStudent.CurrentRow.Cells[2].Value.ToString();
            tbxNoteUpdate.Text = dgwStudent.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = Convert.ToInt32(dgwStudent.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                Number = Convert.ToInt32(tbxNumberUpdate.Text),
                Note = Convert.ToInt32(tbxNoteUpdate.Text)
            };
            pDal.Update(student);
            MessageBox.Show("Güncellendi!");
            ShowAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pDal.Delete(new Student
            {
                Id = Convert.ToInt32(dgwStudent.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("Silindi!");
            ShowAll();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text.ToString();
            if (string.IsNullOrEmpty(key))
            {
                ShowAll();
            }
            else
            {
                var result = pDal.GetByName(tbxSearch.Text);
                dgwStudent.DataSource = result;
            }

        }
    }


}
