using _1_DAL_DataAccessLayer.DALServices;
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

namespace _3_GUI_PresentaionLayers
{
    public partial class FormSanPham : Form
    {
        private QlyHangHoaServices qlhhser;
        private ChiTietHangHoaServices _cthhser;
       
        private static FormSanPham _sender;
     
        public FormSanPham()
        {
            InitializeComponent();
            _sender = this;
            qlhhser = new QlyHangHoaServices();
            _cthhser = new ChiTietHangHoaServices();
            loaddata();

            loadloc();
        }
        #region
        private void menuChatLieu_Click_1(object sender, EventArgs e)
        {
            FormChatLieu formChatLieu = new FormChatLieu();
            formChatLieu.ShowDialog();
        }

        private void menuDungTich_Click_1(object sender, EventArgs e)
        {
            FormDungTich formDungTich = new FormDungTich();
            formDungTich.ShowDialog();
        }

        private void menuNhomHuong_Click_1(object sender, EventArgs e)
        {
            Frmnhomhuong frmNhomHuong = new Frmnhomhuong();
            frmNhomHuong.ShowDialog();
        }

        private void menuVatChua_Click_1(object sender, EventArgs e)
        {
            FrmVatChua frmVatChua = new FrmVatChua(); //Khởi tạo đối tượng
            frmVatChua.ShowDialog(); //Hiển thị
        }

        private void menuXuatXu_Click_1(object sender, EventArgs e)
        {
            FormXuatXu formXuatXu = new FormXuatXu();
            formXuatXu.ShowDialog();
        }

        private void manuAnh_Click_1(object sender, EventArgs e)
        {
            FrmAnh frmAnh = new FrmAnh(); //Khởi tạo đối tượng
            frmAnh.ShowDialog(); //Hiển thị
        }
        #endregion
        void loadloc()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Giá");
            row.Add("Số Lượng");
            row.Add("Số Dung Tích");
            row.Add("Hạn Sử Dụng");
            cbo_loc.Items.AddRange(row.ToArray());
        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void loaddata()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 20;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDHH";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[3].Name = "Mã Vạch";
            dgrid_sanpham.Columns[4].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[5].Name = "Nhà Sản Xuất";
            dgrid_sanpham.Columns[6].Name = "Danh Mục";
            dgrid_sanpham.Columns[7].Name = "Trạng Thái";
            dgrid_sanpham.Columns[8].Name = "Số Lượng";
            dgrid_sanpham.Columns[9].Name = "Gía Nhập";
            dgrid_sanpham.Columns[10].Name = "Gía Bán";
            dgrid_sanpham.Columns[11].Name = "Ngày Nhập Kho";
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            dgrid_sanpham.Columns[19].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[19].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa,x.ChiTietHangHoa.IdthongTinHangHoa ,x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        public static void loaddatasender()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

