namespace HostelManagementSystem.Print
{
    partial class PrintLeavedResidentList
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
            this.LeavedResidentCRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // LeavedResidentCRViewer
            // 
            this.LeavedResidentCRViewer.ActiveViewIndex = -1;
            this.LeavedResidentCRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeavedResidentCRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.LeavedResidentCRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeavedResidentCRViewer.Location = new System.Drawing.Point(0, 0);
            this.LeavedResidentCRViewer.Name = "LeavedResidentCRViewer";
            this.LeavedResidentCRViewer.Size = new System.Drawing.Size(1447, 736);
            this.LeavedResidentCRViewer.TabIndex = 0;
            // 
            // PrintLeavedResidentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 736);
            this.Controls.Add(this.LeavedResidentCRViewer);
            this.Name = "PrintLeavedResidentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintLeavedResidentList";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer LeavedResidentCRViewer;
    }
}