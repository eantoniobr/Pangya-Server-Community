using PangyaAPI.IFF.JP.Models;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
    partial class FrmItem
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label39 = new System.Windows.Forms.Label();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label30 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.txtPrice365Day = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPrice30Day = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPrice15Day = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice7Day = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPrice1Day = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnk = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.nrDay = new System.Windows.Forms.NumericUpDown();
            this.ckTimeShopActive = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSpecial = new System.Windows.Forms.CheckBox();
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.ckPSQ = new System.Windows.Forms.CheckBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.ckDesativado = new System.Windows.Forms.CheckBox();
            this.ckNormal = new System.Windows.Forms.CheckBox();
            this.ckHot = new System.Windows.Forms.CheckBox();
            this.ckGift = new System.Windows.Forms.CheckBox();
            this.txtQtd = new System.Windows.Forms.NumericUpDown();
            this.cbTipo2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.txtSprite = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lbContNome = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.gbTempoVenda = new System.Windows.Forms.GroupBox();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BtnApplyAbility = new System.Windows.Forms.Button();
            this.BtnNewAbility = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFlagAbility2 = new System.Windows.Forms.TextBox();
            this.txtEffectActive3 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEffectActive2 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEffectActive = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtFlagAbility = new System.Windows.Forms.TextBox();
            this.cbType3 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEffectRate3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEffectRate = new System.Windows.Forms.TextBox();
            this.cbType2 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtEffectRate2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
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
            this.BtnApplyDesc = new System.Windows.Forms.Button();
            this.BtnCreateDesc = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice365Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice30Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice15Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice7Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice1Day)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 570);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(809, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(508, 17);
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
            this.btnAbrirArquivo.ToolTipText = "Open File .iff";
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
            this.menuSalvarComo.Click += new System.EventHandler(this.MenuSalvar_Click);
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
            this.menuGerarSql.Click += new System.EventHandler(this.MenuSalvarSQL_Click);
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
            this.menuTypeid.Visible = false;
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
            this.menuBackup.Click += new System.EventHandler(this.MenuBackup_Click);
            // 
            // menuMassa
            // 
            this.menuMassa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMassa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ApagarTodosToolStripMenuItem,
            this.itemShopToolStripMenuItem,
            this.copyItemToolStripMenuItem});
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
            // 
            // sQLInsertInventoryToolStripMenuItem
            // 
            this.sQLInsertInventoryToolStripMenuItem.Name = "sQLInsertInventoryToolStripMenuItem";
            this.sQLInsertInventoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sQLInsertInventoryToolStripMenuItem.Text = "SQL Insert Inventory";
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
            this.itemShopToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
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
            this.copyItemToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.copyItemToolStripMenuItem.Text = "Convert Iff";
            // 
            // s8THToolStripMenuItem
            // 
            this.s8THToolStripMenuItem.Name = "s8THToolStripMenuItem";
            this.s8THToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.s8THToolStripMenuItem.Text = "S8 TH to JP";
            this.s8THToolStripMenuItem.Click += new System.EventHandler(this.ConvertS8TH_Click);
            // 
            // s8GBToolStripMenuItem
            // 
            this.s8GBToolStripMenuItem.Name = "s8GBToolStripMenuItem";
            this.s8GBToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
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
            this.SplitContainer1.Size = new System.Drawing.Size(809, 530);
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
            this.Panel3.Size = new System.Drawing.Size(277, 434);
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
            this.ListaItem.Size = new System.Drawing.Size(277, 434);
            this.ListaItem.TabIndex = 0;
            this.ListaItem.DefaultCellStyleChanged += new System.EventHandler(this.ListaItem_DefaultCellStyleChanged);
            this.ListaItem.RowsDefaultCellStyleChanged += new System.EventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
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
            this.lbArquivo.Size = new System.Drawing.Size(45, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Item.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.PictureBox3);
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.ComboBox1);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Controls.Add(this.Label30);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 461);
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
            // PictureBox3
            // 
            this.PictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox3.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.PictureBox3.Location = new System.Drawing.Point(6, 31);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(35, 35);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox3.TabIndex = 1;
            this.PictureBox3.TabStop = false;
            // 
            // imgStatus
            // 
            this.imgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgStatus.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.imgStatus.Location = new System.Drawing.Point(141, 30);
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
            this.ComboBox2.Location = new System.Drawing.Point(181, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(89, 21);
            this.ComboBox2.TabIndex = 1;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // ComboBox1
            // 
            this.ComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.ItemHeight = 13;
            this.ComboBox1.Items.AddRange(new object[] {
            "All",
            "Normal",
            "Box",
            "Artifact",
            "Artifact Mana",
            "Special Rules",
            "MemorialCoin",
            "Only GM"});
            this.ComboBox1.Location = new System.Drawing.Point(46, 44);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(89, 21);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
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
            this.Label37.Location = new System.Drawing.Point(178, 27);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(37, 13);
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(47, 28);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(28, 13);
            this.Label30.TabIndex = 10;
            this.Label30.Text = "Tipo";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(524, 524);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.tabPage2);
            this.tabForm.Controls.Add(this.tabPage3);
            this.tabForm.Controls.Add(this.tabPage4);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(514, 448);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.txtPrice365Day);
            this.TabPage1.Controls.Add(this.label21);
            this.TabPage1.Controls.Add(this.txtPrice30Day);
            this.TabPage1.Controls.Add(this.label22);
            this.TabPage1.Controls.Add(this.txtPrice15Day);
            this.TabPage1.Controls.Add(this.label23);
            this.TabPage1.Controls.Add(this.txtPrice7Day);
            this.TabPage1.Controls.Add(this.label24);
            this.TabPage1.Controls.Add(this.txtPrice1Day);
            this.TabPage1.Controls.Add(this.label25);
            this.TabPage1.Controls.Add(this.label11);
            this.TabPage1.Controls.Add(this.txtUnk);
            this.TabPage1.Controls.Add(this.groupBox6);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.txtQtd);
            this.TabPage1.Controls.Add(this.cbTipo2);
            this.TabPage1.Controls.Add(this.label5);
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
            this.TabPage1.Controls.Add(this.txtSprite);
            this.TabPage1.Controls.Add(this.txtDesconto);
            this.TabPage1.Controls.Add(this.txtPreco);
            this.TabPage1.Controls.Add(this.txtNome);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.lbContNome);
            this.TabPage1.Controls.Add(this.Label9);
            this.TabPage1.Controls.Add(this.Label10);
            this.TabPage1.Controls.Add(this.Label18);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.gbTempoVenda);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(506, 422);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            // 
            // txtPrice365Day
            // 
            this.txtPrice365Day.Location = new System.Drawing.Point(206, 334);
            this.txtPrice365Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice365Day.Name = "txtPrice365Day";
            this.txtPrice365Day.Size = new System.Drawing.Size(69, 21);
            this.txtPrice365Day.TabIndex = 65;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(132, 336);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 15);
            this.label21.TabIndex = 64;
            this.label21.Text = "Price 365D";
            // 
            // txtPrice30Day
            // 
            this.txtPrice30Day.Location = new System.Drawing.Point(206, 307);
            this.txtPrice30Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice30Day.Name = "txtPrice30Day";
            this.txtPrice30Day.Size = new System.Drawing.Size(69, 21);
            this.txtPrice30Day.TabIndex = 63;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(142, 309);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 15);
            this.label22.TabIndex = 62;
            this.label22.Text = "Price 30D";
            // 
            // txtPrice15Day
            // 
            this.txtPrice15Day.Location = new System.Drawing.Point(206, 280);
            this.txtPrice15Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice15Day.Name = "txtPrice15Day";
            this.txtPrice15Day.Size = new System.Drawing.Size(69, 21);
            this.txtPrice15Day.TabIndex = 61;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(142, 282);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 15);
            this.label23.TabIndex = 60;
            this.label23.Text = "Price 15D";
            // 
            // txtPrice7Day
            // 
            this.txtPrice7Day.Location = new System.Drawing.Point(67, 309);
            this.txtPrice7Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice7Day.Name = "txtPrice7Day";
            this.txtPrice7Day.Size = new System.Drawing.Size(69, 21);
            this.txtPrice7Day.TabIndex = 59;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 313);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 15);
            this.label24.TabIndex = 58;
            this.label24.Text = "Price 7D";
            // 
            // txtPrice1Day
            // 
            this.txtPrice1Day.Location = new System.Drawing.Point(67, 282);
            this.txtPrice1Day.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtPrice1Day.Name = "txtPrice1Day";
            this.txtPrice1Day.Size = new System.Drawing.Size(69, 21);
            this.txtPrice1Day.TabIndex = 57;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 284);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 15);
            this.label25.TabIndex = 56;
            this.label25.Text = "Price 1D";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 15);
            this.label11.TabIndex = 55;
            this.label11.Text = "Unk";
            // 
            // txtUnk
            // 
            this.txtUnk.Location = new System.Drawing.Point(206, 256);
            this.txtUnk.Name = "txtUnk";
            this.txtUnk.Size = new System.Drawing.Size(69, 21);
            this.txtUnk.TabIndex = 54;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label41);
            this.groupBox6.Controls.Add(this.nrDay);
            this.groupBox6.Controls.Add(this.ckTimeShopActive);
            this.groupBox6.Location = new System.Drawing.Point(378, 353);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(118, 62);
            this.groupBox6.TabIndex = 53;
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
            this.GroupBox1.Controls.Add(this.ckPSQ);
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            this.GroupBox1.Location = new System.Drawing.Point(378, 177);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 170);
            this.GroupBox1.TabIndex = 30;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Shop Flag";
            // 
            // ckSpecial
            // 
            this.ckSpecial.AutoSize = true;
            this.ckSpecial.Enabled = false;
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
            // ckPSQ
            // 
            this.ckPSQ.AutoSize = true;
            this.ckPSQ.Location = new System.Drawing.Point(9, 112);
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
            this.ckDesativado.Location = new System.Drawing.Point(9, 147);
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
            this.ckNormal.Location = new System.Drawing.Point(9, 130);
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
            // txtQtd
            // 
            this.txtQtd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtd.Location = new System.Drawing.Point(49, 143);
            this.txtQtd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(101, 22);
            this.txtQtd.TabIndex = 29;
            this.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbTipo2
            // 
            this.cbTipo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo2.FormattingEnabled = true;
            this.cbTipo2.ItemHeight = 15;
            this.cbTipo2.Items.AddRange(new object[] {
            "Normal",
            "Box",
            "Artifact",
            "Artifact Mana",
            "Special Rules",
            "MemorialCoin",
            "Only GM"});
            this.cbTipo2.Location = new System.Drawing.Point(49, 256);
            this.cbTipo2.Name = "cbTipo2";
            this.cbTipo2.Size = new System.Drawing.Size(117, 23);
            this.cbTipo2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tipo";
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
            this.ckTempoAtivo.Location = new System.Drawing.Point(290, 188);
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
            this.Label29.Location = new System.Drawing.Point(13, 172);
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
            this.rbLevelMax.Location = new System.Drawing.Point(379, 77);
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
            this.ckAtivo.Location = new System.Drawing.Point(442, 45);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 4;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // imgIcone
            // 
            this.imgIcone.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgIcone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch; this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.txtIcone.Location = new System.Drawing.Point(323, 43);
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
            this.Label8.Location = new System.Drawing.Point(345, 117);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 15);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Money";
            // 
            // txtSprite
            // 
            this.txtSprite.Location = new System.Drawing.Point(238, 143);
            this.txtSprite.MaxLength = 40;
            this.txtSprite.Name = "txtSprite";
            this.txtSprite.Size = new System.Drawing.Size(163, 21);
            this.txtSprite.TabIndex = 8;
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
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(312, 21);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(285, 46);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(30, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Icon";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(126, 46);
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
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(10, 146);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(29, 15);
            this.Label9.TabIndex = 10;
            this.Label9.Text = "Qtd.";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(193, 146);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(39, 15);
            this.Label10.TabIndex = 10;
            this.Label10.Text = "Sprite";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(177, 119);
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
            this.gbTempoVenda.Location = new System.Drawing.Point(13, 177);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TikiShop";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ckTikiActived);
            this.groupBox5.Controls.Add(this.label49);
            this.groupBox5.Controls.Add(this.txtBonusMax);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.label43);
            this.groupBox5.Controls.Add(this.txtBonusProb);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.label45);
            this.groupBox5.Controls.Add(this.txtBonusMin);
            this.groupBox5.Controls.Add(this.txtTikiPang);
            this.groupBox5.Controls.Add(this.txtTypeTikiShop);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.txtMileagePts);
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Controls.Add(this.txtTikiPts);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.txtTPItemCount);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(493, 163);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TikiShop";
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnApplyDesc);
            this.tabPage3.Controls.Add(this.BtnCreateDesc);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.txtDesc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(506, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Desc Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 13);
            this.label31.TabIndex = 5;
            this.label31.Text = "Item Desc Information:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 26);
            this.txtDesc.MaxLength = 512;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(494, 207);
            this.txtDesc.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BtnApplyAbility);
            this.tabPage4.Controls.Add(this.BtnNewAbility);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(506, 422);
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
            this.BtnApplyAbility.Location = new System.Drawing.Point(400, 207);
            this.BtnApplyAbility.Name = "BtnApplyAbility";
            this.BtnApplyAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyAbility.TabIndex = 50;
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
            this.BtnNewAbility.Location = new System.Drawing.Point(297, 207);
            this.BtnNewAbility.Name = "BtnNewAbility";
            this.BtnNewAbility.Size = new System.Drawing.Size(97, 48);
            this.BtnNewAbility.TabIndex = 51;
            this.BtnNewAbility.TabStop = false;
            this.BtnNewAbility.Text = "New";
            this.BtnNewAbility.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNewAbility.UseVisualStyleBackColor = true;
            this.BtnNewAbility.Click += new System.EventHandler(this.BtnNewAbility_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFlagAbility2);
            this.groupBox2.Controls.Add(this.txtEffectActive3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEffectActive2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEffectActive);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.txtFlagAbility);
            this.groupBox2.Controls.Add(this.cbType3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtEffectRate3);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtEffectRate);
            this.groupBox2.Controls.Add(this.cbType2);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtEffectRate2);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(9, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 199);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config Effect";
            // 
            // txtFlagAbility2
            // 
            this.txtFlagAbility2.Location = new System.Drawing.Point(388, 45);
            this.txtFlagAbility2.Name = "txtFlagAbility2";
            this.txtFlagAbility2.Size = new System.Drawing.Size(94, 20);
            this.txtFlagAbility2.TabIndex = 44;
            this.ToolTip1.SetToolTip(this.txtFlagAbility2, "Index conected with Item.iff");
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(341, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Flag 2";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Effect Nº 3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(341, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Flag 1";
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
            // txtFlagAbility
            // 
            this.txtFlagAbility.Location = new System.Drawing.Point(388, 16);
            this.txtFlagAbility.Name = "txtFlagAbility";
            this.txtFlagAbility.Size = new System.Drawing.Size(94, 20);
            this.txtFlagAbility.TabIndex = 31;
            this.ToolTip1.SetToolTip(this.txtFlagAbility, "Index conected with Item.iff");
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Rate";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Effect Nº 2";
            // 
            // txtEffectRate3
            // 
            this.txtEffectRate3.Location = new System.Drawing.Point(95, 171);
            this.txtEffectRate3.Name = "txtEffectRate3";
            this.txtEffectRate3.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate3.TabIndex = 29;
            this.ToolTip1.SetToolTip(this.txtEffectRate3, "Index conected with Item.iff");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Effect Nº 1";
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(55, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "Rate";
            // 
            // txtEffectRate2
            // 
            this.txtEffectRate2.Location = new System.Drawing.Point(95, 107);
            this.txtEffectRate2.Name = "txtEffectRate2";
            this.txtEffectRate2.Size = new System.Drawing.Size(94, 20);
            this.txtEffectRate2.TabIndex = 27;
            this.ToolTip1.SetToolTip(this.txtEffectRate2, "Index conected with Item.iff");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(50, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Rate";
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 451);
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
            this.btnNovo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
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
            this.diagSalvarSql.FileName = "Item.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Save File SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Select the file folder";
            // 
            // BtnApplyDesc
            // 
            this.BtnApplyDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyDesc.Location = new System.Drawing.Point(403, 239);
            this.BtnApplyDesc.Name = "BtnApplyDesc";
            this.BtnApplyDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyDesc.TabIndex = 12;
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
            this.BtnCreateDesc.Location = new System.Drawing.Point(300, 239);
            this.BtnCreateDesc.Name = "BtnCreateDesc";
            this.BtnCreateDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnCreateDesc.TabIndex = 13;
            this.BtnCreateDesc.TabStop = false;
            this.BtnCreateDesc.Text = "New";
            this.BtnCreateDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreateDesc.UseVisualStyleBackColor = true;
            this.BtnCreateDesc.Click += new System.EventHandler(this.BtnCreateDesc_Click);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 592);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmItem";
            this.Text = "Item - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmItemFormClosing);
            this.Load += new System.EventHandler(this.FrmItem_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice365Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice30Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice15Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice7Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice1Day)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
        private StatusStrip StatusStrip1 = new StatusStrip();
        private ToolStripStatusLabel ToolStripStatusLabel1 = new ToolStripStatusLabel();
        private ToolStripStatusLabel lbTotalItens = new ToolStripStatusLabel();
        private ToolStripStatusLabel ToolStripStatusLabel4 = new ToolStripStatusLabel();
        private ToolStripStatusLabel lbIndices = new ToolStripStatusLabel();
        private ToolStripStatusLabel ToolStripStatusLabel2 = new ToolStripStatusLabel();
        private ToolStripStatusLabel lbStatus = new ToolStripStatusLabel();
        private ToolStripProgressBar pbStatus = new ToolStripProgressBar();
        private ToolStrip ToolStrip1 = new ToolStrip();
        private ToolStripButton btnAbrirArquivo = new ToolStripButton();
        private ToolStripButton menuSalvarComo = new ToolStripButton();
        private ToolStripButton menuGerarSql = new ToolStripButton();
        private ToolStripButton menuTypeid = new ToolStripButton();
        private ToolStripButton menuBackup = new ToolStripButton();
        private SplitContainer SplitContainer1 = new SplitContainer();
        private Panel Panel3 = new Panel();
        private DataGridView ListaItem = new DataGridView();
        private Panel Panel2 = new Panel();
        private PictureBox PictureBox2 = new PictureBox();
        private Label lbArquivo = new Label();
        private Panel Panel1 = new Panel();
        private Label Label39 = new Label();
        private PictureBox imgStatus = new PictureBox();
        private PictureBox PictureBox4 = new PictureBox();
        private PictureBox PictureBox1 = new PictureBox();
        private ComboBox ComboBox2 = new ComboBox();
        private TextBox txtPesquisa = new TextBox();
        private Label lblSearchCount = new Label();
        private Label Label37 = new Label();
        private Panel Panel4 = new Panel();
        private TabControl tabForm = new TabControl();
        private TabPage TabPage1 = new TabPage();
        private PictureBox PictureBox3 = new PictureBox();
        private Button btnVerificarTYPEID = new Button();
        private CheckBox ckTempoAtivo = new CheckBox();
        private ComboBox ComboBox1 = new ComboBox();
        private Label Label29 = new Label();
        private Label Label2 = new Label();
        private RadioButton rbLevelMax = new RadioButton();
        private Label Label30 = new Label();
        private RadioButton rbLevelMin = new RadioButton();
        private ComboBox cbLevel = new ComboBox();
        private ComboBox cbTipo = new ComboBox();
        private CheckBox ckAtivo = new CheckBox();
        private PictureBox imgIcone = new PictureBox();
        private TextBox txtIcone = new TextBox();
        private TextBox txtTypeID = new TextBox();
        private Label Label6 = new Label();
        private Label Label8 = new Label();
        private TextBox txtDesconto = new TextBox();
        private TextBox txtPreco = new TextBox();
        private TextBox txtNome = new TextBox();
        private Label Label7 = new Label();
        private Label Label3 = new Label();
        private Label lbContNome = new Label();
        private Label Label18 = new Label();
        private Label Label4 = new Label();
        private Label Label1 = new Label();
        private GroupBox gbTempoVenda = new GroupBox();
        private DateTimePicker dtTermino = new DateTimePicker();
        private DateTimePicker dtInicio = new DateTimePicker();
        private Label Label28 = new Label();
        private Label Label27 = new Label();
        private GroupBox gbBotoes = new GroupBox();
        private Button btnReabrir = new Button();
        private Button btnNovo = new Button();
        private Button btnRemover = new Button();
        private Button btnBackup = new Button();
        private Button btnSalvar = new Button();
        private BackgroundWorker bwSalvar = new BackgroundWorker();
        private BackgroundWorker bwGerarSql = new BackgroundWorker();
        private SaveFileDialog diagSalvarArquivo = new SaveFileDialog();
        private OpenFileDialog diagAbrirArquivo = new OpenFileDialog();
        private SaveFileDialog diagSalvarSql = new SaveFileDialog();
        private FolderBrowserDialog diagPasta = new FolderBrowserDialog();
        private ToolTip ToolTip1 = new ToolTip();
        private TextBox txtSprite = new TextBox();
        private Label Label10 = new Label();
        private NumericUpDown txtQtd = new NumericUpDown();
        private Label Label9 = new Label();
        public string Arquivo;
         public IFFFile<PangyaAPI.IFF.JP.Models.Data.Item> lsItens;
        public IFFFile<PangyaAPI.IFF.JP.Models.Data.Item> lsTemp;
        public byte[] bStart;
        private bool Alterado;
        private BindingSource bs;
        private int lastRow;
        public long qtdItem;      
        #endregion

        private ComboBox cbTipo2;
        private Label label5;
        private GroupBox GroupBox1;
        private CheckBox ckSpecial;
        private CheckBox ckDisplay;
        private CheckBox ckPSQ;
        private CheckBox ckNew;
        private CheckBox ckDesativado;  
        private CheckBox ckNormal;
        private CheckBox ckHot;
        private CheckBox ckGift;
        private TabPage tabPage2;
        private GroupBox groupBox5;
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
        private IContainer components;
        private GroupBox groupBox6;
        private Label label41;
        private NumericUpDown nrDay;
        private CheckBox ckTimeShopActive;
        private Label label11;
        private TextBox txtUnk;
        private TabPage tabPage3;
        private Label label31;
        private TextBox txtDesc;
        private TabPage tabPage4;
        private Button BtnApplyAbility;
        private Button BtnNewAbility;
        private GroupBox groupBox2;
        private CheckBox txtEffectActive3;
        private Label label12;
        private CheckBox txtEffectActive2;
        private Label label13;
        private Label label14;
        private CheckBox txtEffectActive;
        private ComboBox cbType;
        private TextBox txtFlagAbility;
        private ComboBox cbType3;
        private Label label15;
        private Label label16;
        private TextBox txtEffectRate3;
        private Label label17;
        private TextBox txtEffectRate;
        private ComboBox cbType2;
        private Label label19;
        private TextBox txtEffectRate2;
        private Label label20;
        private TextBox txtFlagAbility2;
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
        private NumericUpDown txtPrice365Day;
        private Label label21;
        private NumericUpDown txtPrice30Day;
        private Label label22;
        private NumericUpDown txtPrice15Day;
        private Label label23;
        private NumericUpDown txtPrice7Day;
        private Label label24;
        private NumericUpDown txtPrice1Day;
        private Label label25;
        private Button BtnApplyDesc;
        private Button BtnCreateDesc;
    }
}