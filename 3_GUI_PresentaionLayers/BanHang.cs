using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections;
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
    public partial class BanHang : Form
    {
        private QlyHangHoaServices qlhhser;
        private QLyBanHangServices _qlbanhangser;
        public BanHang()
        {
            InitializeComponent();
            _qlbanhangser = new QLyBanHangServices();
            qlhhser = new QlyHangHoaServices();
            loadsanpham();
            dgrid_sanpham.AllowUserToAddRows = false;
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



        }

    void loadsanpham()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 7;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[2].Name = "Giá Bán";
            dgrid_sanpham.Columns[3].Name = "Số Lượng Tồn Kho";
          //  dgrid_sanpham.Columns[4].Name = "Số Lượng Muốn Mua";
            dgrid_sanpham.Columns[4].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[5].Name = "Dường Dẫn";
            dgrid_sanpham.Columns[5].Visible =false;
            dgrid_sanpham.Columns[6].Name = "Hạn Sử Dụng";
            //
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Ảnh";
            img.Name = "img_sp";
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dgrid_sanpham.Columns.Add(img);
        
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgrid_sanpham.Columns.Add(cbo);

            ////
            
            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
        
            dgrid_sanpham.Columns.Add(btn);
            btn.UseColumnTextForButtonValue = true;
          
            dgrid_sanpham.Rows.Clear();
            foreach(var x in qlhhser.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.SoLuong,x.DungTich.SoDungTich,x.Anh.DuongDan,x.ChiTietHangHoa.HanSuDung) ;
            }
          
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
         
        }

        private void tbDark_CheckedChanged_1(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label17.Text = DateTime.Now.ToLongDateString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dịtMẹMàyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongTinBanHang(), sender);
           
        }

        private void thôngTinToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormMoRong(), sender);
        }

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
                if (e.RowIndex == _qlbanhangser.GetsList().Count || e.RowIndex < -1)
                {
                    return;
                }
                if (string.IsNullOrEmpty(dgrid_sanpham.Rows[e.RowIndex].Cells["Dường Dẫn"].Value.ToString())) return;
                dgrid_sanpham.Rows[e.RowIndex].Cells["img_sp"].Value = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells["Dường Dẫn"].Value));
            
        }

        private void BanHang_Load(object sender, EventArgs e)
        {

           // dgrid_sanpham.Rows[e.RowIndex].Cells["img_sp"].Value = Image.FromFile(Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells["Dường Dẫn"].Value));
        }

        private void dgrid_sanpham_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
