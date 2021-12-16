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
    public partial class FormXuatXu : Form
    {
        private IServicesXuatXu ixuatxuser;
        private QlyXuatXu xuatXu;
        private XuatXu _xuatXu;
        private XuatXuService _xuatXuSer;
        public FormXuatXu()
        {
            InitializeComponent();
            xuatXu = new QlyXuatXu();
            _xuatXu = new XuatXu();
            ixuatxuser = new XuatXuService();

            //dgv_XuatXu.AllowUserToAddRows = false;
            loaddata();
            loc();
        }
        void loaddata()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgv_XuatXu.ColumnCount = 4;
            dgv_XuatXu.Columns[0].Name = "ID Quoc Gia";
            dgv_XuatXu.Columns[0].Visible = false;
            dgv_XuatXu.Columns[1].Name = "Mã Quốc Gia";
            dgv_XuatXu.Columns[2].Name = "Tên Quốc Gia";
            dgv_XuatXu.Columns[3].Name = "Trạng thái";
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_XuatXu.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_XuatXu.Columns.Add(btn);



            dgv_XuatXu.Rows.Clear();
            foreach (var x in ixuatxuser.getlstxuatxufromDB())
            {
                dgv_XuatXu.Rows.Add(x.IdquocGia, x.MaQuocGia, x.TenQuocGia, x.TrangThai == 1 ? "Tồn tại" : "Không tồn tại");
            }
        }

        private void dgv_XuatXu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_XuatXu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_XuatXu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == ixuatxuser.getlstxuatxufromDB().Count || rowindex == -1) return;
            _xuatXu = ixuatxuser.getlstxuatxufromDB().ToList().FirstOrDefault(c => c.IdquocGia == Convert.ToInt32(dgv_XuatXu.Rows[rowindex].Cells[0].Value.ToString()));
            txtMaQuocGia.Text = dgv_XuatXu.Rows[rowindex].Cells[1].Value.ToString();
            cbxTenQuocGia.Text = dgv_XuatXu.Rows[rowindex].Cells[2].Value.ToString();
            chkHoatDong.Checked = dgv_XuatXu.Rows[rowindex].Cells[3].Value.ToString() == "Hoạt Động";
            ChkKhongHoatDong.Checked = dgv_XuatXu.Rows[rowindex].Cells[3].Value.ToString() == "Không Hoạt Động";
        }

        private void dgv_XuatXu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            dgv_XuatXu.AllowUserToAddRows = false;


            //thêm
            if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_XuatXu.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_XuatXu.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Thêm")
                {
                    if (check() == false)
                    {
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        ixuatxuser.addxuatxu(new XuatXu()
                        {
                            IdquocGia = _xuatXuSer.getlstxuatxufromDB().Max(c => c.IdquocGia) + 1,
                            MaQuocGia = txtMaQuocGia.Text,
                            TenQuocGia = cbxTenQuocGia.Text,


                        });
                        ixuatxuser.save(_xuatXu);
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                        ixuatxuser.getlstxuatxufromDB();
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
            if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_XuatXu.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_XuatXu.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Sửa")
                {
                    if (checkup() == false)
                    {
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _xuatXu.IdquocGia = Convert.ToInt32(dgv_XuatXu.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _xuatXu.MaQuocGia = txtMaQuocGia.Text;
                        _xuatXu.TenQuocGia = cbxTenQuocGia.Text;


                        ixuatxuser.updatexuatxu(_xuatXu);
                        ixuatxuser.save(_xuatXu);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
                        ixuatxuser.getlstxuatxufromDB();
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
            if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_XuatXu.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_XuatXu.Rows[e.RowIndex].Cells["cbo"].Value.ToString();
                if (commnad == "Xóa")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _xuatXu.IdquocGia = Convert.ToInt32(dgv_XuatXu.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _xuatXu.MaQuocGia = txtMaQuocGia.Text;
                        _xuatXu.TenQuocGia = cbxTenQuocGia.Text;
                        _xuatXu.TrangThai = 0;
                        ixuatxuser.updatexuatxu(_xuatXu);
                        ixuatxuser.save(_xuatXu);
                        MessageBox.Show("Xóa Thành Công");
                        ixuatxuser.getlstxuatxufromDB();
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
        public bool check()
        {
            //phần check chống
            #region
            if (string.IsNullOrEmpty(txtMaQuocGia.Text))
            {
                MessageBox.Show("Mã quốc gia không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cbxTenQuocGia.Text))
            {
                MessageBox.Show("Tên quốc gia không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion
            #region
            if (cbxTenQuocGia.Text.Length <= 3)
            {
                MessageBox.Show("Tên quốc gia phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbxTenQuocGia.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên quốc gia không được chứa số", "ERR");
                return false;
            }
            #endregion
            for (int i = 0; i < xuatXu.GetsList().Count; i++)
            {
                if (xuatXu.GetsList().ToList()[i].MaQuocGia == txtMaQuocGia.Text)
                {
                    MessageBox.Show("Mã quốc gia Đã tồn Tại yêu cầu nhập mã quốc gia khác", "ERR");
                    return false;
                }
            }
            return true;
        }
        public bool checkup()
        {
            //phần check chống
            #region
            if (string.IsNullOrEmpty(txtMaQuocGia.Text))
            {
                MessageBox.Show("Mã quốc gia không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cbxTenQuocGia.Text))
            {
                MessageBox.Show("Tên quốc gia không được bỏ trống", "Thông báo");
                return false;
            }

            #endregion
            #region
            if (cbxTenQuocGia.Text.Length <= 3)
            {
                MessageBox.Show("Tên quốc gia phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbxTenQuocGia.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên quốc gia không được chứa số", "ERR");
                return false;
            }
            #endregion
            //for (int i = 0; i < xuatXu.GetsList().Count; i++)
            //{
            //    if (xuatXu.GetsList().ToList()[i].MaQuocGia == txtMaQuocGia.Text)
            //    {
            //        MessageBox.Show("Mã quốc gia Đã tồn Tại yêu cầu nhập mã quốc gia khác", "ERR");
            //        return false;
            //    }
            //}
            return true;
        }
        void loadatafortimkiem(string ma)
        {
            dgv_XuatXu.ColumnCount = 4;
            dgv_XuatXu.Columns[0].Name = "ID Quoc Gia";
            dgv_XuatXu.Columns[0].Visible = false;
            dgv_XuatXu.Columns[1].Name = "Mã Quốc Gia";
            dgv_XuatXu.Columns[2].Name = "Tên Quốc Gia";
            dgv_XuatXu.Columns[3].Name = "Trạng thái";
            dgv_XuatXu.Rows.Clear();
            foreach (var x in ixuatxuser.getlstxuatxufromDB().Where(c => c.MaQuocGia.StartsWith(ma)))
            {
                dgv_XuatXu.Rows.Add(x.IdquocGia, x.MaQuocGia, x.TenQuocGia, x.TrangThai == 1 ? "Tồn tại" : "Không tồn tại");
            }
        }
        private void txt_Timkiem_Leave(object sender, EventArgs e)
        {
            if (txt_Timkiem.Text == "")
            {
                txt_Timkiem.Text = "Tìm kiếm theo mã quốc gia";
                txt_Timkiem.ForeColor = Color.Black;
                _xuatXuSer.getlstxuatxufromDB();
                loaddata();
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
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgv_XuatXu.ColumnCount = 4;
            dgv_XuatXu.Columns[0].Name = "ID Quoc Gia";
            dgv_XuatXu.Columns[0].Visible = false;
            dgv_XuatXu.Columns[1].Name = "Mã Quốc Gia";
            dgv_XuatXu.Columns[2].Name = "Tên Quốc Gia";
            dgv_XuatXu.Columns[3].Name = "Trạng thái";
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_XuatXu.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_XuatXu.Columns.Add(btn);



            dgv_XuatXu.Rows.Clear();
            foreach (var x in ixuatxuser.getlstxuatxufromDB().OrderByDescending(c => c.TenQuocGia))
            {
                dgv_XuatXu.Rows.Add(x.IdquocGia, x.MaQuocGia, x.TenQuocGia, x.TrangThai == 1 ? "Tồn tại" : "Không tồn tại");
            }
        }
        void loaddata2()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Thêm");
            row.Add("Sửa");
            row.Add("Xóa");

            dgv_XuatXu.ColumnCount = 4;
            dgv_XuatXu.Columns[0].Name = "ID Quoc Gia";
            dgv_XuatXu.Columns[0].Visible = false;
            dgv_XuatXu.Columns[1].Name = "Mã Quốc Gia";
            dgv_XuatXu.Columns[2].Name = "Tên Quốc Gia";
            dgv_XuatXu.Columns[3].Name = "Trạng thái";
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = "Chức Năng";
            cbo.Name = "cbo";
            cbo.Items.AddRange(row.ToArray());
            dgv_XuatXu.Columns.Add(cbo);


            ////button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Xác Nhận";
            btn.HeaderText = "Xác Nhận";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgv_XuatXu.Columns.Add(btn);



            dgv_XuatXu.Rows.Clear();
            foreach (var x in ixuatxuser.getlstxuatxufromDB().OrderBy(c => c.TenQuocGia))
            {
                dgv_XuatXu.Rows.Add(x.IdquocGia, x.MaQuocGia, x.TenQuocGia, x.TrangThai == 1 ? "Tồn tại" : "Không tồn tại");
            }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
