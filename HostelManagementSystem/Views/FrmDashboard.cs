using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FormLoad(object form)
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
            FormLoad(new FrmPersonDetail());
        }

        private void PersonDetailLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmPersonDetail());
        }

        private void PersonListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmPersonList());
        }

        private void PersonListLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmPersonList());
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
            FormLoad(new FrmBillingList());
        }

        private void BillListLabel_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBillingList());
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
