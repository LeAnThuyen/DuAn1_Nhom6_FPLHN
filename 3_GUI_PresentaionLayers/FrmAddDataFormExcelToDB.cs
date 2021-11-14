
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using _2_BUS_BussinessLayer.Services;
using _1_DAL_DataAccessLayer.Models;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmAddDataFormExcelToDB : Form
    {

        private QlyHangHoaServices qlyHangHoaServices;
        private string mahh = "";
        private int id;
        private int idcthh;
        private string tenhh = "";
        private int idnsx;
        private int iddanhmuc;
        private int trangthai;
        private string mavach = "";
        private string soluong = "";
        private double gianhap;
        private double giaban;
        private DateTime? ngaynhap;
        private int idtenchatlieu;
        private int idtenvatchua;
        private int idnhomhuong;
        private int idhh;
        private int idtennquocgia;
        private int idsodungtich;
        private int idanh;
        private DateTime? hsd;
        private string model = "";
        public FrmAddDataFormExcelToDB()
        {
            InitializeComponent();
            qlyHangHoaServices = new QlyHangHoaServices();

        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.FileName = txt_filename.Text;
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_filename.Text = openFileDialog.FileName;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Import File Excel Lên Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + txt_filename.Text + "';Extended Properties=Excel 12.0 Xml;");
                conn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select * from[Sheet1$]", conn);
                DataSet theSD = new DataSet();
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                this.dataGridView1.DataSource = dt.DefaultView;
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Import Thành Công Rực Rỡ");
                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.AlertErr("Import Thất Bại");
                }
                return;
            }

            //dataGridView1.Columns[0].Visible = false;//idhh
            //dataGridView1.Columns[6].Visible = false;//idcthh
            //dataGridView1.Columns[3].Visible = false;//idcthh
            //dataGridView1.Columns[4].Visible = false;//idcthh
            //dataGridView1.Columns[14].Visible = false;//idcthh
            //dataGridView1.Columns[15].Visible = false;//idcthh
            //dataGridView1.Columns[16].Visible = false;//idcthh
            //dataGridView1.Columns[17].Visible = false;//idcthh
            //dataGridView1.Columns[18].Visible = false;//idcthh
            //dataGridView1.Columns[19].Visible = false;//idcthh
            //dataGridView1.Columns[20].Visible = false;//idcthh
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Các Sản Phẩm Ở File Excel Vào Database Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //hh
                    id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    tenhh = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    mahh = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    idnsx = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    trangthai = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    iddanhmuc = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    //cthh
                    idcthh = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                    soluong = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                    mavach = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
                    gianhap = Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                    giaban = Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    hsd = Convert.ToDateTime(dataGridView1.Rows[i].Cells[11].Value);
                    model = Convert.ToString(dataGridView1.Rows[i].Cells[12].Value);
                    ngaynhap = Convert.ToDateTime(dataGridView1.Rows[i].Cells[13].Value);
                    trangthai = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                    idtenchatlieu = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                    idnhomhuong = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                    idhh = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                    idtennquocgia = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);
                    idsodungtich = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);
                    idanh = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                    idtenvatchua = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);


                    var sp = new HangHoa()
                    {
                        IdhangHoa = id,
                        TenHangHoa = tenhh,
                        MaHangHoa = mahh,
                        IdnhaSanXuat = idnsx,
                        TrangThai = trangthai,
                        IddanhMuc=iddanhmuc
                    };
                    qlyHangHoaServices.AddSP(sp);
                 //   qlyHangHoaServices.SaveHangHoa(sp);


                    var info = new ChiTietHangHoa()
                    {

                        IdthongTinHangHoa = idcthh,
                        SoLuong = soluong,
                        Mavach = mavach,
                        DonGiaNhap = gianhap,
                        DonGiaBan = giaban,
                        HanSuDung = hsd,
                        Model = model,
                        NgayNhapKho = ngaynhap,
                        TrangThai = trangthai,
                        IdchatLieu = idtenchatlieu,
                        IdnhomHuong = idnhomhuong,
                        IdhangHoa = idhh,
                        IdquocGia = idtennquocgia,
                        IddungTich = idsodungtich,
                        Idanh = idanh,
                        IdvatChua = idtenvatchua,
                    };
                    qlyHangHoaServices.AddSpChiTiet(info);
                  //  qlyHangHoaServices.SaveChiTietHangHoa(info);
                };

                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Thêm Thành Công");
                }
                return;



            };
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.AlertErr("Thêm Thất Bại");
                    }
                    return;
                }
            }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FormSanPham formSanPham = new FormSanPham();

                formSanPham.loaddata();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Chào Mừng Bạn Đến Với PerSoft Perfume <3");

                }
                return;
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
    }

