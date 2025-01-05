namespace HostelManagementSystem.Print
{
    partial class PrintRoomList
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
            this.RoomListCRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RoomListCRViewer
            // 
            this.RoomListCRViewer.ActiveViewIndex = -1;
            this.RoomListCRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoomListCRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoomListCRViewer.Location = new System.Drawing.Point(0, 0);
            this.RoomListCRViewer.Name = "RoomListCRViewer";
            this.RoomListCRViewer.Size = new System.Drawing.Size(1078, 572);
            this.RoomListCRViewer.TabIndex = 0;
            // 
            // PrintRoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 572);
            this.Controls.Add(this.RoomListCRViewer);
            this.Name = "PrintRoomList";
            this.Text = "PrintRoomList";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer RoomListCRViewer;
    }
}