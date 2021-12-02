
namespace _3_GUI_PresentaionLayers
{
    partial class FrmInfoBill
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_info = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_info)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrid_info);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Chi Tiết Hóa Đơn ";
            // 
            // dgrid_info
            // 
            this.dgrid_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_info.Location = new System.Drawing.Point(3, 23);
            this.dgrid_info.Name = "dgrid_info";
            this.dgrid_info.RowHeadersWidth = 51;
            this.dgrid_info.RowTemplate.Height = 29;
            this.dgrid_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_info.Size = new System.Drawing.Size(1252, 281);
            this.dgrid_info.TabIndex = 0;
            this.dgrid_info.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_info_CellContentClick);
            // 
            // FrmInfoBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1258, 479);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Name = "FrmInfoBill";
            this.Text = "FrmInfoBill";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInfoBill_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInfoBill_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgrid_info;
    }
}