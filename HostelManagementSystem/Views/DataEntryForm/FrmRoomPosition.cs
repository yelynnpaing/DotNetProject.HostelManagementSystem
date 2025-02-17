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
    public partial class FrmRoomPosition : Form
    {
        public FrmRoomPosition()
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
            txtRoomPosition.Text = "";
            txtRoomPosition.Focus();
            UpdateBtn.Visible = false;
            DeleteBtn.Visible = false;
            SaveBtn.Visible = true;
        }

        private void FrmRoomPosition_Load(object sender, EventArgs e)
        {
            Connection();
            Clear();
            FillDgRoomPositionListData();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO TblRoomPositions (RoomPosition) VALUES (@RoomPosition)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@RoomPosition", SqlDbType.NVarChar).Value = txtRoomPosition.Text;
                if (string.IsNullOrEmpty(txtRoomPosition.Text))
                {
                    MessageBox.Show("Fill text into RoomPosition field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtRoomPosition.Text))
                {
                    ExecuteMyQuery(cmd, "Adding new RoomPosition is success.");
                }
                Clear();
                FillDgRoomPositionListData();
            }
            catch
            {
                MessageBox.Show("Data saving fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillDgRoomPositionListData()
        {
            try
            {
                string query = "SELECT * FROM TblRoomPositions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "RoomTypeList");
                dgRoomPositionList.DataSource = ds.Tables["RoomTypeList"];
                txtRoomPositionCount.Text = ds.Tables["RoomTypeList"].Rows.Count.ToString();
                dgRoomPositionList.RowTemplate.Height = 70;
                dgRoomPositionList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgRoomPositionList.AllowUserToAddRows = false;
                dgRoomPositionList.Columns[0].Width = 170;
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

        private void dgRoomPositionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomPositionId.Text = dgRoomPositionList.CurrentRow.Cells[0].Value.ToString();
            txtRoomPosition.Text = dgRoomPositionList.CurrentRow.Cells[1].Value.ToString();
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
                string query = @"UPDATE TblRoomPositions SET RoomPosition = @RoomPosition 
                                WHERE RoomPositionId = @RoomPositionId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@RoomPosition", txtRoomPosition.Text.ToString());
                cmd.Parameters.AddWithValue("@RoomPositionId", txtRoomPositionId.Text.ToString());
                if (string.IsNullOrEmpty(txtRoomPosition.Text))
                {
                    MessageBox.Show("Fill text into RoomType field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtRoomPosition.Text))
                {
                    ExecuteMyQuery(cmd, "Update Successful.!");
                }

                Clear();
                FillDgRoomPositionListData();
            }
            catch
            {
                MessageBox.Show("Data updating fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM TblRoomPositions WHERE RoomPositionId = @RoomPositionId";
            SqlCommand cmd = new SqlCommand(query, consql);
            cmd.Parameters.AddWithValue("@RoomPositionId", txtRoomPositionId.Text.ToString());            
            ExecuteMyQuery(cmd, "Deleting is success.!");
            Clear();
            FillDgRoomPositionListData();
        }
    }
}
