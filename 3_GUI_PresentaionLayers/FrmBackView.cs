using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmBackView : Form
    {

        private string mahh = "";
        private int id ;
        private string tenhh = "";
        private string nsx = "";
        private string danhmuc = "";
        private string trangthai="" ;
        private string mavach = "";
        private string soluong ="";
        private string gianhap ="";
        private string giaban ="";
        private DateTime? ngaynhap;
        private string tenchatlieu = "";
        private string tenvatchua = "";
        private string nhomhuong = "";
        private string tennquocgia = "";
        private string sodungtich = "";
        private string anh = "";

        public FrmBackView(int id,string mahh,string tenhh, string nsx,string danhmuc, string trangthai, string mavach,string soluong,
           string gianhap, string giaban,DateTime ngaynhap, string tenchatlieu, string tenvatchua, string nhomhuong, string tenquocgia,
           string sodungtich, string anh)
        {
            InitializeComponent();
            this.mahh = mahh;
            this.id = id;
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
            cbo_mahh.Text = mahh;
            txt_tenhh.Text = tenhh;
            cbo_nsx.Text = nsx;
            cbo_danhmuc.Text = danhmuc;
            chk_conhang.Checked =trangthai=="Còn Hàng";
            chk_hethang.Checked =trangthai=="Hết Hàng";
            txt_mavach.Text = mavach;
            txt_soluong.Text = soluong;
            txt_gianhap.Text = gianhap;
            txt_giaban.Text = giaban;
            dtp_ngaynhap.Value = ngaynhap;
            cbo_tencl.Text = tenchatlieu;
            cbo_tenvatchua.Text = tenvatchua;
            cbo_tennhomhuong.Text = nhomhuong;
            cbo_tenquocgia.Text = tenquocgia;
            cbo_soduntich.Text = sodungtich;
            txt_anh.Text = anh;
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
       
        private void FrmBackView_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;

        }
        private void cbo_tenquocgia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_cammera_Click(object sender, EventArgs e)
        {
          
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txt_mavach.Invoke(new MethodInvoker(delegate ()
                {
                    txt_mavach.Text = result.ToString();
                }));
            }
            pic_cammera.Image = bitmap;
        }

        private void FrmBackView_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

            if (videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
                


        }
    }
}
