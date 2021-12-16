
namespace _3_GUI_PresentaionLayers
{
    partial class FormXuatXu
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
            this.cbxTenQuocGia = new System.Windows.Forms.ComboBox();
            this.txtMaQuocGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_XuatXu = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Timkiem = new System.Windows.Forms.TextBox();
            this.cbx_loc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkKhongHoatDong = new System.Windows.Forms.CheckBox();
            this.chkHoatDong = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuatXu)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTenQuocGia
            // 
            this.cbxTenQuocGia.FormattingEnabled = true;
            this.cbxTenQuocGia.Location = new System.Drawing.Point(238, 86);
            this.cbxTenQuocGia.Margin = new System.Windows.Forms.Padding(2);
            this.cbxTenQuocGia.Name = "cbxTenQuocGia";
            this.cbxTenQuocGia.Size = new System.Drawing.Size(162, 28);
            this.cbxTenQuocGia.TabIndex = 13;
            // 
            // txtMaQuocGia
            // 
            this.txtMaQuocGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaQuocGia.Location = new System.Drawing.Point(238, 22);
            this.txtMaQuocGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaQuocGia.Name = "txtMaQuocGia";
            this.txtMaQuocGia.Size = new System.Drawing.Size(263, 20);
            this.txtMaQuocGia.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Quốc Gia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Quốc Gia";
            // 
            // dgv_XuatXu
            // 
            this.dgv_XuatXu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XuatXu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_XuatXu.Location = new System.Drawing.Point(0, 272);
            this.dgv_XuatXu.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_XuatXu.Name = "dgv_XuatXu";
            this.dgv_XuatXu.RowHeadersWidth = 62;
            this.dgv_XuatXu.RowTemplate.Height = 33;
            this.dgv_XuatXu.Size = new System.Drawing.Size(598, 180);
            this.dgv_XuatXu.TabIndex = 25;
            this.dgv_XuatXu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_XuatXu_CellClick_1);
            this.dgv_XuatXu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_XuatXu_CellContentClick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tìm kiếm";
            // 
            // txt_Timkiem
            // 
            this.txt_Timkiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Timkiem.Location = new System.Drawing.Point(238, 163);
            this.txt_Timkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Timkiem.Name = "txt_Timkiem";
            this.txt_Timkiem.Size = new System.Drawing.Size(270, 20);
            this.txt_Timkiem.TabIndex = 27;
            this.txt_Timkiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Timkiem_KeyUp);
            this.txt_Timkiem.Leave += new System.EventHandler(this.txt_Timkiem_Leave);
            // 
            // cbx_loc
            // 
            this.cbx_loc.FormattingEnabled = true;
            this.cbx_loc.Location = new System.Drawing.Point(238, 230);
            this.cbx_loc.Name = "cbx_loc";
            this.cbx_loc.Size = new System.Drawing.Size(162, 28);
            this.cbx_loc.TabIndex = 29;
            this.cbx_loc.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Lọc";
            // 
            // ChkKhongHoatDong
            // 
            this.ChkKhongHoatDong.AutoSize = true;
            this.ChkKhongHoatDong.ForeColor = System.Drawing.Color.Black;
            this.ChkKhongHoatDong.Location = new System.Drawing.Point(358, 128);
            this.ChkKhongHoatDong.Name = "ChkKhongHoatDong";
            this.ChkKhongHoatDong.Size = new System.Drawing.Size(147, 24);
            this.ChkKhongHoatDong.TabIndex = 33;
            this.ChkKhongHoatDong.Text = "Không hoạt động";
            this.ChkKhongHoatDong.UseVisualStyleBackColor = true;
            // 
            // chkHoatDong
            // 
            this.chkHoatDong.AutoSize = true;
            this.chkHoatDong.ForeColor = System.Drawing.Color.Black;
            this.chkHoatDong.Location = new System.Drawing.Point(238, 128);
            this.chkHoatDong.Name = "chkHoatDong";
            this.chkHoatDong.Size = new System.Drawing.Size(103, 24);
            this.chkHoatDong.TabIndex = 32;
            this.chkHoatDong.Text = "Hoạt động";
            this.chkHoatDong.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(84, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Trạng thái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(238, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = ".................................................................";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(238, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = ".................................................................";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(0, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Thông tin xuất xứ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 37;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormXuatXu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 452);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChkKhongHoatDong);
            this.Controls.Add(this.chkHoatDong);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_loc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Timkiem);
            this.Controls.Add(this.dgv_XuatXu);
            this.Controls.Add(this.cbxTenQuocGia);
            this.Controls.Add(this.txtMaQuocGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormXuatXu";
            this.Text = "XuatXu";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuatXu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTenQuocGia;
        private System.Windows.Forms.TextBox txtMaQuocGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_XuatXu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Timkiem;
        private System.Windows.Forms.ComboBox cbx_loc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkKhongHoatDong;
        private System.Windows.Forms.CheckBox chkHoatDong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}