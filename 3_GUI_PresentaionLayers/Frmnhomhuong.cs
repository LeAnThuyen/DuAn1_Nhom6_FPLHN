using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL_DataAccessLayer.Models;
using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;

namespace _3_GUI_PresentaionLayers
{
    public partial class Frmnhomhuong : Form
    {
        private IQlyNhomHuong _iQlyNhomHuong;
        private Frmnhomhuong NhomHuongg;
        public Frmnhomhuong()
        {
            InitializeComponent();
            _iQlyNhomHuong = new QLyNhomHuongServices();
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
            dgridNhomHuong.ColumnCount = 4;
            dgridNhomHuong.Columns[0].Name = "ID";
            dgridNhomHuong.Columns[0].Visible = false;
            dgridNhomHuong.Columns[1].Name = "Mã chất liệu";
            dgridNhomHuong.Columns[2].Name = "Tên chất chất liệu";
            dgridNhomHuong.Columns[3].Name = "Trạng thái";
            dgridNhomHuong.Rows.Clear();
            foreach (var x in _iQlyNhomHuong.GetsList())
            {
                dgridNhomHuong.Rows.Add(x.IdnhomHuong, x.MaNhomHuong, x.TenNhomHuong,
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

            dgridNhomHuong.Columns.Add(dcColumn);
            dgridNhomHuong.Columns.Add(buttonColumn);
        }
        private void dgridNhomHuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (e.ColumnIndex == dgridNhomHuong.Columns["Ok"].Index)
            {
                if (dgridNhomHuong.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Thêm")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    _1_DAL_DataAccessLayer.Models.NhomHuong nhomHuong = new _1_DAL_DataAccessLayer.Models.NhomHuong()
                    {
                        IdnhomHuong = _iQlyNhomHuong.GetsList().Max(x => x.IdnhomHuong) + 1,
                        MaNhomHuong = "NH0001" + _iQlyNhomHuong.GetsList().Max(x => x.IdnhomHuong) + 1,
                        TenNhomHuong = dgridNhomHuong.Rows[rowIndex].Cells[2].Value.ToString(),
                        TrangThai = dgridNhomHuong.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0
                    };
                    _iQlyNhomHuong.addNV(nhomHuong);
                    LoadData();

                    MessageBox.Show("Thêm thành công");
                }

                if (Convert.ToString(dgridNhomHuong.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Sửa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    var nhomhuong = _iQlyNhomHuong.GetsList().FirstOrDefault(x =>
                        x.IdnhomHuong == Convert.ToInt32(dgridNhomHuong.Rows[rowIndex].Cells[0].Value.ToString()));
                    nhomhuong.TenNhomHuong = dgridNhomHuong.Rows[rowIndex].Cells[2].Value.ToString();
                    nhomhuong.TrangThai = dgridNhomHuong.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0;


                    _iQlyNhomHuong.updateNV(nhomhuong);
                    LoadData();
                }

                if (Convert.ToString(dgridNhomHuong.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Xóa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    var NhpmHuong = _iQlyNhomHuong.GetsList().FirstOrDefault(x =>
                        x.IdnhomHuong == Convert.ToInt32(dgridNhomHuong.Rows[rowIndex].Cells[0].Value.ToString()));
                    _iQlyNhomHuong.removeNV(NhpmHuong);
                    LoadData();
                }

                LoadData();
            }
        }

        private void dgridNhomHuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //if ((rowIndex > _iQlyNhomHuong.GetsList().Count) || rowIndex < 0) return;
            txtMaCL.Text = Convert.ToString(dgridNhomHuong.Rows[rowIndex].Cells[1].Value);
            txtTenChatLieu.Text = Convert.ToString(dgridNhomHuong.Rows[rowIndex].Cells[2].Value);
            ckbON.Checked = dgridNhomHuong.Rows[rowIndex].Cells[3].Value == "Sử dụng" ? true : false;
            chkOFF.Checked = dgridNhomHuong.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
