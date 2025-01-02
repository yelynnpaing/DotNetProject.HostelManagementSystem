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
    public partial class FrmResidentLeave : Form
    {
        public FrmResidentLeave()
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
            txtResidentId.Text = "";
            txtResidentName.Text = "";
            cboRoomId.Text = "";
            txtRoomPrice.Text = "";
            txtResidentPhone.Text = "";
        }

        private void FillLeaveResidents()
        {
            try
            {
                string query = @"SELECT TblResidents.ResidentId as Id, TblResidents.Name,TblResidents.RoomId As RoomNo, 
                                TblResidents.Image, TblResidents.Address, TblResidents.Phone,
                                TblResidents.StartDate, TblResidents.EndDate
                                FROM TblResidents 
                                INNER JOIN TblRooms ON TblResidents.RoomId = TblRooms.RoomId
                                WHERE Leave = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "residents");
                dt = ds.Tables["residents"];
                dgvLeaveResidents.DataSource = dt;
                
                dgvLeaveResidents.Columns[0].Width = 50;
                dgvLeaveResidents.Columns[1].Width = 70;
                dgvLeaveResidents.Columns[2].Width = 90;
                dgvLeaveResidents.Columns[4].Width = 300;

                //dgvLeaveResidents.RowTemplate.Height = 150;
                dgvLeaveResidents.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgvLeaveResidents.AllowUserToAddRows = false;
                //dgResidentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataGridViewImageColumn ImgCol = new DataGridViewImageColumn();
                ImgCol = (DataGridViewImageColumn)dgvLeaveResidents.Columns[3];
                ImgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
            FillLeaveResidents();
        }
    }
}
