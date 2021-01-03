using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StudentDal _studentDal = new StudentDal();
        private void dgwStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void LoadStudent()
        {
            dgwStudent.DataSource = _studentDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _studentDal.Add(new Student
            {
                Name=tbxName.Text,
                Number = Convert.ToInt32(tbxNumber.Text),
                Note = Convert.ToInt32(tbxNote.Text)
            });
            MessageBox.Show("Added");
            LoadStudent();
        }

        private void dgwStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwStudent.CurrentRow.Cells[1].Value.ToString();
            tbxNumberUpdate.Text = dgwStudent.CurrentRow.Cells[2].Value.ToString();
            tbxNoteUpdate.Text = dgwStudent.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _studentDal.Update(new Student
            {
                Id = Convert.ToInt32(dgwStudent.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                Number = Convert.ToInt32(tbxNumberUpdate.Text),
                Note = Convert.ToInt32(tbxNoteUpdate.Text)
            });

            LoadStudent();
            MessageBox.Show("Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _studentDal.Delete(new Student
            {
                Id = Convert.ToInt32(dgwStudent.CurrentRow.Cells[0].Value)
            });
            LoadStudent();
            MessageBox.Show("Deleted!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            var result = _studentDal.GetByName(tbxSearch.Text);
            dgwStudent.DataSource = result;
        }
    }
}
