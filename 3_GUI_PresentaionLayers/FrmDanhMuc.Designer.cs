
namespace _3_GUI_PresentaionLayers
{
    partial class FrmDanhMuc
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
            this.dgridDanhMuc = new System.Windows.Forms.DataGridView();
            this.txtTenDM = new System.Windows.Forms.TextBox();
            this.txtMaDM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgridDanhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // chkOFF
            // 
            this.chkOFF.AutoSize = true;
            this.chkOFF.Location = new System.Drawing.Point(313, 163);
            this.chkOFF.Name = "chkOFF";
            this.chkOFF.Size = new System.Drawing.Size(134, 24);
            this.chkOFF.TabIndex = 28;
            this.chkOFF.Text = "Ngừng sử dụng";
            this.chkOFF.UseVisualStyleBackColor = true;
            // 
            // ckbON
            // 
            this.ckbON.AutoSize = true;
            this.ckbON.Location = new System.Drawing.Point(168, 165);
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
            this.label5.Location = new System.Drawing.Point(0, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Thông tin danh mục";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(168, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = ".................................................................";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(168, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = ".................................................................";
            // 
            // dgridDanhMuc
            // 
            this.dgridDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridDanhMuc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridDanhMuc.Location = new System.Drawing.Point(0, 222);
            this.dgridDanhMuc.Name = "dgridDanhMuc";
            this.dgridDanhMuc.RowHeadersWidth = 51;
            this.dgridDanhMuc.RowTemplate.Height = 29;
            this.dgridDanhMuc.Size = new System.Drawing.Size(481, 129);
            this.dgridDanhMuc.TabIndex = 24;
            this.dgridDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridDanhMuc_CellClick);
            this.dgridDanhMuc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridDanhMuc_CellContentClick);
            // 
            // txtTenDM
            // 
            this.txtTenDM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenDM.Location = new System.Drawing.Point(172, 107);
            this.txtTenDM.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDM.Name = "txtTenDM";
            this.txtTenDM.Size = new System.Drawing.Size(266, 20);
            this.txtTenDM.TabIndex = 22;
            this.txtTenDM.TextChanged += new System.EventHandler(this.txtTenChatLieu_TextChanged);
            // 
            // txtMaDM
            // 
            this.txtMaDM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaDM.Location = new System.Drawing.Point(168, 53);
            this.txtMaDM.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDM.Name = "txtMaDM";
            this.txtMaDM.Size = new System.Drawing.Size(266, 20);
            this.txtMaDM.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên Danh Mục";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã Danh Mục";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 30;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkOFF);
            this.Controls.Add(this.ckbON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgridDanhMuc);
            this.Controls.Add(this.txtTenDM);
            this.Controls.Add(this.txtMaDM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDanhMuc";
            ((System.ComponentModel.ISupportInitialize)(this.dgridDanhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOFF;
        private System.Windows.Forms.CheckBox ckbON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgridDanhMuc;
        private System.Windows.Forms.TextBox txtTenDM;
        private System.Windows.Forms.TextBox txtMaDM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}