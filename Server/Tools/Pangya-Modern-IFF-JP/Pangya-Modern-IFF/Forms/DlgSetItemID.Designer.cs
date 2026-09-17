using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms
{
    partial class DlgSetItemID
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.cbPersonagem = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtResultado);
            this.GroupBox1.Controls.Add(this.txtPos);
            this.GroupBox1.Controls.Add(this.cbPersonagem);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(2, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(212, 116);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(72, 78);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(134, 20);
            this.txtResultado.TabIndex = 1;
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(72, 45);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(134, 20);
            this.txtPos.TabIndex = 13;
            this.txtPos.Text = "0";
            // 
            // cbPersonagem
            // 
            this.cbPersonagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonagem.FormattingEnabled = true;
            this.cbPersonagem.Items.AddRange(new object[] {
            "UNKNOWN_0",
            "CHAR_SET",
            "CHAR_SET_NEW",
            "UNKNOWN_3",
            "CLUB_SET",
            "BALL",
            "CUSTOM/PACK",
            "UNKNOWN_7",
            "CARD",
            "AUXPART"});
            this.cbPersonagem.Location = new System.Drawing.Point(72, 17);
            this.cbPersonagem.Name = "cbPersonagem";
            this.cbPersonagem.Size = new System.Drawing.Size(134, 21);
            this.cbPersonagem.TabIndex = 12;
            this.cbPersonagem.SelectedIndexChanged += new System.EventHandler(this.cbPersonagem_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 81);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 13);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Resultado:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Increment:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(15, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 13);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Set Type:";
            // 
            // btnGerar
            // 
            this.btnGerar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnGerar.Location = new System.Drawing.Point(127, 124);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(87, 30);
            this.btnGerar.TabIndex = 1;
            this.btnGerar.Text = "Gen. New Index";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // DlgSetItemID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 163);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.GroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgSetItemID";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Generation Index";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;

        [AccessedThroughProperty("txtPos")]
        private TextBox txtPos;

        [AccessedThroughProperty("cbPersonagem")]
        private ComboBox cbPersonagem;

        [AccessedThroughProperty("Label2")]
        private Label Label2;

        [AccessedThroughProperty("Label5")]
        private Label Label5;

        [AccessedThroughProperty("txtResultado")]
        private TextBox txtResultado;

        [AccessedThroughProperty("Label4")]
        private Label Label4;

        [AccessedThroughProperty("btnGerar")]
        private Button btnGerar;
        #endregion
    }
}