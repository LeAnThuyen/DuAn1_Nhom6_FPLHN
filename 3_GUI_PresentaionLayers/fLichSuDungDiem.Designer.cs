
namespace _3_GUI_PresentaionLayers
{
    partial class fLichSuDungDiem
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
            this.btnDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDatetime = new System.Windows.Forms.Button();
            this.dgridLichSu = new System.Windows.Forms.DataGridView();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblBacKH = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBac = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblDiem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(452, 130);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(33, 36);
            this.btnDown.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnDown, "Sắp xếp theo điểm giảm dần");
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử dùng điểm";
            // 
            // btnUp
            // 
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(413, 130);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(33, 36);
            this.btnUp.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnUp, "Sắp xếp theo điểm tăng dần");
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDatetime
            // 
            this.btnDatetime.FlatAppearance.BorderSize = 0;
            this.btnDatetime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatetime.Location = new System.Drawing.Point(374, 130);
            this.btnDatetime.Name = "btnDatetime";
            this.btnDatetime.Size = new System.Drawing.Size(33, 36);
            this.btnDatetime.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnDatetime, "Sắp xếp theo tgian mua hàng");
            this.btnDatetime.UseVisualStyleBackColor = true;
            // 
            // dgridLichSu
            // 
            this.dgridLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridLichSu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgridLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridLichSu.Location = new System.Drawing.Point(12, 172);
            this.dgridLichSu.Name = "dgridLichSu";
            this.dgridLichSu.RowHeadersWidth = 51;
            this.dgridLichSu.RowTemplate.Height = 29;
            this.dgridLichSu.Size = new System.Drawing.Size(495, 272);
            this.dgridLichSu.TabIndex = 15;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaKH.ForeColor = System.Drawing.Color.Red;
            this.lblMaKH.Location = new System.Drawing.Point(387, 95);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(43, 23);
            this.lblMaKH.TabIndex = 9;
            this.lblMaKH.Text = "Bậc:";
            // 
            // lblBacKH
            // 
            this.lblBacKH.AutoSize = true;
            this.lblBacKH.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBacKH.ForeColor = System.Drawing.Color.Red;
            this.lblBacKH.Location = new System.Drawing.Point(61, 131);
            this.lblBacKH.Name = "lblBacKH";
            this.lblBacKH.Size = new System.Drawing.Size(43, 23);
            this.lblBacKH.TabIndex = 10;
            this.lblBacKH.Text = "Bậc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(312, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã KH:";
            // 
            // lblBac
            // 
            this.lblBac.AutoSize = true;
            this.lblBac.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBac.Location = new System.Drawing.Point(12, 131);
            this.lblBac.Name = "lblBac";
            this.lblBac.Size = new System.Drawing.Size(43, 23);
            this.lblBac.TabIndex = 12;
            this.lblBac.Text = "Bậc:";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenKH.ForeColor = System.Drawing.Color.Red;
            this.lblTenKH.Location = new System.Drawing.Point(162, 95);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(144, 23);
            this.lblTenKH.TabIndex = 7;
            this.lblTenKH.Text = "Tên khách hàng: ";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTen.Location = new System.Drawing.Point(12, 95);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(144, 23);
            this.lblTen.TabIndex = 8;
            this.lblTen.Text = "Tên khách hàng: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 60);
            this.panel1.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoad.Location = new System.Drawing.Point(352, 461);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(138, 46);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiem.ForeColor = System.Drawing.Color.Red;
            this.lblDiem.Location = new System.Drawing.Point(270, 130);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(43, 23);
            this.lblDiem.TabIndex = 13;
            this.lblDiem.Text = "Bậc:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(131, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Số điểm còn lại";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(436, 66);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(54, 27);
            this.txtMa.TabIndex = 19;
            // 
            // fLichSuDungDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 508);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDatetime);
            this.Controls.Add(this.dgridLichSu);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblBacKH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBac);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.label6);
            this.Name = "fLichSuDungDiem";
            this.Text = "fLichSuDungDiem";
            this.Load += new System.EventHandler(this.fLichSuDungDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnDown;
        public System.Windows.Forms.Button btnUp;
        public System.Windows.Forms.Button btnDatetime;
        public System.Windows.Forms.DataGridView dgridLichSu;
        public System.Windows.Forms.Label lblMaKH;
        public System.Windows.Forms.Label lblBacKH;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblBac;
        public System.Windows.Forms.Label lblTenKH;
        public System.Windows.Forms.Label lblTen;
        public System.Windows.Forms.Label lblDiem;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Button btnLoad;
    }
}