using CrystalDecisions.CrystalReports.Engine;
using HostelManagementSystem.Views.ResidentListtems;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            txtUIN.Text = "";
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
                string query = @"SELECT TblRoomPrices.RoomPrice FROM TblRooms INNER JOIN TblRoomPrices
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId 
                                WHERE TblRooms.RoomId = '" + cboRoomId.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "roomPrice");
                txtRoomPrice.Text = ds.Tables["roomPrice"].Rows[0][0].ToString();
                txtRoomPrice.Enabled = false;
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
            FillDgResidents();
            txtResidentId.Enabled = false;
            txtRoomPrice.Enabled = false;
            UpdateBtn.Visible = false;
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
            txtResidentId.Enabled = false;
            CheckboxOccupy.Checked = true;
            CheckboxOccupy.Enabled = false;
            SaveBtn.Visible = true;
            ClearBtn.Visible = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var image = new ImageConverter().ConvertTo(ResidentPictureBox.Image, typeof(Byte[]));

                string query = @"INSERT INTO TblResidents VALUES (@ResidentId,@UIN, @Name, @RoomId, @Image,
                                @Address, @Phone, @StartDate, @Occupy, @Leave, @EndDate)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                cmd.Parameters.Add("@UIN", SqlDbType.VarChar).Value = txtUIN.Text;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtResidentName.Text;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = cboRoomId.SelectedValue;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtResidentAddress.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = txtResidentPhone.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate.Text;
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
                ExecuteMyQuery(RccCommand, "Add Room Capacity new Count for resident and Making Bill Process for this resident right now!");
                
                Clear();
                FillDgResidents();
                FillCboRoomId();
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
                string query = @"SELECT TblResidents.ResidentId as Id, TblResidents.UIN as SmartId, TblResidents.Name,TblResidents.RoomId As RoomNo, 
                                TblRoomPrices.RoomPrice, TblResidents.Image, TblResidents.Address, TblResidents.Phone,
                                TblResidents.StartDate, TblResidents.Occupy,TblResidents.Leave, TblResidents.EndDate
                                FROM TblResidents 
                                INNER JOIN TblRooms ON TblResidents.RoomId = TblRooms.RoomId 
                                INNER JOIN TblRoomPrices ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId
                                LEFT JOIN TblBanResidentHistory ON TblResidents.ResidentId = TblBanResidentHistory.ResidentId
                                WHERE TblBanResidentHistory.ResidentId IS NULL AND TblResidents.Leave != 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residents");
                dt = ds.Tables["residents"];
                dgResidentList.DataSource = dt;
                txtResidentCount.Text = ds.Tables["residents"].Rows.Count.ToString();

                dgResidentList.Columns[0].Width = 50;
                dgResidentList.Columns[1].Width = 80;
                dgResidentList.Columns[3].Width = 70;
                dgResidentList.Columns[4].Width = 90;
                dgResidentList.Columns[6].Width = 250;
                dgResidentList.Columns[9].Width = 70;
                dgResidentList.Columns[10].Width = 70;

                dgResidentList.RowTemplate.Height = 100;
                dgResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgResidentList.AllowUserToAddRows = false;
                //dgResidentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridViewImageColumn ImgCol = new DataGridViewImageColumn();
                ImgCol = (DataGridViewImageColumn)dgResidentList.Columns[5];
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
                cell.ReadOnly = true;
                dgResidentList.CancelEdit();
            }
        }

        private void dgResidentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtResidentId.Text = dgResidentList.CurrentRow.Cells[0].Value.ToString();
                txtResidentId.Enabled = false;
                txtUIN.Text = dgResidentList.CurrentRow.Cells[1].Value.ToString();
                txtResidentName.Text = dgResidentList.CurrentRow.Cells[2].Value.ToString();
                cboRoomId.Text = dgResidentList.CurrentRow.Cells[3].Value.ToString();
                txtRoomPrice.Text = dgResidentList.CurrentRow.Cells[4].Value.ToString();
                txtRoomPrice.Enabled = false;
                CheckboxOccupy.Enabled = false;
                CheckBoxLeave.Enabled = true;
                Byte[] ImageData = (Byte[])dgResidentList.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(ImageData);
                ResidentPictureBox.Image = Image.FromStream(ms);
                txtResidentAddress.Text = dgResidentList.CurrentRow.Cells[6].Value.ToString();
                txtResidentPhone.Text = dgResidentList.CurrentRow.Cells[7].Value.ToString();
                startDate.Text = dgResidentList.CurrentRow.Cells[8].Value.ToString();
                startDate.Enabled = false;
                CheckboxOccupy.Checked = Convert.ToBoolean(dgResidentList.CurrentRow.Cells[9].Value);
                CheckBoxLeave.Checked = Convert.ToBoolean(dgResidentList.CurrentRow.Cells[10].Value);
                if(CheckBoxLeave.Checked == true)
                {
                    CheckBoxLeave.Enabled = false;
                    CheckboxOccupy.Enabled = true;
                }
                endDate.Text = dgResidentList.CurrentRow.Cells[11].Value.ToString();
                endDate.Enabled = false;
                UpdateBtn.Visible = true;
            }
            catch
            {
                MessageBox.Show("Something wrong! Please reload this page.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckBoxLeave_CheckedChanged(object sender, EventArgs e)
        {
            Boolean isCheckedLeave = CheckBoxLeave.Checked;
            if (isCheckedLeave)
            {
                CheckboxOccupy.Checked = false;
                CheckBoxLeave.Enabled = false;                
                txtUIN.TabStop = false;
            }    
        }

        private void CheckboxOccupy_CheckedChanged(object sender, EventArgs e)
        {
            Boolean isCheckedOccupy = CheckboxOccupy.Checked;
            if (isCheckedOccupy)
            {
                CheckBoxLeave.Checked = false;
                CheckboxOccupy.Enabled = false;
            }
                
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var img = new ImageConverter().ConvertTo(ResidentPictureBox.Image, typeof(Byte[]));
            try
            {
                string query = "UPDATE TblResidents SET ResidentId = @ResidentId, UIN = @UIN, Name = @Name, RoomId = @RoomId, " +
                "Image = @Image, Address = @Address, Phone = @Phone, StartDate = @StartDate, Occupy = @Occupy, " +
                "Leave = @Leave, EndDate = @EndDate WHERE ResidentId = @ResidentId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                cmd.Parameters.Add("@UIN", SqlDbType.VarChar).Value = txtUIN.Text;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtResidentName.Text;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = cboRoomId.Text;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = img;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtResidentAddress.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = txtResidentPhone.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate.Text;

                cmd.Parameters.Add("@Occupy", SqlDbType.Bit).Value = CheckboxOccupy.Checked;
                cmd.Parameters.Add("@Leave", SqlDbType.Bit).Value = CheckBoxLeave.Checked;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate.Text;
                ExecuteMyQuery(cmd, "Resident was successfully updated.");
            }
            catch
            {
                MessageBox.Show("Someting wrong! Resident updating is fail!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //For Room Capacity Check
            try
            {
                string RId, RoomID;
                string RIdQuery = "SELECT ResidentId, RoomId FROM TblRoomCapacityCheck WHERE ResidentId = '" + txtResidentId.Text + "'";
                SqlDataAdapter ad = new SqlDataAdapter(RIdQuery, consql);
                DataSet dset = new DataSet();
                ad.Fill(dset, "residentDatas");
                if (dset.Tables["residentDatas"].Rows.Count == 0)
                {
                    int i = 1;
                    string RCCquery = "INSERT INTO TblRoomCapacityCheck VALUES (@CountCapacity, @RoomId, @ResidentId)";
                    SqlCommand RccCommand = new SqlCommand(RCCquery, consql);
                    RccCommand.Parameters.Add("@CountCapacity", SqlDbType.Int).Value = i;
                    RccCommand.Parameters.Add("RoomId", SqlDbType.VarChar).Value = cboRoomId.Text;
                    RccCommand.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                    //ExecuteMyQuery(RccCommand, "Add Room Capacity to new Count for resident");
                    RccCommand.ExecuteNonQuery();
                    MessageBox.Show("Add Room Capacity to new Count for resident.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RId = dset.Tables["residentDatas"].Rows[0][0].ToString();
                    RoomID = dset.Tables["residentDatas"].Rows[0][1].ToString();
                    if (CheckBoxLeave.Checked == true)
                    {
                        //Remove from Room Capacity Check

                        if (RId == txtResidentId.Text)
                        {
                            string RCCquery = "DELETE FROM TblRoomCapacityCheck WHERE ResidentId = @ResidentId";
                            SqlCommand RccCommand = new SqlCommand(RCCquery, consql);
                            RccCommand.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                            RccCommand.ExecuteNonQuery();
                            //ExecuteMyQuery(RccCommand, "Update Room Capacity new Count for leaving resident");
                            MessageBox.Show("Update Room Capacity new Count for leaving resident.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("This resident was removed from RoomCapacityCheck Table at early.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        //Adding to Room Capacity Check
                        if (RId != txtResidentId.Text)
                        {
                            int i = 1;
                            string RCCquery = "INSERT INTO TblRoomCapacityCheck VALUES (@CountCapacity, @RoomId, @ResidentId)";
                            SqlCommand RccCommand = new SqlCommand(RCCquery, consql);
                            RccCommand.Parameters.Add("@CountCapacity", SqlDbType.Int).Value = i;
                            RccCommand.Parameters.Add("RoomId", SqlDbType.VarChar).Value = cboRoomId.SelectedValue;
                            RccCommand.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                            //ExecuteMyQuery(RccCommand, "Add Room Capacity to new Count for resident");
                            RccCommand.ExecuteNonQuery();
                            MessageBox.Show("Add Room Capacity to new Count for resident.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(RoomID != cboRoomId.Text)
                        {
                            string RCCquery = "UPDATE TblRoomCapacityCheck SET RoomId = @RoomId WHERE ResidentId = @ResidentId";
                            SqlCommand RccCommand = new SqlCommand(RCCquery, consql);
                            RccCommand.Parameters.Add("RoomId", SqlDbType.VarChar).Value = cboRoomId.Text;
                            RccCommand.Parameters.Add("ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                            RccCommand.ExecuteNonQuery();
                            MessageBox.Show("Add new Room to new Capacity Count for resident.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("This resident was occupy RoomCapacityCheck Table at early.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FillCboRoomId();
            Clear();
            FillDgResidents();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            UpdateBtn.Visible = false;
        }

        private void BtnResidentLeave_Click(object sender, EventArgs e)
        {
            FrmResidentLeaveList frmResidentLeave = new FrmResidentLeaveList();
            frmResidentLeave.ShowDialog();
        }

        private void txtUIN_Leave(object sender, EventArgs e)
        {
            try
            {
                string uin, residentId, name, roomId, ban, leave, message;
                string query = @"SELECT TblResidents.ResidentId, TblResidents.UIN, TblResidents.Name, 
                                TblResidents.RoomId, TblResidents.Leave,TblBanResidentHistory.Ban
                                FROM TblResidents 
                                LEFT JOIN TblBanResidentHistory
                                ON TblResidents.ResidentId = TblBanResidentHistory.ResidentId
                                WHERE UIN = '" + txtUIN.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "residentUIN");
                if (ds.Tables["residentUIN"].Rows.Count > 0)
                {
                    residentId = ds.Tables["residentUIN"].Rows[0][0].ToString();
                    uin = ds.Tables["residentUIN"].Rows[0][1].ToString();
                    name = ds.Tables["residentUIN"].Rows[0][2].ToString();
                    roomId = ds.Tables["residentUIN"].Rows[0][3].ToString();
                    leave = ds.Tables["residentUIN"].Rows[0][4].ToString();
                    ban = ds.Tables["residentUIN"].Rows[0][5].ToString();
                    if (ban != "" && Convert.ToBoolean(ban) != false)
                    {
                        message =  "Smart Card ID " + uin + " - " + name + " was banned from this Hostel.";
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveBtn.Visible = false;
                        UpdateBtn.Visible = false;
                        ClearBtn.Visible = false;
                        Clear();
                    }
                    else
                    {
                        if (ban == "" && Convert.ToBoolean(leave) != true)
                        {
                            message = "Smart Card ID " + uin + " - " + name + " was registered this Hostel.";
                            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SaveBtn.Visible = false;
                            ClearBtn.Visible = false;
                            Clear();    
                        }
                        else
                        {
                            message = "Smart Card ID " + uin + " - " + name + " was Leave from this Hostel. Make register again!";
                            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string selectQuery = "SELECT * FROM TblResidents WHERE UIN = '"+uin+"' ORDER BY ResidentId DESC";
                            SqlDataAdapter selectAdapter = new SqlDataAdapter(selectQuery, consql);
                            DataSet selectDs = new DataSet();
                            selectAdapter.Fill(selectDs, "ResidentData");
                            txtUIN.Text = selectDs.Tables["ResidentData"].Rows[0][1].ToString();
                            txtResidentName.Text = selectDs.Tables["ResidentData"].Rows[0][2].ToString();
                            Byte[] ImageData = (Byte[])selectDs.Tables["ResidentData"].Rows[0][4];
                            MemoryStream ms = new MemoryStream(ImageData);
                            ResidentPictureBox.Image = Image.FromStream(ms);
                            txtResidentAddress.Text = selectDs.Tables["ResidentData"].Rows[0][5].ToString();
                            txtResidentPhone.Text = selectDs.Tables["ResidentData"].Rows[0][6].ToString();
                            CheckboxOccupy.Checked = true;
                            SaveBtn.Visible = true;                            
                            ClearBtn.Visible = true;
                        } 
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your page.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBanResident_Click(object sender, EventArgs e)
        {
            FrmBanResidentHistory frmBanResidentHistory = new FrmBanResidentHistory();
            frmBanResidentHistory.ShowDialog();
        }
    }
}



