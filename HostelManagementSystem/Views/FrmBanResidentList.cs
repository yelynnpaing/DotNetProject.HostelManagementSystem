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
            txtUIN.Text = "";
            txtResidentName.Text = "";
            cboResidentId.Text = "";
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
        }

        private void FillCboResidentId()
        {
            string query = "SELECT ResidentId, UIN, Name, RoomId, Phone FROM TblResidents ORDER BY ResidentId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "residents");
            DataTable dt = new DataTable();
            dt = ds.Tables["residents"];
            cboResidentId.DataSource = dt;
            cboResidentId.DisplayMember = dt.Columns["ResidentId"].ToString();
            cboResidentId.ValueMember = dt.Columns["ResidentId"].ToString();
        }

        private void cboResidentId_Leave(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ResidentId, UIN, Name, RoomId, Phone FROM TblResidents WHERE ResidentId = '"+cboResidentId.Text+"';";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "residentData");
                txtUIN.Text = ds.Tables["residentData"].Rows[0][0].ToString();
                txtResidentName.Text = ds.Tables["residentData"].Rows[0][1].ToString();
                txtRoomId.Text = ds.Tables["residentData"].Rows[0][2].ToString();
                txtResidentPhone.Text = ds.Tables["residentData"].Rows[0][3].ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
