using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
    partial class FrmAuxPartEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuxPartEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.menuMassa = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.AlterarDescontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeAllItensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DesativarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AtivarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.LevelMinimoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ApagarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGerarCache = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label39 = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.att2Curva = new System.Windows.Forms.NumericUpDown();
            this.attCurva = new System.Windows.Forms.NumericUpDown();
            this.att2Spin = new System.Windows.Forms.NumericUpDown();
            this.attSpin = new System.Windows.Forms.NumericUpDown();
            this.att2Precisao = new System.Windows.Forms.NumericUpDown();
            this.attPrecisao = new System.Windows.Forms.NumericUpDown();
            this.att2Controle = new System.Windows.Forms.NumericUpDown();
            this.attControle = new System.Windows.Forms.NumericUpDown();
            this.att2Forca = new System.Windows.Forms.NumericUpDown();
            this.attForca = new System.Windows.Forms.NumericUpDown();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.barraCurva = new System.Windows.Forms.Panel();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.barraSpin = new System.Windows.Forms.Panel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.barraPrecisao = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.barraControle = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.barraForca = new System.Windows.Forms.Panel();
            this.Label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnVerificarTYPEID = new System.Windows.Forms.Button();
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.ckDesativado = new System.Windows.Forms.CheckBox();
            this.ckNormal = new System.Windows.Forms.CheckBox();
            this.ckHot = new System.Windows.Forms.CheckBox();
            this.ckGift = new System.Windows.Forms.CheckBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.rbLevelMax = new System.Windows.Forms.RadioButton();
            this.rbLevelMin = new System.Windows.Forms.RadioButton();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.imgIcone = new System.Windows.Forms.PictureBox();
            this.txtIcone = new System.Windows.Forms.TextBox();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lbContNome = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.gbTempoVenda = new System.Windows.Forms.GroupBox();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.BonusFlag = new System.Windows.Forms.NumericUpDown();
            this.BonusPangRate = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.EfeitoExpRate = new System.Windows.Forms.NumericUpDown();
            this.EfeitoPangRate = new System.Windows.Forms.NumericUpDown();
            this.EfeitoGauge = new System.Windows.Forms.NumericUpDown();
            this.EfeitoDropRate = new System.Windows.Forms.NumericUpDown();
            this.Efeito_PowerDrive = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.txtSlotItem = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtPrice365Day = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPrice30Day = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice15Day = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice7Day = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice1Day = new System.Windows.Forms.NumericUpDown();
            this.Label19 = new System.Windows.Forms.Label();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.Panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.att2Curva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attCurva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Spin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Precisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attPrecisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Controle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attControle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Forca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attForca)).BeginInit();
            this.Panel9.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BonusFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusPangRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoExpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoPangRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoDropRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Efeito_PowerDrive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice365Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice30Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice15Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice7Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice1Day)).BeginInit();
            this.gbBotoes.SuspendLayout();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 526);
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
            this.menuSalvarComo,
            this.menuMassa,
            this.menuGerarCache});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(809, 40);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirArquivo.Image")));
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
            this.menuSalvarComo.Image = ((System.Drawing.Image)(resources.GetObject("menuSalvarComo.Image")));
            this.menuSalvarComo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalvarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSalvarComo.Name = "menuSalvarComo";
            this.menuSalvarComo.Size = new System.Drawing.Size(36, 37);
            this.menuSalvarComo.ToolTipText = "Salvar como";
            // 
            // menuMassa
            // 
            this.menuMassa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMassa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_0,
            this.AlterarDescontoToolStripMenuItem,
            this.activeAllItensToolStripMenuItem,
            this.DesativarTodosToolStripMenuItem,
            this.AtivarTodosToolStripMenuItem,
            this.ToolStripMenuItem_1,
            this.ToolStripMenuItem_2,
            this.LevelMinimoToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.ApagarTodosToolStripMenuItem});
            this.menuMassa.Image = ((System.Drawing.Image)(resources.GetObject("menuMassa.Image")));
            this.menuMassa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMassa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuMassa.Name = "menuMassa";
            this.menuMassa.Size = new System.Drawing.Size(45, 37);
            this.menuMassa.Text = "ToolStripDropDownButton1";
            this.menuMassa.ToolTipText = "Operações em massa";
            this.menuMassa.Visible = false;
            // 
            // ToolStripMenuItem_0
            // 
            this.ToolStripMenuItem_0.Name = "ToolStripMenuItem_0";
            this.ToolStripMenuItem_0.Size = new System.Drawing.Size(176, 22);
            this.ToolStripMenuItem_0.Text = "Alterar preço";
            // 
            // AlterarDescontoToolStripMenuItem
            // 
            this.AlterarDescontoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AlterarDescontoToolStripMenuItem.Image")));
            this.AlterarDescontoToolStripMenuItem.Name = "AlterarDescontoToolStripMenuItem";
            this.AlterarDescontoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.AlterarDescontoToolStripMenuItem.Text = "Alterar Desconto";
            // 
            // activeAllItensToolStripMenuItem
            // 
            this.activeAllItensToolStripMenuItem.Name = "activeAllItensToolStripMenuItem";
            this.activeAllItensToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.activeAllItensToolStripMenuItem.Text = "Active All Itens";
            this.activeAllItensToolStripMenuItem.Click += new System.EventHandler(this.activeAllItensToolStripMenuItem_Click);
            // 
            // DesativarTodosToolStripMenuItem
            // 
            this.DesativarTodosToolStripMenuItem.Enabled = false;
            this.DesativarTodosToolStripMenuItem.Name = "DesativarTodosToolStripMenuItem";
            this.DesativarTodosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.DesativarTodosToolStripMenuItem.Text = "Desativar todos";
            // 
            // AtivarTodosToolStripMenuItem
            // 
            this.AtivarTodosToolStripMenuItem.Enabled = false;
            this.AtivarTodosToolStripMenuItem.Name = "AtivarTodosToolStripMenuItem";
            this.AtivarTodosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.AtivarTodosToolStripMenuItem.Text = "Ativar todos";
            // 
            // ToolStripMenuItem_1
            // 
            this.ToolStripMenuItem_1.Enabled = false;
            this.ToolStripMenuItem_1.Name = "ToolStripMenuItem_1";
            this.ToolStripMenuItem_1.Size = new System.Drawing.Size(176, 22);
            this.ToolStripMenuItem_1.Text = "Mudar marcação";
            // 
            // ToolStripMenuItem_2
            // 
            this.ToolStripMenuItem_2.Enabled = false;
            this.ToolStripMenuItem_2.Name = "ToolStripMenuItem_2";
            this.ToolStripMenuItem_2.Size = new System.Drawing.Size(176, 22);
            this.ToolStripMenuItem_2.Text = "Remover marcação";
            // 
            // LevelMinimoToolStripMenuItem
            // 
            this.LevelMinimoToolStripMenuItem.Enabled = false;
            this.LevelMinimoToolStripMenuItem.Name = "LevelMinimoToolStripMenuItem";
            this.LevelMinimoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.LevelMinimoToolStripMenuItem.Text = "Alterar Level";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // ApagarTodosToolStripMenuItem
            // 
            this.ApagarTodosToolStripMenuItem.Enabled = false;
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            this.ApagarTodosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ApagarTodosToolStripMenuItem.Text = "Apagar todos";
            // 
            // menuGerarCache
            // 
            this.menuGerarCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuGerarCache.Enabled = false;
            this.menuGerarCache.Image = ((System.Drawing.Image)(resources.GetObject("menuGerarCache.Image")));
            this.menuGerarCache.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuGerarCache.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuGerarCache.Name = "menuGerarCache";
            this.menuGerarCache.Size = new System.Drawing.Size(36, 37);
            this.menuGerarCache.Text = "ToolStripDropDownButton1";
            this.menuGerarCache.ToolTipText = "Gerar Cache de Imagens";
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
            this.SplitContainer1.Panel1.Controls.Add(this.Panel1);
            this.SplitContainer1.Panel1MinSize = 200;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.Panel4);
            this.SplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.SplitContainer1.Panel2MinSize = 0;
            this.SplitContainer1.Size = new System.Drawing.Size(809, 486);
            this.SplitContainer1.SplitterDistance = 277;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Controls.Add(this.ComboBox1);
            this.Panel3.Controls.Add(this.imgPersonagem);
            this.Panel3.Controls.Add(this.Label36);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(277, 390);
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
            this.ListaItem.Size = new System.Drawing.Size(277, 390);
            this.ListaItem.TabIndex = 0;
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
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
            this.ComboBox1.Location = new System.Drawing.Point(103, 177);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(89, 21);
            this.ComboBox1.TabIndex = 14;
            this.ComboBox1.Visible = false;
            // 
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Image = ((System.Drawing.Image)(resources.GetObject("imgPersonagem.Image")));
            this.imgPersonagem.Location = new System.Drawing.Point(63, 164);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 15;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(100, 161);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(66, 13);
            this.Label36.TabIndex = 16;
            this.Label36.Text = "Personagem";
            this.Label36.Visible = false;
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
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
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
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.Label33);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 417);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(277, 69);
            this.Panel1.TabIndex = 0;
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 27);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(270, 2);
            this.Label39.TabIndex = 22;
            // 
            // imgStatus
            // 
            this.imgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgStatus.Image = ((System.Drawing.Image)(resources.GetObject("imgStatus.Image")));
            this.imgStatus.Location = new System.Drawing.Point(5, 30);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(35, 35);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgStatus.TabIndex = 1;
            this.imgStatus.TabStop = false;
            // 
            // PictureBox4
            // 
            this.PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox4.Image")));
            this.PictureBox4.Location = new System.Drawing.Point(202, 5);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(20, 20);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox4.TabIndex = 1;
            this.PictureBox4.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(5, 5);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
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
            this.ComboBox2.Location = new System.Drawing.Point(46, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(223, 21);
            this.ComboBox2.TabIndex = 1;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            this.txtPesquisa.Location = new System.Drawing.Point(27, 5);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(173, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label33.Location = new System.Drawing.Point(224, 7);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(14, 16);
            this.Label33.TabIndex = 10;
            this.Label33.Text = "0";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(46, 30);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(37, 13);
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(524, 480);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.TabPage2);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(514, 404);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.Panel10);
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label29);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.rbLevelMax);
            this.TabPage1.Controls.Add(this.rbLevelMin);
            this.TabPage1.Controls.Add(this.cbLevel);
            this.TabPage1.Controls.Add(this.cbTipo);
            this.TabPage1.Controls.Add(this.ckAtivo);
            this.TabPage1.Controls.Add(this.imgIcone);
            this.TabPage1.Controls.Add(this.txtIcone);
            this.TabPage1.Controls.Add(this.txtTypeID);
            this.TabPage1.Controls.Add(this.Label6);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.txtDesconto);
            this.TabPage1.Controls.Add(this.txtPreco);
            this.TabPage1.Controls.Add(this.txtNome);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.lbContNome);
            this.TabPage1.Controls.Add(this.Label18);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.gbTempoVenda);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(506, 378);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Informações Básicas";
            // 
            // Panel10
            // 
            this.Panel10.Controls.Add(this.att2Curva);
            this.Panel10.Controls.Add(this.attCurva);
            this.Panel10.Controls.Add(this.att2Spin);
            this.Panel10.Controls.Add(this.attSpin);
            this.Panel10.Controls.Add(this.att2Precisao);
            this.Panel10.Controls.Add(this.attPrecisao);
            this.Panel10.Controls.Add(this.att2Controle);
            this.Panel10.Controls.Add(this.attControle);
            this.Panel10.Controls.Add(this.att2Forca);
            this.Panel10.Controls.Add(this.attForca);
            this.Panel10.Controls.Add(this.Panel9);
            this.Panel10.Controls.Add(this.Panel8);
            this.Panel10.Controls.Add(this.Panel7);
            this.Panel10.Controls.Add(this.Panel6);
            this.Panel10.Controls.Add(this.Panel5);
            this.Panel10.Controls.Add(this.Label17);
            this.Panel10.Controls.Add(this.label11);
            this.Panel10.Controls.Add(this.Label14);
            this.Panel10.Controls.Add(this.Label13);
            this.Panel10.Controls.Add(this.Label12);
            this.Panel10.Controls.Add(this.label15);
            this.Panel10.Controls.Add(this.label16);
            this.Panel10.Controls.Add(this.label21);
            this.Panel10.Controls.Add(this.label32);
            this.Panel10.Location = new System.Drawing.Point(0, 223);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(372, 154);
            this.Panel10.TabIndex = 29;
            // 
            // att2Curva
            // 
            this.att2Curva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att2Curva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att2Curva.Location = new System.Drawing.Point(316, 123);
            this.att2Curva.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.att2Curva.Name = "att2Curva";
            this.att2Curva.Size = new System.Drawing.Size(44, 21);
            this.att2Curva.TabIndex = 20;
            this.att2Curva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attCurva
            // 
            this.attCurva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attCurva.Location = new System.Drawing.Point(259, 123);
            this.attCurva.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attCurva.Name = "attCurva";
            this.attCurva.Size = new System.Drawing.Size(44, 21);
            this.attCurva.TabIndex = 19;
            this.attCurva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // att2Spin
            // 
            this.att2Spin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att2Spin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att2Spin.Location = new System.Drawing.Point(316, 98);
            this.att2Spin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.att2Spin.Name = "att2Spin";
            this.att2Spin.Size = new System.Drawing.Size(44, 21);
            this.att2Spin.TabIndex = 18;
            this.att2Spin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attSpin
            // 
            this.attSpin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attSpin.Location = new System.Drawing.Point(259, 98);
            this.attSpin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attSpin.Name = "attSpin";
            this.attSpin.Size = new System.Drawing.Size(44, 21);
            this.attSpin.TabIndex = 17;
            this.attSpin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // att2Precisao
            // 
            this.att2Precisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att2Precisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att2Precisao.Location = new System.Drawing.Point(316, 73);
            this.att2Precisao.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.att2Precisao.Name = "att2Precisao";
            this.att2Precisao.Size = new System.Drawing.Size(44, 21);
            this.att2Precisao.TabIndex = 16;
            this.att2Precisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attPrecisao
            // 
            this.attPrecisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attPrecisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attPrecisao.Location = new System.Drawing.Point(259, 73);
            this.attPrecisao.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attPrecisao.Name = "attPrecisao";
            this.attPrecisao.Size = new System.Drawing.Size(44, 21);
            this.attPrecisao.TabIndex = 15;
            this.attPrecisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // att2Controle
            // 
            this.att2Controle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att2Controle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att2Controle.Location = new System.Drawing.Point(316, 48);
            this.att2Controle.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.att2Controle.Name = "att2Controle";
            this.att2Controle.Size = new System.Drawing.Size(44, 21);
            this.att2Controle.TabIndex = 14;
            this.att2Controle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attControle
            // 
            this.attControle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attControle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attControle.Location = new System.Drawing.Point(259, 48);
            this.attControle.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attControle.Name = "attControle";
            this.attControle.Size = new System.Drawing.Size(44, 21);
            this.attControle.TabIndex = 13;
            this.attControle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // att2Forca
            // 
            this.att2Forca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.att2Forca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.att2Forca.Location = new System.Drawing.Point(316, 24);
            this.att2Forca.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.att2Forca.Name = "att2Forca";
            this.att2Forca.Size = new System.Drawing.Size(44, 21);
            this.att2Forca.TabIndex = 12;
            this.att2Forca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attForca
            // 
            this.attForca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attForca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attForca.Location = new System.Drawing.Point(259, 24);
            this.attForca.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attForca.Name = "attForca";
            this.attForca.Size = new System.Drawing.Size(44, 21);
            this.attForca.TabIndex = 11;
            this.attForca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Panel9
            // 
            this.Panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel9.Controls.Add(this.barraCurva);
            this.Panel9.Location = new System.Drawing.Point(78, 125);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(177, 18);
            this.Panel9.TabIndex = 24;
            // 
            // barraCurva
            // 
            this.barraCurva.BackColor = System.Drawing.Color.SlateBlue;
            this.barraCurva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barraCurva.Location = new System.Drawing.Point(0, 0);
            this.barraCurva.Name = "barraCurva";
            this.barraCurva.Size = new System.Drawing.Size(0, 18);
            this.barraCurva.TabIndex = 24;
            // 
            // Panel8
            // 
            this.Panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel8.Controls.Add(this.barraSpin);
            this.Panel8.Location = new System.Drawing.Point(78, 100);
            this.Panel8.Name = "Panel8";
            this.Panel8.Size = new System.Drawing.Size(177, 18);
            this.Panel8.TabIndex = 24;
            // 
            // barraSpin
            // 
            this.barraSpin.BackColor = System.Drawing.Color.MediumTurquoise;
            this.barraSpin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barraSpin.Location = new System.Drawing.Point(0, 0);
            this.barraSpin.Name = "barraSpin";
            this.barraSpin.Size = new System.Drawing.Size(0, 18);
            this.barraSpin.TabIndex = 24;
            // 
            // Panel7
            // 
            this.Panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel7.Controls.Add(this.barraPrecisao);
            this.Panel7.Location = new System.Drawing.Point(78, 75);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(177, 18);
            this.Panel7.TabIndex = 24;
            // 
            // barraPrecisao
            // 
            this.barraPrecisao.BackColor = System.Drawing.Color.LimeGreen;
            this.barraPrecisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barraPrecisao.Location = new System.Drawing.Point(0, 0);
            this.barraPrecisao.Name = "barraPrecisao";
            this.barraPrecisao.Size = new System.Drawing.Size(0, 18);
            this.barraPrecisao.TabIndex = 24;
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel6.Controls.Add(this.barraControle);
            this.Panel6.Location = new System.Drawing.Point(78, 50);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(177, 18);
            this.Panel6.TabIndex = 24;
            // 
            // barraControle
            // 
            this.barraControle.BackColor = System.Drawing.Color.Orange;
            this.barraControle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barraControle.Location = new System.Drawing.Point(0, 0);
            this.barraControle.Name = "barraControle";
            this.barraControle.Size = new System.Drawing.Size(0, 18);
            this.barraControle.TabIndex = 24;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.barraForca);
            this.Panel5.Location = new System.Drawing.Point(78, 25);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(177, 18);
            this.Panel5.TabIndex = 24;
            // 
            // barraForca
            // 
            this.barraForca.BackColor = System.Drawing.Color.Red;
            this.barraForca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barraForca.Location = new System.Drawing.Point(0, 0);
            this.barraForca.Name = "barraForca";
            this.barraForca.Size = new System.Drawing.Size(0, 18);
            this.barraForca.TabIndex = 24;
            // 
            // Label17
            // 
            this.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label17.Location = new System.Drawing.Point(309, 11);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(3, 135);
            this.Label17.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(12, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(356, 2);
            this.label11.TabIndex = 21;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(29, 127);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(47, 15);
            this.Label14.TabIndex = 7;
            this.Label14.Text = "CURVA";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(41, 102);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(35, 15);
            this.Label13.TabIndex = 7;
            this.Label13.Text = "SPIN";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(8, 77);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(68, 15);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "PRECISÃO";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "CONTROLE";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "FORÇA";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(316, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 15);
            this.label21.TabIndex = 10;
            this.label21.Text = "Espaço";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(258, 8);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 15);
            this.label32.TabIndex = 10;
            this.label32.Text = "Atributo";
            // 
            // btnVerificarTYPEID
            // 
            this.btnVerificarTYPEID.Image = ((System.Drawing.Image)(resources.GetObject("btnVerificarTYPEID.Image")));
            this.btnVerificarTYPEID.Location = new System.Drawing.Point(257, 41);
            this.btnVerificarTYPEID.Name = "btnVerificarTYPEID";
            this.btnVerificarTYPEID.Size = new System.Drawing.Size(25, 25);
            this.btnVerificarTYPEID.TabIndex = 28;
            this.ToolTip1.SetToolTip(this.btnVerificarTYPEID, "Verificar TYPEID");
            this.btnVerificarTYPEID.UseVisualStyleBackColor = true;
            // 
            // ckTempoAtivo
            // 
            this.ckTempoAtivo.AutoSize = true;
            this.ckTempoAtivo.BackColor = System.Drawing.Color.Transparent;
            this.ckTempoAtivo.Location = new System.Drawing.Point(318, 159);
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            this.ckTempoAtivo.Size = new System.Drawing.Size(51, 19);
            this.ckTempoAtivo.TabIndex = 27;
            this.ckTempoAtivo.Text = "Ativo";
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckDisplay);
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            this.GroupBox1.Location = new System.Drawing.Point(379, 148);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 184);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Marcação";
            // 
            // ckNew
            // 
            this.ckNew.AutoSize = true;
            this.ckNew.Location = new System.Drawing.Point(11, 23);
            this.ckNew.Name = "ckNew";
            this.ckNew.Size = new System.Drawing.Size(81, 19);
            this.ckNew.TabIndex = 0;
            this.ckNew.Text = "Item Novo";
            this.ckNew.UseVisualStyleBackColor = true;
            // 
            // ckDesativado
            // 
            this.ckDesativado.AutoSize = true;
            this.ckDesativado.Location = new System.Drawing.Point(11, 148);
            this.ckDesativado.Name = "ckDesativado";
            this.ckDesativado.Size = new System.Drawing.Size(61, 19);
            this.ckDesativado.TabIndex = 5;
            this.ckDesativado.Text = "Oculto";
            this.ckDesativado.UseVisualStyleBackColor = true;
            // 
            // ckNormal
            // 
            this.ckNormal.AutoSize = true;
            this.ckNormal.Location = new System.Drawing.Point(11, 101);
            this.ckNormal.Name = "ckNormal";
            this.ckNormal.Size = new System.Drawing.Size(94, 19);
            this.ckNormal.TabIndex = 5;
            this.ckNormal.Text = "Item Normal";
            this.ckNormal.UseVisualStyleBackColor = true;
            // 
            // ckHot
            // 
            this.ckHot.AutoSize = true;
            this.ckHot.Location = new System.Drawing.Point(11, 49);
            this.ckHot.Name = "ckHot";
            this.ckHot.Size = new System.Drawing.Size(93, 19);
            this.ckHot.TabIndex = 1;
            this.ckHot.Text = "Item Quente";
            this.ckHot.UseVisualStyleBackColor = true;
            // 
            // ckGift
            // 
            this.ckGift.AutoSize = true;
            this.ckGift.Location = new System.Drawing.Point(11, 75);
            this.ckGift.Name = "ckGift";
            this.ckGift.Size = new System.Drawing.Size(76, 19);
            this.ckGift.TabIndex = 3;
            this.ckGift.Text = "Presente";
            this.ckGift.UseVisualStyleBackColor = true;
            // 
            // Label29
            // 
            this.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label29.Location = new System.Drawing.Point(13, 143);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(483, 2);
            this.Label29.TabIndex = 21;
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(13, 107);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(483, 2);
            this.Label2.TabIndex = 21;
            // 
            // rbLevelMax
            // 
            this.rbLevelMax.AutoSize = true;
            this.rbLevelMax.Location = new System.Drawing.Point(397, 77);
            this.rbLevelMax.Name = "rbLevelMax";
            this.rbLevelMax.Size = new System.Drawing.Size(99, 19);
            this.rbLevelMax.TabIndex = 7;
            this.rbLevelMax.Text = "Level Máximo";
            this.rbLevelMax.UseVisualStyleBackColor = true;
            // 
            // rbLevelMin
            // 
            this.rbLevelMin.AutoSize = true;
            this.rbLevelMin.Checked = true;
            this.rbLevelMin.Location = new System.Drawing.Point(297, 77);
            this.rbLevelMin.Name = "rbLevelMin";
            this.rbLevelMin.Size = new System.Drawing.Size(97, 19);
            this.rbLevelMin.TabIndex = 6;
            this.rbLevelMin.TabStop = true;
            this.rbLevelMin.Text = "Level Mínimo";
            this.rbLevelMin.UseVisualStyleBackColor = true;
            // 
            // cbLevel
            // 
            this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Items.AddRange(new object[] {
            "00 - Rookie F",
            "01 - Rookie E",
            "02 - Rookie D",
            "03 - Rookie C",
            "04 - Rookie B",
            "05 - Rookie A",
            "06 - Beginner E",
            "07 - Beginner D",
            "08 - Beginner C",
            "09 - Beginner B",
            "10 - Beginner A",
            "11 - Junior E",
            "12 - Junior D",
            "13 - Junior C",
            "14 - Junior B",
            "15 - Junior A",
            "16 - Senior E",
            "17 - Senior D",
            "18 - Senior C",
            "19 - Senior B",
            "20 - Senior A",
            "21 - Amateur E",
            "22 - Amateur D",
            "23 - Amateur C",
            "24 - Amateur B",
            "25 - Amateur A",
            "26 - Semi-Pro E",
            "27 - Semi-Pro D",
            "28 - Semi-Pro C",
            "29 - Semi-Pro B",
            "30 - Semi-Pro A",
            "31 - Pro E",
            "32 - Pro D",
            "33 - Pro C",
            "34 - Pro B",
            "35 - Pro A",
            "36 - National Pro E",
            "37 - National Pro D",
            "38 - National Pro C",
            "39 - National Pro B",
            "40 - National Pro A",
            "41 - World Pro E",
            "42 - World Pro D",
            "43 - World Pro C",
            "44 - World Pro B",
            "45 - World Pro A",
            "46 - Master E",
            "47 - Master D",
            "48 - Master C",
            "49 - Master B",
            "50 - Master A",
            "51 - Top Master E",
            "52 - Top Master D",
            "53 - Top Master C",
            "54 - Top Master B",
            "55 - Top Master A",
            "56 - Jungle Master E",
            "57 - Jungle Master D",
            "58 - Jungle Master C",
            "59 - Jungle Master B",
            "60 - Jungle Master A",
            "61 - Legend E",
            "62 - Legend D",
            "63 - Legend C",
            "64 - Legend B",
            "65 - Legend A",
            "66 - Infinity Legend E",
            "67 - Infinity Legend D",
            "68 - Infinity Legend C",
            "69 - Infinity Legend B",
            "70 - Infinity Legend A "});
            this.cbLevel.Location = new System.Drawing.Point(154, 74);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(127, 23);
            this.cbLevel.TabIndex = 5;
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Oculto",
            "Points",
            "Pangs"});
            this.cbTipo.Location = new System.Drawing.Point(395, 114);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(101, 23);
            this.cbTipo.TabIndex = 9;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(444, 45);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(58, 19);
            this.ckAtivo.TabIndex = 4;
            this.ckAtivo.Text = "ATIVO";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // imgIcone
            // 
            this.imgIcone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgIcone.BackgroundImage")));
            this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgIcone.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgIcone.ErrorImage")));
            this.imgIcone.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgIcone.InitialImage")));
            this.imgIcone.Location = new System.Drawing.Point(17, 14);
            this.imgIcone.Name = "imgIcone";
            this.imgIcone.Size = new System.Drawing.Size(85, 85);
            this.imgIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcone.TabIndex = 14;
            this.imgIcone.TabStop = false;
            // 
            // txtIcone
            // 
            this.txtIcone.Location = new System.Drawing.Point(323, 43);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.Size = new System.Drawing.Size(115, 21);
            this.txtIcone.TabIndex = 3;
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(154, 43);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(101, 21);
            this.txtTypeID.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(109, 78);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(36, 15);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Level";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(345, 117);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(44, 15);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Moeda";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(238, 116);
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(96, 21);
            this.txtDesconto.TabIndex = 8;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(49, 116);
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(100, 21);
            this.txtPreco.TabIndex = 8;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(154, 11);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(312, 21);
            this.txtNome.TabIndex = 0;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(283, 46);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(37, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Icone";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(109, 46);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "TypeID";
            // 
            // lbContNome
            // 
            this.lbContNome.AutoSize = true;
            this.lbContNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContNome.ForeColor = System.Drawing.Color.Gray;
            this.lbContNome.Location = new System.Drawing.Point(468, 14);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 9;
            this.lbContNome.Text = "0/40";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(177, 119);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(60, 15);
            this.Label18.TabIndex = 10;
            this.Label18.Text = "Desconto";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 119);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Preço";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(109, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 15);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Nome";
            // 
            // gbTempoVenda
            // 
            this.gbTempoVenda.Controls.Add(this.dtTermino);
            this.gbTempoVenda.Controls.Add(this.dtInicio);
            this.gbTempoVenda.Controls.Add(this.Label28);
            this.gbTempoVenda.Controls.Add(this.Label27);
            this.gbTempoVenda.Enabled = false;
            this.gbTempoVenda.Location = new System.Drawing.Point(13, 148);
            this.gbTempoVenda.Name = "gbTempoVenda";
            this.gbTempoVenda.Size = new System.Drawing.Size(359, 73);
            this.gbTempoVenda.TabIndex = 10;
            this.gbTempoVenda.TabStop = false;
            this.gbTempoVenda.Text = "Venda Programada";
            // 
            // dtTermino
            // 
            this.dtTermino.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTermino.Location = new System.Drawing.Point(185, 42);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(164, 21);
            this.dtTermino.TabIndex = 26;
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(13, 42);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(166, 21);
            this.dtInicio.TabIndex = 26;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(183, 23);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(107, 15);
            this.Label28.TabIndex = 10;
            this.Label28.Text = "Término da Venda";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(36, 24);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(90, 15);
            this.Label27.TabIndex = 10;
            this.Label27.Text = "Início da Venda";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(506, 378);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Avançado";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.BonusFlag);
            this.GroupBox3.Controls.Add(this.BonusPangRate);
            this.GroupBox3.Controls.Add(this.label38);
            this.GroupBox3.Controls.Add(this.label40);
            this.GroupBox3.Controls.Add(this.EfeitoExpRate);
            this.GroupBox3.Controls.Add(this.EfeitoPangRate);
            this.GroupBox3.Controls.Add(this.EfeitoGauge);
            this.GroupBox3.Controls.Add(this.EfeitoDropRate);
            this.GroupBox3.Controls.Add(this.Efeito_PowerDrive);
            this.GroupBox3.Controls.Add(this.label31);
            this.GroupBox3.Controls.Add(this.txtSlotItem);
            this.GroupBox3.Controls.Add(this.label26);
            this.GroupBox3.Controls.Add(this.label30);
            this.GroupBox3.Controls.Add(this.txtPrice365Day);
            this.GroupBox3.Controls.Add(this.label25);
            this.GroupBox3.Controls.Add(this.txtPrice30Day);
            this.GroupBox3.Controls.Add(this.label20);
            this.GroupBox3.Controls.Add(this.label24);
            this.GroupBox3.Controls.Add(this.label22);
            this.GroupBox3.Controls.Add(this.label23);
            this.GroupBox3.Controls.Add(this.txtPrice15Day);
            this.GroupBox3.Controls.Add(this.label10);
            this.GroupBox3.Controls.Add(this.txtPrice7Day);
            this.GroupBox3.Controls.Add(this.label9);
            this.GroupBox3.Controls.Add(this.txtPrice1Day);
            this.GroupBox3.Controls.Add(this.Label19);
            this.GroupBox3.Location = new System.Drawing.Point(6, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(495, 370);
            this.GroupBox3.TabIndex = 30;
            this.GroupBox3.TabStop = false;
            // 
            // BonusFlag
            // 
            this.BonusFlag.Location = new System.Drawing.Point(290, 172);
            this.BonusFlag.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BonusFlag.Name = "BonusFlag";
            this.BonusFlag.Size = new System.Drawing.Size(68, 20);
            this.BonusFlag.TabIndex = 48;
            // 
            // BonusPangRate
            // 
            this.BonusPangRate.Location = new System.Drawing.Point(290, 146);
            this.BonusPangRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BonusPangRate.Name = "BonusPangRate";
            this.BonusPangRate.Size = new System.Drawing.Size(68, 20);
            this.BonusPangRate.TabIndex = 47;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(182, 179);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 13);
            this.label38.TabIndex = 46;
            this.label38.Text = "Bonus[Flag]";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(182, 153);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(68, 13);
            this.label40.TabIndex = 45;
            this.label40.Text = "Bonus[Pang]";
            // 
            // EfeitoExpRate
            // 
            this.EfeitoExpRate.Location = new System.Drawing.Point(290, 121);
            this.EfeitoExpRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.EfeitoExpRate.Name = "EfeitoExpRate";
            this.EfeitoExpRate.Size = new System.Drawing.Size(68, 20);
            this.EfeitoExpRate.TabIndex = 38;
            // 
            // EfeitoPangRate
            // 
            this.EfeitoPangRate.Location = new System.Drawing.Point(290, 94);
            this.EfeitoPangRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.EfeitoPangRate.Name = "EfeitoPangRate";
            this.EfeitoPangRate.Size = new System.Drawing.Size(68, 20);
            this.EfeitoPangRate.TabIndex = 37;
            // 
            // EfeitoGauge
            // 
            this.EfeitoGauge.Location = new System.Drawing.Point(290, 67);
            this.EfeitoGauge.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.EfeitoGauge.Name = "EfeitoGauge";
            this.EfeitoGauge.Size = new System.Drawing.Size(68, 20);
            this.EfeitoGauge.TabIndex = 36;
            // 
            // EfeitoDropRate
            // 
            this.EfeitoDropRate.Location = new System.Drawing.Point(290, 41);
            this.EfeitoDropRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.EfeitoDropRate.Name = "EfeitoDropRate";
            this.EfeitoDropRate.Size = new System.Drawing.Size(68, 20);
            this.EfeitoDropRate.TabIndex = 35;
            // 
            // Efeito_PowerDrive
            // 
            this.Efeito_PowerDrive.Location = new System.Drawing.Point(290, 15);
            this.Efeito_PowerDrive.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Efeito_PowerDrive.Name = "Efeito_PowerDrive";
            this.Efeito_PowerDrive.Size = new System.Drawing.Size(68, 20);
            this.Efeito_PowerDrive.TabIndex = 34;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(28, 153);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(45, 13);
            this.label31.TabIndex = 33;
            this.label31.Text = "ItemSlot";
            // 
            // txtSlotItem
            // 
            this.txtSlotItem.Location = new System.Drawing.Point(81, 149);
            this.txtSlotItem.MaxLength = 40;
            this.txtSlotItem.Name = "txtSlotItem";
            this.txtSlotItem.Size = new System.Drawing.Size(95, 20);
            this.txtSlotItem.TabIndex = 32;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(182, 123);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "Efeito5[EXPRate]";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(182, 96);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(94, 13);
            this.label30.TabIndex = 29;
            this.label30.Text = "Efeito4[PangRate]";
            // 
            // txtPrice365Day
            // 
            this.txtPrice365Day.Location = new System.Drawing.Point(81, 123);
            this.txtPrice365Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice365Day.Name = "txtPrice365Day";
            this.txtPrice365Day.Size = new System.Drawing.Size(95, 20);
            this.txtPrice365Day.TabIndex = 27;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 125);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "Preço 365 dia";
            // 
            // txtPrice30Day
            // 
            this.txtPrice30Day.Location = new System.Drawing.Point(81, 96);
            this.txtPrice30Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice30Day.Name = "txtPrice30Day";
            this.txtPrice30Day.Size = new System.Drawing.Size(95, 20);
            this.txtPrice30Day.TabIndex = 25;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Preço 30 dia";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(182, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 13);
            this.label24.TabIndex = 23;
            this.label24.Text = "Efeito3[PGauge]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(182, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Efeito2[DropRate]";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(182, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "Efeito1[PowerDrive]";
            // 
            // txtPrice15Day
            // 
            this.txtPrice15Day.Location = new System.Drawing.Point(81, 69);
            this.txtPrice15Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice15Day.Name = "txtPrice15Day";
            this.txtPrice15Day.Size = new System.Drawing.Size(95, 20);
            this.txtPrice15Day.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Preço 15 dia";
            // 
            // txtPrice7Day
            // 
            this.txtPrice7Day.Location = new System.Drawing.Point(81, 43);
            this.txtPrice7Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice7Day.Name = "txtPrice7Day";
            this.txtPrice7Day.Size = new System.Drawing.Size(95, 20);
            this.txtPrice7Day.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Preço 7 dia";
            // 
            // txtPrice1Day
            // 
            this.txtPrice1Day.Location = new System.Drawing.Point(81, 17);
            this.txtPrice1Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice1Day.Name = "txtPrice1Day";
            this.txtPrice1Day.Size = new System.Drawing.Size(95, 20);
            this.txtPrice1Day.TabIndex = 13;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(6, 19);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(61, 13);
            this.Label19.TabIndex = 12;
            this.Label19.Text = "Preço 1 dia";
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 407);
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
            this.btnReabrir.Image = ((System.Drawing.Image)(resources.GetObject("btnReabrir.Image")));
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
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
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
            this.btnRemover.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.Image")));
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
            this.btnBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.Image")));
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
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
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
            this.diagSalvarArquivo.Filter = "Arquivo (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Salvar arquivo";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Pangya (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Caddie.iff)";
            // 
            // diagSalvarSql
            // 
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "Caddie.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Salvar arquivo SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            // 
            // ckDisplay
            // 
            this.ckDisplay.AutoSize = true;
            this.ckDisplay.Location = new System.Drawing.Point(10, 125);
            this.ckDisplay.Name = "ckDisplay";
            this.ckDisplay.Size = new System.Drawing.Size(94, 19);
            this.ckDisplay.TabIndex = 6;
            this.ckDisplay.Text = "Only Display";
            this.ckDisplay.UseVisualStyleBackColor = true;
            // 
            // FrmAuxPartEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 548);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAuxPartEditor";
            this.Text = "AuxPart - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmAuxPartEditor_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.Panel10.ResumeLayout(false);
            this.Panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.att2Curva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attCurva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Spin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Precisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attPrecisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Controle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attControle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.att2Forca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attForca)).EndInit();
            this.Panel9.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BonusFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusPangRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoExpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoPangRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EfeitoDropRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Efeito_PowerDrive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice365Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice30Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice15Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice7Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice1Day)).EndInit();
            this.gbBotoes.ResumeLayout(false);
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

		[AccessedThroughProperty("Panel1")]
		private Panel Panel1;

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

		[AccessedThroughProperty("rbLevelMax")]
		private RadioButton rbLevelMax;

		[AccessedThroughProperty("rbLevelMin")]
		private RadioButton rbLevelMin;

		[AccessedThroughProperty("cbLevel")]
		private ComboBox cbLevel;

		[AccessedThroughProperty("ckAtivo")]
		private CheckBox ckAtivo;

		[AccessedThroughProperty("imgIcone")]
		private PictureBox imgIcone;

		[AccessedThroughProperty("Label6")]
		private Label Label6;

		[AccessedThroughProperty("txtNome")]
		private TextBox txtNome;

		[AccessedThroughProperty("Label3")]
		private Label Label3;

		[AccessedThroughProperty("lbContNome")]
		private Label lbContNome;

		[AccessedThroughProperty("Label1")]
		private Label Label1;

		[AccessedThroughProperty("btnAbrirArquivo")]
		private ToolStripButton btnAbrirArquivo;

		[AccessedThroughProperty("diagAbrirArquivo")]
		private OpenFileDialog diagAbrirArquivo;

		[AccessedThroughProperty("txtIcone")]
		private TextBox txtIcone;

		[AccessedThroughProperty("Label7")]
		private Label Label7;

		[AccessedThroughProperty("ToolStripStatusLabel1")]
		private ToolStripStatusLabel ToolStripStatusLabel1;

		[AccessedThroughProperty("lbTotalItens")]
		private ToolStripStatusLabel lbTotalItens;

		[AccessedThroughProperty("Label2")]
		private Label Label2;

		[AccessedThroughProperty("txtPreco")]
		private TextBox txtPreco;

		[AccessedThroughProperty("Label4")]
		private Label Label4;

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

		[AccessedThroughProperty("cbTipo")]
		private ComboBox cbTipo;

		[AccessedThroughProperty("Label8")]
		private Label Label8;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox GroupBox1;

		[AccessedThroughProperty("ckNew")]
		private CheckBox ckNew;

		[AccessedThroughProperty("ckNormal")]
		private CheckBox ckNormal;

		[AccessedThroughProperty("ckGift")]
		private CheckBox ckGift;

		[AccessedThroughProperty("ckHot")]
		private CheckBox ckHot;

		[AccessedThroughProperty("ToolStripStatusLabel2")]
		private ToolStripStatusLabel ToolStripStatusLabel2;

		[AccessedThroughProperty("lbStatus")]
		private ToolStripStatusLabel lbStatus;

		[AccessedThroughProperty("Label18")]
		private Label Label18;

		[AccessedThroughProperty("txtDesconto")]
		private TextBox txtDesconto;

		[AccessedThroughProperty("Panel2")]
		private Panel Panel2;

		[AccessedThroughProperty("Label29")]
		private Label Label29;

		[AccessedThroughProperty("gbTempoVenda")]
		private GroupBox gbTempoVenda;

		[AccessedThroughProperty("ckTempoAtivo")]
		private CheckBox ckTempoAtivo;

		[AccessedThroughProperty("dtTermino")]
		private DateTimePicker dtTermino;

		[AccessedThroughProperty("dtInicio")]
		private DateTimePicker dtInicio;

		[AccessedThroughProperty("Label28")]
		private Label Label28;

		[AccessedThroughProperty("Label27")]
		private Label Label27;

		[AccessedThroughProperty("ckDesativado")]
		private CheckBox ckDesativado;

		[AccessedThroughProperty("ListaItem")]
		private DataGridView ListaItem;

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

		[AccessedThroughProperty("txtTypeID")]
		private TextBox txtTypeID;

		[AccessedThroughProperty("diagSalvarSql")]
		private SaveFileDialog diagSalvarSql;

		[AccessedThroughProperty("menuMassa")]
		private ToolStripDropDownButton menuMassa;

		[AccessedThroughProperty("AlterarPreçoToolStripMenuItem")]
		private ToolStripMenuItem ToolStripMenuItem_0;

		[AccessedThroughProperty("DesativarTodosToolStripMenuItem")]
		private ToolStripMenuItem DesativarTodosToolStripMenuItem;

		[AccessedThroughProperty("AtivarTodosToolStripMenuItem")]
		private ToolStripMenuItem AtivarTodosToolStripMenuItem;

		[AccessedThroughProperty("MudarMarcaçãoToolStripMenuItem")]
		private ToolStripMenuItem ToolStripMenuItem_1;

		[AccessedThroughProperty("RemoverMarcaçãoToolStripMenuItem")]
		private ToolStripMenuItem ToolStripMenuItem_2;

		[AccessedThroughProperty("LevelMinimoToolStripMenuItem")]
		private ToolStripMenuItem LevelMinimoToolStripMenuItem;

		[AccessedThroughProperty("ToolStripMenuItem1")]
		private ToolStripSeparator ToolStripMenuItem1;

		[AccessedThroughProperty("ApagarTodosToolStripMenuItem")]
		private ToolStripMenuItem ApagarTodosToolStripMenuItem;

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

		[AccessedThroughProperty("imgStatus")]
		private PictureBox imgStatus;

		[AccessedThroughProperty("ComboBox2")]
		private ComboBox ComboBox2;

		[AccessedThroughProperty("Label37")]
		private Label Label37;

		[AccessedThroughProperty("Label39")]
		private Label Label39;

		[AccessedThroughProperty("ImageList2")]
		private ImageList ImageList2;

		[AccessedThroughProperty("diagPasta")]
		private FolderBrowserDialog diagPasta;

		[AccessedThroughProperty("AlterarDescontoToolStripMenuItem")]
		private ToolStripMenuItem AlterarDescontoToolStripMenuItem;

		[AccessedThroughProperty("btnVerificarTYPEID")]
		private Button btnVerificarTYPEID;

		[AccessedThroughProperty("ToolTip1")]
		private ToolTip ToolTip1;

		[AccessedThroughProperty("menuGerarCache")]
		private ToolStripButton menuGerarCache;

		[AccessedThroughProperty("imgPersonagem")]
		private PictureBox imgPersonagem;

		[AccessedThroughProperty("Label36")]
		private Label Label36;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox ComboBox1;

		[AccessedThroughProperty("TabPage2")]
		private TabPage TabPage2;

		public string Arquivo;

		private AuxPart oIff;

		public AuxPartCollection lsItens;

		public AuxPartCollection lsTemp;

		public byte[] bStart;

		private bool Alterado;

		private BindingSource bs;

		private int lastRow;

		public long qtdItem;

