using HostelManagementSystem.Print;
using HostelManagementSystem.Reports;
using HostelManagementSystem.Views.ResidentListtems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmResidentList : Form
    {
        public FrmResidentList()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;

        public void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123; Connection Timeout=3600";
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
                                INNER JOIN TblRoomCapacityCheck 
                                ON TblResidents.ResidentId = TblRoomCapacityCheck.ResidentId
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

        private void BtnResidentLeave_Click(object sender, EventArgs e)
        {
            FrmResidentLeaveList RLForm = new FrmResidentLeaveList();
            RLForm.ShowDialog();
        }

        string QueryOrigin = @"SELECT TblResidents.UIN As ResidentUIN, TblResidents.Name, TblResidents.Image, TblRoomCapacityCheck.RoomId As RoomNo,
                                TblRooms.RoomImage, TblRoomPrices.RoomPrice, TblResidents.StartDate, TblResidents.EndDate
                                FROM TblResidents 
                                INNER JOIN TblRoomCapacityCheck
                                ON TblResidents.ResidentId = TblRoomCapacityCheck.ResidentId
                                INNER JOIN TblRooms
                                ON TblResidents.RoomId = TblRooms.RoomId
                                INNER JOIN TblRoomPrices
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId";

        public void CheckForRoomBill()
        {
            try
            {
                DateTime expireDate = DateTime.Now.Date;
                string RUIN, RName, RoomID;
                DateTime startDate, endDate;

                string query = @"SELECT TblResidents.UIN As ResidentUIN, TblResidents.Name, TblRoomCapacityCheck.RoomId As RoomNo,
                                TblResidents.StartDate, TblResidents.EndDate
                                FROM TblResidents 
                                INNER JOIN TblRoomCapacityCheck
                                ON TblResidents.ResidentId = TblRoomCapacityCheck.ResidentId
                                INNER JOIN TblRooms
                                ON TblResidents.RoomId = TblRooms.RoomId
                                INNER JOIN TblRoomPrices
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residentData");
                ds.Tables.Add(dt);
                foreach (DataTable dataTable in ds.Tables)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        RUIN = row[0].ToString();
                        RName = row[1].ToString();
                        RoomID = row[2].ToString();
                        startDate = (DateTime)row[3];
                        endDate = (DateTime)row[4];
                        if (endDate.Date == expireDate)
                        {
                            MessageBox.Show("Resident " + RUIN + " - " + RName + " is to pay Bill for Room " + RoomID + " and expire date is  " + endDate, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (endDate.Date < expireDate)
                        {
                            MessageBox.Show("Resident " + RUIN + " - " + RName + " is to pay Bill for Room " + RoomID + " and expire date is  " + endDate + ". This resident bill is expire.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void formatRows()
        {
            DateTime expireDate = DateTime.Now.Date;
            foreach (DataGridViewRow row in dgOccupyResidentList.Rows)
            {
                if (row.Cells["EndDate"].Value != null)
                {
                    DateTime enddate;
                    if (DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out enddate))
                    {
                        if (enddate.Date == expireDate || enddate < expireDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        public void FillDgOccupyResidentListData()
        {
            foreach (DataGridViewColumn col in dgOccupyResidentList.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                formatRows();
            }
            dgOccupyResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            dgOccupyResidentList.AllowUserToAddRows = false;
            dgOccupyResidentList.RowTemplate.Height = 100;

            DataGridViewImageColumn ImgCol1 = new DataGridViewImageColumn();
            ImgCol1 = (DataGridViewImageColumn)dgOccupyResidentList.Columns[2];
            ImgCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn ImgCol2 = new DataGridViewImageColumn();
            ImgCol2 = (DataGridViewImageColumn)dgOccupyResidentList.Columns[4];
            ImgCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        public void FillDgOccupyResidentList()
        {
            try
            { 
                string query = @" "+ QueryOrigin + " ORDER BY ResidentUIN";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residentList");
                dt = ds.Tables["residentList"];
                dgOccupyResidentList.DataSource = ds.Tables["residentList"];
                FillDgOccupyResidentListData();
                txtResidentCount.Text = ds.Tables["residentList"].Rows.Count.ToString();
            }
            catch
            {
                MessageBox.Show("There is no resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmResidentList_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboResidentUIN();
            
            if(FrmLogin.instance.UserRole != "admin")
            {
                PrintBtn.Visible = false;
            }
            CheckForRoomBill();
            FillDgOccupyResidentList();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery;
                if (cboResidentUIN.Text == "")
                {
                    searchQuery = @"" + QueryOrigin + " WHERE TblResidents.StartDate BETWEEN '" + StartDate.Text + "'  AND '" + EndDate.Text + "'";
                }
                else
                {
                    searchQuery = @"" + QueryOrigin + " WHERE TblResidents.UIN = '" + cboResidentUIN.Text + "'" +
                                    "AND TblResidents.StartDate BETWEEN '" + StartDate.Text + "' AND '" + EndDate.Text + "'";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "residentList");
                dgOccupyResidentList.DataSource = ds.Tables["residentList"];
                FillDgOccupyResidentListData();
                txtResidentCount.Text = ds.Tables["residentList"].Rows.Count.ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong.There is no Resident to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            FillDgOccupyResidentList();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Resident UIN", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Room No", typeof(string));
            dt.Columns.Add("Room Price", typeof(string));
            dt.Columns.Add("Start Date", typeof(DateTime));
            dt.Columns.Add("End Date", typeof(DateTime));

            foreach(DataGridViewRow dgv in dgOccupyResidentList.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[3].Value, dgv.Cells[5].Value,
                    dgv.Cells[6].Value, dgv.Cells[7].Value);
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("OcResidentList.xml");

            PrintOccupyResidentList printOccupyResidentList = new PrintOccupyResidentList();
            OccupyResidentListCrystalReport occupyResidentListCrystalReport = new OccupyResidentListCrystalReport();
            occupyResidentListCrystalReport.SetDataSource(ds);
            printOccupyResidentList.OccupyResidentCRViwer.ReportSource = occupyResidentListCrystalReport;
            printOccupyResidentList.OccupyResidentCRViwer.Refresh();
            printOccupyResidentList.ShowDialog();
        }

        private void highlightBtn_Click(object sender, EventArgs e)
        {
            formatRows();
        }
    }
}
