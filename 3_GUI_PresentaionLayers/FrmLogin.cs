using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmLogin : Form
    {
        private IServiceForDangNhap iserlogin;
        private Button currentButton;
        public Button btnsp;
        public Button btnkh;
        public Button btnnv;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //sender
        //
        public static FrmLogin backsender;
        public Label lbl;
        public TextBox txt;
        public TextBox txt1;
        public Button btntk;
        public Button btnqlnv;
        public PictureBox pic;
      
        public int role;
        public string email;
        public string anhs;
    
        public FrmLogin()
        {
            InitializeComponent();
            iserlogin = new DangNhapServies();
          
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //
           
            pic = pictureBox4;
            backsender = this;
            txt = txt_email;
          //  btnsp = btnSanPham;
            txt1 = txt_ten;
            btnkh = button4;
          
           btntk = btn_thongke;
            btnqlnv = btn_quanlynhanvien;
            loadpic();
            txt_ten.Visible = false;

        }
        void loadpic()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox4.Width - 3, pictureBox4.Height - 3);
            Region rg = new Region(gp);
            pictureBox4.Region = rg;
        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;


        }


        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitle.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
          
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tmr_time_Tick(object sender, EventArgs e)
        {
            DateTime tn = DateTime.Now;
            lblTime.Text = tn.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void tbDark_CheckedChanged(object sender, EventArgs e)
        {
            
            if (tbDark.Checked)
            {
                this.BackColor = Color.RosyBrown;

            }
            else
            {
                this.BackColor = Color.DarkOliveGreen;

            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblPer.ForeColor = lblPer.ForeColor == Color.Transparent ? Color.Red : Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSanPham(), sender);
            lblTitle.Text = "FormSanPham";
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanHang(), sender);
        }
        int x = 112, y = 23, a = 1;

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTinhTrangHoaDon(), sender);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //sender
            FrmInfoNhanVien frmInfoNhanVien = new FrmInfoNhanVien();
            FrmInfoNhanVien.backsender.lbl2.Text = txt_email.Text;
            FrmInfoNhanVien.backsender.pic.Image = pictureBox4.Image;
            FrmInfoNhanVien.backsender.lbl1.Text = txt_ten.Text;
            frmInfoNhanVien.Show();




        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            System.Timers.Timer myTimer = new System.Timers.Timer();
            // Set the Interval to 5 seconds (5000 milliseconds).
            myTimer.Interval = 5000;
            myTimer.AutoReset = true;
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Enabled = true;
            
        }
        public void myTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
         
        }

        private void time_autosendemil_Tick(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThongKeALL(), sender);
        }

        private void btn_quanlynhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien(), sender);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhachHang(), sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                lblTitle.Location = new Point(x, y);
                if (x >= 742)
                {
                    a = -1;
                    lblTitle.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                }
                if (x <= 23)
                {
                    a = 1;
                    lblTitle.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
