using HostelManagementSystem;
using HostelManagementSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin instance;
        public string UserRole;
        public FrmLogin()
        {
            InitializeComponent();
            instance = this;
        }

        SqlConnection consql;
        string str;

        void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123";
            consql = new SqlConnection(str);
            consql.Open();
        }

        void Clear()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName, password, userRole1 = "admin", userRole2 = "staff";
            userName = txtUserName.Text;
            password = txtPassword.Text;

            try
            {
                if (String.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Fill user name into user name field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Fill password into password field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string query = "SELECT * FROM TblUsers WHERE UserName='" + userName + "' AND UserPassword= '" + password + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet dset = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(dset, "Users");
                dt = dset.Tables["Users"];
                string name = dset.Tables["Users"].Rows[0][1].ToString();
                string pw = dset.Tables["Users"].Rows[0][2].ToString();
                string role = dset.Tables["Users"].Rows[0][3].ToString();

                UserRole = role;

                if (dt.Rows.Count > 0)
                {
                    if (userName == name && password == pw && (userRole1 == role || userRole2 == role))
                    {
                        FrmDashboard frmDashboard = new FrmDashboard();
                        frmDashboard.Show();
                    }
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("User Does not exit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                consql.Close();
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void labelReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
