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
        public FrmLogin()
        {
            InitializeComponent();
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
            string userName, password;
            userName = txtUserName.Text;
            password = txtPassword.Text;

            try
            {
                string query = "SELECT * FROM TblUsers WHERE UserName='" + userName + "' AND UserPassword= '" + password + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet dset = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(dset, "Users");
                dt = dset.Tables["Users"];

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Success.");
                    if(userName == "admin" && password == "admin123")
                    {
                        FrmDashboard frmDashboard = new FrmDashboard();
                        frmDashboard.Show();
                    }
                    else
                    {
                        FrmUserDashboard frmUserDashboard = new FrmUserDashboard();
                        frmUserDashboard.Show();
                    }
                    

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
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
