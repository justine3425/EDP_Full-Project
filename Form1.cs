using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArciagaJustine_BSIT2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyDatabase db = new MyDatabase();
        string[,] userCredentials =
        {
            {"justine", "arciaga", "Justine Arciaga!"}
        };
        private object textBox1;

        private void Form1_Load(object sender, EventArgs e)
        {

            if (db.TestConnection() == true)
            {
                MessageBox.Show("Connected to Database");
            }
            else
            {
                MessageBox.Show("Database Connection Failed");
            }
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

            if (db.TestConnection() == true)
            {
                MessageBox.Show("Connected to Database");
            }
            else
            {
                MessageBox.Show("Database Connection Failed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter username", "Validation");
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Validation");
                tbPassword.Focus();
            }
            else
            {
                DataTable dtActive = db.ExecuteReturnQuery(
                    "SELECT * FROM tblLoginCredentials WHERE user_username = @uname AND user_password = @pword AND is_active = 1;",
                    new MySqlParameter("@uname", tbUsername.Text),
                    new MySqlParameter("@pword", tbPassword.Text));

                if (dtActive.Rows.Count == 1)
                {
                    frmHome frm = new frmHome();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    DataTable dtInactive = db.ExecuteReturnQuery(
                        "SELECT * FROM tblLoginCredentials WHERE user_username = @uname AND user_password = @pword AND is_active = 0;",
                        new MySqlParameter("@uname", tbUsername.Text),
                        new MySqlParameter("@pword", tbPassword.Text));

                    if (dtInactive.Rows.Count == 1)
                    {
                        MessageBox.Show("This account has been deactivated.", "Account Deactivated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password", "Login Failed");
                    }
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
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