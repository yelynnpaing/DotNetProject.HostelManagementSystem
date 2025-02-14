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

namespace HostelManagementSystem.Views.ResidentListtems
{
    public partial class FrmResidentLeaveList : Form
    {
        public FrmResidentLeaveList()
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
            cboResidentUIN.Text = "";
        }

        private void FillCboResidentUIN()
        {
            try
            {
                string query = @"SELECT TblResidents.UIN, TblResidents.ResidentId FROM TblResidents 
                                INNER JOIN TblRooms
                                ON TblResidents.RoomId = TblRooms.RoomId
                                WHERE Leave = 1
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


        string OriginQuery = @"SELECT TblResidents.UIN AS ResidentUIN, TblResidents.Name,TblResidents.RoomId As RoomNo, 
                                TblResidents.Image, TblResidents.Address, TblResidents.Phone,
                                TblResidents.StartDate, TblResidents.EndDate, TblResidents.LeaveDate
                                FROM TblResidents 
                                INNER JOIN TblRooms ON TblResidents.RoomId = TblRooms.RoomId
                                WHERE Leave = 1";

        private void FillLeaveResidentData()
        {
            foreach (DataGridViewColumn col in dgvLeaveResidents.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvLeaveResidents.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            dgvLeaveResidents.AllowUserToAddRows = false;
            dgvLeaveResidents.RowTemplate.Height = 100;

            DataGridViewImageColumn ImgCol1 = new DataGridViewImageColumn();
            ImgCol1 = (DataGridViewImageColumn)dgvLeaveResidents.Columns[3];
            ImgCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void FillLeaveResidents()
        {
            try
            {
                string query = @""+ OriginQuery + "";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residents");
                dt = ds.Tables["residents"];
                dgvLeaveResidents.DataSource = dt;
                txtResidentCount.Text = ds.Tables["residents"].Rows.Count.ToString(); 
                
                //dgvLeaveResidents.Columns[0].Width = 50;
                dgvLeaveResidents.Columns[1].Width = 70;
                dgvLeaveResidents.Columns[2].Width = 90;
                dgvLeaveResidents.Columns[4].Width = 300;

                FillLeaveResidentData();
            }
            catch
            {
                MessageBox.Show("There is no resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmResidentLeave_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboResidentUIN();
            FillLeaveResidents();
            if (FrmLogin.instance.UserRole != "admin")
            {
                PrintBtn.Visible = false;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery;
                if (cboResidentUIN.Text == "")
                {
                    //searchQuery = @"" + OriginQuery + " AND TblResidents.LeaveDate BETWEEN '" + StartDate.Text + "'  AND '" + EndDate.Text + "'";
                    searchQuery = @"" + OriginQuery + " AND TblResidents.LeaveDate = '" + leaveDate.Text + "'";
                }
                else
                {
                    searchQuery = @"" + OriginQuery + " AND TblResidents.UIN = '" + cboResidentUIN.Text + "'" +
                                    "AND TblResidents.LeaveDate = '" + leaveDate.Text + "'";
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "leaveResidents");
                dgvLeaveResidents.DataSource = ds.Tables["leaveResidents"];
                FillLeaveResidentData();
                txtResidentCount.Text = ds.Tables["leaveResidents"].Rows.Count.ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong.There is no leave Resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            FillLeaveResidents();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Resident UIN", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Room No", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone No", typeof(string));
            dt.Columns.Add("Start Date", typeof(DateTime));
            dt.Columns.Add("End Date", typeof(DateTime));
            dt.Columns.Add("Leave Date", typeof(DateTime));

            foreach (DataGridViewRow dgv in dgvLeaveResidents.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[4].Value,
                    dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value);
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("LeavedResidentList.xml");

            PrintLeavedResidentList printLeavedResidentList = new PrintLeavedResidentList();
            LeavedResidentListCrystalReport leavedResidentListCrystalReport = new LeavedResidentListCrystalReport();
            leavedResidentListCrystalReport.SetDataSource(ds);
            printLeavedResidentList.LeavedResidentCRViewer.ReportSource = leavedResidentListCrystalReport;
            printLeavedResidentList.LeavedResidentCRViewer.Refresh();
            printLeavedResidentList.ShowDialog();
        }
    }
}
