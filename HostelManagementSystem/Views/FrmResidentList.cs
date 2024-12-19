using HostelManagementSystem.Views.ResidentListtems;
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
    public partial class FrmResidentList : Form
    {
        public FrmResidentList()
        {
            InitializeComponent();
        }

        private void BtnResidentLeave_Click(object sender, EventArgs e)
        {
            FrmResidentLeave RLForm = new FrmResidentLeave();
            RLForm.ShowDialog();
        }
    }
}
