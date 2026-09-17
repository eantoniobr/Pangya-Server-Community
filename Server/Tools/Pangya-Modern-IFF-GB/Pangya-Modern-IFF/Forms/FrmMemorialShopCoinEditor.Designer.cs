using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
    partial class FrmMemorialShopCoinEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMemorialShopCoinEditor));
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbTotalItens = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbIndices = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAbrirArquivo = new System.Windows.Forms.ToolStripButton();
            this.menuSalvarComo = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoCoin = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCounter = new System.Windows.Forms.NumericUpDown();
            this.imgResultado = new System.Windows.Forms.PictureBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtProbs = new System.Windows.Forms.NumericUpDown();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.Label17 = new System.Windows.Forms.Label();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            this.gbBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lbTotalItens,
            this.ToolStripStatusLabel4,
            this.lbIndices,
            this.ToolStripStatusLabel2,
            this.lbStatus,
            this.pbStatus});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 500);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(809, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
            this.ToolStripStatusLabel1.Text = "Total de Itens:";
            // 
            // lbTotalItens
            // 
            this.lbTotalItens.Name = "lbTotalItens";
            this.lbTotalItens.Size = new System.Drawing.Size(13, 17);
            this.lbTotalItens.Text = "0";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(47, 17);
            this.ToolStripStatusLabel4.Text = "Indices:";
            // 
            // lbIndices
            // 
            this.lbIndices.Name = "lbIndices";
            this.lbIndices.Size = new System.Drawing.Size(13, 17);
            this.lbIndices.Text = "0";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(496, 17);
            this.ToolStripStatusLabel2.Spring = true;
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(44, 17);
            this.lbStatus.Text = "Parado";
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            this.pbStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.Color.White;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirArquivo,
            this.menuSalvarComo});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(809, 40);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Image = global::PangyaSuiteFiles.Properties.Resources.btnAbrirArquivo_Image;
            this.btnAbrirArquivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAbrirArquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(36, 37);
            this.btnAbrirArquivo.ToolTipText = "Abrir arquivo";
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // menuSalvarComo
            // 
            this.menuSalvarComo.Enabled = false;
            this.menuSalvarComo.Image = global::PangyaSuiteFiles.Properties.Resources.disk_multiple;
            this.menuSalvarComo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalvarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSalvarComo.Name = "menuSalvarComo";
            this.menuSalvarComo.Size = new System.Drawing.Size(36, 37);
            this.menuSalvarComo.ToolTipText = "Salvar como";
            this.menuSalvarComo.Click += new System.EventHandler(this.menuSalvarComo_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.Silver;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 40);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.Panel3);
            this.SplitContainer1.Panel1.Controls.Add(this.Panel2);
            this.SplitContainer1.Panel1MinSize = 200;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.Panel4);
            this.SplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.SplitContainer1.Panel2MinSize = 0;
            this.SplitContainer1.Size = new System.Drawing.Size(809, 460);
            this.SplitContainer1.SplitterDistance = 277;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Controls.Add(this.Panel1);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(277, 433);
            this.Panel3.TabIndex = 2;
            // 
            // ListaItem
            // 
            this.ListaItem.AllowUserToAddRows = false;
            this.ListaItem.AllowUserToDeleteRows = false;
            this.ListaItem.AllowUserToResizeColumns = false;
            this.ListaItem.AllowUserToResizeRows = false;
            this.ListaItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.ListaItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaItem.Location = new System.Drawing.Point(0, 0);
            this.ListaItem.Name = "ListaItem";
            this.ListaItem.ReadOnly = true;
            this.ListaItem.RowHeadersVisible = false;
            this.ListaItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ListaItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListaItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaItem.ShowCellErrors = false;
            this.ListaItem.ShowEditingIcon = false;
            this.ListaItem.ShowRowErrors = false;
            this.ListaItem.Size = new System.Drawing.Size(277, 364);
            this.ListaItem.TabIndex = 1;
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.label9);
            this.Panel1.Controls.Add(this.comboBox3);
            this.Panel1.Controls.Add(this.label5);
            this.Panel1.Controls.Add(this.ComboBox1);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.pictureBox3);
            this.Panel1.Controls.Add(this.pictureBox5);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.textBox1);
            this.Panel1.Controls.Add(this.label4);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 364);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(277, 69);
            this.Panel1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Coin Type";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 13;
            this.comboBox3.Items.AddRange(new object[] {
            "NORMAL",
            "PREMIUM",
            "SPECIAL",
            "CHARACTER"});
            this.comboBox3.Location = new System.Drawing.Point(188, 44);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(86, 21);
            this.comboBox3.TabIndex = 26;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Item Type";
            // 
            // ComboBox1
            // 
            this.ComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.ItemHeight = 13;
            this.ComboBox1.Items.AddRange(new object[] {
            "ALL",
            "NORMAL",
            "SPRING",
            "SUMMER",
            "FALL",
            "WINTER",
            "CLUBSET",
            "SETITEM",
            "EAR",
            "WING",
            "LUVA",
            "RING_R",
            "RING_L",
            "CADDIE",
            "MASCOT",
            "SUMMER_HOLYDAY",
            "XMAS",
            "HALLOWEEN",
            "MAN",
            "WOMAN",
            "NURI",
            "HANA",
            "AZER",
            "CECI",
            "MAX",
            "KOOH",
            "ARIN",
            "KAZ",
            "LUCIA",
            "NELL",
            "SPIKA",
            "NURI_R",
            "HANA_R",
            "AZER_R",
            "CECI_R"});
            this.ComboBox1.Location = new System.Drawing.Point(96, 44);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(86, 21);
            this.ComboBox1.TabIndex = 24;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 27);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(270, 2);
            this.Label39.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
            this.pictureBox3.Location = new System.Drawing.Point(202, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.pictureBox5.Location = new System.Drawing.Point(5, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // ComboBox2
            // 
            this.ComboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.ItemHeight = 13;
            this.ComboBox2.Items.AddRange(new object[] {
            "All",
            "Active",
            "Disable"});
            this.ComboBox2.Location = new System.Drawing.Point(7, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(82, 21);
            this.ComboBox2.TabIndex = 1;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(27, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "0";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(4, 28);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(37, 13);
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Controls.Add(this.lbArquivo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(277, 27);
            this.Panel2.TabIndex = 1;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Image = global::PangyaSuiteFiles.Properties.Resources.document_editing;
            this.PictureBox2.Location = new System.Drawing.Point(3, 4);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(20, 20);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox2.TabIndex = 1;
            this.PictureBox2.TabStop = false;
            // 
            // lbArquivo
            // 
            this.lbArquivo.AutoSize = true;
            this.lbArquivo.BackColor = System.Drawing.Color.Transparent;
            this.lbArquivo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArquivo.ForeColor = System.Drawing.Color.White;
            this.lbArquivo.Location = new System.Drawing.Point(24, 6);
            this.lbArquivo.Name = "lbArquivo";
            this.lbArquivo.Size = new System.Drawing.Size(139, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Nenhum arquivo aberto";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(524, 454);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(514, 378);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(506, 352);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Informações Básicas";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckAtivo);
            this.GroupBox1.Controls.Add(this.cbItemType);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.cbTipoCoin);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.txtCounter);
            this.GroupBox1.Controls.Add(this.imgResultado);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtTypeID);
            this.GroupBox1.Controls.Add(this.txtIndex);
            this.GroupBox1.Controls.Add(this.txtProbs);
            this.GroupBox1.Controls.Add(this.txtNumber);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Location = new System.Drawing.Point(6, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(495, 230);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Informações";
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(235, 29);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(58, 19);
            this.ckAtivo.TabIndex = 23;
            this.ckAtivo.Text = "ATIVO";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // cbItemType
            // 
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Items.AddRange(new object[] {
            "NORMAL",
            "SPRING",
            "SUMMER",
            "FALL",
            "WINTER",
            "CLUBSET",
            "SETITEM",
            "EAR",
            "WING",
            "LUVA",
            "RING_R",
            "RING_L",
            "CADDIE",
            "MASCOT",
            "SUMMER_HOLYDAY",
            "XMAS",
            "HALLOWEEN",
            "MAN",
            "WOMAN",
            "NURI",
            "HANA",
            "AZER",
            "CECI",
            "MAX",
            "KOOH",
            "ARIN",
            "KAZ",
            "LUCIA",
            "NELL",
            "SPIKA",
            "NURI_R",
            "HANA_R",
            "AZER_R",
            "CECI_R"});
            this.cbItemType.Location = new System.Drawing.Point(84, 195);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(137, 23);
            this.cbItemType.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "ItemType";
            // 
            // cbTipoCoin
            // 
            this.cbTipoCoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCoin.FormattingEnabled = true;
            this.cbTipoCoin.Items.AddRange(new object[] {
            "NORMAL",
            "PREMIUM",
            "SPECIAL",
            "CHARACTER"});
            this.cbTipoCoin.Location = new System.Drawing.Point(84, 166);
            this.cbTipoCoin.Name = "cbTipoCoin";
            this.cbTipoCoin.Size = new System.Drawing.Size(137, 23);
            this.cbTipoCoin.TabIndex = 20;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(20, 169);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(58, 15);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "CoinType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Counter";
            // 
            // txtCounter
            // 
            this.txtCounter.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCounter.Location = new System.Drawing.Point(84, 137);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(137, 23);
            this.txtCounter.TabIndex = 17;
            this.txtCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgResultado
            // 
            this.imgResultado.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.imgResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgResultado.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.imgResultado.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.imgResultado.Location = new System.Drawing.Point(230, 58);
            this.imgResultado.Name = "imgResultado";
            this.imgResultado.Size = new System.Drawing.Size(65, 82);
            this.imgResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgResultado.TabIndex = 16;
            this.imgResultado.TabStop = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(13, 111);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(52, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Number";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Nome";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(13, 58);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(44, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "TypeID";
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(84, 55);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(137, 21);
            this.txtTypeID.TabIndex = 0;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(84, 27);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(137, 21);
            this.txtIndex.TabIndex = 0;
            // 
            // txtProbs
            // 
            this.txtProbs.Font = new System.Drawing.Font("Arial", 10F);
            this.txtProbs.Location = new System.Drawing.Point(84, 79);
            this.txtProbs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtProbs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtProbs.Name = "txtProbs";
            this.txtProbs.Size = new System.Drawing.Size(137, 23);
            this.txtProbs.TabIndex = 1;
            this.txtProbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProbs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNumber.Location = new System.Drawing.Point(84, 108);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(137, 23);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumber.ValueChanged += new System.EventHandler(this.txtItemProdQtd_ValueChanged);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(13, 82);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(33, 15);
            this.Label17.TabIndex = 11;
            this.Label17.Text = "Prob";
            // 
            // gbBotoes
            // 
            this.gbBotoes.Controls.Add(this.btnReabrir);
            this.gbBotoes.Controls.Add(this.btnNovo);
            this.gbBotoes.Controls.Add(this.btnRemover);
            this.gbBotoes.Controls.Add(this.btnBackup);
            this.gbBotoes.Controls.Add(this.btnSalvar);
            this.gbBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBotoes.Enabled = false;
            this.gbBotoes.Location = new System.Drawing.Point(5, 381);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(514, 70);
            this.gbBotoes.TabIndex = 1;
            this.gbBotoes.TabStop = false;
            // 
            // btnReabrir
            // 
            this.btnReabrir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReabrir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReabrir.Image = global::PangyaSuiteFiles.Properties.Resources.accept;
            this.btnReabrir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReabrir.Location = new System.Drawing.Point(308, 14);
            this.btnReabrir.Name = "btnReabrir";
            this.btnReabrir.Size = new System.Drawing.Size(97, 48);
            this.btnReabrir.TabIndex = 0;
            this.btnReabrir.TabStop = false;
            this.btnReabrir.Text = "Aplicar";
            this.btnReabrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReabrir.UseVisualStyleBackColor = true;
            this.btnReabrir.Click += new System.EventHandler(this.btnReabrir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::PangyaSuiteFiles.Properties.Resources.add;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.Location = new System.Drawing.Point(8, 14);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(97, 48);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.TabStop = false;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Image = global::PangyaSuiteFiles.Properties.Resources.delete;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.Location = new System.Drawing.Point(108, 14);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(97, 48);
            this.btnRemover.TabIndex = 0;
            this.btnRemover.TabStop = false;
            this.btnRemover.Text = "Remover";
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Image = global::PangyaSuiteFiles.Properties.Resources.stamp_pattern;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.Location = new System.Drawing.Point(208, 14);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(97, 48);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.TabStop = false;
            this.btnBackup.Text = "Clonar";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click_1);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::PangyaSuiteFiles.Properties.Resources.disk;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(408, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 48);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            this.txtPesquisa.Location = new System.Drawing.Point(319, -23);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(173, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.Visible = false;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label33.Location = new System.Drawing.Point(516, 5);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(14, 16);
            this.Label33.TabIndex = 10;
            this.Label33.Text = "0";
            this.Label33.Visible = false;
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(592, 0);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(66, 13);
            this.Label36.TabIndex = 10;
            this.Label36.Text = "Personagem";
            this.Label36.Visible = false;
            // 
            // bwSalvar
            // 
            this.bwSalvar.WorkerReportsProgress = true;
            this.bwSalvar.WorkerSupportsCancellation = true;
            this.bwSalvar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSalvar_DoWork);
            this.bwSalvar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSalvar_ProgressChanged);
            this.bwSalvar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSalvar_RunWorkerCompleted);
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageList2
            // 
            this.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Imagem (*.sff)|*.sff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Salvar arquivo Part.sff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.sff)|*.sff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Part.sff)";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            // 
            // PictureBox4
            // 
            this.PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
            this.PictureBox4.Location = new System.Drawing.Point(494, -23);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(20, 20);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox4.TabIndex = 1;
            this.PictureBox4.TabStop = false;
            this.PictureBox4.Visible = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.PictureBox1.Location = new System.Drawing.Point(297, -23);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Visible = false;
            // 
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Image = global::PangyaSuiteFiles.Properties.Resources.fred;
            this.imgPersonagem.Location = new System.Drawing.Point(555, -23);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // FrmMemorialShopCoinEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 522);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMemorialShopCoinEditor";
            this.Text = "MemorialShopCoinItem - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmMemorialShopCoinEditor_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            this.gbBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip StatusStrip1;

        [AccessedThroughProperty("ToolStrip1")]
        private ToolStrip ToolStrip1;

        [AccessedThroughProperty("SplitContainer1")]
        private SplitContainer SplitContainer1;

        [AccessedThroughProperty("PictureBox1")]
        private PictureBox PictureBox1;

        [AccessedThroughProperty("txtPesquisa")]
        private TextBox txtPesquisa;

        [AccessedThroughProperty("gbBotoes")]
        private GroupBox gbBotoes;

        [AccessedThroughProperty("Panel4")]
        private Panel Panel4;

        [AccessedThroughProperty("tabForm")]
        private TabControl tabForm;

        [AccessedThroughProperty("TabPage1")]
        private TabPage TabPage1;

        [AccessedThroughProperty("btnAbrirArquivo")]
        private ToolStripButton btnAbrirArquivo;

        [AccessedThroughProperty("diagAbrirArquivo")]
        private OpenFileDialog diagAbrirArquivo;

        [AccessedThroughProperty("ToolStripStatusLabel1")]
        private ToolStripStatusLabel ToolStripStatusLabel1;

        [AccessedThroughProperty("lbTotalItens")]
        private ToolStripStatusLabel lbTotalItens;

        [AccessedThroughProperty("btnReabrir")]
        private Button btnReabrir;

        [AccessedThroughProperty("btnNovo")]
        private Button btnNovo;

        [AccessedThroughProperty("btnRemover")]
        private Button btnRemover;

        [AccessedThroughProperty("btnBackup")]
        private Button btnBackup;

        [AccessedThroughProperty("btnSalvar")]
        private Button btnSalvar;

        [AccessedThroughProperty("ToolStripStatusLabel2")]
        private ToolStripStatusLabel ToolStripStatusLabel2;

        [AccessedThroughProperty("lbStatus")]
        private ToolStripStatusLabel lbStatus;

        [AccessedThroughProperty("diagSalvarArquivo")]
        private SaveFileDialog diagSalvarArquivo;

        [AccessedThroughProperty("menuSalvarComo")]
        private ToolStripButton menuSalvarComo;

        [AccessedThroughProperty("ToolStripStatusLabel4")]
        private ToolStripStatusLabel ToolStripStatusLabel4;

        [AccessedThroughProperty("lbIndices")]
        private ToolStripStatusLabel lbIndices;

        [AccessedThroughProperty("pbStatus")]
        private ToolStripProgressBar pbStatus;

        [AccessedThroughProperty("imgPersonagem")]
        private PictureBox imgPersonagem;

        [AccessedThroughProperty("txtTypeID")]
        private TextBox txtTypeID;

        [AccessedThroughProperty("bwSalvar")]
        private BackgroundWorker bwSalvar;

        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        [AccessedThroughProperty("Label33")]
        private Label Label33;

        [AccessedThroughProperty("ImageList1")]
        private ImageList ImageList1;

        [AccessedThroughProperty("Label36")]
        private Label Label36;

        [AccessedThroughProperty("ImageList2")]
        private ImageList ImageList2;

        [AccessedThroughProperty("diagPasta")]
        private FolderBrowserDialog diagPasta;

        [AccessedThroughProperty("Label1")]
        private Label Label1;

        [AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;

        [AccessedThroughProperty("Label6")]
        private Label Label6;

        [AccessedThroughProperty("Label7")]
        private Label Label7;

        [AccessedThroughProperty("txtItemProdQtd")]
        private NumericUpDown txtNumber;

        [AccessedThroughProperty("txtIndex")]
        private TextBox txtIndex;

        [AccessedThroughProperty("Label17")]
        private Label Label17;

        [AccessedThroughProperty("txtRate")]
        private NumericUpDown txtProbs;

        [AccessedThroughProperty("imgResultado")]
        private PictureBox imgResultado;

        public string Arquivo;

        private MemorialShopCoinItem oIff;

        public MemorialShopCoinItemCollection lsItens;

        public MemorialShopCoinItemCollection lsTemp;

        public byte[] bStart;

        private bool Alterado;

        private BindingSource bs;

        private int lastRow;

        public long qtdItem;

#pragma warning disable CS0169 // O campo "FrmMemorialShopCoinEditor.arquivog" nunca é usado
        private string arquivog;
#pragma warning restore CS0169 // O campo "FrmMemorialShopCoinEditor.arquivog" nunca é usado

        private string caminho;
        #endregion

        private Label label2;
        private NumericUpDown txtCounter;
        private ComboBox cbItemType;
        private Label label3;
        private ComboBox cbTipoCoin;
        private Label Label8;
        private CheckBox ckAtivo;
        private Panel Panel3;
        private Panel Panel2;
        private PictureBox PictureBox2;
        private Label lbArquivo;
        public DataGridView ListaItem;
        private Panel Panel1;
        private Label Label39;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private ComboBox ComboBox2;
        private TextBox textBox1;
        private Label label4;
        private Label Label37;
        private Label label5;
        private ComboBox ComboBox1;
        private Label label9;
        private ComboBox comboBox3;
    }
}