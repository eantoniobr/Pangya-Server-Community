using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class FrmCardEditor
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
            this.menuGerarSql = new System.Windows.Forms.ToolStripButton();
            this.menuTypeid = new System.Windows.Forms.ToolStripButton();
            this.menuBackup = new System.Windows.Forms.ToolStripButton();
            this.menuDividir = new System.Windows.Forms.ToolStripDropDownButton();
            this.DividirArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnirArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMassa = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            this.AlterarDescontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnVerificarTYPEID = new System.Windows.Forms.Button();
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.attCurva = new System.Windows.Forms.NumericUpDown();
            this.attSpin = new System.Windows.Forms.NumericUpDown();
            this.attPrecisao = new System.Windows.Forms.NumericUpDown();
            this.attControle = new System.Windows.Forms.NumericUpDown();
            this.attForca = new System.Windows.Forms.NumericUpDown();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.barraCurva = new System.Windows.Forms.Panel();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.barraSpin = new System.Windows.Forms.Panel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.barraPrecisao = new System.Windows.Forms.Panel();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.barraControle = new System.Windows.Forms.Panel();
            this.attForca2 = new System.Windows.Forms.Panel();
            this.barraForca = new System.Windows.Forms.Panel();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckItemPSQ = new System.Windows.Forms.CheckBox();
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
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFlag2 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtFlag1 = new System.Windows.Forms.TextBox();
            this.Flag1 = new System.Windows.Forms.Label();
            this.txtRarity = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCardVolum = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEffectValue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEffectDuration = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbEffect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtBuffImage = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.txtSlotImage = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtSubIcon = new System.Windows.Forms.TextBox();
            this.labeladd = new System.Windows.Forms.Label();
            this.txtCardImage = new System.Windows.Forms.TextBox();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.activeAllItensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.attCurva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attPrecisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attControle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attForca)).BeginInit();
            this.Panel9.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.attForca2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
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
            this.menuGerarSql,
            this.menuTypeid,
            this.menuBackup,
            this.menuDividir,
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
            // menuGerarSql
            // 
            this.menuGerarSql.Enabled = false;
            this.menuGerarSql.Image = global::PangyaSuiteFiles.Properties.Resources.database_lightning;
            this.menuGerarSql.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuGerarSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuGerarSql.Name = "menuGerarSql";
            this.menuGerarSql.Size = new System.Drawing.Size(36, 37);
            this.menuGerarSql.ToolTipText = "Gerar arquivo de SQL";
            // 
            // menuTypeid
            // 
            this.menuTypeid.Enabled = false;
            this.menuTypeid.Image = global::PangyaSuiteFiles.Properties.Resources.textfield_key;
            this.menuTypeid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuTypeid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuTypeid.Name = "menuTypeid";
            this.menuTypeid.Size = new System.Drawing.Size(36, 37);
            this.menuTypeid.ToolTipText = "Gerar TYPEID";
            this.menuTypeid.Visible = false;
            // 
            // menuBackup
            // 
            this.menuBackup.Enabled = false;
            this.menuBackup.Image = global::PangyaSuiteFiles.Properties.Resources.backup_manager;
            this.menuBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBackup.Name = "menuBackup";
            this.menuBackup.Size = new System.Drawing.Size(36, 37);
            this.menuBackup.ToolTipText = "Backup";
            // 
            // menuDividir
            // 
            this.menuDividir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDividir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DividirArquivoToolStripMenuItem,
            this.UnirArquivoToolStripMenuItem});
            this.menuDividir.Enabled = false;
            this.menuDividir.Image = global::PangyaSuiteFiles.Properties.Resources.plugin;
            this.menuDividir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuDividir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDividir.Name = "menuDividir";
            this.menuDividir.Size = new System.Drawing.Size(45, 37);
            this.menuDividir.ToolTipText = "Dividir Arquivo";
            this.menuDividir.Visible = false;
            // 
            // DividirArquivoToolStripMenuItem
            // 
            this.DividirArquivoToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.plugin_delete;
            this.DividirArquivoToolStripMenuItem.Name = "DividirArquivoToolStripMenuItem";
            this.DividirArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.DividirArquivoToolStripMenuItem.Text = "Dividir arquivo";
            // 
            // UnirArquivoToolStripMenuItem
            // 
            this.UnirArquivoToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.plugin_add;
            this.UnirArquivoToolStripMenuItem.Name = "UnirArquivoToolStripMenuItem";
            this.UnirArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.UnirArquivoToolStripMenuItem.Text = "Unir arquivo";
            // 
            // menuMassa
            // 
            this.menuMassa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMassa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem0,
            this.AlterarDescontoToolStripMenuItem,
            this.activeAllItensToolStripMenuItem,
            this.DesativarTodosToolStripMenuItem,
            this.AtivarTodosToolStripMenuItem,
            this.ToolStripMenuItem_1,
            this.ToolStripMenuItem_2,
            this.LevelMinimoToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.ApagarTodosToolStripMenuItem});
            this.menuMassa.Image = global::PangyaSuiteFiles.Properties.Resources.chart_organisation;
            this.menuMassa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMassa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuMassa.Name = "menuMassa";
            this.menuMassa.Size = new System.Drawing.Size(45, 37);
            this.menuMassa.Text = "ToolStripDropDownButton1";
            this.menuMassa.ToolTipText = "Operações em massa";
            this.menuMassa.Visible = false;
            // 
            // ToolStripMenuItem0
            // 
            this.ToolStripMenuItem0.Image = global::PangyaSuiteFiles.Properties.Resources.AlterarPreçoToolStripMenuItem_Image;
            this.ToolStripMenuItem0.Name = "ToolStripMenuItem0";
            this.ToolStripMenuItem0.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem0.Text = "Alterar preço";
            // 
            // AlterarDescontoToolStripMenuItem
            // 
            this.AlterarDescontoToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.money_delete;
            this.AlterarDescontoToolStripMenuItem.Name = "AlterarDescontoToolStripMenuItem";
            this.AlterarDescontoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AlterarDescontoToolStripMenuItem.Text = "Alterar Desconto";
            // 
            // DesativarTodosToolStripMenuItem
            // 
            this.DesativarTodosToolStripMenuItem.Enabled = false;
            this.DesativarTodosToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.DesativarTodosToolStripMenuItem_Image;
            this.DesativarTodosToolStripMenuItem.Name = "DesativarTodosToolStripMenuItem";
            this.DesativarTodosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DesativarTodosToolStripMenuItem.Text = "Desativar todos";
            // 
            // AtivarTodosToolStripMenuItem
            // 
            this.AtivarTodosToolStripMenuItem.Enabled = false;
            this.AtivarTodosToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.AtivarTodosToolStripMenuItem_Image;
            this.AtivarTodosToolStripMenuItem.Name = "AtivarTodosToolStripMenuItem";
            this.AtivarTodosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AtivarTodosToolStripMenuItem.Text = "Ativar todos";
            // 
            // ToolStripMenuItem_1
            // 
            this.ToolStripMenuItem_1.Enabled = false;
            this.ToolStripMenuItem_1.Image = global::PangyaSuiteFiles.Properties.Resources.MudarMarcaçãoToolStripMenuItem_Image;
            this.ToolStripMenuItem_1.Name = "ToolStripMenuItem_1";
            this.ToolStripMenuItem_1.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_1.Text = "Mudar marcação";
            // 
            // ToolStripMenuItem_2
            // 
            this.ToolStripMenuItem_2.Enabled = false;
            this.ToolStripMenuItem_2.Image = global::PangyaSuiteFiles.Properties.Resources.RemoverMarcaçãoToolStripMenuItem_Image;
            this.ToolStripMenuItem_2.Name = "ToolStripMenuItem_2";
            this.ToolStripMenuItem_2.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_2.Text = "Remover marcação";
            // 
            // LevelMinimoToolStripMenuItem
            // 
            this.LevelMinimoToolStripMenuItem.Enabled = false;
            this.LevelMinimoToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.LevelMinimoToolStripMenuItem_Image;
            this.LevelMinimoToolStripMenuItem.Name = "LevelMinimoToolStripMenuItem";
            this.LevelMinimoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LevelMinimoToolStripMenuItem.Text = "Alterar Level";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // ApagarTodosToolStripMenuItem
            // 
            this.ApagarTodosToolStripMenuItem.Enabled = false;
            this.ApagarTodosToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.ApagarTodosToolStripMenuItem_Image;
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            this.ApagarTodosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ApagarTodosToolStripMenuItem.Text = "Apagar todos";
            // 
            // menuGerarCache
            // 
            this.menuGerarCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuGerarCache.Enabled = false;
            this.menuGerarCache.Image = global::PangyaSuiteFiles.Properties.Resources.package_add;
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
            this.imgStatus.Image = global::PangyaSuiteFiles.Properties.Resources.fred;
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
            this.PictureBox4.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
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
            this.PictureBox1.Image = global::PangyaSuiteFiles.Properties.Resources.zoom;
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
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
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
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.Panel10);
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
            // btnVerificarTYPEID
            // 
            this.btnVerificarTYPEID.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
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
            // Panel10
            // 
            this.Panel10.Controls.Add(this.attCurva);
            this.Panel10.Controls.Add(this.attSpin);
            this.Panel10.Controls.Add(this.attPrecisao);
            this.Panel10.Controls.Add(this.attControle);
            this.Panel10.Controls.Add(this.attForca);
            this.Panel10.Controls.Add(this.Panel9);
            this.Panel10.Controls.Add(this.Panel8);
            this.Panel10.Controls.Add(this.Panel7);
            this.Panel10.Controls.Add(this.Panel6);
            this.Panel10.Controls.Add(this.attForca2);
            this.Panel10.Controls.Add(this.Label9);
            this.Panel10.Controls.Add(this.Label14);
            this.Panel10.Controls.Add(this.Label13);
            this.Panel10.Controls.Add(this.Label12);
            this.Panel10.Controls.Add(this.Label11);
            this.Panel10.Controls.Add(this.Label10);
            this.Panel10.Controls.Add(this.Label15);
            this.Panel10.Location = new System.Drawing.Point(0, 223);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(372, 154);
            this.Panel10.TabIndex = 25;
            // 
            // attCurva
            // 
            this.attCurva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attCurva.Location = new System.Drawing.Point(321, 123);
            this.attCurva.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attCurva.Name = "attCurva";
            this.attCurva.Size = new System.Drawing.Size(44, 21);
            this.attCurva.TabIndex = 19;
            this.attCurva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attCurva.ValueChanged += new System.EventHandler(this.attCurva_ValueChanged);
            // 
            // attSpin
            // 
            this.attSpin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attSpin.Location = new System.Drawing.Point(321, 98);
            this.attSpin.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attSpin.Name = "attSpin";
            this.attSpin.Size = new System.Drawing.Size(44, 21);
            this.attSpin.TabIndex = 17;
            this.attSpin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attSpin.ValueChanged += new System.EventHandler(this.attSpin_ValueChanged);
            // 
            // attPrecisao
            // 
            this.attPrecisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attPrecisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attPrecisao.Location = new System.Drawing.Point(321, 73);
            this.attPrecisao.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attPrecisao.Name = "attPrecisao";
            this.attPrecisao.Size = new System.Drawing.Size(44, 21);
            this.attPrecisao.TabIndex = 15;
            this.attPrecisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attPrecisao.ValueChanged += new System.EventHandler(this.attPrecisao_ValueChanged);
            // 
            // attControle
            // 
            this.attControle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attControle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attControle.Location = new System.Drawing.Point(321, 48);
            this.attControle.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attControle.Name = "attControle";
            this.attControle.Size = new System.Drawing.Size(44, 21);
            this.attControle.TabIndex = 13;
            this.attControle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attControle.ValueChanged += new System.EventHandler(this.attControle_ValueChanged);
            // 
            // attForca
            // 
            this.attForca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attForca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attForca.Location = new System.Drawing.Point(321, 24);
            this.attForca.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attForca.Name = "attForca";
            this.attForca.Size = new System.Drawing.Size(44, 21);
            this.attForca.TabIndex = 11;
            this.attForca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attForca.ValueChanged += new System.EventHandler(this.attForca_ValueChanged);
            // 
            // Panel9
            // 
            this.Panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel9.Controls.Add(this.barraCurva);
            this.Panel9.Location = new System.Drawing.Point(78, 125);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(237, 18);
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
            this.Panel8.Size = new System.Drawing.Size(237, 18);
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
            this.Panel7.Size = new System.Drawing.Size(237, 18);
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
            this.Panel6.Size = new System.Drawing.Size(237, 18);
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
            // attForca2
            // 
            this.attForca2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.attForca2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attForca2.Controls.Add(this.barraForca);
            this.attForca2.Location = new System.Drawing.Point(78, 25);
            this.attForca2.Name = "attForca2";
            this.attForca2.Size = new System.Drawing.Size(237, 18);
            this.attForca2.TabIndex = 24;
            this.attForca2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel5_Paint);
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
            // Label9
            // 
            this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label9.Location = new System.Drawing.Point(12, 3);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(356, 2);
            this.Label9.TabIndex = 21;
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
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(2, 52);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(74, 15);
            this.Label11.TabIndex = 7;
            this.Label11.Text = "CONTROLE";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(28, 26);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(48, 15);
            this.Label10.TabIndex = 7;
            this.Label10.Text = "FORÇA";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(319, 8);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(49, 15);
            this.Label15.TabIndex = 10;
            this.Label15.Text = "Espaço";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckItemPSQ);
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            this.GroupBox1.Location = new System.Drawing.Point(379, 148);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 181);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Marcação";
            // 
            // ckItemPSQ
            // 
            this.ckItemPSQ.AutoSize = true;
            this.ckItemPSQ.Location = new System.Drawing.Point(11, 127);
            this.ckItemPSQ.Name = "ckItemPSQ";
            this.ckItemPSQ.Size = new System.Drawing.Size(103, 19);
            this.ckItemPSQ.TabIndex = 6;
            this.ckItemPSQ.Text = "Item PSQuare";
            this.ckItemPSQ.UseVisualStyleBackColor = true;
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
            this.ckDesativado.Location = new System.Drawing.Point(11, 152);
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
            "Pangs",
            "Only Display"});
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
            this.imgIcone.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgIcone.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.imgIcone.InitialImage = global::PangyaSuiteFiles.Properties.Resources.ajax_loader;
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
            this.TabPage2.Controls.Add(this.GroupBox5);
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(506, 378);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Avançado";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtFlag2);
            this.GroupBox5.Controls.Add(this.label30);
            this.GroupBox5.Controls.Add(this.txtFlag1);
            this.GroupBox5.Controls.Add(this.Flag1);
            this.GroupBox5.Controls.Add(this.txtRarity);
            this.GroupBox5.Controls.Add(this.label24);
            this.GroupBox5.Controls.Add(this.label22);
            this.GroupBox5.Controls.Add(this.txtCardNo);
            this.GroupBox5.Controls.Add(this.label21);
            this.GroupBox5.Controls.Add(this.txtCardVolum);
            this.GroupBox5.Controls.Add(this.label20);
            this.GroupBox5.Controls.Add(this.txtEffectValue);
            this.GroupBox5.Controls.Add(this.label17);
            this.GroupBox5.Controls.Add(this.txtEffectDuration);
            this.GroupBox5.Controls.Add(this.label16);
            this.GroupBox5.Controls.Add(this.cmbEffect);
            this.GroupBox5.Controls.Add(this.label5);
            this.GroupBox5.Location = new System.Drawing.Point(6, 116);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(493, 188);
            this.GroupBox5.TabIndex = 15;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Outras informacoes";
            // 
            // txtFlag2
            // 
            this.txtFlag2.Location = new System.Drawing.Point(106, 162);
            this.txtFlag2.Name = "txtFlag2";
            this.txtFlag2.Size = new System.Drawing.Size(101, 20);
            this.txtFlag2.TabIndex = 25;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(37, 164);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(58, 13);
            this.label30.TabIndex = 26;
            this.label30.Text = "CardFlag2:";
            // 
            // txtFlag1
            // 
            this.txtFlag1.Location = new System.Drawing.Point(106, 138);
            this.txtFlag1.Name = "txtFlag1";
            this.txtFlag1.Size = new System.Drawing.Size(101, 20);
            this.txtFlag1.TabIndex = 23;
            // 
            // Flag1
            // 
            this.Flag1.AutoSize = true;
            this.Flag1.Location = new System.Drawing.Point(45, 141);
            this.Flag1.Name = "Flag1";
            this.Flag1.Size = new System.Drawing.Size(52, 13);
            this.Flag1.TabIndex = 24;
            this.Flag1.Text = "CardFlag:";
            // 
            // txtRarity
            // 
            this.txtRarity.Location = new System.Drawing.Point(106, 112);
            this.txtRarity.Name = "txtRarity";
            this.txtRarity.Size = new System.Drawing.Size(101, 20);
            this.txtRarity.TabIndex = 21;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(60, 115);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Rarity:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(213, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Minutos";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(441, 93);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(38, 20);
            this.txtCardNo.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(386, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "Card No:";
            // 
            // txtCardVolum
            // 
            this.txtCardVolum.Location = new System.Drawing.Point(441, 64);
            this.txtCardVolum.Name = "txtCardVolum";
            this.txtCardVolum.Size = new System.Drawing.Size(38, 20);
            this.txtCardVolum.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(371, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Card Volum:";
            // 
            // txtEffectValue
            // 
            this.txtEffectValue.Location = new System.Drawing.Point(106, 86);
            this.txtEffectValue.Name = "txtEffectValue";
            this.txtEffectValue.Size = new System.Drawing.Size(101, 20);
            this.txtEffectValue.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Valor do Efeito:";
            // 
            // txtEffectDuration
            // 
            this.txtEffectDuration.Location = new System.Drawing.Point(106, 60);
            this.txtEffectDuration.Name = "txtEffectDuration";
            this.txtEffectDuration.Size = new System.Drawing.Size(101, 20);
            this.txtEffectDuration.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Duracao do Efeito:";
            // 
            // cmbEffect
            // 
            this.cmbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffect.FormattingEnabled = true;
            this.cmbEffect.Items.AddRange(new object[] {
            "None",
            "Experience",
            "PercentPang",
            "PercentExperience",
            "Pang",
            "Power",
            "Control",
            "Accuracy",
            "Spin",
            "Curve",
            "StartingGauge",
            "Inventory"});
            this.cmbEffect.Location = new System.Drawing.Point(106, 33);
            this.cmbEffect.Name = "cmbEffect";
            this.cmbEffect.Size = new System.Drawing.Size(101, 21);
            this.cmbEffect.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Efeito:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label19);
            this.GroupBox3.Controls.Add(this.txtBuffImage);
            this.GroupBox3.Controls.Add(this.Label25);
            this.GroupBox3.Controls.Add(this.txtSlotImage);
            this.GroupBox3.Controls.Add(this.Label23);
            this.GroupBox3.Controls.Add(this.txtSubIcon);
            this.GroupBox3.Controls.Add(this.labeladd);
            this.GroupBox3.Controls.Add(this.txtCardImage);
            this.GroupBox3.Location = new System.Drawing.Point(4, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(493, 104);
            this.GroupBox3.TabIndex = 16;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Texturas";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(249, 23);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(58, 13);
            this.Label19.TabIndex = 12;
            this.Label19.Text = "Buff Image";
            // 
            // txtBuffImage
            // 
            this.txtBuffImage.Location = new System.Drawing.Point(311, 19);
            this.txtBuffImage.MaxLength = 40;
            this.txtBuffImage.Name = "txtBuffImage";
            this.txtBuffImage.Size = new System.Drawing.Size(171, 20);
            this.txtBuffImage.TabIndex = 11;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(9, 79);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(57, 13);
            this.Label25.TabIndex = 12;
            this.Label25.Text = "Slot Image";
            // 
            // txtSlotImage
            // 
            this.txtSlotImage.Location = new System.Drawing.Point(71, 75);
            this.txtSlotImage.MaxLength = 40;
            this.txtSlotImage.Name = "txtSlotImage";
            this.txtSlotImage.Size = new System.Drawing.Size(171, 20);
            this.txtSlotImage.TabIndex = 11;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(9, 53);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(50, 13);
            this.Label23.TabIndex = 12;
            this.Label23.Text = "Sub Icon";
            // 
            // txtSubIcon
            // 
            this.txtSubIcon.Location = new System.Drawing.Point(71, 49);
            this.txtSubIcon.MaxLength = 40;
            this.txtSubIcon.Name = "txtSubIcon";
            this.txtSubIcon.Size = new System.Drawing.Size(171, 20);
            this.txtSubIcon.TabIndex = 11;
            // 
            // labeladd
            // 
            this.labeladd.AutoSize = true;
            this.labeladd.Location = new System.Drawing.Point(9, 25);
            this.labeladd.Name = "labeladd";
            this.labeladd.Size = new System.Drawing.Size(28, 13);
            this.labeladd.TabIndex = 12;
            this.labeladd.Text = "PET";
            // 
            // txtCardImage
            // 
            this.txtCardImage.Location = new System.Drawing.Point(71, 21);
            this.txtCardImage.MaxLength = 40;
            this.txtCardImage.Name = "txtCardImage";
            this.txtCardImage.Size = new System.Drawing.Size(171, 20);
            this.txtCardImage.TabIndex = 11;
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
            this.ComboBox1.Location = new System.Drawing.Point(49, 351);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(89, 21);
            this.ComboBox1.TabIndex = 14;
            this.ComboBox1.Visible = false;
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
            this.diagSalvarArquivo.Title = "Salvar arquivo Caddie.iff";
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
            // activeAllItensToolStripMenuItem
            // 
            this.activeAllItensToolStripMenuItem.Name = "activeAllItensToolStripMenuItem";
            this.activeAllItensToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.activeAllItensToolStripMenuItem.Text = "Active All Itens";
            this.activeAllItensToolStripMenuItem.Click += new System.EventHandler(this.activeAllItensToolStripMenuItem_Click);
            // 
            // FrmCardEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 548);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.ComboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::PangyaSuiteFiles.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "FrmCardEditor";
            this.Text = "Card - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmCardEditor_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.attCurva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attPrecisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attControle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attForca)).EndInit();
            this.Panel9.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.attForca2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
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

		[AccessedThroughProperty("TabPage2")]
		private TabPage TabPage2;

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

		[AccessedThroughProperty("menuGerarSql")]
		private ToolStripButton menuGerarSql;

		[AccessedThroughProperty("txtTypeID")]
		private TextBox txtTypeID;

		[AccessedThroughProperty("diagSalvarSql")]
		private SaveFileDialog diagSalvarSql;

		[AccessedThroughProperty("menuMassa")]
		private ToolStripDropDownButton menuMassa;

		[AccessedThroughProperty("menuBackup")]
		private ToolStripButton menuBackup;

		[AccessedThroughProperty("AlterarPreçoToolStripMenuItem")]
		private ToolStripMenuItem ToolStripMenuItem0;

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

		[AccessedThroughProperty("menuTypeid")]
		private ToolStripButton menuTypeid;

		[AccessedThroughProperty("ImageList2")]
		private ImageList ImageList2;

		[AccessedThroughProperty("menuDividir")]
		private ToolStripDropDownButton menuDividir;

		[AccessedThroughProperty("DividirArquivoToolStripMenuItem")]
		private ToolStripMenuItem DividirArquivoToolStripMenuItem;

		[AccessedThroughProperty("UnirArquivoToolStripMenuItem")]
		private ToolStripMenuItem UnirArquivoToolStripMenuItem;

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

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox ComboBox1;

		[AccessedThroughProperty("Panel10")]
		private Panel Panel10;

		[AccessedThroughProperty("attCurva")]
		private NumericUpDown attCurva;

		[AccessedThroughProperty("attSpin")]
		private NumericUpDown attSpin;

		[AccessedThroughProperty("attPrecisao")]
		private NumericUpDown attPrecisao;

		[AccessedThroughProperty("attControle")]
		private NumericUpDown attControle;

		[AccessedThroughProperty("attForca")]
		private NumericUpDown attForca;

		[AccessedThroughProperty("Panel9")]
		private Panel Panel9;

		[AccessedThroughProperty("barraCurva")]
		private Panel barraCurva;

		[AccessedThroughProperty("Panel8")]
		private Panel Panel8;

		[AccessedThroughProperty("barraSpin")]
		private Panel barraSpin;

		[AccessedThroughProperty("Panel7")]
		private Panel Panel7;

		[AccessedThroughProperty("barraPrecisao")]
		private Panel barraPrecisao;

		[AccessedThroughProperty("Panel6")]
		private Panel Panel6;

		[AccessedThroughProperty("barraControle")]
		private Panel barraControle;

		[AccessedThroughProperty("Panel5")]
		private Panel attForca2;

		[AccessedThroughProperty("barraForca")]
		private Panel barraForca;

		[AccessedThroughProperty("Label9")]
		private Label Label9;

		[AccessedThroughProperty("Label14")]
		private Label Label14;

		[AccessedThroughProperty("Label13")]
		private Label Label13;

		[AccessedThroughProperty("Label12")]
		private Label Label12;

		[AccessedThroughProperty("Label11")]
		private Label Label11;

		[AccessedThroughProperty("Label10")]
		private Label Label10;

		[AccessedThroughProperty("Label15")]
		private Label Label15;

		public string Arquivo;

		private Card oIff;


		public CardCollection lsItens;

		public CardCollection lsTemp;

		public byte[] bStart;

#pragma warning disable CS0414 // O campo "FrmCardEditor.Alterado" é atribuído, mas seu valor nunca é usado
		private bool Alterado;
#pragma warning restore CS0414 // O campo "FrmCardEditor.Alterado" é atribuído, mas seu valor nunca é usado

		private BindingSource bs;

		private int lastRow;

		public long qtdItem;

#pragma warning disable CS0169 // O campo "FrmCardEditor.arquivog" nunca é usado
		private string arquivog;
#pragma warning restore CS0169 // O campo "FrmCardEditor.arquivog" nunca é usado

		private string caminho;
        #endregion

        private CheckBox ckItemPSQ;
        private GroupBox GroupBox5;
        private GroupBox GroupBox3;
        private Label Label19;
        private TextBox txtBuffImage;
        private Label Label25;
        private TextBox txtSlotImage;
        private Label Label23;
        private TextBox txtSubIcon;
        private Label labeladd;
        private TextBox txtCardImage;
        private ComboBox cmbEffect;
        private Label label5;
        private Label label22;
        private TextBox txtCardNo;
        private Label label21;
        private TextBox txtCardVolum;
        private Label label20;
        private TextBox txtEffectValue;
        private Label label17;
        private TextBox txtEffectDuration;
        private Label label16;
        private TextBox txtRarity;
        private Label label24;
        private TextBox txtFlag2;
        private Label label30;
        private TextBox txtFlag1;
        private Label Flag1;
        private ToolStripMenuItem activeAllItensToolStripMenuItem;
    }
}