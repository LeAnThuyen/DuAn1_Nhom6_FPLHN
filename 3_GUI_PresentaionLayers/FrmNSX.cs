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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmNSX : Form
    {
        private IServicesNhaSanXuat insxer;
        private QLyNSX nSX;
        private NhaSanXuat _nSX;
        private NhaSanXuatServices _nsxser;
        private IQlyNSX iqlynsx;
        private string except;

        public FrmNSX()
        {
            InitializeComponent();
            iqlynsx = new QLyNSX();
            nSX = new QLyNSX();
            _nsxser = new NhaSanXuatServices();
            _nSX = new NhaSanXuat();
            insxer = new NhaSanXuatServices();
            _nsxser.getlstnxsfromDB();
            dgv_nsx.AllowUserToAddRows = false;
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


                dgv_nsx.ColumnCount = 4;
                dgv_nsx.Columns[0].Name = "ID Nhà sản xuất";
                dgv_nsx.Columns[0].Visible = false;
                dgv_nsx.Columns[1].Name = "Mã Nhà sản xuất";
                dgv_nsx.Columns[2].Name = "Tên nhà sản xuất";
                dgv_nsx.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_nsx.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_nsx.Columns.Add(btn);
                dgv_nsx.Rows.Clear();
                foreach (var x in insxer.getlstnxsfromDB())
                {
                    dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }
        public bool checkup()
        {
            if (string.IsNullOrEmpty(txt_MaNSX.Text))
            {
                MessageBox.Show("Mã NSX không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenNSX.Text))
            {
                MessageBox.Show("Tên NSX không được bỏ trống", "Thông báo");
                return false;
            }

            if (txt_MaNSX.Text.Length <= 3)
            {
                MessageBox.Show("Mã NSX phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaNSX.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã NSX Bắt buộc phải chứa số", "ERR");
                return false;
            }
            //tên
            if (txt_TenNSX.Text.Length <= 3)
            {
                MessageBox.Show("Tên NSX phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenNSX.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên NSX không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenNSX.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên NSX không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaNSX.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã NSX không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (cbx_conhang.Checked == false && cbx_hethang.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txt_TenNSX.Text))
            {
                MessageBox.Show("Tên NSX không được bỏ trống", "Thông báo");
                return false;
            }
            //mã 
            if (string.IsNullOrEmpty(txt_MaNSX.Text))
            {
                MessageBox.Show("Mã NSX không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_MaNSX.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã NSX Bắt buộc phải chứa số", "ERR");
                return false;

            }
            if (Regex.IsMatch(txt_MaNSX.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã NSX không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            for (int i = 0; i < _nsxser.getlstnxsfromDB().Count; i++)
            {
                if (_nsxser.getlstnxsfromDB().ToList()[i].MaNhaSanXuat == txt_MaNSX.Text)
                {
                    MessageBox.Show("Mã NSX Đã tồn Tại yêu cầu nhập mã NSX khác", "ERR");
                    return false;
                }
            }
            //tên
            if (txt_TenNSX.Text.Length <= 3)
            {
                MessageBox.Show("Tên NSX phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenNSX.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên NSX không được chứa số", "ERR");
                return false;
            }

            if (Regex.IsMatch(txt_TenNSX.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên NSX không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            ///trạng thái
            if (cbx_conhang.Checked == false && cbx_hethang.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }

            return true;
        }
        private void dgv_nsx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rd = e.RowIndex;
                dgv_nsx.AllowUserToAddRows = false;


                //thêm
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_nsx.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_nsx.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Thêm")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (Check() == false)
                            {
                                return;
                            }
                            insxer.addnhasanxuat(new NhaSanXuat()
                            {
                                IdnhaSanXuat = insxer.getlstnxsfromDB().Max(c => c.IdnhaSanXuat) + 1,
                                MaNhaSanXuat = txt_MaNSX.Text,
                                TenNhaSanXuat = txt_TenNSX.Text,
                                TrangThai = Convert.ToInt32(cbx_conhang.Checked)

                            });
                            insxer.save(_nSX);
                            MessageBox.Show("Thêm Thành Công", "Thông Báo");
                            _nsxser.getlstnxsfromDB();
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
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_nsx.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_nsx.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Sửa")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (checkup() == false)
                            {
                                return;
                            }
                            _nSX.IdnhaSanXuat = Convert.ToInt32(dgv_nsx.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _nSX.MaNhaSanXuat = txt_MaNSX.Text;
                            _nSX.TenNhaSanXuat = txt_TenNSX.Text;
                            _nSX.TrangThai = 1;

                            insxer.updatenhasanxuat(_nSX);
                            insxer.save(_nSX);
                            MessageBox.Show("Sửa Thành Công", "Thông Báo");
                            insxer.getlstnxsfromDB();
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
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_nsx.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_nsx.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                    if (commnad == "Xóa")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _nSX.IdnhaSanXuat = Convert.ToInt32(dgv_nsx.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _nSX.MaNhaSanXuat = txt_MaNSX.Text;
                            _nSX.TenNhaSanXuat = txt_TenNSX.Text;
                            _nSX.TrangThai = 0;

                            insxer.updatenhasanxuat(_nSX);
                            insxer.save(_nSX);
                            MessageBox.Show("Xóa Thành Công");
                            insxer.getlstnxsfromDB();
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

        private void dgv_nsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == nSX.GetsList().Count || rowindex == -1) return;
                _nSX = insxer.getlstnxsfromDB().ToList().FirstOrDefault(c => c.IdnhaSanXuat == Convert.ToInt32(dgv_nsx.Rows[rowindex].Cells[0].Value.ToString()));
                txt_MaNSX.Text = dgv_nsx.Rows[rowindex].Cells[1].Value.ToString();
                txt_TenNSX.Text = dgv_nsx.Rows[rowindex].Cells[2].Value.ToString();
                cbx_conhang.Checked = dgv_nsx.Rows[rowindex].Cells[3].Value.ToString() == "Hoạt động";
                cbx_hethang.Checked = dgv_nsx.Rows[rowindex].Cells[3].Value.ToString() == "Không hoạt động";
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void cbx_conhang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_conhang.Checked)
            {
                cbx_hethang.Checked = false;
            }
        }

        private void cbx_hethang_CheckedChanged(object sender, EventArgs e)
        {

            if (cbx_hethang.Checked)
            {
                cbx_conhang.Checked = false;
            }
        }

        private void dgv_nsx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IdnhaSanXuat = Convert.ToInt32(dgv_nsx.Rows[e.RowIndex].Cells[0].Value);
                string ManhaSanXuat = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[1].Value);
                string TennhaSanXuat = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[2].Value);
                string trangthai = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[3].Value);
                // this.Alert("Chào Mừng Bạn Đến Với Thông Tin Chi Tiết Sản Phẩm");
                // FrmBackView frmBackView = new FrmBackView(IdnhaSanXuat, ManhaSanXuat, TennhaSanXuat, trangthai);

                //frmBackView.Show();
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

                dgv_nsx.ColumnCount = 4;
                dgv_nsx.Columns[0].Name = "ID Nhà sản xuất";
                dgv_nsx.Columns[0].Visible = false;
                dgv_nsx.Columns[1].Name = "Mã Nhà sản xuất";
                dgv_nsx.Columns[2].Name = "Tên nhà sản xuất";
                dgv_nsx.Columns[3].Name = "Trạng thái";
                dgv_nsx.Rows.Clear();
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_nsx.Columns.Add(cbo);
                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_nsx.Columns.Add(btn);
                foreach (var x in insxer.getlstnxsfromDB().Where(c => c.MaNhaSanXuat.StartsWith(ma)))
                {

                    dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }

        }
        private void txt_Timkiem_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txt_Timkiem.Text == "")
                {
                    txt_Timkiem.Text = "Tìm kiếm theo mã nsx";
                    txt_Timkiem.ForeColor = Color.Black;
                    insxer.getlstnxsfromDB();
                    loadata();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void txt_Timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadatafortimkiem(txt_Timkiem.Text);
        }
        void loc()
        {
            ArrayList row1 = new ArrayList();

            row1 = new ArrayList();
            row1.Add("từ A đến Z");
            row1.Add("từ Z đến A");
            cbx_loc.Items.AddRange(row1.ToArray());

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

                dgv_nsx.ColumnCount = 4;
                dgv_nsx.Columns[0].Name = "ID Nhà sản xuất";
                dgv_nsx.Columns[0].Visible = false;
                dgv_nsx.Columns[1].Name = "Mã Nhà sản xuất";
                dgv_nsx.Columns[2].Name = "Tên nhà sản xuất";
                dgv_nsx.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_nsx.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_nsx.Columns.Add(btn);



                dgv_nsx.Rows.Clear();
                foreach (var x in insxer.getlstnxsfromDB().OrderByDescending(c => c.TenNhaSanXuat))
                {
                    dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
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

                dgv_nsx.ColumnCount = 4;
                dgv_nsx.Columns[0].Name = "ID Nhà sản xuất";
                dgv_nsx.Columns[0].Visible = false;
                dgv_nsx.Columns[1].Name = "Mã Nhà sản xuất";
                dgv_nsx.Columns[2].Name = "Tên nhà sản xuất";
                dgv_nsx.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_nsx.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_nsx.Columns.Add(btn);



                dgv_nsx.Rows.Clear();
                foreach (var x in insxer.getlstnxsfromDB().OrderBy(c => c.TenNhaSanXuat))
                {
                    dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void cbx_loc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_loc.Text == "từ A đến Z")
                {
                    loaddata2();
                    return;
                }
                if (cbx_loc.Text == "từ Z đến A")
                {
                    loaddata1();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Hiếu Để Sửa Lỗi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
