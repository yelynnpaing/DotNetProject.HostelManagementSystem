namespace HostelManagementSystem.Print
{
    partial class PrintOccupyResidentList
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
            this.OccupyResidentCRViwer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // OccupyResidentCRViwer
            // 
            this.OccupyResidentCRViwer.ActiveViewIndex = -1;
            this.OccupyResidentCRViwer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OccupyResidentCRViwer.Cursor = System.Windows.Forms.Cursors.Default;
            this.OccupyResidentCRViwer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OccupyResidentCRViwer.Location = new System.Drawing.Point(0, 0);
            this.OccupyResidentCRViwer.Name = "OccupyResidentCRViwer";
            this.OccupyResidentCRViwer.Size = new System.Drawing.Size(1398, 589);
            this.OccupyResidentCRViwer.TabIndex = 0;
            // 
            // PrintOccupyResidentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 589);
            this.Controls.Add(this.OccupyResidentCRViwer);
            this.Name = "PrintOccupyResidentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintOccupyResidentList";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer OccupyResidentCRViwer;
    }
}