namespace ControlServerForm
{
    partial class BTH05_ControlServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTH05_ControlServerForm));
            this.buttonLangNghe = new System.Windows.Forms.Button();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLangNghe
            // 
            this.buttonLangNghe.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonLangNghe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLangNghe.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.buttonLangNghe, "buttonLangNghe");
            this.buttonLangNghe.Name = "buttonLangNghe";
            this.buttonLangNghe.UseVisualStyleBackColor = false;
            this.buttonLangNghe.Click += new System.EventHandler(this.buttonLangNghe_Click);
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.BackColor = System.Drawing.Color.Ivory;
            resources.ApplyResources(this.labelTrangThai, "labelTrangThai");
            this.labelTrangThai.Name = "labelTrangThai";
            // 
            // BTH04_ControlServerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTrangThai);
            this.Controls.Add(this.buttonLangNghe);
            this.ForeColor = System.Drawing.Color.Green;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BTH04_ControlServerForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLangNghe;
        private System.Windows.Forms.Label labelTrangThai;
    }
}