           _sender.dgrid_sanpham.ColumnCount = 20;
            _sender.dgrid_sanpham.Columns[0].Name = "IDHH";
            _sender.dgrid_sanpham.Columns[0].Visible = false;
            _sender.dgrid_sanpham.Columns[1].Name = "IDHH";
            _sender.dgrid_sanpham.Columns[1].Visible = false;
            _sender.dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            _sender.dgrid_sanpham.Columns[3].Name = "Mã Vạch";
            _sender.dgrid_sanpham.Columns[4].Name = "Tên Hàng Hóa";
            _sender.dgrid_sanpham.Columns[5].Name = "Nhà Sản Xuất";
            _sender.dgrid_sanpham.Columns[6].Name = "Danh Mục";
            _sender.dgrid_sanpham.Columns[7].Name = "Trạng Thái";
            _sender.dgrid_sanpham.Columns[8].Name = "Số Lượng";
            _sender.dgrid_sanpham.Columns[9].Name = "Gía Nhập";
            _sender.dgrid_sanpham.Columns[10].Name = "Gía Bán";
            _sender.dgrid_sanpham.Columns[11].Name = "Ngày Nhập Kho";
            //   dgrid_sanpham.Columns[10].Visible = false;
            _sender.dgrid_sanpham.Columns[12].Name = "Tên Chất Liệu";
            _sender.dgrid_sanpham.Columns[12].Visible = false;
            _sender.dgrid_sanpham.Columns[13].Name = "Tên Vật Chứa";
            _sender.dgrid_sanpham.Columns[13].Visible = false;
            _sender.dgrid_sanpham.Columns[14].Name = "Nhóm Hương";
            _sender.dgrid_sanpham.Columns[14].Visible = false;
            _sender.dgrid_sanpham.Columns[15].Name = "Tên Quốc Gia";
            _sender.dgrid_sanpham.Columns[15].Visible = false;
            _sender.dgrid_sanpham.Columns[16].Name = "Số Dung Tích";
            _sender.dgrid_sanpham.Columns[16].Visible = false;
            _sender.dgrid_sanpham.Columns[17].Name = "Ảnh";// đường dẫn
            _sender.dgrid_sanpham.Columns[17].Visible = false;
            _sender.dgrid_sanpham.Columns[18].Name = "Hạn Sử Dụng";// đường dẫn
            _sender.dgrid_sanpham.Columns[18].Visible = false;
            _sender.dgrid_sanpham.Columns[19].Name = "Model";// đường dẫn
            _sender.dgrid_sanpham.Columns[19].Visible = false;
            // combobox
            _sender.dgrid_sanpham.Rows.Clear();
            foreach (var x in _sender.qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1))
            {
                _sender.dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.ChiTietHangHoa.IdthongTinHangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }

