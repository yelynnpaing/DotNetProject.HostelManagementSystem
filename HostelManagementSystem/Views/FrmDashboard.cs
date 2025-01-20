using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123";
            consql = new SqlConnection(str);
            consql.Open();
        }

        public void FormLoad(object form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);

            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            Connection();
            if(FrmLogin.instance.UserRole != "admin")
            {
                RoomPanel.Visible = false;
                BanResidentPanel.Visible = false;
            }
        }

        private void RoomPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRoom());
        }
        
        private void RoomLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRoom());
        }

        private void RoomListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRoomList());
        }

        private void RoomListLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRoomList());
        }

        private void PersonDetailPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentDetail());
        }

        private void PersonDetailLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentDetail());
        }

        private void PersonListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentList());
        }

        private void PersonListLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentList());
        }

        private void BillingPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBilling());
        }

        private void BillingLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBilling());
        }

        private void BillListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBillingHistory());
        }

        private void BillListLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBillingHistory());
        }

        private void BanResidentPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBanResident());
        }

        private void BanResidantLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBanResident());
        }

        private void RRPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRulesAndRegulations());
        }

        private void RRLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRulesAndRegulations());
        }

        private void LogoutPic_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

    }
}
