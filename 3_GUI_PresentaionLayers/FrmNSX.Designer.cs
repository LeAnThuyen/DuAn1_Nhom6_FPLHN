
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
            this.txt_TenNSX = new System.Windows.Forms.TextBox();
            this.txt_MaNSX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_nsx = new System.Windows.Forms.DataGridView();
            this.txt_Timkiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nsx)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_hethang
            // 
            this.cbx_hethang.AutoSize = true;
            this.cbx_hethang.Location = new System.Drawing.Point(217, 87);
            this.cbx_hethang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbx_hethang.Name = "cbx_hethang";
            this.cbx_hethang.Size = new System.Drawing.Size(95, 24);
            this.cbx_hethang.TabIndex = 23;
            this.cbx_hethang.Text = "Hết Hàng";
            this.cbx_hethang.UseVisualStyleBackColor = true;
            this.cbx_hethang.CheckedChanged += new System.EventHandler(this.cbx_hethang_CheckedChanged);
            // 
            // cbx_conhang
            // 
            this.cbx_conhang.AutoSize = true;
            this.cbx_conhang.Location = new System.Drawing.Point(119, 87);
            this.cbx_conhang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbx_conhang.Name = "cbx_conhang";
            this.cbx_conhang.Size = new System.Drawing.Size(97, 24);
            this.cbx_conhang.TabIndex = 22;
            this.cbx_conhang.Text = "Còn Hàng";
            this.cbx_conhang.UseVisualStyleBackColor = true;
            this.cbx_conhang.CheckedChanged += new System.EventHandler(this.cbx_conhang_CheckedChanged_1);
            // 
            // txt_TenNSX
            // 
            this.txt_TenNSX.Location = new System.Drawing.Point(158, 49);
            this.txt_TenNSX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_TenNSX.Name = "txt_TenNSX";
            this.txt_TenNSX.Size = new System.Drawing.Size(171, 27);
            this.txt_TenNSX.TabIndex = 21;
            // 
            // txt_MaNSX
            // 
            this.txt_MaNSX.Location = new System.Drawing.Point(158, 12);
            this.txt_MaNSX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_MaNSX.Name = "txt_MaNSX";
            this.txt_MaNSX.Size = new System.Drawing.Size(171, 27);
            this.txt_MaNSX.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Trạng Thái";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên nhà sản xuất";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mã Nhà sản xuất";
            // 
            // dgv_nsx
            // 
            this.dgv_nsx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nsx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nsx.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_nsx.Location = new System.Drawing.Point(0, 209);
            this.dgv_nsx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_nsx.Name = "dgv_nsx";
            this.dgv_nsx.RowHeadersWidth = 51;
            this.dgv_nsx.RowTemplate.Height = 25;
            this.dgv_nsx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_nsx.Size = new System.Drawing.Size(530, 200);
            this.dgv_nsx.TabIndex = 24;
            this.dgv_nsx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellClick);
            this.dgv_nsx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellContentClick);
            this.dgv_nsx.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nsx_CellDoubleClick);
            // 
            // txt_Timkiem
            // 
            this.txt_Timkiem.Location = new System.Drawing.Point(354, 171);
            this.txt_Timkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Timkiem.Name = "txt_Timkiem";
            this.txt_Timkiem.Size = new System.Drawing.Size(162, 27);
            this.txt_Timkiem.TabIndex = 25;
            this.txt_Timkiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Timkiem_KeyUp);
            this.txt_Timkiem.Leave += new System.EventHandler(this.txt_Timkiem_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tìm kiếm";
            // 
            // FrmNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 409);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Timkiem);
            this.Controls.Add(this.dgv_nsx);
            this.Controls.Add(this.cbx_hethang);
            this.Controls.Add(this.cbx_conhang);
            this.Controls.Add(this.txt_TenNSX);
            this.Controls.Add(this.txt_MaNSX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmNSX";
            this.Text = "FrmNSX";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nsx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbx_hethang;
        private System.Windows.Forms.CheckBox cbx_conhang;
        private System.Windows.Forms.TextBox txt_TenNSX;
        private System.Windows.Forms.TextBox txt_MaNSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_nsx;
        private System.Windows.Forms.TextBox txt_Timkiem;
        private System.Windows.Forms.Label label4;
    }
}