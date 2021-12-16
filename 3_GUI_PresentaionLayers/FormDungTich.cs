using _1_DAL_DataAccessLayer.DALServices;
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
    public partial class FormDungTich : Form
    {
        private QLyDungTich dungTich;
        private DungTich _dungTich;
        private IQlyDungTich idtser;
        public FormDungTich()
        {

            InitializeComponent();
            idtser = new QLyDungTich();
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


                dgv_DungTich.ColumnCount = 4;
                dgv_DungTich.Columns[0].Name = "ID Dung tích";
                dgv_DungTich.Columns[0].Visible = false;
                dgv_DungTich.Columns[1].Name = "Mã Dung tích";
                dgv_DungTich.Columns[2].Name = "Số dung tích";
                dgv_DungTich.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_DungTich.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_DungTich.Columns.Add(btn);
                dgv_DungTich.Rows.Clear();
                foreach (var x in idtser.GetsList())
                {
                    dgv_DungTich.Rows.Add(x.IddungTich, x.MaDungTich, x.SoDungTich, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void dgv_DungTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DungTich_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void chk_ConHang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_HetHang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgv_DungTich_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rd = e.RowIndex;
                dgv_DungTich.AllowUserToAddRows = false;


                //thêm
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_DungTich.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_DungTich.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Thêm")
                    {
                        if (check() == false)
                        {
                            return;
                        }
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            idtser.addDT(new DungTich()
                            {
                                IddungTich = idtser.GetsList().Max(c => c.IddungTich) + 1,
                                MaDungTich = txtMaDungTich.Text,
                                SoDungTich = Convert.ToInt32(txtSoDungTich.Text),
                                TrangThai = Convert.ToInt32(chk_ConHang.Checked)

                            });
                            idtser.Save(_dungTich);
                            MessageBox.Show("Thêm Thành Công", "Thông Báo");
                            idtser.GetsList();
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
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_DungTich.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_DungTich.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                    if (commnad == "Sửa")
                    {
                        if (checkup() == false)
                        {
                            return;
                        }
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            _dungTich.IddungTich = Convert.ToInt32(dgv_DungTich.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _dungTich.MaDungTich = txtMaDungTich.Text;
                            _dungTich.SoDungTich = Convert.ToInt32(txtSoDungTich.Text);
                            _dungTich.TrangThai = 1;

                            idtser.updateDT(_dungTich);
                            idtser.Save(_dungTich);
                            MessageBox.Show("Sửa Thành Công", "Thông Báo");
                            idtser.GetsList();
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
                if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_DungTich.Rows[rd].Cells["cbo"].Value.ToString()) == false)
                {

                    string commnad = dgv_DungTich.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                    if (commnad == "Xóa")
                    {
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _dungTich.IddungTich = Convert.ToInt32(dgv_DungTich.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _dungTich.MaDungTich = txtMaDungTich.Text;
                            _dungTich.SoDungTich = Convert.ToInt32(txtSoDungTich.Text);
                            _dungTich.TrangThai = 0;

                            idtser.updateDT(_dungTich);
                            idtser.Save(_dungTich);
                            MessageBox.Show("Xóa Thành Công", "Thông Báo");
                            idtser.GetsList();
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

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }
        public bool check()
        {
            //phần check chống
            #region
            if (string.IsNullOrEmpty(txtMaDungTich.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtSoDungTich.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion
            #region
            if (Regex.IsMatch(txtSoDungTich.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số dung tích không được chứa chữ cái", "ERR");
                return false;
            }
            if (Convert.ToInt32(txtSoDungTich.Text) <= 0 && Convert.ToInt32(txtSoDungTich.Text) >= 100000)
            {

                MessageBox.Show("số dung tích không hợp lệ", "ERR");
                return false;
            }
            #endregion
            for (int i = 0; i < idtser.GetsList().Count; i++)
            {
                if (idtser.GetsList().ToList()[i].MaDungTich == txtMaDungTich.Text)
                {
                    MessageBox.Show("Mã dung tích Đã tồn Tại yêu cầu nhập mã dung tích khác", "ERR");
                    return false;
                }
            }
            return true;
        }
        public bool checkup()
        {
            //phần check chống
            #region
            if (string.IsNullOrEmpty(txtMaDungTich.Text))
            {
                MessageBox.Show("Mã dung tích không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtSoDungTich.Text))
            {
                MessageBox.Show("số dung tích không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion
            #region
            if (Regex.IsMatch(txtSoDungTich.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số dung tích không được chứa chữ cái", "ERR");
                return false;
            }
            if (Convert.ToInt32(txtSoDungTich.Text) <= 0 && Convert.ToInt32(txtSoDungTich.Text) >= 100000)
            {

                MessageBox.Show("số dung tích không hợp lệ", "ERR");
                return false;
            }
            #endregion
            //for (int i = 0; i < idtser.GetsList().Count; i++)
            //{
            //    if (idtser.GetsList().ToList()[i].MaDungTich == txtMaDungTich.Text)
            //    {
            //        MessageBox.Show("Mã dung tích Đã tồn Tại yêu cầu nhập mã dung tích khác", "ERR");
            //        return false;
            //    }
            //}
            return true;
        }

        private void dgv_DungTich_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == idtser.GetsList().Count || rowindex == -1) return;
                _dungTich = idtser.GetsList().ToList().FirstOrDefault(c => c.IddungTich == Convert.ToInt32(dgv_DungTich.Rows[rowindex].Cells[0].Value.ToString()));
                txtMaDungTich.Text = dgv_DungTich.Rows[rowindex].Cells[1].Value.ToString();
                txtSoDungTich.Text = dgv_DungTich.Rows[rowindex].Cells[2].Value.ToString();
                chk_ConHang.Checked = dgv_DungTich.Rows[rowindex].Cells[3].Value.ToString() == "Còn hàng";
                chk_HetHang.Checked = dgv_DungTich.Rows[rowindex].Cells[3].Value.ToString() == "Hết hàng";
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void chk_ConHang_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_ConHang.Checked)
            {
                chk_HetHang.Checked = false;
            }
        }

        private void chk_HetHang_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_HetHang.Checked)
            {
                chk_ConHang.Checked = false;
            }
        }

        void loadtim_kiem(string ma)
        {
            try
            {
                dgv_DungTich.ColumnCount = 4;
                dgv_DungTich.Columns[0].Name = "ID Dung tích";
                dgv_DungTich.Columns[0].Visible = false;
                dgv_DungTich.Columns[1].Name = "Mã Dung tích";
                dgv_DungTich.Columns[2].Name = "Số dung tích";
                dgv_DungTich.Columns[3].Name = "Trạng thái";
                dgv_DungTich.Rows.Clear();
                foreach (var x in idtser.GetsList().Where(c => c.MaDungTich.StartsWith(ma)))
                {
                    dgv_DungTich.Rows.Add(x.IddungTich, x.MaDungTich, x.SoDungTich, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_TimKiem.Text == "")
                {
                    txt_TimKiem.Text = "Tìm kiếm theo mã dung tích";
                    txt_TimKiem.ForeColor = Color.Black;
                    idtser.GetsList();
                    loadata();
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
        void loc()
        {
            ArrayList row1 = new ArrayList();

            row1 = new ArrayList();
            row1.Add("mã dung tích từ A đến Z");
            row1.Add("mã dung tích từ Z đến A");
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

                // combobox


                dgv_DungTich.ColumnCount = 4;
                dgv_DungTich.Columns[0].Name = "ID Dung tích";
                dgv_DungTich.Columns[0].Visible = false;
                dgv_DungTich.Columns[1].Name = "Mã Dung tích";
                dgv_DungTich.Columns[2].Name = "Số dung tích";
                dgv_DungTich.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_DungTich.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_DungTich.Columns.Add(btn);
                dgv_DungTich.Rows.Clear();
                foreach (var x in idtser.GetsList().OrderByDescending(c => c.MaDungTich))
                {
                    dgv_DungTich.Rows.Add(x.IddungTich, x.MaDungTich, x.SoDungTich, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
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
                row.Add("Thêm");
                row.Add("Sửa");
                row.Add("Xóa");

                // combobox


                dgv_DungTich.ColumnCount = 4;
                dgv_DungTich.Columns[0].Name = "ID Dung tích";
                dgv_DungTich.Columns[0].Visible = false;
                dgv_DungTich.Columns[1].Name = "Mã Dung tích";
                dgv_DungTich.Columns[2].Name = "Số dung tích";
                dgv_DungTich.Columns[3].Name = "Trạng thái";
                DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
                cbo.HeaderText = "Chức Năng";
                cbo.Name = "cbo";
                cbo.Items.AddRange(row.ToArray());
                dgv_DungTich.Columns.Add(cbo);


                ////button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Xác Nhận";
                btn.HeaderText = "Xác Nhận";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dgv_DungTich.Columns.Add(btn);
                dgv_DungTich.Rows.Clear();
                foreach (var x in idtser.GetsList().OrderBy(c => c.MaDungTich))
                {
                    dgv_DungTich.Rows.Add(x.IddungTich, x.MaDungTich, x.SoDungTich, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
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
                if (cbx_loc.Text == "mã dung tích từ A đến Z")
                {
                    loaddata2();
                    return;
                }
                if (cbx_loc.Text == "mã dung tích từ Z đến A")
                {
                    loaddata1();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Hãy Liên Hệ Với Thắng Để Sửa Lỗi");
            }
        }

        private void cbx_loc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
