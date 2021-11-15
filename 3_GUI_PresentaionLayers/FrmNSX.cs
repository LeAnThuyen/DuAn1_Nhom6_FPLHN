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
    public partial class FrmNSX : Form
    {
        private QLyNSX nSX;
        private NhaSanXuat _nSX;
        private NhaSanXuatServices _nsxser;
        public FrmNSX()
        {
            InitializeComponent();
            nSX = new QLyNSX();
            _nsxser = new NhaSanXuatServices();
            _nSX = new NhaSanXuat();
            _nsxser.getlstnxsfromDB();
            dgv_nsx.AllowUserToAddRows = false;
            loadata();
        }
        void loadata()
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
            foreach (var x in nSX.GetsList())
            {
                dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
            }
        }

        private void dgv_nsx_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                        _nsxser.addnhasanxuat(new NhaSanXuat()
                        {
                            IdnhaSanXuat = _nsxser.getlstnxsfromDB().Max(c => c.IdnhaSanXuat) + 1,
                            MaNhaSanXuat = txt_MaNSX.Text,
                            TenNhaSanXuat = txt_TenNSX.Text,
                            TrangThai = Convert.ToInt32(cbx_conhang.Checked)

                        });
                        _nsxser.save(_nSX);
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

                        _nSX.IdnhaSanXuat = Convert.ToInt32(dgv_nsx.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _nSX.MaNhaSanXuat = txt_MaNSX.Text;
                        _nSX.TenNhaSanXuat = txt_TenNSX.Text;
                        _nSX.TrangThai = 1;

                        _nsxser.updatenhasanxuat(_nSX);
                        _nsxser.save(_nSX);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
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
            //xóa
            if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_nsx.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_nsx.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                if (commnad == "Xóa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _nsxser.deletenhasanxuat(_nSX);
                        _nsxser.save(_nSX);
                        MessageBox.Show("Xóa Thành Công");
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



        }

        private void dgv_nsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == nSX.GetsList().Count || rowindex == -1) return;
            _nSX = _nsxser.getlstnxsfromDB().ToList().FirstOrDefault(c => c.IdnhaSanXuat == Convert.ToInt32(dgv_nsx.Rows[rowindex].Cells[0].Value.ToString()));
            txt_MaNSX.Text = dgv_nsx.Rows[rowindex].Cells[1].Value.ToString();
            txt_TenNSX.Text = dgv_nsx.Rows[rowindex].Cells[2].Value.ToString();
            cbx_conhang.Checked = dgv_nsx.Rows[rowindex].Cells[3].Value.ToString() == "Còn hàng";
            cbx_hethang.Checked = dgv_nsx.Rows[rowindex].Cells[3].Value.ToString() == "Hết hàng";
        }

        private void cbx_conhang_CheckedChanged_1(object sender, EventArgs e)
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
            int IdnhaSanXuat = Convert.ToInt32(dgv_nsx.Rows[e.RowIndex].Cells[0].Value);
            string ManhaSanXuat = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[1].Value);
            string TennhaSanXuat = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[2].Value);
            string trangthai = Convert.ToString(dgv_nsx.Rows[e.RowIndex].Cells[3].Value);
            // this.Alert("Chào Mừng Bạn Đến Với Thông Tin Chi Tiết Sản Phẩm");
            // FrmBackView frmBackView = new FrmBackView(IdnhaSanXuat, ManhaSanXuat, TennhaSanXuat, trangthai);

            //frmBackView.Show();
        }
        void loadatafortimkiem(string ma)
        {

            dgv_nsx.ColumnCount = 4;
            dgv_nsx.Columns[0].Name = "ID Nhà sản xuất";
            dgv_nsx.Columns[0].Visible = false;
            dgv_nsx.Columns[1].Name = "Mã Nhà sản xuất";
            dgv_nsx.Columns[2].Name = "Tên nhà sản xuất";
            dgv_nsx.Columns[3].Name = "Trạng thái";
            dgv_nsx.Rows.Clear();
            foreach (var x in _nsxser.getlstnxsfromDB().Where(c => c.MaNhaSanXuat.StartsWith(ma)))
            {

                dgv_nsx.Rows.Add(x.IdnhaSanXuat, x.MaNhaSanXuat, x.TenNhaSanXuat, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");

            }

        }
        private void txt_Timkiem_Leave(object sender, EventArgs e)
        {

            if (txt_Timkiem.Text == "")
            {
                txt_Timkiem.Text = "Tìm kiếm theo mã nsx";
                txt_Timkiem.ForeColor = Color.Black;
                _nsxser.getlstnxsfromDB();
                loadata();
            }
        }

        private void txt_Timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadatafortimkiem(txt_Timkiem.Text);
        }

    }
}
