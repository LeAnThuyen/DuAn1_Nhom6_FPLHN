
namespace _3_GUI_PresentaionLayers
{
    partial class FrmThongKeKhachHangUuTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKeKhachHangUuTu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grb_hide = new System.Windows.Forms.GroupBox();
            this.dgrid_ss = new System.Windows.Forms.DataGridView();
            this.dgrid_khut = new System.Windows.Forms.DataGridView();
            this.grb_defaut = new System.Windows.Forms.GroupBox();
            this.grb_ctsp = new System.Windows.Forms.GroupBox();
            this.dgrid_cthh = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_reload = new System.Windows.Forms.Button();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.btn_lockhoangtg = new System.Windows.Forms.Button();
            this.lbl_end = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_ss = new System.Windows.Forms.Label();
            this.lab_closedetail = new System.Windows.Forms.Label();
            this.txt_lbllockhoang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_loc = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grb_hide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_khut)).BeginInit();
            this.grb_defaut.SuspendLayout();
            this.grb_ctsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_cthh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Sienna;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 138);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(863, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(291, 124);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(550, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(291, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(239, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // grb_hide
            // 
            this.grb_hide.Controls.Add(this.dgrid_ss);
            this.grb_hide.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_hide.ForeColor = System.Drawing.Color.LightCoral;
            this.grb_hide.Location = new System.Drawing.Point(0, 138);
            this.grb_hide.Name = "grb_hide";
            this.grb_hide.Size = new System.Drawing.Size(1394, 198);
            this.grb_hide.TabIndex = 13;
            this.grb_hide.TabStop = false;
            this.grb_hide.Text = "So Sánh Với Tháng Trước";
            // 
            // dgrid_ss
            // 
            this.dgrid_ss.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_ss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ss.Location = new System.Drawing.Point(3, 23);
            this.dgrid_ss.Name = "dgrid_ss";
            this.dgrid_ss.RowHeadersWidth = 51;
            this.dgrid_ss.RowTemplate.Height = 29;
            this.dgrid_ss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_ss.Size = new System.Drawing.Size(1388, 172);
            this.dgrid_ss.TabIndex = 0;
            // 
            // dgrid_khut
            // 
            this.dgrid_khut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_khut.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrid_khut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_khut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_khut.Location = new System.Drawing.Point(3, 23);
            this.dgrid_khut.Name = "dgrid_khut";
            this.dgrid_khut.RowHeadersWidth = 51;
            this.dgrid_khut.RowTemplate.Height = 29;
            this.dgrid_khut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_khut.Size = new System.Drawing.Size(1388, 266);
            this.dgrid_khut.TabIndex = 0;
            // 
            // grb_defaut
            // 
            this.grb_defaut.Controls.Add(this.grb_ctsp);
            this.grb_defaut.Controls.Add(this.dgrid_khut);
            this.grb_defaut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grb_defaut.ForeColor = System.Drawing.Color.IndianRed;
            this.grb_defaut.Location = new System.Drawing.Point(0, 537);
            this.grb_defaut.Name = "grb_defaut";
            this.grb_defaut.Size = new System.Drawing.Size(1394, 292);
            this.grb_defaut.TabIndex = 0;
            this.grb_defaut.TabStop = false;
            this.grb_defaut.Text = "Thống Kê Khách Hàng Ưu Tú";
            // 
            // grb_ctsp
            // 
            this.grb_ctsp.Controls.Add(this.dgrid_cthh);
            this.grb_ctsp.ForeColor = System.Drawing.Color.LightCoral;
            this.grb_ctsp.Location = new System.Drawing.Point(0, 1);
            this.grb_ctsp.Name = "grb_ctsp";
            this.grb_ctsp.Size = new System.Drawing.Size(1391, 285);
            this.grb_ctsp.TabIndex = 1;
            this.grb_ctsp.TabStop = false;
            this.grb_ctsp.Text = "Thống Kê Chi Tiết Khách Hàng Ưu Tú";
            // 
            // dgrid_cthh
            // 
            this.dgrid_cthh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_cthh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_cthh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_cthh.Location = new System.Drawing.Point(3, 23);
            this.dgrid_cthh.Name = "dgrid_cthh";
            this.dgrid_cthh.RowHeadersWidth = 51;
            this.dgrid_cthh.RowTemplate.Height = 29;
            this.dgrid_cthh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_cthh.Size = new System.Drawing.Size(1385, 259);
            this.dgrid_cthh.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(207, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 50);
            this.button1.TabIndex = 40;
            this.button1.Text = "So Sánh Với Tháng Trước";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_reload
            // 
            this.btn_reload.ForeColor = System.Drawing.Color.Maroon;
            this.btn_reload.Location = new System.Drawing.Point(207, 431);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(205, 50);
            this.btn_reload.TabIndex = 41;
            this.btn_reload.Text = "ReLoad";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // dtp_end
            // 
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_end.Location = new System.Drawing.Point(622, 439);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(205, 27);
            this.dtp_end.TabIndex = 38;
            this.dtp_end.ValueChanged += new System.EventHandler(this.dtp_end_ValueChanged);
            // 
            // dtp_start
            // 
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_start.Location = new System.Drawing.Point(622, 386);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(205, 27);
            this.dtp_start.TabIndex = 39;
            this.dtp_start.ValueChanged += new System.EventHandler(this.dtp_start_ValueChanged);
            // 
            // btn_lockhoangtg
            // 
            this.btn_lockhoangtg.ForeColor = System.Drawing.Color.Maroon;
            this.btn_lockhoangtg.Location = new System.Drawing.Point(207, 375);
            this.btn_lockhoangtg.Name = "btn_lockhoangtg";
            this.btn_lockhoangtg.Size = new System.Drawing.Size(205, 50);
            this.btn_lockhoangtg.TabIndex = 30;
            this.btn_lockhoangtg.Text = "Lọc Theo Khoảng Thời Gian Và Xem Chi Tiết";
            this.btn_lockhoangtg.UseVisualStyleBackColor = true;
            this.btn_lockhoangtg.Click += new System.EventHandler(this.btn_lockhoangtg_Click);
            // 
            // lbl_end
            // 
            this.lbl_end.AutoSize = true;
            this.lbl_end.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_end.Location = new System.Drawing.Point(425, 444);
            this.lbl_end.Name = "lbl_end";
            this.lbl_end.Size = new System.Drawing.Size(140, 20);
            this.lbl_end.TabIndex = 32;
            this.lbl_end.Text = "Thời Gian Kết Thúc :";
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_start.Location = new System.Drawing.Point(424, 393);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(136, 20);
            this.lbl_start.TabIndex = 33;
            this.lbl_start.Text = "Thời Gian Bắt Đầu :";
            // 
            // lbl_ss
            // 
            this.lbl_ss.AutoSize = true;
            this.lbl_ss.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_ss.Location = new System.Drawing.Point(4, 500);
            this.lbl_ss.Name = "lbl_ss";
            this.lbl_ss.Size = new System.Drawing.Size(177, 20);
            this.lbl_ss.TabIndex = 34;
            this.lbl_ss.Text = "So Sánh Với Tháng Trước:";
            // 
            // lab_closedetail
            // 
            this.lab_closedetail.AutoSize = true;
            this.lab_closedetail.ForeColor = System.Drawing.Color.LightCoral;
            this.lab_closedetail.Location = new System.Drawing.Point(7, 446);
            this.lab_closedetail.Name = "lab_closedetail";
            this.lab_closedetail.Size = new System.Drawing.Size(141, 20);
            this.lab_closedetail.TabIndex = 35;
            this.lab_closedetail.Text = "Đóng Xem Chi Tiết :";
            // 
            // txt_lbllockhoang
            // 
            this.txt_lbllockhoang.AutoSize = true;
            this.txt_lbllockhoang.ForeColor = System.Drawing.Color.LightCoral;
            this.txt_lbllockhoang.Location = new System.Drawing.Point(10, 393);
            this.txt_lbllockhoang.Name = "txt_lbllockhoang";
            this.txt_lbllockhoang.Size = new System.Drawing.Size(198, 20);
            this.txt_lbllockhoang.TabIndex = 36;
            this.txt_lbllockhoang.Text = "Lọc Theo Khoảng Thời Gian :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(10, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Lọc Theo Mốc Thời Gian:";
            // 
            // dtp_loc
            // 
            this.dtp_loc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_loc.Location = new System.Drawing.Point(207, 342);
            this.dtp_loc.Name = "dtp_loc";
            this.dtp_loc.Size = new System.Drawing.Size(205, 27);
            this.dtp_loc.TabIndex = 31;
            this.dtp_loc.ValueChanged += new System.EventHandler(this.dtp_loc_ValueChanged);
            // 
            // FrmThongKeKhachHangUuTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1394, 829);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_start);
            this.Controls.Add(this.btn_lockhoangtg);
            this.Controls.Add(this.lbl_end);
            this.Controls.Add(this.lbl_start);
            this.Controls.Add(this.lbl_ss);
            this.Controls.Add(this.lab_closedetail);
            this.Controls.Add(this.txt_lbllockhoang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_loc);
            this.Controls.Add(this.grb_hide);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grb_defaut);
            this.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.Name = "FrmThongKeKhachHangUuTu";
            this.Text = "Form Thống Kê Khách Hàng Ưu Tú";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grb_hide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_khut)).EndInit();
            this.grb_defaut.ResumeLayout(false);
            this.grb_ctsp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_cthh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grb_hide;
        private System.Windows.Forms.DataGridView dgrid_ss;
        private System.Windows.Forms.DataGridView dgrid_khut;
        private System.Windows.Forms.GroupBox grb_defaut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Button btn_lockhoangtg;
        private System.Windows.Forms.Label lbl_end;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_ss;
        private System.Windows.Forms.Label lab_closedetail;
        private System.Windows.Forms.Label txt_lbllockhoang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_loc;
        private System.Windows.Forms.GroupBox grb_ctsp;
        private System.Windows.Forms.DataGridView dgrid_cthh;
    }
}