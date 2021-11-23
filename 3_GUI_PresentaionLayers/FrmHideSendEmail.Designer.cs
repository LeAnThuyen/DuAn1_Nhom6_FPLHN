
namespace _3_GUI_PresentaionLayers
{
    partial class FrmHideSendEmail
    { /// <summary>
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_tinhtrang = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_tongtien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_counthd = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.hide_ok = new System.Windows.Forms.DataGridView();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_dataemail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labl_cancel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_tinhtrang)).BeginInit();
            this.rightpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_ok)).BeginInit();
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
            this.dgrid_tinhtrang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(503, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng Doanh Thu :";
            // 
            // lbl_tongtien
            // 
            this.lbl_tongtien.AutoSize = true;
            this.lbl_tongtien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_tongtien.Location = new System.Drawing.Point(638, 372);
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
            this.label5.Location = new System.Drawing.Point(717, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng Số Hóa Đơn :";
            // 
            // lbl_counthd
            // 
            this.lbl_counthd.AutoSize = true;
            this.lbl_counthd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_counthd.Location = new System.Drawing.Point(869, 372);
            this.lbl_counthd.Name = "lbl_counthd";
            this.lbl_counthd.Size = new System.Drawing.Size(50, 20);
            this.lbl_counthd.TabIndex = 12;
            this.lbl_counthd.Text = "label6";
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
            // rightpanel
            // 
            this.rightpanel.Controls.Add(this.hide_ok);
            this.rightpanel.Controls.Add(this.btn_open);
            this.rightpanel.Controls.Add(this.pictureBox4);
            this.rightpanel.Controls.Add(this.txt_dataemail);
            this.rightpanel.Location = new System.Drawing.Point(3, 395);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(1348, 381);
            this.rightpanel.TabIndex = 14;
            // 
            // hide_ok
            // 
            this.hide_ok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hide_ok.Location = new System.Drawing.Point(764, 71);
            this.hide_ok.Name = "hide_ok";
            this.hide_ok.RowHeadersWidth = 51;
            this.hide_ok.RowTemplate.Height = 29;
            this.hide_ok.Size = new System.Drawing.Size(300, 188);
            this.hide_ok.TabIndex = 17;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.RosyBrown;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(962, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Số Đơn Bị Hủy :";
            // 
            // labl_cancel
            // 
            this.labl_cancel.AutoSize = true;
            this.labl_cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labl_cancel.Location = new System.Drawing.Point(1080, 372);
            this.labl_cancel.Name = "labl_cancel";
            this.labl_cancel.Size = new System.Drawing.Size(50, 20);
            this.labl_cancel.TabIndex = 15;
            this.labl_cancel.Text = "label1";
            // 
            // FrmHideSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1354, 779);
            this.Controls.Add(this.labl_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.lbl_counthd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_tongtien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHideSendEmail";
            this.Text = "FrmTinhTrangHoaDon";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_tinhtrang)).EndInit();
            this.rightpanel.ResumeLayout(false);
            this.rightpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrid_tinhtrang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_tongtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_counthd;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.TextBox txt_dataemail;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView hide_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labl_cancel;
    }
}