        void loaddatafortimkiem(string ma)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 20;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDHH";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[3].Name = "Mã Vạch";
            dgrid_sanpham.Columns[4].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[5].Name = "Nhà Sản Xuất";
            dgrid_sanpham.Columns[6].Name = "Danh Mục";
            dgrid_sanpham.Columns[7].Name = "Trạng Thái";
            dgrid_sanpham.Columns[8].Name = "Số Lượng";
            dgrid_sanpham.Columns[9].Name = "Gía Nhập";
            dgrid_sanpham.Columns[10].Name = "Gía Bán";
            dgrid_sanpham.Columns[11].Name = "Ngày Nhập Kho";
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            dgrid_sanpham.Columns[19].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[19].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.MaHangHoa.StartsWith(txt_timkiem.Text)))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa,x.ChiTietHangHoa.IdthongTinHangHoa ,x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }

        private void dgrid_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int idhh = Convert.ToInt32(dgrid_sanpham.Rows[e.RowIndex].Cells[0].Value);
            int idcthh = Convert.ToInt32(dgrid_sanpham.Rows[e.RowIndex].Cells[1].Value);
            string mahh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[2].Value);
            string mavach = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[3].Value);

            string tenhh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[4].Value);
            string nsx = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[5].Value);
            string danhmuc = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[6].Value);
            string trangthai = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[7].Value);
            string soluong = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[8].Value);
            string dongianhap = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[9].Value);
            string dongiaban = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[10].Value);
            DateTime ngaynhapkho = Convert.ToDateTime(dgrid_sanpham.Rows[e.RowIndex].Cells[11].Value);
            string tencl = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[12].Value);
            string tenvt = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[13].Value);
            string nhomhuong = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[14].Value);
            string tenquocgia = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[15].Value);
            string sodungtich = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[16].Value);
            string anh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[17].Value);
            DateTime hsd = Convert.ToDateTime(dgrid_sanpham.Rows[e.RowIndex].Cells[18].Value);
            string model = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[19].Value);
            this.Alert("Chào Mừng Bạn Đến Với Thông Tin Chi Tiết Sản Phẩm");
            FrmBackView frmBackView = new FrmBackView(idhh,idcthh ,mahh, tenhh, nsx, danhmuc, trangthai, mavach, soluong, dongianhap, dongiaban, ngaynhapkho, tencl, tenvt, nhomhuong, tenquocgia, sodungtich, anh, hsd, model);



            frmBackView.Show();
            




        }
        #region
        void loaddataforloc(string locgia)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();

            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1).OrderByDescending(c => c.ChiTietHangHoa.DonGiaBan))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        void loaddataforlocdungtuch(string dungtich)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();

            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1).OrderByDescending(c => c.DungTich.SoDungTich))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        void loaddataforlochsd(string hsd)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();

            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1).OrderByDescending(c => c.ChiTietHangHoa.HanSuDung))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        void loaddataforlocsoluong(string soluong)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
           
            dgrid_sanpham.Rows.Clear();

            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1).OrderByDescending(c => c.ChiTietHangHoa.SoLuong))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        #endregion

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void dgrid_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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




        private void txt_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_loc.Text == "Giá")
            {
                loaddataforloc("Giá");
                return;
            }
            if (cbo_loc.Text == "Số Lượng")
            {
                loaddataforlocsoluong("Số Lượng");
                return;
            }
            if (cbo_loc.Text == "Dung Tích")
            {
                loaddataforlocdungtuch("Dung Tích");
                return;
            }
            if (cbo_loc.Text == "Hạn Sử Dụng")
            {
                loaddataforlochsd("Hạn Sử Dụng");
                return;
            }
            if (cbo_loc.Text == "")
            {
                loaddata();
                return;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            label4.Text = DateTime.Now.ToLongDateString();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);

        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm số lượng Lớn sản phẩm bằng file excel hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FrmAddDataFormExcelToDB frmAddDataFormExcelToDB = new FrmAddDataFormExcelToDB();
                for (int a = 0; a < 2; a++)
                {
                    this.Alert("Hãy Tiến Hành Thêm Số Lượng Lớn Thôi Nào !");

                }
                frmAddDataFormExcelToDB.Show();
               

            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }

          
            
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            
        }

        #region
        //lọc
        void loaddatafornam()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
          
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IddanhMuc == 0))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //nữ
        void loaddatafornu()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IddanhMuc == 1))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //unisex
        void loaddataforuni()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
          
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IddanhMuc == 3))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //LV
        void loaddataforlv()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IdnhaSanXuat == 0))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //Gucci
        void loaddataforgucci()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IdnhaSanXuat == 2))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //Roja
        void loaddataforRoja()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IdnhaSanXuat == 2))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //Morra
        void loaddataforMorra()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IdnhaSanXuat == 3))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //Chanel
        void loaddataforchanel()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.HangHoa.IdnhaSanXuat == 4))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }

        //50ml
        void loaddatafor50ml()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IddungTich == 0))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //100ml
        void loaddatafor100ml()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IddungTich == 1))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //150ml
        void loaddatafor150ml()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IddungTich == 3))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //200ml
        void loaddatafor200ml()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IddungTich == 3))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //duoi500k
        void loaddataforchuoi500()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.DonGiaBan < 500))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //51
        void loaddatafor51()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.DonGiaBan > 500000 && c.ChiTietHangHoa.DonGiaBan < 1000000))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //12
        void loaddatafor12()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.DonGiaBan > 1000000 && c.ChiTietHangHoa.DonGiaBan < 2000000))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //tren2
        void loaddatafortren2()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
            
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.DonGiaBan > 2000000))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //buoi
        void loaddataforbuoi()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IdnhomHuong == 2))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //lavender
        void loaddataforlavender()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IdnhomHuong == 1))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        //hoa ly
        void loaddataforhoaly()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgrid_sanpham.ColumnCount = 19;
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
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
            dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
            dgrid_sanpham.Columns[18].Visible = false;
           
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1 && c.ChiTietHangHoa.IdnhomHuong == 3))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }


        }
        #endregion




        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loaddatafortimkiem(txt_timkiem.Text);
        }

        private void txt_timkiem_Leave(object sender, EventArgs e)
        {
            if (txt_timkiem.Text == "")
            {


                loaddata();
                return;
            }
        }
        #region
        private void chk_locnam_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_locnam.Checked)
            {
                loaddatafornam();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;

            }
        }

        private void chk_locnu_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_locnu.Checked)
            {
                loaddatafornu();
                chk_locnam.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_unisex_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_unisex.Checked)
            {
                loaddataforuni();
                chk_locnu.Checked = false;
                chk_locnam.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }


        }

        private void chk_LV_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_LV.Checked)
            {

                loaddataforlv();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_locnam.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;

            }

        }

        private void chk_gucci_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_gucci.Checked)
            {

                loaddataforgucci();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_locnam.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;

            }

        }

        private void chk_Roja_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Roja.Checked)
            {
                loaddataforRoja();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_locnam.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)//morra
        {
            if (checkBox3.Checked)
            {
                loaddataforMorra();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                chk_locnam.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_chanel_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_chanel.Checked)
            {
                loaddataforchanel();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_locnam.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;

            }

        }

        private void chk_50ml_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_50ml.Checked)
            {

                loaddatafor50ml();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_locnam.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_100ml_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_100ml.Checked)
            {

                loaddatafor100ml();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_locnam.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;

            }

        }

        private void chk_150ml_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_150ml.Checked)
            {
                loaddatafor150ml();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_locnam.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }





        private void chk_200ml_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_200ml.Checked)
            {

                loaddatafor200ml();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_locnam.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_under500_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_under500.Checked)
            {

                loaddataforchuoi500();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_locnam.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk51_CheckedChanged(object sender, EventArgs e)
        {
            if (chk51.Checked)
            {

                loaddatafor51();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk_locnam.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_12.Checked)
            {

                loaddatafor12();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_locnam.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_tren2tr_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_tren2tr.Checked)
            {
                loaddatafortren2();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_locnam.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_buoi_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_buoi.Checked)
            {
                loaddataforbuoi();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_locnam.Checked = false;
                chk_Lavender.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_Lavender_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Lavender.Checked)
            {

                loaddataforlavender();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_locnam.Checked = false;
                chk_hoaly.Checked = false;
            }

        }

        private void chk_hoaly_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Lavender.Checked)
            {

                loaddataforhoaly();
                chk_locnu.Checked = false;
                chk_unisex.Checked = false;
                chk_LV.Checked = false;
                chk_gucci.Checked = false;
                chk_Roja.Checked = false;
                checkBox3.Checked = false;
                chk_chanel.Checked = false;
                chk_50ml.Checked = false;
                chk_100ml.Checked = false;
                chk_150ml.Checked = false;
                chk_200ml.Checked = false;
                chk_under500.Checked = false;
                chk51.Checked = false;
                chk_12.Checked = false;
                chk_tren2tr.Checked = false;
                chk_buoi.Checked = false;
                chk_Lavender.Checked = false;
                chk_locnam.Checked = false;
            }

        }

        #endregion
        void InHoaDon()
        {
            ppDSanPham.Document = pDSanPham;
            ppDSanPham.ShowDialog();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            InHoaDon();
        }

        private void pDSanPham_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            var w = pDSanPham.DefaultPageSettings.PaperSize.Width;
            //Lấy tên cửa hàng

            e.Graphics.DrawString(
                "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 20));
            e.Graphics.DrawString(
                "Danh sách sản phẩm".ToUpper(), new Font("Courier New", 18, FontStyle.Bold), Brushes.Black, new PointF(300, 110));
            //Mã hóa đơn

            //e.Graphics.DrawString(
            //    String.Format("NV{0}", _i),
            //    new Font("Courier New", 12, FontStyle.Bold),
            //    Brushes.Black, new PointF(w / 2 + 200, 20));

            ////Dịa chỉ sdt
            //e.Graphics.DrawString(
            //    String.Format("{0} - {1}", ten, ten),
            //    new Font("Courier New", 8, FontStyle.Bold),
            //    Brushes.Black, new PointF(100, 45));

            //Ngày giờ xuất sản phẩm

            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new PointF(w / 2 + 200, 45));

            Pen blackPEn = new Pen(Color.Black, 1);
            var y = 70;



        }

        private void FormSanPham_Load(object sender, EventArgs e)
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

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn xuất file pdf  hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                ReportFileToPDF reportFileToPDF = new ReportFileToPDF();
                reportFileToPDF.Show();
                for (int a = 0; a < 1; a++)
                {
                    this.Alert("Hãy Tiến Hành Xuát Ra File PDF Thôi Nào !");

                }
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }

           
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frmDanhMuc = new FrmDanhMuc();
            frmDanhMuc.ShowDialog();
        }
    }
}
