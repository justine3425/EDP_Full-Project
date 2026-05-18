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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        MyDatabase db = new MyDatabase();
        bool isUpdate = false;

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome frm = new frmHome();
            frm.Show();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            string query = "SELECT tbluserinformation.userID, tbllogincredentials.LoginID, tbluserinformation.firstname, tbluserinformation.middlename, tbluserinformation.lastname, tbluserinformation.emailAddress, tbluserinformation.homeAddress, tbluserinformation.birthDate, tbllogincredentials.user_username as 'Username', tbllogincredentials.user_password as 'Password' FROM tbllogincredentials INNER JOIN tbluserinformation ON tbllogincredentials.userID = tbluserinformation.userID;";

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.DataSource = db.ExecuteReturnQuery(query);
            dgvUsers.Columns[0].Visible = false;
            dgvUsers.Columns[1].Visible = false;
        }
        private void ClearFields()
        {
            tbFname.Clear();
            tbMname.Clear();
            tbLname.Clear();
            tbEmailAdd.Clear();
            tbHomeAdd.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
            dtpBirthDate.Value = DateTime.Now;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(tbEmailAdd.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error");
                tbEmailAdd.Focus();
                return;
            }

            if (isUpdate == false)
            {
                string query = "INSERT INTO tbluserinformation (firstname, middlename, lastname, emailAddress, homeAddress, birthDate) VALUES (@fname, @mname, @lname, @email, @hadd, @bDate);SET @newUserID = LAST_INSERT_ID();INSERT INTO tbllogincredentials (userID, user_username, user_password) VALUES (@newUserID, @username, @password);";

                int affectedRowCount = db.ExecuteNoReturnQuery(query,
                    new MySqlParameter("@fname", tbFname.Text),
                    new MySqlParameter("@mname", tbMname.Text),
                    new MySqlParameter("@lname", tbLname.Text),
                    new MySqlParameter("@email", tbEmailAdd.Text),
                    new MySqlParameter("@hadd", tbHomeAdd.Text),
                    new MySqlParameter("@bDate", dtpBirthDate.Value),
                    new MySqlParameter("@username", tbUsername.Text),
                    new MySqlParameter("@password", tbPassword.Text)
                    );

                if (affectedRowCount > 0)
                {
                    MessageBox.Show("Data Inserted!");
                    frmUsers_Load(null, null);
                }
            }
            else if (isUpdate == true)
            {
                string query = "UPDATE tbluserinformation SET firstname = @fname, middlename = @mname, lastname = @lname, emailAddress = @email, homeAddress = @hadd, birthDate = @bDate WHERE userID = @userID; UPDATE tbllogincredentials SET user_username = @username, user_password = @password WHERE userID = @userID;";
                int affectedRowCount = db.ExecuteNoReturnQuery(query,
                    new MySqlParameter("@fname", tbFname.Text),
                    new MySqlParameter("@mname", tbMname.Text),
                    new MySqlParameter("@lname", tbLname.Text),
                    new MySqlParameter("@email", tbEmailAdd.Text),
                    new MySqlParameter("@hadd", tbHomeAdd.Text),
                    new MySqlParameter("@bDate", dtpBirthDate.Value),
                    new MySqlParameter("@username", tbUsername.Text),
                    new MySqlParameter("@password", tbPassword.Text),
                    new MySqlParameter("@userID", dgvUsers.CurrentRow.Cells[0].Value)
                    );
                if (affectedRowCount > 0)
                {
                    MessageBox.Show("Data Updated!");
                    frmUsers_Load(null, null);
                    ClearFields();
                }
                isUpdate = false;
            }


        }


        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this account?", "Update Account", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    isUpdate = true;
                    int idUserInfo = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                    int idLoginCredentials = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    tbFname.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
                    tbMname.Text = dgvUsers.SelectedRows[0].Cells[3].Value.ToString();
                    tbLname.Text = dgvUsers.SelectedRows[0].Cells[4].Value.ToString();
                    tbEmailAdd.Text = dgvUsers.SelectedRows[0].Cells[5].Value.ToString();
                    tbHomeAdd.Text = dgvUsers.SelectedRows[0].Cells[6].Value.ToString();
                    dtpBirthDate.Value = Convert.ToDateTime(dgvUsers.SelectedRows[0].Cells[7].Value);
                    tbUsername.Text = dgvUsers.SelectedRows[0].Cells[8].Value.ToString();
                    tbPassword.Text = dgvUsers.SelectedRows[0].Cells[9].Value.ToString();

                }
            }
        }

        private void tbEmailAdd_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(tbEmailAdd.Text))
            {
                MessageBox.Show("Invalid email format.", "Validation");
                tbEmailAdd.Focus();
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this account?", "Account Deactivation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    string query = "UPDATE tbllogincredentials SET is_active = 0 where LoginID = @id";

                    int affectedRows = db.ExecuteNoReturnQuery(query,
                        new MySqlParameter("@id", id));
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Account is deactivated!");
                    }

                }
            }
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Password" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }
    }
}