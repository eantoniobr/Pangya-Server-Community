using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
   public partial class FrmPart
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPart));
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addIFFFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.cmbCharacter = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nrDay = new System.Windows.Forms.NumericUpDown();
            this.ckTimeShopActive = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtHide = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRentValue = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cbRarity = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.btnVerificarTYPEID = new System.Windows.Forms.Button();
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
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
            this.Label9 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ckSlotNPC = new System.Windows.Forms.CheckBox();
            this.ckSlotCaddie = new System.Windows.Forms.CheckBox();
            this.ckSlotCharacter = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckRental = new System.Windows.Forms.CheckBox();
            this.ckSpecial = new System.Windows.Forms.CheckBox();
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.ckPSQ = new System.Windows.Forms.CheckBox();
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
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.imgIcone = new System.Windows.Forms.PictureBox();
            this.txtIcone = new System.Windows.Forms.TextBox();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckTikiActived = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtBonusMax = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtBonusProb = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtBonusMin = new System.Windows.Forms.TextBox();
            this.txtTikiPang = new System.Windows.Forms.TextBox();
            this.txtTypeTikiShop = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtMileagePts = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtTikiPts = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtTPItemCount = new System.Windows.Forms.TextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUn = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtAddWith = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtSubParte2 = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.txtSubParte1 = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtTextura6 = new System.Windows.Forms.TextBox();
            this.txtTextura4 = new System.Windows.Forms.TextBox();
            this.txtTextura2 = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.txtTextura5 = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtTextura3 = new System.Windows.Forms.TextBox();
            this.labeladd = new System.Windows.Forms.Label();
            this.txtTextura1 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BtnApplyDesc = new System.Windows.Forms.Button();
            this.BtnCreateDesc = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BtnApplyAbility = new System.Windows.Forms.Button();
            this.BtnNewAbility = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtEffectActive3 = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtEffectActive2 = new System.Windows.Forms.CheckBox();
            this.txtFlag2 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtEffectActive = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.cbType3 = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtEffectRate3 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtEffectRate = new System.Windows.Forms.TextBox();
            this.cbType2 = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtEffectRate2 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imgPersonagem2 = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).BeginInit();
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
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem2)).BeginInit();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 613);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(807, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(505, 17);
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
            this.menuMassa});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(807, 40);
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
            // menuDividir
            // 
            this.menuDividir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDividir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DividirArquivoToolStripMenuItem,
            this.UnirArquivoToolStripMenuItem});
            this.menuDividir.Enabled = false;
            this.menuDividir.Image = global::Pangya_Modern_Editor.Properties.Resources.plugin;
            this.menuDividir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuDividir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDividir.Name = "menuDividir";
            this.menuDividir.Size = new System.Drawing.Size(45, 37);
            this.menuDividir.ToolTipText = "Dividir Arquivo";
            // 
            // DividirArquivoToolStripMenuItem
            // 
            this.DividirArquivoToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.plugin_delete;
            this.DividirArquivoToolStripMenuItem.Name = "DividirArquivoToolStripMenuItem";
            this.DividirArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.DividirArquivoToolStripMenuItem.Text = "Dividir arquivo";
            this.DividirArquivoToolStripMenuItem.Click += new System.EventHandler(this.DividirArquivoToolStripMenuItem_Click);
            // 
            // UnirArquivoToolStripMenuItem
            // 
            this.UnirArquivoToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.plugin_add;
            this.UnirArquivoToolStripMenuItem.Name = "UnirArquivoToolStripMenuItem";
            this.UnirArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.UnirArquivoToolStripMenuItem.Text = "Unir arquivo";
            this.UnirArquivoToolStripMenuItem.Click += new System.EventHandler(this.UnirArquivoToolStripMenuItem_Click);
            // 
            // menuMassa
            // 
            this.menuMassa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMassa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ApagarTodosToolStripMenuItem,
            this.itemShopToolStripMenuItem,
            this.copyItemToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuMassa.Enabled = false;
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
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // ApagarTodosToolStripMenuItem
            // 
            this.ApagarTodosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFFToolStripMenuItem,
            this.sQLInsertInventoryToolStripMenuItem,
            this.cSVFileToolStripMenuItem});
            this.ApagarTodosToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDisk;
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            this.ApagarTodosToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ApagarTodosToolStripMenuItem.Text = "Save";
            // 
            // iFFToolStripMenuItem
            // 
            this.iFFToolStripMenuItem.Name = "iFFToolStripMenuItem";
            this.iFFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iFFToolStripMenuItem.Text = "Items Select (IFF)";
            this.iFFToolStripMenuItem.Click += new System.EventHandler(this.ApagarTodosToolStripMenuItem_Click);
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
            this.cSVFileToolStripMenuItem.Click += new System.EventHandler(this.cSVFileToolStripMenuItem_Click);
            // 
            // itemShopToolStripMenuItem
            // 
            this.itemShopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getItemActiveToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.itemShopToolStripMenuItem.Name = "itemShopToolStripMenuItem";
            this.itemShopToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.itemShopToolStripMenuItem.Text = "Item Shop";
            // 
            // getItemActiveToolStripMenuItem
            // 
            this.getItemActiveToolStripMenuItem.Name = "getItemActiveToolStripMenuItem";
            this.getItemActiveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.getItemActiveToolStripMenuItem.Text = "Get Item In PSQ";
            this.getItemActiveToolStripMenuItem.Click += new System.EventHandler(this.getItemToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyItemToolStripMenuItem
            // 
            this.copyItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s8THToolStripMenuItem,
            this.s8GBToolStripMenuItem});
            this.copyItemToolStripMenuItem.Name = "copyItemToolStripMenuItem";
            this.copyItemToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addIFFFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addIFFFileToolStripMenuItem
            // 
            this.addIFFFileToolStripMenuItem.Name = "addIFFFileToolStripMenuItem";
            this.addIFFFileToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addIFFFileToolStripMenuItem.Text = "Add IFF File";
            this.addIFFFileToolStripMenuItem.Click += new System.EventHandler(this.addIFFFileToolStripMenuItem_Click);
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
            this.SplitContainer1.Size = new System.Drawing.Size(807, 573);
            this.SplitContainer1.SplitterDistance = 276;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(276, 477);
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
            this.ListaItem.Size = new System.Drawing.Size(276, 477);
            this.ListaItem.TabIndex = 0;
            this.ListaItem.DefaultCellStyleChanged += new System.EventHandler(this.ListaItem_DefaultCellStyleChanged);
            this.ListaItem.RowsDefaultCellStyleChanged += new System.EventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
            this.ListaItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaItem_CellClick);
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            this.ListaItem.Sorted += new System.EventHandler(this.ListaItem_Sorted);
            this.ListaItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaItem_KeyDown);
            this.ListaItem.MouseHover += new System.EventHandler(this.ListaItem_MouseHover);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Controls.Add(this.lbArquivo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(276, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(44, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Part.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.imgPersonagem);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.cmbCharacter);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Controls.Add(this.Label36);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 504);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(276, 69);
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
            this.imgStatus.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.imgStatus.Location = new System.Drawing.Point(133, 31);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(32, 35);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStatus.TabIndex = 1;
            this.imgStatus.TabStop = false;
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
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.imgPersonagem.Location = new System.Drawing.Point(3, 31);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
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
            "Pangs",
            "Points",
            "Rental",
            "Hide",
            "NoIcon"});
            this.ComboBox2.Location = new System.Drawing.Point(171, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(63, 21);
            this.ComboBox2.TabIndex = 1;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // cmbCharacter
            // 
            this.cmbCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharacter.FormattingEnabled = true;
            this.cmbCharacter.ItemHeight = 13;
            this.cmbCharacter.Items.AddRange(new object[] {
            "All",
            "Nuri",
            "Hana",
            "Azer",
            "Cecilia",
            "Max",
            "Kooh",
            "Arin",
            "Kaz",
            "Lucia",
            "Nell",
            "Spika",
            "Nuri R",
            "Hana R",
            "Cecilia R",
            "Men Only",
            "Women Only"});
            this.cmbCharacter.Location = new System.Drawing.Point(43, 44);
            this.cmbCharacter.Name = "cmbCharacter";
            this.cmbCharacter.Size = new System.Drawing.Size(79, 21);
            this.cmbCharacter.TabIndex = 1;
            this.cmbCharacter.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            this.txtPesquisa.Location = new System.Drawing.Point(27, 5);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(163, 20);
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
            this.Label37.Location = new System.Drawing.Point(168, 28);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(37, 13);
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(40, 28);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(53, 13);
            this.Label36.TabIndex = 10;
            this.Label36.Text = "Character";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(523, 567);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.tabPage3);
            this.tabForm.Controls.Add(this.TabPage2);
            this.tabForm.Controls.Add(this.tabPage4);
            this.tabForm.Controls.Add(this.tabPage5);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(513, 491);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.groupBox6);
            this.TabPage1.Controls.Add(this.txtPos);
            this.TabPage1.Controls.Add(this.label21);
            this.TabPage1.Controls.Add(this.txtHide);
            this.TabPage1.Controls.Add(this.label22);
            this.TabPage1.Controls.Add(this.txtRentValue);
            this.TabPage1.Controls.Add(this.label40);
            this.TabPage1.Controls.Add(this.cbRarity);
            this.TabPage1.Controls.Add(this.label30);
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.Panel10);
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label29);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.rbLevelMax);
            this.TabPage1.Controls.Add(this.rbLevelMin);
            this.TabPage1.Controls.Add(this.cbLevel);
            this.TabPage1.Controls.Add(this.cbTipo);
            this.TabPage1.Controls.Add(this.cbCategoria);
            this.TabPage1.Controls.Add(this.ckAtivo);
            this.TabPage1.Controls.Add(this.imgIcone);
            this.TabPage1.Controls.Add(this.txtIcone);
            this.TabPage1.Controls.Add(this.txtTypeID);
            this.TabPage1.Controls.Add(this.Label6);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.Label5);
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
            this.TabPage1.Size = new System.Drawing.Size(505, 465);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nrDay);
            this.groupBox6.Controls.Add(this.ckTimeShopActive);
            this.groupBox6.Controls.Add(this.label58);
            this.groupBox6.Location = new System.Drawing.Point(380, 395);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(119, 62);
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Shop";
            // 
            // nrDay
            // 
            this.nrDay.Location = new System.Drawing.Point(41, 19);
            this.nrDay.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nrDay.Name = "nrDay";
            this.nrDay.Size = new System.Drawing.Size(47, 21);
            this.nrDay.TabIndex = 18;
            // 
            // ckTimeShopActive
            // 
            this.ckTimeShopActive.AutoSize = true;
            this.ckTimeShopActive.Location = new System.Drawing.Point(14, 41);
            this.ckTimeShopActive.Name = "ckTimeShopActive";
            this.ckTimeShopActive.Size = new System.Drawing.Size(87, 19);
            this.ckTimeShopActive.TabIndex = 17;
            this.ckTimeShopActive.Text = "Time Active";
            this.ckTimeShopActive.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(9, 21);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(31, 15);
            this.label58.TabIndex = 12;
            this.label58.Text = "Day:";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(74, 225);
            this.txtPos.MaxLength = 40;
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(76, 21);
            this.txtPos.TabIndex = 36;
            this.ToolTip1.SetToolTip(this.txtPos, "no edit, for test");
            this.txtPos.TextChanged += new System.EventHandler(this.txtPos_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 228);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 15);
            this.label21.TabIndex = 35;
            this.label21.Text = "PosMask";
            // 
            // txtHide
            // 
            this.txtHide.Location = new System.Drawing.Point(74, 251);
            this.txtHide.MaxLength = 40;
            this.txtHide.Name = "txtHide";
            this.txtHide.Size = new System.Drawing.Size(76, 21);
            this.txtHide.TabIndex = 34;
            this.ToolTip1.SetToolTip(this.txtHide, "no edit, for test");
            this.txtHide.TextChanged += new System.EventHandler(this.txtHide_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 254);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 15);
            this.label22.TabIndex = 33;
            this.label22.Text = "HideMask";
            // 
            // txtRentValue
            // 
            this.txtRentValue.Location = new System.Drawing.Point(254, 225);
            this.txtRentValue.MaxLength = 40;
            this.txtRentValue.Name = "txtRentValue";
            this.txtRentValue.Size = new System.Drawing.Size(99, 21);
            this.txtRentValue.TabIndex = 32;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(179, 228);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(75, 15);
            this.label40.TabIndex = 31;
            this.label40.Text = "Rental Pang";
            // 
            // cbRarity
            // 
            this.cbRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRarity.FormattingEnabled = true;
            this.cbRarity.Items.AddRange(new object[] {
            "Normal",
            "Incomum",
            "Points",
            "Rare"});
            this.cbRarity.Location = new System.Drawing.Point(423, 117);
            this.cbRarity.Name = "cbRarity";
            this.cbRarity.Size = new System.Drawing.Size(70, 23);
            this.cbRarity.TabIndex = 29;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(383, 120);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 15);
            this.label30.TabIndex = 30;
            this.label30.Text = "Rarity";
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
            this.ckTempoAtivo.Location = new System.Drawing.Point(281, 156);
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            this.ckTempoAtivo.Size = new System.Drawing.Size(87, 19);
            this.ckTempoAtivo.TabIndex = 27;
            this.ckTempoAtivo.Text = "Time Active";
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            this.ckTempoAtivo.CheckedChanged += new System.EventHandler(this.ckTempoAtivo_CheckedChanged);
            this.ckTempoAtivo.TextChanged += new System.EventHandler(this.ckTempoAtivo_CheckedChanged);
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
            this.Panel10.Controls.Add(this.Label9);
            this.Panel10.Controls.Add(this.Label14);
            this.Panel10.Controls.Add(this.Label13);
            this.Panel10.Controls.Add(this.Label12);
            this.Panel10.Controls.Add(this.Label11);
            this.Panel10.Controls.Add(this.Label10);
            this.Panel10.Controls.Add(this.Label16);
            this.Panel10.Controls.Add(this.Label15);
            this.Panel10.Location = new System.Drawing.Point(2, 280);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(372, 183);
            this.Panel10.TabIndex = 25;
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
            this.att2Curva.ValueChanged += new System.EventHandler(this.att2Curva_ValueChanged);
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
            this.attCurva.ValueChanged += new System.EventHandler(this.attCurva_ValueChanged);
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
            this.att2Spin.ValueChanged += new System.EventHandler(this.att2Spin_ValueChanged);
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
            this.attSpin.ValueChanged += new System.EventHandler(this.attSpin_ValueChanged);
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
            this.att2Precisao.ValueChanged += new System.EventHandler(this.att2Precisao_ValueChanged);
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
            this.attPrecisao.ValueChanged += new System.EventHandler(this.attPrecisao_ValueChanged);
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
            this.att2Controle.ValueChanged += new System.EventHandler(this.att2Controle_ValueChanged);
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
            this.attControle.ValueChanged += new System.EventHandler(this.attControle_ValueChanged);
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
            this.att2Forca.ValueChanged += new System.EventHandler(this.att2Forca_ValueChanged);
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
            this.attForca.ValueChanged += new System.EventHandler(this.attForca_ValueChanged);
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
            this.Label12.Location = new System.Drawing.Point(27, 78);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(49, 15);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "IMPACT";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(10, 51);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(66, 15);
            this.Label11.TabIndex = 7;
            this.Label11.Text = "CONTROL";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(24, 26);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(52, 15);
            this.Label10.TabIndex = 7;
            this.Label10.Text = "POWER";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(316, 8);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(35, 15);
            this.Label16.TabIndex = 10;
            this.Label16.Text = "Slots";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(258, 8);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(35, 15);
            this.Label15.TabIndex = 10;
            this.Label15.Text = "Stats";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.ckSlotNPC);
            this.GroupBox2.Controls.Add(this.ckSlotCaddie);
            this.GroupBox2.Controls.Add(this.ckSlotCharacter);
            this.GroupBox2.Location = new System.Drawing.Point(380, 145);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(117, 73);
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Slot Card";
            // 
            // ckSlotNPC
            // 
            this.ckSlotNPC.AutoSize = true;
            this.ckSlotNPC.Location = new System.Drawing.Point(5, 50);
            this.ckSlotNPC.Name = "ckSlotNPC";
            this.ckSlotNPC.Size = new System.Drawing.Size(76, 19);
            this.ckSlotNPC.TabIndex = 35;
            this.ckSlotNPC.Text = "Slot NPC";
            this.ckSlotNPC.UseVisualStyleBackColor = true;
            this.ckSlotNPC.CheckedChanged += new System.EventHandler(this.ckSlotNPC_CheckedChanged);
            // 
            // ckSlotCaddie
            // 
            this.ckSlotCaddie.AutoSize = true;
            this.ckSlotCaddie.Location = new System.Drawing.Point(5, 32);
            this.ckSlotCaddie.Name = "ckSlotCaddie";
            this.ckSlotCaddie.Size = new System.Drawing.Size(90, 19);
            this.ckSlotCaddie.TabIndex = 34;
            this.ckSlotCaddie.Text = "Slot Caddie";
            this.ckSlotCaddie.UseVisualStyleBackColor = true;
            this.ckSlotCaddie.CheckedChanged += new System.EventHandler(this.ckSlotCaddie_CheckedChanged);
            // 
            // ckSlotCharacter
            // 
            this.ckSlotCharacter.AutoSize = true;
            this.ckSlotCharacter.Location = new System.Drawing.Point(5, 14);
            this.ckSlotCharacter.Name = "ckSlotCharacter";
            this.ckSlotCharacter.Size = new System.Drawing.Size(104, 19);
            this.ckSlotCharacter.TabIndex = 33;
            this.ckSlotCharacter.Text = "Slot Character";
            this.ckSlotCharacter.UseVisualStyleBackColor = true;
            this.ckSlotCharacter.CheckedChanged += new System.EventHandler(this.ckSlotCharacter_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ckRental);
            this.GroupBox1.Controls.Add(this.ckSpecial);
            this.GroupBox1.Controls.Add(this.ckDisplay);
            this.GroupBox1.Controls.Add(this.ckPSQ);
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            this.GroupBox1.Location = new System.Drawing.Point(379, 217);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 178);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Shop Flag";
            this.ToolTip1.SetToolTip(this.GroupBox1, "Active Item in PSQ AND SHOP");
            // 
            // ckRental
            // 
            this.ckRental.AutoSize = true;
            this.ckRental.Location = new System.Drawing.Point(9, 123);
            this.ckRental.Name = "ckRental";
            this.ckRental.Size = new System.Drawing.Size(89, 19);
            this.ckRental.TabIndex = 9;
            this.ckRental.Text = "Item Rental";
            this.ckRental.UseVisualStyleBackColor = true;
            // 
            // ckSpecial
            // 
            this.ckSpecial.AutoSize = true;
            this.ckSpecial.Enabled = false;
            this.ckSpecial.Location = new System.Drawing.Point(9, 55);
            this.ckSpecial.Name = "ckSpecial";
            this.ckSpecial.Size = new System.Drawing.Size(94, 19);
            this.ckSpecial.TabIndex = 8;
            this.ckSpecial.Text = "Item Special";
            this.ckSpecial.UseVisualStyleBackColor = true;
            this.ckSpecial.CheckedChanged += new System.EventHandler(this.ckSpecial_CheckedChanged);
            // 
            // ckDisplay
            // 
            this.ckDisplay.AutoSize = true;
            this.ckDisplay.Location = new System.Drawing.Point(9, 89);
            this.ckDisplay.Name = "ckDisplay";
            this.ckDisplay.Size = new System.Drawing.Size(94, 19);
            this.ckDisplay.TabIndex = 6;
            this.ckDisplay.Text = "Only Display";
            this.ckDisplay.UseVisualStyleBackColor = true;
            this.ckDisplay.CheckedChanged += new System.EventHandler(this.ckDisplay_CheckedChanged);
            // 
            // ckPSQ
            // 
            this.ckPSQ.AutoSize = true;
            this.ckPSQ.Location = new System.Drawing.Point(9, 106);
            this.ckPSQ.Name = "ckPSQ";
            this.ckPSQ.Size = new System.Drawing.Size(107, 19);
            this.ckPSQ.TabIndex = 7;
            this.ckPSQ.Text = "Personal shop";
            this.ckPSQ.UseVisualStyleBackColor = true;
            this.ckPSQ.CheckedChanged += new System.EventHandler(this.ckPSQ_CheckedChanged);
            // 
            // ckNew
            // 
            this.ckNew.AutoSize = true;
            this.ckNew.Location = new System.Drawing.Point(9, 19);
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
            this.ckDesativado.Location = new System.Drawing.Point(9, 157);
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
            this.ckNormal.Location = new System.Drawing.Point(9, 140);
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
            this.ckHot.Location = new System.Drawing.Point(9, 38);
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
            this.ckGift.Location = new System.Drawing.Point(9, 72);
            this.ckGift.Name = "ckGift";
            this.ckGift.Size = new System.Drawing.Size(95, 19);
            this.ckGift.TabIndex = 3;
            this.ckGift.Text = "Item Giftable";
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
            this.Label2.Size = new System.Drawing.Size(482, 2);
            this.Label2.TabIndex = 21;
            // 
            // rbLevelMax
            // 
            this.rbLevelMax.AutoSize = true;
            this.rbLevelMax.Location = new System.Drawing.Point(295, 87);
            this.rbLevelMax.Name = "rbLevelMax";
            this.rbLevelMax.Size = new System.Drawing.Size(81, 19);
            this.rbLevelMax.TabIndex = 7;
            this.rbLevelMax.Text = "Level Max.";
            this.rbLevelMax.UseVisualStyleBackColor = true;
            // 
            // rbLevelMin
            // 
            this.rbLevelMin.AutoSize = true;
            this.rbLevelMin.Checked = true;
            this.rbLevelMin.Location = new System.Drawing.Point(295, 67);
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
            this.cbLevel.SelectedIndexChanged += new System.EventHandler(this.Alterou);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Hide",
            "Cookies",
            "Pangs"});
            this.cbTipo.Location = new System.Drawing.Point(304, 116);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(70, 23);
            this.cbTipo.TabIndex = 9;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.Alterou);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Items.AddRange(new object[] {
            "TOP",
            "BOTTOM",
            "HEAD",
            "GLOVES",
            "SHOES",
            "EQUIP OR BASE",
            "SUB_LEG",
            "UCC",
            "UCC DRAW ONLY",
            "UCC COPY ONLY"});
            this.cbCategoria.Location = new System.Drawing.Point(254, 251);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(120, 23);
            this.cbCategoria.TabIndex = 1;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(438, 13);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 4;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
            this.ckAtivo.CheckedChanged += new System.EventHandler(this.ckAtivo_CheckedChanged);
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
            this.txtIcone.Location = new System.Drawing.Point(316, 43);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.Size = new System.Drawing.Size(177, 21);
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
            this.Label8.Location = new System.Drawing.Point(258, 119);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 15);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Money";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(222, 255);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(32, 15);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Type";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(187, 116);
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(70, 21);
            this.txtDesconto.TabIndex = 8;
            this.txtDesconto.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(49, 116);
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(68, 21);
            this.txtPreco.TabIndex = 8;
            this.txtPreco.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(154, 11);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(238, 21);
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
            this.lbContNome.Location = new System.Drawing.Point(398, 15);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 9;
            this.lbContNome.Text = "0/64";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(123, 119);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(62, 15);
            this.Label18.TabIndex = 10;
            this.Label18.Text = "Disccount";
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
            this.gbTempoVenda.Location = new System.Drawing.Point(13, 145);
            this.gbTempoVenda.Name = "gbTempoVenda";
            this.gbTempoVenda.Size = new System.Drawing.Size(359, 73);
            this.gbTempoVenda.TabIndex = 10;
            this.gbTempoVenda.TabStop = false;
            this.gbTempoVenda.Text = "Sell Programation";
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
            this.Label28.Size = new System.Drawing.Size(53, 15);
            this.Label28.TabIndex = 10;
            this.Label28.Text = "End Sell";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(36, 24);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(56, 15);
            this.Label27.TabIndex = 10;
            this.Label27.Text = "Start Sell";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(505, 465);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TikiShop";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckTikiActived);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.txtBonusMax);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.label43);
            this.groupBox4.Controls.Add(this.txtBonusProb);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Controls.Add(this.label45);
            this.groupBox4.Controls.Add(this.txtBonusMin);
            this.groupBox4.Controls.Add(this.txtTikiPang);
            this.groupBox4.Controls.Add(this.txtTypeTikiShop);
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.txtMileagePts);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.txtTikiPts);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.txtTPItemCount);
            this.groupBox4.Location = new System.Drawing.Point(6, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 163);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TikiShop";
            // 
            // ckTikiActived
            // 
            this.ckTikiActived.AutoSize = true;
            this.ckTikiActived.Location = new System.Drawing.Point(392, 18);
            this.ckTikiActived.Name = "ckTikiActived";
            this.ckTikiActived.Size = new System.Drawing.Size(99, 17);
            this.ckTikiActived.TabIndex = 15;
            this.ckTikiActived.Text = "Active (internal)";
            this.ckTikiActived.UseVisualStyleBackColor = true;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(252, 134);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(63, 13);
            this.label49.TabIndex = 14;
            this.label49.Text = "Bonus Max:";
            // 
            // txtBonusMax
            // 
            this.txtBonusMax.Location = new System.Drawing.Point(318, 131);
            this.txtBonusMax.MaxLength = 40;
            this.txtBonusMax.Name = "txtBonusMax";
            this.txtBonusMax.Size = new System.Drawing.Size(147, 20);
            this.txtBonusMax.TabIndex = 13;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(23, 134);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(65, 13);
            this.label42.TabIndex = 12;
            this.label42.Text = "Bonus Prob:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(255, 105);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(60, 13);
            this.label43.TabIndex = 12;
            this.label43.Text = "Bonus Min:";
            // 
            // txtBonusProb
            // 
            this.txtBonusProb.Location = new System.Drawing.Point(88, 130);
            this.txtBonusProb.MaxLength = 40;
            this.txtBonusProb.Name = "txtBonusProb";
            this.txtBonusProb.Size = new System.Drawing.Size(154, 20);
            this.txtBonusProb.TabIndex = 11;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(255, 79);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(60, 13);
            this.label44.TabIndex = 12;
            this.label44.Text = "Tiki Pangs:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(258, 51);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(54, 13);
            this.label45.TabIndex = 12;
            this.label45.Text = "Type Tiki:";
            this.ToolTip1.SetToolTip(this.label45, "Is Type \'rare\', \'normal\', \'cookies\'");
            // 
            // txtBonusMin
            // 
            this.txtBonusMin.Location = new System.Drawing.Point(318, 102);
            this.txtBonusMin.MaxLength = 40;
            this.txtBonusMin.Name = "txtBonusMin";
            this.txtBonusMin.Size = new System.Drawing.Size(147, 20);
            this.txtBonusMin.TabIndex = 11;
            // 
            // txtTikiPang
            // 
            this.txtTikiPang.Location = new System.Drawing.Point(318, 76);
            this.txtTikiPang.MaxLength = 40;
            this.txtTikiPang.Name = "txtTikiPang";
            this.txtTikiPang.Size = new System.Drawing.Size(147, 20);
            this.txtTikiPang.TabIndex = 11;
            // 
            // txtTypeTikiShop
            // 
            this.txtTypeTikiShop.Location = new System.Drawing.Point(318, 48);
            this.txtTypeTikiShop.MaxLength = 40;
            this.txtTypeTikiShop.Name = "txtTypeTikiShop";
            this.txtTypeTikiShop.Size = new System.Drawing.Size(147, 20);
            this.txtTypeTikiShop.TabIndex = 11;
            this.ToolTip1.SetToolTip(this.txtTypeTikiShop, "Is Type \'rare\', \'normal\', \'cookies\'");
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(17, 107);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 13);
            this.label46.TabIndex = 12;
            this.label46.Text = "Mileage Pts:";
            // 
            // txtMileagePts
            // 
            this.txtMileagePts.Location = new System.Drawing.Point(88, 104);
            this.txtMileagePts.MaxLength = 40;
            this.txtMileagePts.Name = "txtMileagePts";
            this.txtMileagePts.Size = new System.Drawing.Size(154, 20);
            this.txtMileagePts.TabIndex = 11;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(37, 81);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(45, 13);
            this.label47.TabIndex = 12;
            this.label47.Text = "Tiki Pts:";
            // 
            // txtTikiPts
            // 
            this.txtTikiPts.Location = new System.Drawing.Point(88, 78);
            this.txtTikiPts.MaxLength = 40;
            this.txtTikiPts.Name = "txtTikiPts";
            this.txtTikiPts.Size = new System.Drawing.Size(154, 20);
            this.txtTikiPts.TabIndex = 11;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(9, 53);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(76, 13);
            this.label48.TabIndex = 12;
            this.label48.Text = "Tiki Count Pts:";
            // 
            // txtTPItemCount
            // 
            this.txtTPItemCount.Location = new System.Drawing.Point(88, 50);
            this.txtTPItemCount.MaxLength = 40;
            this.txtTPItemCount.Name = "txtTPItemCount";
            this.txtTPItemCount.Size = new System.Drawing.Size(154, 20);
            this.txtTPItemCount.TabIndex = 11;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(505, 465);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Part";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtUn);
            this.GroupBox3.Controls.Add(this.label33);
            this.GroupBox3.Controls.Add(this.txtPoints);
            this.GroupBox3.Controls.Add(this.label59);
            this.GroupBox3.Controls.Add(this.txtAddWith);
            this.GroupBox3.Controls.Add(this.label41);
            this.GroupBox3.Controls.Add(this.Label20);
            this.GroupBox3.Controls.Add(this.Label35);
            this.GroupBox3.Controls.Add(this.Label26);
            this.GroupBox3.Controls.Add(this.txtSubParte2);
            this.GroupBox3.Controls.Add(this.txtModelo);
            this.GroupBox3.Controls.Add(this.Label38);
            this.GroupBox3.Controls.Add(this.Label24);
            this.GroupBox3.Controls.Add(this.txtSubParte1);
            this.GroupBox3.Controls.Add(this.Label19);
            this.GroupBox3.Controls.Add(this.txtTextura6);
            this.GroupBox3.Controls.Add(this.txtTextura4);
            this.GroupBox3.Controls.Add(this.txtTextura2);
            this.GroupBox3.Controls.Add(this.Label25);
            this.GroupBox3.Controls.Add(this.txtTextura5);
            this.GroupBox3.Controls.Add(this.Label23);
            this.GroupBox3.Controls.Add(this.txtTextura3);
            this.GroupBox3.Controls.Add(this.labeladd);
            this.GroupBox3.Controls.Add(this.txtTextura1);
            this.GroupBox3.Location = new System.Drawing.Point(6, 4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(493, 201);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            // 
            // txtUn
            // 
            this.txtUn.Location = new System.Drawing.Point(71, 160);
            this.txtUn.MaxLength = 40;
            this.txtUn.Name = "txtUn";
            this.txtUn.Size = new System.Drawing.Size(155, 20);
            this.txtUn.TabIndex = 21;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(16, 164);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 20;
            this.label33.Text = "Unknown";
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(311, 160);
            this.txtPoints.MaxLength = 40;
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(155, 20);
            this.txtPoints.TabIndex = 19;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(272, 164);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(36, 13);
            this.label59.TabIndex = 18;
            this.label59.Text = "Points";
            // 
            // txtAddWith
            // 
            this.txtAddWith.Location = new System.Drawing.Point(311, 102);
            this.txtAddWith.MaxLength = 32;
            this.txtAddWith.Name = "txtAddWith";
            this.txtAddWith.Size = new System.Drawing.Size(155, 20);
            this.txtAddWith.TabIndex = 17;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(257, 105);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(51, 13);
            this.label41.TabIndex = 16;
            this.label41.Text = "Add With";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(33, 105);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(36, 13);
            this.Label20.TabIndex = 12;
            this.Label20.Text = "Model";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(251, 134);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(58, 13);
            this.Label35.TabIndex = 12;
            this.Label35.Text = "Sub-Item 2";
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(257, 76);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(52, 13);
            this.Label26.TabIndex = 12;
            this.Label26.Text = "Texture 6";
            // 
            // txtSubParte2
            // 
            this.txtSubParte2.Location = new System.Drawing.Point(311, 131);
            this.txtSubParte2.MaxLength = 40;
            this.txtSubParte2.Name = "txtSubParte2";
            this.txtSubParte2.Size = new System.Drawing.Size(155, 20);
            this.txtSubParte2.TabIndex = 11;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(71, 102);
            this.txtModelo.MaxLength = 40;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(155, 20);
            this.txtModelo.TabIndex = 11;
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Location = new System.Drawing.Point(11, 134);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(58, 13);
            this.Label38.TabIndex = 12;
            this.Label38.Text = "Sub-Item 1";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(257, 50);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(52, 13);
            this.Label24.TabIndex = 12;
            this.Label24.Text = "Texture 5";
            // 
            // txtSubParte1
            // 
            this.txtSubParte1.Location = new System.Drawing.Point(71, 131);
            this.txtSubParte1.MaxLength = 40;
            this.txtSubParte1.Name = "txtSubParte1";
            this.txtSubParte1.Size = new System.Drawing.Size(155, 20);
            this.txtSubParte1.TabIndex = 11;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(257, 22);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(52, 13);
            this.Label19.TabIndex = 12;
            this.Label19.Text = "Texture 4";
            // 
            // txtTextura6
            // 
            this.txtTextura6.Location = new System.Drawing.Point(311, 73);
            this.txtTextura6.MaxLength = 40;
            this.txtTextura6.Name = "txtTextura6";
            this.txtTextura6.Size = new System.Drawing.Size(155, 20);
            this.txtTextura6.TabIndex = 11;
            // 
            // txtTextura4
            // 
            this.txtTextura4.Location = new System.Drawing.Point(311, 47);
            this.txtTextura4.MaxLength = 40;
            this.txtTextura4.Name = "txtTextura4";
            this.txtTextura4.Size = new System.Drawing.Size(155, 20);
            this.txtTextura4.TabIndex = 11;
            // 
            // txtTextura2
            // 
            this.txtTextura2.Location = new System.Drawing.Point(311, 19);
            this.txtTextura2.MaxLength = 40;
            this.txtTextura2.Name = "txtTextura2";
            this.txtTextura2.Size = new System.Drawing.Size(155, 20);
            this.txtTextura2.TabIndex = 11;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(17, 78);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(52, 13);
            this.Label25.TabIndex = 12;
            this.Label25.Text = "Texture 3";
            // 
            // txtTextura5
            // 
            this.txtTextura5.Location = new System.Drawing.Point(71, 75);
            this.txtTextura5.MaxLength = 40;
            this.txtTextura5.Name = "txtTextura5";
            this.txtTextura5.Size = new System.Drawing.Size(155, 20);
            this.txtTextura5.TabIndex = 11;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(17, 52);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(52, 13);
            this.Label23.TabIndex = 12;
            this.Label23.Text = "Texture 2";
            // 
            // txtTextura3
            // 
            this.txtTextura3.Location = new System.Drawing.Point(71, 49);
            this.txtTextura3.MaxLength = 40;
            this.txtTextura3.Name = "txtTextura3";
            this.txtTextura3.Size = new System.Drawing.Size(155, 20);
            this.txtTextura3.TabIndex = 11;
            // 
            // labeladd
            // 
            this.labeladd.AutoSize = true;
            this.labeladd.Location = new System.Drawing.Point(17, 24);
            this.labeladd.Name = "labeladd";
            this.labeladd.Size = new System.Drawing.Size(52, 13);
            this.labeladd.TabIndex = 12;
            this.labeladd.Text = "Texture 1";
            // 
            // txtTextura1
            // 
            this.txtTextura1.Location = new System.Drawing.Point(71, 21);
            this.txtTextura1.MaxLength = 40;
            this.txtTextura1.Name = "txtTextura1";
            this.txtTextura1.Size = new System.Drawing.Size(155, 20);
            this.txtTextura1.TabIndex = 11;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BtnApplyDesc);
            this.tabPage4.Controls.Add(this.BtnCreateDesc);
            this.tabPage4.Controls.Add(this.label31);
            this.tabPage4.Controls.Add(this.txtDesc);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(505, 465);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Desc Info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BtnApplyDesc
            // 
            this.BtnApplyDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyDesc.Location = new System.Drawing.Point(403, 245);
            this.BtnApplyDesc.Name = "BtnApplyDesc";
            this.BtnApplyDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyDesc.TabIndex = 2;
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
            this.BtnCreateDesc.Location = new System.Drawing.Point(300, 245);
            this.BtnCreateDesc.Name = "BtnCreateDesc";
            this.BtnCreateDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnCreateDesc.TabIndex = 3;
            this.BtnCreateDesc.TabStop = false;
            this.BtnCreateDesc.Text = "New";
            this.BtnCreateDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreateDesc.UseVisualStyleBackColor = true;
            this.BtnCreateDesc.Click += new System.EventHandler(this.BtnCreateDesc_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 13);
            this.label31.TabIndex = 1;
            this.label31.Text = "Item Desc Information:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 36);
            this.txtDesc.MaxLength = 512;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(494, 207);
            this.txtDesc.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BtnApplyAbility);
            this.tabPage5.Controls.Add(this.BtnNewAbility);
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(505, 465);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Ability Info";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BtnApplyAbility
            // 
            this.BtnApplyAbility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyAbility.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyAbility.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyAbility.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyAbility.Location = new System.Drawing.Point(400, 211);
            this.BtnApplyAbility.Name = "BtnApplyAbility";
            this.BtnApplyAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyAbility.TabIndex = 46;
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
            this.BtnNewAbility.Location = new System.Drawing.Point(297, 211);
            this.BtnNewAbility.Name = "BtnNewAbility";
            this.BtnNewAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnNewAbility.TabIndex = 47;
            this.BtnNewAbility.TabStop = false;
            this.BtnNewAbility.Text = "New";
            this.BtnNewAbility.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNewAbility.UseVisualStyleBackColor = true;
            this.BtnNewAbility.Click += new System.EventHandler(this.BtnNewAbility_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtEffectActive3);
            this.groupBox5.Controls.Add(this.label50);
            this.groupBox5.Controls.Add(this.txtEffectActive2);
            this.groupBox5.Controls.Add(this.txtFlag2);
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.txtEffectActive);
            this.groupBox5.Controls.Add(this.cbType);
            this.groupBox5.Controls.Add(this.txtFlag);
            this.groupBox5.Controls.Add(this.cbType3);
            this.groupBox5.Controls.Add(this.label53);
            this.groupBox5.Controls.Add(this.label54);
            this.groupBox5.Controls.Add(this.txtEffectRate3);
            this.groupBox5.Controls.Add(this.label55);
            this.groupBox5.Controls.Add(this.txtEffectRate);
            this.groupBox5.Controls.Add(this.cbType2);
            this.groupBox5.Controls.Add(this.label56);
            this.groupBox5.Controls.Add(this.txtEffectRate2);
            this.groupBox5.Controls.Add(this.label57);
            this.groupBox5.Location = new System.Drawing.Point(9, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(488, 199);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Config Effect";
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
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(341, 48);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(36, 13);
            this.label50.TabIndex = 34;
            this.label50.Text = "Flag 2";
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
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(20, 144);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(59, 13);
            this.label51.TabIndex = 40;
            this.label51.Text = "Effect Nº 3";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(341, 19);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(36, 13);
            this.label52.TabIndex = 32;
            this.label52.Text = "Flag 1";
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
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(50, 174);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(30, 13);
            this.label53.TabIndex = 30;
            this.label53.Text = "Rate";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(20, 86);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(59, 13);
            this.label54.TabIndex = 39;
            this.label54.Text = "Effect Nº 2";
            // 
            // txtEffectRate3
            // 
            this.txtEffectRate3.Location = new System.Drawing.Point(95, 171);
            this.txtEffectRate3.Name = "txtEffectRate3";
            this.txtEffectRate3.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate3.TabIndex = 29;
            this.ToolTip1.SetToolTip(this.txtEffectRate3, "Index conected with Item.iff");
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(25, 19);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(59, 13);
            this.label55.TabIndex = 38;
            this.label55.Text = "Effect Nº 1";
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
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(55, 47);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(30, 13);
            this.label56.TabIndex = 26;
            this.label56.Text = "Rate";
            // 
            // txtEffectRate2
            // 
            this.txtEffectRate2.Location = new System.Drawing.Point(95, 107);
            this.txtEffectRate2.Name = "txtEffectRate2";
            this.txtEffectRate2.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate2.TabIndex = 27;
            this.ToolTip1.SetToolTip(this.txtEffectRate2, "Index conected with Item.iff");
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(50, 111);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(30, 13);
            this.label57.TabIndex = 28;
            this.label57.Text = "Rate";
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 494);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(513, 70);
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
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "none.png");
            this.ImageList1.Images.SetKeyName(1, "nuri_classic.png");
            this.ImageList1.Images.SetKeyName(2, "hana_classic.png");
            this.ImageList1.Images.SetKeyName(3, "azer.png");
            this.ImageList1.Images.SetKeyName(4, "cecilia_classic.png");
            this.ImageList1.Images.SetKeyName(5, "max.png");
            this.ImageList1.Images.SetKeyName(6, "kooh.png");
            this.ImageList1.Images.SetKeyName(7, "arin.png");
            this.ImageList1.Images.SetKeyName(8, "kaz.png");
            this.ImageList1.Images.SetKeyName(9, "lucia_renew.png");
            this.ImageList1.Images.SetKeyName(10, "nell.png");
            this.ImageList1.Images.SetKeyName(11, "spika.png");
            this.ImageList1.Images.SetKeyName(12, "nuri_renew.png");
            this.ImageList1.Images.SetKeyName(13, "hana_renew.png");
            this.ImageList1.Images.SetKeyName(14, "cecilia_renew.png");
            // 
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Save File Part.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (Part.iff)";
            // 
            // diagSalvarSql
            // 
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "Part.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Save File SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Select the file folder";
            // 
            // imgPersonagem2
            // 
            this.imgPersonagem2.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem2.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.imgPersonagem2.Location = new System.Drawing.Point(770, 2);
            this.imgPersonagem2.Name = "imgPersonagem2";
            this.imgPersonagem2.Size = new System.Drawing.Size(32, 35);
            this.imgPersonagem2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPersonagem2.TabIndex = 1;
            this.imgPersonagem2.TabStop = false;
            // 
            // FrmPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 635);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.imgPersonagem2);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmPart";
            this.Text = "Part - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPartFormClosing);
            this.Load += new System.EventHandler(this.FrmPart_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).EndInit();
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
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        StatusStrip StatusStrip1;
        ToolStripStatusLabel ToolStripStatusLabel1;
        ToolStripStatusLabel lbTotalItens;
        ToolStripStatusLabel ToolStripStatusLabel4;
        ToolStripStatusLabel lbIndices;
        ToolStripStatusLabel ToolStripStatusLabel2;
        ToolStripStatusLabel lbStatus;
        ToolStripProgressBar pbStatus;
        ToolStrip ToolStrip1;
        SplitContainer SplitContainer1;
        Panel Panel3;
        DataGridView ListaItem;
        Panel Panel2;
        Label lbArquivo;
        Panel Panel1;
        Label Label39;
        ComboBox ComboBox2;
        ComboBox cmbCharacter;
        TextBox txtPesquisa;
        Label lblSearchCount;
        Label Label37;
        Label Label36;
        Panel Panel4;
        TabControl tabForm;
        TabPage TabPage1;
        CheckBox ckTempoAtivo;
        Panel Panel10;
        NumericUpDown att2Curva;
        NumericUpDown attCurva;
        NumericUpDown att2Spin;
        NumericUpDown attSpin;
        NumericUpDown att2Precisao;
        NumericUpDown attPrecisao;
        NumericUpDown att2Controle;
        NumericUpDown attControle;
        NumericUpDown att2Forca;
        NumericUpDown attForca;
        Panel Panel9;
        Panel barraCurva;
        Panel Panel8;
        Panel barraSpin;
        Panel Panel7;
        Panel barraPrecisao;
        Panel Panel6;
        Panel barraControle;
        Panel Panel5;
        Panel barraForca;
        Label Label17;
        Label Label9;
        Label Label14;
        Label Label13;
        Label Label12;
        Label Label11;
        Label Label10;
        Label Label16;
        Label Label15;
        GroupBox GroupBox2;
        GroupBox GroupBox1;
        CheckBox ckNew;
        CheckBox ckDesativado;
        CheckBox ckNormal;
        CheckBox ckHot;
        CheckBox ckGift;
        CheckBox ckDisplay;
        CheckBox ckPSQ;
        CheckBox ckSpecial;
        Label Label29;
        Label Label2;
        RadioButton rbLevelMax;
        RadioButton rbLevelMin;
        ComboBox cbLevel;
        ComboBox cbTipo;
        ComboBox cbCategoria;
        CheckBox ckAtivo;
        TextBox txtIcone;
        TextBox txtTypeID;
        Label Label6;
        Label Label8;
        Label Label5;
        TextBox txtDesconto;
        TextBox txtPreco;
        TextBox txtNome;
        Label Label7;
        Label Label3;
        Label lbContNome;
        Label Label18;
        Label Label4;
        Label Label1;
        GroupBox gbTempoVenda;
        DateTimePicker dtTermino;
        DateTimePicker dtInicio;
        Label Label28;
        Label Label27;
        TabPage TabPage2;
        Label Label20;
        TextBox txtModelo;
        Label Label35;
        TextBox txtSubParte2;
        Label Label38;
        TextBox txtSubParte1;
        GroupBox GroupBox3;
        Label Label26;
        Label Label24;
        Label Label19;
        TextBox txtTextura6;
        TextBox txtTextura4;
        TextBox txtTextura2;
        Label Label25;
        TextBox txtTextura5;
        Label Label23;
        TextBox txtTextura3;
        Label labeladd;
        GroupBox gbBotoes;
        BackgroundWorker bwSalvar;
        BackgroundWorker bwGerarSql;
        SaveFileDialog diagSalvarArquivo;
        OpenFileDialog diagAbrirArquivo;
        SaveFileDialog diagSalvarSql;
        FolderBrowserDialog diagPasta;
        ToolTip ToolTip1;
        PictureBox PictureBox2;
        PictureBox imgStatus;
        PictureBox PictureBox4;
        PictureBox imgPersonagem;
        PictureBox PictureBox1;
        Button btnVerificarTYPEID;
        PictureBox imgIcone;
        Button btnReabrir;
        Button btnNovo;
        Button btnRemover;
        Button btnBackup;
        Button btnSalvar;
        PictureBox imgPersonagem2;
        ToolStripButton btnAbrirArquivo;
        ToolStripButton menuSalvarComo;
        ToolStripButton menuGerarSql;
        ToolStripButton menuTypeid;
        ToolStripButton menuBackup;
        ToolStripDropDownButton menuMassa;
        ToolStripSeparator ToolStripMenuItem1;
        ToolStripMenuItem ApagarTodosToolStripMenuItem;
        private ToolStripDropDownButton menuDividir;
        private ToolStripMenuItem DividirArquivoToolStripMenuItem;
        private ToolStripMenuItem UnirArquivoToolStripMenuItem;
        private ImageList ImageList1;
        public string Arquivo;
         public IFFFile<Part> lsItens;
        public IFFFile<Part> lsTemp;
        public byte[] bStart;
        private bool Alterado;
        private BindingSource bs;
        private int lastRow;
        public long qtdItem;
        #endregion

        private TabPage tabPage3;
        private GroupBox groupBox4;
        internal CheckBox ckTikiActived;
        private Label label49;
        private TextBox txtBonusMax;
        private Label label42;
        private Label label43;
        private TextBox txtBonusProb;
        private Label label44;
        private Label label45;
        private TextBox txtBonusMin;
        private TextBox txtTikiPang;
        private TextBox txtTypeTikiShop;
        private Label label46;
        private TextBox txtMileagePts;
        private Label label47;
        private TextBox txtTikiPts;
        private Label label48;
        private TextBox txtTPItemCount;
        private ComboBox cbRarity;
        private Label label30;
        private TabPage tabPage4;
        private Label label31;
        private TextBox txtDesc;
        private IContainer components;
        private TextBox txtTextura1;
        private ToolStripMenuItem iFFToolStripMenuItem;
        private ToolStripMenuItem sQLInsertInventoryToolStripMenuItem;
        private ToolStripMenuItem itemShopToolStripMenuItem;
        private ToolStripMenuItem getItemActiveToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem cSVFileToolStripMenuItem;
        private ToolStripMenuItem copyItemToolStripMenuItem;
        private ToolStripMenuItem s8THToolStripMenuItem;
        private ToolStripMenuItem s8GBToolStripMenuItem;
        private CheckBox ckRental;
        private TextBox txtRentValue;
        private Label label40;
        private TextBox txtAddWith;
        private Label label41;
        private CheckBox ckSlotCaddie;
        private CheckBox ckSlotCharacter;
        private Button BtnApplyDesc;
        private Button BtnCreateDesc;
        private TextBox txtPos;
        private Label label21;
        private TextBox txtHide;
        private Label label22;
        private TabPage tabPage5;
        private GroupBox groupBox5;
        private CheckBox txtEffectActive3;
        private Label label50;
        private CheckBox txtEffectActive2;
        private TextBox txtFlag2;
        private Label label51;
        private Label label52;
        private CheckBox txtEffectActive;
        private ComboBox cbType;
        private TextBox txtFlag;
        private ComboBox cbType3;
        private Label label53;
        private Label label54;
        private TextBox txtEffectRate3;
        private Label label55;
        private TextBox txtEffectRate;
        private ComboBox cbType2;
        private Label label56;
        private TextBox txtEffectRate2;
        private Label label57;
        private Button BtnApplyAbility;
        private Button BtnNewAbility;
        private GroupBox groupBox6;
        private NumericUpDown nrDay;
        private CheckBox ckTimeShopActive;
        private Label label58;
        private TextBox txtUn;
        private Label label33;
        private TextBox txtPoints;
        private Label label59;
        private CheckBox ckSlotNPC;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem addIFFFileToolStripMenuItem;
    }
}