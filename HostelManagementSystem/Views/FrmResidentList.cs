using HostelManagementSystem.Views.ResidentListtems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        private void Connection()
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
            FrmResidentLeave RLForm = new FrmResidentLeave();
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

        private void FillDgOccupyResidentListData()
        {
            foreach (DataGridViewColumn col in dgOccupyResidentList.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void FillDgOccupyResidentList()
        {
            try
            { 
                string query = @" "+ QueryOrigin + " ORDER BY ResidentUIN";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residentList");
                dgOccupyResidentList.DataSource = ds.Tables["residentList"];
                FillDgOccupyResidentListData();
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
                adapter.Fill(ds, "occupyResidents");
                dgOccupyResidentList.DataSource = ds.Tables["occupyResidents"];
                FillDgOccupyResidentListData();
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
    }
}
