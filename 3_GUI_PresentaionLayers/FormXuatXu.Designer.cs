
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuatXu)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTenQuocGia
            // 
            this.cbxTenQuocGia.FormattingEnabled = true;
            this.cbxTenQuocGia.Location = new System.Drawing.Point(279, 90);
            this.cbxTenQuocGia.Margin = new System.Windows.Forms.Padding(2);
            this.cbxTenQuocGia.Name = "cbxTenQuocGia";
            this.cbxTenQuocGia.Size = new System.Drawing.Size(146, 28);
            this.cbxTenQuocGia.TabIndex = 13;
            // 
            // txtMaQuocGia
            // 
            this.txtMaQuocGia.Location = new System.Drawing.Point(279, 38);
            this.txtMaQuocGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaQuocGia.Name = "txtMaQuocGia";
            this.txtMaQuocGia.Size = new System.Drawing.Size(146, 27);
            this.txtMaQuocGia.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Quốc Gia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Quốc Gia";
            // 
            // dgv_XuatXu
            // 
            this.dgv_XuatXu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_XuatXu.Location = new System.Drawing.Point(26, 132);
            this.dgv_XuatXu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_XuatXu.Name = "dgv_XuatXu";
            this.dgv_XuatXu.RowHeadersWidth = 62;
            this.dgv_XuatXu.RowTemplate.Height = 33;
            this.dgv_XuatXu.Size = new System.Drawing.Size(540, 180);
            this.dgv_XuatXu.TabIndex = 25;
            this.dgv_XuatXu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_XuatXu_CellClick_1);
            this.dgv_XuatXu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_XuatXu_CellContentClick_1);
            // 
            // FormXuatXu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(602, 345);
            this.Controls.Add(this.dgv_XuatXu);
            this.Controls.Add(this.cbxTenQuocGia);
            this.Controls.Add(this.txtMaQuocGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
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
    }
}