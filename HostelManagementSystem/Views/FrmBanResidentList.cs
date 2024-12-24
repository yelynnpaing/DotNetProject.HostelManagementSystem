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
    public partial class FrmBanResidentList : Form
    {
        public FrmBanResidentList()
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
            txtRoomId.Text = "";
            txtResidentId.Text = "";
            txtResidentName.Text = "";
            cboResidentUIN.Text = "";
            txtResidentPhone.Text = "";
        }

        private void FrmBanResidentList_Load(object sender, EventArgs e)
        {
            Connection();
            BanDate.Value = DateTime.Now;
            BanDate.Enabled = false;
            startDate.MinDate = DateTime.Now;
            endDate.MinDate = DateTime.Now.AddDays(1);
            FillCboResidentId();
            Clear();
            UnBanCheckBox.Enabled = false;
        }

        private void FillCboResidentId()
        {
            string query = "SELECT ResidentId, UIN, Name, RoomId, Phone FROM TblResidents ORDER BY ResidentId";
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
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Id;
                string query = @"INSERT INTO TblBanResidents VALUES (@ResidentId, @RoomId, @BanDate, @startDate, 
                                @endDate, @Ban, @UnBan)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = cboResidentUIN.SelectedValue;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@BanDate", SqlDbType.DateTime).Value = BanDate.Text;
                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate.Text;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate.Text;
                cmd.Parameters.Add("@Ban", SqlDbType.Bit).Value = BanCheckBox.Checked;
                cmd.Parameters.Add("@UnBan", SqlDbType.Bit).Value = UnBanCheckBox.Checked;
                ExecuteMyQuery(cmd, "Resident banned successfully!");

                //For Ban Residents History
                if (UnBanCheckBox.Checked == false)
                {
                    string HQuery = @"INSERT INTO TblBanResidentHistory VALUES (@ResidentId, @RoomId, @BanDate, @startDate, 
                                @endDate, @Ban)";
                    SqlCommand Hcmd = new SqlCommand(HQuery, consql);
                    Hcmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = cboResidentUIN.SelectedValue;
                    Hcmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                    Hcmd.Parameters.Add("@BanDate", SqlDbType.DateTime).Value = BanDate.Text;
                    Hcmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate.Text;
                    Hcmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate.Text;
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
    }
}
