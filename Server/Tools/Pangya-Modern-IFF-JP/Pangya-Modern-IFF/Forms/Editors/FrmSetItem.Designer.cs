using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using Pangya_Modern_Editor.Properties;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
    partial class FrmSetItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.cSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cbSet = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.txtUnFlag = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.nrDay = new System.Windows.Forms.NumericUpDown();
            this.ckTimeShopActive = new System.Windows.Forms.CheckBox();
            this.cbSetTipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSpecial = new System.Windows.Forms.CheckBox();
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.ckDesativado = new System.Windows.Forms.CheckBox();
            this.ckNormal = new System.Windows.Forms.CheckBox();
            this.ckHot = new System.Windows.Forms.CheckBox();
            this.ckGift = new System.Windows.Forms.CheckBox();
            this.btnVerificarTYPEID = new System.Windows.Forms.Button();
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
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
            this.gbTempoVenda = new System.Windows.Forms.GroupBox();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.NumItens = new System.Windows.Forms.NumericUpDown();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.img_10 = new System.Windows.Forms.PictureBox();
            this.typeid_10 = new System.Windows.Forms.TextBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.qtd_10 = new System.Windows.Forms.TextBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.gb5 = new System.Windows.Forms.GroupBox();
            this.img_5 = new System.Windows.Forms.PictureBox();
            this.typeid_5 = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.qtd_5 = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.img_9 = new System.Windows.Forms.PictureBox();
            this.typeid_9 = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.qtd_9 = new System.Windows.Forms.TextBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.gb4 = new System.Windows.Forms.GroupBox();
            this.img_4 = new System.Windows.Forms.PictureBox();
            this.typeid_4 = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.qtd_4 = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.img_8 = new System.Windows.Forms.PictureBox();
            this.typeid_8 = new System.Windows.Forms.TextBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.qtd_8 = new System.Windows.Forms.TextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.img_3 = new System.Windows.Forms.PictureBox();
            this.typeid_3 = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.qtd_3 = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.img_7 = new System.Windows.Forms.PictureBox();
            this.typeid_7 = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.qtd_7 = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.img_2 = new System.Windows.Forms.PictureBox();
            this.typeid_2 = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.qtd_2 = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.img_6 = new System.Windows.Forms.PictureBox();
            this.typeid_6 = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.qtd_6 = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.img_1 = new System.Windows.Forms.PictureBox();
            this.typeid_1 = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.qtd_1 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnApplyDesc = new System.Windows.Forms.Button();
            this.BtnCreateDesc = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
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
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumItens)).BeginInit();
            this.GroupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_10)).BeginInit();
            this.gb5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_5)).BeginInit();
            this.GroupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_9)).BeginInit();
            this.gb4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_4)).BeginInit();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_8)).BeginInit();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_3)).BeginInit();
            this.GroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_7)).BeginInit();
            this.gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_2)).BeginInit();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_6)).BeginInit();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_1)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 561);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(812, 22);
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
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(50, 17);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(521, 17);
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
            this.ToolStrip1.Size = new System.Drawing.Size(812, 40);
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
            this.menuGerarSql.ToolTipText = "Generate Sql";
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
            this.cSVFileToolStripMenuItem});
            this.ApagarTodosToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDisk;
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            this.ApagarTodosToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ApagarTodosToolStripMenuItem.Text = "Save";
            // 
            // iFFToolStripMenuItem
            // 
            this.iFFToolStripMenuItem.Name = "iFFToolStripMenuItem";
            this.iFFToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.iFFToolStripMenuItem.Text = "Items Select (IFF)";
            // 
            // cSVFileToolStripMenuItem
            // 
            this.cSVFileToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnExcel;
            this.cSVFileToolStripMenuItem.Name = "cSVFileToolStripMenuItem";
            this.cSVFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cSVFileToolStripMenuItem.Text = "CSV File";
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
            this.SplitContainer1.Size = new System.Drawing.Size(812, 521);
            this.SplitContainer1.SplitterDistance = 291;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(291, 425);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaItem.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.ListaItem.Size = new System.Drawing.Size(291, 425);
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
            this.Panel2.Size = new System.Drawing.Size(291, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(65, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "SetItem.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.cbSet);
            this.Panel1.Controls.Add(this.label42);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 452);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(291, 69);
            this.Panel1.TabIndex = 0;
            // 
            // cbSet
            // 
            this.cbSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSet.FormattingEnabled = true;
            this.cbSet.Items.AddRange(new object[] {
            "UNKNOWN_0",
            "CHAR_SET",
            "CHAR_SET_NEW",
            "NO VIEW SHOP",
            "CLUB_SET",
            "BALL",
            "ITEM ACTIVE",
            "ITEM PASSIVE",
            "CARD/PACK",
            "RING"});
            this.cbSet.Location = new System.Drawing.Point(134, 44);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(140, 21);
            this.cbSet.TabIndex = 54;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(131, 28);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(31, 13);
            this.label42.TabIndex = 55;
            this.label42.Text = "Type";
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
            this.imgStatus.Location = new System.Drawing.Point(4, 30);
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
            "Pangs",
            "Cookies",
            "Hide"});
            this.ComboBox2.Location = new System.Drawing.Point(44, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(85, 21);
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
            this.txtPesquisa.Size = new System.Drawing.Size(170, 20);
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
            this.Label37.Location = new System.Drawing.Point(41, 27);
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
            this.Panel4.Size = new System.Drawing.Size(513, 515);
            this.Panel4.TabIndex = 2;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.TabPage2);
            this.tabForm.Controls.Add(this.tabPage3);
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForm.Enabled = false;
            this.tabForm.Location = new System.Drawing.Point(5, 3);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(503, 439);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.txtUnFlag);
            this.TabPage1.Controls.Add(this.label10);
            this.TabPage1.Controls.Add(this.groupBox2);
            this.TabPage1.Controls.Add(this.cbSetTipo);
            this.TabPage1.Controls.Add(this.label9);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
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
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.gbTempoVenda);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(495, 413);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            this.TabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // txtUnFlag
            // 
            this.txtUnFlag.Location = new System.Drawing.Point(242, 231);
            this.txtUnFlag.MaxLength = 40;
            this.txtUnFlag.Name = "txtUnFlag";
            this.txtUnFlag.Size = new System.Drawing.Size(96, 21);
            this.txtUnFlag.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 55;
            this.label10.Text = "UnFlag";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.nrDay);
            this.groupBox2.Controls.Add(this.ckTimeShopActive);
            this.groupBox2.Location = new System.Drawing.Point(361, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 62);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Shop";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 20);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(31, 15);
            this.label30.TabIndex = 53;
            this.label30.Text = "Day:";
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
            // cbSetTipo
            // 
            this.cbSetTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetTipo.FormattingEnabled = true;
            this.cbSetTipo.Items.AddRange(new object[] {
            "UNKNOWN_0",
            "CHAR_SET",
            "CHAR_SET_NEW",
            "NO VIEW SHOP",
            "CLUB_SET",
            "BALL",
            "ITEM ACTIVE",
            "ITEM PASSIVE",
            "CARD/PACK",
            "RING"});
            this.cbSetTipo.Location = new System.Drawing.Point(63, 229);
            this.cbSetTipo.Name = "cbSetTipo";
            this.cbSetTipo.Size = new System.Drawing.Size(113, 23);
            this.cbSetTipo.TabIndex = 42;
            this.cbSetTipo.SelectedIndexChanged += new System.EventHandler(this.cbSetTipo_SelectedIndexChanged);
            this.cbSetTipo.SelectionChangeCommitted += new System.EventHandler(this.cbSetTipo_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 43;
            this.label9.Text = "Type";
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
            this.GroupBox1.Location = new System.Drawing.Point(361, 148);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 155);
            this.GroupBox1.TabIndex = 40;
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
            // btnVerificarTYPEID
            // 
            this.btnVerificarTYPEID.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.btnVerificarTYPEID.Location = new System.Drawing.Point(280, 41);
            this.btnVerificarTYPEID.Name = "btnVerificarTYPEID";
            this.btnVerificarTYPEID.Size = new System.Drawing.Size(25, 25);
            this.btnVerificarTYPEID.TabIndex = 28;
            this.ToolTip1.SetToolTip(this.btnVerificarTYPEID, "Verify Item Index");
            this.btnVerificarTYPEID.UseVisualStyleBackColor = true;
            this.btnVerificarTYPEID.Click += new System.EventHandler(this.btnVerificarTYPEID_Click);
            // 
            // Label29
            // 
            this.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label29.Location = new System.Drawing.Point(36, 146);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(443, 2);
            this.Label29.TabIndex = 21;
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(36, 107);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(443, 2);
            this.Label2.TabIndex = 21;
            // 
            // rbLevelMax
            // 
            this.rbLevelMax.AutoSize = true;
            this.rbLevelMax.Location = new System.Drawing.Point(310, 85);
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
            this.rbLevelMin.Location = new System.Drawing.Point(310, 67);
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
            this.cbLevel.Location = new System.Drawing.Point(177, 74);
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
            this.cbTipo.Location = new System.Drawing.Point(382, 116);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(73, 23);
            this.cbTipo.TabIndex = 9;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(414, 14);
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
            this.imgIcone.Location = new System.Drawing.Point(40, 14);
            this.imgIcone.Name = "imgIcone";
            this.imgIcone.Size = new System.Drawing.Size(85, 85);
            this.imgIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcone.TabIndex = 14;
            this.imgIcone.TabStop = false;
            // 
            // txtIcone
            // 
            this.txtIcone.Location = new System.Drawing.Point(339, 43);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.Size = new System.Drawing.Size(140, 21);
            this.txtIcone.TabIndex = 3;
            this.txtIcone.TextChanged += new System.EventHandler(this.txtIcone_TextChanged);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(177, 43);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(101, 21);
            this.txtTypeID.TabIndex = 2;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(132, 78);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(36, 15);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Level";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(332, 119);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 15);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Money";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(236, 117);
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(96, 21);
            this.txtDesconto.TabIndex = 8;
            this.txtDesconto.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(72, 116);
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(96, 21);
            this.txtPreco.TabIndex = 8;
            this.txtPreco.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(177, 11);
            this.txtNome.MaxLength = 64;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(197, 21);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(308, 46);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(30, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Icon";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(149, 46);
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
            this.lbContNome.Location = new System.Drawing.Point(380, 15);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 9;
            this.lbContNome.Text = "0/64";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(174, 120);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(56, 15);
            this.Label18.TabIndex = 10;
            this.Label18.Text = "Discount";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(33, 119);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 15);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Price";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(132, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 15);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Name";
            // 
            // ckTempoAtivo
            // 
            this.ckTempoAtivo.AutoSize = true;
            this.ckTempoAtivo.BackColor = System.Drawing.Color.Transparent;
            this.ckTempoAtivo.Location = new System.Drawing.Point(261, 158);
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            this.ckTempoAtivo.Size = new System.Drawing.Size(87, 19);
            this.ckTempoAtivo.TabIndex = 28;
            this.ckTempoAtivo.Text = "Time Active";
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            this.ckTempoAtivo.CheckedChanged += new System.EventHandler(this.ckTempoAtivo_CheckedChanged);
            this.ckTempoAtivo.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // gbTempoVenda
            // 
            this.gbTempoVenda.Controls.Add(this.dtTermino);
            this.gbTempoVenda.Controls.Add(this.dtInicio);
            this.gbTempoVenda.Controls.Add(this.Label28);
            this.gbTempoVenda.Controls.Add(this.Label27);
            this.gbTempoVenda.Enabled = false;
            this.gbTempoVenda.Location = new System.Drawing.Point(10, 149);
            this.gbTempoVenda.Name = "gbTempoVenda";
            this.gbTempoVenda.Size = new System.Drawing.Size(347, 73);
            this.gbTempoVenda.TabIndex = 56;
            this.gbTempoVenda.TabStop = false;
            this.gbTempoVenda.Text = "Sell Programation";
            // 
            // dtTermino
            // 
            this.dtTermino.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTermino.Location = new System.Drawing.Point(185, 42);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(155, 21);
            this.dtTermino.TabIndex = 26;
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(13, 42);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(154, 21);
            this.dtInicio.TabIndex = 26;
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
            // TabPage2
            // 
            this.TabPage2.AutoScroll = true;
            this.TabPage2.Controls.Add(this.NumItens);
            this.TabPage2.Controls.Add(this.GroupBox10);
            this.TabPage2.Controls.Add(this.gb5);
            this.TabPage2.Controls.Add(this.GroupBox9);
            this.TabPage2.Controls.Add(this.gb4);
            this.TabPage2.Controls.Add(this.GroupBox8);
            this.TabPage2.Controls.Add(this.gb3);
            this.TabPage2.Controls.Add(this.GroupBox7);
            this.TabPage2.Controls.Add(this.gb2);
            this.TabPage2.Controls.Add(this.GroupBox6);
            this.TabPage2.Controls.Add(this.gb1);
            this.TabPage2.Controls.Add(this.Label11);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(495, 413);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Set";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // NumItens
            // 
            this.NumItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NumItens.Location = new System.Drawing.Point(72, 7);
            this.NumItens.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumItens.Name = "NumItens";
            this.NumItens.Size = new System.Drawing.Size(59, 23);
            this.NumItens.TabIndex = 18;
            this.NumItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox10
            // 
            this.GroupBox10.Controls.Add(this.img_10);
            this.GroupBox10.Controls.Add(this.typeid_10);
            this.GroupBox10.Controls.Add(this.Label35);
            this.GroupBox10.Controls.Add(this.qtd_10);
            this.GroupBox10.Controls.Add(this.Label36);
            this.GroupBox10.Location = new System.Drawing.Point(247, 337);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(238, 74);
            this.GroupBox10.TabIndex = 17;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Item 10";
            // 
            // img_10
            // 
            this.img_10.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_10.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_10.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_10.Location = new System.Drawing.Point(176, 13);
            this.img_10.Name = "img_10";
            this.img_10.Size = new System.Drawing.Size(56, 55);
            this.img_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_10.TabIndex = 16;
            this.img_10.TabStop = false;
            // 
            // typeid_10
            // 
            this.typeid_10.Location = new System.Drawing.Point(52, 19);
            this.typeid_10.Name = "typeid_10";
            this.typeid_10.Size = new System.Drawing.Size(108, 20);
            this.typeid_10.TabIndex = 13;
            this.typeid_10.TextChanged += new System.EventHandler(this.typeid_10_TextChanged);
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(10, 22);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(39, 13);
            this.Label35.TabIndex = 15;
            this.Label35.Text = "Typeid";
            // 
            // qtd_10
            // 
            this.qtd_10.Location = new System.Drawing.Point(52, 44);
            this.qtd_10.Name = "qtd_10";
            this.qtd_10.Size = new System.Drawing.Size(108, 20);
            this.qtd_10.TabIndex = 13;
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(25, 47);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(24, 13);
            this.Label36.TabIndex = 15;
            this.Label36.Text = "Qtd";
            // 
            // gb5
            // 
            this.gb5.Controls.Add(this.img_5);
            this.gb5.Controls.Add(this.typeid_5);
            this.gb5.Controls.Add(this.Label20);
            this.gb5.Controls.Add(this.qtd_5);
            this.gb5.Controls.Add(this.Label21);
            this.gb5.Location = new System.Drawing.Point(6, 337);
            this.gb5.Name = "gb5";
            this.gb5.Size = new System.Drawing.Size(238, 74);
            this.gb5.TabIndex = 17;
            this.gb5.TabStop = false;
            this.gb5.Text = "Item 5";
            // 
            // img_5
            // 
            this.img_5.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_5.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_5.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_5.Location = new System.Drawing.Point(176, 13);
            this.img_5.Name = "img_5";
            this.img_5.Size = new System.Drawing.Size(56, 55);
            this.img_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_5.TabIndex = 16;
            this.img_5.TabStop = false;
            // 
            // typeid_5
            // 
            this.typeid_5.Location = new System.Drawing.Point(52, 19);
            this.typeid_5.Name = "typeid_5";
            this.typeid_5.Size = new System.Drawing.Size(108, 20);
            this.typeid_5.TabIndex = 13;
            this.typeid_5.TextChanged += new System.EventHandler(this.typeid_5_TextChanged);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(10, 22);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(39, 13);
            this.Label20.TabIndex = 15;
            this.Label20.Text = "Typeid";
            // 
            // qtd_5
            // 
            this.qtd_5.Location = new System.Drawing.Point(52, 44);
            this.qtd_5.Name = "qtd_5";
            this.qtd_5.Size = new System.Drawing.Size(108, 20);
            this.qtd_5.TabIndex = 13;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(25, 47);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(24, 13);
            this.Label21.TabIndex = 15;
            this.Label21.Text = "Qtd";
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.img_9);
            this.GroupBox9.Controls.Add(this.typeid_9);
            this.GroupBox9.Controls.Add(this.Label32);
            this.GroupBox9.Controls.Add(this.qtd_9);
            this.GroupBox9.Controls.Add(this.Label34);
            this.GroupBox9.Location = new System.Drawing.Point(247, 261);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(238, 74);
            this.GroupBox9.TabIndex = 17;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Item 9";
            // 
            // img_9
            // 
            this.img_9.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_9.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_9.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_9.Location = new System.Drawing.Point(176, 13);
            this.img_9.Name = "img_9";
            this.img_9.Size = new System.Drawing.Size(56, 55);
            this.img_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_9.TabIndex = 16;
            this.img_9.TabStop = false;
            // 
            // typeid_9
            // 
            this.typeid_9.Location = new System.Drawing.Point(52, 19);
            this.typeid_9.Name = "typeid_9";
            this.typeid_9.Size = new System.Drawing.Size(108, 20);
            this.typeid_9.TabIndex = 13;
            this.typeid_9.TextChanged += new System.EventHandler(this.typeid_9_TextChanged);
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(10, 22);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(39, 13);
            this.Label32.TabIndex = 15;
            this.Label32.Text = "Typeid";
            // 
            // qtd_9
            // 
            this.qtd_9.Location = new System.Drawing.Point(52, 44);
            this.qtd_9.Name = "qtd_9";
            this.qtd_9.Size = new System.Drawing.Size(108, 20);
            this.qtd_9.TabIndex = 13;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(25, 47);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(24, 13);
            this.Label34.TabIndex = 15;
            this.Label34.Text = "Qtd";
            // 
            // gb4
            // 
            this.gb4.Controls.Add(this.img_4);
            this.gb4.Controls.Add(this.typeid_4);
            this.gb4.Controls.Add(this.Label17);
            this.gb4.Controls.Add(this.qtd_4);
            this.gb4.Controls.Add(this.Label19);
            this.gb4.Location = new System.Drawing.Point(6, 261);
            this.gb4.Name = "gb4";
            this.gb4.Size = new System.Drawing.Size(238, 74);
            this.gb4.TabIndex = 17;
            this.gb4.TabStop = false;
            this.gb4.Text = "Item 4";
            // 
            // img_4
            // 
            this.img_4.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_4.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_4.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_4.Location = new System.Drawing.Point(176, 13);
            this.img_4.Name = "img_4";
            this.img_4.Size = new System.Drawing.Size(56, 55);
            this.img_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_4.TabIndex = 16;
            this.img_4.TabStop = false;
            // 
            // typeid_4
            // 
            this.typeid_4.Location = new System.Drawing.Point(52, 19);
            this.typeid_4.Name = "typeid_4";
            this.typeid_4.Size = new System.Drawing.Size(108, 20);
            this.typeid_4.TabIndex = 13;
            this.typeid_4.TextChanged += new System.EventHandler(this.typeid_4_TextChanged);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(10, 22);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(39, 13);
            this.Label17.TabIndex = 15;
            this.Label17.Text = "Typeid";
            // 
            // qtd_4
            // 
            this.qtd_4.Location = new System.Drawing.Point(52, 44);
            this.qtd_4.Name = "qtd_4";
            this.qtd_4.Size = new System.Drawing.Size(108, 20);
            this.qtd_4.TabIndex = 13;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(25, 47);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(24, 13);
            this.Label19.TabIndex = 15;
            this.Label19.Text = "Qtd";
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.img_8);
            this.GroupBox8.Controls.Add(this.typeid_8);
            this.GroupBox8.Controls.Add(this.Label26);
            this.GroupBox8.Controls.Add(this.qtd_8);
            this.GroupBox8.Controls.Add(this.Label31);
            this.GroupBox8.Location = new System.Drawing.Point(247, 186);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(238, 74);
            this.GroupBox8.TabIndex = 17;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Item 8";
            // 
            // img_8
            // 
            this.img_8.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_8.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_8.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_8.Location = new System.Drawing.Point(176, 13);
            this.img_8.Name = "img_8";
            this.img_8.Size = new System.Drawing.Size(56, 55);
            this.img_8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_8.TabIndex = 16;
            this.img_8.TabStop = false;
            // 
            // typeid_8
            // 
            this.typeid_8.Location = new System.Drawing.Point(52, 19);
            this.typeid_8.Name = "typeid_8";
            this.typeid_8.Size = new System.Drawing.Size(108, 20);
            this.typeid_8.TabIndex = 13;
            this.typeid_8.TextChanged += new System.EventHandler(this.typeid_8_TextChanged);
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(10, 22);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(39, 13);
            this.Label26.TabIndex = 15;
            this.Label26.Text = "Typeid";
            // 
            // qtd_8
            // 
            this.qtd_8.Location = new System.Drawing.Point(52, 44);
            this.qtd_8.Name = "qtd_8";
            this.qtd_8.Size = new System.Drawing.Size(108, 20);
            this.qtd_8.TabIndex = 13;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(25, 47);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(24, 13);
            this.Label31.TabIndex = 15;
            this.Label31.Text = "Qtd";
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.img_3);
            this.gb3.Controls.Add(this.typeid_3);
            this.gb3.Controls.Add(this.Label15);
            this.gb3.Controls.Add(this.qtd_3);
            this.gb3.Controls.Add(this.Label16);
            this.gb3.Location = new System.Drawing.Point(6, 186);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(238, 74);
            this.gb3.TabIndex = 17;
            this.gb3.TabStop = false;
            this.gb3.Text = "Item 3";
            // 
            // img_3
            // 
            this.img_3.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_3.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_3.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_3.Location = new System.Drawing.Point(176, 13);
            this.img_3.Name = "img_3";
            this.img_3.Size = new System.Drawing.Size(56, 55);
            this.img_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_3.TabIndex = 16;
            this.img_3.TabStop = false;
            // 
            // typeid_3
            // 
            this.typeid_3.Location = new System.Drawing.Point(52, 19);
            this.typeid_3.Name = "typeid_3";
            this.typeid_3.Size = new System.Drawing.Size(108, 20);
            this.typeid_3.TabIndex = 13;
            this.typeid_3.TextChanged += new System.EventHandler(this.typeid_3_TextChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(10, 22);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(39, 13);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Typeid";
            // 
            // qtd_3
            // 
            this.qtd_3.Location = new System.Drawing.Point(52, 44);
            this.qtd_3.Name = "qtd_3";
            this.qtd_3.Size = new System.Drawing.Size(108, 20);
            this.qtd_3.TabIndex = 13;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(25, 47);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(24, 13);
            this.Label16.TabIndex = 15;
            this.Label16.Text = "Qtd";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.img_7);
            this.GroupBox7.Controls.Add(this.typeid_7);
            this.GroupBox7.Controls.Add(this.Label24);
            this.GroupBox7.Controls.Add(this.qtd_7);
            this.GroupBox7.Controls.Add(this.Label25);
            this.GroupBox7.Location = new System.Drawing.Point(247, 111);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(238, 74);
            this.GroupBox7.TabIndex = 17;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Item 7";
            // 
            // img_7
            // 
            this.img_7.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_7.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_7.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_7.Location = new System.Drawing.Point(176, 13);
            this.img_7.Name = "img_7";
            this.img_7.Size = new System.Drawing.Size(56, 55);
            this.img_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_7.TabIndex = 16;
            this.img_7.TabStop = false;
            // 
            // typeid_7
            // 
            this.typeid_7.Location = new System.Drawing.Point(52, 19);
            this.typeid_7.Name = "typeid_7";
            this.typeid_7.Size = new System.Drawing.Size(108, 20);
            this.typeid_7.TabIndex = 13;
            this.typeid_7.TextChanged += new System.EventHandler(this.typeid_7_TextChanged);
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(10, 22);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(39, 13);
            this.Label24.TabIndex = 15;
            this.Label24.Text = "Typeid";
            // 
            // qtd_7
            // 
            this.qtd_7.Location = new System.Drawing.Point(52, 44);
            this.qtd_7.Name = "qtd_7";
            this.qtd_7.Size = new System.Drawing.Size(108, 20);
            this.qtd_7.TabIndex = 13;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(25, 47);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(24, 13);
            this.Label25.TabIndex = 15;
            this.Label25.Text = "Qtd";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.img_2);
            this.gb2.Controls.Add(this.typeid_2);
            this.gb2.Controls.Add(this.Label13);
            this.gb2.Controls.Add(this.qtd_2);
            this.gb2.Controls.Add(this.Label14);
            this.gb2.Location = new System.Drawing.Point(6, 111);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(238, 74);
            this.gb2.TabIndex = 17;
            this.gb2.TabStop = false;
            this.gb2.Text = "Item 2";
            // 
            // img_2
            // 
            this.img_2.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_2.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_2.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_2.Location = new System.Drawing.Point(176, 13);
            this.img_2.Name = "img_2";
            this.img_2.Size = new System.Drawing.Size(56, 55);
            this.img_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_2.TabIndex = 16;
            this.img_2.TabStop = false;
            // 
            // typeid_2
            // 
            this.typeid_2.Location = new System.Drawing.Point(52, 19);
            this.typeid_2.Name = "typeid_2";
            this.typeid_2.Size = new System.Drawing.Size(108, 20);
            this.typeid_2.TabIndex = 13;
            this.typeid_2.TextChanged += new System.EventHandler(this.typeid_2_TextChanged);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(10, 22);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(39, 13);
            this.Label13.TabIndex = 15;
            this.Label13.Text = "Typeid";
            // 
            // qtd_2
            // 
            this.qtd_2.Location = new System.Drawing.Point(52, 44);
            this.qtd_2.Name = "qtd_2";
            this.qtd_2.Size = new System.Drawing.Size(108, 20);
            this.qtd_2.TabIndex = 13;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(25, 47);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(24, 13);
            this.Label14.TabIndex = 15;
            this.Label14.Text = "Qtd";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.img_6);
            this.GroupBox6.Controls.Add(this.typeid_6);
            this.GroupBox6.Controls.Add(this.Label22);
            this.GroupBox6.Controls.Add(this.qtd_6);
            this.GroupBox6.Controls.Add(this.Label23);
            this.GroupBox6.Location = new System.Drawing.Point(247, 36);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(238, 74);
            this.GroupBox6.TabIndex = 17;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Item 6";
            // 
            // img_6
            // 
            this.img_6.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_6.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_6.Location = new System.Drawing.Point(176, 13);
            this.img_6.Name = "img_6";
            this.img_6.Size = new System.Drawing.Size(56, 55);
            this.img_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_6.TabIndex = 16;
            this.img_6.TabStop = false;
            // 
            // typeid_6
            // 
            this.typeid_6.Location = new System.Drawing.Point(52, 19);
            this.typeid_6.Name = "typeid_6";
            this.typeid_6.Size = new System.Drawing.Size(108, 20);
            this.typeid_6.TabIndex = 13;
            this.typeid_6.TextChanged += new System.EventHandler(this.typeid_6_TextChanged);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(10, 22);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(39, 13);
            this.Label22.TabIndex = 15;
            this.Label22.Text = "Typeid";
            // 
            // qtd_6
            // 
            this.qtd_6.Location = new System.Drawing.Point(52, 44);
            this.qtd_6.Name = "qtd_6";
            this.qtd_6.Size = new System.Drawing.Size(108, 20);
            this.qtd_6.TabIndex = 13;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(25, 47);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(24, 13);
            this.Label23.TabIndex = 15;
            this.Label23.Text = "Qtd";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.img_1);
            this.gb1.Controls.Add(this.typeid_1);
            this.gb1.Controls.Add(this.Label12);
            this.gb1.Controls.Add(this.qtd_1);
            this.gb1.Controls.Add(this.Label5);
            this.gb1.Location = new System.Drawing.Point(6, 36);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(238, 74);
            this.gb1.TabIndex = 17;
            this.gb1.TabStop = false;
            this.gb1.Text = "Item 1";
            // 
            // img_1
            // 
            this.img_1.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_1.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img_1.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img_1.Location = new System.Drawing.Point(176, 13);
            this.img_1.Name = "img_1";
            this.img_1.Size = new System.Drawing.Size(56, 55);
            this.img_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_1.TabIndex = 16;
            this.img_1.TabStop = false;
            // 
            // typeid_1
            // 
            this.typeid_1.Location = new System.Drawing.Point(52, 19);
            this.typeid_1.Name = "typeid_1";
            this.typeid_1.Size = new System.Drawing.Size(108, 20);
            this.typeid_1.TabIndex = 13;
            this.typeid_1.TextChanged += new System.EventHandler(this.typeid_1_TextChanged);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(10, 22);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(39, 13);
            this.Label12.TabIndex = 15;
            this.Label12.Text = "Typeid";
            // 
            // qtd_1
            // 
            this.qtd_1.Location = new System.Drawing.Point(52, 44);
            this.qtd_1.Name = "qtd_1";
            this.qtd_1.Size = new System.Drawing.Size(108, 20);
            this.qtd_1.TabIndex = 13;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(25, 47);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(24, 13);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Qtd";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(7, 13);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(59, 13);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "Total Items";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnApplyDesc);
            this.tabPage3.Controls.Add(this.BtnCreateDesc);
            this.tabPage3.Controls.Add(this.label38);
            this.tabPage3.Controls.Add(this.txtDesc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(495, 413);
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
            this.BtnApplyDesc.Location = new System.Drawing.Point(394, 243);
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
            this.BtnCreateDesc.Location = new System.Drawing.Point(291, 243);
            this.BtnCreateDesc.Name = "BtnCreateDesc";
            this.BtnCreateDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnCreateDesc.TabIndex = 11;
            this.BtnCreateDesc.TabStop = false;
            this.BtnCreateDesc.Text = "New";
            this.BtnCreateDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreateDesc.UseVisualStyleBackColor = true;
            this.BtnCreateDesc.Click += new System.EventHandler(this.BtnCreateDesc_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(1, 10);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(113, 13);
            this.label38.TabIndex = 9;
            this.label38.Text = "Item Desc Information:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(4, 30);
            this.txtDesc.MaxLength = 512;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(487, 207);
            this.txtDesc.TabIndex = 8;
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 442);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(503, 70);
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
            this.btnReabrir.Location = new System.Drawing.Point(303, 14);
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
            this.btnNovo.Location = new System.Drawing.Point(3, 14);
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
            this.btnRemover.Location = new System.Drawing.Point(103, 14);
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
            this.btnBackup.Location = new System.Drawing.Point(203, 14);
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
            this.btnSalvar.Location = new System.Drawing.Point(403, 14);
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
            this.diagSalvarArquivo.Filter = "SetItem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Save File SetItem.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "SetItem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (SetItem.iff)";
            // 
            // diagSalvarSql
            // 
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "SetItem.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Save File SQL";
            // 
            // FrmSetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 583);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmSetItem";
            this.Text = "SetItem - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetItemFormClosing);
            this.Load += new System.EventHandler(this.FrmSetItem_Load);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrDay)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumItens)).EndInit();
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_10)).EndInit();
            this.gb5.ResumeLayout(false);
            this.gb5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_5)).EndInit();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_9)).EndInit();
            this.gb4.ResumeLayout(false);
            this.gb4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_4)).EndInit();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_8)).EndInit();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_3)).EndInit();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_7)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_2)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_6)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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

        [AccessedThroughProperty("bwSalvar")]
        private BackgroundWorker bwSalvar;

        [AccessedThroughProperty("bwGerarSql")]
        private BackgroundWorker bwGerarSql;

        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        [AccessedThroughProperty("lblSearchCount")]
        private Label lblSearchCount;

        [AccessedThroughProperty("imgStatus")]
        private PictureBox imgStatus;

        [AccessedThroughProperty("ComboBox2")]
        private ComboBox ComboBox2;

        [AccessedThroughProperty("Label37")]
        private Label Label37;

        [AccessedThroughProperty("Label39")]
        private Label Label39;

        [AccessedThroughProperty("btnVerificarTYPEID")]
        private Button btnVerificarTYPEID;

        [AccessedThroughProperty("ToolTip1")]
        private ToolTip ToolTip1;

        [AccessedThroughProperty("TabPage2")]
        private TabPage TabPage2;

        [AccessedThroughProperty("NumItens")]
        private NumericUpDown NumItens;

        [AccessedThroughProperty("GroupBox10")]
        private GroupBox GroupBox10;

        [AccessedThroughProperty("img_10")]
        private PictureBox img_10;

        [AccessedThroughProperty("typeid_10")]
        private TextBox typeid_10;

        [AccessedThroughProperty("Label35")]
        private Label Label35;

        [AccessedThroughProperty("qtd_10")]
        private TextBox qtd_10;

        [AccessedThroughProperty("Label36")]
        private Label Label36;

        [AccessedThroughProperty("gb5")]
        private GroupBox gb5;

        [AccessedThroughProperty("img_5")]
        private PictureBox img_5;

        [AccessedThroughProperty("typeid_5")]
        private TextBox typeid_5;

        [AccessedThroughProperty("Label20")]
        private Label Label20;

        [AccessedThroughProperty("qtd_5")]
        private TextBox qtd_5;

        [AccessedThroughProperty("Label21")]
        private Label Label21;

        [AccessedThroughProperty("GroupBox9")]
        private GroupBox GroupBox9;

        [AccessedThroughProperty("img_9")]
        private PictureBox img_9;

        [AccessedThroughProperty("typeid_9")]
        private TextBox typeid_9;

        [AccessedThroughProperty("Label32")]
        private Label Label32;

        [AccessedThroughProperty("qtd_9")]
        private TextBox qtd_9;

        [AccessedThroughProperty("Label34")]
        private Label Label34;

        [AccessedThroughProperty("gb4")]
        private GroupBox gb4;

        [AccessedThroughProperty("img_4")]
        private PictureBox img_4;

        [AccessedThroughProperty("typeid_4")]
        private TextBox typeid_4;

        [AccessedThroughProperty("Label17")]
        private Label Label17;

        [AccessedThroughProperty("qtd_4")]
        private TextBox qtd_4;

        [AccessedThroughProperty("Label19")]
        private Label Label19;

        [AccessedThroughProperty("GroupBox8")]
        private GroupBox GroupBox8;

        [AccessedThroughProperty("img_8")]
        private PictureBox img_8;

        [AccessedThroughProperty("typeid_8")]
        private TextBox typeid_8;

        [AccessedThroughProperty("Label26")]
        private Label Label26;

        [AccessedThroughProperty("qtd_8")]
        private TextBox qtd_8;

        [AccessedThroughProperty("Label31")]
        private Label Label31;

        [AccessedThroughProperty("gb3")]
        private GroupBox gb3;

        [AccessedThroughProperty("img_3")]
        private PictureBox img_3;

        [AccessedThroughProperty("typeid_3")]
        private TextBox typeid_3;

        [AccessedThroughProperty("Label15")]
        private Label Label15;

        [AccessedThroughProperty("qtd_3")]
        private TextBox qtd_3;

        [AccessedThroughProperty("Label16")]
        private Label Label16;

        [AccessedThroughProperty("GroupBox7")]
        private GroupBox GroupBox7;

        [AccessedThroughProperty("img_7")]
        private PictureBox img_7;

        [AccessedThroughProperty("typeid_7")]
        private TextBox typeid_7;

        [AccessedThroughProperty("Label24")]
        private Label Label24;

        [AccessedThroughProperty("qtd_7")]
        private TextBox qtd_7;

        [AccessedThroughProperty("Label25")]
        private Label Label25;

        [AccessedThroughProperty("gb2")]
        private GroupBox gb2;

        [AccessedThroughProperty("img_2")]
        private PictureBox img_2;

        [AccessedThroughProperty("typeid_2")]
        private TextBox typeid_2;

        [AccessedThroughProperty("Label13")]
        private Label Label13;

        [AccessedThroughProperty("qtd_2")]
        private TextBox qtd_2;

        [AccessedThroughProperty("Label14")]
        private Label Label14;

        [AccessedThroughProperty("GroupBox6")]
        private GroupBox GroupBox6;

        [AccessedThroughProperty("img_6")]
        private PictureBox img_6;

        [AccessedThroughProperty("typeid_6")]
        private TextBox typeid_6;

        [AccessedThroughProperty("Label22")]
        private Label Label22;

        [AccessedThroughProperty("qtd_6")]
        private TextBox qtd_6;

        [AccessedThroughProperty("Label23")]
        private Label Label23;

        [AccessedThroughProperty("gb1")]
        private GroupBox gb1;

        [AccessedThroughProperty("img_1")]
        private PictureBox img_1;

        [AccessedThroughProperty("typeid_1")]
        private TextBox typeid_1;

        [AccessedThroughProperty("Label12")]
        private Label Label12;

        [AccessedThroughProperty("qtd_1")]
        private TextBox qtd_1;

        [AccessedThroughProperty("Label5")]
        private Label Label5;

        [AccessedThroughProperty("Label11")]
        private Label Label11;

        public string Arquivo;

        public IFFFile<SetItem> lsItens;

        public IFFFile<SetItem> lsTemp;

        public byte[] bStart;

        private bool Alterado = false;

        private BindingSource bs;

        private int lastRow;

        public long qtdItem;          
        #endregion
        private ToolStripButton menuGerarSql;
        private ToolStripButton menuTypeid;
        private ToolStripButton menuBackup;
        private GroupBox GroupBox1;
        private CheckBox ckSpecial;
        private CheckBox ckDisplay;
        private CheckBox ckNew;
        private CheckBox ckDesativado;
        private CheckBox ckNormal;
        private CheckBox ckHot;
        private CheckBox ckGift;
        private ComboBox cbSetTipo;
        private Label label9;
        private IContainer components;
        private GroupBox groupBox2;
        private Label label30;
        private NumericUpDown nrDay;
        private CheckBox ckTimeShopActive;
        private ComboBox cbSet;
        private Label label42;
        private ToolStripDropDownButton menuMassa;
        private ToolStripSeparator ToolStripMenuItem1;
        private ToolStripMenuItem ApagarTodosToolStripMenuItem;
        private ToolStripMenuItem iFFToolStripMenuItem;
        private ToolStripMenuItem cSVFileToolStripMenuItem;
        private ToolStripMenuItem copyItemToolStripMenuItem;
        private ToolStripMenuItem s8THToolStripMenuItem;
        private ToolStripMenuItem s8GBToolStripMenuItem;
        private TextBox txtUnFlag;
        private Label label10;
        private GroupBox gbTempoVenda;
        private DateTimePicker dtTermino;
        private DateTimePicker dtInicio;
        private Label Label28;
        private Label Label27;
        private CheckBox ckTempoAtivo;
        private TabPage tabPage3;
        private Button BtnApplyDesc;
        private Button BtnCreateDesc;
        private Label label38;
        private TextBox txtDesc;
    }
}