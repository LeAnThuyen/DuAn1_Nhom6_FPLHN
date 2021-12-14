
namespace _3_GUI_PresentaionLayers
{
    partial class FrmQuenMatKhau
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
            this.components = new System.ComponentModel.Container();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.txt_mxn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nlmk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(186, 27);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(240, 27);
            this.txt_email.TabIndex = 12;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            this.txt_email.Leave += new System.EventHandler(this.txt_email_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(48, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Email";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackColor = System.Drawing.Color.Gray;
            this.btn_dangnhap.FlatAppearance.BorderSize = 0;
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_dangnhap.ForeColor = System.Drawing.Color.Maroon;
            this.btn_dangnhap.Location = new System.Drawing.Point(245, 57);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(126, 34);
            this.btn_dangnhap.TabIndex = 13;
            this.btn_dangnhap.Text = "Tìm Mail";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txt_mxn
            // 
            this.txt_mxn.Location = new System.Drawing.Point(186, 109);
            this.txt_mxn.Name = "txt_mxn";
            this.txt_mxn.Size = new System.Drawing.Size(240, 27);
            this.txt_mxn.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(48, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nhập Mã Xác Nhận";
            // 
            // txt_mk
            // 
            this.txt_mk.Location = new System.Drawing.Point(186, 146);
            this.txt_mk.Multiline = true;
            this.txt_mk.Name = "txt_mk";
            this.txt_mk.PasswordChar = '*';
            this.txt_mk.Size = new System.Drawing.Size(240, 26);
            this.txt_mk.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(48, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nhập Mật Khẩu";
            // 
            // txt_nlmk
            // 
            this.txt_nlmk.Location = new System.Drawing.Point(186, 189);
            this.txt_nlmk.Multiline = true;
            this.txt_nlmk.Name = "txt_nlmk";
            this.txt_nlmk.PasswordChar = '*';
            this.txt_nlmk.Size = new System.Drawing.Size(240, 26);
            this.txt_nlmk.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(48, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nhập lại Mật Khẩu";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(236, 218);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Xác Nhận";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(431, 151);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(431, 194);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // FrmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(510, 452);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_nlmk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_mk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_mxn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmQuenMatKhau";
            this.Text = "FrmQuenMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.TextBox txt_mxn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nlmk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Timer timer1;
    }
}