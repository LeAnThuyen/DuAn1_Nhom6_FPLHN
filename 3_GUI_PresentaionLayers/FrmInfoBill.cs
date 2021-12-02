using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
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
    public partial class FrmInfoBill : Form
    {

        private IServicesHoaDon _hdser;
        private IKhachHangServices _ikhser;
        private IServicesNhanVien _invser;
        private int idhd;
        private int status;
        private HoaDonBan hd;
        public FrmInfoBill(int id)
        {
            InitializeComponent();
            _hdser = new HoaDonBanServices();
            _ikhser = new KhachHangService();
            _invser = new NhanVienServices();
            this.idhd = id;
            loadhd(id);
            //for (int i = 0; i < 1; i++)
            //{
            //    dgrid_info.Rows[i].Cells["cbo"].Value = Convert.ToString(_hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(idhd)).Select(c => c.TrangThai == 1 ? "Đã Thanh Toán" : (c.TrangThai == 0 ? "Đã Cọc" : (c.TrangThai == 2 ? "Chưa Thanh Toán" : (c.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy")))).FirstOrDefault());
            //}
            ddd();
        }










        void loadhd(int id)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Đã Thanh Toán");
            row.Add("Đã Hủy");
            row.Add("Chờ Giao Hàng");
            row.Add("Chưa Thanh Toán");
            row.Add("Đã Cọc");
            //
            ArrayList row1 = new ArrayList();

            row1 = new ArrayList();
            row1.Add("Sửa");
          
     
            
            dgrid_info.ColumnCount = 14;
            dgrid_info.Columns[0].Name = "ID";
            dgrid_info.Columns[0].Visible = false;
            dgrid_info.Columns[1].Name = "Mã Hóa Đơn";
            dgrid_info.Columns[2].Name = "Ngày Lập";
            dgrid_info.Columns[3].Name = "Ngày Ship";
            dgrid_info.Columns[4].Name = "Ngày Nhận";
            dgrid_info.Columns[5].Name = "Tiền";
            dgrid_info.Columns[5].Visible = false;
            dgrid_info.Columns[6].Name = "Thuế";
            dgrid_info.Columns[7].Name = "Tổng Số Tiền";
            dgrid_info.Columns[8].Name = "Tiền Cọc";
            dgrid_info.Columns[9].Name = "Tên Khách Hàng";
            dgrid_info.Columns[10].Name = "Tên Nhân Viên";
            dgrid_info.Columns[11].Name = "Ghi Chú";
            dgrid_info.Columns[12].Name = "Mã Khách Hàng";
            dgrid_info.Columns[12].Visible = false;
            dgrid_info.Columns[13].Name = "Mã Nhân Viên";
            dgrid_info.Columns[13].Visible = false;
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Trạng Thái";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
          
            dgrid_info.Columns.Add(cbo);
          
            //
            DataGridViewComboBoxColumn cbofun = new DataGridViewComboBoxColumn();
            cbofun.HeaderText = "Chức Năng";
            cbofun.Name = "cbo_fun";
            cbofun.Items.AddRange(row1.ToArray());
            dgrid_info.Columns.Add(cbofun);
            //
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgrid_info.Columns.Add(btn);
            dgrid_info.Rows.Clear();
            foreach(var x in _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == Convert.ToInt32(id))){


                var kh = _ikhser.getlstkhachhangformDB().Where(c => c.IdkhachHang == x.IdkhachHang).FirstOrDefault();
                var nv = _invser.getlstnhanvienfromDB().Where(c => c.Iduser == x.Iduser).FirstOrDefault();


                dgrid_info.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap, x.NgayShipHang, x.NgayNhanHang,x.Tien, x.Thue, x.TongSoTien, x.TienCoc, kh.TenKhachHang, nv.TenNhanVien, x.GhiChu,kh.MaKhachHang,nv.MaNhanVien);
               
            }
            
          
        }
        void ddd()
        {
           
        }
        private void dgrid_info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;

            if (e.ColumnIndex == 16 && string.IsNullOrEmpty(dgrid_info.Rows[rd].Cells["cbo_fun"].Value.ToString()) == false)
            {

                string commnad = dgrid_info.Rows[e.RowIndex].Cells["cbo_fun"].Value.ToString();

                if (commnad == "Sửa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                      
                        if(Convert.ToString( dgrid_info.Rows[rd].Cells["cbo"].Value)==Convert.ToString("Đã Thanh Toán"))
                        {
                            status = 1;
                           
                        }
                        if (Convert.ToString(dgrid_info.Rows[rd].Cells["cbo"].Value) == Convert.ToString("Đã Cọc"))
                        {
                            status = 0;
                          
                        }
                        if (Convert.ToString(dgrid_info.Rows[rd].Cells["cbo"].Value) == Convert.ToString("Chưa Thanh Toán"))
                        {
                            status = 2;
                           
                        }
                        if (Convert.ToString(dgrid_info.Rows[rd].Cells["cbo"].Value) == Convert.ToString("Đang Chờ Giao Hàng"))
                        {
                            status = 3;
                           
                        }
                        if (Convert.ToString(dgrid_info.Rows[rd].Cells["cbo"].Value) == Convert.ToString("Đã Hủy"))
                        {
                            status = 4;
                            
                        }
                        hd = _hdser.getlsthdbfromDB().ToList().FirstOrDefault(c => c.IdhoaDon == Convert.ToInt32(dgrid_info.Rows[rd].Cells[0].Value));

                        hd.MaHoaDon = Convert.ToString(dgrid_info.Rows[rd].Cells["Mã Hóa Đơn"].Value);
                        hd.NgayLap = Convert.ToDateTime(dgrid_info.Rows[rd].Cells["Ngày Lập"].Value);
                        hd.NgayShipHang = Convert.ToDateTime(dgrid_info.Rows[rd].Cells["Ngày Ship"].Value);
                        hd.NgayNhanHang = Convert.ToDateTime(dgrid_info.Rows[rd].Cells["Ngày Nhận"].Value);
                        hd.Tien = Convert.ToDouble(dgrid_info.Rows[rd].Cells["Tiền"].Value);
                        hd.TongSoTien = Convert.ToDouble(dgrid_info.Rows[rd].Cells["Tổng Số Tiền"].Value);
                        hd.Thue = Convert.ToInt32(dgrid_info.Rows[rd].Cells["Thuế"].Value);
                        hd.TienCoc = Convert.ToDouble(dgrid_info.Rows[rd].Cells["Tiền Cọc"].Value);
                        hd.IdkhachHang = _ikhser.getlstkhachhangformDB().Where(c => c.MaKhachHang == Convert.ToString(Convert.ToString(dgrid_info.Rows[rd].Cells["Mã Khách Hàng"].Value))).Select(c => c.IdkhachHang).FirstOrDefault();
                        hd.Iduser = _invser.getlstnhanvienfromDB().Where(c => c.MaNhanVien == Convert.ToString(Convert.ToString(dgrid_info.Rows[rd].Cells["Mã Nhân Viên"].Value))).Select(c => c.Iduser).FirstOrDefault();
                        hd.GhiChu = Convert.ToString(dgrid_info.Rows[rd].Cells["Ghi Chú"].Value);
                        hd.TrangThai = Convert.ToInt32(status);




                        _hdser.updatehdb(hd);
                        _hdser.save();
                        _hdser.getlsthdbfromDB().Where(c => c.IdhoaDon == idhd);
                        loadhd(idhd);
                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void FrmInfoBill_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void FrmInfoBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            BanHang hang = new BanHang();
            hang.loadhoadonduyet();
        }
    }
}
