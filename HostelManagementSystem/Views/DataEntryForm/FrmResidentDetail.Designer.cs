namespace HostelManagementSystem.Views
{
    partial class FrmResidentDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResidentPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NewBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResidentId = new System.Windows.Forms.TextBox();
            this.SelectImageBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResidentPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.cboRoomId = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResidentAddress = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.txtResidentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckboxOccupy = new System.Windows.Forms.CheckBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CheckBoxLeave = new System.Windows.Forms.CheckBox();
            this.txtRoomPrice = new System.Windows.Forms.TextBox();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUIN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgResidentList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResidentCount = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResidentPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResidentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(528, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(780, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Phone";
            // 
            // txtResidentPhone
            // 
            this.txtResidentPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentPhone.Location = new System.Drawing.Point(783, 134);
            this.txtResidentPhone.Name = "txtResidentPhone";
            this.txtResidentPhone.Size = new System.Drawing.Size(188, 27);
            this.txtResidentPhone.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Image";
            // 
            // NewBtn
            // 
            this.NewBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.NewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.ForeColor = System.Drawing.Color.White;
            this.NewBtn.Location = new System.Drawing.Point(30, 299);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(130, 36);
            this.NewBtn.TabIndex = 24;
            this.NewBtn.Text = "New";
            this.NewBtn.UseVisualStyleBackColor = false;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "ResidentId";
            // 
            // txtResidentId
            // 
            this.txtResidentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentId.Location = new System.Drawing.Point(28, 45);
            this.txtResidentId.Name = "txtResidentId";
            this.txtResidentId.Size = new System.Drawing.Size(188, 27);
            this.txtResidentId.TabIndex = 26;
            // 
            // SelectImageBtn
            // 
            this.SelectImageBtn.BackColor = System.Drawing.Color.Gray;
            this.SelectImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectImageBtn.ForeColor = System.Drawing.Color.White;
            this.SelectImageBtn.Location = new System.Drawing.Point(28, 241);
            this.SelectImageBtn.Name = "SelectImageBtn";
            this.SelectImageBtn.Size = new System.Drawing.Size(221, 36);
            this.SelectImageBtn.TabIndex = 27;
            this.SelectImageBtn.Text = "Select Image ...";
            this.SelectImageBtn.UseVisualStyleBackColor = false;
            this.SelectImageBtn.Click += new System.EventHandler(this.SelectImageBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ResidentPictureBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(29, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 139);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // ResidentPictureBox
            // 
            this.ResidentPictureBox.Location = new System.Drawing.Point(18, 21);
            this.ResidentPictureBox.Name = "ResidentPictureBox";
            this.ResidentPictureBox.Size = new System.Drawing.Size(188, 104);
            this.ResidentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResidentPictureBox.TabIndex = 4;
            this.ResidentPictureBox.TabStop = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(203, 299);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(130, 36);
            this.SaveBtn.TabIndex = 29;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.ForeColor = System.Drawing.Color.Black;
            this.UpdateBtn.Location = new System.Drawing.Point(560, 299);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(130, 36);
            this.UpdateBtn.TabIndex = 30;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // cboRoomId
            // 
            this.cboRoomId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomId.FormattingEnabled = true;
            this.cboRoomId.Location = new System.Drawing.Point(783, 45);
            this.cboRoomId.Name = "cboRoomId";
            this.cboRoomId.Size = new System.Drawing.Size(188, 28);
            this.cboRoomId.TabIndex = 32;
            this.cboRoomId.Leave += new System.EventHandler(this.cboRoomId_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(780, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Room No";
            // 
            // txtResidentAddress
            // 
            this.txtResidentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentAddress.Location = new System.Drawing.Point(281, 106);
            this.txtResidentAddress.Multiline = true;
            this.txtResidentAddress.Name = "txtResidentAddress";
            this.txtResidentAddress.Size = new System.Drawing.Size(439, 127);
            this.txtResidentAddress.TabIndex = 34;
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Silver;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearBtn.Location = new System.Drawing.Point(380, 299);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(130, 36);
            this.ClearBtn.TabIndex = 35;
            this.ClearBtn.Text = "Clear ";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // txtResidentName
            // 
            this.txtResidentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentName.Location = new System.Drawing.Point(532, 45);
            this.txtResidentName.Name = "txtResidentName";
            this.txtResidentName.Size = new System.Drawing.Size(188, 27);
            this.txtResidentName.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Address";
            // 
            // CheckboxOccupy
            // 
            this.CheckboxOccupy.AutoSize = true;
            this.CheckboxOccupy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxOccupy.Location = new System.Drawing.Point(1034, 134);
            this.CheckboxOccupy.Name = "CheckboxOccupy";
            this.CheckboxOccupy.Size = new System.Drawing.Size(88, 24);
            this.CheckboxOccupy.TabIndex = 38;
            this.CheckboxOccupy.Text = "Occupy";
            this.CheckboxOccupy.UseVisualStyleBackColor = true;
            this.CheckboxOccupy.CheckedChanged += new System.EventHandler(this.CheckboxOccupy_CheckedChanged);
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(783, 206);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(188, 27);
            this.startDate.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(779, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "Start Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1030, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Room Price ( MMK )";
            // 
            // CheckBoxLeave
            // 
            this.CheckBoxLeave.AutoSize = true;
            this.CheckBoxLeave.Enabled = false;
            this.CheckBoxLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLeave.Location = new System.Drawing.Point(1146, 134);
            this.CheckBoxLeave.Name = "CheckBoxLeave";
            this.CheckBoxLeave.Size = new System.Drawing.Size(76, 24);
            this.CheckBoxLeave.TabIndex = 43;
            this.CheckBoxLeave.Text = "Leave";
            this.CheckBoxLeave.UseVisualStyleBackColor = true;
            this.CheckBoxLeave.CheckedChanged += new System.EventHandler(this.CheckBoxLeave_CheckedChanged);
            // 
            // txtRoomPrice
            // 
            this.txtRoomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomPrice.Location = new System.Drawing.Point(1034, 45);
            this.txtRoomPrice.Name = "txtRoomPrice";
            this.txtRoomPrice.Size = new System.Drawing.Size(188, 27);
            this.txtRoomPrice.TabIndex = 44;
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(1034, 206);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(159, 27);
            this.endDate.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1030, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "End Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUIN);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.txtRoomPrice);
            this.groupBox1.Controls.Add(this.CheckBoxLeave);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startDate);
            this.groupBox1.Controls.Add(this.CheckboxOccupy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtResidentName);
            this.groupBox1.Controls.Add(this.ClearBtn);
            this.groupBox1.Controls.Add(this.txtResidentAddress);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboRoomId);
            this.groupBox1.Controls.Add(this.UpdateBtn);
            this.groupBox1.Controls.Add(this.SaveBtn);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.SelectImageBtn);
            this.groupBox1.Controls.Add(this.txtResidentId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NewBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtResidentPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(359, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1260, 349);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // txtUIN
            // 
            this.txtUIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUIN.Location = new System.Drawing.Point(281, 45);
            this.txtUIN.Name = "txtUIN";
            this.txtUIN.Size = new System.Drawing.Size(188, 27);
            this.txtUIN.TabIndex = 48;
            this.txtUIN.TabStop = false;
            this.txtUIN.Leave += new System.EventHandler(this.txtUIN_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(277, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 47;
            this.label13.Text = "Smart Card Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(354, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 29);
            this.label8.TabIndex = 21;
            this.label8.Text = "Resident Register";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(354, 519);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 29);
            this.label9.TabIndex = 23;
            this.label9.Text = "Resident List";
            // 
            // dgResidentList
            // 
            this.dgResidentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgResidentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResidentList.Location = new System.Drawing.Point(359, 551);
            this.dgResidentList.Name = "dgResidentList";
            this.dgResidentList.RowHeadersWidth = 51;
            this.dgResidentList.RowTemplate.Height = 24;
            this.dgResidentList.Size = new System.Drawing.Size(1561, 410);
            this.dgResidentList.TabIndex = 24;
            this.dgResidentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResidentList_CellClick);
            this.dgResidentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResidentList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(541, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "- ";
            // 
            // txtResidentCount
            // 
            this.txtResidentCount.AutoSize = true;
            this.txtResidentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtResidentCount.Location = new System.Drawing.Point(576, 519);
            this.txtResidentCount.Name = "txtResidentCount";
            this.txtResidentCount.Size = new System.Drawing.Size(29, 29);
            this.txtResidentCount.TabIndex = 25;
            this.txtResidentCount.Text = "- ";
            // 
            // FrmResidentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 1003);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResidentCount);
            this.Controls.Add(this.dgResidentList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmResidentDetail";
            this.Text = "FrmPersonDetail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmResidentDetail_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResidentPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResidentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResidentPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResidentId;
        private System.Windows.Forms.Button SelectImageBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox ResidentPictureBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.ComboBox cboRoomId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResidentAddress;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.TextBox txtResidentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckboxOccupy;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox CheckBoxLeave;
        private System.Windows.Forms.TextBox txtRoomPrice;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgResidentList;
        private System.Windows.Forms.TextBox txtUIN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtResidentCount;
    }
}