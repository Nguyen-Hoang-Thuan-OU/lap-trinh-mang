namespace ICMP_PING
{
    partial class Form1
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
            this.label6 = new System.Windows.Forms.Label();
            this.lvThongke = new System.Windows.Forms.ListView();
            this.chbxContinous = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumpacket = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvDetail = new System.Windows.Forms.ListView();
            this.lvResult = new System.Windows.Forms.ListView();
            this.countsend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btCheck = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "( Nhấn ESC để dừng ! )";
            // 
            // lvThongke
            // 
            this.lvThongke.BackColor = System.Drawing.SystemColors.MenuText;
            this.lvThongke.ForeColor = System.Drawing.SystemColors.Info;
            this.lvThongke.Location = new System.Drawing.Point(399, 196);
            this.lvThongke.Name = "lvThongke";
            this.lvThongke.Size = new System.Drawing.Size(313, 66);
            this.lvThongke.TabIndex = 23;
            this.lvThongke.UseCompatibleStateImageBehavior = false;
            this.lvThongke.View = System.Windows.Forms.View.List;
            // 
            // chbxContinous
            // 
            this.chbxContinous.AutoSize = true;
            this.chbxContinous.Location = new System.Drawing.Point(136, 57);
            this.chbxContinous.Name = "chbxContinous";
            this.chbxContinous.Size = new System.Drawing.Size(15, 14);
            this.chbxContinous.TabIndex = 14;
            this.chbxContinous.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chbxContinous);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumpacket);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Location = new System.Drawing.Point(399, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 77);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Gửi liên tục(/t)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số gói tin(/n)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(152, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "bytes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kích thước tin (/l)";
            // 
            // txtNumpacket
            // 
            this.txtNumpacket.Location = new System.Drawing.Point(255, 24);
            this.txtNumpacket.Name = "txtNumpacket";
            this.txtNumpacket.Size = new System.Drawing.Size(54, 20);
            this.txtNumpacket.TabIndex = 10;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(96, 24);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(54, 20);
            this.txtSize.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Chi tiết: ";
            // 
            // lvDetail
            // 
            this.lvDetail.BackColor = System.Drawing.SystemColors.MenuText;
            this.lvDetail.ForeColor = System.Drawing.SystemColors.Info;
            this.lvDetail.Location = new System.Drawing.Point(399, 66);
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(314, 124);
            this.lvDetail.TabIndex = 20;
            this.lvDetail.UseCompatibleStateImageBehavior = false;
            this.lvDetail.View = System.Windows.Forms.View.Tile;
            // 
            // lvResult
            // 
            this.lvResult.BackColor = System.Drawing.SystemColors.MenuText;
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.countsend,
            this.Address,
            this.Result});
            this.lvResult.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lvResult.Location = new System.Drawing.Point(20, 66);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(362, 197);
            this.lvResult.TabIndex = 16;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // countsend
            // 
            this.countsend.Text = "Lần gửi";
            this.countsend.Width = 69;
            // 
            // Address
            // 
            this.Address.Text = "Địa chỉ";
            this.Address.Width = 146;
            // 
            // Result
            // 
            this.Result.Text = "Kết quả";
            this.Result.Width = 212;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nhập IP hoặc Hostname: ";
            // 
            // btCheck
            // 
            this.btCheck.Location = new System.Drawing.Point(223, 310);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(78, 41);
            this.btCheck.TabIndex = 15;
            this.btCheck.Text = "Ping";
            this.btCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(108, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(502, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "_____PING IP OR HOSTNAME_____";
            // 
            // btReset
            // 
            this.btReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btReset.Location = new System.Drawing.Point(307, 310);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(54, 41);
            this.btReset.TabIndex = 18;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Kết quả: ";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(20, 310);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(197, 41);
            this.txtInput.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 361);
            this.Controls.Add(this.lvThongke);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvDetail);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "PING PROGRAM";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvThongke;
        private System.Windows.Forms.CheckBox chbxContinous;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumpacket;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.ColumnHeader countsend;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
    }
}