#pragma warning disable CS0169 // O campo "FrmAuxPartEditor.arquivog" nunca é usado
		private string arquivog;
#pragma warning restore CS0169 // O campo "FrmAuxPartEditor.arquivog" nunca é usado

		private string caminho;
        #endregion
        private GroupBox GroupBox3;
        private NumericUpDown EfeitoExpRate;
        private NumericUpDown EfeitoPangRate;
        private NumericUpDown EfeitoGauge;
        private NumericUpDown EfeitoDropRate;
        private NumericUpDown Efeito_PowerDrive;
        private Label label26;
        private Label label30;
        private NumericUpDown txtPrice365Day;
        private Label label25;
        private NumericUpDown txtPrice30Day;
        private Label label20;
        private Label label24;
        private Label label22;
        private Label label23;
        private NumericUpDown txtPrice15Day;
        private Label label10;
        private NumericUpDown txtPrice7Day;
        private Label label9;
        private NumericUpDown txtPrice1Day;
        private Label Label19;
        private Panel Panel10;
        private NumericUpDown att2Curva;
        private NumericUpDown attCurva;
        private NumericUpDown att2Spin;
        private NumericUpDown attSpin;
        private NumericUpDown att2Precisao;
        private NumericUpDown attPrecisao;
        private NumericUpDown att2Controle;
        private NumericUpDown attControle;
        private NumericUpDown att2Forca;
        private NumericUpDown attForca;
        private Panel Panel9;
        private Panel barraCurva;
        private Panel Panel8;
        private Panel barraSpin;
        private Panel Panel7;
        private Panel barraPrecisao;
        private Panel Panel6;
        private Panel barraControle;
        private Panel Panel5;
        private Panel barraForca;
        private Label Label17;
        private Label label11;
        private Label Label14;
        private Label Label13;
        private Label Label12;
        private Label label15;
        private Label label16;
        private Label label21;
        private Label label32;
        private NumericUpDown BonusFlag;
        private NumericUpDown BonusPangRate;
        private Label label38;
        private Label label40;
        private Label label31;
        private TextBox txtSlotItem;
        private ToolStripMenuItem activeAllItensToolStripMenuItem;
        private CheckBox ckDisplay;
    }
}