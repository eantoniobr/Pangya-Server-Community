using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
    partial class FrmGrandPrixDataEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGrandPrixDataEditor));
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtRes4 = new System.Windows.Forms.TextBox();
            this.txtRes3 = new System.Windows.Forms.TextBox();
            this.txtRes2 = new System.Windows.Forms.TextBox();
            this.txtRes1 = new System.Windows.Forms.TextBox();
            this.img4 = new System.Windows.Forms.PictureBox();
            this.img3 = new System.Windows.Forms.PictureBox();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.img1 = new System.Windows.Forms.PictureBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtItem5 = new System.Windows.Forms.TextBox();
            this.txtItem5Qtd = new System.Windows.Forms.NumericUpDown();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtItem4 = new System.Windows.Forms.TextBox();
            this.txtItem3 = new System.Windows.Forms.TextBox();
            this.txtItem2 = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtItem1 = new System.Windows.Forms.TextBox();
            this.txtItem4Qtd = new System.Windows.Forms.NumericUpDown();
            this.txtItem3Qtd = new System.Windows.Forms.NumericUpDown();
            this.txtItem2Qtd = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtItem1Qtd = new System.Windows.Forms.NumericUpDown();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.txtItemProdQtd = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.imgIcone = new System.Windows.Forms.PictureBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbContNome = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbAba = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtNatural = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Time_End = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.Time_Start = new System.Windows.Forms.DateTimePicker();
            this.Time_Open = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtScore2 = new System.Windows.Forms.TextBox();
            this.txtScore1 = new System.Windows.Forms.TextBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtScore3 = new System.Windows.Forms.TextBox();
            this.nmrPangReward = new System.Windows.Forms.NumericUpDown();
            this.cbHoleSize = new System.Windows.Forms.ComboBox();
            this.txt_Ticket_TypeID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtTimeHole = new System.Windows.Forms.TextBox();
            this.txt_Ticket_Qntd = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbTotalHole = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem5Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPangReward)).BeginInit();
            this.gbBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 578);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(851, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(538, 17);
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
            this.ToolStrip1.Size = new System.Drawing.Size(851, 40);
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
            this.menuSalvarComo.Click += new System.EventHandler(this.MenuSalvar_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.Silver;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.SplitContainer1.Size = new System.Drawing.Size(851, 533);
            this.SplitContainer1.SplitterDistance = 297;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.panel5);
            this.Panel3.Controls.Add(this.Panel1);
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(297, 533);
            this.Panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.PictureBox2);
            this.panel5.Controls.Add(this.lbArquivo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(297, 27);
            this.panel5.TabIndex = 3;
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
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.cbPage);
            this.Panel1.Controls.Add(this.label22);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.pictureBox3);
            this.Panel1.Controls.Add(this.pictureBox6);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.textBox1);
            this.Panel1.Controls.Add(this.Label19);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 457);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(297, 76);
            this.Panel1.TabIndex = 2;
            // 
            // cbPage
            // 
            this.cbPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.FormattingEnabled = true;
            this.cbPage.ItemHeight = 13;
            this.cbPage.Items.AddRange(new object[] {
            "ROOKIE",
            "BEGINNER",
            "JUNIOR",
            "EVENT"});
            this.cbPage.Location = new System.Drawing.Point(3, 53);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(102, 21);
            this.cbPage.TabIndex = 25;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(0, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Page";
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 32);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(260, 2);
            this.Label39.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
            this.pictureBox3.Location = new System.Drawing.Point(204, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.pictureBox3_HelpRequested);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.pictureBox6.Location = new System.Drawing.Point(5, 9);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // ComboBox2
            // 
            this.ComboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.ItemHeight = 13;
            this.ComboBox2.Items.AddRange(new object[] {
            "Todos",
            "Ativos",
            "Desativados"});
            this.ComboBox2.Location = new System.Drawing.Point(110, 53);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(90, 21);
            this.ComboBox2.TabIndex = 1;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(27, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(226, 8);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(14, 16);
            this.Label19.TabIndex = 10;
            this.Label19.Text = "0";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(116, 37);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(37, 13);
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
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
            this.ListaItem.Location = new System.Drawing.Point(1, 27);
            this.ListaItem.Name = "ListaItem";
            this.ListaItem.ReadOnly = true;
            this.ListaItem.RowHeadersVisible = false;
            this.ListaItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ListaItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListaItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaItem.ShowCellErrors = false;
            this.ListaItem.ShowEditingIcon = false;
            this.ListaItem.ShowRowErrors = false;
            this.ListaItem.Size = new System.Drawing.Size(283, 430);
            this.ListaItem.TabIndex = 0;
            this.ListaItem.DefaultCellStyleChanged += new System.EventHandler(this.ListaItem_DefaultCellStyleChanged);
            this.ListaItem.RowDefaultCellStyleChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            this.ListaItem.Sorted += new System.EventHandler(this.ListaItem_Sorted);
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(200, 100);
            this.Panel2.TabIndex = 3;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(546, 527);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.tabPage2);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(536, 451);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(528, 425);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Informações Básicas";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.textBox2);
            this.GroupBox2.Controls.Add(this.pictureBox8);
            this.GroupBox2.Controls.Add(this.txtRes4);
            this.GroupBox2.Controls.Add(this.txtRes3);
            this.GroupBox2.Controls.Add(this.txtRes2);
            this.GroupBox2.Controls.Add(this.txtRes1);
            this.GroupBox2.Controls.Add(this.img4);
            this.GroupBox2.Controls.Add(this.img3);
            this.GroupBox2.Controls.Add(this.img2);
            this.GroupBox2.Controls.Add(this.img1);
            this.GroupBox2.Location = new System.Drawing.Point(2, 303);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(524, 119);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Resultado";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(305, 93);
            this.textBox2.MaxLength = 20000;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(65, 21);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.pictureBox8.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.pictureBox8.Location = new System.Drawing.Point(305, 13);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(65, 82);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox8.TabIndex = 18;
            this.pictureBox8.TabStop = false;
            // 
            // txtRes4
            // 
            this.txtRes4.BackColor = System.Drawing.Color.White;
            this.txtRes4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes4.Location = new System.Drawing.Point(231, 93);
            this.txtRes4.MaxLength = 20000;
            this.txtRes4.Name = "txtRes4";
            this.txtRes4.ReadOnly = true;
            this.txtRes4.Size = new System.Drawing.Size(65, 21);
            this.txtRes4.TabIndex = 2;
            this.txtRes4.Text = "0";
            this.txtRes4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRes3
            // 
            this.txtRes3.BackColor = System.Drawing.Color.White;
            this.txtRes3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes3.Location = new System.Drawing.Point(155, 93);
            this.txtRes3.MaxLength = 20000;
            this.txtRes3.Name = "txtRes3";
            this.txtRes3.ReadOnly = true;
            this.txtRes3.Size = new System.Drawing.Size(65, 21);
            this.txtRes3.TabIndex = 2;
            this.txtRes3.Text = "0";
            this.txtRes3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRes2
            // 
            this.txtRes2.BackColor = System.Drawing.Color.White;
            this.txtRes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes2.Location = new System.Drawing.Point(79, 93);
            this.txtRes2.MaxLength = 20000;
            this.txtRes2.Name = "txtRes2";
            this.txtRes2.ReadOnly = true;
            this.txtRes2.Size = new System.Drawing.Size(65, 21);
            this.txtRes2.TabIndex = 2;
            this.txtRes2.Text = "0";
            this.txtRes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRes1
            // 
            this.txtRes1.BackColor = System.Drawing.Color.White;
            this.txtRes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes1.Location = new System.Drawing.Point(3, 93);
            this.txtRes1.MaxLength = 20000;
            this.txtRes1.Name = "txtRes1";
            this.txtRes1.ReadOnly = true;
            this.txtRes1.Size = new System.Drawing.Size(65, 21);
            this.txtRes1.TabIndex = 2;
            this.txtRes1.Text = "0";
            this.txtRes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // img4
            // 
            this.img4.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.img4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img4.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.img4.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.img4.Location = new System.Drawing.Point(231, 13);
            this.img4.Name = "img4";
            this.img4.Size = new System.Drawing.Size(65, 82);
            this.img4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img4.TabIndex = 15;
            this.img4.TabStop = false;
            // 
            // img3
            // 
            this.img3.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.img3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img3.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.img3.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.img3.Location = new System.Drawing.Point(155, 13);
            this.img3.Name = "img3";
            this.img3.Size = new System.Drawing.Size(65, 82);
            this.img3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img3.TabIndex = 15;
            this.img3.TabStop = false;
            // 
            // img2
            // 
            this.img2.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.img2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img2.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.img2.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.img2.Location = new System.Drawing.Point(79, 13);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(65, 82);
            this.img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img2.TabIndex = 15;
            this.img2.TabStop = false;
            // 
            // img1
            // 
            this.img1.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.img1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img1.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.img1.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.img1.Location = new System.Drawing.Point(3, 13);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(65, 82);
            this.img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img1.TabIndex = 15;
            this.img1.TabStop = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.button5);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.label23);
            this.GroupBox3.Controls.Add(this.txtItem5);
            this.GroupBox3.Controls.Add(this.txtItem5Qtd);
            this.GroupBox3.Controls.Add(this.Button4);
            this.GroupBox3.Controls.Add(this.Button3);
            this.GroupBox3.Controls.Add(this.Button2);
            this.GroupBox3.Controls.Add(this.Button1);
            this.GroupBox3.Controls.Add(this.Label16);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.Label15);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.Label11);
            this.GroupBox3.Controls.Add(this.txtItem4);
            this.GroupBox3.Controls.Add(this.txtItem3);
            this.GroupBox3.Controls.Add(this.txtItem2);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.txtItem1);
            this.GroupBox3.Controls.Add(this.txtItem4Qtd);
            this.GroupBox3.Controls.Add(this.txtItem3Qtd);
            this.GroupBox3.Controls.Add(this.txtItem2Qtd);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.txtItem1Qtd);
            this.GroupBox3.Controls.Add(this.txtTypeID);
            this.GroupBox3.Controls.Add(this.txtItemProdQtd);
            this.GroupBox3.Location = new System.Drawing.Point(6, 97);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(516, 199);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Configurações";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.button5.Location = new System.Drawing.Point(241, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 24);
            this.button5.TabIndex = 36;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Quantidade";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 156);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 15);
            this.label23.TabIndex = 35;
            this.label23.Text = "Quinto Item";
            // 
            // txtItem5
            // 
            this.txtItem5.Location = new System.Drawing.Point(107, 153);
            this.txtItem5.Name = "txtItem5";
            this.txtItem5.Size = new System.Drawing.Size(110, 21);
            this.txtItem5.TabIndex = 32;
            // 
            // txtItem5Qtd
            // 
            this.txtItem5Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem5Qtd.Location = new System.Drawing.Point(340, 151);
            this.txtItem5Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem5Qtd.Name = "txtItem5Qtd";
            this.txtItem5Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem5Qtd.TabIndex = 33;
            this.txtItem5Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.Button4.Location = new System.Drawing.Point(241, 127);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(25, 24);
            this.Button4.TabIndex = 31;
            this.Button4.TabStop = false;
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.Button3.Location = new System.Drawing.Point(241, 103);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(25, 24);
            this.Button3.TabIndex = 31;
            this.Button3.TabStop = false;
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.Button2.Location = new System.Drawing.Point(241, 79);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(25, 24);
            this.Button2.TabIndex = 31;
            this.Button2.TabStop = false;
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
            this.Button1.Location = new System.Drawing.Point(241, 55);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(25, 24);
            this.Button1.TabIndex = 31;
            this.Button1.TabStop = false;
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(263, 131);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(71, 15);
            this.Label16.TabIndex = 11;
            this.Label16.Text = "Quantidade";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(263, 107);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(71, 15);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "Quantidade";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(263, 83);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(71, 15);
            this.Label12.TabIndex = 11;
            this.Label12.Text = "Quantidade";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(263, 59);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(71, 15);
            this.Label10.TabIndex = 11;
            this.Label10.Text = "Quantidade";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(262, 23);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(71, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Quantidade";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(9, 131);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(71, 15);
            this.Label15.TabIndex = 11;
            this.Label15.Text = "Quarto Item";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(9, 107);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(78, 15);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "Terceiro Item";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(9, 83);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(84, 15);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Segundo Item";
            // 
            // txtItem4
            // 
            this.txtItem4.Location = new System.Drawing.Point(107, 128);
            this.txtItem4.Name = "txtItem4";
            this.txtItem4.Size = new System.Drawing.Size(110, 21);
            this.txtItem4.TabIndex = 8;
            this.txtItem4.TextChanged += new System.EventHandler(this.txtItem4_TextChanged);
            // 
            // txtItem3
            // 
            this.txtItem3.Location = new System.Drawing.Point(107, 104);
            this.txtItem3.Name = "txtItem3";
            this.txtItem3.Size = new System.Drawing.Size(110, 21);
            this.txtItem3.TabIndex = 6;
            this.txtItem3.TextChanged += new System.EventHandler(this.txtItem3_TextChanged);
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(107, 80);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(110, 21);
            this.txtItem2.TabIndex = 4;
            this.txtItem2.TextChanged += new System.EventHandler(this.txtItem2_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(9, 59);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(81, 15);
            this.Label9.TabIndex = 11;
            this.Label9.Text = "Primeiro Item";
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(107, 56);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(110, 21);
            this.txtItem1.TabIndex = 2;
            this.txtItem1.TextChanged += new System.EventHandler(this.txtItem1_TextChanged);
            // 
            // txtItem4Qtd
            // 
            this.txtItem4Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem4Qtd.Location = new System.Drawing.Point(340, 126);
            this.txtItem4Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem4Qtd.Name = "txtItem4Qtd";
            this.txtItem4Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem4Qtd.TabIndex = 9;
            this.txtItem4Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem4Qtd.ValueChanged += new System.EventHandler(this.txtItem4Qtd_ValueChanged);
            // 
            // txtItem3Qtd
            // 
            this.txtItem3Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem3Qtd.Location = new System.Drawing.Point(340, 102);
            this.txtItem3Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem3Qtd.Name = "txtItem3Qtd";
            this.txtItem3Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem3Qtd.TabIndex = 7;
            this.txtItem3Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem3Qtd.ValueChanged += new System.EventHandler(this.txtItem3Qtd_ValueChanged);
            // 
            // txtItem2Qtd
            // 
            this.txtItem2Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem2Qtd.Location = new System.Drawing.Point(340, 78);
            this.txtItem2Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem2Qtd.Name = "txtItem2Qtd";
            this.txtItem2Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem2Qtd.TabIndex = 5;
            this.txtItem2Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem2Qtd.ValueChanged += new System.EventHandler(this.txtItem2Qtd_ValueChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(10, 23);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(64, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "GP TypeID";
            // 
            // txtItem1Qtd
            // 
            this.txtItem1Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem1Qtd.Location = new System.Drawing.Point(340, 54);
            this.txtItem1Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem1Qtd.Name = "txtItem1Qtd";
            this.txtItem1Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem1Qtd.TabIndex = 3;
            this.txtItem1Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem1Qtd.ValueChanged += new System.EventHandler(this.txtItem1Qtd_ValueChanged);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(108, 20);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(110, 21);
            this.txtTypeID.TabIndex = 0;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtItemProdQtd
            // 
            this.txtItemProdQtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItemProdQtd.Location = new System.Drawing.Point(339, 18);
            this.txtItemProdQtd.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtItemProdQtd.Name = "txtItemProdQtd";
            this.txtItemProdQtd.ReadOnly = true;
            this.txtItemProdQtd.Size = new System.Drawing.Size(72, 23);
            this.txtItemProdQtd.TabIndex = 1;
            this.txtItemProdQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemProdQtd.ValueChanged += new System.EventHandler(this.txtItemProdQtd_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.imgIcone);
            this.GroupBox1.Controls.Add(this.txtNome);
            this.GroupBox1.Controls.Add(this.lbContNome);
            this.GroupBox1.Controls.Add(this.label18);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cbAba);
            this.GroupBox1.Controls.Add(this.ckAtivo);
            this.GroupBox1.Controls.Add(this.txtIndex);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.txtNatural);
            this.GroupBox1.Location = new System.Drawing.Point(6, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(516, 88);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Opções";
            // 
            // imgIcone
            // 
            this.imgIcone.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgIcone.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.imgIcone.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
            this.imgIcone.Location = new System.Drawing.Point(6, 17);
            this.imgIcone.Name = "imgIcone";
            this.imgIcone.Size = new System.Drawing.Size(85, 63);
            this.imgIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcone.TabIndex = 15;
            this.imgIcone.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(140, 20);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(142, 21);
            this.txtNome.TabIndex = 12;
            // 
            // lbContNome
            // 
            this.lbContNome.AutoSize = true;
            this.lbContNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContNome.ForeColor = System.Drawing.Color.Gray;
            this.lbContNome.Location = new System.Drawing.Point(281, 23);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 13;
            this.lbContNome.Text = "0/64";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(95, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "Nome";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(98, 50);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Link";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(313, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Pagina";
            // 
            // cbAba
            // 
            this.cbAba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAba.FormattingEnabled = true;
            this.cbAba.Items.AddRange(new object[] {
            "ROOKIE",
            "BEGINNER",
            "JUNIOR",
            "EVENT"});
            this.cbAba.Location = new System.Drawing.Point(368, 18);
            this.cbAba.Name = "cbAba";
            this.cbAba.Size = new System.Drawing.Size(116, 23);
            this.cbAba.TabIndex = 1;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(340, 49);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(58, 19);
            this.ckAtivo.TabIndex = 2;
            this.ckAtivo.Text = "ATIVO";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(140, 47);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(79, 21);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(222, 50);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(47, 15);
            this.Label17.TabIndex = 11;
            this.Label17.Text = "Natural";
            // 
            // txtNatural
            // 
            this.txtNatural.Location = new System.Drawing.Point(271, 47);
            this.txtNatural.Name = "txtNatural";
            this.txtNatural.Size = new System.Drawing.Size(63, 21);
            this.txtNatural.TabIndex = 0;
            this.txtNatural.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(11, 299);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(483, 2);
            this.Label2.TabIndex = 21;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.GroupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 425);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Avançado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Time_End);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.Time_Start);
            this.groupBox4.Controls.Add(this.Time_Open);
            this.groupBox4.Controls.Add(this.label43);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Location = new System.Drawing.Point(8, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(514, 79);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GP Timers";
            // 
            // Time_End
            // 
            this.Time_End.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.Time_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time_End.Location = new System.Drawing.Point(341, 42);
            this.Time_End.Name = "Time_End";
            this.Time_End.Size = new System.Drawing.Size(141, 20);
            this.Time_End.TabIndex = 30;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(339, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(26, 13);
            this.label27.TabIndex = 29;
            this.label27.Text = "End";
            // 
            // Time_Start
            // 
            this.Time_Start.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.Time_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time_Start.Location = new System.Drawing.Point(175, 42);
            this.Time_Start.Name = "Time_Start";
            this.Time_Start.Size = new System.Drawing.Size(141, 20);
            this.Time_Start.TabIndex = 26;
            // 
            // Time_Open
            // 
            this.Time_Open.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.Time_Open.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time_Open.Location = new System.Drawing.Point(13, 42);
            this.Time_Open.Name = "Time_Open";
            this.Time_Open.Size = new System.Drawing.Size(141, 20);
            this.Time_Open.TabIndex = 26;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(173, 23);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 13);
            this.label43.TabIndex = 10;
            this.label43.Text = "Start";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(36, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(33, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "Open";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtScore2);
            this.GroupBox5.Controls.Add(this.txtScore1);
            this.GroupBox5.Controls.Add(this.cbClass);
            this.GroupBox5.Controls.Add(this.label42);
            this.GroupBox5.Controls.Add(this.txtScore3);
            this.GroupBox5.Controls.Add(this.nmrPangReward);
            this.GroupBox5.Controls.Add(this.cbHoleSize);
            this.GroupBox5.Controls.Add(this.txt_Ticket_TypeID);
            this.GroupBox5.Controls.Add(this.label29);
            this.GroupBox5.Controls.Add(this.txtTimeHole);
            this.GroupBox5.Controls.Add(this.txt_Ticket_Qntd);
            this.GroupBox5.Controls.Add(this.label26);
            this.GroupBox5.Controls.Add(this.label30);
            this.GroupBox5.Controls.Add(this.cbMap);
            this.GroupBox5.Controls.Add(this.label24);
            this.GroupBox5.Controls.Add(this.cbTotalHole);
            this.GroupBox5.Controls.Add(this.label34);
            this.GroupBox5.Controls.Add(this.cbMode);
            this.GroupBox5.Controls.Add(this.label25);
            this.GroupBox5.Controls.Add(this.label41);
            this.GroupBox5.Controls.Add(this.label40);
            this.GroupBox5.Controls.Add(this.label32);
            this.GroupBox5.Controls.Add(this.label35);
            this.GroupBox5.Controls.Add(this.label38);
            this.GroupBox5.Controls.Add(this.label31);
            this.GroupBox5.Controls.Add(this.txtInfo);
            this.GroupBox5.Location = new System.Drawing.Point(8, 3);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(514, 225);
            this.GroupBox5.TabIndex = 16;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Outras informacoes";
            // 
            // txtScore2
            // 
            this.txtScore2.Location = new System.Drawing.Point(292, 128);
            this.txtScore2.Name = "txtScore2";
            this.txtScore2.Size = new System.Drawing.Size(72, 20);
            this.txtScore2.TabIndex = 54;
            // 
            // txtScore1
            // 
            this.txtScore1.Location = new System.Drawing.Point(292, 104);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(72, 20);
            this.txtScore1.TabIndex = 53;
            // 
            // cbClass
            // 
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbClass.Location = new System.Drawing.Point(422, 110);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(86, 21);
            this.cbClass.TabIndex = 50;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(368, 113);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 13);
            this.label42.TabIndex = 49;
            this.label42.Text = "GP Class:";
            // 
            // txtScore3
            // 
            this.txtScore3.Location = new System.Drawing.Point(292, 154);
            this.txtScore3.Name = "txtScore3";
            this.txtScore3.Size = new System.Drawing.Size(72, 20);
            this.txtScore3.TabIndex = 55;
            // 
            // nmrPangReward
            // 
            this.nmrPangReward.Location = new System.Drawing.Point(292, 179);
            this.nmrPangReward.Name = "nmrPangReward";
            this.nmrPangReward.Size = new System.Drawing.Size(72, 20);
            this.nmrPangReward.TabIndex = 52;
            // 
            // cbHoleSize
            // 
            this.cbHoleSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoleSize.FormattingEnabled = true;
            this.cbHoleSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cbHoleSize.Location = new System.Drawing.Point(90, 19);
            this.cbHoleSize.Name = "cbHoleSize";
            this.cbHoleSize.Size = new System.Drawing.Size(116, 21);
            this.cbHoleSize.TabIndex = 48;
            // 
            // txt_Ticket_TypeID
            // 
            this.txt_Ticket_TypeID.Location = new System.Drawing.Point(90, 154);
            this.txt_Ticket_TypeID.Name = "txt_Ticket_TypeID";
            this.txt_Ticket_TypeID.Size = new System.Drawing.Size(116, 20);
            this.txt_Ticket_TypeID.TabIndex = 33;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 157);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 13);
            this.label29.TabIndex = 34;
            this.label29.Text = "Ticket TypeID:";
            // 
            // txtTimeHole
            // 
            this.txtTimeHole.Location = new System.Drawing.Point(90, 126);
            this.txtTimeHole.Name = "txtTimeHole";
            this.txtTimeHole.Size = new System.Drawing.Size(116, 20);
            this.txtTimeHole.TabIndex = 31;
            // 
            // txt_Ticket_Qntd
            // 
            this.txt_Ticket_Qntd.Location = new System.Drawing.Point(90, 180);
            this.txt_Ticket_Qntd.Name = "txt_Ticket_Qntd";
            this.txt_Ticket_Qntd.Size = new System.Drawing.Size(116, 20);
            this.txt_Ticket_Qntd.TabIndex = 35;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 129);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 32;
            this.label26.Text = "GP TimeHole:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 182);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 13);
            this.label30.TabIndex = 36;
            this.label30.Text = "Ticker Quantity:";
            // 
            // cbMap
            // 
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Items.AddRange(new object[] {
            "BLUE_LAGOON",
            "BLUE_WATER",
            "SEPIA_WIND",
            "WIND_HILL",
            "WIZ_WIZ",
            "WEST_WIZ",
            "BLUE_MOON",
            "SILVIA_CANNON",
            "ICE_CANNON",
            "WHITE_WIZ",
            "SHINNING_SAND",
            "PINK_WIND",
            "13 - DEEP_INFERNO",
            "ICE_SPA",
            "LOST_SEAWAY",
            "EASTERN_VALLEY",
            "CHRONICLE_1_CHAOS",
            "ICE_INFERNO",
            "WIZ_CITY",
            "ABBOT_MINE",
            "MYSTIC_RUINS"});
            this.cbMap.Location = new System.Drawing.Point(89, 73);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(117, 21);
            this.cbMap.TabIndex = 28;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "GP Map:";
            // 
            // cbTotalHole
            // 
            this.cbTotalHole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTotalHole.FormattingEnabled = true;
            this.cbTotalHole.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12",
            "18"});
            this.cbTotalHole.Location = new System.Drawing.Point(90, 46);
            this.cbTotalHole.Name = "cbTotalHole";
            this.cbTotalHole.Size = new System.Drawing.Size(116, 21);
            this.cbTotalHole.TabIndex = 11;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(20, 49);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 13);
            this.label34.TabIndex = 10;
            this.label34.Text = "Total Hole:";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "FRONT",
            "BACK",
            "RANDOM",
            "SHUFFLE",
            "REPEAT",
            "SHUFFLE_COURSE"});
            this.cbMode.Location = new System.Drawing.Point(89, 100);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(117, 21);
            this.cbMode.TabIndex = 30;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 103);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "GP Mode:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(20, 22);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(55, 13);
            this.label41.TabIndex = 47;
            this.label41.Text = "Hole Size:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(208, 181);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 13);
            this.label40.TabIndex = 46;
            this.label40.Text = "PangReward:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(208, 157);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 13);
            this.label32.TabIndex = 44;
            this.label32.Text = "Score Bot Max:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(208, 132);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 13);
            this.label35.TabIndex = 42;
            this.label35.Text = "Score Bot Med:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(208, 108);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 13);
            this.label38.TabIndex = 40;
            this.label38.Text = "Score Bot Min:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(208, 13);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(28, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "Info:";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(236, 13);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(272, 90);
            this.txtInfo.TabIndex = 37;
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 454);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(536, 70);
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
            this.btnNovo.Enabled = false;
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
            this.btnRemover.Enabled = false;
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
            this.btnBackup.Enabled = false;
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
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
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
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::PangyaSuiteFiles.Properties.Resources.document_editing;
            this.pictureBox7.Location = new System.Drawing.Point(3, 4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 1;
            this.pictureBox7.TabStop = false;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 0;
            // 
            // PictureBox4
            // 
            this.PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
            this.PictureBox4.Location = new System.Drawing.Point(494, 24);
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
            this.PictureBox1.Location = new System.Drawing.Point(297, 24);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Visible = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            this.txtPesquisa.Location = new System.Drawing.Point(319, 24);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(292, 20);
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
            // ComboBox1
            // 
            this.ComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.ItemHeight = 13;
            this.ComboBox1.Items.AddRange(new object[] {
            "Todos",
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
            this.ComboBox1.Location = new System.Drawing.Point(595, 16);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(131, 21);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.Visible = false;
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
            // bwGerarSql
            // 
            this.bwGerarSql.WorkerReportsProgress = true;
            this.bwGerarSql.WorkerSupportsCancellation = true;
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
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Salvar arquivo Part.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Part.iff)";
            // 
            // diagSalvarSql
            // 
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "Part.iff.sql";
            this.diagSalvarSql.Filter = "Imagem (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Salvar arquivo SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            // 
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Image = global::PangyaSuiteFiles.Properties.Resources.fred;
            this.imgPersonagem.Location = new System.Drawing.Point(555, 55);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // FrmGrandPrixDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 600);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmGrandPrixDataEditor";
            this.Text = "GrandPrixData - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmGrandPrixDataEditor_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem5Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPangReward)).EndInit();
            this.gbBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
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

		[AccessedThroughProperty("Panel3")]
		private Panel Panel3;

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

		[AccessedThroughProperty("ckAtivo")]
		private CheckBox ckAtivo;

		[AccessedThroughProperty("btnAbrirArquivo")]
		private ToolStripButton btnAbrirArquivo;

		[AccessedThroughProperty("diagAbrirArquivo")]
		private OpenFileDialog diagAbrirArquivo;

		[AccessedThroughProperty("ToolStripStatusLabel1")]
		private ToolStripStatusLabel ToolStripStatusLabel1;

		[AccessedThroughProperty("lbTotalItens")]
		private ToolStripStatusLabel lbTotalItens;

		[AccessedThroughProperty("Label2")]
		private Label Label2;

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

		[AccessedThroughProperty("Panel2")]
		private Panel Panel2;

		[AccessedThroughProperty("diagSalvarArquivo")]
		private SaveFileDialog diagSalvarArquivo;

		[AccessedThroughProperty("menuSalvarComo")]
		private ToolStripButton menuSalvarComo;

		[AccessedThroughProperty("PictureBox2")]
		private PictureBox PictureBox2;

		[AccessedThroughProperty("lbArquivo")]
		private Label lbArquivo;

		[AccessedThroughProperty("ToolStripStatusLabel4")]
		private ToolStripStatusLabel ToolStripStatusLabel4;

		[AccessedThroughProperty("lbIndices")]
		private ToolStripStatusLabel lbIndices;

		[AccessedThroughProperty("pbStatus")]
		private ToolStripProgressBar pbStatus;

		[AccessedThroughProperty("imgPersonagem")]
		private PictureBox imgPersonagem;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox ComboBox1;

		[AccessedThroughProperty("txtTypeID")]
		private TextBox txtTypeID;

		[AccessedThroughProperty("diagSalvarSql")]
		private SaveFileDialog diagSalvarSql;

		[AccessedThroughProperty("bwSalvar")]
		private BackgroundWorker bwSalvar;

		[AccessedThroughProperty("bwGerarSql")]
		private BackgroundWorker bwGerarSql;

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

		[AccessedThroughProperty("ToolTip1")]
		private ToolTip ToolTip1;

		[AccessedThroughProperty("Label1")]
		private Label Label1;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox GroupBox1;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox GroupBox2;

		[AccessedThroughProperty("txtRes1")]
		private TextBox txtRes1;

		[AccessedThroughProperty("img1")]
		private PictureBox img1;

		[AccessedThroughProperty("txtRes4")]
		private TextBox txtRes4;

		[AccessedThroughProperty("txtRes3")]
		private TextBox txtRes3;

		[AccessedThroughProperty("txtRes2")]
		private TextBox txtRes2;

		[AccessedThroughProperty("img4")]
		private PictureBox img4;

		[AccessedThroughProperty("img3")]
		private PictureBox img3;

		[AccessedThroughProperty("img2")]
		private PictureBox img2;

		[AccessedThroughProperty("GroupBox3")]
		private GroupBox GroupBox3;

		[AccessedThroughProperty("Label6")]
		private Label Label6;

		[AccessedThroughProperty("Label3")]
		private Label Label3;

		[AccessedThroughProperty("cbAba")]
		private ComboBox cbAba;

		[AccessedThroughProperty("Label7")]
		private Label Label7;

		[AccessedThroughProperty("txtItemProdQtd")]
		private NumericUpDown txtItemProdQtd;

		[AccessedThroughProperty("Label16")]
		private Label Label16;

		[AccessedThroughProperty("Label14")]
		private Label Label14;

		[AccessedThroughProperty("Label12")]
		private Label Label12;

		[AccessedThroughProperty("Label10")]
		private Label Label10;

		[AccessedThroughProperty("Label15")]
		private Label Label15;

		[AccessedThroughProperty("Label13")]
		private Label Label13;

		[AccessedThroughProperty("Label11")]
		private Label Label11;

		[AccessedThroughProperty("txtItem4")]
		private TextBox txtItem4;

		[AccessedThroughProperty("txtItem3")]
		private TextBox txtItem3;

		[AccessedThroughProperty("txtItem2")]
		private TextBox txtItem2;

		[AccessedThroughProperty("Label9")]
		private Label Label9;

		[AccessedThroughProperty("txtItem1")]
		private TextBox txtItem1;

		[AccessedThroughProperty("txtItem4Qtd")]
		private NumericUpDown txtItem4Qtd;

		[AccessedThroughProperty("txtItem3Qtd")]
		private NumericUpDown txtItem3Qtd;

		[AccessedThroughProperty("txtItem2Qtd")]
		private NumericUpDown txtItem2Qtd;

		[AccessedThroughProperty("txtItem1Qtd")]
		private NumericUpDown txtItem1Qtd;

		[AccessedThroughProperty("txtIndex")]
		private TextBox txtIndex;

		[AccessedThroughProperty("Button4")]
		private Button Button4;

		[AccessedThroughProperty("Button3")]
		private Button Button3;

		[AccessedThroughProperty("Button2")]
		private Button Button2;

		[AccessedThroughProperty("Button1")]
		private Button Button1;

		[AccessedThroughProperty("Label17")]
		private Label Label17;

		[AccessedThroughProperty("txtU6")]
		private TextBox txtNatural;

		public string Arquivo;

		private GrandPrixData oIff;

		public GrandPrixDataCollection lsItens;

		public GrandPrixDataCollection lsTemp;

		public byte[] bStart;

		private bool Alterado;

		private BindingSource bs;

		private int lastRow;

		public long qtdItem;

#pragma warning disable CS0169 // O campo "FrmGrandPrixDataEditor.arquivog" nunca é usado
		private string arquivog;
#pragma warning restore CS0169 // O campo "FrmGrandPrixDataEditor.arquivog" nunca é usado

		private string caminho;
        #endregion

        private TextBox txtNome;
        private Label lbContNome;
        private Label label18;
        private DataGridView ListaItem;
        private Panel Panel1;
        private Label Label39;
        private PictureBox pictureBox3;
        private PictureBox pictureBox6;
        private ComboBox ComboBox2;
        private TextBox textBox1;
        private Label Label19;
        private Label Label37;
        private PictureBox imgIcone;
        private Panel panel5;
        private PictureBox pictureBox7;
        private Label label21;
#pragma warning disable CS0169 // O campo "FrmGrandPrixDataEditor.Clonagem" nunca é usado
        private GrandPrixData Clonagem;
#pragma warning restore CS0169 // O campo "FrmGrandPrixDataEditor.Clonagem" nunca é usado
        private ComboBox cbPage;
        private Label label22;
        private TabPage tabPage2;
        private Button button5;
        private Label label8;
        private Label label23;
        private TextBox txtItem5;
        private NumericUpDown txtItem5Qtd;
        private TextBox textBox2;
        private PictureBox pictureBox8;
        private GroupBox GroupBox5;
        private ComboBox cbTotalHole;
        private Label label34;
        private ComboBox cbMode;
        private Label label25;
        private ComboBox cbMap;
        private Label label24;
        private Label label26;
        private TextBox txtTimeHole;
        private Label label30;
        private TextBox txt_Ticket_Qntd;
        private Label label29;
        private TextBox txt_Ticket_TypeID;
        private Label label40;
        private Label label32;
        private Label label35;
        private Label label38;
        private Label label31;
        private TextBox txtInfo;
        private ComboBox cbHoleSize;
        private Label label41;
        private ComboBox cbClass;
        private Label label42;
        private NumericUpDown nmrPangReward;
        private GroupBox groupBox4;
        private DateTimePicker Time_Start;
        private DateTimePicker Time_Open;
        private Label label43;
        private Label label44;
        private DateTimePicker Time_End;
        private Label label27;
        private TextBox txtScore2;
        private TextBox txtScore1;
        private TextBox txtScore3;
    }
}