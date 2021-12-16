using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmKhachHang : Form
    {
        private IKhachHangServices ikhachhangser;
        private QlyKhachHang khang;
        private KhachHang _khachhang;
        private KhachHangService _khangser;
        public FrmKhachHang()
        {
            InitializeComponent();
            khang = new QlyKhachHang();
            ikhachhangser = new KhachHangService();
            _khachhang = new KhachHang();
            ikhachhangser.getlstkhachhangformDB();
            dgv_Khachhang.AllowUserToAddRows = false;
            loadata();
            loc();
        }
        void loadata()
        {
            try
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
                foreach (var x in ikhachhangser.getlstkhachhangformDB())
                {
                    dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.IddiemTieuDung);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }
        public bool checkup()
        {
            if (string.IsNullOrEmpty(txt_MaKhachHang.Text))
            {
                MessageBox.Show("Mã Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Email.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_DiaChi.Text))
            {
                MessageBox.Show("Địa Chỉ không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Sdt.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenKhachHang.Text))
            {
                MessageBox.Show("Tên Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (txt_MaKhachHang.Text.Length <= 3)
            {
                MessageBox.Show("Mã Khách Hàng phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaKhachHang.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Khách Hàng Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaKhachHang.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã Khách Hàng không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //tên
            if (txt_TenKhachHang.Text.Length <= 3)
            {
                MessageBox.Show("Tên Khách Hàng phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenKhachHang.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Khách Hàng không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenKhachHang.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Khách Hàng không được chứa ký tự đặc biệt", "ERR");
                return false;
            }

            //email
            if (txt_Email.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_Email.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "ERR");
                return false;
            }
            //diachi
            if (txt_DiaChi.Text.Length <= 3)
            {
                MessageBox.Show("Địa Chỉ bạn nhập không hợp lệ", "ERR");
                return false;
            }
            if (txt_DiaChi.Text.Length <= 3 && txt_DiaChi.Text.Length >= 100)
            {
                MessageBox.Show(" Địa chỉ", "ERR");
                return false;
            }
            //dienthoai
            if (txt_Sdt.Text.Length <= 3)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_Sdt.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số điện thoại không được chứa chữ cái", "ERR");
                return false;
            }
            if (txt_Sdt.Text.Length <= 0 && txt_Sdt.Text.Length > 10)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            /*   if (Regex.IsMatch(txt_Sdt.Text, @"^(\+[0-9]{10})$") == false)
               {

                   MessageBox.Show("số điện thoại không hợp lệ", "ERR");
                   return false;
               }*/
            ///trạng thái
            if (ckd_Onl.Checked == false && ckd_off.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }

            return true;
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txt_Email.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenKhachHang.Text))
            {
                MessageBox.Show("Tên Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            //mã 

            if (Regex.IsMatch(txt_MaKhachHang.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Khách Hàng Bắt buộc phải chứa số", "ERR");
                return false;

            }
            for (int i = 0; i < ikhachhangser.getlstkhachhangformDB().Count; i++)
            {
                if (ikhachhangser.getlstkhachhangformDB().ToList()[i].MaKhachHang == txt_MaKhachHang.Text)
                {
                    MessageBox.Show("Mã Khách Hàng Đã tồn Tại yêu cầu nhập mã NSX khác", "ERR");
                    return false;
                }
            }
            //tên
            if (txt_TenKhachHang.Text.Length <= 3)
            {
                MessageBox.Show("Tên Khách Hàng phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenKhachHang.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Khách Hàng không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenKhachHang.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Khách Hàng không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (ckd_Onl.Checked == false && ckd_off.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            //email
            if (txt_Email.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_Email.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "ERR");
                return false;
            }
            for (int i = 0; i < ikhachhangser.getlstkhachhangformDB().Count; i++)
            {
                if (ikhachhangser.getlstkhachhangformDB().ToList()[i].Email == txt_Email.Text)
                {
                    MessageBox.Show("Email  Đã tồn Tại yêu cầu nhập emmail khác", "ERR");
                    return false;
                }

            }

            //diachi
            if (txt_DiaChi.Text.Length <= 3)
            {
                MessageBox.Show("Địa Chỉ bạn nhập không hợp lệ", "ERR");
                return false;
            }
            if (txt_DiaChi.Text.Length <= 3 && txt_DiaChi.Text.Length >= 100)
            {
                MessageBox.Show(" Địa chỉ", "ERR");
                return false;
            }
            //dienthoai
            if (txt_Sdt.Text.Length <= 3)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_Sdt.Text, @"^(\+[0-9]{9})$") == false)
            {

                MessageBox.Show("số điện thoại không được chứa chữ cái", "ERR");
                return false;
            }
            if (txt_Sdt.Text.Length <= 0 && txt_Sdt.Text.Length > 10)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            ///trạng thái
            if (ckd_Onl.Checked == false && ckd_off.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }

        private void dgv_Khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rd = e.RowIndex;
                dgv_Khachhang.AllowUserToAddRows = false;


                //thêm
                try
                {
                    if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                    {

                        string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                        if (commnad == "Thêm")
                        {
                            DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Check() == false)
                                {
                                    return;
                                }


                                _khachhang.IdkhachHang = ikhachhangser.getlstkhachhangformDB().Max(c => c.IdkhachHang) + 1;
                                _khachhang.MaKhachHang = txt_MaKhachHang.Text;
                                _khachhang.TenKhachHang = txt_TenKhachHang.Text;
                                _khachhang.Email = txt_Email.Text;
                                _khachhang.DiaChi = txt_DiaChi.Text;
                                _khachhang.SoDienThoai = txt_Sdt.Text;
                                _khachhang.TrangThai = ckd_Onl.Checked;
                                _khachhang.IddiemTieuDung = 1;
                                ikhachhangser.addkhachhang(_khachhang);

                                ikhachhangser.savekhachhang(_khachhang);
                                MessageBox.Show("Thêm Thành Công", "Thông Báo");
                                ikhachhangser.getlstkhachhangformDB();
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
                catch (Exception ex)
                {

                    MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
                }
                //sửa
                try
                {
                    if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                    {

                        string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                        if (commnad == "Sửa")
                        {
                            DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (checkup() == false)
                                {
                                    return;
                                }

                                _khachhang.IdkhachHang = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[0].Value.ToString());
                                _khachhang.MaKhachHang = txt_MaKhachHang.Text;
                                _khachhang.TenKhachHang = txt_TenKhachHang.Text;
                                _khachhang.Email = txt_Email.Text;
                                _khachhang.DiaChi = txt_DiaChi.Text;
                                _khachhang.SoDienThoai = txt_Sdt.Text;
                                _khachhang.TrangThai = ckd_Onl.Checked;
                                _khachhang.IddiemTieuDung = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[7].Value.ToString());
                                ikhachhangser.updatekhachhang(_khachhang);
                                ikhachhangser.savekhachhang(_khachhang);
                                MessageBox.Show("Sửa Thành Công", "Thông Báo");
                                ikhachhangser.getlstkhachhangformDB();
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
                catch (Exception ex)
                {

                    MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
                }
                //xóa
                if (e.ColumnIndex == 9 && string.IsNullOrEmpty(dgv_Khachhang.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_Khachhang.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                    if (commnad == "Xóa")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _khachhang.IdkhachHang = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _khachhang.MaKhachHang = txt_MaKhachHang.Text;
                            _khachhang.TenKhachHang = txt_TenKhachHang.Text;
                            _khachhang.Email = txt_Email.Text;
                            _khachhang.DiaChi = txt_DiaChi.Text;
                            _khachhang.SoDienThoai = txt_Sdt.Text;
                            _khachhang.TrangThai = ckd_off.Checked;
                            _khachhang.IddiemTieuDung = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[7].Value.ToString());
                            ikhachhangser.updatekhachhang(_khachhang);
                            ikhachhangser.savekhachhang(_khachhang);
                            MessageBox.Show("Xóa Thành Công", "Thông Báo");
                            ikhachhangser.getlstkhachhangformDB();
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void dgv_Khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == khang.GetsList().Count || rowindex == -1) return;
                _khachhang = ikhachhangser.getlstkhachhangformDB().ToList().FirstOrDefault(c => c.IdkhachHang == Convert.ToInt32(dgv_Khachhang.Rows[rowindex].Cells[0].Value.ToString()));
                txt_MaKhachHang.Text = dgv_Khachhang.Rows[rowindex].Cells[1].Value.ToString();
                txt_TenKhachHang.Text = dgv_Khachhang.Rows[rowindex].Cells[2].Value.ToString();
                txt_Email.Text = dgv_Khachhang.Rows[rowindex].Cells[3].Value.ToString();
                txt_DiaChi.Text = dgv_Khachhang.Rows[rowindex].Cells[4].Value.ToString();
                txt_Sdt.Text = dgv_Khachhang.Rows[rowindex].Cells[5].Value.ToString();
                ckd_Onl.Checked = dgv_Khachhang.Rows[rowindex].Cells[6].Value.ToString() == "Hoạt Động";
                ckd_off.Checked = dgv_Khachhang.Rows[rowindex].Cells[6].Value.ToString() == "Không Hoạt Động";
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }

        }

        private void ckd_Onl_CheckedChanged(object sender, EventArgs e)
        {
            if (ckd_Onl.Checked)
            {
                ckd_off.Checked = false;
            }
        }

        private void ckd_off_CheckedChanged(object sender, EventArgs e)
        {

            if (ckd_off.Checked)
            {
                ckd_Onl.Checked = false;
            }
        }

        private void dgv_Khachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IdkhachHang = Convert.ToInt32(dgv_Khachhang.Rows[e.RowIndex].Cells[0].Value);
                string MaKhachHang = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[1].Value);
                string TenKhachHang = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[2].Value);
                string Email = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[3].Value);
                string DiaChi = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[4].Value);
                string SoDienThoai = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[5].Value);
                string trangthai = Convert.ToString(dgv_Khachhang.Rows[e.RowIndex].Cells[6].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }
        void loadatafortimkiem(string ma)
        {

            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                row.Add("Thêm");
                row.Add("Sửa");
                row.Add("Xóa");

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
                foreach (var x in ikhachhangser.getlstkhachhangformDB().Where(c => c.MaKhachHang.StartsWith(ma) || c.TenKhachHang.StartsWith(ma) || c.Email.StartsWith(ma) || c.SoDienThoai.StartsWith(ma) || c.DiaChi.StartsWith(ma)))
                {

                    dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.IddiemTieuDung);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }

        }

        private void tbx_TimKiem_Leave(object sender, EventArgs e)
        {
            try
            {

                if (tbx_TimKiem.Text == "")
                {
                    tbx_TimKiem.Text = "Tìm kiếm Khách Hàng";
                    tbx_TimKiem.ForeColor = Color.Black;
                    ikhachhangser.getlstkhachhangformDB();
                    loadata();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
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
            try
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
                foreach (var x in ikhachhangser.getlstkhachhangformDB().OrderByDescending(c => c.TenKhachHang))
                {
                    dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.IddiemTieuDung);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }
        void loaddata2()
        {
            try
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
                foreach (var x in ikhachhangser.getlstkhachhangformDB().OrderBy(c => c.TenKhachHang))
                {
                    dgv_Khachhang.Rows.Add(x.IdkhachHang, x.MaKhachHang, x.TenKhachHang, x.Email, x.DiaChi, x.SoDienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.IddiemTieuDung);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToLongTimeString();
            label16.Text = DateTime.Now.ToLongDateString();
        }

        private void cbx_Loc_SelectedValueChanged_1(object sender, EventArgs e)
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
