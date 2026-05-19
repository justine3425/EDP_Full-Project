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
            Register registerForm = new Register();
            registerForm.Text = "Register";
            registerForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StoreStatus  storeForm = new StoreStatus();
            storeForm.Text = "Store Status";
            storeForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PriceBook priceForm = new PriceBook();
            priceForm.Text = "Price Book";
            priceForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Vendors vendorsForm = new Vendors();
            vendorsForm.Text = "Vendors";
            vendorsForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Users usersForm = new Users();
            usersForm.Text = "Users";
            usersForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TimeClock timeForm = new TimeClock();
            timeForm.Text = "Time Clock";
            timeForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
           
        }
    }
}