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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] userCredentials =
        {
            {"justine", "arciaga", "Justine Arciaga!"}
        };

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Please enter Username!", "Validation");
                tbUsername.Focus();
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Please enter password!", "Validation");
                tbPassword.Focus();
                return;
            }

            bool loginSuccess = false;

            for (int x = 0; x < userCredentials.GetLength(0); x++)
            {
                if (username == userCredentials[x, 0] && password == userCredentials[x, 1])
                {
                    MessageBox.Show("Welcome " + userCredentials[x, 2]);

                    frmHome home = new frmHome();
                    home.Show();
                    this.Hide();

                    loginSuccess = true;
                    break;
                }
            }

            if (!loginSuccess)
            {
                MessageBox.Show("Invalid Username/Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUsername.Focus();
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}