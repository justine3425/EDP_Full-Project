using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArciagaJustine_BSIT2D
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form registerForm = new Form();
            registerForm.Text = "Register";
            registerForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form storeForm = new Form();
            storeForm.Text = "Store Status";
            storeForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form priceForm = new Form();
            priceForm.Text = "Price Book";
            priceForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form vendorsForm = new Form();
            vendorsForm.Text = "Vendors";
            vendorsForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form usersForm = new Form();
            usersForm.Text = "Users";
            usersForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form timeForm = new Form();
            timeForm.Text = "Time Clock";
            timeForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}