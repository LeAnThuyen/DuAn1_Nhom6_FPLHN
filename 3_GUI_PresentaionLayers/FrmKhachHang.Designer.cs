
namespace _3_GUI_PresentaionLayers
{
    partial class FrmKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhachHang));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaKhachHang = new System.Windows.Forms.TextBox();
            this.txt_TenKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckd_Onl = new System.Windows.Forms.CheckBox();
            this.ckd_off = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Sdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_Khachhang = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_TimKiem = new System.Windows.Forms.TextBox();
            this.cbx_Loc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Khachhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(68, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khách Hàng";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(67, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Khách Hàng";
            this.label2.UseWaitCursor = true;
            // 
            // txt_MaKhachHang
            // 
            this.txt_MaKhachHang.Location = new System.Drawing.Point(166, 91);
            this.txt_MaKhachHang.Name = "txt_MaKhachHang";
            this.txt_MaKhachHang.Size = new System.Drawing.Size(141, 23);
            this.txt_MaKhachHang.TabIndex = 2;
            this.txt_MaKhachHang.UseWaitCursor = true;
            // 
            // txt_TenKhachHang
            // 
            this.txt_TenKhachHang.Location = new System.Drawing.Point(166, 124);
            this.txt_TenKhachHang.Name = "txt_TenKhachHang";
            this.txt_TenKhachHang.Size = new System.Drawing.Size(141, 23);
            this.txt_TenKhachHang.TabIndex = 3;
            this.txt_TenKhachHang.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(606, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng Thái";
            this.label3.UseWaitCursor = true;
            // 
            // ckd_Onl
            // 
            this.ckd_Onl.AutoSize = true;
            this.ckd_Onl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ckd_Onl.Location = new System.Drawing.Point(696, 152);
            this.ckd_Onl.Name = "ckd_Onl";
            this.ckd_Onl.Size = new System.Drawing.Size(84, 19);
            this.ckd_Onl.TabIndex = 5;
            this.ckd_Onl.Text = "Hoạt Động";
            this.ckd_Onl.UseVisualStyleBackColor = true;
            this.ckd_Onl.UseWaitCursor = true;
            this.ckd_Onl.CheckedChanged += new System.EventHandler(this.ckd_Onl_CheckedChanged);
            // 
            // ckd_off
            // 
            this.ckd_off.AutoSize = true;
            this.ckd_off.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ckd_off.Location = new System.Drawing.Point(802, 154);
            this.ckd_off.Name = "ckd_off";
            this.ckd_off.Size = new System.Drawing.Size(122, 19);
            this.ckd_off.TabIndex = 6;
            this.ckd_off.Text = "Không Hoạt Động";
            this.ckd_off.UseVisualStyleBackColor = true;
            this.ckd_off.UseWaitCursor = true;
            this.ckd_off.CheckedChanged += new System.EventHandler(this.ckd_off_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(68, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email";
            this.label4.UseWaitCursor = true;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(166, 157);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(141, 23);
            this.txt_Email.TabIndex = 9;
            this.txt_Email.UseWaitCursor = true;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(736, 91);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(163, 23);
            this.txt_DiaChi.TabIndex = 11;
            this.txt_DiaChi.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(606, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa Chỉ";
            this.label5.UseWaitCursor = true;
            // 
            // txt_Sdt
            // 
            this.txt_Sdt.Location = new System.Drawing.Point(736, 115);
            this.txt_Sdt.Name = "txt_Sdt";
            this.txt_Sdt.Size = new System.Drawing.Size(163, 23);
            this.txt_Sdt.TabIndex = 13;
            this.txt_Sdt.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(606, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số Điện Thoại";
            this.label6.UseWaitCursor = true;
            // 
            // dgv_Khachhang
            // 
            this.dgv_Khachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Khachhang.Location = new System.Drawing.Point(72, 223);
            this.dgv_Khachhang.Name = "dgv_Khachhang";
            this.dgv_Khachhang.RowHeadersWidth = 51;
            this.dgv_Khachhang.RowTemplate.Height = 25;
            this.dgv_Khachhang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Khachhang.Size = new System.Drawing.Size(848, 150);
            this.dgv_Khachhang.TabIndex = 14;
            this.dgv_Khachhang.UseWaitCursor = true;
            this.dgv_Khachhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Khachhang_CellClick);
            this.dgv_Khachhang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Khachhang_CellContentClick);
            this.dgv_Khachhang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Khachhang_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(632, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tìm Kiếm";
            this.label7.UseWaitCursor = true;
            // 
            // tbx_TimKiem
            // 
            this.tbx_TimKiem.Location = new System.Drawing.Point(695, 190);
            this.tbx_TimKiem.Name = "tbx_TimKiem";
            this.tbx_TimKiem.Size = new System.Drawing.Size(203, 23);
            this.tbx_TimKiem.TabIndex = 17;
            this.tbx_TimKiem.UseWaitCursor = true;
            this.tbx_TimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_TimKiem_KeyUp);
            this.tbx_TimKiem.Leave += new System.EventHandler(this.tbx_TimKiem_Leave);
            // 
            // cbx_Loc
            // 
            this.cbx_Loc.FormattingEnabled = true;
            this.cbx_Loc.Location = new System.Drawing.Point(463, 190);
            this.cbx_Loc.Name = "cbx_Loc";
            this.cbx_Loc.Size = new System.Drawing.Size(163, 23);
            this.cbx_Loc.TabIndex = 18;
            this.cbx_Loc.UseWaitCursor = true;
            this.cbx_Loc.SelectedValueChanged += new System.EventHandler(this.cbx_Loc_SelectedValueChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(431, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Lọc";
            this.label8.UseWaitCursor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(16, 13);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 22);
            this.label15.TabIndex = 101;
            this.label15.Text = "label15";
            this.label15.UseWaitCursor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(16, 50);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 22);
            this.label16.TabIndex = 102;
            this.label16.Text = "label16";
            this.label16.UseWaitCursor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(255, 14);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(959, 449);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbx_Loc);
            this.Controls.Add(this.tbx_TimKiem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_Khachhang);
            this.Controls.Add(this.txt_Sdt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckd_off);
            this.Controls.Add(this.ckd_Onl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_TenKhachHang);
            this.Controls.Add(this.txt_MaKhachHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmKhachHang";
            this.Text = "FrmKhachHang";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Khachhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaKhachHang;
        private System.Windows.Forms.TextBox txt_TenKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckd_Onl;
        private System.Windows.Forms.CheckBox ckd_off;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Sdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_Khachhang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_TimKiem;
        private System.Windows.Forms.ComboBox cbx_Loc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
    }
}