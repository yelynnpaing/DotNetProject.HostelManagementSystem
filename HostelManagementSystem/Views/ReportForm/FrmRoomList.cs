using HostelManagementSystem.Print;
using HostelManagementSystem.Reports;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmRoomList : Form
    {
        public FrmRoomList()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;
        FrmResidentList frmResidentList = new FrmResidentList();

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123; Connection Timeout=3600";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            cboRoomId.Text = "";
        }

        private void FillCboRoomId()
        {
            try
            {
                string query = "SELECT RoomId From TblRooms";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet dataSet = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(dataSet, "cboRoomId");
                dt = dataSet.Tables["cboRoomId"];
                cboRoomId.DataSource = dt;
                cboRoomId.DisplayMember = dt.Columns["RoomId"].ToString();
                cboRoomId.ValueMember = dt.Columns["RoomId"].ToString();
            }
            catch
            {
                MessageBox.Show("Something went wrong! Please reload your Page.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string QueryOrigin = @"SELECT TblRooms.RoomId As RoomNo, TblRoomTypes.RoomType, TblRoomPositions.RoomPosition, 
                               TblRooms.RoomImage, TblRoomPrices.RoomPrice, 
                               TblRoomCapacity.Capacity, TblResidents.Name As Name, TblResidents.UIN AS ResidentUIN,
                               TblResidents.EndDate
                               FROM TblRooms
                               INNER JOIN TblRoomTypes
                               ON TblRooms.RoomTypeId = TblRoomTypes.RoomTypeId
                               INNER JOIN TblRoomPositions
                               ON TblRooms.RoomPositionId = TblRoomPositions.RoomPositionId
                               INNER JOIN TblRoomPrices
                               ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId
                               LEFT JOIN TblRoomCapacity
                               ON TblRooms.RoomId = TblRoomCapacity.RoomId
                               LEFT JOIN TblRoomCapacityCheck
                               ON TblRooms.RoomId = TblRoomCapacityCheck.RoomId
                               LEFT JOIN TblResidents
                               ON TblRoomCapacityCheck.ResidentId = TblResidents.ResidentId";


        private void formatRows()
        {
            try
            {
                DateTime expireDate = DateTime.Now.Date;
                foreach (DataGridViewRow row in dgRoomList.Rows)
                {
                    if (row.Cells["EndDate"].Value != null)
                    {
                        DateTime enddate;
                        if (DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out enddate))
                        {
                            if (enddate.Date == expireDate || enddate.Date < expireDate)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void FillDgRoomListData()
        {
            foreach (DataGridViewColumn col in dgRoomList.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                formatRows();
            }
            dgRoomList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            dgRoomList.AllowUserToAddRows = false;
            dgRoomList.RowTemplate.Height = 100;

            DataGridViewImageColumn imgCol1 = new DataGridViewImageColumn();
            imgCol1 = (DataGridViewImageColumn)dgRoomList.Columns[3];
            imgCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void FillDgRoomList()
        {
            try
            {
                string RUIN;
                string query = @""+ QueryOrigin + " ORDER BY RoomSerialNo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "roomList");                
                ds.Tables.Add(dt);
                dgRoomList.DataSource = ds.Tables["roomList"];
                FillDgRoomListData();                
            }
            catch
            {
                MessageBox.Show("There is no rooms to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmRoomList_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboRoomId();
            frmResidentList.Connection();
            frmResidentList.CheckForRoomBill();
            FillDgRoomList();
            if(FrmLogin.instance.UserRole != "admin")
            {
                PrintBtn.Visible = false;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string query = "" + QueryOrigin + " WHERE TblRooms.RoomId = '"+cboRoomId.Text+"' ORDER BY OCCUPY";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "roomList");
            dgRoomList.DataSource = ds.Tables["roomList"];

            FillDgRoomListData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            FillDgRoomList();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Room No",  typeof(string));
            dt.Columns.Add("Room Type",  typeof(string));
            dt.Columns.Add("Room Position",  typeof(string));
            dt.Columns.Add("Price",  typeof(float));
            dt.Columns.Add("Capacity",  typeof(int));
            dt.Columns.Add("Resident Name",  typeof(string));
            dt.Columns.Add("ResidentUIN", typeof(string));
            dt.Columns.Add("End Date", typeof(DateTime));

            foreach (DataGridViewRow dgv in dgRoomList.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[4].Value,
                    dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value);
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("roomList.xml");

            PrintRoomList printRoomList = new PrintRoomList();
            RoomListCrystalReport roomListCrystalReport = new RoomListCrystalReport();
            roomListCrystalReport.SetDataSource(ds);
            printRoomList.RoomListCRViewer.ReportSource = roomListCrystalReport;
            printRoomList.RoomListCRViewer.Refresh();
            printRoomList.ShowDialog();
        }

        private void highlightBtn_Click(object sender, EventArgs e)
        {
            FillDgRoomList();
        }
    }
}
