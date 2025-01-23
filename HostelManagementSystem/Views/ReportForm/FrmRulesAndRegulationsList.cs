using HostelManagementSystem.PrintingForm;
using HostelManagementSystem.Reports;
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
            if(FrmLogin.instance.UserRole != "admin")
            {
                PrintBtn.Visible = false;
            }
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
                dgRulesAndRegulations.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11F, FontStyle.Bold);
                dgRulesAndRegulations.AllowUserToAddRows = false;
            }
            catch
            {
                MessageBox.Show("There is no Rules and Regulations to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",  typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            foreach(DataGridViewRow row in dgRulesAndRegulations.Rows)
            {
                dt.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("RulesAndRegulationsList.xml");

            PrintRulesAndRegualtionsList printRulesAndRegualtionsList = new PrintRulesAndRegualtionsList();
            RulesAndRegualtionsCrystalReport rulesAndRegulationsCrystalReport = new RulesAndRegualtionsCrystalReport();
            rulesAndRegulationsCrystalReport.SetDataSource(ds);
            printRulesAndRegualtionsList.RulesAndRegulationsCRViewer.ReportSource = rulesAndRegulationsCrystalReport;
            printRulesAndRegualtionsList.RulesAndRegulationsCRViewer.Refresh();
            printRulesAndRegualtionsList.ShowDialog();
            //rulesAndRegulationsCrystalReport.PrintToPrinter(2, false, 0, 0);
        }
    }
}
