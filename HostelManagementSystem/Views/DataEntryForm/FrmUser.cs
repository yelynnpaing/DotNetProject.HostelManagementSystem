using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views.DataEntryForm
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();

            var cbi1 = new ComboBoxItem(Name = "admin") { Id = 1};
            var cbi2 = new ComboBoxItem(Name = "staff") { Id = 2};
            cboUserRole.Items.Add(cbi1);
            cboUserRole.Items.Add(cbi2);
        }        

        SqlConnection consql;
        string str;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;Connection Timeout=3600";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            txtUserId.Text = "";
            txtUserName.Text = "";
            txtUserPassword.Text = "";
            txtConfirmPassword.Text = "";
            cboUserRole.Text = "";
            txtUserName.Focus();
            UpdateBtn.Visible = false;
            DeleteBtn.Visible = false;
            SaveBtn.Visible = true;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillDgUserData();
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtUserPassword.Text)
            {
                MessageBox.Show("Confirm Password doesn't match password. Please type again!");
                txtConfirmPassword.Clear();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO TblUsers VALUES (@UserName, @UserPassword, @UerRole)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
                cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = txtUserPassword.Text;
                cmd.Parameters.Add("@UerRole", SqlDbType.VarChar).Value = cboUserRole.SelectedItem.ToString();
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Fill UserName field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtUserPassword.Text))
                {
                    MessageBox.Show("Fill UserPassword field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(cboUserRole.Text))
                {
                    MessageBox.Show("Select User Role field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtUserPassword.Text) && !string.IsNullOrEmpty(cboUserRole.Text))
                {
                    ExecuteMyQuery(cmd, "New User Adding is success.");
                }
                FillDgUserData();
                Clear();
            }
            catch
            {
                MessageBox.Show("Something wrongs! check for creating room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExecuteMyQuery(SqlCommand Command, string Message)
        {

            if (Command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDgUserData()
        {
            try
            {
                string query = @"SELECT * FROM TblUsers ORDER BY UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet Dset = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(Dset, "Users");
                dt = Dset.Tables["Users"];
                dgUserList.DataSource = dt;
                txtUserListCount.Text = Dset.Tables["Users"].Rows.Count.ToString();

                dgUserList.RowTemplate.Height = 100;
                dgUserList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgUserList.AllowUserToAddRows = false;
            }
            catch
            {
                MessageBox.Show("There is no users to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = dgUserList.CurrentRow.Cells[1].Value.ToString();
            txtUserPassword.Text = dgUserList.CurrentRow.Cells[2].Value.ToString();
            cboUserRole.Text = dgUserList.CurrentRow.Cells[3].Value.ToString();
            txtUserId.Text = dgUserList.CurrentRow.Cells[0].Value.ToString();
            UpdateBtn.Visible = true;
            DeleteBtn.Visible = true;
            SaveBtn.Visible = false;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE TblUsers SET UserName = @UserName, UserPassword = @UserPassword,
                                    UserRole = @UserRole
                                    WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@UserPassword", txtUserPassword.Text);
                cmd.Parameters.AddWithValue("@UserRole", cboUserRole.Text);
                cmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Fill UserName field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtUserPassword.Text))
                {
                    MessageBox.Show("Fill UserPassword field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(cboUserRole.Text))
                {
                    MessageBox.Show("Select User Role field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtUserPassword.Text) && !string.IsNullOrEmpty(cboUserRole.Text))
                {
                    ExecuteMyQuery(cmd, "Data Updating is success.");
                }

                Clear();
                FillDgUserData();
            }
            catch
            {
                MessageBox.Show("Data updating fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM TblUsers WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
                ExecuteMyQuery(cmd, "User Deleting is success.!");
                Clear();
                FillDgUserData();
            }
            catch
            {
                MessageBox.Show("Select row to delete. If you cannot select the row, you can't use delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


    public class ComboBoxItem
    {
        private readonly string text;
        public int Id { get; set; }
        public ComboBoxItem(string text)
        {
            this.text = text;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
