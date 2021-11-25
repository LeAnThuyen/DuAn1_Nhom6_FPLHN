using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;

namespace _3_GUI_PresentaionLayers
{
    public partial class fXuLiDonHang : Form
    {
        private IQlyHoaDon _iQlyHoaDon;
        private IQlyKhachHang _iQlyKhachHang;
        private IQlyHangHoa _iQlyHangHoa;
        public fXuLiDonHang()
        {
            InitializeComponent();
            _iQlyHoaDon = new QlyHoaDonServices();
            _iQlyKhachHang = new QLyKhachHangServices();
            _iQlyHangHoa = new QlyHangHoaServices();
            LoadData();
            this.dgridDonTam.DefaultCellStyle.ForeColor = Color.Black;
            loadcbxTenKh();
            loadcbxMaSP();
            css();
        }

        void LoadData()
        {
            dgridDonTam.ColumnCount = 7;
            dgridDonTam.Columns[0].Name = "ID";
            dgridDonTam.Columns[0].Visible = false;
            dgridDonTam.Columns[1].Name = "Mã hóa đơn";
            dgridDonTam.Columns[2].Name = "Thời gian";
            dgridDonTam.Columns[3].Name = "Tên khách hàng";
            dgridDonTam.Columns[4].Name = "Tổng cộng";
            dgridDonTam.Columns[5].Name = "Trạng thái";
            dgridDonTam.Columns[6].Name = "Ghi chú";
            dgridDonTam.Rows.Clear();
            foreach (var x in _iQlyHoaDon.GetsListHD())
            {
                dgridDonTam.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap,
                    x.IdkhachHang, x.TongSoTien
                    , x.TrangThai, x.GhiChu);
            }
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "Hoàn thành";
            buttonColumn.Name = "Hoàn thành";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridDonTam.Columns.Add(buttonColumn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_iQlyHoaDon.GetsList().Select(x=>x.HoaDonBan.IdhoaDon).FirstOrDefault()+"", "Thông báo");
        }

        private void cbxMaDH_SelectedValueChanged(object sender, EventArgs e)
        {
            dgridDonTam.ColumnCount = 7;
            dgridDonTam.Columns[0].Name = "ID";
            dgridDonTam.Columns[0].Visible = false;
            dgridDonTam.Columns[1].Name = "Mã hóa đơn";
            dgridDonTam.Columns[2].Name = "Thời gian";
            dgridDonTam.Columns[3].Name = "Tên khách hàng";
            dgridDonTam.Columns[4].Name = "Tổng cộng";
            dgridDonTam.Columns[5].Name = "Trạng thái";
            dgridDonTam.Columns[6].Name = "Ghi chú";
            dgridDonTam.Rows.Clear();
            foreach (var x in _iQlyHoaDon.GetsListHD().Where(x=>x.MaHoaDon==Convert.ToString(cbxMaDH.SelectedItem)))
            {
                dgridDonTam.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap,
                    x.IdkhachHang, x.TongSoTien
                    , x.TrangThai, x.GhiChu);
            }
        }

        void css()
        {
            label3.AutoSize = false;
            label3.Height = 2;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label4.AutoSize = false;
            label4.Height = 2;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label5.AutoSize = false;
            label5.Height = 2;
            label6.BorderStyle = BorderStyle.Fixed3D; label5.AutoSize = false;
            label6.Height = 2;
            label6.BorderStyle = BorderStyle.Fixed3D;
        }
        void loadcbxTenKh()
        {
            foreach (var x in _iQlyHoaDon.GetsListHD())
            {
                comboBox2.Items.Add(_iQlyKhachHang.GetsListKH().Where(c => c.IdkhachHang == x.IdkhachHang)
                    .Select(x => x.TenKhachHang).FirstOrDefault());
            }
        }
        void loadcbxMaSP()
        {
            foreach (var x in _iQlyHangHoa.GetsListHH())
            {
                comboBox3.Items.Add(x.MaHangHoa);
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            dgridDonTam.ColumnCount = 7;
            dgridDonTam.Columns[0].Name = "ID";
            dgridDonTam.Columns[0].Visible = false;
            dgridDonTam.Columns[1].Name = "Mã hóa đơn";
            dgridDonTam.Columns[2].Name = "Thời gian";
            dgridDonTam.Columns[3].Name = "Tên khách hàng";
            dgridDonTam.Columns[4].Name = "Tổng cộng";
            dgridDonTam.Columns[5].Name = "Trạng thái";
            dgridDonTam.Columns[6].Name = "Ghi chú";
            dgridDonTam.Rows.Clear();

            var id = _iQlyKhachHang.GetsListKH().Where(x => x.TenKhachHang == Convert.ToString(comboBox2.SelectedItem))
                .Select(x => x.IdkhachHang).FirstOrDefault();
            foreach (var x in _iQlyHoaDon.GetsListHD().Where(x => x.IdkhachHang==id))
            {
                dgridDonTam.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap,
                    x.IdkhachHang, x.TongSoTien
                    , x.TrangThai, x.GhiChu);
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            dgridDonTam.ColumnCount = 7;
            dgridDonTam.Columns[0].Name = "ID";
            dgridDonTam.Columns[0].Visible = false;
            dgridDonTam.Columns[1].Name = "Mã hóa đơn";
            dgridDonTam.Columns[2].Name = "Thời gian";
            dgridDonTam.Columns[3].Name = "Tên khách hàng";
            dgridDonTam.Columns[4].Name = "Tổng cộng";
            dgridDonTam.Columns[5].Name = "Trạng thái";
            dgridDonTam.Columns[6].Name = "Ghi chú";
            dgridDonTam.Rows.Clear();
            foreach (var x in _iQlyHoaDon.GetsListHD().Where(x => x.MaHoaDon == Convert.ToString(cbxMaDH.SelectedItem)))
            {
                dgridDonTam.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap,
                    x.IdkhachHang, x.TongSoTien
                    , x.TrangThai, x.GhiChu);
            }
        }

        private void cbxTenhang_SelectedValueChanged(object sender, EventArgs e)
        {
            dgridDonTam.ColumnCount = 7;
            dgridDonTam.Columns[0].Name = "ID";
            dgridDonTam.Columns[0].Visible = false;
            dgridDonTam.Columns[1].Name = "Mã hóa đơn";
            dgridDonTam.Columns[2].Name = "Thời gian";
            dgridDonTam.Columns[3].Name = "Tên khách hàng";
            dgridDonTam.Columns[4].Name = "Tổng cộng";
            dgridDonTam.Columns[5].Name = "Trạng thái";
            dgridDonTam.Columns[6].Name = "Ghi chú";
            dgridDonTam.Rows.Clear();
            foreach (var x in _iQlyHoaDon.GetsListHD().Where(x => x.MaHoaDon == Convert.ToString(cbxMaDH.SelectedItem)))
            {
                dgridDonTam.Rows.Add(x.IdhoaDon, x.MaHoaDon, x.NgayLap,
                    x.IdkhachHang, x.TongSoTien
                    , x.TrangThai, x.GhiChu);
            }
        }

        private void dgridDonTam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (e.ColumnIndex == dgridDonTam.Columns["Hoàn thành"].Index)
            {
                if (dgridDonTam.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Hoàn thành")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn hoàn thành không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }
                   
                  
                    LoadData();

                    MessageBox.Show("Hoàn thành đơn hàng thành công");
                }

                LoadData();
            }
        }
    }
}
