namespace HostelManagementSystem.Print
{
    partial class PrintBannedResident
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
            this.BannedResidentsCRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BannedResidentsCRViewer
            // 
            this.BannedResidentsCRViewer.ActiveViewIndex = -1;
            this.BannedResidentsCRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BannedResidentsCRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BannedResidentsCRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BannedResidentsCRViewer.Location = new System.Drawing.Point(0, 0);
            this.BannedResidentsCRViewer.Name = "BannedResidentsCRViewer";
            this.BannedResidentsCRViewer.Size = new System.Drawing.Size(1407, 646);
            this.BannedResidentsCRViewer.TabIndex = 0;
            // 
            // PrintBannedResident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 646);
            this.Controls.Add(this.BannedResidentsCRViewer);
            this.Name = "PrintBannedResident";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintBannedResident";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer BannedResidentsCRViewer;
    }
}