using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class DlgMassaDesconto
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
            this.components = new System.ComponentModel.Container();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckDesconto = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.ckStatus = new System.Windows.Forms.CheckBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.GroupBox18 = new System.Windows.Forms.GroupBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.ckPreco = new System.Windows.Forms.CheckBox();
            this.cbPreco = new System.Windows.Forms.ComboBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label46 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.cbDesconto = new System.Windows.Forms.ComboBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTipo2 = new System.Windows.Forms.ComboBox();
            this.ckTipo = new System.Windows.Forms.CheckBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.cbMoeda2 = new System.Windows.Forms.ComboBox();
            this.ckMoeda = new System.Windows.Forms.CheckBox();
            this.cbMoeda = new System.Windows.Forms.ComboBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.cbMarcacao2 = new System.Windows.Forms.ComboBox();
            this.ckMarcacao = new System.Windows.Forms.CheckBox();
            this.cbMarcacao = new System.Windows.Forms.ComboBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.cbPersonagem2 = new System.Windows.Forms.ComboBox();
            this.ckPersonagem = new System.Windows.Forms.CheckBox();
            this.cbPersonagem = new System.Windows.Forms.ComboBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txxtVariavel = new System.Windows.Forms.TextBox();
            this.ckBase = new System.Windows.Forms.CheckBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.cbOperacao = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.StatusStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox18.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(3, 439);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(416, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 25;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(371, 17);
            this.ToolStripStatusLabel1.Text = "Caso nenhum critério seja selecionado, todos os itens serão alterados";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(30, 17);
            this.ToolStripStatusLabel2.Spring = true;
            // 
            // ckDesconto
            // 
            this.ckDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckDesconto.AutoSize = true;
            this.ckDesconto.Location = new System.Drawing.Point(371, 19);
            this.ckDesconto.Name = "ckDesconto";
            this.ckDesconto.Size = new System.Drawing.Size(15, 14);
            this.ckDesconto.TabIndex = 24;
            this.ToolTip1.SetToolTip(this.ckDesconto, "Ativar Condição");
            this.ckDesconto.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.btnLimpar);
            this.Panel1.Controls.Add(this.btnSimular);
            this.Panel1.Controls.Add(this.btnAplicar);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.GroupBox7);
            this.Panel1.Controls.Add(this.GroupBox18);
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Controls.Add(this.GroupBox3);
            this.Panel1.Controls.Add(this.GroupBox4);
            this.Panel1.Controls.Add(this.GroupBox6);
            this.Panel1.Controls.Add(this.GroupBox8);
            this.Panel1.Controls.Add(this.GroupBox5);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(416, 436);
            this.Panel1.TabIndex = 26;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = global::PangyaSuiteFiles.Properties.Resources.to_do_list;
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(109, 387);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(94, 41);
            this.btnLimpar.TabIndex = 24;
            this.btnLimpar.TabStop = false;
            this.btnLimpar.Text = "&Limpar ";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSimular
            // 
            this.btnSimular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimular.Image = global::PangyaSuiteFiles.Properties.Resources.to_do_list_cheked_all;
            this.btnSimular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimular.Location = new System.Drawing.Point(9, 387);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(94, 41);
            this.btnSimular.TabIndex = 24;
            this.btnSimular.TabStop = false;
            this.btnSimular.Text = "&Simular";
            this.btnSimular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Image = global::PangyaSuiteFiles.Properties.Resources.accept;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(288, 387);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(118, 41);
            this.btnAplicar.TabIndex = 24;
            this.btnAplicar.TabStop = false;
            this.btnAplicar.Text = "&Aplicar";
            this.btnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.DimGray;
            this.Label4.Location = new System.Drawing.Point(4, 74);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 19);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Caso:";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label3.Location = new System.Drawing.Point(7, 98);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(398, 2);
            this.Label3.TabIndex = 21;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.DimGray;
            this.Label9.Location = new System.Drawing.Point(4, 2);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(179, 19);
            this.Label9.TabIndex = 22;
            this.Label9.Text = "Alterar desconto para:";
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label8.Location = new System.Drawing.Point(7, 23);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(398, 2);
            this.Label8.TabIndex = 21;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox7.Controls.Add(this.ckAtivo);
            this.GroupBox7.Controls.Add(this.ckStatus);
            this.GroupBox7.Controls.Add(this.cbStatus);
            this.GroupBox7.Controls.Add(this.Label18);
            this.GroupBox7.Controls.Add(this.Label19);
            this.GroupBox7.Location = new System.Drawing.Point(9, 96);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(396, 45);
            this.GroupBox7.TabIndex = 23;
            this.GroupBox7.TabStop = false;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(221, 17);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(58, 17);
            this.ckAtivo.TabIndex = 25;
            this.ckAtivo.Text = "ATIVO";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // ckStatus
            // 
            this.ckStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckStatus.AutoSize = true;
            this.ckStatus.Location = new System.Drawing.Point(371, 19);
            this.ckStatus.Name = "ckStatus";
            this.ckStatus.Size = new System.Drawing.Size(15, 14);
            this.ckStatus.TabIndex = 24;
            this.ckStatus.UseVisualStyleBackColor = true;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.ItemHeight = 13;
            this.cbStatus.Items.AddRange(new object[] {
            "Igual",
            "Diferente"});
            this.cbStatus.Location = new System.Drawing.Point(85, 14);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(111, 21);
            this.cbStatus.TabIndex = 2;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(202, 18);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(13, 13);
            this.Label18.TabIndex = 0;
            this.Label18.Text = "à";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(8, 18);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(52, 13);
            this.Label19.TabIndex = 0;
            this.Label19.Text = "Status for";
            // 
            // GroupBox18
            // 
            this.GroupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox18.Controls.Add(this.txtPreco);
            this.GroupBox18.Controls.Add(this.ckPreco);
            this.GroupBox18.Controls.Add(this.cbPreco);
            this.GroupBox18.Controls.Add(this.Label45);
            this.GroupBox18.Controls.Add(this.Label46);
            this.GroupBox18.Location = new System.Drawing.Point(8, 136);
            this.GroupBox18.Name = "GroupBox18";
            this.GroupBox18.Size = new System.Drawing.Size(396, 45);
            this.GroupBox18.TabIndex = 23;
            this.GroupBox18.TabStop = false;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(222, 15);
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(131, 20);
            this.txtPreco.TabIndex = 25;
            this.txtPreco.Text = "0";
            // 
            // ckPreco
            // 
            this.ckPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPreco.AutoSize = true;
            this.ckPreco.Location = new System.Drawing.Point(371, 19);
            this.ckPreco.Name = "ckPreco";
            this.ckPreco.Size = new System.Drawing.Size(15, 14);
            this.ckPreco.TabIndex = 24;
            this.ckPreco.UseVisualStyleBackColor = true;
            // 
            // cbPreco
            // 
            this.cbPreco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPreco.FormattingEnabled = true;
            this.cbPreco.ItemHeight = 13;
            this.cbPreco.Items.AddRange(new object[] {
            "Maior",
            "Maior e igual",
            "Menor",
            "Menor e igual",
            "Igual",
            "Diferente"});
            this.cbPreco.Location = new System.Drawing.Point(85, 14);
            this.cbPreco.Name = "cbPreco";
            this.cbPreco.Size = new System.Drawing.Size(111, 21);
            this.cbPreco.TabIndex = 2;
            // 
            // Label45
            // 
            this.Label45.AutoSize = true;
            this.Label45.Location = new System.Drawing.Point(202, 18);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(13, 13);
            this.Label45.TabIndex = 0;
            this.Label45.Text = "à";
            // 
            // Label46
            // 
            this.Label46.AutoSize = true;
            this.Label46.Location = new System.Drawing.Point(8, 18);
            this.Label46.Name = "Label46";
            this.Label46.Size = new System.Drawing.Size(50, 13);
            this.Label46.TabIndex = 0;
            this.Label46.Text = "Preço for";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.txtDesconto);
            this.GroupBox2.Controls.Add(this.ckDesconto);
            this.GroupBox2.Controls.Add(this.cbDesconto);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Location = new System.Drawing.Point(8, 176);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(396, 45);
            this.GroupBox2.TabIndex = 23;
            this.GroupBox2.TabStop = false;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(222, 15);
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(131, 20);
            this.txtDesconto.TabIndex = 25;
            this.txtDesconto.Text = "0";
            // 
            // cbDesconto
            // 
            this.cbDesconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesconto.FormattingEnabled = true;
            this.cbDesconto.ItemHeight = 13;
            this.cbDesconto.Items.AddRange(new object[] {
            "Maior",
            "Maior e igual",
            "Menor",
            "Menor e igual",
            "Igual",
            "Diferente"});
            this.cbDesconto.Location = new System.Drawing.Point(85, 14);
            this.cbDesconto.Name = "cbDesconto";
            this.cbDesconto.Size = new System.Drawing.Size(111, 21);
            this.cbDesconto.TabIndex = 2;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(202, 18);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(13, 13);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "à";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(8, 18);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(68, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Desconto for";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.Controls.Add(this.cbTipo2);
            this.GroupBox3.Controls.Add(this.ckTipo);
            this.GroupBox3.Controls.Add(this.cbTipo);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Location = new System.Drawing.Point(8, 216);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(396, 45);
            this.GroupBox3.TabIndex = 23;
            this.GroupBox3.TabStop = false;
            // 
            // cbTipo2
            // 
            this.cbTipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo2.FormattingEnabled = true;
            this.cbTipo2.Items.AddRange(new object[] {
            "Parte Superior",
            "Parte Inferior",
            "Chapeu",
            "Luva",
            "Sapato",
            "Acessório",
            "Nova Self Design",
            "Copia Self Design"});
            this.cbTipo2.Location = new System.Drawing.Point(222, 14);
            this.cbTipo2.Name = "cbTipo2";
            this.cbTipo2.Size = new System.Drawing.Size(131, 21);
            this.cbTipo2.TabIndex = 25;
            // 
            // ckTipo
            // 
            this.ckTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckTipo.AutoSize = true;
            this.ckTipo.Location = new System.Drawing.Point(371, 19);
            this.ckTipo.Name = "ckTipo";
            this.ckTipo.Size = new System.Drawing.Size(15, 14);
            this.ckTipo.TabIndex = 24;
            this.ckTipo.UseVisualStyleBackColor = true;
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.ItemHeight = 13;
            this.cbTipo.Items.AddRange(new object[] {
            "Igual",
            "Diferente"});
            this.cbTipo.Location = new System.Drawing.Point(85, 14);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(111, 21);
            this.cbTipo.TabIndex = 2;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(202, 18);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(13, 13);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "à";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(8, 18);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(43, 13);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Tipo for";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox4.Controls.Add(this.cbMoeda2);
            this.GroupBox4.Controls.Add(this.ckMoeda);
            this.GroupBox4.Controls.Add(this.cbMoeda);
            this.GroupBox4.Controls.Add(this.Label15);
            this.GroupBox4.Controls.Add(this.Label7);
            this.GroupBox4.Location = new System.Drawing.Point(8, 256);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(396, 45);
            this.GroupBox4.TabIndex = 23;
            this.GroupBox4.TabStop = false;
            // 
            // cbMoeda2
            // 
            this.cbMoeda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoeda2.FormattingEnabled = true;
            this.cbMoeda2.Items.AddRange(new object[] {
            "Points",
            "Pangs",
            "Desativado"});
            this.cbMoeda2.Location = new System.Drawing.Point(222, 14);
            this.cbMoeda2.Name = "cbMoeda2";
            this.cbMoeda2.Size = new System.Drawing.Size(131, 21);
            this.cbMoeda2.TabIndex = 25;
            // 
            // ckMoeda
            // 
            this.ckMoeda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckMoeda.AutoSize = true;
            this.ckMoeda.Location = new System.Drawing.Point(371, 19);
            this.ckMoeda.Name = "ckMoeda";
            this.ckMoeda.Size = new System.Drawing.Size(15, 14);
            this.ckMoeda.TabIndex = 24;
            this.ckMoeda.UseVisualStyleBackColor = true;
            // 
            // cbMoeda
            // 
            this.cbMoeda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoeda.FormattingEnabled = true;
            this.cbMoeda.ItemHeight = 13;
            this.cbMoeda.Items.AddRange(new object[] {
            "Igual",
            "Diferente"});
            this.cbMoeda.Location = new System.Drawing.Point(85, 14);
            this.cbMoeda.Name = "cbMoeda";
            this.cbMoeda.Size = new System.Drawing.Size(111, 21);
            this.cbMoeda.TabIndex = 2;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(202, 18);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(13, 13);
            this.Label15.TabIndex = 0;
            this.Label15.Text = "à";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(8, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(55, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Moeda for";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox6.Controls.Add(this.cbMarcacao2);
            this.GroupBox6.Controls.Add(this.ckMarcacao);
            this.GroupBox6.Controls.Add(this.cbMarcacao);
            this.GroupBox6.Controls.Add(this.Label16);
            this.GroupBox6.Controls.Add(this.Label17);
            this.GroupBox6.Location = new System.Drawing.Point(8, 296);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(396, 45);
            this.GroupBox6.TabIndex = 23;
            this.GroupBox6.TabStop = false;
            // 
            // cbMarcacao2
            // 
            this.cbMarcacao2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcacao2.FormattingEnabled = true;
            this.cbMarcacao2.Items.AddRange(new object[] {
            "Item Normal",
            "Item Normal Presente",
            "Item Novo",
            "Item Novo Presente",
            "Item Quente",
            "Item Quente Presente",
            "Item Oculto"});
            this.cbMarcacao2.Location = new System.Drawing.Point(222, 14);
            this.cbMarcacao2.Name = "cbMarcacao2";
            this.cbMarcacao2.Size = new System.Drawing.Size(131, 21);
            this.cbMarcacao2.TabIndex = 25;
            // 
            // ckMarcacao
            // 
            this.ckMarcacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckMarcacao.AutoSize = true;
            this.ckMarcacao.Location = new System.Drawing.Point(371, 19);
            this.ckMarcacao.Name = "ckMarcacao";
            this.ckMarcacao.Size = new System.Drawing.Size(15, 14);
            this.ckMarcacao.TabIndex = 24;
            this.ckMarcacao.UseVisualStyleBackColor = true;
            // 
            // cbMarcacao
            // 
            this.cbMarcacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcacao.FormattingEnabled = true;
            this.cbMarcacao.ItemHeight = 13;
            this.cbMarcacao.Items.AddRange(new object[] {
            "Igual",
            "Diferente"});
            this.cbMarcacao.Location = new System.Drawing.Point(85, 14);
            this.cbMarcacao.Name = "cbMarcacao";
            this.cbMarcacao.Size = new System.Drawing.Size(111, 21);
            this.cbMarcacao.TabIndex = 2;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(202, 18);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(13, 13);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "à";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(8, 18);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(70, 13);
            this.Label17.TabIndex = 0;
            this.Label17.Text = "Marcação for";
            // 
            // GroupBox8
            // 
            this.GroupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox8.Controls.Add(this.cbPersonagem2);
            this.GroupBox8.Controls.Add(this.ckPersonagem);
            this.GroupBox8.Controls.Add(this.cbPersonagem);
            this.GroupBox8.Controls.Add(this.Label20);
            this.GroupBox8.Controls.Add(this.Label21);
            this.GroupBox8.Location = new System.Drawing.Point(8, 336);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(396, 45);
            this.GroupBox8.TabIndex = 23;
            this.GroupBox8.TabStop = false;
            // 
            // cbPersonagem2
            // 
            this.cbPersonagem2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPersonagem2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonagem2.FormattingEnabled = true;
            this.cbPersonagem2.ItemHeight = 13;
            this.cbPersonagem2.Items.AddRange(new object[] {
            "Nico",
            "Hana",
            "Fred",
            "Cecilia",
            "Max",
            "Kooh",
            "Arin",
            "Kaz",
            "Lucia",
            "Nell"});
            this.cbPersonagem2.Location = new System.Drawing.Point(222, 14);
            this.cbPersonagem2.Name = "cbPersonagem2";
            this.cbPersonagem2.Size = new System.Drawing.Size(143, 21);
            this.cbPersonagem2.TabIndex = 25;
            // 
            // ckPersonagem
            // 
            this.ckPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPersonagem.AutoSize = true;
            this.ckPersonagem.Location = new System.Drawing.Point(371, 19);
            this.ckPersonagem.Name = "ckPersonagem";
            this.ckPersonagem.Size = new System.Drawing.Size(15, 14);
            this.ckPersonagem.TabIndex = 24;
            this.ckPersonagem.UseVisualStyleBackColor = true;
            // 
            // cbPersonagem
            // 
            this.cbPersonagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonagem.FormattingEnabled = true;
            this.cbPersonagem.ItemHeight = 13;
            this.cbPersonagem.Items.AddRange(new object[] {
            "Igual",
            "Diferente"});
            this.cbPersonagem.Location = new System.Drawing.Point(85, 14);
            this.cbPersonagem.Name = "cbPersonagem";
            this.cbPersonagem.Size = new System.Drawing.Size(111, 21);
            this.cbPersonagem.TabIndex = 2;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(202, 18);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(13, 13);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "à";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(8, 18);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(66, 13);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "Personagem";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox5.Controls.Add(this.txxtVariavel);
            this.GroupBox5.Controls.Add(this.ckBase);
            this.GroupBox5.Controls.Add(this.Label12);
            this.GroupBox5.Controls.Add(this.cbOperacao);
            this.GroupBox5.Controls.Add(this.Label11);
            this.GroupBox5.Location = new System.Drawing.Point(7, 26);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(398, 45);
            this.GroupBox5.TabIndex = 23;
            this.GroupBox5.TabStop = false;
            // 
            // txxtVariavel
            // 
            this.txxtVariavel.Location = new System.Drawing.Point(203, 15);
            this.txxtVariavel.MaxLength = 40;
            this.txxtVariavel.Name = "txxtVariavel";
            this.txxtVariavel.Size = new System.Drawing.Size(62, 20);
            this.txxtVariavel.TabIndex = 25;
            // 
            // ckBase
            // 
            this.ckBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBase.AutoSize = true;
            this.ckBase.Checked = true;
            this.ckBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBase.Location = new System.Drawing.Point(277, 17);
            this.ckBase.Name = "ckBase";
            this.ckBase.Size = new System.Drawing.Size(113, 17);
            this.ckBase.TabIndex = 24;
            this.ckBase.Text = "Baseado no preço";
            this.ckBase.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(155, 19);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(45, 13);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "Variavel";
            // 
            // cbOperacao
            // 
            this.cbOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperacao.FormattingEnabled = true;
            this.cbOperacao.ItemHeight = 13;
            this.cbOperacao.Items.AddRange(new object[] {
            "Somar",
            "Subtrair",
            "Multiplicar",
            "Dividir"});
            this.cbOperacao.Location = new System.Drawing.Point(71, 15);
            this.cbOperacao.Name = "cbOperacao";
            this.cbOperacao.Size = new System.Drawing.Size(70, 21);
            this.cbOperacao.TabIndex = 2;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(11, 19);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(54, 13);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "Operação";
            // 
            // DlgMassaDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 461);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.StatusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgMassaDesconto";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Text = "Alteração em massa";
            this.Load += new System.EventHandler(this.DlgMassaDesconto_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox18.ResumeLayout(false);
            this.GroupBox18.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		[AccessedThroughProperty("StatusStrip1")]
		private StatusStrip StatusStrip1;

		[AccessedThroughProperty("ToolStripStatusLabel2")]
		private ToolStripStatusLabel ToolStripStatusLabel2;

		[AccessedThroughProperty("ToolTip1")]
		private ToolTip ToolTip1;

		[AccessedThroughProperty("ToolStripStatusLabel1")]
		private ToolStripStatusLabel ToolStripStatusLabel1;

		[AccessedThroughProperty("Panel1")]
		private Panel Panel1;

		[AccessedThroughProperty("btnAplicar")]
		private Button btnAplicar;

		[AccessedThroughProperty("Label4")]
		private Label Label4;

		[AccessedThroughProperty("Label3")]
		private Label Label3;

		[AccessedThroughProperty("Label9")]
		private Label Label9;

		[AccessedThroughProperty("Label8")]
		private Label Label8;

		[AccessedThroughProperty("GroupBox7")]
		private GroupBox GroupBox7;

		[AccessedThroughProperty("ckAtivo")]
		private CheckBox ckAtivo;

		[AccessedThroughProperty("ckStatus")]
		private CheckBox ckStatus;

		[AccessedThroughProperty("cbStatus")]
		private ComboBox cbStatus;

		[AccessedThroughProperty("Label18")]
		private Label Label18;

		[AccessedThroughProperty("Label19")]
		private Label Label19;

		[AccessedThroughProperty("GroupBox18")]
		private GroupBox GroupBox18;

		[AccessedThroughProperty("txtPreco")]
		private TextBox txtPreco;

		[AccessedThroughProperty("ckPreco")]
		private CheckBox ckPreco;

		[AccessedThroughProperty("cbPreco")]
		private ComboBox cbPreco;

		[AccessedThroughProperty("Label45")]
		private Label Label45;

		[AccessedThroughProperty("Label46")]
		private Label Label46;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox GroupBox2;

		[AccessedThroughProperty("txtDesconto")]
		private TextBox txtDesconto;

		[AccessedThroughProperty("ckDesconto")]
		private CheckBox ckDesconto;

		[AccessedThroughProperty("cbDesconto")]
		private ComboBox cbDesconto;

		[AccessedThroughProperty("Label13")]
		private Label Label13;

		[AccessedThroughProperty("Label5")]
		private Label Label5;

		[AccessedThroughProperty("GroupBox3")]
		private GroupBox GroupBox3;

		[AccessedThroughProperty("cbTipo2")]
		private ComboBox cbTipo2;

		[AccessedThroughProperty("ckTipo")]
		private CheckBox ckTipo;

		[AccessedThroughProperty("cbTipo")]
		private ComboBox cbTipo;

		[AccessedThroughProperty("Label14")]
		private Label Label14;

		[AccessedThroughProperty("Label6")]
		private Label Label6;

		[AccessedThroughProperty("GroupBox4")]
		private GroupBox GroupBox4;

		[AccessedThroughProperty("cbMoeda2")]
		private ComboBox cbMoeda2;

		[AccessedThroughProperty("ckMoeda")]
		private CheckBox ckMoeda;

		[AccessedThroughProperty("cbMoeda")]
		private ComboBox cbMoeda;

		[AccessedThroughProperty("Label15")]
		private Label Label15;

		[AccessedThroughProperty("Label7")]
		private Label Label7;

		[AccessedThroughProperty("GroupBox6")]
		private GroupBox GroupBox6;

		[AccessedThroughProperty("cbMarcacao2")]
		private ComboBox cbMarcacao2;

		[AccessedThroughProperty("ckMarcacao")]
		private CheckBox ckMarcacao;

		[AccessedThroughProperty("cbMarcacao")]
		private ComboBox cbMarcacao;

		[AccessedThroughProperty("Label16")]
		private Label Label16;

		[AccessedThroughProperty("Label17")]
		private Label Label17;

		[AccessedThroughProperty("GroupBox8")]
		private GroupBox GroupBox8;

		[AccessedThroughProperty("cbPersonagem2")]
		private ComboBox cbPersonagem2;

		[AccessedThroughProperty("ckPersonagem")]
		private CheckBox ckPersonagem;

		[AccessedThroughProperty("cbPersonagem")]
		private ComboBox cbPersonagem;

		[AccessedThroughProperty("Label20")]
		private Label Label20;

		[AccessedThroughProperty("Label21")]
		private Label Label21;

		[AccessedThroughProperty("GroupBox5")]
		private GroupBox GroupBox5;

		[AccessedThroughProperty("txxtVariavel")]
		private TextBox txxtVariavel;

		[AccessedThroughProperty("Label12")]
		private Label Label12;

		[AccessedThroughProperty("cbOperacao")]
		private ComboBox cbOperacao;

		[AccessedThroughProperty("Label11")]
		private Label Label11;

		[AccessedThroughProperty("btnSimular")]
		private Button btnSimular;

		[AccessedThroughProperty("btnLimpar")]
		private Button btnLimpar;

		[AccessedThroughProperty("ckBase")]
		private CheckBox ckBase;
		#endregion
	}
}