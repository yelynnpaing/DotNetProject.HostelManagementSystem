namespace HostelManagementSystem.Views
{
    partial class FrmRulesAndRegulations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.dgRulesAndRegulations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgRulesAndRegulations)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(364, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(702, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rules And Regulations from Mandalar Myay Hostel";
            // 
            // dgRulesAndRegulations
            // 
            this.dgRulesAndRegulations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRulesAndRegulations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRulesAndRegulations.Location = new System.Drawing.Point(369, 214);
            this.dgRulesAndRegulations.Name = "dgRulesAndRegulations";
            this.dgRulesAndRegulations.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgRulesAndRegulations.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRulesAndRegulations.RowTemplate.Height = 24;
            this.dgRulesAndRegulations.Size = new System.Drawing.Size(1431, 736);
            this.dgRulesAndRegulations.TabIndex = 29;
            // 
            // FrmRulesAndRegulations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1003);
            this.Controls.Add(this.dgRulesAndRegulations);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRulesAndRegulations";
            this.Text = "FrmRulesAndRegulations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRulesAndRegulations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRulesAndRegulations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgRulesAndRegulations;
    }
}