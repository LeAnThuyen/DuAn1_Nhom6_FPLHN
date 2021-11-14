using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmThongBao : Form
    {

        public static FrmThongBao backsender;
        public RichTextBox rtx;
        public FrmThongBao()
        {
            InitializeComponent();
            backsender = this;
            rtx = rtx_noticafitions;
            loadsugesstion();
        }
        public void loadsugesstion()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=TANA\\SQLEXPRESS;Initial Catalog=duan1;Persist Security Info=True;User ID=thuyen;Password=123";

            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("select TenNhanVien FROM NhanVien Where IDRole=1", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlDataReader dr = sqlCommand.ExecuteReader();

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }


            cbo_tennv.AutoCompleteCustomSource = col;
            connection.Close();
        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
        }

        private void pic_send_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {


                this.Close();
             
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
