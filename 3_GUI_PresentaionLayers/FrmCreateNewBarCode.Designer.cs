
namespace _3_GUI_PresentaionLayers
{
    partial class FrmCreateNewBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateNewBarCode));
            this.Pic_QRcode = new System.Windows.Forms.PictureBox();
            this.txt_QRcode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_printer = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_QRcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_printer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pic_QRcode
            // 
            this.Pic_QRcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_QRcode.Location = new System.Drawing.Point(160, 30);
            this.Pic_QRcode.Name = "Pic_QRcode";
            this.Pic_QRcode.Size = new System.Drawing.Size(277, 160);
            this.Pic_QRcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_QRcode.TabIndex = 0;
            this.Pic_QRcode.TabStop = false;
            // 
            // txt_QRcode
            // 
            this.txt_QRcode.Location = new System.Drawing.Point(160, 215);
            this.txt_QRcode.Name = "txt_QRcode";
            this.txt_QRcode.Size = new System.Drawing.Size(277, 27);
            this.txt_QRcode.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(160, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(359, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(81, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "QRCode :";
            // 
            // pic_printer
            // 
            this.pic_printer.BackColor = System.Drawing.Color.IndianRed;
            this.pic_printer.Image = ((System.Drawing.Image)(resources.GetObject("pic_printer.Image")));
            this.pic_printer.Location = new System.Drawing.Point(533, 0);
            this.pic_printer.Name = "pic_printer";
            this.pic_printer.Size = new System.Drawing.Size(78, 40);
            this.pic_printer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_printer.TabIndex = 15;
            this.pic_printer.TabStop = false;
            this.pic_printer.Click += new System.EventHandler(this.pic_printer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pic_printer);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.LightCoral;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 76);
            this.panel1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tạo Mới Mã QRCode :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(274, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Xác Nhận :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(469, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "In PDF :";
            // 
            // FrmCreateNewBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(611, 369);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_QRcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pic_QRcode);
            this.Name = "FrmCreateNewBarCode";
            this.Text = "FrmCreateNewBarCode";
            ((System.ComponentModel.ISupportInitialize)(this.Pic_QRcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_printer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic_QRcode;
        private System.Windows.Forms.TextBox txt_QRcode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_printer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}