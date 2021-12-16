
namespace _3_GUI_PresentaionLayers
{
    partial class FormDungTich
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
            this.chk_HetHang = new System.Windows.Forms.CheckBox();
            this.chk_ConHang = new System.Windows.Forms.CheckBox();
            this.txtSoDungTich = new System.Windows.Forms.TextBox();
            this.txtMaDungTich = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_DungTich = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.cbx_loc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DungTich)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_HetHang
            // 
            this.chk_HetHang.AutoSize = true;
            this.chk_HetHang.Location = new System.Drawing.Point(338, 138);
            this.chk_HetHang.Margin = new System.Windows.Forms.Padding(2);
            this.chk_HetHang.Name = "chk_HetHang";
            this.chk_HetHang.Size = new System.Drawing.Size(95, 24);
            this.chk_HetHang.TabIndex = 16;
            this.chk_HetHang.Text = "Hết Hàng";
            this.chk_HetHang.UseVisualStyleBackColor = true;
            this.chk_HetHang.CheckedChanged += new System.EventHandler(this.chk_HetHang_CheckedChanged_1);
            // 
            // chk_ConHang
            // 
            this.chk_ConHang.AutoSize = true;
            this.chk_ConHang.Location = new System.Drawing.Point(218, 138);
            this.chk_ConHang.Margin = new System.Windows.Forms.Padding(2);
            this.chk_ConHang.Name = "chk_ConHang";
            this.chk_ConHang.Size = new System.Drawing.Size(97, 24);
            this.chk_ConHang.TabIndex = 15;
            this.chk_ConHang.Text = "Còn Hàng";
            this.chk_ConHang.UseVisualStyleBackColor = true;
            this.chk_ConHang.CheckedChanged += new System.EventHandler(this.chk_ConHang_CheckedChanged_1);
            // 
            // txtSoDungTich
            // 
            this.txtSoDungTich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoDungTich.Location = new System.Drawing.Point(209, 82);
            this.txtSoDungTich.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoDungTich.Name = "txtSoDungTich";
            this.txtSoDungTich.Size = new System.Drawing.Size(270, 20);
            this.txtSoDungTich.TabIndex = 14;
            // 
            // txtMaDungTich
            // 
            this.txtMaDungTich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaDungTich.Location = new System.Drawing.Point(254, 21);
            this.txtMaDungTich.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDungTich.Name = "txtMaDungTich";
            this.txtMaDungTich.Size = new System.Drawing.Size(270, 20);
            this.txtMaDungTich.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Trạng Thái";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Số Dung Tích";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Dung Tích";
            // 
            // dgv_DungTich
            // 
            this.dgv_DungTich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DungTich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_DungTich.Location = new System.Drawing.Point(0, 261);
            this.dgv_DungTich.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_DungTich.Name = "dgv_DungTich";
            this.dgv_DungTich.RowHeadersWidth = 62;
            this.dgv_DungTich.RowTemplate.Height = 33;
            this.dgv_DungTich.Size = new System.Drawing.Size(533, 164);
            this.dgv_DungTich.TabIndex = 25;
            this.dgv_DungTich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DungTich_CellClick_1);
            this.dgv_DungTich.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DungTich_CellContentClick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tìm Kiếm";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TimKiem.Location = new System.Drawing.Point(202, 164);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(273, 20);
            this.txt_TimKiem.TabIndex = 28;
            this.txt_TimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyUp);
            this.txt_TimKiem.Leave += new System.EventHandler(this.txt_TimKiem_Leave);
            // 
            // cbx_loc
            // 
            this.cbx_loc.FormattingEnabled = true;
            this.cbx_loc.Location = new System.Drawing.Point(206, 221);
            this.cbx_loc.Name = "cbx_loc";
            this.cbx_loc.Size = new System.Drawing.Size(216, 28);
            this.cbx_loc.TabIndex = 30;
            this.cbx_loc.SelectedIndexChanged += new System.EventHandler(this.cbx_loc_SelectedIndexChanged);
            this.cbx_loc.SelectedValueChanged += new System.EventHandler(this.cbx_loc_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Lọc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(209, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = ".................................................................";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(209, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(269, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = ".................................................................";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(202, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = ".................................................................";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "Thông tin dung tích";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 36;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDungTich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 425);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_loc);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_DungTich);
            this.Controls.Add(this.chk_HetHang);
            this.Controls.Add(this.chk_ConHang);
            this.Controls.Add(this.txtSoDungTich);
            this.Controls.Add(this.txtMaDungTich);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDungTich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DungTich";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DungTich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_HetHang;
        private System.Windows.Forms.CheckBox chk_ConHang;
        private System.Windows.Forms.TextBox txtSoDungTich;
        private System.Windows.Forms.TextBox txtMaDungTich;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_DungTich;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.ComboBox cbx_loc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}