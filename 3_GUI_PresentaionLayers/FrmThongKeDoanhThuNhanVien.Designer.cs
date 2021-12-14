
namespace _3_GUI_PresentaionLayers
{
    partial class FrmThongKeDoanhThuNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKeDoanhThuNhanVien));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_doanhthu = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nam = new System.Windows.Forms.ComboBox();
            this.cbo_loc = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_ngay = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_doanhthu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrid_doanhthu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1394, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Doanh Thu Nhân Viên";
            // 
            // dgrid_doanhthu
            // 
            this.dgrid_doanhthu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_doanhthu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrid_doanhthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_doanhthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_doanhthu.Location = new System.Drawing.Point(3, 23);
            this.dgrid_doanhthu.Name = "dgrid_doanhthu";
            this.dgrid_doanhthu.RowHeadersWidth = 51;
            this.dgrid_doanhthu.RowTemplate.Height = 29;
            this.dgrid_doanhthu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_doanhthu.Size = new System.Drawing.Size(1388, 266);
            this.dgrid_doanhthu.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(1144, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Theo Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(806, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Theo Tháng :";
            // 
            // cbo_nam
            // 
            this.cbo_nam.FormattingEnabled = true;
            this.cbo_nam.Location = new System.Drawing.Point(1231, 503);
            this.cbo_nam.Name = "cbo_nam";
            this.cbo_nam.Size = new System.Drawing.Size(151, 28);
            this.cbo_nam.TabIndex = 3;
            this.cbo_nam.SelectedValueChanged += new System.EventHandler(this.cbo_nam_SelectedValueChanged);
            // 
            // cbo_loc
            // 
            this.cbo_loc.FormattingEnabled = true;
            this.cbo_loc.Location = new System.Drawing.Point(918, 500);
            this.cbo_loc.Name = "cbo_loc";
            this.cbo_loc.Size = new System.Drawing.Size(151, 28);
            this.cbo_loc.TabIndex = 4;
            this.cbo_loc.SelectedIndexChanged += new System.EventHandler(this.cbo_loc_SelectedIndexChanged);
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
            this.panel1.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(848, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(291, 124);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(535, 11);
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
            this.pictureBox1.Location = new System.Drawing.Point(224, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(495, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Theo Ngày:";
            // 
            // cbo_ngay
            // 
            this.cbo_ngay.FormattingEnabled = true;
            this.cbo_ngay.Location = new System.Drawing.Point(596, 500);
            this.cbo_ngay.Name = "cbo_ngay";
            this.cbo_ngay.Size = new System.Drawing.Size(151, 28);
            this.cbo_ngay.TabIndex = 9;
            this.cbo_ngay.SelectedValueChanged += new System.EventHandler(this.cbo_ngay_SelectedValueChanged);
            // 
            // FrmThongKeDoanhThuNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1394, 829);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_ngay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_nam);
            this.Controls.Add(this.cbo_loc);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.Name = "FrmThongKeDoanhThuNhanVien";
            this.Text = "FrmThongKeDoanhThuNhanVien";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_doanhthu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrid_doanhthu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nam;
        private System.Windows.Forms.ComboBox cbo_loc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_ngay;
    }
}