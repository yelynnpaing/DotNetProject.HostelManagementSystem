namespace HostelManagementSystem.PrintingForm
{
    partial class PrintRulesAndRegualtionsList
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
            this.RulesAndRegulationsCRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RulesAndRegulationsCRViewer
            // 
            this.RulesAndRegulationsCRViewer.ActiveViewIndex = -1;
            this.RulesAndRegulationsCRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RulesAndRegulationsCRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RulesAndRegulationsCRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RulesAndRegulationsCRViewer.Location = new System.Drawing.Point(0, 0);
            this.RulesAndRegulationsCRViewer.Name = "RulesAndRegulationsCRViewer";
            this.RulesAndRegulationsCRViewer.Size = new System.Drawing.Size(1409, 583);
            this.RulesAndRegulationsCRViewer.TabIndex = 0;
            // 
            // PrintRulesAndRegualtionsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 583);
            this.Controls.Add(this.RulesAndRegulationsCRViewer);
            this.Name = "PrintRulesAndRegualtionsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintRulesAndRegualtionsList";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer RulesAndRegulationsCRViewer;
    }
}