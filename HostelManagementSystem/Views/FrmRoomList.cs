using MySqlX.XDevAPI.Relational;
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
    public partial class FrmRoomList : Form
    {
        public FrmRoomList()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;
        

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
                               TblRoomCapacity.Capacity, TblResidents.Name As Resident
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

        private void FillDgRoomListData()
        {
            foreach (DataGridViewColumn col in dgRoomList.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                string query = @""+ QueryOrigin + " ORDER BY Occupy";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "roomList");
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
            FillDgRoomList();
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
    }
}
