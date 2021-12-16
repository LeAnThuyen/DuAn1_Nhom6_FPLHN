
namespace _3_GUI_PresentaionLayers
{
    partial class FrmThongKeALL
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thốngKêDoanhThuNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelhome = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PeachPuff;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêDoanhThuNhânViênToolStripMenuItem,
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1394, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thốngKêDoanhThuNhânViênToolStripMenuItem
            // 
            this.thốngKêDoanhThuNhânViênToolStripMenuItem.Name = "thốngKêDoanhThuNhânViênToolStripMenuItem";
            this.thốngKêDoanhThuNhânViênToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.thốngKêDoanhThuNhânViênToolStripMenuItem.Text = "Thống Kê Doanh Thu Cửa Hàng";
            this.thốngKêDoanhThuNhânViênToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDoanhThuNhânViênToolStripMenuItem_Click);
            // 
            // thốngKêSảnPhẩmBánChạyToolStripMenuItem
            // 
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem.Name = "thốngKêSảnPhẩmBánChạyToolStripMenuItem";
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem.Text = "Thống Kê Sản Phẩm Bán Chạy";
            this.thốngKêSảnPhẩmBánChạyToolStripMenuItem.Click += new System.EventHandler(this.thốngKêSảnPhẩmBánChạyToolStripMenuItem_Click);
            // 
            // panelhome
            // 
            this.panelhome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelhome.Location = new System.Drawing.Point(0, 28);
            this.panelhome.Name = "panelhome";
            this.panelhome.Size = new System.Drawing.Size(1394, 801);
            this.panelhome.TabIndex = 1;
            // 
            // FrmThongKeALL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1394, 829);
            this.Controls.Add(this.panelhome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmThongKeALL";
            this.Text = "FrmThongKeALL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thốngKêDoanhThuNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêSảnPhẩmBánChạyToolStripMenuItem;
        private System.Windows.Forms.Panel panelhome;
    }
}