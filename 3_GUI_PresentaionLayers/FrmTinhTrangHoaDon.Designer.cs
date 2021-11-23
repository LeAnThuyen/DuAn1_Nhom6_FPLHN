
namespace _3_GUI_PresentaionLayers
{
    partial class FrmTinhTrangHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTinhTrangHoaDon));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_tinhtrang = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nam = new System.Windows.Forms.ComboBox();
            this.cbo_loc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_ngay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_tongtien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_counthd = new System.Windows.Forms.Label();
            this.pn_sendemail = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_fileattach = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_emailname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_sub = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtx_content = new System.Windows.Forms.RichTextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.cbo_loadloc = new System.Windows.Forms.ComboBox();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_dataemail = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_tinhtrang)).BeginInit();
            this.pn_sendemail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rightpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrid_tinhtrang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1354, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgrid_tinhtrang
            // 
            this.dgrid_tinhtrang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_tinhtrang.BackgroundColor = System.Drawing.Color.Linen;
            this.dgrid_tinhtrang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_tinhtrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_tinhtrang.Location = new System.Drawing.Point(3, 23);
            this.dgrid_tinhtrang.Name = "dgrid_tinhtrang";
            this.dgrid_tinhtrang.RowHeadersWidth = 51;
            this.dgrid_tinhtrang.RowTemplate.Height = 29;
            this.dgrid_tinhtrang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_tinhtrang.Size = new System.Drawing.Size(1348, 326);
            this.dgrid_tinhtrang.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(597, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Theo Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(306, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Theo Tháng :";
            // 
            // cbo_nam
            // 
            this.cbo_nam.FormattingEnabled = true;
            this.cbo_nam.Location = new System.Drawing.Point(684, 358);
            this.cbo_nam.Name = "cbo_nam";
            this.cbo_nam.Size = new System.Drawing.Size(151, 28);
            this.cbo_nam.TabIndex = 3;
            this.cbo_nam.SelectedValueChanged += new System.EventHandler(this.cbo_nam_SelectedValueChanged);
            // 
            // cbo_loc
            // 
            this.cbo_loc.FormattingEnabled = true;
            this.cbo_loc.Location = new System.Drawing.Point(406, 358);
            this.cbo_loc.Name = "cbo_loc";
            this.cbo_loc.Size = new System.Drawing.Size(151, 28);
            this.cbo_loc.TabIndex = 4;
            this.cbo_loc.SelectedValueChanged += new System.EventHandler(this.cbo_loc_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(5, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Theo Ngày:";
            // 
            // cbo_ngay
            // 
            this.cbo_ngay.FormattingEnabled = true;
            this.cbo_ngay.Location = new System.Drawing.Point(105, 361);
            this.cbo_ngay.Name = "cbo_ngay";
            this.cbo_ngay.Size = new System.Drawing.Size(151, 28);
            this.cbo_ngay.TabIndex = 7;
            this.cbo_ngay.SelectedValueChanged += new System.EventHandler(this.cbo_ngay_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(889, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng Doanh Thu :";
            // 
            // lbl_tongtien
            // 
            this.lbl_tongtien.AutoSize = true;
            this.lbl_tongtien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_tongtien.Location = new System.Drawing.Point(1024, 364);
            this.lbl_tongtien.Name = "lbl_tongtien";
            this.lbl_tongtien.Size = new System.Drawing.Size(50, 20);
            this.lbl_tongtien.TabIndex = 10;
            this.lbl_tongtien.Text = "label5";
            this.lbl_tongtien.TextChanged += new System.EventHandler(this.lbl_tongtien_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(1103, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng Số Hóa Đơn :";
            // 
            // lbl_counthd
            // 
            this.lbl_counthd.AutoSize = true;
            this.lbl_counthd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_counthd.Location = new System.Drawing.Point(1255, 364);
            this.lbl_counthd.Name = "lbl_counthd";
            this.lbl_counthd.Size = new System.Drawing.Size(50, 20);
            this.lbl_counthd.TabIndex = 12;
            this.lbl_counthd.Text = "label6";
            // 
            // pn_sendemail
            // 
            this.pn_sendemail.BackColor = System.Drawing.Color.RosyBrown;
            this.pn_sendemail.Controls.Add(this.pictureBox3);
            this.pn_sendemail.Controls.Add(this.pictureBox2);
            this.pn_sendemail.Controls.Add(this.pictureBox1);
            this.pn_sendemail.Controls.Add(this.txt_fileattach);
            this.pn_sendemail.Controls.Add(this.label9);
            this.pn_sendemail.Controls.Add(this.txt_emailname);
            this.pn_sendemail.Controls.Add(this.label8);
            this.pn_sendemail.Controls.Add(this.txt_sub);
            this.pn_sendemail.Controls.Add(this.label7);
            this.pn_sendemail.Controls.Add(this.label6);
            this.pn_sendemail.Controls.Add(this.rtx_content);
            this.pn_sendemail.Location = new System.Drawing.Point(0, 395);
            this.pn_sendemail.Name = "pn_sendemail";
            this.pn_sendemail.Size = new System.Drawing.Size(1038, 384);
            this.pn_sendemail.TabIndex = 13;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(958, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(958, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(844, 330);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txt_fileattach
            // 
            this.txt_fileattach.Location = new System.Drawing.Point(95, 13);
            this.txt_fileattach.Name = "txt_fileattach";
            this.txt_fileattach.Size = new System.Drawing.Size(833, 27);
            this.txt_fileattach.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "File Attach :";
            // 
            // txt_emailname
            // 
            this.txt_emailname.Location = new System.Drawing.Point(95, 62);
            this.txt_emailname.Name = "txt_emailname";
            this.txt_emailname.Size = new System.Drawing.Size(833, 27);
            this.txt_emailname.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "To :";
            // 
            // txt_sub
            // 
            this.txt_sub.Location = new System.Drawing.Point(95, 110);
            this.txt_sub.Name = "txt_sub";
            this.txt_sub.Size = new System.Drawing.Size(833, 27);
            this.txt_sub.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Subject :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(5, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Content :";
            // 
            // rtx_content
            // 
            this.rtx_content.Location = new System.Drawing.Point(3, 191);
            this.rtx_content.Name = "rtx_content";
            this.rtx_content.Size = new System.Drawing.Size(925, 125);
            this.rtx_content.TabIndex = 0;
            this.rtx_content.Text = "";
            // 
            // btn_open
            // 
            this.btn_open.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_open.FlatAppearance.BorderSize = 0;
            this.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_open.ForeColor = System.Drawing.Color.Maroon;
            this.btn_open.Location = new System.Drawing.Point(127, 191);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(171, 51);
            this.btn_open.TabIndex = 14;
            this.btn_open.Text = "Gửi Mail Thông Báo";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_loadloc
            // 
            this.cbo_loadloc.FormattingEnabled = true;
            this.cbo_loadloc.Location = new System.Drawing.Point(6, 61);
            this.cbo_loadloc.Name = "cbo_loadloc";
            this.cbo_loadloc.Size = new System.Drawing.Size(301, 28);
            this.cbo_loadloc.TabIndex = 16;
            this.cbo_loadloc.SelectedValueChanged += new System.EventHandler(this.cbo_loadloc_SelectedValueChanged);
            // 
            // rightpanel
            // 
            this.rightpanel.Controls.Add(this.cbo_loadloc);
            this.rightpanel.Controls.Add(this.pictureBox5);
            this.rightpanel.Controls.Add(this.btn_open);
            this.rightpanel.Controls.Add(this.pictureBox4);
            this.rightpanel.Controls.Add(this.txt_dataemail);
            this.rightpanel.Location = new System.Drawing.Point(1044, 395);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(307, 381);
            this.rightpanel.TabIndex = 14;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(117, 18);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(68, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.RosyBrown;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(37, 191);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(84, 51);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // txt_dataemail
            // 
            this.txt_dataemail.Location = new System.Drawing.Point(6, 95);
            this.txt_dataemail.Name = "txt_dataemail";
            this.txt_dataemail.Size = new System.Drawing.Size(301, 27);
            this.txt_dataemail.TabIndex = 15;
            // 
            // FrmTinhTrangHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1354, 779);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.pn_sendemail);
            this.Controls.Add(this.lbl_counthd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_tongtien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_ngay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_nam);
            this.Controls.Add(this.cbo_loc);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTinhTrangHoaDon";
            this.Text = "FrmTinhTrangHoaDon";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_tinhtrang)).EndInit();
            this.pn_sendemail.ResumeLayout(false);
            this.pn_sendemail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rightpanel.ResumeLayout(false);
            this.rightpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrid_tinhtrang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nam;
        private System.Windows.Forms.ComboBox cbo_loc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_ngay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_tongtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_counthd;
        private System.Windows.Forms.Panel pn_sendemail;
        private System.Windows.Forms.RichTextBox rtx_content;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_fileattach;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_emailname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_sub;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.ComboBox cbo_loadloc;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.TextBox txt_dataemail;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}