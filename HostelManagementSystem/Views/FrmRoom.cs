//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem.Views
{
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }

        SqlConnection consql;
        string str;
        DataSet Dset;

        private void Connection()
        {
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;";
            consql = new SqlConnection(str);
            consql.Open();
        }

        private void Clear()
        {
            txtRoomId.Text = "";
            cboRoomType.Text = "";
            cboRoomPosition.Text = "";
            txtRoomPrice.Text = "";
            RoomPictureBox.Image = null;
            txtRoomId.Focus();
        }

        private void FillCboRoomType()
        {
            string query = "SELECT RoomTypeId, RoomType FROM TblRoomTypes ORDER BY RoomTypeId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(dataSet, "cboRoomTypes");
            dt = dataSet.Tables["cboRoomTypes"];
            cboRoomType.DataSource = dt;
            cboRoomType.DisplayMember = dt.Columns["RoomType"].ToString();
            cboRoomType.ValueMember = dt.Columns["RoomTypeId"].ToString();
        }

        private void FillCboRoomPosition()
        {
            string query = "SELECT RoomPositionId, RoomPosition FROM TblRoomPositions ORDER BY RoomPositionId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(dataSet, "cboRoomPositions");
            dt = dataSet.Tables["cboRoomPositions"];
            cboRoomPosition.DataSource = dt;
            cboRoomPosition.DisplayMember = dt.Columns["RoomPosition"].ToString();
            cboRoomPosition.ValueMember = dt.Columns["RoomPositionId"].ToString();
        }

        private void AutoId()
        {
            string RName;
            int RID;

            string query = "SELECT RoomId FROM Tblrooms ORDER BY RoomId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "rooms");

            if (Dset.Tables["rooms"].Rows.Count > 0)
            {
                RName = Dset.Tables["rooms"].Rows[Dset.Tables["rooms"].Rows.Count - 1][0].ToString();
                RID = int.Parse(RName.Substring(1, (RName.Length - 1)));
                txtRoomId.Text = "R" + (RID + 1).ToString("000");
            }
            else
            {
                txtRoomId.Text = "R001";
            }
        }

        private void FrmRoom_Load(object sender, EventArgs e)
        {
            Clear();
            Connection();
            FillCboRoomType();
            FillCboRoomPosition();
            FilldgRoomDatas();
        }

        private void SelectImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "Choose Image(*.PNG; *.JPG; *.JPEG) | *.png; *.jpg; *.jpeg";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //RoomPictureBox.Image = Image.FromFile(openFileDialog.FileName);
                RoomPictureBox.Load(openFileDialog.FileName);
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            Clear();
            AutoId();
        }

        private void cboRoomPosition_Leave(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT RoomPriceId, RoomPrice, TblRoomPositions.RoomPositionId, TblRoomTypes.RoomTypeId FROM TblRoomPrices " +
                    "INNER JOIN TblRoomTypes ON TblRoomPrices.RoomTypeId = '" + cboRoomType.SelectedValue + "'" +
                    "INNER JOIN TblRoomPositions ON TblRoomPrices.RoomPositionId = '" + cboRoomPosition.SelectedValue + "'" +
                    "WHERE TblRoomTypes.RoomTypeId = '" + cboRoomType.SelectedValue + "' AND TblRoomPositions.RoomPositionId = '" + cboRoomPosition.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                DataSet Dset = new DataSet();
                adapter.Fill(Dset, "Price");
                txtRoomPriceId.Text = Dset.Tables["Price"].Rows[0][0].ToString();
                txtRoomPrice.Text = Dset.Tables["Price"].Rows[0][1].ToString();
            }
            catch
            {
                MessageBox.Show("Please select Room Position", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var image = new ImageConverter().ConvertTo(RoomPictureBox.Image, typeof(Byte[]));

                string query = "INSERT INTO TblRooms VALUES (@RoomId, @RoomTypeId, @RoomPositionId, @RoomPriceId, @image)";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@RoomTypeId", SqlDbType.Int).Value = cboRoomType.SelectedValue;
                cmd.Parameters.Add("@RoomPositionId", SqlDbType.Int).Value = cboRoomPosition.SelectedValue;
                cmd.Parameters.Add("@RoomPriceId", SqlDbType.Int).Value = txtRoomPriceId.Text;
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = image;

                ExectueMyQuery(cmd, "Creating Room is success.");
                FilldgRoomDatas();
                Clear();
            }
            catch
            {
                MessageBox.Show("Something wrongs! check for creating room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExectueMyQuery(SqlCommand Command, string Message)
        {
            
            if(Command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(Message);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //consql.Close();
        }

      
        private void FilldgRoomDatas()
        {
            string query = "SELECT RoomId, TblRoomTypes.RoomType, TblRoomPositions.RoomPosition , TblRoomPrices.RoomPrice, " +
                "RoomImage FROM TblRooms INNER JOIN TblRoomTypes ON TblRooms.RoomTypeId = TblRoomTypes.RoomTypeId" +
                " INNER JOIN TblRoomPositions ON TblRooms.RoomPositionId = TblRoomPositions.RoomPositionId" +
                " INNER JOIN TblRoomPrices ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(ds, "rooms");
            dt = ds.Tables["rooms"];

            dgRoom.RowTemplate.Height = 100;
            dgRoom.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F , FontStyle.Bold);
            dgRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRoom.AllowUserToAddRows = false;
            dgRoom.DataSource = dt;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dgRoom.Columns[4];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    } 
}
