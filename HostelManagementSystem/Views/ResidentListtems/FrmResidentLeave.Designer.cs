namespace HostelManagementSystem.Views.ResidentListtems
{
    partial class FrmResidentLeave
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
            this.dgvLeaveResidents = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboResidentUIN = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveResidents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLeaveResidents
            // 
            this.dgvLeaveResidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaveResidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveResidents.Location = new System.Drawing.Point(38, 258);
            this.dgvLeaveResidents.Name = "dgvLeaveResidents";
            this.dgvLeaveResidents.RowHeadersWidth = 51;
            this.dgvLeaveResidents.RowTemplate.Height = 50;
            this.dgvLeaveResidents.Size = new System.Drawing.Size(1387, 570);
            this.dgvLeaveResidents.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(33, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "Leave Resident List";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(33, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 29);
            this.label8.TabIndex = 39;
            this.label8.Text = "Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboResidentUIN);
            this.groupBox1.Controls.Add(this.ClearBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Location = new System.Drawing.Point(38, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 121);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // cboResidentUIN
            // 
            this.cboResidentUIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResidentUIN.FormattingEnabled = true;
            this.cboResidentUIN.Location = new System.Drawing.Point(29, 48);
            this.cboResidentUIN.Name = "cboResidentUIN";
            this.cboResidentUIN.Size = new System.Drawing.Size(188, 28);
            this.cboResidentUIN.TabIndex = 36;
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Silver;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearBtn.Location = new System.Drawing.Point(467, 43);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(130, 36);
            this.ClearBtn.TabIndex = 35;
            this.ClearBtn.Text = "Clear ";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Resident UIN";
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.Color.White;
            this.SearchBtn.Location = new System.Drawing.Point(283, 43);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(130, 36);
            this.SearchBtn.TabIndex = 24;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // FrmResidentLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 901);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLeaveResidents);
            this.Controls.Add(this.label2);
            this.Name = "FrmResidentLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmResidentLeave";
            this.Load += new System.EventHandler(this.FrmResidentLeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveResidents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLeaveResidents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboResidentUIN;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SearchBtn;
    }
}