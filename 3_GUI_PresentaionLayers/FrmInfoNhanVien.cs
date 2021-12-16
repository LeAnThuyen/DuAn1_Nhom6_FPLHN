using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmInfoNhanVien : Form
    {
        Attachment attach = null;
        public static FrmInfoNhanVien backsender;
        public Label lbl1;
        public Label lbl2;
    
        public PictureBox pic;
        public FrmInfoNhanVien()
        {
            InitializeComponent();
            loadpic();
            backsender = this;
            lbl1 = lbl_tennv;
            lbl2 = lbl_email;
            pic = pictureBox1;

        }
        void loadpic()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        private void FrmInfoNhanVien_Load(object sender, EventArgs e)
        {

        }
        void SendEmail(string to, string subject, string mess, Attachment attachment)
        {


            MailMessage mailMessage = new MailMessage("leanthuyen08122002.work@gmail.com", to, subject, mess);
            if (attach != null)
            {
                mailMessage.Attachments.Add(attach);
            }
            mailMessage.IsBodyHtml = true;
            string newLine = Environment.NewLine;
            String body = "<br />Đây Là Toàn Bộ Doanh Thu Của Ngày Tính Đến 21h";
            mailMessage.Body = mess + body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("leanthuyen08122002.work@gmail.com", "anthuyenle08");
            smtpClient.Send(mailMessage);


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmHideSendEmail frmHideSendEmail = new FrmHideSendEmail();
            frmHideSendEmail.Show();
            frmHideSendEmail.Hide();
           
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Đăng Xuất Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                DateTime timer = DateTime.Now;
                int a = timer.Hour;
                int b = timer.Minute;
                FileInfo file = new FileInfo(@"C:\persoftdaily.xlsx");
                attach = new Attachment(@"C:\persoftdaily.xlsx");
                if (a > 6 && b >=0)
                {
                    SendEmail("thuyenlaph16978@fpt.edu.vn", "Doanh Thu Hằng Ngày", "Mời Anh Xem File Thống Kê Doanh Thu Ngày Hôm Nay ạ", attach);
                    FormDangNhap formDangNhap = new FormDangNhap();
                    formDangNhap.Show();
                    this.Hide();
                    
                }
                else{
                    FormDangNhap formDangNhap = new FormDangNhap();
                    formDangNhap.Show();
                    this.Hide();
                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau("thuyenlaph16978@fpt.edu.vn");
            frmDoiMatKhau.Show();
            this.Hide();
        }
    }
}
