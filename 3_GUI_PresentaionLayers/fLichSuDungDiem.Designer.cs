
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLichSuDungDiem));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblBac = new System.Windows.Forms.Label();
            this.dgridLichSu = new System.Windows.Forms.DataGridView();
            this.btnDatetime = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 60);
            this.panel1.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTen.Location = new System.Drawing.Point(12, 89);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(144, 23);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên khách hàng: ";
            // 
            // lblBac
            // 
            this.lblBac.AutoSize = true;
            this.lblBac.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBac.Location = new System.Drawing.Point(12, 125);
            this.lblBac.Name = "lblBac";
            this.lblBac.Size = new System.Drawing.Size(43, 23);
            this.lblBac.TabIndex = 3;
            this.lblBac.Text = "Bậc:";
            // 
            // dgridLichSu
            // 
            this.dgridLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridLichSu.Location = new System.Drawing.Point(12, 166);
            this.dgridLichSu.Name = "dgridLichSu";
            this.dgridLichSu.RowHeadersWidth = 51;
            this.dgridLichSu.RowTemplate.Height = 29;
            this.dgridLichSu.Size = new System.Drawing.Size(495, 272);
            this.dgridLichSu.TabIndex = 4;
            // 
            // btnDatetime
            // 
            this.btnDatetime.FlatAppearance.BorderSize = 0;
            this.btnDatetime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatetime.Image = ((System.Drawing.Image)(resources.GetObject("btnDatetime.Image")));
            this.btnDatetime.Location = new System.Drawing.Point(374, 124);
            this.btnDatetime.Name = "btnDatetime";
            this.btnDatetime.Size = new System.Drawing.Size(33, 36);
            this.btnDatetime.TabIndex = 5;
            this.btnDatetime.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(413, 124);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(33, 36);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(452, 124);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(33, 36);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // fLichSuDungDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 450);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDatetime);
            this.Controls.Add(this.dgridLichSu);
            this.Controls.Add(this.lblBac);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.panel1);
            this.Name = "fLichSuDungDiem";
            this.Text = "fLichSuDungDiem";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblBac;
        private System.Windows.Forms.DataGridView dgridLichSu;
        private System.Windows.Forms.Button btnDatetime;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}