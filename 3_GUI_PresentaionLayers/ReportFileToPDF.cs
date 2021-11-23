using _2_BUS_BussinessLayer.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
using iTextSharp.text.html.simpleparser;
namespace _3_GUI_PresentaionLayers
{
    public partial class ReportFileToPDF : Form
    {
        private QlyHangHoaServices qlhhser;
        public ReportFileToPDF()
        {
            InitializeComponent();
            qlhhser = new QlyHangHoaServices();
            loaddata();
        }
        public void loaddata()
        {

            dgrid_sanpham.ColumnCount = 19;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[2].Name = "Mã Vạch";
            dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[4].Name = "Nhà Sản Xuất";
            dgrid_sanpham.Columns[5].Name = "Danh Mục";
            dgrid_sanpham.Columns[6].Name = "Trạng Thái";
            dgrid_sanpham.Columns[7].Name = "Số Lượng";
            dgrid_sanpham.Columns[8].Name = "Gía Nhập";
            dgrid_sanpham.Columns[9].Name = "Gía Bán";
            dgrid_sanpham.Columns[10].Name = "Ngày Nhập Kho";
            //   dgrid_sanpham.Columns[10].Visible = false;
            dgrid_sanpham.Columns[11].Name = "Tên Chất Liệu";
            // dgrid_sanpham.Columns[11].Visible = false;
            dgrid_sanpham.Columns[12].Name = "Tên Vật Chứa";
            //dgrid_sanpham.Columns[12].Visible = false;
            dgrid_sanpham.Columns[13].Name = "Nhóm Hương";
            // dgrid_sanpham.Columns[13].Visible = false;
            dgrid_sanpham.Columns[14].Name = "Tên Quốc Gia";
            //dgrid_sanpham.Columns[14].Visible = false;
            dgrid_sanpham.Columns[15].Name = "Số Dung Tích";
            //  dgrid_sanpham.Columns[15].Visible = false;
            dgrid_sanpham.Columns[16].Name = "Ảnh";// đường dẫn
            ///  dgrid_sanpham.Columns[16].Visible = false;
            dgrid_sanpham.Columns[17].Name = "Hạn Sử Dụng";// đường dẫn
                                                           //  dgrid_sanpham.Columns[17].Visible = false;
            dgrid_sanpham.Columns[18].Name = "Model";// đường dẫn
                                                     //  dgrid_sanpham.Columns[18].Visible = false;

            foreach (var x in qlhhser.GetsList().Where(c => c.HangHoa.TrangThai == 1))
            {
                dgrid_sanpham.Rows.Add(x.HangHoa.IdhangHoa, x.HangHoa.MaHangHoa, x.ChiTietHangHoa.Mavach, x.HangHoa.TenHangHoa, x.NhaSanXuat.TenNhaSanXuat, x.DanhMuc.TenDanhMuc, x.HangHoa.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.ChiTietHangHoa.SoLuong,
                    x.ChiTietHangHoa.DonGiaNhap, x.ChiTietHangHoa.DonGiaBan, x.ChiTietHangHoa.NgayNhapKho, x.ChatLieu.TenChatLieu, x.VatChua.TenVatChua, x.NhomHuong.TenNhomHuong, x.XuatXu.TenQuocGia, x.DungTich.SoDungTich, x.Anh.DuongDan, x.ChiTietHangHoa.HanSuDung, x.ChiTietHangHoa.Model);
            }

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
        public void exportdata(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf,10,iTextSharp.text.Font.NORMAL);
            //Add header;
            foreach(DataGridViewColumn col in dgrid_sanpham.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(col.HeaderText));
                pdfPTable.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dgrid_sanpham.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(Convert.ToString(cell.Value), text));
                }

                  

            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream= new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfPTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }


        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn Xuất Ra File PDF Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    exportdata(dgrid_sanpham, "test");
                    for (int i = 0; i < 2; i++)
                    {

                        this.Alert("Xuất Ra File PDF Thành Công");

                    }
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        this.Alert("Xuất Ra File PDF Thất Bại");

                    }
                    return;
                }
             
            }
            catch (Exception ex)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Lỗi Rồi"+ex.Message);

                }
                
                return;
            }
        }
    }
}
