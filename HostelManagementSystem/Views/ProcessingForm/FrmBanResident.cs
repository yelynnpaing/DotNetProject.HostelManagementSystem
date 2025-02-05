using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmBanResident : Form
    {
        public FrmBanResident()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            cboResidentUIN.Text = "";
            txtResidentId.Text = "";
            txtResidentName.Text = "";
            txtRoomId.Text = "";
            txtResidentPhone.Text = "";

            cboResidentUIN.Enabled = true;
            txtResidentId.Enabled = true;
            txtResidentName.Enabled = true;
            txtRoomId.Enabled = true;
            txtResidentPhone.Enabled = true;
            UpdateBtn.Visible = false;
        }

        private void FrmBanResidentList_Load(object sender, EventArgs e)
        {
            Connection();
            BanDate.Value = DateTime.Now;
            BanDate.Enabled = false;
            FillCboResidentId();
            Clear();
            UnBanCheckBox.Enabled = false;
            FillCboRulesAndRegulations();
            FillDgBanResidentList();
        }

        private void FillCboResidentId()
        {
            string query = @"SELECT TblResidents.UIN, TblResidents.ResidentId, TblResidents.Name, TblResidents.RoomId, TblResidents.Phone
                                FROM TblResidents
                                INNER JOIN TblRoomCapacityCheck
                                ON TblResidents.ResidentId = TblRoomCapacityCheck.ResidentId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "residents");
            DataTable dt = new DataTable();
            dt = ds.Tables["residents"];
            cboResidentUIN.DataSource = dt;
            cboResidentUIN.DisplayMember = dt.Columns["UIN"].ToString();
            cboResidentUIN.ValueMember = dt.Columns["ResidentId"].ToString();
        }

        
        private void cboResidentUIN_Leave(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ResidentId, Name, RoomId, Phone FROM TblResidents WHERE UIN = '" + cboResidentUIN.Text + "';";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "residentData");
                txtResidentId.Text = ds.Tables["residentData"].Rows[0][0].ToString();
                txtResidentName.Text = ds.Tables["residentData"].Rows[0][1].ToString();
                txtRoomId.Text = ds.Tables["residentData"].Rows[0][2].ToString();
                txtResidentPhone.Text = ds.Tables["residentData"].Rows[0][3].ToString();
                cboResidentUIN.Enabled = false;
                txtResidentId.Enabled = false;
                txtResidentName.Enabled = false;
                txtRoomId.Enabled = false;
                txtResidentPhone.Enabled = false;
                BanCheckBox.Checked = true;
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FillCboRulesAndRegulations()
        {
            try
            {
                string query = "SELECT RRId, Title FROM TblRulesAndRegulations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable(); 
                adapter.Fill(ds, "cboRulesAndRegulations");
                dt = ds.Tables["cboRulesAndRegulations"];
                cboRulesAndRegulations.DataSource = dt;
                cboRulesAndRegulations.DisplayMember = dt.Columns["Title"].ToString();
                cboRulesAndRegulations.ValueMember = dt.Columns["RRId"].ToString();
            }
            catch
            {
                MessageBox.Show("There is nothing to show rules and regulations! Please reload your page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Id;
                string query = @"INSERT INTO TblBanResidents VALUES (@ResidentId, @RoomId, @BanDate, @RRID, @Ban, @UnBan)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = cboResidentUIN.SelectedValue;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@BanDate", SqlDbType.DateTime).Value = BanDate.Text;
                cmd.Parameters.Add("@RRID", SqlDbType.Int).Value = cboRulesAndRegulations.SelectedValue;
                cmd.Parameters.Add("@Ban", SqlDbType.Bit).Value = BanCheckBox.Checked;
                cmd.Parameters.Add("@UnBan", SqlDbType.Bit).Value = UnBanCheckBox.Checked;
                ExecuteMyQuery(cmd, "Resident banned successfully!");
                FillDgBanResidentList();

                //For Ban Residents History
                if (UnBanCheckBox.Checked == false)
                {
                    string HQuery = @"INSERT INTO TblBanResidentHistory VALUES (@ResidentId, @RoomId, @BanDate, @RRID, @Ban)";
                    SqlCommand Hcmd = new SqlCommand(HQuery, consql);
                    Hcmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = cboResidentUIN.SelectedValue;
                    Hcmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                    Hcmd.Parameters.Add("@BanDate", SqlDbType.DateTime).Value = BanDate.Text;
                    Hcmd.Parameters.Add("@RRID", SqlDbType.Int).Value = cboRulesAndRegulations.SelectedValue;
                    Hcmd.Parameters.Add("@Ban", SqlDbType.Bit).Value = BanCheckBox.Checked;
                    ExecuteMyQuery(Hcmd, "Ban Resident was successfully added to history!");
                }

                //For RoomCapacity Check Ban residents
                string IdQuery = @"SELECT TblRoomCapacityCheck.ResidentId FROM TblRoomCapacityCheck
                                INNER JOIN TblBanResidents
                                ON TblRoomCapacityCheck.ResidentId = TblBanResidents.ResidentId;";
                SqlDataAdapter adapter = new SqlDataAdapter(IdQuery, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "id");
                if (ds.Tables["id"].Rows.Count > 0)
                {
                    Id = ds.Tables["id"].Rows[0][0].ToString();
                    string subQuery = "DELETE FROM TblRoomCapacityCheck WHERE ResidentId = @ResidentId";
                    SqlCommand subCmd = new SqlCommand(subQuery, consql);
                    subCmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = Id;
                    subCmd.ExecuteNonQuery();
                    MessageBox.Show("Update Room Capacity new Count for banning resident.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This resident was removed from RoomCapacityCheck Table at early.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Clear();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Fail Banning resident!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExecuteMyQuery(SqlCommand cmd, string message)
        {
            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Boolean isBanCheckBox = BanCheckBox.Checked;
            if (isBanCheckBox)
            {
                UnBanCheckBox.Checked = false;
                UnBanCheckBox.Enabled = false;
                BanCheckBox.Enabled = false;
            }
        }

        private void UnBanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Boolean isUnBanCheckBox = UnBanCheckBox.Checked;
            if (isUnBanCheckBox)
            {
                BanCheckBox.Checked = false;
                BanCheckBox.Enabled = true;
                UnBanCheckBox.Enabled = false;
            }
        }

        private void FillDgBanResidentList()
        {
            try
            {
                string query = @"SELECT TblResidents.UIN, TblResidents.ResidentId, TblResidents.Name, TblBanResidents.RoomId As RoomNo, 
                                    TblResidents.Phone,TblBanResidents.BanDate, TblRulesAndRegulations.Title AS BanReason,
                                    TblBanResidents.Ban, TblBanResidents.UnBan
                                    FROM TblBanResidents
                                    INNER JOIN TblResidents
                                    ON TblResidents.ResidentId = TblBanResidents.ResidentId
                                    INNER JOIN TblRulesAndRegulations
                                    ON TblBanResidents.RRID = TblRulesAndRegulations.RRId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "banResidents");
                dgBanResidentList.DataSource = ds.Tables["banResidents"];
                txtResidentCount.Text = ds.Tables["banResidents"].Rows.Count.ToString();
                dgBanResidentList.AllowUserToAddRows = false;
                dgBanResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgBanResidentList.RowTemplate.Height = 50;
            }
            catch
            {
                MessageBox.Show("There is no resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgBanResidentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBanResidentList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgBanResidentList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //bool isChecked = Convert.ToBoolean(cell.Value);
                cell.ReadOnly = true;
                dgBanResidentList.CancelEdit();
            }
        }

        private void dgBanResidentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboResidentUIN.Text = dgBanResidentList.CurrentRow.Cells[0].Value.ToString();
                txtResidentId.Text = dgBanResidentList.CurrentRow.Cells[1].Value.ToString();
                txtResidentName.Text = dgBanResidentList.CurrentRow.Cells[2].Value.ToString();
                txtRoomId.Text = dgBanResidentList.CurrentRow.Cells[3].Value.ToString();
                txtResidentPhone.Text = dgBanResidentList.CurrentRow.Cells[4].Value.ToString();
                BanDate.Text = dgBanResidentList.CurrentRow.Cells[5].Value.ToString();
                cboRulesAndRegulations.Text = dgBanResidentList.CurrentRow.Cells[6].Value.ToString();
                BanCheckBox.Checked = Convert.ToBoolean(dgBanResidentList.CurrentRow.Cells[7].Value.ToString());
                UnBanCheckBox.Checked = Convert.ToBoolean(dgBanResidentList.CurrentRow.Cells[8].Value.ToString());
                if(BanCheckBox.Checked == true)
                {
                    BanCheckBox.Enabled = false;
                    UnBanCheckBox.Enabled = true;
                }
                cboResidentUIN.Enabled = false;
                txtResidentId.Enabled = false;
                txtResidentName.Enabled = false;
                txtRoomId.Enabled = false;
                txtResidentPhone.Enabled = false;
                BanDate.Enabled = false;
                UpdateBtn.Visible = true;
            }
            catch
            {
                MessageBox.Show("Someting wrong! Please reload this page.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE TblBanResidents SET ResidentId=@ResidentId, RoomId=@RoomId, BanDate=@BanDate,
                                RRID=@RRID, Ban=@Ban, UnBan=@UnBan
                                WHERE ResidentId = @ResidentId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = txtResidentId.Text;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@BanDate", SqlDbType.DateTime).Value = BanDate.Text;                
                cmd.Parameters.Add("@RRID", SqlDbType.Int).Value = cboRulesAndRegulations.SelectedValue;
                cmd.Parameters.Add("@Ban", SqlDbType.Bit).Value = BanCheckBox.Checked;
                cmd.Parameters.Add("@UnBan", SqlDbType.Bit).Value = UnBanCheckBox.Checked;
                ExecuteMyQuery(cmd, "Updating successful Banned Resident!");
                Clear();
                FillDgBanResidentList();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Update Banned resident!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
