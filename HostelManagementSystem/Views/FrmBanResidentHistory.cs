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
    public partial class FrmBanResidentHistory : Form
    {
        public FrmBanResidentHistory()
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
        }

        private void FillCboResidentUIN()
        {
            try
            {
                string query = @"SELECT TblResidents.UIN, TblBanResidentHistory.ResidentId
                                FROM TblBanResidentHistory
                                INNER JOIN TblResidents
                                ON TblResidents.ResidentId = TblBanResidentHistory.ResidentId
                                ORDER BY UIN";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet dataSet = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(dataSet, "cboResidentUIN");
                dt = dataSet.Tables["cboResidentUIN"];
                cboResidentUIN.DataSource = dt;
                cboResidentUIN.DisplayMember = dt.Columns["UIN"].ToString();
                cboResidentUIN.ValueMember = dt.Columns["ResidentId"].ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your Page.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmBanResidentHistory_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboResidentUIN();
            FillDgBanResidentList();
        }

        string OriginQuery = @"SELECT TblResidents.Image, TblResidents.UIN, TblResidents.ResidentId, TblResidents.Name,
                                TblBanResidentHistory.RoomId As RoomNo, TblResidents.Phone, TblBanResidentHistory.BanDate, 
                                TblRulesAndRegulations.Title As BanReason, TblBanResidentHistory.StartDate, 
                                TblBanResidentHistory.EndDate,TblBanResidentHistory.Ban
                                FROM TblBanResidentHistory
                                INNER JOIN TblResidents
                                ON TblResidents.ResidentId = TblBanResidentHistory.ResidentId
                                INNER JOIN TblRulesAndRegulations
                                ON TblBanResidentHistory.RRID = TblRulesAndRegulations.RRId";

        
        private void FillDgBanResidentListData()
        {
            dgBanResidentList.Columns[7].Width = 150;
            dgBanResidentList.Columns[10].Width = 60;

            dgBanResidentList.RowTemplate.Height = 70;
            dgBanResidentList.AllowUserToAddRows = false;
            dgBanResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol = (DataGridViewImageColumn)dgBanResidentList.Columns[0];
            imageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void FillDgBanResidentList()
        {
            try
            {
                string query = @" " + OriginQuery + " ORDER BY ResidentId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "banResidents");
                dgBanResidentList.DataSource = ds.Tables["banResidents"];
                FillDgBanResidentListData();
            }
            catch
            {
                MessageBox.Show("There is no resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgBanResidentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBanResidentList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgBanResidentList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ReadOnly = true;
                dgBanResidentList.CancelEdit();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string searchQuery = @"" + OriginQuery + "  WHERE TblResidents.UIN = '" + cboResidentUIN.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, consql);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "banResidents");
            dgBanResidentList.DataSource = ds.Tables["banResidents"];
            FillDgBanResidentListData();
        }

        private void ClearBtn_Click_1(object sender, EventArgs e)
        {
            Clear();
            FillDgBanResidentList();
        }
    }
}
