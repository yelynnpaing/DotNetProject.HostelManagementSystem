namespace HostelManagementSystem.Views
{
    partial class FrmResidentList
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
            this.label9 = new System.Windows.Forms.Label();
            this.dgOccupyResidentList = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.cboResidentUIN = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.BtnResidentLeave = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.highlightBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOccupyResidentList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(359, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 29);
            this.label9.TabIndex = 27;
            this.label9.Text = "Occupy Resident List";
            // 
            // dgOccupyResidentList
            // 
            this.dgOccupyResidentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOccupyResidentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOccupyResidentList.Location = new System.Drawing.Point(364, 413);
            this.dgOccupyResidentList.Name = "dgOccupyResidentList";
            this.dgOccupyResidentList.RowHeadersWidth = 51;
            this.dgOccupyResidentList.RowTemplate.Height = 24;
            this.dgOccupyResidentList.Size = new System.Drawing.Size(1366, 517);
            this.dgOccupyResidentList.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(359, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 29);
            this.label8.TabIndex = 37;
            this.label8.Text = "Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.StartDate);
            this.groupBox1.Controls.Add(this.cboResidentUIN);
            this.groupBox1.Controls.Add(this.ClearBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Location = new System.Drawing.Point(364, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 160);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "End Date";
            // 
            // EndDate
            // 
            this.EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(514, 49);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(188, 27);
            this.EndDate.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(264, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Start Date";
            // 
            // StartDate
            // 
            this.StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(268, 49);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(188, 27);
            this.StartDate.TabIndex = 50;
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
            this.ClearBtn.Location = new System.Drawing.Point(209, 100);
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
            this.SearchBtn.Location = new System.Drawing.Point(26, 100);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(130, 36);
            this.SearchBtn.TabIndex = 24;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // BtnResidentLeave
            // 
            this.BtnResidentLeave.BackColor = System.Drawing.SystemColors.Control;
            this.BtnResidentLeave.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.BtnResidentLeave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnResidentLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResidentLeave.ForeColor = System.Drawing.Color.Blue;
            this.BtnResidentLeave.Location = new System.Drawing.Point(1532, 148);
            this.BtnResidentLeave.Name = "BtnResidentLeave";
            this.BtnResidentLeave.Size = new System.Drawing.Size(198, 36);
            this.BtnResidentLeave.TabIndex = 47;
            this.BtnResidentLeave.Text = "Leaved Residents";
            this.BtnResidentLeave.UseVisualStyleBackColor = false;
            this.BtnResidentLeave.Click += new System.EventHandler(this.BtnResidentLeave_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBtn.ForeColor = System.Drawing.Color.Black;
            this.PrintBtn.Location = new System.Drawing.Point(1541, 371);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(189, 36);
            this.PrintBtn.TabIndex = 56;
            this.PrintBtn.Text = "Print Resident List";
            this.PrintBtn.UseVisualStyleBackColor = false;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // highlightBtn
            // 
            this.highlightBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.highlightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlightBtn.ForeColor = System.Drawing.Color.White;
            this.highlightBtn.Location = new System.Drawing.Point(643, 371);
            this.highlightBtn.Name = "highlightBtn";
            this.highlightBtn.Size = new System.Drawing.Size(205, 36);
            this.highlightBtn.TabIndex = 54;
            this.highlightBtn.Text = "Highlight Expire Bill";
            this.highlightBtn.UseVisualStyleBackColor = false;
            this.highlightBtn.Click += new System.EventHandler(this.highlightBtn_Click);
            // 
            // FrmResidentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1003);
            this.Controls.Add(this.highlightBtn);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.BtnResidentLeave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgOccupyResidentList);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmResidentList";
            this.Text = "FrmPersonList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResidentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOccupyResidentList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgOccupyResidentList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button BtnResidentLeave;
        private System.Windows.Forms.ComboBox cboResidentUIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button highlightBtn;
    }
}