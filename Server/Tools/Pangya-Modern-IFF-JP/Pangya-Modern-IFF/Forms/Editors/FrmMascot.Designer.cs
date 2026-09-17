using PangyaAPI.IFF.JP.Models;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
    partial class FrmMascot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.menuMassa = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ApagarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLInsertInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getItemActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s8THToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s8GBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.nrDay = new System.Windows.Forms.NumericUpDown();
            this.ckTimeShopActive = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSpecial = new System.Windows.Forms.CheckBox();
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.ckDesativado = new System.Windows.Forms.CheckBox();
            this.ckNormal = new System.Windows.Forms.CheckBox();
            this.ckHot = new System.Windows.Forms.CheckBox();
            this.ckGift = new System.Windows.Forms.CheckBox();
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
            this.btnVerificarTYPEID = new System.Windows.Forms.Button();
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
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
            this.ckActiveMSG = new System.Windows.Forms.CheckBox();
            this.BonusFlag = new System.Windows.Forms.NumericUpDown();
            this.BonusPangRate = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtChangePrice = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtFlagMSG = new System.Windows.Forms.TextBox();
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
            this.Label5 = new System.Windows.Forms.Label();
            this.labeladd = new System.Windows.Forms.Label();
            this.txtSprite2 = new System.Windows.Forms.TextBox();
            this.txtSprite1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnApplyDesc = new System.Windows.Forms.Button();
            this.BtnCreateDesc = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BtnApplyAbility = new System.Windows.Forms.Button();
            this.BtnNewAbility = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEffectActive3 = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtEffectActive2 = new System.Windows.Forms.CheckBox();
            this.txtFlag2 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtEffectActive = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.cbType3 = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtEffectRate3 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtEffectRate = new System.Windows.Forms.TextBox();
            this.cbType2 = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtEffectRate2 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).BeginInit();
            this.GroupBox1.SuspendLayout();
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
            this.Panel5.SuspendLayout();
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
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.ToolStripStatusLabel1.Text = "Total Items:";
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
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(49, 17);
            this.ToolStripStatusLabel4.Text = "Indexes:";
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(518, 17);
            this.ToolStripStatusLabel2.Spring = true;
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(31, 17);
            this.lbStatus.Text = "Stop";
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
            this.menuMassa});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(809, 40);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Image = global::Pangya_Modern_Editor.Properties.Resources.BntOpenFile;
            this.btnAbrirArquivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAbrirArquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(36, 37);
            this.btnAbrirArquivo.ToolTipText = "Open File";
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // menuSalvarComo
            // 
            this.menuSalvarComo.Enabled = false;
            this.menuSalvarComo.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMenuSave;
            this.menuSalvarComo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalvarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSalvarComo.Name = "menuSalvarComo";
            this.menuSalvarComo.Size = new System.Drawing.Size(36, 37);
            this.menuSalvarComo.ToolTipText = "Save File";
            this.menuSalvarComo.Click += new System.EventHandler(this.MenuSalvarComo_Click);
            // 
            // menuGerarSql
            // 
            this.menuGerarSql.Enabled = false;
            this.menuGerarSql.Image = global::Pangya_Modern_Editor.Properties.Resources.database;
            this.menuGerarSql.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuGerarSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuGerarSql.Name = "menuGerarSql";
            this.menuGerarSql.Size = new System.Drawing.Size(36, 37);
            this.menuGerarSql.ToolTipText = "Gerar arquivo de SQL";
            this.menuGerarSql.Click += new System.EventHandler(this.menuGerarSql_Click);
            // 
            // menuTypeid
            // 
            this.menuTypeid.Enabled = false;
            this.menuTypeid.Image = global::Pangya_Modern_Editor.Properties.Resources.textfield_key;
            this.menuTypeid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuTypeid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuTypeid.Name = "menuTypeid";
            this.menuTypeid.Size = new System.Drawing.Size(36, 37);
            this.menuTypeid.ToolTipText = "Gerar TYPEID";
            this.menuTypeid.Click += new System.EventHandler(this.menuTypeid_Click);
            // 
            // menuBackup
            // 
            this.menuBackup.Enabled = false;
            this.menuBackup.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnBackup;
            this.menuBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBackup.Name = "menuBackup";
            this.menuBackup.Size = new System.Drawing.Size(36, 37);
            this.menuBackup.ToolTipText = "Backup";
            this.menuBackup.Click += new System.EventHandler(this.menuBackup_Click);
            // 
            // menuMassa
            // 
            this.menuMassa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMassa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ApagarTodosToolStripMenuItem,
            this.itemShopToolStripMenuItem,
            this.copyItemToolStripMenuItem});
            this.menuMassa.Image = global::Pangya_Modern_Editor.Properties.Resources.chart_organisation;
            this.menuMassa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMassa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuMassa.Name = "menuMassa";
            this.menuMassa.Size = new System.Drawing.Size(45, 37);
            this.menuMassa.Text = "ToolStripDropDownButton1";
            this.menuMassa.ToolTipText = "Operações em massa";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // ApagarTodosToolStripMenuItem
            // 
            this.ApagarTodosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFFToolStripMenuItem,
            this.sQLInsertInventoryToolStripMenuItem,
            this.cSVFileToolStripMenuItem});
            this.ApagarTodosToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDisk;
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            this.ApagarTodosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ApagarTodosToolStripMenuItem.Text = "Save";
            // 
            // iFFToolStripMenuItem
            // 
            this.iFFToolStripMenuItem.Name = "iFFToolStripMenuItem";
            this.iFFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iFFToolStripMenuItem.Text = "Items Select (IFF)";
            // 
            // sQLInsertInventoryToolStripMenuItem
            // 
            this.sQLInsertInventoryToolStripMenuItem.Name = "sQLInsertInventoryToolStripMenuItem";
            this.sQLInsertInventoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sQLInsertInventoryToolStripMenuItem.Text = "SQL Insert Inventory";
            this.sQLInsertInventoryToolStripMenuItem.Click += new System.EventHandler(this.sQLInsertInventoryToolStripMenuItem_Click);
            // 
            // cSVFileToolStripMenuItem
            // 
            this.cSVFileToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnExcel;
            this.cSVFileToolStripMenuItem.Name = "cSVFileToolStripMenuItem";
            this.cSVFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cSVFileToolStripMenuItem.Text = "CSV File";
            // 
            // itemShopToolStripMenuItem
            // 
            this.itemShopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getItemActiveToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.itemShopToolStripMenuItem.Name = "itemShopToolStripMenuItem";
            this.itemShopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.itemShopToolStripMenuItem.Text = "Item Shop";
            // 
            // getItemActiveToolStripMenuItem
            // 
            this.getItemActiveToolStripMenuItem.Name = "getItemActiveToolStripMenuItem";
            this.getItemActiveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.getItemActiveToolStripMenuItem.Text = "Get Item In PSQ";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // copyItemToolStripMenuItem
            // 
            this.copyItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s8THToolStripMenuItem,
            this.s8GBToolStripMenuItem});
            this.copyItemToolStripMenuItem.Name = "copyItemToolStripMenuItem";
            this.copyItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyItemToolStripMenuItem.Text = "Convert Iff";
            // 
            // s8THToolStripMenuItem
            // 
            this.s8THToolStripMenuItem.Name = "s8THToolStripMenuItem";
            this.s8THToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.s8THToolStripMenuItem.Text = "S8 TH to JP";
            this.s8THToolStripMenuItem.Click += new System.EventHandler(this.ConvertS8TH_Click);
            // 
            // s8GBToolStripMenuItem
            // 
            this.s8GBToolStripMenuItem.Name = "s8GBToolStripMenuItem";
            this.s8GBToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.s8GBToolStripMenuItem.Text = "S8 GB to JP";
            this.s8GBToolStripMenuItem.Click += new System.EventHandler(this.ConvertS8GB_Click);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaItem.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.ListaItem.DefaultCellStyleChanged += new System.EventHandler(this.ListaItem_DefaultCellStyleChanged);
            this.ListaItem.RowsDefaultCellStyleChanged += new System.EventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            this.ListaItem.Sorted += new System.EventHandler(this.ListaItem_Sorted);
            this.ListaItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaItem_KeyDown);
            this.ListaItem.MouseHover += new System.EventHandler(this.ListaItem_MouseHover);
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
            this.PictureBox2.Image = global::Pangya_Modern_Editor.Properties.Resources.document_editing;
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
            this.lbArquivo.Size = new System.Drawing.Size(63, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Mascot.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.PictureBox3);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 417);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(277, 69);
            this.Panel1.TabIndex = 0;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox3.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.PictureBox3.Location = new System.Drawing.Point(3, 30);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(35, 35);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox3.TabIndex = 24;
            this.PictureBox3.TabStop = false;
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 27);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(270, 2);
            this.Label39.TabIndex = 22;
            // 
            // PictureBox4
            // 
            this.PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox4.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.PictureBox4.Location = new System.Drawing.Point(202, 5);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(20, 20);
            this.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox4.TabIndex = 1;
            this.PictureBox4.TabStop = false;
            this.PictureBox4.Click += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
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
            "All",
            "Active",
            "Pang",
            "Cookies",
            "Hide"});
            this.ComboBox2.Location = new System.Drawing.Point(46, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(71, 21);
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
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(224, 7);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(14, 16);
            this.lblSearchCount.TabIndex = 10;
            this.lblSearchCount.Text = "0";
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
            this.tabForm.Controls.Add(this.tabPage3);
            this.tabForm.Controls.Add(this.tabPage4);
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
            this.TabPage1.Controls.Add(this.groupBox6);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Panel10);
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
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
            this.TabPage1.Text = "Basic Info";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label41);
            this.groupBox6.Controls.Add(this.nrDay);
            this.groupBox6.Controls.Add(this.ckTimeShopActive);
            this.groupBox6.Location = new System.Drawing.Point(383, 304);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(118, 62);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Shop";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(13, 20);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(31, 15);
            this.label41.TabIndex = 53;
            this.label41.Text = "Day:";
            // 
            // nrDay
            // 
            this.nrDay.Location = new System.Drawing.Point(44, 18);
            this.nrDay.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nrDay.Name = "nrDay";
            this.nrDay.Size = new System.Drawing.Size(45, 21);
            this.nrDay.TabIndex = 18;
            // 
            // ckTimeShopActive
            // 
            this.ckTimeShopActive.AutoSize = true;
            this.ckTimeShopActive.Location = new System.Drawing.Point(16, 41);
            this.ckTimeShopActive.Name = "ckTimeShopActive";
            this.ckTimeShopActive.Size = new System.Drawing.Size(86, 19);
            this.ckTimeShopActive.TabIndex = 17;
            this.ckTimeShopActive.Text = "Time Shop";
            this.ckTimeShopActive.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckSpecial);
            this.GroupBox1.Controls.Add(this.ckDisplay);
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            this.GroupBox1.Location = new System.Drawing.Point(383, 148);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 154);
            this.GroupBox1.TabIndex = 30;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Shop Flag";
            // 
            // ckSpecial
            // 
            this.ckSpecial.AutoSize = true;
            this.ckSpecial.Location = new System.Drawing.Point(9, 59);
            this.ckSpecial.Name = "ckSpecial";
            this.ckSpecial.Size = new System.Drawing.Size(94, 19);
            this.ckSpecial.TabIndex = 8;
            this.ckSpecial.Text = "Item Special";
            this.ckSpecial.UseVisualStyleBackColor = true;
            // 
            // ckDisplay
            // 
            this.ckDisplay.AutoSize = true;
            this.ckDisplay.Location = new System.Drawing.Point(9, 94);
            this.ckDisplay.Name = "ckDisplay";
            this.ckDisplay.Size = new System.Drawing.Size(94, 19);
            this.ckDisplay.TabIndex = 6;
            this.ckDisplay.Text = "Only Display";
            this.ckDisplay.UseVisualStyleBackColor = true;
            this.ckDisplay.CheckedChanged += new System.EventHandler(this.ckDisplay_CheckedChanged);
            // 
            // ckNew
            // 
            this.ckNew.AutoSize = true;
            this.ckNew.Location = new System.Drawing.Point(9, 23);
            this.ckNew.Name = "ckNew";
            this.ckNew.Size = new System.Drawing.Size(78, 19);
            this.ckNew.TabIndex = 0;
            this.ckNew.Text = "Item New";
            this.ckNew.UseVisualStyleBackColor = true;
            this.ckNew.CheckedChanged += new System.EventHandler(this.ckNew_CheckedChanged);
            // 
            // ckDesativado
            // 
            this.ckDesativado.AutoSize = true;
            this.ckDesativado.Location = new System.Drawing.Point(9, 129);
            this.ckDesativado.Name = "ckDesativado";
            this.ckDesativado.Size = new System.Drawing.Size(52, 19);
            this.ckDesativado.TabIndex = 5;
            this.ckDesativado.Text = "Hide";
            this.ckDesativado.UseVisualStyleBackColor = true;
            this.ckDesativado.CheckedChanged += new System.EventHandler(this.ckDesativado_CheckedChanged);
            // 
            // ckNormal
            // 
            this.ckNormal.AutoSize = true;
            this.ckNormal.Location = new System.Drawing.Point(9, 112);
            this.ckNormal.Name = "ckNormal";
            this.ckNormal.Size = new System.Drawing.Size(94, 19);
            this.ckNormal.TabIndex = 5;
            this.ckNormal.Text = "Item Normal";
            this.ckNormal.UseVisualStyleBackColor = true;
            this.ckNormal.CheckedChanged += new System.EventHandler(this.ckNormal_CheckedChanged);
            // 
            // ckHot
            // 
            this.ckHot.AutoSize = true;
            this.ckHot.Location = new System.Drawing.Point(9, 42);
            this.ckHot.Name = "ckHot";
            this.ckHot.Size = new System.Drawing.Size(72, 19);
            this.ckHot.TabIndex = 1;
            this.ckHot.Text = "Item Hot";
            this.ckHot.UseVisualStyleBackColor = true;
            this.ckHot.CheckedChanged += new System.EventHandler(this.ckHot_CheckedChanged);
            // 
            // ckGift
            // 
            this.ckGift.AutoSize = true;
            this.ckGift.Location = new System.Drawing.Point(9, 76);
            this.ckGift.Name = "ckGift";
            this.ckGift.Size = new System.Drawing.Size(95, 19);
            this.ckGift.TabIndex = 3;
            this.ckGift.Text = "Item Giftable";
            this.ckGift.UseVisualStyleBackColor = true;
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
            this.Panel10.Controls.Add(this.Panel5);
            this.Panel10.Controls.Add(this.Label17);
            this.Panel10.Controls.Add(this.label11);
            this.Panel10.Controls.Add(this.Label14);
            this.Panel10.Controls.Add(this.Label13);
            this.Panel10.Controls.Add(this.Label12);
            this.Panel10.Controls.Add(this.label15);
            this.Panel10.Controls.Add(this.label16);
            this.Panel10.Controls.Add(this.label21);
            this.Panel10.Location = new System.Drawing.Point(3, 222);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(367, 154);
            this.Panel10.TabIndex = 29;
            // 
            // attCurva
            // 
            this.attCurva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attCurva.Location = new System.Drawing.Point(315, 123);
            this.attCurva.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attCurva.Name = "attCurva";
            this.attCurva.Size = new System.Drawing.Size(44, 21);
            this.attCurva.TabIndex = 19;
            this.attCurva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attCurva.ValueChanged += new System.EventHandler(this.att2Curva_ValueChanged);
            // 
            // attSpin
            // 
            this.attSpin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attSpin.Location = new System.Drawing.Point(315, 98);
            this.attSpin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attSpin.Name = "attSpin";
            this.attSpin.Size = new System.Drawing.Size(44, 21);
            this.attSpin.TabIndex = 17;
            this.attSpin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attSpin.ValueChanged += new System.EventHandler(this.att2Spin_ValueChanged);
            // 
            // attPrecisao
            // 
            this.attPrecisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attPrecisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attPrecisao.Location = new System.Drawing.Point(315, 73);
            this.attPrecisao.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attPrecisao.Name = "attPrecisao";
            this.attPrecisao.Size = new System.Drawing.Size(44, 21);
            this.attPrecisao.TabIndex = 15;
            this.attPrecisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attPrecisao.ValueChanged += new System.EventHandler(this.att2Precisao_ValueChanged);
            // 
            // attControle
            // 
            this.attControle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attControle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attControle.Location = new System.Drawing.Point(315, 48);
            this.attControle.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attControle.Name = "attControle";
            this.attControle.Size = new System.Drawing.Size(44, 21);
            this.attControle.TabIndex = 13;
            this.attControle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attControle.ValueChanged += new System.EventHandler(this.att2Controle_ValueChanged);
            // 
            // attForca
            // 
            this.attForca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attForca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attForca.Location = new System.Drawing.Point(315, 24);
            this.attForca.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.attForca.Name = "attForca";
            this.attForca.Size = new System.Drawing.Size(44, 21);
            this.attForca.TabIndex = 11;
            this.attForca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.attForca.ValueChanged += new System.EventHandler(this.att2Forca_ValueChanged);
            // 
            // Panel9
            // 
            this.Panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel9.Controls.Add(this.barraCurva);
            this.Panel9.Location = new System.Drawing.Point(72, 125);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(225, 18);
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
            this.Panel8.Location = new System.Drawing.Point(72, 100);
            this.Panel8.Name = "Panel8";
            this.Panel8.Size = new System.Drawing.Size(225, 18);
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
            this.Panel7.Location = new System.Drawing.Point(72, 75);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(225, 18);
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
            this.Panel6.Location = new System.Drawing.Point(72, 50);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(225, 18);
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
            this.Panel5.Location = new System.Drawing.Point(72, 25);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(225, 18);
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
            this.Label17.Location = new System.Drawing.Point(303, 11);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(3, 130);
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
            this.Label14.Location = new System.Drawing.Point(23, 127);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(49, 15);
            this.Label14.TabIndex = 7;
            this.Label14.Text = "CURVE";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(35, 102);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(35, 15);
            this.Label13.TabIndex = 7;
            this.Label13.Text = "SPIN";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(2, 77);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(73, 15);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "PRECISION";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "CONTROL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "POWER";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(314, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 15);
            this.label21.TabIndex = 10;
            this.label21.Text = "Stats";
            // 
            // btnVerificarTYPEID
            // 
            this.btnVerificarTYPEID.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.btnVerificarTYPEID.Location = new System.Drawing.Point(257, 41);
            this.btnVerificarTYPEID.Name = "btnVerificarTYPEID";
            this.btnVerificarTYPEID.Size = new System.Drawing.Size(25, 25);
            this.btnVerificarTYPEID.TabIndex = 28;
            this.ToolTip1.SetToolTip(this.btnVerificarTYPEID, "Verify Item Index");
            this.btnVerificarTYPEID.UseVisualStyleBackColor = true;
            this.btnVerificarTYPEID.Click += new System.EventHandler(this.btnVerificarTYPEID_Click);
            // 
            // ckTempoAtivo
            // 
            this.ckTempoAtivo.AutoSize = true;
            this.ckTempoAtivo.BackColor = System.Drawing.Color.Transparent;
            this.ckTempoAtivo.Location = new System.Drawing.Point(288, 159);
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            this.ckTempoAtivo.Size = new System.Drawing.Size(82, 19);
            this.ckTempoAtivo.TabIndex = 27;
            this.ckTempoAtivo.Text = "Time Sale";
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            this.ckTempoAtivo.CheckedChanged += new System.EventHandler(this.ckTempoAtivo_CheckedChanged);
            this.ckTempoAtivo.TextChanged += new System.EventHandler(this.ckTempoAtivo_CheckedChanged);
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
            this.rbLevelMax.Size = new System.Drawing.Size(78, 19);
            this.rbLevelMax.TabIndex = 7;
            this.rbLevelMax.Text = "Level Max";
            this.rbLevelMax.UseVisualStyleBackColor = true;
            // 
            // rbLevelMin
            // 
            this.rbLevelMin.AutoSize = true;
            this.rbLevelMin.Checked = true;
            this.rbLevelMin.Location = new System.Drawing.Point(297, 77);
            this.rbLevelMin.Name = "rbLevelMin";
            this.rbLevelMin.Size = new System.Drawing.Size(79, 19);
            this.rbLevelMin.TabIndex = 6;
            this.rbLevelMin.TabStop = true;
            this.rbLevelMin.Text = "Level Min.";
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
            "Hide",
            "Cookies",
            "Pangs"});
            this.cbTipo.Location = new System.Drawing.Point(395, 114);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(101, 23);
            this.cbTipo.TabIndex = 9;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(435, 45);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 4;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // imgIcone
            // 
            this.imgIcone.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgIcone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgIcone.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgIcone.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.imgIcone.Location = new System.Drawing.Point(17, 14);
            this.imgIcone.Name = "imgIcone";
            this.imgIcone.Size = new System.Drawing.Size(85, 85);
            this.imgIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcone.TabIndex = 14;
            this.imgIcone.TabStop = false;
            // 
            // txtIcone
            // 
            this.txtIcone.Location = new System.Drawing.Point(314, 43);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.Size = new System.Drawing.Size(115, 21);
            this.txtIcone.TabIndex = 3;
            this.txtIcone.TextChanged += new System.EventHandler(this.txtIcone_TextChanged);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(154, 43);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(101, 21);
            this.txtTypeID.TabIndex = 2;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
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
            this.Label8.Location = new System.Drawing.Point(347, 119);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 15);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Money";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(238, 116);
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(96, 21);
            this.txtDesconto.TabIndex = 8;
            this.txtDesconto.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(49, 116);
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(100, 21);
            this.txtPreco.TabIndex = 8;
            this.txtPreco.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(154, 11);
            this.txtNome.MaxLength = 64;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(312, 21);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(283, 46);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(30, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Icon";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(131, 46);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(19, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "ID";
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
            this.lbContNome.Text = "0/64";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(177, 119);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(56, 15);
            this.Label18.TabIndex = 10;
            this.Label18.Text = "Discount";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 119);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Price";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(109, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 15);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Name";
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
            this.gbTempoVenda.Text = "Sale Programation";
            // 
            // dtTermino
            // 
            this.dtTermino.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTermino.Location = new System.Drawing.Point(185, 42);
            this.dtTermino.MinDate = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(164, 21);
            this.dtTermino.TabIndex = 26;
            this.dtTermino.Value = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(13, 42);
            this.dtInicio.MinDate = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(166, 21);
            this.dtInicio.TabIndex = 26;
            this.dtInicio.Value = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(183, 23);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(57, 15);
            this.Label28.TabIndex = 10;
            this.Label28.Text = "End Sale";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(36, 24);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(60, 15);
            this.Label27.TabIndex = 10;
            this.Label27.Text = "Start Sale";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(506, 378);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Mascot";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.ckActiveMSG);
            this.GroupBox3.Controls.Add(this.BonusFlag);
            this.GroupBox3.Controls.Add(this.BonusPangRate);
            this.GroupBox3.Controls.Add(this.label38);
            this.GroupBox3.Controls.Add(this.label40);
            this.GroupBox3.Controls.Add(this.label35);
            this.GroupBox3.Controls.Add(this.txtChangePrice);
            this.GroupBox3.Controls.Add(this.label34);
            this.GroupBox3.Controls.Add(this.txtFlagMSG);
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
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.labeladd);
            this.GroupBox3.Controls.Add(this.txtSprite2);
            this.GroupBox3.Controls.Add(this.txtSprite1);
            this.GroupBox3.Location = new System.Drawing.Point(6, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(495, 288);
            this.GroupBox3.TabIndex = 30;
            this.GroupBox3.TabStop = false;
            // 
            // ckActiveMSG
            // 
            this.ckActiveMSG.AutoSize = true;
            this.ckActiveMSG.Location = new System.Drawing.Point(367, 20);
            this.ckActiveMSG.Name = "ckActiveMSG";
            this.ckActiveMSG.Size = new System.Drawing.Size(102, 17);
            this.ckActiveMSG.TabIndex = 49;
            this.ckActiveMSG.Text = "Active Message";
            this.ckActiveMSG.UseVisualStyleBackColor = true;
            // 
            // BonusFlag
            // 
            this.BonusFlag.Location = new System.Drawing.Point(293, 225);
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
            this.BonusPangRate.Location = new System.Drawing.Point(293, 199);
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
            this.label38.Location = new System.Drawing.Point(224, 227);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 13);
            this.label38.TabIndex = 46;
            this.label38.Text = "Bonus[Flag]";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(219, 204);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(68, 13);
            this.label40.TabIndex = 45;
            this.label40.Text = "Bonus[Pang]";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(0, 232);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(71, 13);
            this.label35.TabIndex = 44;
            this.label35.Text = "Change Price";
            // 
            // txtChangePrice
            // 
            this.txtChangePrice.Location = new System.Drawing.Point(84, 229);
            this.txtChangePrice.MaxLength = 40;
            this.txtChangePrice.Name = "txtChangePrice";
            this.txtChangePrice.Size = new System.Drawing.Size(95, 20);
            this.txtChangePrice.TabIndex = 43;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(0, 206);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 13);
            this.label34.TabIndex = 42;
            this.label34.Text = "Flag Message";
            // 
            // txtFlagMSG
            // 
            this.txtFlagMSG.Location = new System.Drawing.Point(84, 201);
            this.txtFlagMSG.MaxLength = 40;
            this.txtFlagMSG.Name = "txtFlagMSG";
            this.txtFlagMSG.Size = new System.Drawing.Size(95, 20);
            this.txtFlagMSG.TabIndex = 41;
            // 
            // EfeitoExpRate
            // 
            this.EfeitoExpRate.Location = new System.Drawing.Point(293, 174);
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
            this.EfeitoPangRate.Location = new System.Drawing.Point(293, 147);
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
            this.EfeitoGauge.Location = new System.Drawing.Point(293, 120);
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
            this.EfeitoDropRate.Location = new System.Drawing.Point(293, 94);
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
            this.Efeito_PowerDrive.Location = new System.Drawing.Point(293, 68);
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
            this.label31.Location = new System.Drawing.Point(25, 254);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(45, 13);
            this.label31.TabIndex = 33;
            this.label31.Text = "ItemSlot";
            // 
            // txtSlotItem
            // 
            this.txtSlotItem.Location = new System.Drawing.Point(84, 254);
            this.txtSlotItem.MaxLength = 40;
            this.txtSlotItem.Name = "txtSlotItem";
            this.txtSlotItem.Size = new System.Drawing.Size(95, 20);
            this.txtSlotItem.TabIndex = 32;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(233, 178);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "EXP Rate";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(232, 149);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 13);
            this.label30.TabIndex = 29;
            this.label30.Text = "PangRate";
            // 
            // txtPrice365Day
            // 
            this.txtPrice365Day.Location = new System.Drawing.Point(84, 176);
            this.txtPrice365Day.Maximum = new decimal(new int[] {
            255,
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
            this.label25.Location = new System.Drawing.Point(18, 181);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "Price 365D";
            // 
            // txtPrice30Day
            // 
            this.txtPrice30Day.Location = new System.Drawing.Point(84, 149);
            this.txtPrice30Day.Maximum = new decimal(new int[] {
            255,
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
            this.label20.Location = new System.Drawing.Point(24, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Price 30D";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(213, 122);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 13);
            this.label24.TabIndex = 23;
            this.label24.Text = "Unit P. Gauge";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(206, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Drop Hole Rate";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(225, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "PowerDrive";
            // 
            // txtPrice15Day
            // 
            this.txtPrice15Day.Location = new System.Drawing.Point(84, 122);
            this.txtPrice15Day.Maximum = new decimal(new int[] {
            255,
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
            this.label10.Location = new System.Drawing.Point(24, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Price 15D";
            // 
            // txtPrice7Day
            // 
            this.txtPrice7Day.Location = new System.Drawing.Point(84, 96);
            this.txtPrice7Day.Maximum = new decimal(new int[] {
            255,
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
            this.label9.Location = new System.Drawing.Point(30, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Price 7D";
            // 
            // txtPrice1Day
            // 
            this.txtPrice1Day.Location = new System.Drawing.Point(84, 70);
            this.txtPrice1Day.Maximum = new decimal(new int[] {
            255,
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
            this.Label19.Location = new System.Drawing.Point(30, 75);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(48, 13);
            this.Label19.TabIndex = 12;
            this.Label19.Text = "Price 1D";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 49);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Texture";
            // 
            // labeladd
            // 
            this.labeladd.AutoSize = true;
            this.labeladd.Location = new System.Drawing.Point(9, 22);
            this.labeladd.Name = "labeladd";
            this.labeladd.Size = new System.Drawing.Size(36, 13);
            this.labeladd.TabIndex = 12;
            this.labeladd.Text = "Model";
            // 
            // txtSprite2
            // 
            this.txtSprite2.Location = new System.Drawing.Point(60, 45);
            this.txtSprite2.MaxLength = 40;
            this.txtSprite2.Name = "txtSprite2";
            this.txtSprite2.Size = new System.Drawing.Size(301, 20);
            this.txtSprite2.TabIndex = 11;
            // 
            // txtSprite1
            // 
            this.txtSprite1.Location = new System.Drawing.Point(60, 18);
            this.txtSprite1.MaxLength = 40;
            this.txtSprite1.Name = "txtSprite1";
            this.txtSprite1.Size = new System.Drawing.Size(301, 20);
            this.txtSprite1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnApplyDesc);
            this.tabPage3.Controls.Add(this.BtnCreateDesc);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Controls.Add(this.txtDesc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(506, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Desc Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnApplyDesc
            // 
            this.BtnApplyDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyDesc.Location = new System.Drawing.Point(403, 237);
            this.BtnApplyDesc.Name = "BtnApplyDesc";
            this.BtnApplyDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyDesc.TabIndex = 10;
            this.BtnApplyDesc.TabStop = false;
            this.BtnApplyDesc.Text = "Apply";
            this.BtnApplyDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnApplyDesc.UseVisualStyleBackColor = true;
            this.BtnApplyDesc.Click += new System.EventHandler(this.BtnApplyDesc_Click);
            // 
            // BtnCreateDesc
            // 
            this.BtnCreateDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCreateDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnNew;
            this.BtnCreateDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCreateDesc.Location = new System.Drawing.Point(300, 237);
            this.BtnCreateDesc.Name = "BtnCreateDesc";
            this.BtnCreateDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnCreateDesc.TabIndex = 11;
            this.BtnCreateDesc.TabStop = false;
            this.BtnCreateDesc.Text = "New";
            this.BtnCreateDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreateDesc.UseVisualStyleBackColor = true;
            this.BtnCreateDesc.Click += new System.EventHandler(this.BtnCreateDesc_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 7);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 13);
            this.label32.TabIndex = 9;
            this.label32.Text = "Item Desc Information:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 27);
            this.txtDesc.MaxLength = 512;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(494, 207);
            this.txtDesc.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BtnApplyAbility);
            this.tabPage4.Controls.Add(this.BtnNewAbility);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(506, 378);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ability Info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BtnApplyAbility
            // 
            this.BtnApplyAbility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyAbility.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyAbility.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyAbility.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyAbility.Location = new System.Drawing.Point(400, 210);
            this.BtnApplyAbility.Name = "BtnApplyAbility";
            this.BtnApplyAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyAbility.TabIndex = 47;
            this.BtnApplyAbility.TabStop = false;
            this.BtnApplyAbility.Text = "Apply";
            this.BtnApplyAbility.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnApplyAbility.UseVisualStyleBackColor = true;
            this.BtnApplyAbility.Click += new System.EventHandler(this.BtnApplyAbility_Click);
            // 
            // BtnNewAbility
            // 
            this.BtnNewAbility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnNewAbility.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewAbility.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnNew;
            this.BtnNewAbility.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNewAbility.Location = new System.Drawing.Point(297, 210);
            this.BtnNewAbility.Name = "BtnNewAbility";
            this.BtnNewAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnNewAbility.TabIndex = 48;
            this.BtnNewAbility.TabStop = false;
            this.BtnNewAbility.Text = "New";
            this.BtnNewAbility.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNewAbility.UseVisualStyleBackColor = true;
            this.BtnNewAbility.Click += new System.EventHandler(this.BtnNewAbility_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEffectActive3);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.txtEffectActive2);
            this.groupBox2.Controls.Add(this.txtFlag2);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.txtEffectActive);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.txtFlag);
            this.groupBox2.Controls.Add(this.cbType3);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.txtEffectRate3);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.txtEffectRate);
            this.groupBox2.Controls.Add(this.cbType2);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.txtEffectRate2);
            this.groupBox2.Controls.Add(this.label49);
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 199);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config Effect";
            // 
            // txtEffectActive3
            // 
            this.txtEffectActive3.AutoSize = true;
            this.txtEffectActive3.Location = new System.Drawing.Point(200, 174);
            this.txtEffectActive3.Name = "txtEffectActive3";
            this.txtEffectActive3.Size = new System.Drawing.Size(56, 17);
            this.txtEffectActive3.TabIndex = 43;
            this.txtEffectActive3.Text = "Active";
            this.txtEffectActive3.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(341, 48);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(36, 13);
            this.label42.TabIndex = 34;
            this.label42.Text = "Flag 2";
            // 
            // txtEffectActive2
            // 
            this.txtEffectActive2.AutoSize = true;
            this.txtEffectActive2.Location = new System.Drawing.Point(200, 107);
            this.txtEffectActive2.Name = "txtEffectActive2";
            this.txtEffectActive2.Size = new System.Drawing.Size(56, 17);
            this.txtEffectActive2.TabIndex = 42;
            this.txtEffectActive2.Text = "Active";
            this.txtEffectActive2.UseVisualStyleBackColor = true;
            // 
            // txtFlag2
            // 
            this.txtFlag2.Location = new System.Drawing.Point(388, 45);
            this.txtFlag2.Name = "txtFlag2";
            this.txtFlag2.Size = new System.Drawing.Size(94, 20);
            this.txtFlag2.TabIndex = 33;
            this.ToolTip1.SetToolTip(this.txtFlag2, "Index conected with Item.iff");
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(20, 144);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 13);
            this.label43.TabIndex = 40;
            this.label43.Text = "Effect Nº 3";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(341, 19);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(36, 13);
            this.label44.TabIndex = 32;
            this.label44.Text = "Flag 1";
            // 
            // txtEffectActive
            // 
            this.txtEffectActive.AutoSize = true;
            this.txtEffectActive.Location = new System.Drawing.Point(200, 43);
            this.txtEffectActive.Name = "txtEffectActive";
            this.txtEffectActive.Size = new System.Drawing.Size(56, 17);
            this.txtEffectActive.TabIndex = 41;
            this.txtEffectActive.Text = "Active";
            this.txtEffectActive.UseVisualStyleBackColor = true;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL (WIND LOW AND NO ITEM)",
            "PIXEL (WIND HIGH AND NO ITEM)",
            "PIXEL BY WIND",
            "PIXEL 2",
            "PIXEL (WIND LOW)",
            "P. GUAGE (StartHOLE)",
            "P. GUAGE (+1)",
            "P. GUAGE (StartGAME)",
            "PAWS NOT ACCUMULATE",
            "SWITCH TWO EFFECT",
            "EARCUFF DIRECTION WIND",
            "COMBINE ITEM",
            "SAFETY CLIENT RANDOM",
            "PIXEL RANDOM",
            "WIND 1M RANDOM",
            "PIXEL BY WIND MIDDLE DOUBLE",
            "GROUND 100% RONDOM",
            "ASSIST MIRACLE SIGN",
            "VECTOR SIGN",
            "ASSIST TRAJECTORY SHOT",
            "PAWS ACCUMULATE",
            "P. GUAGE FREE ",
            "SAFETY RANDOM ",
            "+1 ALL STATS       ",
            "P. GUAGE BY MISS SHOT",
            "PIXEL BY WIND 2",
            "PIXEL WITH RAIN",
            "NO RAIN EFFECT",
            "PUTT MORE 10Y RANDOM",
            "UNKNOWN 31",
            "MIRACLE SIGN RANDOM",
            "UNKNOWN 33",
            "-1M WIND"});
            this.cbType.Location = new System.Drawing.Point(95, 15);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(162, 22);
            this.cbType.TabIndex = 35;
            // 
            // txtFlag
            // 
            this.txtFlag.Location = new System.Drawing.Point(388, 16);
            this.txtFlag.Name = "txtFlag";
            this.txtFlag.Size = new System.Drawing.Size(94, 20);
            this.txtFlag.TabIndex = 31;
            this.ToolTip1.SetToolTip(this.txtFlag, "Index conected with Item.iff");
            // 
            // cbType3
            // 
            this.cbType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbType3.FormattingEnabled = true;
            this.cbType3.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL (WIND LOW AND NO ITEM)",
            "PIXEL (WIND HIGH AND NO ITEM)",
            "PIXEL BY WIND",
            "PIXEL 2",
            "PIXEL (WIND LOW)",
            "P. GUAGE (StartHOLE)",
            "P. GUAGE (+1)",
            "P. GUAGE (StartGAME)",
            "PAWS NOT ACCUMULATE",
            "SWITCH TWO EFFECT",
            "EARCUFF DIRECTION WIND",
            "COMBINE ITEM",
            "SAFETY CLIENT RANDOM",
            "PIXEL RANDOM",
            "WIND 1M RANDOM",
            "PIXEL BY WIND MIDDLE DOUBLE",
            "GROUND 100% RONDOM",
            "ASSIST MIRACLE SIGN",
            "VECTOR SIGN",
            "ASSIST TRAJECTORY SHOT",
            "PAWS ACCUMULATE",
            "P. GUAGE FREE ",
            "SAFETY RANDOM ",
            "+1 ALL STATS       ",
            "P. GUAGE BY MISS SHOT",
            "PIXEL BY WIND 2",
            "PIXEL WITH RAIN",
            "NO RAIN EFFECT",
            "PUTT MORE 10Y RANDOM",
            "UNKNOWN 31",
            "MIRACLE SIGN RANDOM",
            "UNKNOWN 33",
            "-1M WIND"});
            this.cbType3.Location = new System.Drawing.Point(95, 142);
            this.cbType3.Name = "cbType3";
            this.cbType3.Size = new System.Drawing.Size(162, 22);
            this.cbType3.TabIndex = 37;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(50, 174);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(30, 13);
            this.label45.TabIndex = 30;
            this.label45.Text = "Rate";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(20, 86);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 39;
            this.label46.Text = "Effect Nº 2";
            // 
            // txtEffectRate3
            // 
            this.txtEffectRate3.Location = new System.Drawing.Point(95, 171);
            this.txtEffectRate3.Name = "txtEffectRate3";
            this.txtEffectRate3.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate3.TabIndex = 29;
            this.ToolTip1.SetToolTip(this.txtEffectRate3, "Index conected with Item.iff");
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(25, 19);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(59, 13);
            this.label47.TabIndex = 38;
            this.label47.Text = "Effect Nº 1";
            // 
            // txtEffectRate
            // 
            this.txtEffectRate.Location = new System.Drawing.Point(95, 43);
            this.txtEffectRate.Name = "txtEffectRate";
            this.txtEffectRate.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate.TabIndex = 25;
            this.ToolTip1.SetToolTip(this.txtEffectRate, "Index conected with Item.iff");
            // 
            // cbType2
            // 
            this.cbType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbType2.FormattingEnabled = true;
            this.cbType2.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL (WIND LOW AND NO ITEM)",
            "PIXEL (WIND HIGH AND NO ITEM)",
            "PIXEL BY WIND",
            "PIXEL 2",
            "PIXEL (WIND LOW)",
            "P. GUAGE (StartHOLE)",
            "P. GUAGE (+1)",
            "P. GUAGE (StartGAME)",
            "PAWS NOT ACCUMULATE",
            "SWITCH TWO EFFECT",
            "EARCUFF DIRECTION WIND",
            "COMBINE ITEM",
            "SAFETY CLIENT RANDOM",
            "PIXEL RANDOM",
            "WIND 1M RANDOM",
            "PIXEL BY WIND MIDDLE DOUBLE",
            "GROUND 100% RONDOM",
            "ASSIST MIRACLE SIGN",
            "VECTOR SIGN",
            "ASSIST TRAJECTORY SHOT",
            "PAWS ACCUMULATE",
            "P. GUAGE FREE ",
            "SAFETY RANDOM ",
            "+1 ALL STATS       ",
            "P. GUAGE BY MISS SHOT",
            "PIXEL BY WIND 2",
            "PIXEL WITH RAIN",
            "NO RAIN EFFECT",
            "PUTT MORE 10Y RANDOM",
            "UNKNOWN 31",
            "MIRACLE SIGN RANDOM",
            "UNKNOWN 33",
            "-1M WIND"});
            this.cbType2.Location = new System.Drawing.Point(95, 79);
            this.cbType2.Name = "cbType2";
            this.cbType2.Size = new System.Drawing.Size(162, 22);
            this.cbType2.TabIndex = 36;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(55, 47);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(30, 13);
            this.label48.TabIndex = 26;
            this.label48.Text = "Rate";
            // 
            // txtEffectRate2
            // 
            this.txtEffectRate2.Location = new System.Drawing.Point(95, 107);
            this.txtEffectRate2.Name = "txtEffectRate2";
            this.txtEffectRate2.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate2.TabIndex = 27;
            this.ToolTip1.SetToolTip(this.txtEffectRate2, "Index conected with Item.iff");
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(50, 111);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(30, 13);
            this.label49.TabIndex = 28;
            this.label49.Text = "Rate";
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
            this.btnReabrir.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.btnReabrir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReabrir.Location = new System.Drawing.Point(308, 14);
            this.btnReabrir.Name = "btnReabrir";
            this.btnReabrir.Size = new System.Drawing.Size(97, 48);
            this.btnReabrir.TabIndex = 0;
            this.btnReabrir.TabStop = false;
            this.btnReabrir.Text = "Apply";
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
            this.btnNovo.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnNew;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.Location = new System.Drawing.Point(8, 14);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(97, 48);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.TabStop = false;
            this.btnNovo.Text = "New";
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
            this.btnRemover.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnRemove;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.Location = new System.Drawing.Point(108, 14);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(97, 48);
            this.btnRemover.TabIndex = 0;
            this.btnRemover.TabStop = false;
            this.btnRemover.Text = "Delete";
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnClone;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.Location = new System.Drawing.Point(208, 14);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(97, 48);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.TabStop = false;
            this.btnBackup.Text = "Copy";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDisk;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(408, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 48);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Update";
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
            this.bwGerarSql.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGerarSql_DoWork);
            this.bwGerarSql.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGerarSql_ProgressChanged);
            this.bwGerarSql.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGerarSql_RunWorkerCompleted);
            // 
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Arquivo (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Save File";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Pangya (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (Caddie.iff)";
            // 
            // diagSalvarSql
            // 
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "Mascot.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Save File SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Select the file folder";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel3.Text = "Total Items:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel5.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel6.Text = "Indexes:";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel7.Text = "0";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel8.Text = "Stop";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // FrmMascot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 548);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmMascot";
            this.Text = "Mascot - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMascotFormClosing);
            this.Load += new System.EventHandler(this.FrmMascot_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
            this.Panel5.ResumeLayout(false);
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // StatusStrip
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbTotalItens;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lbIndices;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;

        // ToolStrip
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton btnAbrirArquivo;
        private System.Windows.Forms.ToolStripButton menuSalvarComo;
        private System.Windows.Forms.ToolStripButton menuGerarSql;
        private System.Windows.Forms.ToolStripButton menuTypeid;
        private System.Windows.Forms.ToolStripButton menuBackup;

        // SplitContainer
        private System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.DataGridView ListaItem;
        private System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.PictureBox imgPersonagem;
        private System.Windows.Forms.Label Label36;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Label lbArquivo;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label Label39;
        private System.Windows.Forms.PictureBox PictureBox4;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.ComboBox ComboBox2;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.Label Label37;
        private System.Windows.Forms.Panel Panel4;

        // TabControl
        private System.Windows.Forms.TabControl tabForm;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.NumericUpDown txtPrice1Day;
        private System.Windows.Forms.Label Label19;
        private System.Windows.Forms.Label labeladd;
        private System.Windows.Forms.TextBox txtSprite1;
        private System.Windows.Forms.Button btnVerificarTYPEID;
        private System.Windows.Forms.CheckBox ckTempoAtivo;
        private System.Windows.Forms.Label Label29;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.RadioButton rbLevelMax;
        private System.Windows.Forms.RadioButton rbLevelMin;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.CheckBox ckAtivo;
        private System.Windows.Forms.PictureBox imgIcone;
        private System.Windows.Forms.TextBox txtIcone;
        private System.Windows.Forms.TextBox txtTypeID;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label lbContNome;
        private System.Windows.Forms.Label Label18;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox gbTempoVenda;
        private System.Windows.Forms.DateTimePicker dtTermino;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label Label28;
        private System.Windows.Forms.Label Label27;
        private System.Windows.Forms.GroupBox gbBotoes;
        private System.Windows.Forms.Button btnReabrir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnSalvar;

        // BackgroundWorkers
        private System.ComponentModel.BackgroundWorker bwSalvar;
        private System.ComponentModel.BackgroundWorker bwGerarSql;

        // File Dialogs
        private System.Windows.Forms.SaveFileDialog diagSalvarArquivo;
        private System.Windows.Forms.OpenFileDialog diagAbrirArquivo;
        private System.Windows.Forms.SaveFileDialog diagSalvarSql;
        private System.Windows.Forms.FolderBrowserDialog diagPasta;

        // ToolTip
        private System.Windows.Forms.ToolTip ToolTip1;

        // Additional Fields
        private System.Windows.Forms.TextBox txtSprite2;
        private System.Windows.Forms.Label Label5;

        // TabPage2
        private System.Windows.Forms.TabPage TabPage2;
         private System.Windows.Forms.Label Label12;
         private System.Windows.Forms.Label Label13;
         private System.Windows.Forms.Label Label14;
         private System.Windows.Forms.Label Label17;
           #endregion
        private Panel Panel10;
        private NumericUpDown attCurva;
        private NumericUpDown attSpin;
        private NumericUpDown attPrecisao;
        private NumericUpDown attControle;
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
        private Label label11;
        private Label label15;
        private Label label16;
        private Label label21;
        private CheckBox ckActiveMSG;
        private NumericUpDown BonusFlag;
        private NumericUpDown BonusPangRate;
        private Label label38;
        private Label label40;
        private Label label35;
        private TextBox txtChangePrice;
        private Label label34;
        private TextBox txtFlagMSG;
        private NumericUpDown EfeitoExpRate;
        private NumericUpDown EfeitoPangRate;
        private NumericUpDown EfeitoGauge;
        private NumericUpDown EfeitoDropRate;
        private NumericUpDown Efeito_PowerDrive;
        private Label label31;
        private TextBox txtSlotItem;
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
        public string Arquivo;
        private PangyaAPI.IFF.JP.Models.Data.Mascot oIff;
        public IFFFile<PangyaAPI.IFF.JP.Models.Data.Mascot> lsItens;
        public IFFFile<PangyaAPI.IFF.JP.Models.Data.Mascot> lsTemp;
        private bool Alterado;
        private BindingSource bs;
        private int lastRow;
        public long qtdItem;     
        private GroupBox GroupBox1;
        private CheckBox ckSpecial;
        private CheckBox ckDisplay;
        private CheckBox ckNew;
        private CheckBox ckDesativado;
        private CheckBox ckNormal;
        private CheckBox ckHot;
        private CheckBox ckGift;
        private GroupBox groupBox6;
        private Label label41;
        private NumericUpDown nrDay;
        private CheckBox ckTimeShopActive;
        private TabPage tabPage3;
        private Button BtnApplyDesc;
        private Button BtnCreateDesc;
        private Label label32;
        private TextBox txtDesc;
        private TabPage tabPage4;
        private Button BtnApplyAbility;
        private Button BtnNewAbility;
        private GroupBox groupBox2;
        private CheckBox txtEffectActive3;
        private Label label42;
        private CheckBox txtEffectActive2;
        private TextBox txtFlag2;
        private Label label43;
        private Label label44;
        private CheckBox txtEffectActive;
        private ComboBox cbType;
        private TextBox txtFlag;
        private ComboBox cbType3;
        private Label label45;
        private Label label46;
        private TextBox txtEffectRate3;
        private Label label47;
        private TextBox txtEffectRate;
        private ComboBox cbType2;
        private Label label48;
        private TextBox txtEffectRate2;
        private Label label49;
        private ToolStripDropDownButton menuMassa;
        private ToolStripSeparator ToolStripMenuItem1;
        private ToolStripMenuItem ApagarTodosToolStripMenuItem;
        private ToolStripMenuItem iFFToolStripMenuItem;
        private ToolStripMenuItem sQLInsertInventoryToolStripMenuItem;
        private ToolStripMenuItem cSVFileToolStripMenuItem;
        private ToolStripMenuItem itemShopToolStripMenuItem;
        private ToolStripMenuItem getItemActiveToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem copyItemToolStripMenuItem;
        private ToolStripMenuItem s8THToolStripMenuItem;
        private ToolStripMenuItem s8GBToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel toolStripStatusLabel7;
        private ToolStripStatusLabel toolStripStatusLabel8;
        private ToolStripProgressBar toolStripProgressBar1;
        private PictureBox PictureBox3;
    }
}