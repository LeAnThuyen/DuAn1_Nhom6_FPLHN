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
    public partial class FrmAnh : Form
    {
        private QLyAnh anh;
        private Anh _anh;
        private AnhServices _anhSer;
        public FrmAnh()
        {
            InitializeComponent();
            anh = new QLyAnh();
            _anhSer = new AnhServices();
            _anh = new Anh();
            _anhSer.getlstanhfromDB();
            dgv_anh.AllowUserToAddRows = false;
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


            dgv_anh.ColumnCount = 5;
            dgv_anh.Columns[0].Name = "ID Ảnh";
            dgv_anh.Columns[0].Visible = false;
            dgv_anh.Columns[1].Name = "Mã Ảnh";
            dgv_anh.Columns[2].Name = "Tên Ảnh";
            dgv_anh.Columns[3].Name = "Đưỡng dẫn";
            dgv_anh.Columns[4].Name = "Trạng thái";
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_anh.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_anh.Columns.Add(btn);
            dgv_anh.Rows.Clear();
            foreach (var x in anh.GetsList())
            {
                dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.DuongDan, x.TrangThai == 1 ? "Có ảnh" : "Chưa có ảnh");
            }
        }
        private void dgv_anh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            dgv_anh.AllowUserToAddRows = false;


            //thêm
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgv_anh.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_anh.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Thêm")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _anhSer.addanh(new Anh()
                        {
                            Idanh = _anhSer.getlstanhfromDB().Max(c => c.Idanh) + 1,
                            MaAnh = txt_MaAnh.Text,
                            TenAnh = txt_TenAnh.Text,
                            DuongDan = txt_DuongDan.Text,

                            TrangThai = Convert.ToInt32(cbx_CoAnh.Checked)

                        });
                        _anhSer.save(_anh);
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                        _anhSer.getlstanhfromDB();
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
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgv_anh.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_anh.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Sửa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _anh.Idanh = Convert.ToInt32(dgv_anh.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _anh.MaAnh = txt_MaAnh.Text;
                        _anh.TenAnh = txt_TenAnh.Text;
                        _anh.DuongDan = txt_DuongDan.Text;
                        _anh.TrangThai = 1;

                        _anhSer.updateanh(_anh);
                        _anhSer.save(_anh);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
                        _anhSer.getlstanhfromDB();
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
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(dgv_anh.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_anh.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                if (commnad == "Xóa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _anhSer.deleteanh(_anh);
                        _anhSer.save(_anh);
                        MessageBox.Show("Xóa Thành Công");
                        _anhSer.getlstanhfromDB();
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

        private void dgv_anh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == anh.GetsList().Count || rowindex == -1) return;
            _anh = _anhSer.getlstanhfromDB().ToList().FirstOrDefault(c => c.Idanh == Convert.ToInt32(dgv_anh.Rows[rowindex].Cells[0].Value.ToString()));
            txt_MaAnh.Text = dgv_anh.Rows[rowindex].Cells[1].Value.ToString();
            txt_TenAnh.Text = dgv_anh.Rows[rowindex].Cells[2].Value.ToString();
            txt_DuongDan.Text = dgv_anh.Rows[rowindex].Cells[3].Value.ToString();
            cbx_CoAnh.Checked = dgv_anh.Rows[rowindex].Cells[4].Value.ToString() == "Có ảnh";
            cbx_Kcoanh.Checked = dgv_anh.Rows[rowindex].Cells[4].Value.ToString() == "Chưa có ảnh";
        }

        private void cbx_CoAnh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_CoAnh.Checked)
            {
                cbx_CoAnh.Checked = false;
            }
        }

        private void cbx_Kcoanh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_Kcoanh.Checked)
            {
                cbx_Kcoanh.Checked = false;
            }

        }

        private void dgv_anh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Idanh = Convert.ToInt32(dgv_anh.Rows[e.RowIndex].Cells[0].Value);
            string Maanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[1].Value);
            string Tenanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[2].Value);
            string DuongDan = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[3].Value);
            string trangthai = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[4].Value);
        }

        void loadatafortimkiem(string ma)
        {

            dgv_anh.ColumnCount = 5;
            dgv_anh.Columns[0].Name = "ID ảnh";
            dgv_anh.Columns[0].Visible = false;
            dgv_anh.Columns[1].Name = "Mã ảnht";
            dgv_anh.Columns[2].Name = "Tên ảnh";
            dgv_anh.Columns[3].Name = "Đường dẫn";
            dgv_anh.Columns[4].Name = "Trạng thái";
            dgv_anh.Rows.Clear();
            foreach (var x in _anhSer.getlstanhfromDB().Where(c => c.MaAnh.StartsWith(ma)))
            {

                dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.DuongDan, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");

            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void txt_timkiem_Leave(object sender, EventArgs e)
        {
            if (txt_timkiem.Text == "")
            {
                txt_timkiem.Text = "Tìm kiếm theo mã nsx";
                txt_timkiem.ForeColor = Color.Black;
                _anhSer.getlstanhfromDB();
                loadata();
            }
        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loadatafortimkiem(txt_timkiem.Text);
        }

    }
}
