
namespace _3_GUI_PresentaitonLayer
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
            this.label10 = new System.Windows.Forms.Label();
            this.menuChatLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDungTich = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhomHuong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVatChua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXuatXu = new System.Windows.Forms.ToolStripMenuItem();
            this.manuAnh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgrid_sanpham = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).BeginInit();
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
            this.panel1.Controls.Add(this.dgrid_sanpham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 547);
            this.panel1.TabIndex = 82;
            // 
            // dgrid_sanpham
            // 
            this.dgrid_sanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_sanpham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_sanpham.Location = new System.Drawing.Point(0, 0);
            this.dgrid_sanpham.Name = "dgrid_sanpham";
            this.dgrid_sanpham.RowHeadersWidth = 51;
            this.dgrid_sanpham.RowTemplate.Height = 29;
            this.dgrid_sanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_sanpham.Size = new System.Drawing.Size(1219, 547);
            this.dgrid_sanpham.TabIndex = 0;
            this.dgrid_sanpham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_sanpham_CellDoubleClick);
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 763);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSanPham";
            this.Text = "FormSanPham";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_sanpham)).EndInit();
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
    }
}