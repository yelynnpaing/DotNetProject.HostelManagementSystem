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
            txtUIN.Text = "";
            txtResidentId.Text = "";
            txtResidentName.Text = "";
            txtRoomId.Text = "";
            txtResidentPhone.Text = "";
        }

        private void FrmBanResidentHistory_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillDgBanResidentList();
        }

        private void FillDgBanResidentList()
        {
            try
            {
                string query = @"SELECT TblResidents.Image, TblResidents.UIN, TblResidents.ResidentId, TblResidents.Name, TblBanResidents.RoomId As RoomNo, TblResidents.Phone,
                                TblBanResidents.BanDate, TblBanResidents.StartDate, TblBanResidents.EndDate, TblBanResidents.Ban, TblBanResidents.UnBan
                                FROM TblBanResidents
                                INNER JOIN TblResidents
                                ON TblResidents.ResidentId = TblBanResidents.ResidentId
                                WHERE TblBanResidents.Ban = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "banResidents");
                dgBanResidentList.DataSource = ds.Tables["banResidents"];
                dgBanResidentList.RowTemplate.Height = 100;
                dgBanResidentList.AllowUserToAddRows = false;
                dgBanResidentList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol = (DataGridViewImageColumn)dgBanResidentList.Columns[0];
                imageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
    }
}
