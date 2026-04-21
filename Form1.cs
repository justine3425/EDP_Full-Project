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
            else
            {
                DataTable dt = db.ExecuteReturnQuery("SELECT * from tbLoginCredentials WHERE user_username = @uname and user_password = @pword;",
                    new MySqlParameter("@uname", tbUsername.Text),
                    new MySqlParameter("@pword", tbPassword.Text));
                if (dt.Rows.Count == 1)
                {
                    frmHome frm = new frmHome();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
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

