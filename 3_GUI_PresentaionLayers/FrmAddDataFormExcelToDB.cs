
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
using _1_DAL_DataAccessLayer.IDALServices;
using _1_DAL_DataAccessLayer.DALServices;

namespace _3_GUI_PresentaionLayers
{
    public partial class FrmAddDataFormExcelToDB : Form
    {

        private QlyHangHoaServices qlyHangHoaServices;
        private IChatLieuServices _iclser;
        private ChatLieu cl;
        private Anh img;
        private DanhMuc dm;
        private NhaSanXuat nsx;
        private NhomHuong nhuog;
        private VatChua vt;
        private XuatXu xx;
        private HangHoa hh;
        private DungTich dtich;
        private IServicesAnh _ianhser;
        private IServicesDanhMuc _idmser;
        private IServicesNhaSanXuat _insxser;
        private IServicesNhomHuong _inhser;
        private IServicesVatChua _ivtser;
        private IServicesXuatXu _ixxser;
        private IDungTichServices _idtser;
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
            _iclser = new ChatLieuServie();
            _ianhser = new AnhServices();
            _idmser = new DanhMucServices();
            _insxser = new NhaSanXuatServices();
            _inhser = new NhomHuongServices();
            _ivtser = new VatChuaServices();
            _ixxser = new XuatXuService();
            _idtser = new DungTichServices();
            hh = new HangHoa();
            cl = new ChatLieu();
            nhuog = new NhomHuong();
            dtich = new DungTich();
         //
         img = new Anh();
         dm= new DanhMuc();
        nsx= new NhaSanXuat();
      
            vt = new VatChua(); 
         xx= new XuatXu();

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
            if (txt_filename.Text == "")
            {
                MessageBox.Show("Bạn Chưa Chọn File Excel", "Thông Báo");
                return;
            }
           
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Import File Excel Lên Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + txt_filename.Text + "';Extended Properties=Excel 12.0 Xml;");
                conn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select * from[Sheet1$]", conn);
                DataSet theSD = new DataSet();
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (dt.Columns.Count != 22)
                {
                    MessageBox.Show("Bạn Đã Chọn Sai File Để Thêm Số Lượng Lớn Sản Phẩm Số Cột Không Đáp Ứng Đúng Format", "Thông Báo");
                    txt_filename.Text = "";
                    return;
                }
                this.dataGridView1.DataSource = dt.DefaultView;
              
                for ( int i =0; i<dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        //chất liệu chính
                        bool indexo = _iclser.getlstchatlieufromDB().Any(c => c.IdchatLieu == Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value));
                        if (indexo == false)
                        {
                            cl.IdchatLieu = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                            _iclser.addchatlieu(cl);
                            _iclser.save(cl);
                        }
                        //Nhà Sản Xuất
                        bool indexo1 = _insxser.getlstnxsfromDB().Any(c => c.IdnhaSanXuat == Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value));
                        if (indexo1 == false)
                        {
                            nsx.IdnhaSanXuat = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                            _insxser.addnhasanxuat(nsx);
                            _insxser.save(nsx);
                        }
                        //Danh Mục
                        bool indexo2 = _idmser.getlstdanhmucfromDB().Any(c => c.IddanhMuc == Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value));
                        if (indexo2 == false)
                        {
                            dm.IddanhMuc = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                            _idmser.adddanhmuc(dm);
                            _idmser.save(dm);
                        }
                        //Nhóm Hương
                        bool indexo3 = _inhser.getlstnhomhuongfromDB().Any(c => c.IdnhomHuong == Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value));
                        if (indexo3 == false)
                        {
                            nhuog.IdnhomHuong = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);

                            _inhser.addnhomhuong(nhuog);

                            _inhser.save(nhuog);
                        }
                        //Xuất Xứ
                        bool indexo4 = _ixxser.getlstxuatxufromDB().Any(c => c.IdquocGia == Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value));
                        if (indexo4 == false)
                        {
                            xx.IdquocGia = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);
                            _ixxser.addxuatxu(xx);
                            _ixxser.save(xx);
                        }
                        //Dung Tích
                        bool indexo5 = _idtser.getlstdungtichfromDB().Any(c => c.IddungTich == Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value));
                        if (indexo5 == false)
                        {
                            dtich.IddungTich = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);
                            _idtser.adddungtich(dtich);
                            _idtser.save(dtich);
                        }
                        //Ảnh
                        bool indexo6 = _ianhser.getlstanhfromDB().Any(c => c.Idanh == Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value));
                        if (indexo6 == false)
                        {
                            img.Idanh = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                            img.DuongDan = "C:\\Users\\Asus\\OneDrive\\Máy tính\\Bò Bía\\IMG_IG.png";
                            _ianhser.addanh(img);
                            _ianhser.save(img);
                        }
                        //Vật Chứa
                        bool indexo7 = _ivtser.getlstvatchuafromDB().Any(c => c.IdvatChua == Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value));
                        if (indexo7 == false)
                        {
                            vt.IdvatChua = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                            _ivtser.addvatchua(vt);
                            _ivtser.save(vt);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Convert.ToString(ex.Message), "Thông Báo");
                        return;

                    }
           
                }
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

          
        }
        void preadd()
        {
          
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txt_filename.Text == "")
            {
                MessageBox.Show("Bạn Chưa Chọn File Excel", "Thông Báo");
                return;
            }
           
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Các Sản Phẩm Ở File Excel Vào Database Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {

                        id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        tenhh = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        mahh = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                        idnsx = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);//done
                        trangthai = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        iddanhmuc = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);//done
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
                        idtenchatlieu = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);//done
                        idnhomhuong = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);//done
                        idhh = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);//
                        idtennquocgia = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);//
                        idsodungtich = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);//
                        idanh = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);//
                        idtenvatchua = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);//


                        var sp = new HangHoa()
                        {
                            IdhangHoa = id,
                            TenHangHoa = tenhh,
                            MaHangHoa = mahh,
                            IdnhaSanXuat = idnsx,
                            TrangThai = trangthai,
                            IddanhMuc = iddanhmuc
                        };
                        qlyHangHoaServices.AddSP(sp);



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
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(Convert.ToString(ex.Message), "Thông Báo");
                        return;
                    }
                 
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
              
              
                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Chào Mừng Bạn Đến Với Form Sản Phẩm");

                }
                FormSanPham.loaddatasender();
                this.Hide();



            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
    }

