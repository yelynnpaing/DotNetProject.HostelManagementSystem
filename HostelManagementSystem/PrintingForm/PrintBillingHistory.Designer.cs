namespace HostelManagementSystem.Print
{
    partial class PrintBillingHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BillingHistoryCRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BillingHistoryCRViewer
            // 
            this.BillingHistoryCRViewer.ActiveViewIndex = -1;
            this.BillingHistoryCRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BillingHistoryCRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BillingHistoryCRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BillingHistoryCRViewer.Location = new System.Drawing.Point(0, 0);
            this.BillingHistoryCRViewer.Name = "BillingHistoryCRViewer";
            this.BillingHistoryCRViewer.Size = new System.Drawing.Size(1301, 619);
            this.BillingHistoryCRViewer.TabIndex = 0;
            // 
            // PrintBillingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 619);
            this.Controls.Add(this.BillingHistoryCRViewer);
            this.Name = "PrintBillingHistory";
            this.Text = "PrintBillingHistory";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer BillingHistoryCRViewer;
    }
}