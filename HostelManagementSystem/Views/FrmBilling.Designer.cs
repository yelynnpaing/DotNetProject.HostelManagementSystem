namespace HostelManagementSystem.Views
{
    partial class FrmBilling
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
            this.dgInvoiceList = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BillingDate = new System.Windows.Forms.DateTimePicker();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.cboResidentUIN = new System.Windows.Forms.ComboBox();
            this.txtInvoiceId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.txtRoomPrice = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NewBtn = new System.Windows.Forms.Button();
            this.txtResidentPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResidentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgInvoiceList
            // 
            this.dgInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceList.Location = new System.Drawing.Point(360, 450);
            this.dgInvoiceList.Name = "dgInvoiceList";
            this.dgInvoiceList.RowHeadersWidth = 51;
            this.dgInvoiceList.RowTemplate.Height = 24;
            this.dgInvoiceList.Size = new System.Drawing.Size(1561, 477);
            this.dgInvoiceList.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(355, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 29);
            this.label9.TabIndex = 26;
            this.label9.Text = "Invoices List";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResidentName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.BillingDate);
            this.groupBox1.Controls.Add(this.txtRoomId);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cboPaymentType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.cboResidentUIN);
            this.groupBox1.Controls.Add(this.txtInvoiceId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTotalBill);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startDate);
            this.groupBox1.Controls.Add(this.txtRoomPrice);
            this.groupBox1.Controls.Add(this.ClearBtn);
            this.groupBox1.Controls.Add(this.SaveBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NewBtn);
            this.groupBox1.Controls.Add(this.txtResidentPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(360, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1492, 227);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1272, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 54;
            this.label13.Text = "Billing Date";
            // 
            // BillingDate
            // 
            this.BillingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BillingDate.Location = new System.Drawing.Point(1276, 40);
            this.BillingDate.Name = "BillingDate";
            this.BillingDate.Size = new System.Drawing.Size(188, 27);
            this.BillingDate.TabIndex = 53;
            // 
            // txtRoomId
            // 
            this.txtRoomId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomId.Location = new System.Drawing.Point(785, 40);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(188, 27);
            this.txtRoomId.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(277, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Resident UIN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1021, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Payment Type";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(1024, 103);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(188, 28);
            this.cboPaymentType.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(530, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "New End Date";
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(534, 104);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(188, 27);
            this.endDate.TabIndex = 48;
            // 
            // cboResidentUIN
            // 
            this.cboResidentUIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResidentUIN.FormattingEnabled = true;
            this.cboResidentUIN.Location = new System.Drawing.Point(281, 40);
            this.cboResidentUIN.Name = "cboResidentUIN";
            this.cboResidentUIN.Size = new System.Drawing.Size(188, 28);
            this.cboResidentUIN.TabIndex = 47;
            this.cboResidentUIN.Leave += new System.EventHandler(this.cboResidentUIN_Leave);
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceId.Location = new System.Drawing.Point(31, 41);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Size = new System.Drawing.Size(188, 27);
            this.txtInvoiceId.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "InvoiceId";
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(785, 104);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(188, 27);
            this.txtTotalBill.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(781, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Monthly Bill";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(277, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "New Start Date";
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(281, 104);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(188, 27);
            this.startDate.TabIndex = 39;
            // 
            // txtRoomPrice
            // 
            this.txtRoomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomPrice.Location = new System.Drawing.Point(1036, 41);
            this.txtRoomPrice.Name = "txtRoomPrice";
            this.txtRoomPrice.Size = new System.Drawing.Size(188, 27);
            this.txtRoomPrice.TabIndex = 36;
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Silver;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearBtn.Location = new System.Drawing.Point(379, 175);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(130, 36);
            this.ClearBtn.TabIndex = 35;
            this.ClearBtn.Text = "Clear ";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(202, 175);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(130, 36);
            this.SaveBtn.TabIndex = 29;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(781, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Room No";
            // 
            // NewBtn
            // 
            this.NewBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.NewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.ForeColor = System.Drawing.Color.White;
            this.NewBtn.Location = new System.Drawing.Point(31, 175);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(130, 36);
            this.NewBtn.TabIndex = 24;
            this.NewBtn.Text = "New";
            this.NewBtn.UseVisualStyleBackColor = false;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // txtResidentPhone
            // 
            this.txtResidentPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentPhone.Location = new System.Drawing.Point(30, 104);
            this.txtResidentPhone.Name = "txtResidentPhone";
            this.txtResidentPhone.Size = new System.Drawing.Size(188, 27);
            this.txtResidentPhone.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1032, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "RoomPrice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(355, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "Invoice Creating";
            // 
            // txtResidentName
            // 
            this.txtResidentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResidentName.Location = new System.Drawing.Point(534, 40);
            this.txtResidentName.Name = "txtResidentName";
            this.txtResidentName.Size = new System.Drawing.Size(188, 27);
            this.txtResidentName.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(530, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Resident Name";
            // 
            // FrmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 972);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgInvoiceList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBilling";
            this.Text = "FrmBilling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgInvoiceList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.TextBox txtRoomPrice;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.TextBox txtResidentPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboResidentUIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker BillingDate;
        private System.Windows.Forms.TextBox txtResidentName;
        private System.Windows.Forms.Label label1;
    }
}