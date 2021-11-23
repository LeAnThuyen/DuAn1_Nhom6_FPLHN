
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DungTich)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_HetHang
            // 
            this.chk_HetHang.AutoSize = true;
            this.chk_HetHang.Location = new System.Drawing.Point(350, 103);
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
            this.chk_ConHang.Location = new System.Drawing.Point(251, 103);
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
            this.txtSoDungTich.Location = new System.Drawing.Point(271, 68);
            this.txtSoDungTich.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoDungTich.Name = "txtSoDungTich";
            this.txtSoDungTich.Size = new System.Drawing.Size(171, 27);
            this.txtSoDungTich.TabIndex = 14;
            // 
            // txtMaDungTich
            // 
            this.txtMaDungTich.Location = new System.Drawing.Point(271, 31);
            this.txtMaDungTich.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDungTich.Name = "txtMaDungTich";
            this.txtMaDungTich.Size = new System.Drawing.Size(171, 27);
            this.txtMaDungTich.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 103);
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
            this.label2.Location = new System.Drawing.Point(160, 68);
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
            this.label1.Location = new System.Drawing.Point(160, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Dung Tích";
            // 
            // dgv_DungTich
            // 
            this.dgv_DungTich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DungTich.Location = new System.Drawing.Point(50, 149);
            this.dgv_DungTich.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_DungTich.Name = "dgv_DungTich";
            this.dgv_DungTich.RowHeadersWidth = 62;
            this.dgv_DungTich.RowTemplate.Height = 33;
            this.dgv_DungTich.Size = new System.Drawing.Size(540, 180);
            this.dgv_DungTich.TabIndex = 25;
            this.dgv_DungTich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DungTich_CellClick_1);
            this.dgv_DungTich.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DungTich_CellContentClick_1);
            // 
            // FormDungTich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(633, 391);
            this.Controls.Add(this.dgv_DungTich);
            this.Controls.Add(this.chk_HetHang);
            this.Controls.Add(this.chk_ConHang);
            this.Controls.Add(this.txtSoDungTich);
            this.Controls.Add(this.txtMaDungTich);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormDungTich";
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
    }
}