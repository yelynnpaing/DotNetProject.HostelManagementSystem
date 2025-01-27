
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames.Image;


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
            str = "Data Source=DESKTOP-L3SMK21\\SQLEXPRESS;Initial Catalog=HostelManagementSystemDb;Persist Security Info=True;User ID=sa;Password=sasa@123;Connection Timeout=3600";
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
            txtRoomId.Enabled = true;
            cboRoomType.Enabled = true;
            cboRoomPosition.Enabled = true;
            txtRoomPrice.Enabled = true;
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

            //string query = "SELECT RoomId FROM Tblrooms ORDER BY RoomId";
            string query = "SELECT RoomId FROM Tblrooms ORDER BY RoomSerialNo";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "rooms");

            if (Dset.Tables["rooms"].Rows.Count > 0)
            {
                RName = Dset.Tables["rooms"].Rows[Dset.Tables["rooms"].Rows.Count - 1][0].ToString();
                RID = int.Parse(RName.Substring(1, (RName.Length - 1)));
                //for dynamic room number 
                if(cboRoomType.GetItemText(this.cboRoomType.SelectedItem) == "Single")
                {
                    txtRoomId.Text = "S" + (RID + 1).ToString("000");
                }
                else if (cboRoomType.GetItemText(this.cboRoomType.SelectedItem) == "Double")
                {
                    txtRoomId.Text = "D" + (RID + 1).ToString("000");
                }
                else if (cboRoomType.GetItemText(this.cboRoomType.SelectedItem) == "Triple")
                {
                    txtRoomId.Text = "T" + (RID + 1).ToString("000");
                }

                //for static roomNumber
                //txtRoomId.Text = "R" + (RID + 1).ToString("000");
            }
            else
            {
                if (cboRoomType.GetItemText(this.cboRoomType.SelectedItem) == "Single")
                {
                    txtRoomId.Text = "S001";
                }
                else
                {
                    MessageBox.Show("Please, Select Single RoomType.The first number is start from single.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //for static roomNumber
                //txtRoomId.Text = "R001";
            }
        }

        private void FrmRoom_Load(object sender, EventArgs e)
        {
            Connection();
            FillCboRoomType();
            FillCboRoomPosition();
            Clear();
            txtRoomId.Enabled = false;
            txtRoomPrice.Enabled = false;
            FilldgRoomDatas();
        }

        private void SelectImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "Choose Image(*.PNG; *.JPG; *.JPEG) | *.png; *.jpg; *.jpeg";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RoomPictureBox.Load(openFileDialog.FileName);
            }
        } 

        private void NewBtn_Click(object sender, EventArgs e)
        {
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

                //Insert RoomCapacity value
                string rcQuery = "INSERT INTO TblRoomCapacity VALUES (@Capacity, @RoomId)";
                SqlCommand rcCommand = new SqlCommand(rcQuery, consql);
                rcCommand.Parameters.Add("@Capacity", SqlDbType.Int).Value = cboRoomType.SelectedValue;
                rcCommand.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                ExectueMyQuery(rcCommand, "Successfully added room capacity value.");

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
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query cannot be execute!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void FilldgRoomDatas()
        {
            try
            {
                string query = "SELECT TblRooms.RoomId AS RoomNo, TblRoomTypes.RoomType, TblRoomPositions.RoomPosition , TblRoomPrices.RoomPrice, " +
               "RoomImage FROM TblRooms INNER JOIN TblRoomTypes ON TblRooms.RoomTypeId = TblRoomTypes.RoomTypeId" +
               " INNER JOIN TblRoomPositions ON TblRooms.RoomPositionId = TblRoomPositions.RoomPositionId" +
               " INNER JOIN TblRoomPrices ON TblRooms.RoomPriceId = TblRoomPrices.RoomPriceId ORDER BY RoomSerialNo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
                Dset = new DataSet();
                DataTable dt = new DataTable();
                adapter.Fill(Dset, "rooms");
                dt = Dset.Tables["rooms"];
                dgRoom.DataSource = dt;

                dgRoom.RowTemplate.Height = 100;
                dgRoom.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                dgRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgRoom.AllowUserToAddRows = false;
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol = (DataGridViewImageColumn)dgRoom.Columns[4];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            catch
            {
                MessageBox.Show("There is no room to show!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Not use because index out of range error
                //int i;
                //i = dgRoom.CurrentRow.Index;
                //txtRoomId.Text = Dset.Tables["rooms"].Rows[i][0].ToString();
                //cboRoomType.Text = Dset.Tables["rooms"].Rows[i][1].ToString();
                //cboRoomPosition.Text = Dset.Tables["rooms"].Rows[i][2].ToString();
                //txtRoomPrice.Text = Dset.Tables["rooms"].Rows[i][3].ToString();

                txtRoomId.Text = dgRoom.CurrentRow.Cells[0].Value.ToString();
                cboRoomType.Text = dgRoom.CurrentRow.Cells[1].Value.ToString();
                cboRoomPosition.Text = dgRoom.CurrentRow.Cells[2].Value.ToString();
                txtRoomPrice.Text = dgRoom.CurrentRow.Cells[3].Value.ToString();
                txtRoomId.Enabled = false;
                cboRoomType.Enabled = false;
                cboRoomPosition.Enabled = false;
                txtRoomPrice.Enabled = false;
                Byte[] imageData = (Byte[])dgRoom.CurrentRow.Cells[4].Value;
                MemoryStream ms = new MemoryStream(imageData);
                RoomPictureBox.Image = Image.FromStream(ms);
            }
            catch
            {
                MessageBox.Show("Warning , Something went wrong! Please reload your page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var img = new ImageConverter().ConvertTo(RoomPictureBox.Image, typeof(Byte[]));
                string query = "UPDATE TblRooms SET RoomId = @RoomId, RoomTypeId = @RoomTypeId, RoomPositionId = @RoomPositionId, " +
                    "RoomPriceId = @RoomPriceId, RoomImage = @image WHERE RoomId = '" + txtRoomId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, consql);
                cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = txtRoomId.Text;
                cmd.Parameters.Add("@RoomTypeId", SqlDbType.Int).Value = cboRoomType.SelectedValue;
                cmd.Parameters.Add("@RoomPositionId", SqlDbType.Int).Value = cboRoomPosition.SelectedValue;
                cmd.Parameters.Add("@RoomPriceId", SqlDbType.Int).Value = txtRoomPriceId.Text;
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = img;

                ExectueMyQuery(cmd, "Updating Room is success.");
                FilldgRoomDatas();
                Clear();
            }
            catch
            {
                MessageBox.Show("Warning!, Please check, something wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM TblRooms WHERE RoomId = @RoomId";
            SqlCommand cmd = new SqlCommand(query, consql);
            cmd.Parameters.AddWithValue("@RoomId", txtRoomId.Text);
            ExectueMyQuery(cmd, "Deleting Room is Success!");
            FilldgRoomDatas();
            Clear();
        }
    } 
}


