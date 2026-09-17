using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles
{
    partial class FrmAcessLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcessLogin));
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(168, 53);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '•';
            this.PasswordTextBox.Size = new System.Drawing.Size(170, 22);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(141, 139);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(96, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "&OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(245, 139);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(96, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "&Cancelar";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.Location = new System.Drawing.Point(168, 14);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(169, 22);
            this.UsernameTextBox.TabIndex = 0;
            // 
            // txtMac
            // 
            this.txtMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMac.Location = new System.Drawing.Point(168, 92);
            this.txtMac.Name = "txtMac";
            this.txtMac.ReadOnly = true;
            this.txtMac.Size = new System.Drawing.Size(170, 22);
            this.txtMac.TabIndex = 3;
            this.txtMac.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(138, 127);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(200, 2);
            this.Label2.TabIndex = 22;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Image = global::PangyaSuiteFiles.Properties.Resources.computer_key;
            this.PictureBox3.Location = new System.Drawing.Point(135, 86);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(32, 32);
            this.PictureBox3.TabIndex = 4;
            this.PictureBox3.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = global::PangyaSuiteFiles.Properties.Resources.key;
            this.PictureBox2.Location = new System.Drawing.Point(135, 47);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(32, 32);
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::PangyaSuiteFiles.Properties.Resources.user;
            this.PictureBox1.Location = new System.Drawing.Point(135, 8);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(32, 32);
            this.PictureBox1.TabIndex = 4;
            this.PictureBox1.TabStop = false;
            // 
            // PictureBox4
            // 
            this.PictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox4.ErrorImage = global::PangyaSuiteFiles.Properties.Resources.Ch_cadie;
            this.PictureBox4.Image = global::PangyaSuiteFiles.Properties.Resources.pangya2;
            this.PictureBox4.Location = new System.Drawing.Point(0, 0);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(351, 173);
            this.PictureBox4.TabIndex = 4;
            this.PictureBox4.TabStop = false;
            // 
            // FrmAcessLogin
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(351, 173);
            this.ControlBox = false;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PictureBox4);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcessLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autenticação de Usuário";
            this.Load += new System.EventHandler(this.FrmAcessLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        [AccessedThroughProperty("UsernameTextBox")]
        private TextBox UsernameTextBox;

        [AccessedThroughProperty("PasswordTextBox")]
        private TextBox PasswordTextBox;

        [AccessedThroughProperty("OK")]
        private Button OK;

        [AccessedThroughProperty("Cancel")]
        private Button Cancel;

        [AccessedThroughProperty("txtMac")]
        private TextBox txtMac;

        [AccessedThroughProperty("PictureBox1")]
        private PictureBox PictureBox1;

        [AccessedThroughProperty("PictureBox2")]
        private PictureBox PictureBox2;

        [AccessedThroughProperty("PictureBox3")]
        private PictureBox PictureBox3;

        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        [AccessedThroughProperty("Label2")]
        private Label Label2;

        public bool flag;

        private int countErro;

        public string chave;
        #endregion
    }
}