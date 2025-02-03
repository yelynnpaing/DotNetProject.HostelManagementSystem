using HostelManagementSystem.Print;
using HostelManagementSystem.Reports;
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
            if (FrmLogin.instance.UserRole != "admin")
            {
                PrintBtn.Visible = false;
            }
        }

        string OriginQuery = @"SELECT TblResidents.Image, TblResidents.UIN, TblResidents.ResidentId, TblResidents.Name,
                                TblBanResidentHistory.RoomId As RoomNo, TblResidents.Phone, TblBanResidentHistory.BanDate, 
                                TblRulesAndRegulations.Title As BanReason, TblBanResidentHistory.Ban
                                FROM TblBanResidentHistory
                                INNER JOIN TblResidents
                                ON TblResidents.ResidentId = TblBanResidentHistory.ResidentId
                                INNER JOIN TblRulesAndRegulations
                                ON TblBanResidentHistory.RRID = TblRulesAndRegulations.RRId";

        
        private void FillDgBanResidentListData()
        {
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
                txtResidentCount.Text = ds.Tables["banResidents"].Rows.Count.ToString();
                FillDgBanResidentListData();
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
                cell.ReadOnly = true;
                dgBanResidentList.CancelEdit();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery;
                if (cboResidentUIN.Text == "")
                {
                    searchQuery = @"" + OriginQuery + " WHERE TblBanResidentHistory.BanDate BETWEEN '" + StartDate.Text + "'  AND '" + EndDate.Text + "'";
                }
                else
                {
                    searchQuery = @"" + OriginQuery + " WHERE TblResidents.UIN = '" + cboResidentUIN.Text + "'" +
                                    "AND TblBanResidentHistory.BanDate BETWEEN '" + StartDate.Text + "' AND '" + EndDate.Text + "'";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "banResidents");
                dgBanResidentList.DataSource = ds.Tables["banResidents"];
                FillDgBanResidentListData();
                txtResidentCount.Text = ds.Tables["banResidents"].Rows.Count.ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong.There is no Resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click_1(object sender, EventArgs e)
        {
            Clear();
            FillDgBanResidentList();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Resident UIN", typeof(string));
            dt.Columns.Add("Resident ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Room No", typeof(string));
            dt.Columns.Add("Phone No", typeof(string));
            dt.Columns.Add("Ban Date", typeof(DateTime));
            dt.Columns.Add("Ban Reason", typeof(string));
            dt.Columns.Add("Ban", typeof(Boolean));

            foreach(DataGridViewRow dgv in dgBanResidentList.Rows)
            {
                dt.Rows.Add(dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value,
                    dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value);
            } 

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("BannedResidents.xml");

            PrintBannedResident printBannedResident = new PrintBannedResident();
            BannedResidentCrystalReport bannedResidentCrystalReport = new BannedResidentCrystalReport();
            bannedResidentCrystalReport.SetDataSource(ds);
            printBannedResident.BannedResidentsCRViewer.ReportSource = bannedResidentCrystalReport;
            printBannedResident.BannedResidentsCRViewer.Refresh();
            printBannedResident.ShowDialog();
        }
    }
}
