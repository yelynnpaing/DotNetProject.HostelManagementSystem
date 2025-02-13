using Google.Protobuf.WellKnownTypes;
using HostelManagementSystem.Views.DataEntryForm;
using HostelManagementSystem.Views.ResidentListtems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        private Label LastSelectLabel = null;

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

        // * * * Not Use 
        //private void CheckLabelUnderLine()
        //{
        //    foreach (Control control in SidebarPanel.Controls)
        //    {
        //        if (control is Label label)
        //        {
        //            label.Click += Label_Click;
        //        }
        //    }
        //}

        //private void Label_Click(object sender, EventArgs e)
        //{
        //    if(sender is Label clickedLabel)
        //    {
        //        if (LastSelectLabel != null)
        //        {
        //            LastSelectLabel.Font = new Font(LastSelectLabel.Font, LastSelectLabel.Font.Style ^ FontStyle.Underline);
        //        }
        //        clickedLabel.Font = new Font(clickedLabel.Font, clickedLabel.Font.Style ^ FontStyle.Underline);
        //        LastSelectLabel = clickedLabel;
        //    }
        //}

        //for Active Page
        private void LabelUnderLine(object sender)
        {
            if (sender is Label clickedLabel)
            {
                if (LastSelectLabel != null)
                {
                    LastSelectLabel.Font = new Font(LastSelectLabel.Font, LastSelectLabel.Font.Style ^ FontStyle.Underline);
                    LastSelectLabel.Font = new Font(LastSelectLabel.Font, LastSelectLabel.Font.Style ^ FontStyle.Italic);
                }

                clickedLabel.Font = new Font(clickedLabel.Font, clickedLabel.Font.Style ^ FontStyle.Underline);
                clickedLabel.Font = new Font(clickedLabel.Font, clickedLabel.Font.Style ^ FontStyle.Italic);
               
                LastSelectLabel = clickedLabel;
            };
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //private void FrmDashboard_Load(object sender, EventArgs e)
        //{
        //    Connection();
        //    //if(FrmLogin.instance.UserRole != "admin")
        //    //{
        //    //    RoomPanel.Enabled = false;
        //    //    BanResidentPanel.Enabled = false;
        //    //}
        //}

        private void RulesAndRegulationPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRulesAndRegulations());            
        }

        private void RulesAndRegulationLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmRulesAndRegulations());
        }

        private void RoomPic_Click(object sender, EventArgs e)
        {
            if(FrmLogin.instance.UserRole != "admin")
            {
                MessageBox.Show("Warning! you cann't access this features. This is only for admin.So, You can use other features.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormLoad(new FrmRoom());
            }
        }
        
        private void RoomLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            if (FrmLogin.instance.UserRole != "admin")
            {
                MessageBox.Show("Warning! you cann't access this features. This is only for admin.So, You can use other features.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormLoad(new FrmRoom());
            }
        }

        private void RoomListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRoomList());
        }

        private void RoomListLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmRoomList());
        }

        private void PersonDetailPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentDetail());
        }

        private void PersonDetailLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmResidentDetail());
        }

        private void PersonListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentList());
        }

        private void PersonListLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmResidentList());
        }

        private void BillingPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBilling());
        }

        private void BillingLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmBilling());
        }

        private void BillListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmBillingHistory());
        }

        private void BillListLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmBillingHistory());
        }

        private void BanResidentPic_Click(object sender, EventArgs e)
        {
            if (FrmLogin.instance.UserRole != "admin")
            {
                MessageBox.Show("Warning! you cann't access this features. This is only for admin.So, You can use other features.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormLoad(new FrmBanResident());
            }
        }

        private void BanResidantLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            if (FrmLogin.instance.UserRole != "admin")
            {
                MessageBox.Show("Warning! you cann't access this features. This is only for admin.So, You can use other features.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormLoad(new FrmBanResident());
            }
        }

        private void leaveResidentListPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmResidentLeaveList());
        }

        private void leaveResidentListLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmResidentLeaveList());
        }

        private void banResidentListPic_Click(object sender, EventArgs e)
        {

            FormLoad(new FrmBanResidentHistory());
        }

        private void banResidentLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmBanResidentHistory());
        }

        private void RRPic_Click(object sender, EventArgs e)
        {
            FormLoad(new FrmRulesAndRegulationsList());
        }

        private void RRLabel_Click(object sender, EventArgs e)
        {
            LabelUnderLine(sender);
            FormLoad(new FrmRulesAndRegulationsList());
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


        //for hover effect     
        private void DataEntryLabel_MouseEnter(object sender, EventArgs e)
        {
            DataEntryPanel.BackColor = Color.Gray;
            DataEntryLabel.ForeColor = Color.Black;
        }

        private void DataEntryLabel_MouseLeave(object sender, EventArgs e)
        {
            DataEntryPanel.BackColor = Color.Transparent;
            DataEntryLabel.ForeColor = SystemColors.Control;
        }

        private void RulesAndRegulationLabel_MouseEnter(object sender, EventArgs e)
        {
            RRPanel.BackColor = Color.Gray;
            RulesAndRegulationLabel.ForeColor = Color.Black;
        }

        private void RulesAndRegulationLabel_MouseLeave(object sender, EventArgs e)
        {
            RRPanel.BackColor = Color.Transparent;
            RulesAndRegulationLabel.ForeColor = SystemColors.Control;
        }

        private void RoomLabel_MouseEnter(object sender, EventArgs e)
        {
            RoomPanel.BackColor = Color.Gray;
            RoomLabel.ForeColor = Color.Black;
        }

        private void RoomLabel_MouseLeave(object sender, EventArgs e)
        {
            RoomPanel.BackColor = Color.Transparent;
            RoomLabel.ForeColor = SystemColors.Control;
        }

        private void PersonDetailLabel_MouseEnter(object sender, EventArgs e)
        {
            PersonDetailPanel.BackColor = Color.Gray;
            PersonDetailLabel.ForeColor = Color.Black;
        }

        private void PersonDetailLabel_MouseLeave(object sender, EventArgs e)
        {
            PersonDetailPanel.BackColor = Color.Transparent;
            PersonDetailLabel.ForeColor = SystemColors.Control;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            ProcessingPanel.BackColor = Color.Gray;
            ProcessingLabel.ForeColor = Color.Black;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            ProcessingPanel.BackColor = Color.Transparent;
            ProcessingLabel.ForeColor = SystemColors.Control;
        }

        private void BillingLabel_MouseEnter(object sender, EventArgs e)
        {
            BillingPanel.BackColor = Color.Gray;
            BillingLabel.ForeColor = Color.Black;
        }

        private void BillingLabel_MouseLeave(object sender, EventArgs e)
        {
            BillingPanel.BackColor = Color.Transparent;
            BillingLabel.ForeColor = SystemColors.Control;
        }

        private void BanResidantLabel_MouseEnter(object sender, EventArgs e)
        {
            BanResidentPanel.BackColor = Color.Gray;
            BanResidantLabel.ForeColor = Color.Black;
        }

        private void BanResidantLabel_MouseLeave(object sender, EventArgs e)
        {
            BanResidentPanel.BackColor = Color.Transparent;
            BanResidantLabel.ForeColor = SystemColors.Control;
        }

        private void ReportLabel_MouseEnter(object sender, EventArgs e)
        {
            ReportPanel.BackColor = Color.Gray;
            ReportLabel.ForeColor = Color.Black;
        }

        private void ReportLabel_MouseLeave(object sender, EventArgs e)
        {
            ReportPanel.BackColor = Color.Transparent;
            ReportLabel.ForeColor = SystemColors.Control;
        }

        private void RoomListLabel_MouseEnter(object sender, EventArgs e)
        {
            RoomListPanel.BackColor = Color.Gray;
            RoomListLabel.ForeColor = Color.Black;
        }

        private void RoomListLabel_MouseLeave(object sender, EventArgs e)
        {
            RoomListPanel.BackColor = Color.Transparent;
            RoomListLabel.ForeColor = SystemColors.Control;
        }

        private void PersonListLabel_MouseEnter(object sender, EventArgs e)
        {
            PersonListPanel.BackColor = Color.Gray;
            PersonListLabel.ForeColor = Color.Black;
        }

        private void PersonListLabel_MouseLeave(object sender, EventArgs e)
        {
            PersonListPanel.BackColor = Color.Transparent;
            PersonListLabel.ForeColor = SystemColors.Control;
        }

        private void BillListLabel_MouseEnter(object sender, EventArgs e)
        {
            BillListPanel.BackColor = Color.Gray;
            BillListLabel.ForeColor = Color.Black;
        }

        private void BillListLabel_MouseLeave(object sender, EventArgs e)
        {
            BillListPanel.BackColor = Color.Transparent;
            BillListLabel.ForeColor = SystemColors.Control;
        }

        private void leaveResidentListLabel_MouseEnter(object sender, EventArgs e)
        {
            LeaveResidentPanel.BackColor = Color.Gray;
            leaveResidentListLabel.ForeColor = Color.Black;
        }

        private void leaveResidentListLabel_MouseLeave(object sender, EventArgs e)
        {
            LeaveResidentPanel.BackColor = Color.Transparent;
            leaveResidentListLabel.ForeColor = SystemColors.Control;
        }

        private void banResidentListLabel_MouseEnter(object sender, EventArgs e)
        {
            BanResidentListPanel.BackColor = Color.Gray;
            banResidentListLabel.ForeColor = Color.Black;
        }

        private void banResidentListLabel_MouseLeave(object sender, EventArgs e)
        {
            BanResidentListPanel.BackColor = Color.Transparent;
            banResidentListLabel.ForeColor = SystemColors.Control;
        }

        private void RRLabel_MouseEnter(object sender, EventArgs e)
        {
            RRListPanel.BackColor = Color.Gray;
            RRLabel.ForeColor = Color.Black;
        }

        private void RRLabel_MouseLeave(object sender, EventArgs e)
        {
            RRListPanel.BackColor = Color.Transparent;
            RRLabel.ForeColor = SystemColors.Control;
        }

        private void LogoutLabel_MouseEnter(object sender, EventArgs e)
        {
            LogoutPanel.BackColor = Color.Gray;
            LogoutLabel.ForeColor = Color.Black;
        }

        private void LogoutLabel_MouseLeave(object sender, EventArgs e)
        {
            LogoutPanel.BackColor = Color.Transparent;
            LogoutLabel.ForeColor = SystemColors.Control;
        }

    }
}
