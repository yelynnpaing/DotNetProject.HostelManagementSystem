using Org.BouncyCastle.Asn1;
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
    public partial class FrmRoomPrice : Form
    {
        public FrmRoomPrice()
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
            cboRoomType.Text = "";
            cboRoomPosition.Text = "";
            txtRoomPrice.Text = "";
            cboRoomType.Focus();
            UpdateBtn.Visible = false;
            DeleteBtn.Visible = false;
            SaveBtn.Visible = true;
        }

        private void FillCboRoomType()
        {
            string query = "SELECT RoomTypeId, RoomType FROM TblRoomTypes ORDER BY RoomTypeId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(dataSet, "cboRoomTypes");
            dt = dataSet.Tables["cboRoomTypes"];
            cboRoomType.DataSource = dt;
            cboRoomType.DisplayMember = dt.Columns["RoomType"].ToString();
            cboRoomType.ValueMember = dt.Columns["RoomTypeId"].ToString();
        }

        private void FillCboRoomPosition()
        {
            string query = "SELECT RoomPositionId, RoomPosition FROM TblRoomPositions ORDER BY RoomPositionId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(dataSet, "cboRoomPositions");
            dt = dataSet.Tables["cboRoomPositions"];
            cboRoomPosition.DataSource = dt;
            cboRoomPosition.DisplayMember = dt.Columns["RoomPosition"].ToString();
            cboRoomPosition.ValueMember = dt.Columns["RoomPositionId"].ToString();
        }

        private void FrmRoomPrice_Load(object sender, EventArgs e)
        {
            Connection();
            Clear();
            FillCboRoomType();
            FillCboRoomPosition();
            FilldgRoomPriceData();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO TblRoomPrices VALUES (@RoomTypeId, @RoomPositionId, @RoomPrice)";
                SqlCommand cmd = new SqlCommand(query, consql);
                //Check Room Price is already exist
                foreach(DataGridViewRow dr in dgRoomPriceList.Rows)
                {
                    if (dr.Cells["RoomType"].Value.ToString() != cboRoomType.Text && dr.Cells["RoomPosition"].Value.ToString() != cboRoomPosition.Text)
                    {
                        cmd.Parameters.Add("@RoomTypeId", SqlDbType.Int).Value = cboRoomType.SelectedValue;
                        cmd.Parameters.Add("@RoomPositionId", SqlDbType.Int).Value = cboRoomPosition.SelectedValue;
                        cmd.Parameters.Add("@RoomPrice", SqlDbType.Decimal).Value = txtRoomPrice.Text;
                        if (string.IsNullOrEmpty(cboRoomType.Text))
                        {
                            MessageBox.Show("Select RoomType into RoomType field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (string.IsNullOrEmpty(cboRoomPosition.Text))
                        {
                            MessageBox.Show("Select RoomPosition into RoomPosition field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (string.IsNullOrEmpty(txtRoomPrice.Text))
                        {
                            MessageBox.Show("Fill Room Price in RoomPrice field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (!string.IsNullOrEmpty(cboRoomPosition.Text) && !string.IsNullOrEmpty(cboRoomPosition.Text) && !string.IsNullOrEmpty(txtRoomPrice.Text))
                        {
                            ExecuteMyQuery(cmd, "Adding new RoomType is success.");
                        }
                        FilldgRoomPriceData();
                    }
                    else
                    {
                        MessageBox.Show("This room type and room position for Price is already taken. Please choose another another room type and position!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
                
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

        private void FilldgRoomPriceData()
        {
            try
            {
                string query = @"SELECT TblRoomPrices.RoomPriceId, TblRoomTypes.RoomType, TblRoomPositions.RoomPosition, TblRoomPrices.RoomPrice 
                                    FROM TblRoomPrices
                                    INNER JOIN TblRoomTypes
                                    ON TblRoomPrices.RoomTypeId = TblRoomTypes.RoomTypeId
                                    INNER JOIN TblRoomPositions
                                    ON TblRoomPrices.RoomPositionId = TblRoomPositions.RoomPositionId 
                                    ORDER BY RoomPriceId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet Dset = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(Dset, "RoomPrice");
                dt = Dset.Tables["RoomPrice"];
                dgRoomPriceList.DataSource = dt;
                txtRoomPriceCount.Text = Dset.Tables["RoomPrice"].Rows.Count.ToString();
                dgRoomPriceList.Columns["RoomPriceId"].Visible = false;
                dgRoomPriceList.RowTemplate.Height = 100;
                dgRoomPriceList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgRoomPriceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgRoomPriceList.AllowUserToAddRows = false;
            }
            catch
            {
                MessageBox.Show("There is no room to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgRoomPriceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomPriceId.Text = dgRoomPriceList.CurrentRow.Cells[0].Value.ToString();
            cboRoomType.Text = dgRoomPriceList.CurrentRow.Cells[1].Value.ToString();
            cboRoomPosition.Text = dgRoomPriceList.CurrentRow.Cells[2].Value.ToString();
            txtRoomPrice.Text = dgRoomPriceList.CurrentRow.Cells[3].Value.ToString();
            UpdateBtn.Visible = true;
            DeleteBtn.Visible = true;
            SaveBtn.Visible = false;
        }

         private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE TblRoomPrices SET RoomTypeId = @RoomTypeId, RoomPositionId = @RoomPositionId,
                                    RoomPrice = @RoomPrice
                                    WHERE RoomPriceId = @RoomPriceId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@RoomTypeId", cboRoomType.SelectedValue);
                cmd.Parameters.AddWithValue("@RoomPositionId", cboRoomPosition.SelectedValue);
                cmd.Parameters.AddWithValue("@RoomPrice", txtRoomPrice.Text.ToString());
                cmd.Parameters.AddWithValue("@RoomPriceId", txtRoomPriceId.Text.ToString());
                if (string.IsNullOrEmpty(cboRoomType.Text))
                {
                    MessageBox.Show("Select RoomType into RoomType field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(cboRoomPosition.Text))
                {
                    MessageBox.Show("Select RoomPosition into RoomPosition field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtRoomPrice.Text))
                {
                    MessageBox.Show("Fill Room Price in RoomPrice field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(cboRoomPosition.Text) && !string.IsNullOrEmpty(cboRoomPosition.Text) && !string.IsNullOrEmpty(txtRoomPrice.Text))
                {
                    ExecuteMyQuery(cmd, "Updating is success.");
                }

                Clear();
                FilldgRoomPriceData();
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
                string query = "DELETE FROM TblRoomPrices WHERE RoomPriceId = @RoomPriceId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@RoomPriceId", txtRoomPriceId.Text.ToString());                
                ExecuteMyQuery(cmd, "Deleting is success.!");
                Clear();
                FilldgRoomPriceData();
            }
            catch
            {
                MessageBox.Show("Select row to delete. If you cannot select the row, you can't use delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
