using _1_DAL_DataAccessLayer.Models;
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

namespace _3_GUI_PresentaitonLayer
{
    public partial class FormSanPham : Form
    {
        private QlyHangHoaServices qlhhser;
       
        public FormSanPham()
        {
            InitializeComponent();
            qlhhser = new QlyHangHoaServices();
            loaddata();
        }
        #region
        private void menuChatLieu_Click_1(object sender, EventArgs e)
        {
            ChatLieu frmChatLieu = new ChatLieu(); //Khởi tạo đối tượng
           // frmChatLieu.ShowDialog(); //Hiển thị
        }

        private void menuDungTich_Click_1(object sender, EventArgs e)
        {
            DungTich frmDungTich = new DungTich(); //Khởi tạo đối tượng
            frmDungTich.ShowDialog(); //Hiển thị
        }

        private void menuNhomHuong_Click_1(object sender, EventArgs e)
        {
            NhomHuong frmNhomHuong = new NhomHuong();
            frmNhomHuong.ShowDialog();
        }

        private void menuVatChua_Click_1(object sender, EventArgs e)
        {
            VatChua frmVatChua = new VatChua(); //Khởi tạo đối tượng
            frmVatChua.ShowDialog(); //Hiển thị
        }

        private void menuXuatXu_Click_1(object sender, EventArgs e)
        {
            XuatXu frmXuatXu = new XuatXu(); //Khởi tạo đối tượng
            frmXuatXu.ShowDialog(); //Hiển thị
        }

        private void manuAnh_Click_1(object sender, EventArgs e)
        {
            Anh frmAnh = new Anh(); //Khởi tạo đối tượng
            frmAnh.ShowDialog(); //Hiển thị
        }
        #endregion


        void loaddata()
        {
            //ArrayList row = new ArrayList();

            //row = new ArrayList();
            //row.Add("Thêm");
            //row.Add("Sửa");
            //row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[2].Name = "Mã Vạch";
            dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[4].Name = "Nhà Sản Xuất";
            dgrid_sanpham.Columns[5].Name = "Danh Mục";
            dgrid_sanpham.Columns[6].Name = "Trạng Thái";
            dgrid_sanpham.Columns[7].Name = "Số Lượng";
            dgrid_sanpham.Columns[8].Name = "Gía Nhập";
            dgrid_sanpham.Columns[9].Name = "Gía Bán";
            dgrid_sanpham.Columns[10].Name = "Ngày Nhập Kho";
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
                                                   //combobox
            //DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            //cbo.HeaderText = "Chức Năng";
            //cbo.Name = "cbo";
            //cbo.Items.AddRange(row.ToArray());
            //dgrid_sanpham.Columns.Add(cbo);

            ////

            ////button
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.Text = "Xác Nhận";
            //btn.HeaderText = "Xác Nhận";
            //btn.Name = "btn";
            //btn.UseColumnTextForButtonValue = true;
            //dgrid_sanpham.Columns.Add(btn);
            ////ảnh
            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //img.HeaderText = "Ảnh Hàng Hóa";
            //img.Name = "img_nv";
            //img.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dgrid_sanpham.Columns.Add(img);
            //dgrid_sanpham.Columns["img_nv"].Width = 100;
            //dgrid_sanpham.RowTemplate.Height = 80;
            dgrid_sanpham.Rows.Clear();
            foreach(var x in qlhhser.GetsList())
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa,x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai==1?"Còn Hàng":"Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich,x.Anh.DuongDan);
            }

        }

        private void dgrid_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
