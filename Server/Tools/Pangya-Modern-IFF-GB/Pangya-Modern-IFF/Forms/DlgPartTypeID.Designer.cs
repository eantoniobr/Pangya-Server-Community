using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class DlgPartTypeID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPartTypeID));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.cbPersonagem = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtResultado);
            this.GroupBox1.Controls.Add(this.cbTipo);
            this.GroupBox1.Controls.Add(this.txtSerial);
            this.GroupBox1.Controls.Add(this.txtGrupo);
            this.GroupBox1.Controls.Add(this.txtPos);
            this.GroupBox1.Controls.Add(this.cbPersonagem);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Location = new System.Drawing.Point(12, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(231, 177);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(81, 149);
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
            "Parte Superior",
            "Parte Inferior",
            "Chapeu",
            "Luva",
            "Sapato",
            "Acessório",
            "Nova Self Design",
            "Copia Self Design"});
            this.cbTipo.Location = new System.Drawing.Point(81, 48);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(134, 21);
            this.cbTipo.TabIndex = 12;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(81, 126);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(134, 20);
            this.txtSerial.TabIndex = 13;
            this.txtSerial.Text = "0";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(81, 102);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(134, 20);
            this.txtGrupo.TabIndex = 13;
            this.txtGrupo.Text = "2";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(81, 77);
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
            "All",
            "Nuri",
            "Hana",
            "Arthur",
            "Cesillia",
            "Max",
            "Kooh",
            "Arin",
            "Kaz",
            "Lucia",
            "Nell",
            "Spika",
            "Nuri_R",
            "Hana_R",
            "Cesillia_R"});
            this.cbPersonagem.Location = new System.Drawing.Point(81, 17);
            this.cbPersonagem.Name = "cbPersonagem";
            this.cbPersonagem.Size = new System.Drawing.Size(134, 21);
            this.cbPersonagem.TabIndex = 12;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 154);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Resultado";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(12, 129);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(33, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Serial";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 105);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Grupo";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 80);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(25, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Pos";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 51);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Tipo";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(66, 13);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Personagem";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(141, 54);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(34, 13);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Icone";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(168, 192);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 1;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // DlgPartTypeID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 222);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgPartTypeID";
            this.Text = "Gerar Typeid";
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

        [AccessedThroughProperty("txtGrupo")]
        private TextBox txtGrupo;

        [AccessedThroughProperty("Label4")]
        private Label Label4;

        [AccessedThroughProperty("Label3")]
        private Label Label3;

        [AccessedThroughProperty("btnGerar")]
        private Button btnGerar;

        [AccessedThroughProperty("txtSerial")]
        private TextBox txtSerial;

        [AccessedThroughProperty("Label6")]
        private Label Label6;
        #endregion
    }
}