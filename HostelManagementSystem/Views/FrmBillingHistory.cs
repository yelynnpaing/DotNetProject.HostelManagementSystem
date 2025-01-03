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
    public partial class FrmBillingHistory : Form
    {
        public FrmBillingHistory()
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
            StartDate.Text = "";
            EndDate.Text = "";
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

        private void FrmBillingHistory_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboRoomId();
            FillDgInvoiceList();
        }

        string OriginQuery = @"SELECT TblInvoices.InvID, TblResidents.Name, TblRooms.RoomId As RoomNo, TblRoomPrices.RoomPrice,
                                TblInvoices.BillingDate, TblResidents.Phone, TblInvoices.StartDate, TblInvoices.EndDate, 
                                TblInvoices.TotalBill, TblPaymentTypes.PaymentName FROM TblInvoices
                                INNER JOIN TblResidents
                                ON TblInvoices.ResidentId = TblResidents.ResidentId
                                INNER JOIN TblRooms 
                                ON TblInvoices.RoomId = TblRooms.RoomId
                                INNER JOIN TblRoomPrices 
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId
                                INNER JOIN TblPaymentTypes 
                                ON TblInvoices.PaymentTypeId = TblPaymentTypes.PaymentTypeId";


        private void FillDgInvoiceListData()
        {
            foreach (DataGridViewColumn col in dgInvoiceList.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            dgInvoiceList.AllowUserToAddRows = false;
            dgInvoiceList.RowTemplate.Height = 50;
        }

        private void FillDgInvoiceList()
        {
            try
            {
                string query = @""+OriginQuery+ " ORDER BY InvID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "invoices");
                dt = ds.Tables["invoices"];
                dgInvoiceList.DataSource = dt;
                FillDgInvoiceListData();
            }
            catch
            {
                MessageBox.Show("There is no Invoice to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                if (cboRoomId.Text == "")
                {
                    query = @"" + OriginQuery + " WHERE TblInvoices.StartDate BETWEEN '" + StartDate.Text + "'  AND '" + EndDate.Text + "'";
                }
                else
                {
                    query = @"" + OriginQuery + " WHERE TblRooms.RoomId = '" + cboRoomId.Text + "'" +
                                    "AND TblInvoices.StartDate BETWEEN '" + StartDate.Text + "' AND '" + EndDate.Text + "'";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "invoices");
                dt = ds.Tables["invoices"];
                dgInvoiceList.DataSource = dt;
                FillDgInvoiceListData();
            }
            catch
            {
                MessageBox.Show("Something went wrong.There is no Invoice to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
            FillDgInvoiceList();
        }
    }
}
