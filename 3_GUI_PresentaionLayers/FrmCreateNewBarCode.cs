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

        



       


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Frm_EditHangHoa frm_EditHangHoa = new Frm_EditHangHoa(id, idcthh, mahh, tenhh, nsx, danhmuc, trangthai,Convert.ToString(txt_QRcode.Text), soluong, gianhap, giaban, Convert.ToDateTime(ngaynhap), tenchatlieu, tenvatchua, nhomhuong, tennquocgia, sodungtich, anh, Convert.ToDateTime(hsd), model);

                this.Hide();
                for (int i = 0; i < 2; i++)
                {
                   
                    this.Alert("Thêm Mã Vạch Thành Công");

                }
                
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
