
namespace _3_GUI_PresentaionLayers
{
    partial class FormChatLieu
    {/// <summary>
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaCL = new System.Windows.Forms.TextBox();
            this.dgridChatLieu = new System.Windows.Forms.DataGridView();
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbON = new System.Windows.Forms.CheckBox();
            this.chkOFF = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgridChatLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Chất Liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Chất Liệu";
            // 
            // txtMaCL
            // 
            this.txtMaCL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaCL.Location = new System.Drawing.Point(168, 51);
            this.txtMaCL.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaCL.Name = "txtMaCL";
            this.txtMaCL.Size = new System.Drawing.Size(266, 20);
            this.txtMaCL.TabIndex = 3;
            // 
            // dgridChatLieu
            // 
            this.dgridChatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridChatLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridChatLieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridChatLieu.Location = new System.Drawing.Point(0, 239);
            this.dgridChatLieu.Name = "dgridChatLieu";
            this.dgridChatLieu.RowHeadersWidth = 51;
            this.dgridChatLieu.RowTemplate.Height = 29;
            this.dgridChatLieu.Size = new System.Drawing.Size(528, 129);
            this.dgridChatLieu.TabIndex = 4;
            this.dgridChatLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridChatLieu_CellClick);
            this.dgridChatLieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridChatLieu_CellContentClick);
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenChatLieu.Location = new System.Drawing.Point(168, 106);
            this.txtTenChatLieu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(266, 20);
            this.txtTenChatLieu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(168, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = ".................................................................";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(165, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = ".................................................................";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(11, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thông tin chất liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 168);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Trạng thái";
            // 
            // ckbON
            // 
            this.ckbON.AutoSize = true;
            this.ckbON.Location = new System.Drawing.Point(168, 168);
            this.ckbON.Name = "ckbON";
            this.ckbON.Size = new System.Drawing.Size(124, 24);
            this.ckbON.TabIndex = 7;
            this.ckbON.Text = "Đang sử dụng";
            this.ckbON.UseVisualStyleBackColor = true;
            // 
            // chkOFF
            // 
            this.chkOFF.AutoSize = true;
            this.chkOFF.Location = new System.Drawing.Point(313, 167);
            this.chkOFF.Name = "chkOFF";
            this.chkOFF.Size = new System.Drawing.Size(134, 24);
            this.chkOFF.TabIndex = 7;
            this.chkOFF.Text = "Ngừng sử dụng";
            this.chkOFF.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormChatLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(528, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkOFF);
            this.Controls.Add(this.ckbON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgridChatLieu);
            this.Controls.Add(this.txtTenChatLieu);
            this.Controls.Add(this.txtMaCL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormChatLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatLieu";
            ((System.ComponentModel.ISupportInitialize)(this.dgridChatLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaCL;
        private System.Windows.Forms.DataGridView dgridChatLieu;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbON;
        private System.Windows.Forms.CheckBox chkOFF;
        private System.Windows.Forms.Button button1;
    }
}