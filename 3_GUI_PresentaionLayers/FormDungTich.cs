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
    public partial class FormDungTich : Form
    {
        private QLyDungTich dungTich;
        private DungTich _dungTich;
        private DungTichServices _dungTichSer;
        public FormDungTich()
        {
            InitializeComponent();
        }


        void loadata()
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
            foreach (var x in dungTich.GetsList())
            {
                dgv_DungTich.Rows.Add(x.IddungTich, x.MaDungTich, x.SoDungTich, x.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
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

            int rd = e.RowIndex;
            dgv_DungTich.AllowUserToAddRows = false;


            //thêm
            if (e.ColumnIndex == 5 && string.IsNullOrEmpty(dgv_DungTich.Rows[rd].Cells["cbo"].Value.ToString()) == false)
            {

                string commnad = dgv_DungTich.Rows[e.RowIndex].Cells["cbo"].Value.ToString();

                if (commnad == "Thêm")
                {
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _dungTichSer.adddungtich(new DungTich()
                        {
                            IddungTich = _dungTichSer.getlstdungtichfromDB().Max(c => c.IddungTich) + 1,
                            MaDungTich = txtMaDungTich.Text,
                            SoDungTich = Convert.ToInt32(txtSoDungTich.Text),
                            TrangThai = Convert.ToInt32(chk_ConHang.Checked)

                        });
                        _dungTichSer.save(_dungTich);
                        MessageBox.Show("Thêm Thành Công", "Thông Báo");
                        _dungTichSer.getlstdungtichfromDB();
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
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        _dungTich.IddungTich = Convert.ToInt32(dgv_DungTich.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _dungTich.MaDungTich = txtMaDungTich.Text;
                        _dungTich.SoDungTich = Convert.ToInt32(txtSoDungTich.Text);
                        _dungTich.TrangThai = Convert.ToInt32(chk_ConHang.Checked);

                        dungTich.updateDT(_dungTich);
                        dungTich.Save(_dungTich);
                        MessageBox.Show("Sửa Thành Công", "Thông Báo");
                        _dungTichSer.getlstdungtichfromDB();
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
                    DialogResult dialogResult = MessageBox.Show("bạn có muốn chọn chức năng Sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _dungTichSer.deletedungtich(_dungTich);
                        _dungTichSer.save(_dungTich);
                        MessageBox.Show("Xóa Thành Công");
                        _dungTichSer.getlstdungtichfromDB();
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

        private void dgv_DungTich_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == dungTich.GetsList().Count || rowindex == -1) return;
            _dungTich = _dungTichSer.getlstdungtichfromDB().ToList().FirstOrDefault(c => c.IddungTich == Convert.ToInt32(dgv_DungTich.Rows[rowindex].Cells[0].Value.ToString()));
            txtMaDungTich.Text = dgv_DungTich.Rows[rowindex].Cells[1].Value.ToString();
            txtSoDungTich.Text = dgv_DungTich.Rows[rowindex].Cells[2].Value.ToString();
            chk_ConHang.Checked = dgv_DungTich.Rows[rowindex].Cells[3].Value.ToString() == "Còn hàng";
            chk_HetHang.Checked = dgv_DungTich.Rows[rowindex].Cells[3].Value.ToString() == "Hết hàng";
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
    }
}
