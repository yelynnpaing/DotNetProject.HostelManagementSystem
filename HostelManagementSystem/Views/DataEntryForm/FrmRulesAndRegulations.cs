using System;
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

namespace HostelManagementSystem.Views.DataEntryForm
{
    public partial class FrmRulesAndRegulations : Form
    {
        public FrmRulesAndRegulations()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;Connection Timeout=3600";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            txtRRId.Text = "";
            txtRRTitle.Text = "";
            txtRRDescription.Text = "";
            txtRRTitle.Focus();
        }

        private void FrmRulesAndRegulations_Load(object sender, EventArgs e)
        {
            Connection();
            Clear();
            FillDgRRListData();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO TblRulesAndRegulations (Title, Description) 
                            VALUES (@Title, @Description)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = txtRRTitle.Text;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = txtRRDescription.Text;
                if(string.IsNullOrEmpty(txtRRTitle.Text))
                {
                    MessageBox.Show("Fill text into Title field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtRRDescription.Text))
                {
                    MessageBox.Show("Fill text into Description field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtRRTitle.Text) && !string.IsNullOrEmpty(txtRRTitle.Text))
                {
                    ExecuteMyQuery(cmd, "Adding new rules and regulations is success.");
                }
                Clear();
                FillDgRRListData();
            }
            catch
            {
                MessageBox.Show("Data saving fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillDgRRListData()
        {
            try
            {
                string query = "SELECT * FROM TblRulesAndRegulations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "RRList");
                dgRRList.DataSource = ds.Tables["RRList"];
                txtRRCount.Text = ds.Tables["RRList"].Rows.Count.ToString();
                dgRRList.RowTemplate.Height = 70;
                dgRRList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgRRList.AllowUserToAddRows = false;
                dgRRList.Columns[0].Width = 100;
                dgRRList.Columns[1].Width = 250;
            }
            catch
            {
                MessageBox.Show("There is no data to show!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExecuteMyQuery(SqlCommand cmd, String message)
        {
            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute. Check Query.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgRRList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRRId.Text = dgRRList.CurrentRow.Cells[0].Value.ToString();
            txtRRTitle.Text = dgRRList.CurrentRow.Cells[1].Value.ToString();
            txtRRDescription.Text = dgRRList.CurrentRow.Cells[2].Value.ToString();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE TblRulesAndRegulations SET Title = @Title, Description = @Description
                            WHERE RRId = @RRId";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.AddWithValue("@Title", txtRRTitle.Text.ToString());
                cmd.Parameters.AddWithValue("@Description", txtRRDescription.Text.ToString());
                cmd.Parameters.AddWithValue("@RRId", txtRRId.Text.ToString());
                if (string.IsNullOrEmpty(txtRRTitle.Text))
                {
                    MessageBox.Show("Fill text into Title field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtRRDescription.Text))
                {
                    MessageBox.Show("Fill text into Description field.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!string.IsNullOrEmpty(txtRRTitle.Text) && !string.IsNullOrEmpty(txtRRTitle.Text))
                {
                    ExecuteMyQuery(cmd, "Update Successful.!");
                }
               
                Clear();
                FillDgRRListData();
            }
            catch
            {
                MessageBox.Show("Data updating fail!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM TblRulesAndRegulations WHERE RRId = @RRId";
            SqlCommand cmd = new SqlCommand(query, consql);
            cmd.Parameters.AddWithValue("@RRid", txtRRId.Text.ToString());
            if(string.IsNullOrEmpty(txtRRId.Text))
            {
                MessageBox.Show("Select row to delete. If you cannot select the row, you can't use delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ExecuteMyQuery(cmd, "Deleting is success.!");
            Clear();
            FillDgRRListData(); 
        }
    }
}
