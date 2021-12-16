using _1_DAL_DataAccessLayer.DALServices;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using System;
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
    public partial class FrmDanhMuc : Form
    {
        private IQlyDanhMuc _iqlyDanhMuc;
        private DanhMuc danhMuc;
        Frm_EditHangHoa Frm_EditHangHoa;
        private HangHoaServices _hhser;
      
        public FrmDanhMuc()
        {
            InitializeComponent();
            _iqlyDanhMuc = new QLyDanhMucServices();
            _hhser = new HangHoaServices();
            css();
            LoadData();
         
        }
        void css()
        {
            label4.AutoSize = false;
            label4.Height = 2;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label3.AutoSize = false;
            label3.Height = 2;
            label3.BorderStyle = BorderStyle.Fixed3D;
        }

        void LoadData()
        {
            dgridDanhMuc.ColumnCount = 4;
            dgridDanhMuc.Columns[0].Name = "ID";
            dgridDanhMuc.Columns[0].Visible = false;
            dgridDanhMuc.Columns[1].Name = "Mã danh mục";
            dgridDanhMuc.Columns[2].Name = "Tên danh mục";
            dgridDanhMuc.Columns[3].Name = "Trạng thái";
            dgridDanhMuc.Rows.Clear();
            foreach (var x in _iqlyDanhMuc.GetsList())
            {
                dgridDanhMuc.Rows.Add(x.IddanhMuc, x.MaDanhMuc, x.TenDanhMuc,
                    x.TrangThai == 1 ? "Sử dụng" : "Không sử dụng");
            }
            DataGridViewComboBoxColumn dcColumn = new DataGridViewComboBoxColumn();
            dcColumn.HeaderText = "CRUD";
            dcColumn.Items.Add("Thêm");
            dcColumn.Items.Add("Sửa");
            dcColumn.Items.Add("Xóa");

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Xác nhận";
            buttonColumn.Text = "OK";
            buttonColumn.Name = "OK";

            dgridDanhMuc.Columns.Add(dcColumn);
            dgridDanhMuc.Columns.Add(buttonColumn);
        }
        public bool checkup()
        {
            if (string.IsNullOrEmpty(txtMaDM.Text))
            {
                MessageBox.Show("Mã Danh Mục không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDM.Text))
            {
                MessageBox.Show("Tên Danh Mục không được bỏ trống", "Thông báo");
                return false;
            }
            if (ckbON.Checked == false && chkOFF.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }

            if (txtMaDM.Text.Length <= 3)
            {
                MessageBox.Show("Mã Danh Mục phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtMaDM.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Danh Mục bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (txtTenDM.Text.Length <= 3)
            {
                MessageBox.Show("Tên Danh Mục phải trên 3 ký tự", "ERR");
                return false;
            }
            //tên
            if (txtTenDM.Text.Length <= 3)
            {
                MessageBox.Show("Tên Danh Mục phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtTenDM.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Danh Mục không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txtTenDM.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Tên Danh Mục chứa ký tự đặc biệt", "ERR");
                return false;
            }


            return true;
        }
        private void txtTenChatLieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgridDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;

                if (e.ColumnIndex == dgridDanhMuc.Columns["Ok"].Index)
                {
                    if (dgridDanhMuc.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Thêm")
                    {
                        var x = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (x == DialogResult.No)
                        {
                            return;
                        }

                        _1_DAL_DataAccessLayer.Models.DanhMuc danhMuc = new _1_DAL_DataAccessLayer.Models.DanhMuc()
                        {
                            IddanhMuc = _iqlyDanhMuc.GetsList().Max(x => x.IddanhMuc) + 1,
                            MaDanhMuc = "DM001" + _iqlyDanhMuc.GetsList().Max(x => x.IddanhMuc) + 1,
                            TenDanhMuc = dgridDanhMuc.Rows[rowIndex].Cells[2].Value.ToString(),
                            TrangThai = dgridDanhMuc.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0
                        };
                        _iqlyDanhMuc.addNV(danhMuc);
                        LoadData();

                        MessageBox.Show("Thêm thành công");
                    }

                    if (Convert.ToString(dgridDanhMuc.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Sửa")
                    {
                        var x = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (x == DialogResult.No)
                        {
                            return;
                        }

                        var danhmuc = _iqlyDanhMuc.GetsList().FirstOrDefault(x =>
                            x.IddanhMuc == Convert.ToInt32(dgridDanhMuc.Rows[rowIndex].Cells[0].Value.ToString()));
                        danhmuc.TenDanhMuc = dgridDanhMuc.Rows[rowIndex].Cells[2].Value.ToString();
                        danhmuc.TrangThai = dgridDanhMuc.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0;


                        _iqlyDanhMuc.updateNV(danhmuc);
                        LoadData();
                    }

                    if (Convert.ToString(dgridDanhMuc.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Xóa")
                    {
                        var x = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (x == DialogResult.No)
                        {
                            return;
                        }

                        var danhmucc = _iqlyDanhMuc.GetsList().FirstOrDefault(x =>
                            x.IddanhMuc == Convert.ToInt32(dgridDanhMuc.Rows[rowIndex].Cells[0].Value.ToString()));
                        _iqlyDanhMuc.removeNV(danhmucc);
                        LoadData();
                    }

                    LoadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Bình Để Sửa Lỗi");
            }
        }

        private void dgridDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowIndex = e.RowIndex;
                //if ((rowIndex > _iQlyNhomHuong.GetsList().Count) || rowIndex < 0) return;
                txtMaDM.Text = Convert.ToString(dgridDanhMuc.Rows[rowIndex].Cells[1].Value);
                txtTenDM.Text = Convert.ToString(dgridDanhMuc.Rows[rowIndex].Cells[2].Value);
                ckbON.Checked = dgridDanhMuc.Rows[rowIndex].Cells[3].Value == "Sử dụng" ? true : false;
                chkOFF.Checked = dgridDanhMuc.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? true : false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Bình Để Sửa Lỗi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

