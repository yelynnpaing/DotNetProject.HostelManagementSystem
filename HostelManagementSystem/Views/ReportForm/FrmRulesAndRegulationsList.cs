using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmRulesAndRegulationsList : Form
    {
        public FrmRulesAndRegulationsList()
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

        private void FrmRulesAndRegulations_Load(object sender, EventArgs e)
        {
            Connection();
            FillDgRulesAndRegulations();
        }

        private void FillDgRulesAndRegulations()
        {
            try
            {
                string query = "SELECT RRId AS ID, Title, Description FROM TblRulesAndRegulations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "rulesAndRegulations");
                dgRulesAndRegulations.DataSource = ds.Tables["rulesAndRegulations"];
                dgRulesAndRegulations.Columns[0].Width = 80;
                dgRulesAndRegulations.Columns[1].Width = 230;

                dgRulesAndRegulations.RowTemplate.Height = 40;
                dgRulesAndRegulations.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12F, FontStyle.Bold);
                dgRulesAndRegulations.AllowUserToAddRows = false;
            }
            catch
            {
                MessageBox.Show("There is no Rules and Regulations to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
