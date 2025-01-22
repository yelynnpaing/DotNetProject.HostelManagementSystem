﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;
        DataSet Dset;

        private void Clear()
        {
            txtInvoiceId.Text = "";
            cboResidentUIN.Text = "";
            txtResidentName.Text = "";
            txtRoomPrice.Text = "";
            txtRoomId.Text = "";
            txtResidentPhone.Text = "";
            txtTotalBill.Text = "";
            cboPaymentType.Text="";
            txtInvoiceId.Focus();

            txtInvoiceId.Enabled = true;
            cboResidentUIN.Enabled = true;
            txtResidentName.Enabled = true;
            txtRoomId.Enabled = true;
            txtRoomPrice.Enabled = true;
            txtResidentPhone.Enabled = true;
            startDate.Enabled = true;
            endDate.Enabled = true;
            txtTotalBill.Enabled = true;
        }

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void AutoId()
        {
            string IvName;
            int IVId;

            string query = "SELECT InvID FROM TblInvoices ORDER BY InvID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "residents");

            if (Dset.Tables["residents"].Rows.Count > 0)
            {
                IvName = Dset.Tables["residents"].Rows[Dset.Tables["residents"].Rows.Count - 1][0].ToString();
                IVId = int.Parse(IvName.Substring(3, (IvName.Length - 3)));
                txtInvoiceId.Text = "INV" + (IVId + 1).ToString("000000");
            }
            else
            {
                txtInvoiceId.Text = "INV000001";
            }
        }

        private void FillCboResidents()
        {
            string query = @"SELECT TblResidents.ResidentId, TblResidents.UIN AS ResidentUIN, TblResidents.Name FROM TblResidents
                            INNER JOIN TblRoomCapacityCheck
                            ON TblResidents.ResidentId = TblRoomCapacityCheck.ResidentId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(ds, "residents");
            dt = ds.Tables["residents"];
            cboResidentUIN.DataSource = dt;
            cboResidentUIN.DisplayMember = dt.Columns["ResidentUIN"].ToString();
            cboResidentUIN.ValueMember = dt.Columns["ResidentId"].ToString();
        }

        private void FillCboPaymentType()
        {
            string query = "SELECT PaymentTypeId, PaymentName FROM TblPaymentTypes";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(ds, "paymentTypes");
            dt = ds.Tables["paymentTypes"];
            cboPaymentType.DataSource = dt;
            cboPaymentType.DisplayMember = dt.Columns["PaymentName"].ToString();
            cboPaymentType.ValueMember = dt.Columns["PaymentTypeId"].ToString();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            Connection();
            FillCboResidents();
            BillingDate.MinDate = DateTime.Now;
            FillCboPaymentType();
            Clear();
            FilldgInvoiceList();
        }

        private void cboResidentUIN_Leave(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT TblResidents.Name, TblRooms.RoomId, TblRoomPrices.RoomPrice, TblResidents.Phone,
                                TblResidents.StartDate, TblResidents.EndDate FROM TblRooms
                                INNER JOIN TblRoomPrices
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId
                                INNER JOIN TblResidents
                                ON TblRooms.RoomId = TblResidents.RoomId
                                WHERE TblRooms.RoomId = TblResidents.RoomId AND TblResidents.ResidentId = '" + cboResidentUIN.SelectedValue+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "invoiceDatas");
                dt = ds.Tables["invoiceDatas"];
                txtResidentName.Text = ds.Tables["invoiceDatas"].Rows[0][0].ToString();
                txtRoomId.Text = ds.Tables["invoiceDatas"].Rows[0][1].ToString();
                txtRoomPrice.Text = ds.Tables["invoiceDatas"].Rows[0][2].ToString();
                txtResidentPhone.Text = ds.Tables["invoiceDatas"].Rows[0][3].ToString();
                //Insert EndDate value to New Start Date Value
                foreach(DataGridViewRow dr in dgInvoiceList.Rows)
                {
                    if (dr.Cells["ResidentUIN"].Value.ToString() == cboResidentUIN.Text)
                    {
                        startDate.Text = ds.Tables["invoiceDatas"].Rows[0][5].ToString();
                        endDate.Text = startDate.Value.AddDays(7).ToString();
                        break;
                    }
                    else
                    {
                        startDate.Text = ds.Tables["invoiceDatas"].Rows[0][4].ToString();
                        endDate.Text = ds.Tables["invoiceDatas"].Rows[0][5].ToString();
                    }
                }
                
                txtTotalBill.Text = ds.Tables["invoiceDatas"].Rows[0][2].ToString();
                txtInvoiceId.Enabled = false;
                cboResidentUIN.Enabled = false;
                txtResidentName.Enabled = false;
                txtRoomId.Enabled = false;
                txtRoomPrice.Enabled = false;
                txtResidentPhone.Enabled = false;
                startDate.Enabled = false;                
                txtTotalBill.Enabled = false;
            }
            catch
            {
                MessageBox.Show("There is no residents in this room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            Clear();
            AutoId();
        }

        private void UpdateResidentEndDate()
        {
            try
            {
                string query = @"UPDATE TblResidents SET StartDate = @StartDate, EndDate = @EndDate WHERE ResidentId = @ResidentId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@StartDate", startDate.Text);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Text);
                cmd.Parameters.AddWithValue("@ResidentId", cboResidentUIN.SelectedValue);
                ExecuteMyQuery(cmd, "This Resident EndDate is Updated.");
            }
            catch
            {
                MessageBox.Show("Something went wrongs! Please try again...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO TblInvoices VALUES (@InvoiceId, @ResidentId, @RoomId, @BillingDate, @StartDate, @EndDate, @TotalBill, @PaymentTypeId)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@InvoiceId", SqlDbType.VarChar).Value = txtInvoiceId.Text;
                cmd.Parameters.Add("@ResidentId", SqlDbType.VarChar).Value = cboResidentUIN.SelectedValue;
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@BillingDate", SqlDbType.Date).Value = BillingDate.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate.Text;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate.Text;
                cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = txtTotalBill.Text;
                cmd.Parameters.Add("@PaymentTypeId", SqlDbType.Int).Value = cboPaymentType.SelectedValue;

                ExecuteMyQuery(cmd, "Invoice datas save successfully!");
                UpdateResidentEndDate();
                Clear();
                FilldgInvoiceList();
            }
            catch
            {
                MessageBox.Show("Something went wrongs! Please try again...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteMyQuery(SqlCommand cmd, string message)
        {
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FilldgInvoiceList()
        {
            try
            {
                string query = @"SELECT TblInvoices.InvID, TblResidents.UIN AS ResidentUIN, TblResidents.Name, TblRooms.RoomId As RoomNo, TblRoomPrices.RoomPrice,
                                TblInvoices.BillingDate, TblResidents.Phone, TblInvoices.StartDate, TblInvoices.EndDate, 
                                TblInvoices.TotalBill, TblPaymentTypes.PaymentName AS Payment FROM TblInvoices
                                INNER JOIN TblResidents
                                ON TblInvoices.ResidentId = TblResidents.ResidentId
                                INNER JOIN TblRooms 
                                ON TblInvoices.RoomId = TblRooms.RoomId
                                INNER JOIN TblRoomPrices 
                                ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId
                                INNER JOIN TblPaymentTypes 
                                ON TblInvoices.PaymentTypeId = TblPaymentTypes.PaymentTypeId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(ds, "invoices");
                dt = ds.Tables["invoices"];
                dgInvoiceList.DataSource = dt;

                dgInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgInvoiceList.AllowUserToAddRows = false;
                dgInvoiceList.RowTemplate.Height = 50;
            }
            catch
            {
                MessageBox.Show("There is no Invoice to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
