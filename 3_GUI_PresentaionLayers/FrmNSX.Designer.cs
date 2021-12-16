
namespace _3_GUI_PresentaionLayers
{
    partial class FrmNSX
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
            this.cbx_hethang = new System.Windows.Forms.CheckBox();
            this.cbx_conhang = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_nsx = new System.Windows.Forms.DataGridView();
            this.txt_Timkiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_loc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TenNSX = new System.Windows.Forms.TextBox();
            this.txt_MaNSX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nsx)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_hethang
            // 
            this.cbx_hethang.AutoSize = true;
            this.cbx_hethang.ForeColor = System.Drawing.Color.Black;
            this.cbx_hethang.Location = new System.Drawing.Point(381, 135);
            this.cbx_hethang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbx_hethang.Name = "cbx_hethang";
            this.cbx_hethang.Size = new System.Drawing.Size(147, 24);
            this.cbx_hethang.TabIndex = 23;
            this.cbx_hethang.Text = "Không hoạt động";
            this.cbx_hethang.UseVisualStyleBackColor = true;
            this.cbx_hethang.CheckedChanged += new System.EventHandler(this.cbx_hethang_CheckedChanged);
            // 
            // cbx_conhang
            // 
            this.cbx_conhang.AutoSize = true;
            this.cbx_conhang.ForeColor = System.Drawing.Color.Black;
            this.cbx_conhang.Location = new System.Drawing.Point(245, 135);
            this.cbx_conhang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbx_conhang.Name = "cbx_conhang";
            this.cbx_conhang.Size = new System.Drawing.Size(103, 24);
            this.cbx_conhang.TabIndex = 22;
            this.cbx_conhang.Text = "Hoạt động";
            this.cbx_conhang.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(110, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Trạng Thái";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgv_nsx
            // 
            this.dgv_nsx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nsx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nsx.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_nsx.Location = new System.Drawing.Point(0, 284);
            this.dgv_nsx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_nsx.Name = "dgv_nsx";
            this.dgv_nsx.RowHeadersWidth = 51;
            this.dgv_nsx.RowTemplate.Height = 25;
            this.dgv_nsx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_nsx.Size = new System.Drawing.Size(590, 155);
            this.dgv_nsx.TabIndex = 24;
            this.dgv_nsx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellClick);
            this.dgv_nsx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellContentClick);
            this.dgv_nsx.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellDoubleClick);
            // 
            // txt_Timkiem
            // 
            this.txt_Timkiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Timkiem.ForeColor = System.Drawing.Color.Black;
            this.txt_Timkiem.Location = new System.Drawing.Point(247, 205);
            this.txt_Timkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Timkiem.Name = "txt_Timkiem";
            this.txt_Timkiem.Size = new System.Drawing.Size(270, 20);
            this.txt_Timkiem.TabIndex = 25;
            this.txt_Timkiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Timkiem_KeyUp);
            this.txt_Timkiem.Leave += new System.EventHandler(this.txt_Timkiem_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(110, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tìm kiếm";
            // 
            // cbx_loc
            // 
            this.cbx_loc.ForeColor = System.Drawing.Color.Black;
            this.cbx_loc.FormattingEnabled = true;
            this.cbx_loc.Location = new System.Drawing.Point(246, 167);
            this.cbx_loc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_loc.Name = "cbx_loc";
            this.cbx_loc.Size = new System.Drawing.Size(270, 28);
            this.cbx_loc.TabIndex = 27;
            this.cbx_loc.SelectedValueChanged += new System.EventHandler(this.cbx_loc_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(111, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Lọc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(15, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Thông tin nhà sản xuất";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(246, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(269, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = ".................................................................";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(238, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = ".................................................................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(238, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = ".................................................................";
            // 
            // txt_TenNSX
            // 
            this.txt_TenNSX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TenNSX.Location = new System.Drawing.Point(241, 73);
            this.txt_TenNSX.Margin = new System.Windows.Forms.Padding(1);
            this.txt_TenNSX.Name = "txt_TenNSX";
            this.txt_TenNSX.Size = new System.Drawing.Size(265, 20);
            this.txt_TenNSX.TabIndex = 35;
            // 
            // txt_MaNSX
            // 
            this.txt_MaNSX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MaNSX.Location = new System.Drawing.Point(238, 20);
            this.txt_MaNSX.Margin = new System.Windows.Forms.Padding(1);
            this.txt_MaNSX.Name = "txt_MaNSX";
            this.txt_MaNSX.Size = new System.Drawing.Size(265, 20);
            this.txt_MaNSX.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Tên Nhà Sản Xuất";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 40);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Mã Nhà Sản Xuất";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 39;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TenNSX);
            this.Controls.Add(this.txt_MaNSX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_loc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Timkiem);
            this.Controls.Add(this.dgv_nsx);
            this.Controls.Add(this.cbx_hethang);
            this.Controls.Add(this.cbx_conhang);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmNSX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNSX";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nsx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbx_hethang;
        private System.Windows.Forms.CheckBox cbx_conhang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_nsx;
        private System.Windows.Forms.TextBox txt_Timkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_loc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenNSX;
        private System.Windows.Forms.TextBox txt_MaNSX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}