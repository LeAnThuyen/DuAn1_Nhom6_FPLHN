
namespace _3_GUI_PresentaionLayers
{
    partial class FormSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSanPham));
            this.label10 = new System.Windows.Forms.Label();
            this.menuChatLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDungTich = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhomHuong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVatChua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXuatXu = new System.Windows.Forms.ToolStripMenuItem();
            this.manuAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pic_search = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrid_sanpham = new System.Windows.Forms.DataGridView();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbDark = new _3_GUI_PresentaionLayers.RJControls.RJToggleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbo_loc = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(99, 294);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 81;
            // 
            // menuChatLieu
            // 
            this.menuChatLieu.Name = "menuChatLieu";
            this.menuChatLieu.Size = new System.Drawing.Size(84, 24);
            this.menuChatLieu.Text = "Chất Liệu";
            this.menuChatLieu.Click += new System.EventHandler(this.menuChatLieu_Click_1);
            // 
            // menuDungTich
            // 
            this.menuDungTich.Name = "menuDungTich";
            this.menuDungTich.Size = new System.Drawing.Size(90, 24);
            this.menuDungTich.Text = "Dung Tích";
            this.menuDungTich.Click += new System.EventHandler(this.menuDungTich_Click_1);
            // 
            // menuNhomHuong
            // 
            this.menuNhomHuong.Name = "menuNhomHuong";
            this.menuNhomHuong.Size = new System.Drawing.Size(114, 24);
            this.menuNhomHuong.Text = "Nhóm Hương";
            this.menuNhomHuong.Click += new System.EventHandler(this.menuNhomHuong_Click_1);
            // 
            // menuVatChua
            // 
            this.menuVatChua.Name = "menuVatChua";
            this.menuVatChua.Size = new System.Drawing.Size(83, 24);
            this.menuVatChua.Text = "Vật Chứa";
            this.menuVatChua.Click += new System.EventHandler(this.menuVatChua_Click_1);
            // 
            // menuXuatXu
            // 
            this.menuXuatXu.Name = "menuXuatXu";
            this.menuXuatXu.Size = new System.Drawing.Size(75, 24);
            this.menuXuatXu.Text = "Xuất Xứ";
            this.menuXuatXu.Click += new System.EventHandler(this.menuXuatXu_Click_1);
            // 
            // manuAnh
            // 
            this.manuAnh.Name = "manuAnh";
            this.manuAnh.Size = new System.Drawing.Size(49, 24);
            this.manuAnh.Text = "Ảnh";
            this.manuAnh.Click += new System.EventHandler(this.manuAnh_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChatLieu,
            this.menuDungTich,
            this.menuNhomHuong,
            this.menuVatChua,
            this.menuXuatXu,
            this.manuAnh});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1219, 28);
            this.menuStrip1.TabIndex = 62;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgrid_sanpham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 539);
            this.panel1.TabIndex = 82;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.cbo_loc);
            this.panel2.Controls.Add(this.pic_search);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 64);
            this.panel2.TabIndex = 1;
            // 
            // pic_search
            // 
            this.pic_search.Image = ((System.Drawing.Image)(resources.GetObject("pic_search.Image")));
            this.pic_search.Location = new System.Drawing.Point(225, 16);
            this.pic_search.Name = "pic_search";
            this.pic_search.Size = new System.Drawing.Size(58, 36);
            this.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_search.TabIndex = 2;
            this.pic_search.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Tìm Kiếm Theo Mã Sản Phẩm";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label1.Location = new System.Drawing.Point(965, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nháy Đúp 1 Dòng Để Xem Chi Tiết";
            // 
            // dgrid_sanpham
            // 
            this.dgrid_sanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_sanpham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrid_sanpham.Location = new System.Drawing.Point(0, 64);
            this.dgrid_sanpham.Name = "dgrid_sanpham";
            this.dgrid_sanpham.RowHeadersWidth = 51;
            this.dgrid_sanpham.RowTemplate.Height = 29;
            this.dgrid_sanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_sanpham.Size = new System.Drawing.Size(1219, 475);
            this.dgrid_sanpham.TabIndex = 0;
            this.dgrid_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_sanpham_CellClick);
            this.dgrid_sanpham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_sanpham_CellContentClick);
            this.dgrid_sanpham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_sanpham_CellDoubleClick);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.Transparent;
            this.lblTime.Location = new System.Drawing.Point(896, 38);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(323, 46);
            this.lblTime.TabIndex = 91;
            // 
            // tbDark
            // 
            this.tbDark.AutoSize = true;
            this.tbDark.Location = new System.Drawing.Point(0, 31);
            this.tbDark.MinimumSize = new System.Drawing.Size(45, 22);
            this.tbDark.Name = "tbDark";
            this.tbDark.OffBackColor = System.Drawing.Color.Gray;
            this.tbDark.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tbDark.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tbDark.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tbDark.Size = new System.Drawing.Size(45, 22);
            this.tbDark.TabIndex = 90;
            this.tbDark.UseVisualStyleBackColor = true;
            this.tbDark.CheckedChanged += new System.EventHandler(this.tbDark_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbo_loc
            // 
            this.cbo_loc.FormattingEnabled = true;
            this.cbo_loc.Location = new System.Drawing.Point(329, 24);
            this.cbo_loc.Name = "cbo_loc";
            this.cbo_loc.Size = new System.Drawing.Size(151, 28);
            this.cbo_loc.TabIndex = 3;
            this.cbo_loc.SelectedIndexChanged += new System.EventHandler(this.txt_loc_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(495, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1219, 763);
            this.Controls.Add(this.tbDark);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSanPham";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem menuChatLieu;
        private System.Windows.Forms.ToolStripMenuItem menuDungTich;
        private System.Windows.Forms.ToolStripMenuItem menuNhomHuong;
        private System.Windows.Forms.ToolStripMenuItem menuVatChua;
        private System.Windows.Forms.ToolStripMenuItem menuXuatXu;
        private System.Windows.Forms.ToolStripMenuItem manuAnh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrid_sanpham;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private RJControls.RJToggleButton tbDark;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic_search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbo_loc;
    }
}