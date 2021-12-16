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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI_PresentaionLayers
{
    public partial class FormChatLieu : Form
    {
        private IQlyChatLieu _iQlyChatLieu;
        private ChatLieuServie _clser;
        private ChatLieu chatLieu;
        public FormChatLieu()
        {
            InitializeComponent();
            _iQlyChatLieu = new QLyChatLieuServices();
            _clser = new ChatLieuServie();
            chatLieu = new ChatLieu();
            LoadData();
            css();
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
            dgridChatLieu.ColumnCount = 4;
            dgridChatLieu.Columns[0].Name = "ID";
            dgridChatLieu.Columns[0].Visible = false;
            dgridChatLieu.Columns[1].Name = "Mã chất liệu";
            dgridChatLieu.Columns[2].Name = "Tên chất chất liệu";
            dgridChatLieu.Columns[3].Name = "Trạng thái";
            dgridChatLieu.Rows.Clear();
            foreach (var x in _iQlyChatLieu.GetsList())
            {
                dgridChatLieu.Rows.Add(x.IdchatLieu, x.MaChatLieu, x.TenChatLieu,
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
            buttonColumn.UseColumnTextForButtonValue = true;

            dgridChatLieu.Columns.Add(dcColumn);
            dgridChatLieu.Columns.Add(buttonColumn);
        }

        private void dgridChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (e.ColumnIndex == dgridChatLieu.Columns["Ok"].Index)
            {
                if (dgridChatLieu.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString() == "Thêm")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    ChatLieu ChatLieu1 = new ChatLieu()
                    {
                        IdchatLieu = _iQlyChatLieu.GetsList().Max(x => x.IdchatLieu) + 1,
                        MaChatLieu = "CL0001" + _iQlyChatLieu.GetsList().Max(x => x.IdchatLieu) + 1,
                        TenChatLieu = dgridChatLieu.Rows[rowIndex].Cells[2].Value.ToString(),
                        TrangThai = dgridChatLieu.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0
                    };
                    _iQlyChatLieu.addNV(ChatLieu1);
                    LoadData();

                    MessageBox.Show("Thêm thành công");
                    return;
                }

                if (Convert.ToString(dgridChatLieu.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Sửa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }


                    var nhomhuong = _iQlyChatLieu.GetsList().FirstOrDefault(x =>
                        x.IdchatLieu == Convert.ToInt32(dgridChatLieu.Rows[rowIndex].Cells[0].Value.ToString()));
                    nhomhuong.TenChatLieu = dgridChatLieu.Rows[rowIndex].Cells[2].Value.ToString();
                    nhomhuong.TrangThai = dgridChatLieu.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? 1 : 0;


                    _iQlyChatLieu.updateNV(nhomhuong);
                    LoadData();
                }

                if (Convert.ToString(dgridChatLieu.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value) == "Xóa")
                {
                    var x = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                    {
                        return;
                    }

                    var ChatLieu = _iQlyChatLieu.GetsList().FirstOrDefault(x =>
                        x.IdchatLieu == Convert.ToInt32(dgridChatLieu.Rows[rowIndex].Cells[0].Value.ToString()));
                    _iQlyChatLieu.removeNV(ChatLieu);
                    LoadData();
                    return;
                }

                LoadData();
            }
        }
        private void dgridChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //if ((rowIndex > _iQlyNhomHuong.GetsList().Count) || rowIndex < 0) return;
            txtMaCL.Text = Convert.ToString(dgridChatLieu.Rows[rowIndex].Cells[1].Value);
            txtTenChatLieu.Text = Convert.ToString(dgridChatLieu.Rows[rowIndex].Cells[2].Value);
            ckbON.Checked = dgridChatLieu.Rows[rowIndex].Cells[3].Value == "Sử dụng" ? true : false;
            chkOFF.Checked = dgridChatLieu.Rows[rowIndex].Cells[3].Value == "Không sử dụng" ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
