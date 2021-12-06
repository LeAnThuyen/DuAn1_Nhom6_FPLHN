
namespace _3_GUI_PresentaionLayers
{
    partial class FrmAnh
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
            this.btn_send = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_TenAnh = new System.Windows.Forms.TextBox();
            this.txt_MaAnh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DuongDan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_anh = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_CoAnh = new System.Windows.Forms.CheckBox();
            this.cbx_Kcoanh = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_anh)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(621, 19);
            this.btn_send.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(90, 27);
            this.btn_send.TabIndex = 17;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(370, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txt_TenAnh
            // 
            this.txt_TenAnh.Location = new System.Drawing.Point(155, 60);
            this.txt_TenAnh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_TenAnh.Name = "txt_TenAnh";
            this.txt_TenAnh.Size = new System.Drawing.Size(146, 27);
            this.txt_TenAnh.TabIndex = 15;
            // 
            // txt_MaAnh
            // 
            this.txt_MaAnh.Location = new System.Drawing.Point(155, 15);
            this.txt_MaAnh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MaAnh.Name = "txt_MaAnh";
            this.txt_MaAnh.Size = new System.Drawing.Size(146, 27);
            this.txt_MaAnh.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên Ảnh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Ảnh";
            // 
            // txt_DuongDan
            // 
            this.txt_DuongDan.Location = new System.Drawing.Point(155, 121);
            this.txt_DuongDan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_DuongDan.Name = "txt_DuongDan";
            this.txt_DuongDan.Size = new System.Drawing.Size(146, 27);
            this.txt_DuongDan.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Đường dẫn";
            // 
            // dgv_anh
            // 
            this.dgv_anh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_anh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_anh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_anh.Location = new System.Drawing.Point(0, 247);
            this.dgv_anh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_anh.Name = "dgv_anh";
            this.dgv_anh.RowHeadersWidth = 51;
            this.dgv_anh.RowTemplate.Height = 25;
            this.dgv_anh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_anh.Size = new System.Drawing.Size(760, 200);
            this.dgv_anh.TabIndex = 20;
            this.dgv_anh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_anh_CellClick);
            this.dgv_anh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_anh_CellContentClick);
            this.dgv_anh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_anh_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Trạng thái";
            // 
            // cbx_CoAnh
            // 
            this.cbx_CoAnh.AutoSize = true;
            this.cbx_CoAnh.Location = new System.Drawing.Point(155, 169);
            this.cbx_CoAnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_CoAnh.Name = "cbx_CoAnh";
            this.cbx_CoAnh.Size = new System.Drawing.Size(77, 24);
            this.cbx_CoAnh.TabIndex = 22;
            this.cbx_CoAnh.Text = "Có ảnh";
            this.cbx_CoAnh.UseVisualStyleBackColor = true;
            this.cbx_CoAnh.CheckedChanged += new System.EventHandler(this.cbx_CoAnh_CheckedChanged);
            // 
            // cbx_Kcoanh
            // 
            this.cbx_Kcoanh.AutoSize = true;
            this.cbx_Kcoanh.Location = new System.Drawing.Point(235, 169);
            this.cbx_Kcoanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_Kcoanh.Name = "cbx_Kcoanh";
            this.cbx_Kcoanh.Size = new System.Drawing.Size(113, 24);
            this.cbx_Kcoanh.TabIndex = 23;
            this.cbx_Kcoanh.Text = "Chưa có ảnh";
            this.cbx_Kcoanh.UseVisualStyleBackColor = true;
            this.cbx_Kcoanh.CheckedChanged += new System.EventHandler(this.cbx_Kcoanh_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tìm kiếm";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(632, 208);
            this.txt_timkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(114, 27);
            this.txt_timkiem.TabIndex = 25;
            this.txt_timkiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_timkiem_KeyUp);
            this.txt_timkiem.Leave += new System.EventHandler(this.txt_timkiem_Leave);
            // 
            // FrmAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(760, 447);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_Kcoanh);
            this.Controls.Add(this.cbx_CoAnh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_anh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DuongDan);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_TenAnh);
            this.Controls.Add(this.txt_MaAnh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAnh";
            this.Text = "Anh";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_anh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_TenAnh;
        private System.Windows.Forms.TextBox txt_MaAnh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DuongDan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_anh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbx_CoAnh;
        private System.Windows.Forms.CheckBox cbx_Kcoanh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_timkiem;
    }
}