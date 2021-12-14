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
    public partial class FrmKhachHang : Form
    {
        private QlyKhachHang khang;
        private KhachHang _khachhang;
        private KhachHangService _khangser;
        public FrmKhachHang()
        {
            InitializeComponent();
            khang = new QlyKhachHang();
            _khangser = new KhachHangService();
            _khachhang = new KhachHang();
            _khangser.getlstkhachhangformDB();
            dgv_Khachhang.AllowUserToAddRows = false;
            loadata();
            loc();
        }
        void loadata()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            // combobox


            dgv_Khachhang.ColumnCount = 8;
            dgv_Khachhang.Columns[0].Name = "ID Khách Hàng";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[2].Name = "Tên khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Email";
            dgv_Khachhang.Columns[4].Name = "Địa Chỉ";
            dgv_Khachhang.Columns[5].Name = "Số điện thoại";
            dgv_Khachhang.Columns[6].Name = "Trạng thái ";
            dgv_Khachhang.Columns[7].Name = "ID Điểm tiêu dùng";
            dgv_Khachhang.Columns[7].Visible = false;

            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_Khachhang.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_Khachhang.Columns.Add(btn);
            dgv_Khachhang.Rows.Clear();
            foreach (var x in khang.GetsList())
            {
                dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Onl" : "Off", x.IddiemTieuDung);
            }
        }

        private void dgv_Khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            dgv_Khachhang.AllowUserToAddRows = false;


            //thêm
            if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Thêm")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {



                        _khachhang.IdkhachHang = _khangser.getlstkhachhangformDB().Max(c => c.IdkhachHang) + 1;
                        _khachhang.MaKhachHang = txt_MaKhachHang.Text;
                        _khachhang.TenKhachHang = txt_TenKhachHang.Text;
                        _khachhang.Email = txt_Email.Text;
                        _khachhang.DiaChi = txt_DiaChi.Text;
                        _khachhang.SoDienThoai = txt_Sdt.Text;
                        _khachhang.TrangThai = ckd_Onl.Checked;
                        _khachhang.IddiemTieuDung = 1;
                        _khangser.addkhachhang(_khachhang);

                        _khangser.savekhachhang(_khachhang);
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                        _khangser.getlstkhachhangformDB();
                        loadata();
                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            //sửa
            if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Sửa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _khachhang.IdkhachHang = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _khachhang.MaKhachHang = txt_MaKhachHang.Text;
                        _khachhang.TenKhachHang = txt_TenKhachHang.Text;
                        _khachhang.Email = txt_Email.Text;
                        _khachhang.DiaChi = txt_DiaChi.Text;
                        _khachhang.SoDienThoai = txt_Sdt.Text;
                        _khachhang.TrangThai = ckd_Onl.Checked;
                        _khachhang.IddiemTieuDung = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[7].Value.ToString());
                        _khangser.updatekhachhang(_khachhang);
                        _khangser.savekhachhang(_khachhang);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
                        _khangser.getlstkhachhangformDB();
                        loadata();
                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

            }
            //xóa
            if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                if (commnad == "Xóa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _khangser.deletekhachhang(_khachhang);
                        _khangser.savekhachhang(_khachhang);
                        MessageBox.Show("Xóa Thành Công");
                        _khangser.getlstkhachhangformDB();
                        loadata();

                        return;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void dgv_Khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == khang.GetsList().Count || rowindex == -1) return;
            _khachhang = _khangser.getlstkhachhangformDB().ToList().FirstOrDefault(c => c.IdkhachHang == Convert.ToInt32(dgv_Khachhang.Rows[rowindex].Cells[0].Value.ToString()));
            txt_MaKhachHang.Text = dgv_Khachhang.Rows[rowindex].Cells[1].Value.ToString();
            txt_TenKhachHang.Text = dgv_Khachhang.Rows[rowindex].Cells[2].Value.ToString();
            txt_Email.Text = dgv_Khachhang.Rows[rowindex].Cells[3].Value.ToString();
            txt_DiaChi.Text = dgv_Khachhang.Rows[rowindex].Cells[4].Value.ToString();
            txt_Sdt.Text = dgv_Khachhang.Rows[rowindex].Cells[5].Value.ToString();
            ckd_Onl.Checked = dgv_Khachhang.Rows[rowindex].Cells[6].Value.ToString() == "Onl";
            ckd_off.Checked = dgv_Khachhang.Rows[rowindex].Cells[6].Value.ToString() == "Off";

        }

        private void ckd_Onl_CheckedChanged(object sender, EventArgs e)
        {
            if (ckd_Onl.Checked)
            {
                ckd_Onl.Checked = false;
            }
        }

        private void ckd_off_CheckedChanged(object sender, EventArgs e)
        {

            if (ckd_off.Checked)
            {
                ckd_off.Checked = false;
            }
        }

        private void dgv_Khachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdkhachHang = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[0].Value);
            string MaKhachHang = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[1].Value);
            string TenKhachHang = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[2].Value);
            string Email = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[3].Value);
            string DiaChi = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[4].Value);
            string SoDienThoai = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[5].Value);
            string trangthai = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[6].Value);
        }
        void loadatafortimkiem(string ma)
        {

            dgv_Khachhang.ColumnCount = 8;
            dgv_Khachhang.Columns[0].Name = "ID Khách Hàng";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[2].Name = "Tên khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Email";
            dgv_Khachhang.Columns[4].Name = "Địa Chỉ";
            dgv_Khachhang.Columns[5].Name = "Số điện thoại";
            dgv_Khachhang.Columns[6].Name = "Trạng thái ";
            dgv_Khachhang.Columns[7].Name = "ID Điểm tiêu dùng";
            dgv_Khachhang.Columns[7].Visible = false;
            dgv_Khachhang.Rows.Clear();
            foreach (var x in _khangser.getlstkhachhangformDB().Where(c => c.MaKhachHang.StartsWith(ma)))
            {

                dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Onl" : "Off", x.IddiemTieuDung);

            }

        }

        private void tbx_TimKiem_Leave(object sender, EventArgs e)
        {

            if (tbx_TimKiem.Text == "")
            {
                tbx_TimKiem.Text = "Tìm kiếm theo mã khách hàng";
                tbx_TimKiem.ForeColor = Color.Black;
                _khangser.getlstkhachhangformDB();
                loadata();
            }
        }

        private void tbx_TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadatafortimkiem(tbx_TimKiem.Text);
        }
        void loc()
        {
            ArrayList row1 = new ArrayList();

            row1 = new ArrayList();
            row1.Add("từ A đến Z");
            row1.Add("từ Z đến A");
            cbx_Loc.Items.AddRange(row1.ToArray());

        }
        void loaddata1()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            // combobox


            dgv_Khachhang.ColumnCount = 8;
            dgv_Khachhang.Columns[0].Name = "ID Khách Hàng";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[2].Name = "Tên khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Email";
            dgv_Khachhang.Columns[4].Name = "Địa Chỉ";
            dgv_Khachhang.Columns[5].Name = "Số điện thoại";
            dgv_Khachhang.Columns[6].Name = "Trạng thái ";
            dgv_Khachhang.Columns[7].Name = "ID Điểm tiêu dùng";
            dgv_Khachhang.Columns[7].Visible = false;
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_Khachhang.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_Khachhang.Columns.Add(btn);
            dgv_Khachhang.Rows.Clear();
            foreach (var x in _khangser.getlstkhachhangformDB().OrderByDescending(c => c.MaKhachHang))
            {
                dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Onl" : "Off", x.IddiemTieuDung);
            }
        }
        void loaddata2()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            // combobox


            dgv_Khachhang.ColumnCount = 8;
            dgv_Khachhang.Columns[0].Name = "ID Khách Hàng";
            dgv_Khachhang.Columns[0].Visible = false;
            dgv_Khachhang.Columns[1].Name = "Mã Khách Hàng";
            dgv_Khachhang.Columns[2].Name = "Tên khách Hàng";
            dgv_Khachhang.Columns[3].Name = "Email";
            dgv_Khachhang.Columns[4].Name = "Địa Chỉ";
            dgv_Khachhang.Columns[5].Name = "Số điện thoại";
            dgv_Khachhang.Columns[6].Name = "Trạng thái ";
            dgv_Khachhang.Columns[7].Name = "ID Điểm tiêu dùng";
            dgv_Khachhang.Columns[7].Visible = false;
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_Khachhang.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_Khachhang.Columns.Add(btn);
            dgv_Khachhang.Rows.Clear();
            foreach (var x in _khangser.getlstkhachhangformDB().OrderByDescending(c => c.MaKhachHang))
            {
                dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai);
            }
        }
        private void cbx_loc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbx_Loc.Text == "từ A đến Z")
            {
                loaddata2();
                return;
            }
            if (cbx_Loc.Text == "từ Z đến A")
            {
                loaddata1();
                return;
            }
        }
    }
}
