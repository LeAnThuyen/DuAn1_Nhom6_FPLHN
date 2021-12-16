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
    public partial class FrmAnh : Form
    {
        private IServicesAnh ianhser;
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
                    dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.DuongDan, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }
        public bool checkup()
        {
            if (string.IsNullOrEmpty(txt_MaAnh.Text))
            {
                MessageBox.Show("Mã Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenAnh.Text))
            {
                MessageBox.Show("Tên Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_ddan.Text))
            {
                MessageBox.Show("Đường dẫn Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            //Mã 
            if (txt_MaAnh.Text.Length <= 3)
            {
                MessageBox.Show("Mã Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Ảnh Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //tên
            if (txt_TenAnh.Text.Length <= 3)
            {
                MessageBox.Show("Tên Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (txt_ddan.Text.Length <= 3)
            {
                MessageBox.Show("Đường dẫn Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (cbx_CoAnh.Checked == false && cbx_Kcoanh.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txt_TenAnh.Text))
            {
                MessageBox.Show("Tên Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_MaAnh.Text))
            {
                MessageBox.Show("Mã Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_ddan.Text))
            {
                MessageBox.Show("Đường dẫn Ảnh không được bỏ trống", "Thông báo");
                return false;
            }
            //mã 

            if (Regex.IsMatch(txt_MaAnh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Ảnh Bắt buộc phải chứa số", "ERR");
                return false;

            }
            if (Regex.IsMatch(txt_MaAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Mã Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            for (int i = 0; i < _anhSer.getlstanhfromDB().Count; i++)
            {
                if (_anhSer.getlstanhfromDB().ToList()[i].MaAnh == txt_MaAnh.Text)
                {
                    MessageBox.Show("Mã Ảnh Đã tồn Tại yêu cầu nhập mã Ảnh khác", "ERR");
                    return false;
                }
            }
            //tên
            if (txt_TenAnh.Text.Length <= 3)
            {
                MessageBox.Show("Tên Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }

            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa số", "ERR");
                return false;
            }

            if (txt_DuongDan.Text.Length <= 3)
            {
                MessageBox.Show("Đường dẫn Ảnh phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenAnh.Text, @"^[a-zA-Z0-9\s.\?\,\'\;\:\!\-]+$") == false)
            {

                MessageBox.Show("Tên Ảnh không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            //Trạng thái
            if (cbx_CoAnh.Checked == false && cbx_Kcoanh.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái", "ERR");
                return false;
            }
            return true;
        }
        private void dgv_anh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                            if (Check() == false)
                            {
                                return;
                            }
                            _anhSer.addanh(new Anh()
                            {
                                Idanh = _anhSer.getlstanhfromDB().Max(c => c.Idanh) + 1,
                                MaAnh = txt_MaAnh.Text,
                                TenAnh = txt_TenAnh.Text,
                                DuongDan = txt_ddan.Text,

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
                            if (checkup() == false)
                            {
                                return;
                            }
                            _anh.Idanh = Convert.ToInt32(dgv_anh.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _anh.MaAnh = txt_MaAnh.Text;
                            _anh.TenAnh = txt_TenAnh.Text;
                            _anh.DuongDan = txt_ddan.Text;
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
                        DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Xóa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _anh.Idanh = Convert.ToInt32(dgv_anh.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _anh.MaAnh = txt_MaAnh.Text;
                            _anh.TenAnh = txt_TenAnh.Text;
                            _anh.DuongDan = txt_ddan.Text;
                            _anh.TrangThai = 0;
                            _anhSer.updateanh(_anh);
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
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }

        private void dgv_anh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == anh.GetsList().Count || rowindex == -1) return;
                _anh = _anhSer.getlstanhfromDB().ToList().FirstOrDefault(c => c.Idanh == Convert.ToInt32(dgv_anh.Rows[rowindex].Cells[0].Value.ToString()));
                txt_MaAnh.Text =Convert.ToString( dgv_anh.Rows[rowindex].Cells[1].Value);
                txt_TenAnh.Text =Convert.ToString( dgv_anh.Rows[rowindex].Cells[2].Value);
                txt_ddan.Text = Convert.ToString(dgv_anh.Rows[rowindex].Cells[3].Value);
                cbx_CoAnh.Checked =Convert.ToString( dgv_anh.Rows[rowindex].Cells[4].Value) == "Hoạt động";
                cbx_Kcoanh.Checked =Convert.ToString( dgv_anh.Rows[rowindex].Cells[4].Value) == "Không hoạt động";
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }

        private void cbx_CoAnh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_CoAnh.Checked)
                {
                    cbx_Kcoanh.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }

        private void cbx_Kcoanh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_Kcoanh.Checked)
                {
                    cbx_CoAnh.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }

        }

        private void dgv_anh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Idanh = Convert.ToInt32(dgv_anh.Rows[e.RowIndex].Cells[0].Value);
                string Maanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[1].Value);
                string Tenanh = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[2].Value);
                string DuongDan = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[3].Value);
                string trangthai = Convert.ToString(dgv_anh.Rows[e.RowIndex].Cells[4].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
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

                dgv_anh.ColumnCount = 5;
                dgv_anh.Columns[0].Name = "ID ảnh";
                dgv_anh.Columns[0].Visible = false;
                dgv_anh.Columns[1].Name = "Mã ảnh";
                dgv_anh.Columns[2].Name = "Tên ảnh";
                dgv_anh.Columns[3].Name = "Đường dẫn";
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
                foreach (var x in _anhSer.getlstanhfromDB().Where(c => c.MaAnh.StartsWith(ma)))
                {

                    dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.DuongDan, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                    this.Text = open.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
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
            foreach (var x in _anhSer.getlstanhfromDB().OrderByDescending(c => c.TenAnh))
            {
                dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
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
                foreach (var x in _anhSer.getlstanhfromDB().OrderBy(c => c.TenAnh))
                {
                    dgv_anh.Rows.Add(x.Idanh, x.MaAnh, x.TenAnh, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Hiếu để khắc phục");
            }
        }

        private void cbx_loc_SelectedValueChanged(object sender, EventArgs e)
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
