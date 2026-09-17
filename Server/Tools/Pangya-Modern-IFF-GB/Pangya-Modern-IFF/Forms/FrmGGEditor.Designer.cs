namespace PangyaSuiteFiles.Forms
{
    partial class FrmGGEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGGEditor));
            this.BtnOpenIFF = new System.Windows.Forms.Button();
            this.BtnDecryptIFF = new System.Windows.Forms.Button();
            this.BtnEncryptIFF = new System.Windows.Forms.Button();
            this.BtnSaveIFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOpenIFF
            // 
            this.BtnOpenIFF.Location = new System.Drawing.Point(12, 108);
            this.BtnOpenIFF.Name = "BtnOpenIFF";
            this.BtnOpenIFF.Size = new System.Drawing.Size(92, 42);
            this.BtnOpenIFF.TabIndex = 0;
            this.BtnOpenIFF.Text = "Open.ini";
            this.BtnOpenIFF.UseVisualStyleBackColor = true;
            this.BtnOpenIFF.Click += new System.EventHandler(this.BtnOpenIFF_Click);
            // 
            // BtnDecryptIFF
            // 
            this.BtnDecryptIFF.Location = new System.Drawing.Point(128, 26);
            this.BtnDecryptIFF.Name = "BtnDecryptIFF";
            this.BtnDecryptIFF.Size = new System.Drawing.Size(92, 42);
            this.BtnDecryptIFF.TabIndex = 1;
            this.BtnDecryptIFF.Text = "Pangya.ini Decrypt";
            this.BtnDecryptIFF.UseVisualStyleBackColor = true;
            this.BtnDecryptIFF.Click += new System.EventHandler(this.BtnEncryptDecrypt_Click);
            // 
            // BtnEncryptIFF
            // 
            this.BtnEncryptIFF.Enabled = false;
            this.BtnEncryptIFF.Location = new System.Drawing.Point(12, 26);
            this.BtnEncryptIFF.Name = "BtnEncryptIFF";
            this.BtnEncryptIFF.Size = new System.Drawing.Size(92, 42);
            this.BtnEncryptIFF.TabIndex = 2;
            this.BtnEncryptIFF.Text = "Pangya.ini Encrypt";
            this.BtnEncryptIFF.UseVisualStyleBackColor = true;
            this.BtnEncryptIFF.Click += new System.EventHandler(this.BtnEncryptDecrypt_Click);
            // 
            // BtnSaveIFF
            // 
            this.BtnSaveIFF.Location = new System.Drawing.Point(128, 108);
            this.BtnSaveIFF.Name = "BtnSaveIFF";
            this.BtnSaveIFF.Size = new System.Drawing.Size(92, 42);
            this.BtnSaveIFF.TabIndex = 3;
            this.BtnSaveIFF.Text = "Save.ini";
            this.BtnSaveIFF.UseVisualStyleBackColor = true;
            this.BtnSaveIFF.Click += new System.EventHandler(this.BtnSaveIFF_Click);
            // 
            // FrmGGEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 172);
            this.Controls.Add(this.BtnSaveIFF);
            this.Controls.Add(this.BtnEncryptIFF);
            this.Controls.Add(this.BtnDecryptIFF);
            this.Controls.Add(this.BtnOpenIFF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGGEditor";
            this.Text = "Game Guard File Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenIFF;
        private System.Windows.Forms.Button BtnDecryptIFF;
        private System.Windows.Forms.Button BtnEncryptIFF;
        private System.Windows.Forms.Button BtnSaveIFF;
    }
}