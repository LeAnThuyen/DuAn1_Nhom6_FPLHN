using _2_BUS_BussinessLayer.IServices;
using _2_BUS_BussinessLayer.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace _3_GUI_PresentaionLayers
{
    public partial class FrmHideSendEmail : Form
    {
        private IServicesTinhTrangHoaDon _istatus;
        Attachment attach = null;
        private string em;
        public FrmHideSendEmail()
        {
            InitializeComponent();
            _istatus = new ServiceTinhTrangHoaDon();
            loaddatafordathanhtoan();
            hide_ok.Visible = false;
            loaddata();
             senderexcel();
            // SaveDataGridViewToCSV(@"C:\DoanhThuPerSoftDaily.txt");
           


        }
        public void exportdata(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header;
            foreach (DataGridViewColumn col in dgrid_tinhtrang.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(col.HeaderText));
                pdfPTable.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dgrid_tinhtrang.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(Convert.ToString(cell.Value), text));
                }



            }
            
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";

            savefiledialog.InitialDirectory = @"C:\test";
           
           
               
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfPTable);
                    pdfdoc.Close();
                    stream.Close();
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
        void loaddatafordathanhtoan()
        {
            hide_ok.ColumnCount = 10;
            hide_ok.Columns[0].Name = "Mã Hóa Đơn";
            hide_ok.Columns[1].Name = "Mã Nhân Viên";
            hide_ok.Columns[2].Name = "Mã Khách Hàng";
            hide_ok.Columns[3].Name = "Tên Khách Hàng";
            hide_ok.Columns[4].Name = "Số Điện Thoại";
            hide_ok.Columns[5].Name = "Email";
            hide_ok.Columns[6].Name = "Tổng Tiền";
            hide_ok.Columns[7].Name = "Trạng Thái";
            hide_ok.Columns[8].Name = "Ghi Chú";
            hide_ok.Columns[9].Name = "Ngày Lập";
            hide_ok.Rows.Clear();
            foreach (var x in _istatus.GetlistViewStatushd().Where(c => c.TrangThai != 0 && c.TrangThai != 1 && c.TrangThai != 2 && c.TrangThai != 3))
            {
                hide_ok.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);

                int numRows = hide_ok.Rows.Count;

                labl_cancel.Text = Convert.ToString(numRows - 1);
            }
            if (hide_ok.RowCount == 1)
            {
                labl_cancel.Text = Convert.ToString("0");
                labl_cancel.Text = Convert.ToString("0");
            }
        }

        void loaddata()
        {
            dgrid_tinhtrang.ColumnCount = 10;
            dgrid_tinhtrang.Columns[0].Name = "Mã Hóa Đơn";
            dgrid_tinhtrang.Columns[1].Name = "Mã Nhân Viên";
            dgrid_tinhtrang.Columns[2].Name = "Mã Khách Hàng";
            dgrid_tinhtrang.Columns[3].Name = "Tên Khách Hàng";
            dgrid_tinhtrang.Columns[4].Name = "Số Điện Thoại";
            dgrid_tinhtrang.Columns[5].Name = "Email";
            dgrid_tinhtrang.Columns[6].Name = "Tổng Tiền";
            dgrid_tinhtrang.Columns[7].Name = "Trạng Thái";
            dgrid_tinhtrang.Columns[8].Name = "Ghi Chú";
            dgrid_tinhtrang.Columns[9].Name = "Ngày Lập";
            //add cột
           
            dgrid_tinhtrang.Rows.Clear();
            
           
            foreach (var x in _istatus.GetlistViewStatushd())
            {
                dgrid_tinhtrang.Rows.Add(x.MaHoaDon, x.MaNhanVien, x.MaKhachHang, x.TenKhachHang, x.SoDienThoai,
                    x.Email, x.TongTien, x.TrangThai == 1 ? "Đã Thanh Toán" : (x.TrangThai == 0 ? "Đã Cọc" : (x.TrangThai == 2 ? "Chưa Thanh Toán" : (x.TrangThai == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"))), x.GhiChu, x.NgayLap);
                int sum = 0;
                for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
                }
                lbl_tongtien.Text = sum.ToString();
                //
                int numRows = dgrid_tinhtrang.Rows.Count;

                lbl_counthd.Text = Convert.ToString(numRows - 1);
            }
            if (dgrid_tinhtrang.RowCount == 1)
            {
                lbl_tongtien.Text = Convert.ToString("0");
                lbl_counthd.Text = Convert.ToString("0");
                return;
            }


            DataGridViewTextBoxColumn tongtien = new DataGridViewTextBoxColumn();
            tongtien.HeaderText = "Tổng Doanh Thu";
            tongtien.Name = "txt_total";
         
        
            dgrid_tinhtrang.Columns.Add(tongtien);

            //
            DataGridViewTextBoxColumn totalbill = new DataGridViewTextBoxColumn();
            totalbill.HeaderText = "Tổng Số Hóa Đơn";
            totalbill.Name = "txt_totalbill";
            dgrid_tinhtrang.Columns.Add(totalbill);
            //
            DataGridViewTextBoxColumn cancelbill = new DataGridViewTextBoxColumn();
            cancelbill.HeaderText = "Số Đơn Hủy";
            cancelbill.Name = "txt_cancelbill";
            dgrid_tinhtrang.Columns.Add(cancelbill);
            //
           
            //
            int sum1 = 0;
            for (int i = 0; i < dgrid_tinhtrang.Rows.Count; ++i)
            {
                sum1 += Convert.ToInt32(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value);
            }
            for (int i = 0; i < 1; ++i)
            {
            dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value=Convert.ToString( sum1);
            }
            for (int i = 0; i < 1; ++i)
            {
                dgrid_tinhtrang.Rows[i].Cells["txt_totalbill"].Value = Convert.ToString(
                    lbl_counthd.Text);
            }
            for (int i = 0; i < 1; ++i)
            {
                dgrid_tinhtrang.Rows[i].Cells["txt_cancelbill"].Value = Convert.ToString(labl_cancel.Text);
            }
           


        }

        //xử lý quá mệt

        void senderexcel()
        {
            System.Data.OleDb.OleDbConnection MyConnection;//"C:\Thuyên.xlsx"//"C:\persoftdaily.xlsx"//
            System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();//,,, ,  , ,, , , ,,
            string sql = null;
            MyConnection = new System.Data.OleDb.OleDbConnection((@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\persoftdaily.xlsx';Extended Properties=Excel 12.0 Xml;"));
            MyConnection.Open();
            myCommand.Connection = MyConnection;
            //for(int i =0; i< dgrid_tinhtrang.RowCount; ++i)//([Mã Hóa Đơn],[Mã Nhân Viên],[Mã Khách Hàng],[Tên Khách Hàng],[Số Điện Thoại],[Email],[Tổng Tiền],[Trạng Thái],[GhiChú],[Ngày Lập],[Tổng Doanh Thu],[Số Đơn Hủy]) 
            //{

            //    sql = "INSERT INTO [sheet1$] values('" + dgrid_tinhtrang.Rows[i].Cells["Mã Hóa Đơn"].Value + "','"+dgrid_tinhtrang.Rows[i].Cells["Mã Nhân Viên"].Value + "'  ,'"+ dgrid_tinhtrang.Rows[i].Cells["Mã Khách Hàng"].Value + "'    ,'" + dgrid_tinhtrang.Rows[i].Cells["Tên Khách Hàng"].Value + "','" + dgrid_tinhtrang.Rows[i].Cells["Số Điện Thoại"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Email"].Value + "' ,  '" + dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Ghi Chú"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["Trạng Thái"].Value + "' ,'" +dgrid_tinhtrang.Rows[i].Cells["Ngày Lập"].Value + "' ,'" + dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value + "' ,'" +dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value + "' )";
            //    myCommand.CommandText = sql;
            //}

            sql = "INSERT INTO [sheet1$] values(@mahd,@manv,@makh,@tenkh,@sdt,@eamil,@tongtien,@status,@note,@ngaylap,@tongdoanhthu,@totalbill,@sodonhuy)";
            for (int i = 0; i < dgrid_tinhtrang.Rows.Count; i++)
            {
                myCommand.Parameters.AddWithValue("@mahd", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Mã Hóa Đơn"].Value));
                //myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@manv", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Mã Nhân Viên"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@makh", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Mã Khách Hàng"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tenkh", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Tên Khách Hàng"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@sdt", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Số Điện Thoại"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@eamil", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Email"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tongtien", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Tổng Tiền"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@status", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Trạng Thái"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@note", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Ghi Chú"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@ngaylap", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["Ngày Lập"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@tongdoanhthu", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["txt_total"].Value));
                // myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@totalbill", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["txt_totalbill"].Value));
                //  myCommand.CommandText = sql;
                myCommand.Parameters.AddWithValue("@sodonhuy", Convert.ToString(dgrid_tinhtrang.Rows[i].Cells["txt_cancelbill"].Value));
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                myCommand.Parameters.Clear();



            } 


             

            

            MyConnection.Close();





        }



        private void lbl_tongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
             
           




        }
        //tiến hành
        #region



        #endregion
        //gửi mail


        public void abcd()
        {

            TextWriter textWriter = new StreamWriter(@"C:\DoanhThuPerSoftDaily.txt");

            for (int x = 0; x < dgrid_tinhtrang.Columns.Count; x++)
            {
                textWriter.Write(dgrid_tinhtrang.Columns[x].HeaderText);
                if (x != dgrid_tinhtrang.Columns.Count - 1)
                {
                    textWriter.Write("\t " + " ");
                }

            }
            textWriter.WriteLine();


            //writing the data
            for (int x = 0; x < dgrid_tinhtrang.Rows.Count - 1; x++)
            {
                for (int y = 0; y < dgrid_tinhtrang.Columns.Count; y++)
                {
                    textWriter.Write(dgrid_tinhtrang.Rows[x].Cells[y].Value);
                    if (y != dgrid_tinhtrang.Columns.Count - 1)
                    {
                        textWriter.Write("\t " + "|");
                    }
                }
                textWriter.WriteLine();
            }
            textWriter.Close();


        }
        void SaveDataGridViewToCSV(string Filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dgrid_tinhtrang.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            // Select all the cells
            dgrid_tinhtrang.SelectAll();
            // Copy (set clipboard)
            Clipboard.SetDataObject(dgrid_tinhtrang.GetClipboardContent());
            // Paste (get the clipboard and serialize it to a file)
            File.WriteAllText(Filename, Clipboard.GetText(TextDataFormat.UnicodeText));
        }
      
        private async Task ExportUserData()
        {
          //  string file_name = AppDomain.CurrentDomain.BaseDirectory + "/export.txt";

            TextWriter writer = new StreamWriter(@"C:\DoanhThuPerSoftDaily.txt");

            for (int i = 0; i < dgrid_tinhtrang.Rows.Count; i++)
            {
                for (int j = 0; j < dgrid_tinhtrang.Columns.Count; j++)
                {
                    await writer.WriteAsync("\t" + dgrid_tinhtrang.Columns[j].HeaderText + Convert.ToString( dgrid_tinhtrang.Rows[i].Cells[j].Value) + "\t" + "|");
                }

                await writer.WriteLineAsync("");
            }

            writer.Close();
            MessageBox.Show("Data exported!", "Insta Tool Info", MessageBoxButtons.OK);
        }
      
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            


        }
    }
}
