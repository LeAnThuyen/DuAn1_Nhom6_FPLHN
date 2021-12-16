
namespace _3_GUI_PresentaionLayers
{
    partial class FrmVatChua
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
            this.chkOFF = new System.Windows.Forms.CheckBox();
            this.ckbON = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgridVatChua = new System.Windows.Forms.DataGridView();
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.txtMaCL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgridVatChua)).BeginInit();
            this.SuspendLayout();
            // 
            // chkOFF
            // 
            this.chkOFF.AutoSize = true;
            this.chkOFF.Location = new System.Drawing.Point(313, 160);
            this.chkOFF.Name = "chkOFF";
            this.chkOFF.Size = new System.Drawing.Size(134, 24);
            this.chkOFF.TabIndex = 28;
            this.chkOFF.Text = "Ngừng sử dụng";
            this.chkOFF.UseVisualStyleBackColor = true;
            // 
            // ckbON
            // 
            this.ckbON.AutoSize = true;
            this.ckbON.Location = new System.Drawing.Point(168, 161);
            this.ckbON.Name = "ckbON";
            this.ckbON.Size = new System.Drawing.Size(124, 24);
            this.ckbON.TabIndex = 29;
            this.ckbON.Text = "Đang sử dụng";
            this.ckbON.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(11, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Thông tin vật chứa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(165, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = ".................................................................";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(168, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = ".................................................................";
            // 
            // dgridVatChua
            // 
            this.dgridVatChua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridVatChua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridVatChua.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridVatChua.Location = new System.Drawing.Point(0, 204);
            this.dgridVatChua.Name = "dgridVatChua";
            this.dgridVatChua.RowHeadersWidth = 51;
            this.dgridVatChua.RowTemplate.Height = 29;
            this.dgridVatChua.Size = new System.Drawing.Size(492, 142);
            this.dgridVatChua.TabIndex = 24;
            this.dgridVatChua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridVatChua_CellClick_1);
            this.dgridVatChua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridVatChua_CellContentClick);
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenChatLieu.Location = new System.Drawing.Point(168, 99);
            this.txtTenChatLieu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(266, 20);
            this.txtTenChatLieu.TabIndex = 22;
            // 
            // txtMaCL
            // 
            this.txtMaCL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaCL.Location = new System.Drawing.Point(168, 44);
            this.txtMaCL.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaCL.Name = "txtMaCL";
            this.txtMaCL.Size = new System.Drawing.Size(266, 20);
            this.txtMaCL.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên vật chứa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã vật chứa";
            // 
            // X
            // 
            this.X.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.X.Location = new System.Drawing.Point(398, -2);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(94, 29);
            this.X.TabIndex = 30;
            this.X.Text = "X";
            this.X.UseVisualStyleBackColor = true;
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // FrmVatChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 346);
            this.Controls.Add(this.X);
            this.Controls.Add(this.chkOFF);
            this.Controls.Add(this.ckbON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgridVatChua);
            this.Controls.Add(this.txtTenChatLieu);
            this.Controls.Add(this.txtMaCL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVatChua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VatChua";
            ((System.ComponentModel.ISupportInitialize)(this.dgridVatChua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOFF;
        private System.Windows.Forms.CheckBox ckbON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgridVatChua;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.TextBox txtMaCL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button X;
    }
}