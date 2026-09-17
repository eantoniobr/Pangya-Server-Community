using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using Pangya_Modern_Editor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
    partial class FrmCaddie
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
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUn = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.labeladd = new System.Windows.Forms.Label();
            this.txtSprite = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nrDay = new System.Windows.Forms.NumericUpDown();
            this.ckTimeShopActive = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSpecial = new System.Windows.Forms.CheckBox();
            this.ckDisplay = new System.Windows.Forms.CheckBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.ckDesativado = new System.Windows.Forms.CheckBox();
            this.ckNormal = new System.Windows.Forms.CheckBox();
            this.ckHot = new System.Windows.Forms.CheckBox();
            this.ckGift = new System.Windows.Forms.CheckBox();
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
            this.Panel5 = new System.Windows.Forms.Panel();
            this.barraForca = new System.Windows.Forms.Panel();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnApplyDesc = new System.Windows.Forms.Button();
            this.BtnCreateDesc = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnApplyAbility = new System.Windows.Forms.Button();
            this.BtnNewAbility = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtEffectActive3 = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtEffectActive2 = new System.Windows.Forms.CheckBox();
            this.txtFlagAbility2 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtEffectActive = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtFlagAbility = new System.Windows.Forms.TextBox();
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
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bwGerarSql = new System.ComponentModel.BackgroundWorker();
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.diagSalvarSql = new System.Windows.Forms.SaveFileDialog();
            this.diagPasta = new System.Windows.Forms.FolderBrowserDialog();
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
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.ApagarTodosToolStripMenuItem});
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
            this.cSVFileToolStripMenuItem.Click += new System.EventHandler(this.cSVFileToolStripMenuItem_Click);
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
            this.lbArquivo.Size = new System.Drawing.Size(60, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Caddie.iff";
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
            this.Panel1.Controls.Add(this.lblSearchCount);
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
            this.imgStatus.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
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
            this.ComboBox2.Location = new System.Drawing.Point(177, 44);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(92, 21);
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
            this.Label37.Location = new System.Drawing.Point(174, 27);
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
            this.tabForm.Controls.Add(this.tabPage2);
            this.tabForm.Controls.Add(this.tabPage3);
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
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.txtUn);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.txtSalary);
            this.TabPage1.Controls.Add(this.labeladd);
            this.TabPage1.Controls.Add(this.txtSprite);
            this.TabPage1.Controls.Add(this.groupBox6);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.Panel10);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 38;
            this.label5.Text = "Unk:";
            // 
            // txtUn
            // 
            this.txtUn.Location = new System.Drawing.Point(422, 84);
            this.txtUn.MaxLength = 40;
            this.txtUn.Name = "txtUn";
            this.txtUn.Size = new System.Drawing.Size(79, 21);
            this.txtUn.TabIndex = 37;
            this.txtUn.Text = "0";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(371, 66);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(51, 15);
            this.Label23.TabIndex = 36;
            this.Label23.Text = "Monthly:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(422, 62);
            this.txtSalary.MaxLength = 40;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(79, 21);
            this.txtSalary.TabIndex = 35;
            this.txtSalary.Text = "0";
            // 
            // labeladd
            // 
            this.labeladd.AutoSize = true;
            this.labeladd.Location = new System.Drawing.Point(289, 45);
            this.labeladd.Name = "labeladd";
            this.labeladd.Size = new System.Drawing.Size(43, 15);
            this.labeladd.TabIndex = 34;
            this.labeladd.Text = "Model:";
            // 
            // txtSprite
            // 
            this.txtSprite.Location = new System.Drawing.Point(334, 41);
            this.txtSprite.MaxLength = 40;
            this.txtSprite.Name = "txtSprite";
            this.txtSprite.Size = new System.Drawing.Size(104, 21);
            this.txtSprite.TabIndex = 33;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nrDay);
            this.groupBox6.Controls.Add(this.ckTimeShopActive);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Location = new System.Drawing.Point(381, 304);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(119, 70);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Shop";
            // 
            // nrDay
            // 
            this.nrDay.Location = new System.Drawing.Point(37, 20);
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
            this.ckTimeShopActive.Location = new System.Drawing.Point(19, 45);
            this.ckTimeShopActive.Name = "ckTimeShopActive";
            this.ckTimeShopActive.Size = new System.Drawing.Size(65, 19);
            this.ckTimeShopActive.TabIndex = 17;
            this.ckTimeShopActive.Text = "Enable";
            this.ckTimeShopActive.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(2, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(31, 15);
            this.label32.TabIndex = 12;
            this.label32.Text = "Day:";
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
            this.GroupBox1.Location = new System.Drawing.Point(381, 148);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(118, 156);
            this.GroupBox1.TabIndex = 31;
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
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.barraForca);
            this.Panel5.Location = new System.Drawing.Point(78, 25);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(237, 18);
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
            this.Label14.Location = new System.Drawing.Point(23, 127);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(49, 15);
            this.Label14.TabIndex = 7;
            this.Label14.Text = "CURVE";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(37, 103);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(35, 15);
            this.Label13.TabIndex = 7;
            this.Label13.Text = "SPIN";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(23, 79);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(49, 15);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "IMPACT";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(6, 53);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(66, 15);
            this.Label11.TabIndex = 7;
            this.Label11.Text = "CONTROL";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(20, 27);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(52, 15);
            this.Label10.TabIndex = 7;
            this.Label10.Text = "POWER";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(320, 8);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(35, 15);
            this.Label15.TabIndex = 10;
            this.Label15.Text = "Stats";
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
            this.Label2.Location = new System.Drawing.Point(13, 109);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(483, 2);
            this.Label2.TabIndex = 21;
            // 
            // rbLevelMax
            // 
            this.rbLevelMax.AutoSize = true;
            this.rbLevelMax.Location = new System.Drawing.Point(292, 83);
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
            this.rbLevelMin.Location = new System.Drawing.Point(293, 63);
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
            this.ckAtivo.Location = new System.Drawing.Point(444, 41);
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
            this.imgIcone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.txtIcone.Location = new System.Drawing.Point(348, 11);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.Size = new System.Drawing.Size(104, 21);
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
            this.Label6.Location = new System.Drawing.Point(114, 77);
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
            this.txtNome.Size = new System.Drawing.Size(127, 21);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(316, 14);
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
            this.lbContNome.Location = new System.Drawing.Point(287, 15);
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
            this.dtTermino.Size = new System.Drawing.Size(157, 21);
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
            this.dtInicio.Size = new System.Drawing.Size(152, 21);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnApplyDesc);
            this.tabPage2.Controls.Add(this.BtnCreateDesc);
            this.tabPage2.Controls.Add(this.label38);
            this.tabPage2.Controls.Add(this.txtDesc);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Desc Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnApplyDesc
            // 
            this.BtnApplyDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyDesc.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyDesc.Location = new System.Drawing.Point(403, 238);
            this.BtnApplyDesc.Name = "BtnApplyDesc";
            this.BtnApplyDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnApplyDesc.TabIndex = 14;
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
            this.BtnCreateDesc.Location = new System.Drawing.Point(300, 238);
            this.BtnCreateDesc.Name = "BtnCreateDesc";
            this.BtnCreateDesc.Size = new System.Drawing.Size(97, 48);
            this.BtnCreateDesc.TabIndex = 15;
            this.BtnCreateDesc.TabStop = false;
            this.BtnCreateDesc.Text = "New";
            this.BtnCreateDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreateDesc.UseVisualStyleBackColor = true;
            this.BtnCreateDesc.Click += new System.EventHandler(this.BtnCreateDesc_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 6);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(113, 13);
            this.label38.TabIndex = 13;
            this.label38.Text = "Item Desc Information:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 26);
            this.txtDesc.MaxLength = 512;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(494, 207);
            this.txtDesc.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnApplyAbility);
            this.tabPage3.Controls.Add(this.BtnNewAbility);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(506, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ability Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnApplyAbility
            // 
            this.BtnApplyAbility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnApplyAbility.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyAbility.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnApply;
            this.BtnApplyAbility.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyAbility.Location = new System.Drawing.Point(393, 208);
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
            this.BtnNewAbility.Location = new System.Drawing.Point(290, 208);
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
            this.groupBox5.Controls.Add(this.txtFlagAbility2);
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.txtEffectActive);
            this.groupBox5.Controls.Add(this.cbType);
            this.groupBox5.Controls.Add(this.txtFlagAbility);
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
            this.groupBox5.Location = new System.Drawing.Point(8, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(488, 199);
            this.groupBox5.TabIndex = 45;
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
            // txtFlagAbility2
            // 
            this.txtFlagAbility2.Location = new System.Drawing.Point(388, 45);
            this.txtFlagAbility2.Name = "txtFlagAbility2";
            this.txtFlagAbility2.Size = new System.Drawing.Size(94, 20);
            this.txtFlagAbility2.TabIndex = 33;
            this.ToolTip1.SetToolTip(this.txtFlagAbility2, "Index conected with Item.iff");
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
            this.btnBackup.MouseHover += new System.EventHandler(this.ListaItem_MouseHover);
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
            this.bwGerarSql.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGerarSql_DoWork);
            this.bwGerarSql.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGerarSql_ProgressChanged);
            this.bwGerarSql.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGerarSql_RunWorkerCompleted);
            // 
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Save File Caddie.iff";
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
            this.diagSalvarSql.FileName = "Caddie.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Save File SQL";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            // 
            // FrmCaddie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 548);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.ComboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmCaddie";
            this.Text = "Caddie - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCaddies_Closing);
            this.Load += new System.EventHandler(this.FrmCaddie_Load);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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

        [AccessedThroughProperty("diagPasta")]
        private FolderBrowserDialog diagPasta;

        [AccessedThroughProperty("btnVerificarTYPEID")]
        private Button btnVerificarTYPEID;

        [AccessedThroughProperty("ToolTip1")]
        private ToolTip ToolTip1;

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
        private Panel Panel5;

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

        private Caddie oIff;


        public IFFFile<Caddie> lsItens;

        public IFFFile<Caddie> lsTemp;

        public byte[] bStart;
        private bool Alterado;
        private BindingSource bs;

        private int lastRow;

        public long qtdItem; 
        
        #endregion
        private ToolStripButton menuGerarSql;
        private ToolStripButton menuTypeid;
        private ToolStripButton menuBackup;
        private GroupBox groupBox6;
        private NumericUpDown nrDay;
        private CheckBox ckTimeShopActive;
        private Label label32;
        private GroupBox GroupBox1;
        private CheckBox ckSpecial;
        private CheckBox ckDisplay;
        private CheckBox ckNew;
        private CheckBox ckDesativado;
        private CheckBox ckNormal;
        private CheckBox ckHot;
        private CheckBox ckGift;
        private IContainer components;
        private Label label5;
        private TextBox txtUn;
        private Label Label23;
        private TextBox txtSalary;
        private Label labeladd;
        private TextBox txtSprite;
        private TabPage tabPage2;
        private Button BtnApplyDesc;
        private Button BtnCreateDesc;
        private Label label38;
        private TextBox txtDesc;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private CheckBox txtEffectActive3;
        private Label label50;
        private CheckBox txtEffectActive2;
        private TextBox txtFlagAbility2;
        private Label label51;
        private Label label52;
        private CheckBox txtEffectActive;
        private ComboBox cbType;
        private TextBox txtFlagAbility;
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
        private ToolStripDropDownButton menuMassa;
        private ToolStripSeparator ToolStripMenuItem1;
        private ToolStripMenuItem ApagarTodosToolStripMenuItem;
        private ToolStripMenuItem iFFToolStripMenuItem;
        private ToolStripMenuItem sQLInsertInventoryToolStripMenuItem;
        private ToolStripMenuItem cSVFileToolStripMenuItem;
    }
}