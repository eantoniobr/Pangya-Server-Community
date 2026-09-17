using Pangya_Modern_Editor.Properties;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnIFFEditor = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.BtnLangEditor = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Hey Estou Aqui, Okay!?";
            this.notifyIcon1.BalloonTipTitle = "App Run";
            this.notifyIcon1.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.notifyIcon1.Text = "!Pang Suite Tools";
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(22, 193);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Creator: LuisMK";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.BtnAbout);
            this.groupBox4.Controls.Add(this.BtnIFFEditor);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.BtnLangEditor);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(12, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(102, 189);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(10, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 22);
            this.button2.TabIndex = 16;
            this.button2.Text = "&Exit";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.ForeColor = System.Drawing.Color.Black;
            this.BtnAbout.Location = new System.Drawing.Point(10, 130);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(84, 22);
            this.BtnAbout.TabIndex = 15;
            this.BtnAbout.Text = "&About App";
            this.BtnAbout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnIFFEditor
            // 
            this.BtnIFFEditor.ForeColor = System.Drawing.Color.Black;
            this.BtnIFFEditor.Location = new System.Drawing.Point(10, 103);
            this.BtnIFFEditor.Name = "BtnIFFEditor";
            this.BtnIFFEditor.Size = new System.Drawing.Size(84, 22);
            this.BtnIFFEditor.TabIndex = 13;
            this.BtnIFFEditor.Text = "Pangya_JP.iff";
            this.BtnIFFEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnIFFEditor.UseVisualStyleBackColor = true;
            this.BtnIFFEditor.Click += new System.EventHandler(this.BtnIFFEditor_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(10, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 25);
            this.button5.TabIndex = 11;
            this.button5.Text = "ShitList.bin";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnBinEditor);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(10, 41);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 25);
            this.button6.TabIndex = 10;
            this.button6.Text = "Caddie.Talk";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BtnTalkEditor);
            // 
            // BtnLangEditor
            // 
            this.BtnLangEditor.ForeColor = System.Drawing.Color.Black;
            this.BtnLangEditor.Location = new System.Drawing.Point(10, 14);
            this.BtnLangEditor.Name = "BtnLangEditor";
            this.BtnLangEditor.Size = new System.Drawing.Size(84, 22);
            this.BtnLangEditor.TabIndex = 8;
            this.BtnLangEditor.Text = "Language.dat";
            this.BtnLangEditor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnLangEditor.UseVisualStyleBackColor = true;
            this.BtnLangEditor.Click += new System.EventHandler(this.BtnThailandEditor_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(126, 211);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.linkLabel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.StartupWindow_Load);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private NotifyIcon notifyIcon1;
        private LinkLabel linkLabel1;
        private GroupBox groupBox4;
        private Button button5;
        private Button button6;
        private Button BtnLangEditor;
        private Button BtnIFFEditor;
        private Button button2;
        private Button BtnAbout;
        #endregion
    }
}