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

namespace HostelManagementSystem.Views.DataEntryForm
{
    public partial class FrmRoomType : Form
    {
        public FrmRoomType()
        {
            InitializeComponent();
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
            txtRoomType.Text = ""; 
            txtRoomType.Focus();
            UpdateBtn.Visible = false;
            DeleteBtn.Visible = false;
            SaveBtn.Visible = true;
        }

        private void FrmRoomType_Load(object sender, EventArgs e)
        {
            Connection();
            Clear();
            FillDgRoomTypeListData();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO TblRoomTypes (RoomType) VALUES (@RoomType)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar).Value = txtRoomType.Text;                
                if (string.IsNullOrEmpty(txtRoomType.Text))
                {
                    MessageBox.Show("Fill text into RoomType field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
                if (!string.IsNullOrEmpty(txtRoomType.Text))
                {
                    ExecuteMyQuery(cmd, "Adding new RoomType is success.");
                }
                Clear();
                FillDgRoomTypeListData();
            }
            catch
            {
                MessageBox.Show("Data saving fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillDgRoomTypeListData()
        {
            try
            {
                string query = "SELECT * FROM TblRoomTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "RoomTypeList");
                dgRoomTypeList.DataSource = ds.Tables["RoomTypeList"];
                txtRoomTypeCount.Text = ds.Tables["RoomTypeList"].Rows.Count.ToString();
                dgRoomTypeList.Columns["RoomTypeId"].Visible = false;
                dgRoomTypeList.RowTemplate.Height = 70;
                dgRoomTypeList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgRoomTypeList.AllowUserToAddRows = false;
                dgRoomTypeList.Columns[0].Width = 170;
            }
            catch
            {
                MessageBox.Show("There is no data to show!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExecuteMyQuery(SqlCommand cmd, String message)
        {
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute. Check Query.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgRoomTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomTypeId.Text = dgRoomTypeList.CurrentRow.Cells[0].Value.ToString();
            txtRoomType.Text = dgRoomTypeList.CurrentRow.Cells[1].Value.ToString();
            UpdateBtn.Visible = true;
            DeleteBtn.Visible = true;
            SaveBtn.Visible = false;
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE TblRoomTypes SET RoomType = @RoomType WHERE RoomTypeId = @RoomTypeId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@RoomType", txtRoomType.Text.ToString());                
                cmd.Parameters.AddWithValue("@RoomTypeId", txtRoomTypeId.Text.ToString());
                if (string.IsNullOrEmpty(txtRoomType.Text))
                {
                    MessageBox.Show("Fill text into RoomType field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtRoomType.Text))
                {
                    ExecuteMyQuery(cmd, "Update Successful.!");
                }

                Clear();
                FillDgRoomTypeListData();
            }
            catch
            {
                MessageBox.Show("Data updating fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM TblRoomTypes WHERE RoomTypeId = @RoomTypeId";
            SqlCommand cmd = new SqlCommand(query, consql);
            cmd.Parameters.AddWithValue("@RoomTypeId", txtRoomTypeId.Text.ToString());
            ExecuteMyQuery(cmd, "Deleting is success.!");
            Clear();
            FillDgRoomTypeListData();
        }
    }
}
