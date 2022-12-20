namespace ThreadTCPChatForm
{
    partial class ThreadTCPChatForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxNoiDungTinNhan = new System.Windows.Forms.TextBox();
            this.buttonGui = new System.Windows.Forms.Button();
            this.buttonLangNghe = new System.Windows.Forms.Button();
            this.buttonKetNoi = new System.Windows.Forms.Button();
            this.listBoxKetQua = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(240, 58);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Nhập thông điệp";
            // 
            // textBoxNoiDungTinNhan
            // 
            this.textBoxNoiDungTinNhan.Location = new System.Drawing.Point(17, 70);
            this.textBoxNoiDungTinNhan.Multiline = true;
            this.textBoxNoiDungTinNhan.Name = "textBoxNoiDungTinNhan";
            this.textBoxNoiDungTinNhan.Size = new System.Drawing.Size(381, 55);
            this.textBoxNoiDungTinNhan.TabIndex = 1;
            // 
            // buttonGui
            // 
            this.buttonGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGui.Location = new System.Drawing.Point(404, 70);
            this.buttonGui.Name = "buttonGui";
            this.buttonGui.Size = new System.Drawing.Size(127, 55);
            this.buttonGui.TabIndex = 2;
            this.buttonGui.Text = "Gửi";
            this.buttonGui.UseVisualStyleBackColor = true;
            this.buttonGui.Click += new System.EventHandler(this.buttonGui_Click);
            // 
            // buttonLangNghe
            // 
            this.buttonLangNghe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLangNghe.Location = new System.Drawing.Point(537, 9);
            this.buttonLangNghe.Name = "buttonLangNghe";
            this.buttonLangNghe.Size = new System.Drawing.Size(127, 55);
            this.buttonLangNghe.TabIndex = 2;
            this.buttonLangNghe.Text = "Lắng nghe";
            this.buttonLangNghe.UseVisualStyleBackColor = true;
            this.buttonLangNghe.Click += new System.EventHandler(this.buttonLangNghe_Click);
            // 
            // buttonKetNoi
            // 
            this.buttonKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKetNoi.Location = new System.Drawing.Point(537, 70);
            this.buttonKetNoi.Name = "buttonKetNoi";
            this.buttonKetNoi.Size = new System.Drawing.Size(127, 55);
            this.buttonKetNoi.TabIndex = 2;
            this.buttonKetNoi.Text = "Kết nối";
            this.buttonKetNoi.UseVisualStyleBackColor = true;
            this.buttonKetNoi.Click += new System.EventHandler(this.buttonKetNoi_Click);
            // 
            // listBoxKetQua
            // 
            this.listBoxKetQua.FormattingEnabled = true;
            this.listBoxKetQua.ItemHeight = 16;
            this.listBoxKetQua.Location = new System.Drawing.Point(17, 144);
            this.listBoxKetQua.Name = "listBoxKetQua";
            this.listBoxKetQua.Size = new System.Drawing.Size(647, 244);
            this.listBoxKetQua.TabIndex = 3;
            // 
            // ThreadTCPChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 426);
            this.Controls.Add(this.listBoxKetQua);
            this.Controls.Add(this.buttonKetNoi);
            this.Controls.Add(this.buttonLangNghe);
            this.Controls.Add(this.buttonGui);
            this.Controls.Add(this.textBoxNoiDungTinNhan);
            this.Controls.Add(this.labelMessage);
            this.Name = "ThreadTCPChatForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxNoiDungTinNhan;
        private System.Windows.Forms.Button buttonGui;
        private System.Windows.Forms.Button buttonLangNghe;
        private System.Windows.Forms.Button buttonKetNoi;
        private System.Windows.Forms.ListBox listBoxKetQua;
    }
}

