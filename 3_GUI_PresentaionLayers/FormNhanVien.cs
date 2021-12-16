using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FormNhanVien : Form
    {

        private IServicesNhanVien inhanvienser;
        private string FileImageNam = "";
        private QlyNhanVienServices nhanVien;
        private NhanVien _nhanVien;

        private IQlyNhanVien invser;
        public FormNhanVien()
        {
            InitializeComponent();
            nhanVien = new QlyNhanVienServices();
            _nhanVien = new NhanVien();
            inhanvienser = new NhanVienServices();
            //invser = new QlyNhanVienServices();

            //dgvNhanVien.AllowUserToAddRows = false;
            loaddata();
            loadanh();
            loc();
        }
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();

        }


        void loaddata()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                row.Add("Thêm");
                row.Add("Sửa");
                row.Add("Xóa");

                // combobox
                dgvNhanVien.ColumnCount = 14;
                dgvNhanVien.Columns[0].Name = "ID Người dùng";
                dgvNhanVien.Columns[0].Visible = false;
                dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
                dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
                dgvNhanVien.Columns[3].Name = "Giới Tính";
                dgvNhanVien.Columns[4].Name = "Năm Sinh";
                dgvNhanVien.Columns[5].Name = "Email";
                dgvNhanVien.Columns[6].Name = "Password";
                //dgvNhanVien.Columns[6].Visible = false;
                dgvNhanVien.Columns[7].Name = "Quê Quán";
                dgvNhanVien.Columns[8].Name = "Số CMND";
                dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
                dgvNhanVien.Columns[10].Name = "Trạng thái";
                dgvNhanVien.Columns[11].Name = "Đường Dẫn";
                dgvNhanVien.Columns[11].Visible = false;
                dgvNhanVien.Columns[12].Name = "ID Role";
                dgvNhanVien.Columns[12].Visible = false;
                dgvNhanVien.Columns[13].Name = "Flag";
                dgvNhanVien.Columns[13].Visible = false;
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgvNhanVien.Columns.Add(cbo);

                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgvNhanVien.Columns.Add(btn);

                dgvNhanVien.Rows.Clear();
                foreach (var x in inhanvienser.getlstnhanvienfromDB().Where(c => c.TrangThai == true))
                {
                    dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }
        void loadanh()
        {
            //DataGridViewImageColumn img = new DataGridViewImageColumn();
            //img.HeaderText = "Ảnh Nhân Viên";
            //img.Name = "img_sp";
            //img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //dgvNhanVien.Columns.Add(img);
            //dgvNhanVien.Rows.Clear();
            //for (int i = 0; i < dgvNhanVien.RowCount; i++)
            //{
            //    Image img2 = Image.FromFile(Convert.ToString(dgvNhanVien.Rows[i].Cells["Đường Dẫn"].Value));

            //    dgvNhanVien.Rows[i].Cells["img_sp"].Value = img2;

            //}

        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rd = e.RowIndex;
                dgvNhanVien.AllowUserToAddRows = false;
                //thêm
                if (e.ColumnIndex == 15 && string.IsNullOrEmpty(dgvNhanVien.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgvNhanVien.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Thêm")
                    {
                        if (check() == false)
                        {
                            return;
                        }
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            inhanvienser.addnhanvien(new NhanVien()
                            {
                                Iduser = inhanvienser.getlstnhanvienfromDB().Max(c => c.Iduser) + 1,
                                MaNhanVien = txtMaNV.Text,
                                TenNhanVien = txtTenNV.Text,
                                GioiTinh = Convert.ToInt32(chkNam.Checked),
                                NamSinh = Convert.ToInt32(txtNamSinh.Text),
                                Email = txtEmail.Text,
                                PassWord = encryption(txt_pass.Text),
                                QueQuan = txtQueQuan.Text,
                                SoCmnd = txtCMND.Text,
                                DienThoai = txtSDT.Text,
                                TrangThai = chkHoatDong.Checked,
                                Anh = txt_anh.Text,
                                Flag = false
                            });
                            inhanvienser.save(_nhanVien);
                            MessageBox.Show("Thêm Thành Công", "Thông Báo");
                            inhanvienser.getlstnhanvienfromDB();
                            loaddata();
                            return;
                        }
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                //sửa
                if (e.ColumnIndex == 15 && string.IsNullOrEmpty(dgvNhanVien.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgvNhanVien.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Sửa")
                    {
                        if (checkup() == false)
                        {
                            return;
                        }
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            _nhanVien.Iduser = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _nhanVien.MaNhanVien = txtMaNV.Text;
                            _nhanVien.TenNhanVien = txtTenNV.Text;
                            _nhanVien.GioiTinh = Convert.ToInt32(chkNam.Checked);
                            _nhanVien.NamSinh = Convert.ToInt32(txtNamSinh.Text);
                            _nhanVien.Email = txtEmail.Text;
                            _nhanVien.PassWord =encryption( txt_pass.Text);
                            _nhanVien.QueQuan = txtQueQuan.Text;
                            _nhanVien.SoCmnd = txtCMND.Text;
                            _nhanVien.DienThoai = txtSDT.Text;
                            _nhanVien.TrangThai = chkHoatDong.Checked;
                            _nhanVien.Flag = false;
                            inhanvienser.updatenhanvien(_nhanVien);
                            inhanvienser.save(_nhanVien);
                            MessageBox.Show("Sửa Thành Công", "Thông Báo");
                            inhanvienser.getlstnhanvienfromDB();
                            loaddata();
                            return;
                        }
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                    }

                }
                //xóa
                if (e.ColumnIndex == 15 && string.IsNullOrEmpty(dgvNhanVien.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgvNhanVien.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                    if (commnad == "Xóa")
                    {

                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _nhanVien.Iduser = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _nhanVien.MaNhanVien = txtMaNV.Text;
                            _nhanVien.TenNhanVien = txtTenNV.Text;
                            _nhanVien.GioiTinh = Convert.ToInt32(chkNam.Checked);
                            _nhanVien.NamSinh = Convert.ToInt32(txtNamSinh.Text);
                            _nhanVien.Email = txtEmail.Text;
                            _nhanVien.PassWord = encryption(txt_pass.Text);
                            _nhanVien.QueQuan = txtQueQuan.Text;
                            _nhanVien.SoCmnd = txtCMND.Text;
                            _nhanVien.DienThoai = txtSDT.Text;
                            _nhanVien.TrangThai = false;
                            _nhanVien.Flag = false;
                            inhanvienser.updatenhanvien(_nhanVien);
                            inhanvienser.save(_nhanVien);
                            MessageBox.Show("Xóa Thành Công", "Thông Báo");
                            inhanvienser.getlstnhanvienfromDB();
                            loaddata();

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

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == inhanvienser.getlstnhanvienfromDB().Count || rowindex == -1) return;
                _nhanVien = inhanvienser.getlstnhanvienfromDB().FirstOrDefault(c => c.Iduser == Convert.ToInt32(dgvNhanVien.Rows[rowindex].Cells[0].Value.ToString()));
                txtMaNV.Text = dgvNhanVien.Rows[rowindex].Cells[1].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[rowindex].Cells[2].Value.ToString();
                chkNam.Checked = dgvNhanVien.Rows[rowindex].Cells[3].Value.ToString() == "Nam";
                chkNu.Checked = dgvNhanVien.Rows[rowindex].Cells[3].Value.ToString() == "Nữ";
                txtNamSinh.Text = dgvNhanVien.Rows[rowindex].Cells[4].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[rowindex].Cells[5].Value.ToString();
                txt_pass.Text = dgvNhanVien.Rows[rowindex].Cells[6].Value.ToString();
                txtQueQuan.Text = dgvNhanVien.Rows[rowindex].Cells[7].Value.ToString();
                txtCMND.Text = dgvNhanVien.Rows[rowindex].Cells[8].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[rowindex].Cells[9].Value.ToString();
                chkHoatDong.Checked = dgvNhanVien.Rows[rowindex].Cells[10].Value.ToString() == "Hoạt Động";
                ChkKhongHoatDong.Checked = dgvNhanVien.Rows[rowindex].Cells[10].Value.ToString() == "Không Hoạt Động";
                Image img1 = Image.FromFile(Convert.ToString(dgvNhanVien.Rows[rowindex].Cells[11].Value.ToString()));
                pic_anh.Image = img1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }

        }
        public bool checkup()
        {
            //phần check chống
            #region
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txtNamSinh.Text))
            {
                MessageBox.Show("Năm sinh  không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion


            #region
            //mã 

            if (Regex.IsMatch(txtMaNV.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nhân Viên Bắt buộc phải chứa số", "ERR");
                return false;
            }
            //for (int i = 0; i < inhanvienser.getlstnhanvienfromDB().Count; i++)
            //{
            //    if (inhanvienser.getlstnhanvienfromDB().ToList()[i].MaNhanVien == txtMaNV.Text)
            //    {
            //        MessageBox.Show("Mã nhân Viên Đã tồn Tại yêu cầu nhập mã sinh viên khác", "ERR");
            //        return false;
            //    }
            //}




            //tên
            if (txtTenNV.Text.Length <= 3)
            {
                MessageBox.Show("Tên nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtTenNV.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên nhân Viên không được chứa số", "ERR");
                return false;
            }
            //giới tính
            if (chkNam.Checked == false && chkNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "ERR");
                return false;
            }

            //email
            if (txtEmail.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "ERR");
                return false;
            }
            //for (int i = 0; i < inhanvienser.getlstnhanvienfromDB().Count; i++)
            //{
            //    if (inhanvienser.getlstnhanvienfromDB().ToList()[i].Email == txtEmail.Text)
            //    {
            //        MessageBox.Show("Email nhân Viên Đã tồn Tại yêu cầu nhập mã sinh viên khác", "ERR");
            //        return false;
            //    }
            //}
            //pass
            if (txt_pass.Text.Length <= 3)
            {
                MessageBox.Show("Mật Khẩu nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_pass.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("mật khẩu nhân Viên Bắt buộc phải chứa số", "ERR");
                return false;
            }
            //dia chi
            if (txtSDT.Text.Length <= 3 && txtSDT.Text.Length >= 100)
            {
                MessageBox.Show(" địa chỉ", "ERR");
                return false;
            }
            //dien thoai
            if (txtSDT.Text.Length <= 3)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtSDT.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số điện thoại nhân viên không được chứa chữ cái", "ERR");
                return false;
            }
            //nam sinh
            if (Regex.IsMatch(txtNamSinh.Text, @"^\d+$") == false)
            {

                MessageBox.Show("năm sinh nhân viên không được chứa chữ cái", "ERR");
                return false;
            }
            if (Convert.ToInt32(txtNamSinh.Text) <= 1900 && Convert.ToInt32(txtNamSinh.Text) >= 2005)
            {

                MessageBox.Show("năm sinh nhân viên không hợp lệ", "ERR");
                return false;
            }






            #endregion
            return true;

        }
        public bool check()
        {  //phần check chống
            #region
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txtNamSinh.Text))
            {
                MessageBox.Show("Năm sinh  không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion


            #region
            //mã 

            if (Regex.IsMatch(txtMaNV.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nhân Viên Bắt buộc phải chứa số", "ERR");
                return false;
            }
            for (int i = 0; i < inhanvienser.getlstnhanvienfromDB().Count; i++)
            {
                if (inhanvienser.getlstnhanvienfromDB().ToList()[i].MaNhanVien == txtMaNV.Text)
                {
                    MessageBox.Show("Mã nhân Viên Đã tồn Tại yêu cầu nhập mã nhân viên khác", "ERR");
                    return false;
                }
            }




            //tên
            if (txtTenNV.Text.Length <= 3)
            {
                MessageBox.Show("Tên nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtTenNV.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên nhân Viên không được chứa số", "ERR");
                return false;
            }
            //giới tính
            if (chkNam.Checked == false && chkNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "ERR");
                return false;
            }

            //email
            if (txtEmail.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "ERR");
                return false;
            }
            for (int i = 0; i < inhanvienser.getlstnhanvienfromDB().Count; i++)
            {
                if (inhanvienser.getlstnhanvienfromDB().ToList()[i].Email == txtEmail.Text)
                {
                    MessageBox.Show("Email nhân Viên Đã tồn Tại yêu cầu nhập mã nhân viên khác", "ERR");
                    return false;
                }
            }
            //pass
            if (txt_pass.Text.Length <= 3)
            {
                MessageBox.Show("Mật Khẩu nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_pass.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("mật khẩu nhân Viên Bắt buộc phải chứa số", "ERR");
                return false;
            }
            //dia chi
            if (txtSDT.Text.Length <= 3 && txtSDT.Text.Length >= 100)
            {
                MessageBox.Show(" địa chỉ", "ERR");
                return false;
            }
            //dien thoai
            if (txtSDT.Text.Length <= 3)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtSDT.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số điện thoại nhân viên không được chứa chữ cái", "ERR");
                return false;
            }
            //nam sinh
            if (Regex.IsMatch(txtNamSinh.Text, @"^\d+$") == false)
            {

                MessageBox.Show("năm sinh nhân viên không được chứa chữ cái", "ERR");
                return false;
            }
            if (Convert.ToInt32(txtNamSinh.Text) <= 1900 && Convert.ToInt32(txtNamSinh.Text) >= 2005)
            {

                MessageBox.Show("năm sinh nhân viên không hợp lệ", "ERR");
                return false;
            }






            #endregion
            return true;
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
            {
                chkNam.Checked = false;
            }
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNam.Checked)
            {
                chkNu.Checked = false;
            }
        }
        void loadimg(ref string imgname)
        {
            OpenFileDialog fileimgname = new OpenFileDialog();
            if (fileimgname.ShowDialog() == DialogResult.OK)
            {
                imgname = fileimgname.FileName;

                txt_anh.Text = fileimgname.FileName;
            }

        }
        private void btn_anh_Click(object sender, EventArgs e)
        {
            try
            {

                loadimg(ref FileImageNam);
                pic_anh.Image = new Bitmap(FileImageNam);

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void chkHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHoatDong.Checked)
            {
                ChkKhongHoatDong.Checked = false;
            }
        }

        private void ChkKhongHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkKhongHoatDong.Checked)
            {
                chkHoatDong.Checked = false;
            }
        }
        void loadtim_kiem(string ma)
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            dgvNhanVien.ColumnCount = 14;
            dgvNhanVien.Columns[0].Name = "ID Người dùng";
            dgvNhanVien.Columns[0].Visible = false;
            dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
            dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
            dgvNhanVien.Columns[3].Name = "Giới Tính";
            dgvNhanVien.Columns[4].Name = "Năm Sinh";
            dgvNhanVien.Columns[5].Name = "Email";
            dgvNhanVien.Columns[6].Name = "Password";
            dgvNhanVien.Columns[7].Name = "Quê Quán";
            dgvNhanVien.Columns[8].Name = "Số CMND";
            dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
            dgvNhanVien.Columns[10].Name = "Trạng thái";
            dgvNhanVien.Columns[11].Name = "Ảnh";
            dgvNhanVien.Columns[11].Visible = false;
            dgvNhanVien.Columns[12].Name = "ID Role";
            dgvNhanVien.Columns[12].Visible = false;
            dgvNhanVien.Columns[13].Name = "Flag";
            dgvNhanVien.Columns[13].Visible = false;
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgvNhanVien.Columns.Add(cbo);
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Ảnh Nhân Viên";
            img.Name = "img_nv";
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvNhanVien.Rows.Clear();
            foreach (var x in inhanvienser.getlstnhanvienfromDB().Where(c => c.TenNhanVien.StartsWith(ma) || c.SoCmnd.StartsWith(ma) || c.QueQuan.StartsWith(ma) || c.DienThoai.StartsWith(ma) || c.Email.StartsWith(ma)))
            {
                dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
            }
        }

        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_TimKiem.Text == "")
                {
                    txt_TimKiem.Text = "Tìm kiếm theo tên,cmnd, quê quán và email nhân viên";
                    txt_TimKiem.ForeColor = Color.Black;
                    inhanvienser.getlstnhanvienfromDB();
                    loaddata();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void txt_TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadtim_kiem(txt_TimKiem.Text);
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
        void loc()
        {
            ArrayList row1 = new ArrayList();

            row1 = new ArrayList();
            row1.Add("tên nhân viên từ A đến Z");
            row1.Add("tên nhân viên từ Z đến A");
            row1.Add("email nhân viên từ A đến Z");
            row1.Add("email nhân viên từ Z đến A");
            cbx_loc.Items.AddRange(row1.ToArray());

        }
        void loaddata1()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                dgvNhanVien.ColumnCount = 14;
                dgvNhanVien.Columns[0].Name = "ID Người dùng";
                dgvNhanVien.Columns[0].Visible = false;
                dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
                dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
                dgvNhanVien.Columns[3].Name = "Giới Tính";
                dgvNhanVien.Columns[4].Name = "Năm Sinh";
                dgvNhanVien.Columns[5].Name = "Email";
                dgvNhanVien.Columns[6].Name = "Password";
                dgvNhanVien.Columns[7].Name = "Quê Quán";
                dgvNhanVien.Columns[8].Name = "Số CMND";
                dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
                dgvNhanVien.Columns[10].Name = "Trạng thái";
                dgvNhanVien.Columns[11].Name = "Ảnh";
                dgvNhanVien.Columns[11].Visible = false;
                dgvNhanVien.Columns[12].Name = "ID Role";
                dgvNhanVien.Columns[12].Visible = false;
                dgvNhanVien.Columns[13].Name = "Flag";
                dgvNhanVien.Columns[13].Visible = false;
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgvNhanVien.Columns.Add(cbo);
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Ảnh Nhân Viên";
                img.Name = "img_nv";
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvNhanVien.Rows.Clear();
                foreach (var x in inhanvienser.getlstnhanvienfromDB().OrderByDescending(c => c.TenNhanVien))
                {
                    dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }
        void loaddata2()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                dgvNhanVien.ColumnCount = 14;
                dgvNhanVien.Columns[0].Name = "ID Người dùng";
                dgvNhanVien.Columns[0].Visible = false;
                dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
                dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
                dgvNhanVien.Columns[3].Name = "Giới Tính";
                dgvNhanVien.Columns[4].Name = "Năm Sinh";
                dgvNhanVien.Columns[5].Name = "Email";
                dgvNhanVien.Columns[6].Name = "Password";
                dgvNhanVien.Columns[7].Name = "Quê Quán";
                dgvNhanVien.Columns[8].Name = "Số CMND";
                dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
                dgvNhanVien.Columns[10].Name = "Trạng thái";
                dgvNhanVien.Columns[11].Name = "Ảnh";
                dgvNhanVien.Columns[11].Visible = false;
                dgvNhanVien.Columns[12].Name = "ID Role";
                dgvNhanVien.Columns[12].Visible = false;
                dgvNhanVien.Columns[13].Name = "Flag";
                dgvNhanVien.Columns[13].Visible = false;
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgvNhanVien.Columns.Add(cbo);
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Ảnh Nhân Viên";
                img.Name = "img_nv";
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvNhanVien.Rows.Clear();
                foreach (var x in inhanvienser.getlstnhanvienfromDB().OrderBy(c => c.TenNhanVien))
                {
                    dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }
        void loaddata3()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                dgvNhanVien.ColumnCount = 14;
                dgvNhanVien.Columns[0].Name = "ID Người dùng";
                dgvNhanVien.Columns[0].Visible = false;
                dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
                dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
                dgvNhanVien.Columns[3].Name = "Giới Tính";
                dgvNhanVien.Columns[4].Name = "Năm Sinh";
                dgvNhanVien.Columns[5].Name = "Email";
                dgvNhanVien.Columns[6].Name = "Password";
                dgvNhanVien.Columns[7].Name = "Quê Quán";
                dgvNhanVien.Columns[8].Name = "Số CMND";
                dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
                dgvNhanVien.Columns[10].Name = "Trạng thái";
                dgvNhanVien.Columns[11].Name = "Ảnh";
                dgvNhanVien.Columns[11].Visible = false;
                dgvNhanVien.Columns[12].Name = "ID Role";
                dgvNhanVien.Columns[12].Visible = false;
                dgvNhanVien.Columns[13].Name = "Flag";
                dgvNhanVien.Columns[13].Visible = false;
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgvNhanVien.Columns.Add(cbo);
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Ảnh Nhân Viên";
                img.Name = "img_nv";
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvNhanVien.Rows.Clear();
                foreach (var x in inhanvienser.getlstnhanvienfromDB().OrderByDescending(c => c.Email))
                {
                    dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }
        void loaddata4()
        {
            try
            {
                ArrayList row = new ArrayList();

                row = new ArrayList();
                dgvNhanVien.ColumnCount = 14;
                dgvNhanVien.Columns[0].Name = "ID Người dùng";
                dgvNhanVien.Columns[0].Visible = false;
                dgvNhanVien.Columns[1].Name = "Mã Nhân Viên";
                dgvNhanVien.Columns[2].Name = "Tên Nhân Viên";
                dgvNhanVien.Columns[3].Name = "Giới Tính";
                dgvNhanVien.Columns[4].Name = "Năm Sinh";
                dgvNhanVien.Columns[5].Name = "Email";
                dgvNhanVien.Columns[6].Name = "Password";
                dgvNhanVien.Columns[7].Name = "Quê Quán";
                dgvNhanVien.Columns[8].Name = "Số CMND";
                dgvNhanVien.Columns[9].Name = "Số Điện Thoại";
                dgvNhanVien.Columns[10].Name = "Trạng thái";
                dgvNhanVien.Columns[11].Name = "Ảnh";
                dgvNhanVien.Columns[11].Visible = false;
                dgvNhanVien.Columns[12].Name = "ID Role";
                dgvNhanVien.Columns[12].Visible = false;
                dgvNhanVien.Columns[13].Name = "Flag";
                dgvNhanVien.Columns[13].Visible = false;
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgvNhanVien.Columns.Add(cbo);
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Ảnh Nhân Viên";
                img.Name = "img_nv";
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvNhanVien.Rows.Clear();
                foreach (var x in inhanvienser.getlstnhanvienfromDB().OrderBy(c => c.Email))
                {
                    dgvNhanVien.Rows.Add(x.Iduser, x.MaNhanVien, x.TenNhanVien, x.GioiTinh == 1 ? "Nam" : "Nữ", x.NamSinh, x.Email, x.PassWord, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", x.Anh, x.Idrole == 1 ? "Nhân Viên" : "Quản Lý", x.Flag);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void cbx_loc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_loc.Text == "tên nhân viên từ A đến Z")
                {
                    loaddata2();
                    return;
                }
                if (cbx_loc.Text == "tên nhân viên từ Z đến A")
                {
                    loaddata1();
                    return;
                }
                if (cbx_loc.Text == "email nhân viên từ A đến Z")
                {
                    loaddata4();
                    return;
                }
                if (cbx_loc.Text == "email nhân viên từ Z đến A")
                {
                    loaddata3();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToLongTimeString();
            label16.Text = DateTime.Now.ToLongDateString();
        }
    }
}
