namespace HostelManagementSystem.Views
{
    partial class FrmRoomList
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
            this.dgRoomList = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboRoomId = new System.Windows.Forms.ComboBox();
            this.PrintBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgRoomList
            // 
            this.dgRoomList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoomList.Location = new System.Drawing.Point(354, 340);
            this.dgRoomList.Name = "dgRoomList";
            this.dgRoomList.RowHeadersWidth = 51;
            this.dgRoomList.RowTemplate.Height = 24;
            this.dgRoomList.Size = new System.Drawing.Size(1551, 599);
            this.dgRoomList.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(349, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 29);
            this.label9.TabIndex = 29;
            this.label9.Text = "Rooms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(349, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 29);
            this.label8.TabIndex = 34;
            this.label8.Text = "Search ";
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.Color.White;
            this.SearchBtn.Location = new System.Drawing.Point(265, 59);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(130, 36);
            this.SearchBtn.TabIndex = 24;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Room No";
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Silver;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearBtn.Location = new System.Drawing.Point(443, 59);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(130, 36);
            this.ClearBtn.TabIndex = 35;
            this.ClearBtn.Text = "Clear ";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRoomId);
            this.groupBox1.Controls.Add(this.ClearBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Location = new System.Drawing.Point(354, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 135);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // cboRoomId
            // 
            this.cboRoomId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomId.FormattingEnabled = true;
            this.cboRoomId.Location = new System.Drawing.Point(37, 66);
            this.cboRoomId.Name = "cboRoomId";
            this.cboRoomId.Size = new System.Drawing.Size(188, 28);
            this.cboRoomId.TabIndex = 54;
            // 
            // PrintBtn
            // 
            this.PrintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBtn.ForeColor = System.Drawing.Color.Black;
            this.PrintBtn.Location = new System.Drawing.Point(1716, 298);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(189, 36);
            this.PrintBtn.TabIndex = 55;
            this.PrintBtn.Text = "Print Room Datas";
            this.PrintBtn.UseVisualStyleBackColor = false;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // FrmRoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1003);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgRoomList);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRoomList";
            this.Text = "FrmRoomList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRoomList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRoomList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboRoomId;
        private System.Windows.Forms.Button PrintBtn;
    }
}