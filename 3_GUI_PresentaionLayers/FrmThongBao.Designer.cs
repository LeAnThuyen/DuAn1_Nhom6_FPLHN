
namespace _3_GUI_PresentaionLayers
{
    partial class FrmThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongBao));
            this.pic_send = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_newfeed = new System.Windows.Forms.DataGridView();
            this.panel_content = new System.Windows.Forms.Panel();
            this.rtx_content = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_send)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_newfeed)).BeginInit();
            this.panel_content.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_send
            // 
            this.pic_send.Image = ((System.Drawing.Image)(resources.GetObject("pic_send.Image")));
            this.pic_send.Location = new System.Drawing.Point(964, 139);
            this.pic_send.Name = "pic_send";
            this.pic_send.Size = new System.Drawing.Size(83, 51);
            this.pic_send.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_send.TabIndex = 3;
            this.pic_send.TabStop = false;
            this.pic_send.Click += new System.EventHandler(this.pic_send_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1080, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 65);
            this.panel2.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrid_newfeed);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 293);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgrid_newfeed
            // 
            this.dgrid_newfeed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_newfeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_newfeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_newfeed.Location = new System.Drawing.Point(3, 23);
            this.dgrid_newfeed.Name = "dgrid_newfeed";
            this.dgrid_newfeed.RowHeadersWidth = 51;
            this.dgrid_newfeed.RowTemplate.Height = 29;
            this.dgrid_newfeed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_newfeed.Size = new System.Drawing.Size(1172, 267);
            this.dgrid_newfeed.TabIndex = 0;
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.rtx_content);
            this.panel_content.Controls.Add(this.pic_send);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_content.Location = new System.Drawing.Point(0, 401);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1178, 202);
            this.panel_content.TabIndex = 8;
            // 
            // rtx_content
            // 
            this.rtx_content.Location = new System.Drawing.Point(3, 3);
            this.rtx_content.Name = "rtx_content";
            this.rtx_content.Size = new System.Drawing.Size(927, 196);
            this.rtx_content.TabIndex = 0;
            this.rtx_content.Text = "";
            // 
            // FrmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmThongBao";
            this.Text = "FormThongBao";
            ((System.ComponentModel.ISupportInitialize)(this.pic_send)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_newfeed)).EndInit();
            this.panel_content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_send;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrid_newfeed;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.RichTextBox rtx_content;
    }
}