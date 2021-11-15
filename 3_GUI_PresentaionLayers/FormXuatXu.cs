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
    public partial class FormXuatXu : Form
    {
        private QlyXuatXu xuatXu;
        private XuatXu _xuatXu;
        private XuatXuService _xuatXuSer;
        public FormXuatXu()
        {
            InitializeComponent();
            xuatXu = new QlyXuatXu();
            _xuatXu = new XuatXu();
            _xuatXuSer = new XuatXuService();
            _xuatXuSer.getlstxuatxufromDB();
            dgv_XuatXu.AllowUserToAddRows = false;
            loaddata();
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
            foreach (var x in xuatXu.GetsList())
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
            if (rowindex == xuatXu.GetsList().Count || rowindex == -1) return;
            _xuatXu = _xuatXuSer.getlstxuatxufromDB().ToList().FirstOrDefault(c => c.IdquocGia == Convert.ToInt32(dgv_XuatXu.Rows[rowindex].Cells[0].Value.ToString()));
            txtMaQuocGia.Text = dgv_XuatXu.Rows[rowindex].Cells[1].Value.ToString();
            cbxTenQuocGia.Text = dgv_XuatXu.Rows[rowindex].Cells[2].Value.ToString();
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
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _xuatXuSer.addxuatxu(new XuatXu()
                        {
                            IdquocGia = _xuatXuSer.getlstxuatxufromDB().Max(c => c.IdquocGia) + 1,
                            MaQuocGia = txtMaQuocGia.Text,
                            TenQuocGia = cbxTenQuocGia.Text


                        });
                        _xuatXuSer.save(_xuatXu);
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                        _xuatXuSer.getlstxuatxufromDB();
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
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _xuatXu.IdquocGia = Convert.ToInt32(dgv_XuatXu.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _xuatXu.MaQuocGia = txtMaQuocGia.Text;
                        _xuatXu.TenQuocGia = cbxTenQuocGia.Text;


                        xuatXu.updateXX(_xuatXu);
                        xuatXu.Save(_xuatXu);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
                        _xuatXuSer.getlstxuatxufromDB();
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
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _xuatXuSer.deletexuatxu(_xuatXu);
                        _xuatXuSer.save(_xuatXu);
                        MessageBox.Show("Xóa Thành Công");
                        _xuatXuSer.getlstxuatxufromDB();
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
    }
}
