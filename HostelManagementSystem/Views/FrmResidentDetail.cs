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

namespace HostelManagementSystem.Views
{
    public partial class FrmResidentDetail : Form
    {
        public FrmResidentDetail()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;
        DataSet Dset;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            txtResidentId.Text = "";
            txtResidentName.Text = "";
            cboRoomId.Text = "";
            txtRoomPrice.Text = "";
            ResidentPictureBox.Image = null;
            txtResidentAddress.Text = "";
            txtResidentPhone.Text = "";
        }

        private void AutoId()
        {
            string ResName;
            int ResID;

            string query = "SELECT ResidentId FROM TblResidents ORDER BY ResidentId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "residents");

            if (Dset.Tables["residents"].Rows.Count > 0)
            {
                ResName = Dset.Tables["residents"].Rows[Dset.Tables["residents"].Rows.Count - 1][0].ToString();
                ResID = int.Parse(ResName.Substring(1, (ResName.Length - 1)));
                txtResidentId.Text = "P" + (ResID + 1).ToString("000");
            }
            else
            {
                txtResidentId.Text = "P001";
            }
        }

        private void FillCboRoomId()
        {
            string query = @"SELECT TblRooms.RoomId
                            FROM TblRooms
                            INNER JOIN TblRoomCapacity 
                                ON TblRooms.RoomId = TblRoomCapacity.RoomId
                            LEFT JOIN TblRoomCapacityCheck
                                ON TblRoomCapacity.RoomId = TblRoomCapacityCheck.RoomId 
                            GROUP BY TblRooms.RoomId, TblRoomCapacity.Capacity
                            HAVING TblRoomCapacity.Capacity > COALESCE(SUM(TblRoomCapacityCheck.CountCapacity), 0);";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(ds, "roomId");
            dt = ds.Tables["roomId"];
            cboRoomId.DataSource = dt;
            cboRoomId.DisplayMember = dt.Columns["RoomId"].ToString();
            cboRoomId.ValueMember = dt.Columns["RoomId"].ToString();
        }

        private void cboRoomId_Leave(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT TblRoomPrices.RoomPrice FROM TblRooms INNER JOIN TblRoomPrices " +
                    "ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId WHERE TblRooms.RoomId = '" + cboRoomId.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "roomPrice");
                txtRoomPrice.Text = ds.Tables["roomPrice"].Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Please select RoomId", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmResidentDetail_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboRoomId();
            startDate.MinDate = DateTime.Now;
            endDate.MinDate = DateTime.Now;
            FillDgResidents();
        }

        private void SelectImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Select Image";
            OFD.Filter = "Choose Image(*.JPG; *.JPEG; *.PNG) | *.jpg; *.jpeg; *.png";
            if(OFD.ShowDialog() == DialogResult.OK)
            {
                ResidentPictureBox.Load(OFD.FileName);
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            Clear();
            AutoId();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var image = new ImageConverter().ConvertTo(ResidentPictureBox.Image, typeof(Byte[]));

                string query = "INSERT INTO TblResidents VALUES (@ResidentId, @Name, @RoomId, @Image, " +
                    "@Address, @Phone, @StartDate, @Occupy, @Leave, @EndDate)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtResidentName.Text;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = cboRoomId.SelectedValue;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtResidentAddress.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = txtResidentPhone.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate.Value;
                cmd.Parameters.Add("@Occupy", SqlDbType.Bit).Value = CheckboxOccupy.Checked;
                cmd.Parameters.Add("@Leave", SqlDbType.Bit).Value = CheckBoxLeave.Checked;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate.Text;

                ExecuteMyQuery(cmd, "New resident creating is success!");

                //For Room Capacity Check
                int i = 1;
                string RCCquery = "INSERT INTO TblRoomCapacityCheck VALUES (@CountCapacity, @RoomId, @ResidentId)";
                SqlCommand RccCommand = new SqlCommand(RCCquery, consql);
                RccCommand.Parameters.Add("@CountCapacity", SqlDbType.Int).Value = i;
                RccCommand.Parameters.Add("RoomId", SqlDbType.VarChar).Value = cboRoomId.SelectedValue;
                RccCommand.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                ExecuteMyQuery(RccCommand, "Add Room Capacity new Count for resident");

                Clear();
                FillDgResidents();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please retry!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExecuteMyQuery(SqlCommand cmd, string message)
        {
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDgResidents()
        {
            try
            {
                string query = "SELECT TblResidents.ResidentId as Id, TblResidents.Name,TblResidents.RoomId, TblRoomPrices.RoomPrice," +
                " TblResidents.Image, TblResidents.Address, TblResidents.Phone,TblResidents.StartDate, TblResidents.Occupy, " +
                "TblResidents.Leave, TblResidents.EndDate FROM TblResidents INNER JOIN TblRooms " +
                "ON TblResidents.RoomId = TblRooms.RoomId INNER JOIN TblRoomPrices " +
                "ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residents");
                dt = ds.Tables["residents"];
                dgResidentList.DataSource = dt;

                dgResidentList.Columns[0].Width = 50;
                dgResidentList.Columns[2].Width = 70;
                dgResidentList.Columns[3].Width = 90;
                dgResidentList.Columns[5].Width = 300;

                dgResidentList.RowTemplate.Height = 100;
                dgResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgResidentList.AllowUserToAddRows = false;
                //dgResidentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridViewImageColumn ImgCol = new DataGridViewImageColumn();
                ImgCol = (DataGridViewImageColumn)dgResidentList.Columns[4];
                ImgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            catch
            {
                MessageBox.Show("There is no resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgResidentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResidentList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgResidentList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool isChecked = Convert.ToBoolean(cell.Value);
                if (isChecked == false)
                {
                    DialogResult result = MessageBox.Show("Are you sure ? you want to make this resident to leave from this room!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        cell.Value = true;
                        CheckboxOccupy.Checked = false;
                    }
                    else
                    {
                        cell.ReadOnly = true;
                        dgResidentList.CancelEdit();
                    }
                }
                else
                {
                    cell.ReadOnly = true;
                    dgResidentList.CancelEdit();
                }
            }
        }
    }
}



