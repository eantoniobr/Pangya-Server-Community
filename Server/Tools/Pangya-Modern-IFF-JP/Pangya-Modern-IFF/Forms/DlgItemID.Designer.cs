using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms
{
    partial class DlgItemID
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
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.cbPersonagem = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.cbIffTyp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbIffTyp);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtResultado);
            this.GroupBox1.Controls.Add(this.cbTipo);
            this.GroupBox1.Controls.Add(this.txtSerial);
            this.GroupBox1.Controls.Add(this.txtPos);
            this.GroupBox1.Controls.Add(this.cbPersonagem);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Location = new System.Drawing.Point(2, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(212, 194);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(72, 161);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(134, 20);
            this.txtResultado.TabIndex = 1;
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "TOP",
            "BOTTOM",
            "HEAD",
            "CLOVE",
            "SHOES",
            "ACCESSORY_OR_BASE",
            "SUB_LEG",
            "UNKNOWN",
            "Create SD",
            "Copy SD"});
            this.cbTipo.Location = new System.Drawing.Point(72, 48);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(134, 21);
            this.cbTipo.TabIndex = 12;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(72, 125);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(134, 20);
            this.txtSerial.TabIndex = 13;
            this.txtSerial.Text = "0";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(72, 99);
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
            "Nuri",
            "Hana",
            "Arthur",
            "Cecilia",
            "Max",
            "Kooh",
            "Arin",
            "Kaz",
            "Lucia",
            "Nell",
            "Spika",
            "Nuri_R",
            "Hana_R",
            "Azer_R",
            "Cecilia_R"});
            this.cbPersonagem.Location = new System.Drawing.Point(72, 17);
            this.cbPersonagem.Name = "cbPersonagem";
            this.cbPersonagem.Size = new System.Drawing.Size(134, 21);
            this.cbPersonagem.TabIndex = 12;
            this.cbPersonagem.SelectedIndexChanged += new System.EventHandler(this.cbPersonagem_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 164);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Resultado";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 128);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(58, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Part Serial:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 102);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(50, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Part Pos:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 51);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Part Type:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(5, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 13);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Character:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(132, 54);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(28, 13);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Icon";
            // 
            // btnGerar
            // 
            this.btnGerar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnGerar.Location = new System.Drawing.Point(127, 202);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(87, 30);
            this.btnGerar.TabIndex = 1;
            this.btnGerar.Text = "Gen. New Index";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // cbIffTyp
            // 
            this.cbIffTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIffTyp.FormattingEnabled = true;
            this.cbIffTyp.Items.AddRange(new object[] {
            "UNKNOWN",
            "CHARACTER",
            "PART",
            "CLUB",
            "CLUBSET",
            "BALL",
            "ITEM",
            "CADDIE",
            "CAD_ITEM",
            "SET_ITEM",
            "COURSE",
            "MATCH",
            "UNKNOWN_12",
            "ENCHANT",
            "SKIN",
            "HAIR_STYLE",
            "MASCOT",
            "UNKNOWN_17",
            "FURNITURE",
            "ACHIEVEMENT",
            "UNKNOWN_20",
            "UNKNOWN_21",
            "UNKNOWN_22",
            "UNKNOWN_23",
            "UNKNOWN_24",
            "UNKNOWN_25",
            "UNKNOWN_26",
            "COUNTER_ITEM",
            "AUX_PART",
            "QUEST_STUFF",
            "QUEST_ITEM",
            "CARD"});
            this.cbIffTyp.Location = new System.Drawing.Point(72, 74);
            this.cbIffTyp.Name = "cbIffTyp";
            this.cbIffTyp.Size = new System.Drawing.Size(134, 21);
            this.cbIffTyp.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "IFF Group:";
            // 
            // DlgPartID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 238);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.GroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgPartID";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Generation Index";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;

        [AccessedThroughProperty("cbTipo")]
        private ComboBox cbTipo;

        [AccessedThroughProperty("txtPos")]
        private TextBox txtPos;

        [AccessedThroughProperty("cbPersonagem")]
        private ComboBox cbPersonagem;

        [AccessedThroughProperty("Label2")]
        private Label Label2;

        [AccessedThroughProperty("Label1")]
        private Label Label1;

        [AccessedThroughProperty("Label5")]
        private Label Label5;

        [AccessedThroughProperty("Label7")]
        private Label Label7;

        [AccessedThroughProperty("txtResultado")]
        private TextBox txtResultado;

        [AccessedThroughProperty("Label4")]
        private Label Label4;

        [AccessedThroughProperty("btnGerar")]
        private Button btnGerar;

        [AccessedThroughProperty("txtSerial")]
        private TextBox txtSerial;

        [AccessedThroughProperty("Label6")]
        private Label Label6;
        #endregion

        private ComboBox cbIffTyp;
        private Label label3;
    }
}