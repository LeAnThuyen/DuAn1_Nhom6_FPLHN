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
    public partial class FrmVatChua : Form
    {
        private IQlyVatChua _iQlyVatChua;
        public FrmVatChua()
        {
            InitializeComponent();
            _iQlyVatChua = new QLyVatChuaServices();
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
            dgridVatChua.ColumnCount = 4;
            dgridVatChua.Columns[0].Name = "ID";
            dgridVatChua.Columns[0].Visible = false;
            dgridVatChua.Columns[1].Name = "Mã chất liệu";
            dgridVatChua.Columns[2].Name = "Tên chất chất liệu";
            dgridVatChua.Columns[3].Name = "Trạng thái";
            dgridVatChua.Rows.Clear();
            foreach (var x in _iQlyVatChua.GetsList())
            {
                dgridVatChua.Rows.Add(x.IdvatChua, x.MaVatChua, x.TenVatChua,
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

            dgridVatChua.Columns.Add(dcColumn);
            dgridVatChua.Columns.Add(buttonColumn);
        }

        private void dgridVatChua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (e.ColumnIndex == dgridVatChua.Columns["Ok"].Index)
            {
                if (dgridVatChua.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Thêm")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    _1_DAL_DataAccessLayer.Models.VatChua VatChua = new _1_DAL_DataAccessLayer.Models.VatChua()
                    {
                        IdvatChua = _iQlyVatChua.GetsList().Max(x => x.IdvatChua) + 1,
                        MaVatChua = "VC0001" + _iQlyVatChua.GetsList().Max(x => x.IdvatChua) + 1,
                        TenVatChua = dgridVatChua.Rows[rowIndex].Cells[2].Value.ToString(),
                        TrangThai = dgridVatChua.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0
                    };
                    _iQlyVatChua.addNV(VatChua);
                    LoadData();
                    LoadData();

                    MessageBox.Show("Thêm thành công");
                    return;
                }

                if (Convert.ToString(dgridVatChua.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Sửa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    var nhomhuong = _iQlyVatChua.GetsList().FirstOrDefault(x =>
                        x.IdvatChua == Convert.ToInt32(dgridVatChua.Rows[rowIndex].Cells[0].Value.ToString()));
                    nhomhuong.TenVatChua = dgridVatChua.Rows[rowIndex].Cells[2].Value.ToString();
                    nhomhuong.TrangThai = dgridVatChua.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0;


                    _iQlyVatChua.updateNV(nhomhuong);
                    LoadData();
                }

                if (Convert.ToString(dgridVatChua.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Xóa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    var NhpmHuong = _iQlyVatChua.GetsList().FirstOrDefault(x =>
                        x.IdvatChua == Convert.ToInt32(dgridVatChua.Rows[rowIndex].Cells[0].Value.ToString()));
                    _iQlyVatChua.removeNV(NhpmHuong);
                    LoadData();
                    return;
                }

                LoadData();
            }
        }

        private void dgridVatChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if ((rowIndex > _iQlyVatChua.GetsList().Count) || rowIndex < 0) return;
            txtMaCL.Text = dgridVatChua.Rows[rowIndex].Cells[1].Value.ToString();
            txtTenChatLieu.Text = dgridVatChua.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void dgridVatChua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //if ((rowIndex > _iQlyNhomHuong.GetsList().Count) || rowIndex < 0) return;
            txtMaCL.Text = Convert.ToString(dgridVatChua.Rows[rowIndex].Cells[1].Value);
            txtTenChatLieu.Text = Convert.ToString(dgridVatChua.Rows[rowIndex].Cells[2].Value);
            ckbON.Checked = dgridVatChua.Rows[rowIndex].Cells[3].Value == "Sử dụng" ? true : false;
            chkOFF.Checked = dgridVatChua.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? true : false;
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
