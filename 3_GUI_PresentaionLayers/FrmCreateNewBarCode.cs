using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmCreateNewBarCode : Form
    {
        private string mahh = "";
        private int id;
        private int idcthh;
        private string tenhh = "";
        private string nsx = "";
        private string danhmuc = "";
        private string trangthai = "";
        private string mavach = "";
        private string soluong = "";
        private string gianhap = "";
        private string giaban = "";
        private DateTime? ngaynhap;
        private string tenchatlieu = "";
        private string tenvatchua = "";
        private string nhomhuong = "";
        private string tennquocgia = "";
        private string sodungtich = "";
        private string anh = "";
        private DateTime? hsd;
        private string model = "";
        public string sender = "";
        public FrmCreateNewBarCode(int id, int idcthh, string mahh, string tenhh, string nsx, string danhmuc, string trangthai, string mavach, string soluong,
            string gianhap, string giaban, DateTime ngaynhap, string tenchatlieu, string tenvatchua, string nhomhuong, string tenquocgia,
            string sodungtich, string anh, DateTime hsd, string model)
        {
            InitializeComponent();
            this.mahh = mahh;
            this.id = id;
            this.idcthh = idcthh;
            this.tenhh = tenhh;
            this.nsx = nsx;
            this.danhmuc = danhmuc;
            this.trangthai = trangthai;
            this.mavach = mavach;
            this.soluong = soluong;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.ngaynhap = ngaynhap;
            this.tenchatlieu = tenchatlieu;
            this.tenvatchua = tenvatchua;
            this.nhomhuong = nhomhuong;
            this.tennquocgia = tenquocgia;
            this.sodungtich = sodungtich;
            this.anh = anh;
            this.hsd = hsd;
            this.model = model;
            t1.Visible = false;
            t2.Visible = false;
            t3.Visible = false;
            t4.Visible = false;
            t5.Visible = false;
            t6.Visible = false;
            lb1.Visible = false;
            lb2.Visible = false;
            lb3.Visible = false;
            lb4.Visible = false;
            lb4.Visible = false;
            lb5.Visible = false;
            lb6.Visible = false;
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
         
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

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("bạn có muốn tạo mã QR Code hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                QRCodeGenerator qRCode = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCode.CreateQrCode(txt_QRcode.Text, QRCodeGenerator.ECCLevel.L);
                QRCode qR = new QRCode(qRCodeData);
                Pic_QRcode.Image = qR.GetGraphic(5);
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Tạo Mã QR Code Thành Công");

                }

                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Tạo Mã QR Code Thất Bại ");

                }
                return;
            }
           
        }

        



        private void pictureBox9_Click(object sender, EventArgs e)
        {
            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            lb1.Visible = true;
            lb2.Visible = true;
            lb3.Visible = true;
            lb4.Visible = true;
            lb4.Visible = true;
            lb5.Visible = true;
            lb6.Visible = true;
            p1.Visible = true;
            p2.Visible = true;
            p3.Visible = true;
            p4.Visible = true;
            p5.Visible = true;
            p6.Visible = true;
        
            StringBuilder builder = new StringBuilder();
                t1.Text= Convert.ToString(builder.Append(RandomString(4, true)));
                
                t2.Text = Convert.ToString(builder.Append(RandomString(4, true)));
          
                t3.Text = Convert.ToString(builder.Append(RandomString(4, true)));
             
                t4.Text = Convert.ToString(builder.Append(RandomString(4, true)));
           
                t5.Text = Convert.ToString(builder.Append(RandomString(4, true)));
            
                t6.Text = Convert.ToString(builder.Append(RandomString(4, true)));
            //1
            QRCodeGenerator qRCode0 = new QRCodeGenerator();
            QRCodeData qRCodeData0 = qRCode0.CreateQrCode(t1.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR0 = new QRCode(qRCodeData0);
            p1.Image = qR0.GetGraphic(5);

            //2
            QRCodeGenerator qRCode2 = new QRCodeGenerator();
            QRCodeData qRCodeData2 = qRCode2.CreateQrCode(t2.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR2 = new QRCode(qRCodeData2);
            p2.Image = qR2.GetGraphic(5);
            //3
            QRCodeGenerator qRCode3 = new QRCodeGenerator();
            QRCodeData qRCodeData3 = qRCode3.CreateQrCode(t3.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR3 = new QRCode(qRCodeData3);
            p3.Image = qR3.GetGraphic(5);
            //4
            QRCodeGenerator qRCode4 = new QRCodeGenerator();
            QRCodeData qRCodeData4 = qRCode4.CreateQrCode(t4.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR4 = new QRCode(qRCodeData4);
            p4.Image = qR4.GetGraphic(5);
            //5
            QRCodeGenerator qRCode5 = new QRCodeGenerator();
            QRCodeData qRCodeData5 = qRCode5.CreateQrCode(t5.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR5 = new QRCode(qRCodeData5);
            p5.Image = qR5.GetGraphic(5);
            //6
            QRCodeGenerator qRCode6 = new QRCodeGenerator();
            QRCodeData qRCodeData6 = qRCode6.CreateQrCode(t6.Text, QRCodeGenerator.ECCLevel.L);
            QRCode qR6= new QRCode(qRCodeData6);
            p6.Image = qR6.GetGraphic(5);

        }
        //checkedchanged
        #region
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
            {
                sender = Convert.ToString(t1.Text);
                chk0.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;

            }
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk3.Checked)
            {
                sender = Convert.ToString(t3.Text);
                chk1.Checked = false;
                chk2.Checked = false;
                chk0.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;

            }
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk5.Checked)
            {
                sender =Convert.ToString( t5.Text);
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk0.Checked = false;
                chk6.Checked = false;

            }
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                sender = Convert.ToString(t2.Text);
                chk1.Checked = false;
                chk0.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;

            }
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk4.Checked)
            {
                sender = Convert.ToString(t4.Text);
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk0.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;

            }
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk6.Checked)
            {
                sender = Convert.ToString(t6.Text);//System.Windows.Forms.PictureBox, SizeMode: Zoom
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk0.Checked = false;

            }
        }
        private void chk0_CheckedChanged(object sender, EventArgs e)
        {
            if (chk0.Checked)
            {
                sender = Convert.ToString(txt_QRcode.Text);
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;


            }
        }
        #endregion


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Frm_EditHangHoa frm_EditHangHoa = new Frm_EditHangHoa(id, idcthh, mahh, tenhh, nsx, danhmuc, trangthai,Convert.ToString(sender), soluong, gianhap, giaban, Convert.ToDateTime(ngaynhap), tenchatlieu, tenvatchua, nhomhuong, tennquocgia, sodungtich, anh, Convert.ToDateTime(hsd), model);
                frm_EditHangHoa.Show();
               // this.Close();
                for (int i = 0; i < 2; i++)
                {
                   
                    this.Alert("Thêm Mã Vạch Thành Công");

                }
                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thêm Mã Vạch Thất Bại ");

                }
                return;
            }

        }

        private void print(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Pic_QRcode.Width, Pic_QRcode.Height);
            Pic_QRcode.DrawToBitmap(bitmap, new Rectangle(0, 0, Pic_QRcode.Width, Pic_QRcode.Height));
            e.Graphics.DrawImage(bitmap,0, 0);
            bitmap.Dispose();

        }

        private void pic_printer_Click(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show("bạn có in mã QR code thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += print;
                pd.Document = printDocument;

                if (pd.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
              
               
                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Tạo File PDF Thất Bại ");

                }
                return;
            }

           

        }

        
    }
}
