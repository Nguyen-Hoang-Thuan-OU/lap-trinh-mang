namespace ControlClientForm
{
    partial class BTH05_ControlClientForm
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
            this.labelIP = new System.Windows.Forms.Label();
            this.textBoxHienThi = new System.Windows.Forms.TextBox();
            this.checkBoxEpBuoc = new System.Windows.Forms.CheckBox();
            this.buttonKetNoi = new System.Windows.Forms.Button();
            this.buttonTatNguon = new System.Windows.Forms.Button();
            this.buttonKhoiDongLai = new System.Windows.Forms.Button();
            this.buttonKhoaMay = new System.Windows.Forms.Button();
            this.buttonDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelIP.Location = new System.Drawing.Point(12, 9);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(60, 60);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP";
            this.labelIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHienThi
            // 
            this.textBoxHienThi.Location = new System.Drawing.Point(78, 9);
            this.textBoxHienThi.Multiline = true;
            this.textBoxHienThi.Name = "textBoxHienThi";
            this.textBoxHienThi.Size = new System.Drawing.Size(322, 60);
            this.textBoxHienThi.TabIndex = 1;
            // 
            // checkBoxEpBuoc
            // 
            this.checkBoxEpBuoc.AutoSize = true;
            this.checkBoxEpBuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEpBuoc.ForeColor = System.Drawing.Color.OrangeRed;
            this.checkBoxEpBuoc.Location = new System.Drawing.Point(406, 9);
            this.checkBoxEpBuoc.Name = "checkBoxEpBuoc";
            this.checkBoxEpBuoc.Size = new System.Drawing.Size(92, 22);
            this.checkBoxEpBuoc.TabIndex = 2;
            this.checkBoxEpBuoc.Text = "Ép buộc";
            this.checkBoxEpBuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEpBuoc.UseVisualStyleBackColor = true;
            //this.checkBoxEpBuoc.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonKetNoi
            // 
            this.buttonKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKetNoi.ForeColor = System.Drawing.Color.Green;
            this.buttonKetNoi.Location = new System.Drawing.Point(406, 39);
            this.buttonKetNoi.Name = "buttonKetNoi";
            this.buttonKetNoi.Size = new System.Drawing.Size(107, 30);
            this.buttonKetNoi.TabIndex = 3;
            this.buttonKetNoi.Text = "Kết nối";
            this.buttonKetNoi.UseVisualStyleBackColor = true;
            this.buttonKetNoi.Click += new System.EventHandler(this.buttonKetNoi_Click);
            // 
            // buttonTatNguon
            // 
            this.buttonTatNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTatNguon.ForeColor = System.Drawing.Color.Red;
            this.buttonTatNguon.Location = new System.Drawing.Point(19, 98);
            this.buttonTatNguon.Name = "buttonTatNguon";
            this.buttonTatNguon.Size = new System.Drawing.Size(101, 88);
            this.buttonTatNguon.TabIndex = 4;
            this.buttonTatNguon.Text = "Tắt nguồn";
            this.buttonTatNguon.UseVisualStyleBackColor = true;
            this.buttonTatNguon.Click += new System.EventHandler(this.buttonTatNguon_Click);
            // 
            // buttonKhoiDongLai
            // 
            this.buttonKhoiDongLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhoiDongLai.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonKhoiDongLai.Location = new System.Drawing.Point(148, 98);
            this.buttonKhoiDongLai.Name = "buttonKhoiDongLai";
            this.buttonKhoiDongLai.Size = new System.Drawing.Size(101, 88);
            this.buttonKhoiDongLai.TabIndex = 5;
            this.buttonKhoiDongLai.Text = "Khởi động lại";
            this.buttonKhoiDongLai.UseVisualStyleBackColor = true;
            this.buttonKhoiDongLai.Click += new System.EventHandler(this.buttonKhoiDongLai_Click);
            // 
            // buttonKhoaMay
            // 
            this.buttonKhoaMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhoaMay.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonKhoaMay.Location = new System.Drawing.Point(281, 98);
            this.buttonKhoaMay.Name = "buttonKhoaMay";
            this.buttonKhoaMay.Size = new System.Drawing.Size(101, 88);
            this.buttonKhoaMay.TabIndex = 5;
            this.buttonKhoaMay.Text = "Khoá máy";
            this.buttonKhoaMay.UseVisualStyleBackColor = true;
            this.buttonKhoaMay.Click += new System.EventHandler(this.buttonKhoaMay_Click);
            // 
            // buttonDangXuat
            // 
            this.buttonDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangXuat.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonDangXuat.Location = new System.Drawing.Point(412, 98);
            this.buttonDangXuat.Name = "buttonDangXuat";
            this.buttonDangXuat.Size = new System.Drawing.Size(101, 88);
            this.buttonDangXuat.TabIndex = 5;
            this.buttonDangXuat.Text = "Đăng xuất";
            this.buttonDangXuat.UseVisualStyleBackColor = true;
            this.buttonDangXuat.Click += new System.EventHandler(this.buttonDangXuat_Click);
            // 
            // BTH04_ControlClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 244);
            this.Controls.Add(this.buttonDangXuat);
            this.Controls.Add(this.buttonKhoaMay);
            this.Controls.Add(this.buttonKhoiDongLai);
            this.Controls.Add(this.buttonTatNguon);
            this.Controls.Add(this.buttonKetNoi);
            this.Controls.Add(this.checkBoxEpBuoc);
            this.Controls.Add(this.textBoxHienThi);
            this.Controls.Add(this.labelIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BTH04_ControlClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textBoxHienThi;
        private System.Windows.Forms.CheckBox checkBoxEpBuoc;
        private System.Windows.Forms.Button buttonKetNoi;
        private System.Windows.Forms.Button buttonTatNguon;
        private System.Windows.Forms.Button buttonKhoiDongLai;
        private System.Windows.Forms.Button buttonKhoaMay;
        private System.Windows.Forms.Button buttonDangXuat;
    }
}

