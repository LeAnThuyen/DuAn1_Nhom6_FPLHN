
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
            this.rtx_contentsend = new System.Windows.Forms.RichTextBox();
            this.cbo_tennv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_send = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtx_noticafitions = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_send)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // rtx_contentsend
            // 
            this.rtx_contentsend.BackColor = System.Drawing.Color.RosyBrown;
            this.rtx_contentsend.Location = new System.Drawing.Point(91, 388);
            this.rtx_contentsend.Name = "rtx_contentsend";
            this.rtx_contentsend.Size = new System.Drawing.Size(640, 135);
            this.rtx_contentsend.TabIndex = 0;
            this.rtx_contentsend.Text = "";
            // 
            // cbo_tennv
            // 
            this.cbo_tennv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_tennv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbo_tennv.FormattingEnabled = true;
            this.cbo_tennv.Location = new System.Drawing.Point(89, 313);
            this.cbo_tennv.Name = "cbo_tennv";
            this.cbo_tennv.Size = new System.Drawing.Size(642, 28);
            this.cbo_tennv.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "To :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Content:";
            // 
            // pic_send
            // 
            this.pic_send.Image = ((System.Drawing.Image)(resources.GetObject("pic_send.Image")));
            this.pic_send.Location = new System.Drawing.Point(638, 540);
            this.pic_send.Name = "pic_send";
            this.pic_send.Size = new System.Drawing.Size(83, 51);
            this.pic_send.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_send.TabIndex = 3;
            this.pic_send.TabStop = false;
            this.pic_send.Click += new System.EventHandler(this.pic_send_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtx_noticafitions);
            this.panel1.Location = new System.Drawing.Point(2, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 159);
            this.panel1.TabIndex = 4;
            // 
            // rtx_noticafitions
            // 
            this.rtx_noticafitions.BackColor = System.Drawing.Color.RosyBrown;
            this.rtx_noticafitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtx_noticafitions.Location = new System.Drawing.Point(0, 0);
            this.rtx_noticafitions.Name = "rtx_noticafitions";
            this.rtx_noticafitions.Size = new System.Drawing.Size(729, 157);
            this.rtx_noticafitions.TabIndex = 0;
            this.rtx_noticafitions.Text = "";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 65);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(635, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(733, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pic_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_tennv);
            this.Controls.Add(this.rtx_contentsend);
            this.Name = "FrmThongBao";
            this.Text = "FormThongBao";
            ((System.ComponentModel.ISupportInitialize)(this.pic_send)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtx_contentsend;
        private System.Windows.Forms.ComboBox cbo_tennv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtx_noticafitions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}