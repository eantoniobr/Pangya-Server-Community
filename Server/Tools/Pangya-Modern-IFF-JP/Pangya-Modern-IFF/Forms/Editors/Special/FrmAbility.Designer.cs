using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    partial class FrmAbility
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
            this.menuBackup = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEffect = new System.Windows.Forms.ComboBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEffectActive3 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEffectActive2 = new System.Windows.Forms.CheckBox();
            this.txtFlag2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEffectActive = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.cbType3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEffectRate3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEffectRate = new System.Windows.Forms.TextBox();
            this.cbType2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEffectRate2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.imgResultado = new System.Windows.Forms.PictureBox();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.Label36 = new System.Windows.Forms.Label();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).BeginInit();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 442);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(803, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(512, 17);
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
            this.menuBackup});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(803, 40);
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
            this.menuSalvarComo.Click += new System.EventHandler(this.menuSalvarComo_Click);
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
            this.SplitContainer1.Size = new System.Drawing.Size(803, 402);
            this.SplitContainer1.SplitterDistance = 274;
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
            this.Panel3.Size = new System.Drawing.Size(274, 375);
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
            this.ListaItem.Size = new System.Drawing.Size(274, 305);
            this.ListaItem.TabIndex = 1;
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.cbEffect);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.BtnSearch);
            this.Panel1.Controls.Add(this.pictureBox5);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 305);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(274, 70);
            this.Panel1.TabIndex = 2;
            // 
            // imgStatus
            // 
            this.imgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgStatus.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.imgStatus.Location = new System.Drawing.Point(4, 28);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(35, 39);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgStatus.TabIndex = 45;
            this.imgStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Effect";
            // 
            // cbEffect
            // 
            this.cbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEffect.FormattingEnabled = true;
            this.cbEffect.Items.AddRange(new object[] {
            "ALL",
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
            this.cbEffect.Location = new System.Drawing.Point(46, 44);
            this.cbEffect.Name = "cbEffect";
            this.cbEffect.Size = new System.Drawing.Size(162, 22);
            this.cbEffect.TabIndex = 44;
            this.cbEffect.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 25);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(270, 2);
            this.Label39.TabIndex = 22;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.BtnSearch.Location = new System.Drawing.Point(202, 3);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(20, 20);
            this.BtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Click += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.pictureBox5.Location = new System.Drawing.Point(5, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Location = new System.Drawing.Point(27, 3);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(170, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(224, 4);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(14, 16);
            this.lblSearchCount.TabIndex = 10;
            this.lblSearchCount.Text = "0";
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Controls.Add(this.lbArquivo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(274, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(55, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Ability.iff";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(521, 396);
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
            this.tabForm.Size = new System.Drawing.Size(511, 320);
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
            this.TabPage1.Size = new System.Drawing.Size(503, 294);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Controls.Add(this.groupBox2);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtTypeID);
            this.GroupBox1.Controls.Add(this.imgResultado);
            this.GroupBox1.Location = new System.Drawing.Point(6, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(495, 286);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 14);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(216, 21);
            this.txtName.TabIndex = 43;
            this.toolTip1.SetToolTip(this.txtName, "Index conected with Item.iff");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEffectActive3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEffectActive2);
            this.groupBox2.Controls.Add(this.txtFlag2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtEffectActive);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.txtFlag);
            this.groupBox2.Controls.Add(this.cbType3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtEffectRate3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEffectRate);
            this.groupBox2.Controls.Add(this.cbType2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtEffectRate2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 199);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config Effect";
            // 
            // txtEffectActive3
            // 
            this.txtEffectActive3.AutoSize = true;
            this.txtEffectActive3.Location = new System.Drawing.Point(200, 174);
            this.txtEffectActive3.Name = "txtEffectActive3";
            this.txtEffectActive3.Size = new System.Drawing.Size(57, 19);
            this.txtEffectActive3.TabIndex = 43;
            this.txtEffectActive3.Text = "Active";
            this.txtEffectActive3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(341, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "Flag 2";
            // 
            // txtEffectActive2
            // 
            this.txtEffectActive2.AutoSize = true;
            this.txtEffectActive2.Location = new System.Drawing.Point(200, 107);
            this.txtEffectActive2.Name = "txtEffectActive2";
            this.txtEffectActive2.Size = new System.Drawing.Size(57, 19);
            this.txtEffectActive2.TabIndex = 42;
            this.txtEffectActive2.Text = "Active";
            this.txtEffectActive2.UseVisualStyleBackColor = true;
            // 
            // txtFlag2
            // 
            this.txtFlag2.Location = new System.Drawing.Point(388, 45);
            this.txtFlag2.Name = "txtFlag2";
            this.txtFlag2.Size = new System.Drawing.Size(94, 21);
            this.txtFlag2.TabIndex = 33;
            this.toolTip1.SetToolTip(this.txtFlag2, "Index conected with Item.iff");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "Effect Nº 3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(341, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 15);
            this.label13.TabIndex = 32;
            this.label13.Text = "Flag 1";
            // 
            // txtEffectActive
            // 
            this.txtEffectActive.AutoSize = true;
            this.txtEffectActive.Location = new System.Drawing.Point(200, 43);
            this.txtEffectActive.Name = "txtEffectActive";
            this.txtEffectActive.Size = new System.Drawing.Size(57, 19);
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
            this.txtFlag.Size = new System.Drawing.Size(94, 21);
            this.txtFlag.TabIndex = 31;
            this.toolTip1.SetToolTip(this.txtFlag, "Index conected with Item.iff");
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Rate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = "Effect Nº 2";
            // 
            // txtEffectRate3
            // 
            this.txtEffectRate3.Location = new System.Drawing.Point(95, 171);
            this.txtEffectRate3.Name = "txtEffectRate3";
            this.txtEffectRate3.Size = new System.Drawing.Size(94, 21);
            this.txtEffectRate3.TabIndex = 29;
            this.toolTip1.SetToolTip(this.txtEffectRate3, "Index conected with Item.iff");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 15);
            this.label14.TabIndex = 38;
            this.label14.Text = "Effect Nº 1";
            // 
            // txtEffectRate
            // 
            this.txtEffectRate.Location = new System.Drawing.Point(95, 43);
            this.txtEffectRate.Name = "txtEffectRate";
            this.txtEffectRate.Size = new System.Drawing.Size(94, 21);
            this.txtEffectRate.TabIndex = 25;
            this.toolTip1.SetToolTip(this.txtEffectRate, "Index conected with Item.iff");
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Rate";
            // 
            // txtEffectRate2
            // 
            this.txtEffectRate2.Location = new System.Drawing.Point(95, 107);
            this.txtEffectRate2.Name = "txtEffectRate2";
            this.txtEffectRate2.Size = new System.Drawing.Size(94, 21);
            this.txtEffectRate2.TabIndex = 27;
            this.toolTip1.SetToolTip(this.txtEffectRate2, "Index conected with Item.iff");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Rate";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(101, 47);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(19, 15);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "ID";
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(126, 44);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(137, 21);
            this.txtTypeID.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtTypeID, "Index conected with Item.iff");
            // 
            // imgResultado
            // 
            this.imgResultado.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgResultado.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgResultado.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.imgResultado.Location = new System.Drawing.Point(5, 14);
            this.imgResultado.Name = "imgResultado";
            this.imgResultado.Size = new System.Drawing.Size(65, 61);
            this.imgResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgResultado.TabIndex = 16;
            this.imgResultado.TabStop = false;
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 323);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(511, 70);
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
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Salvar arquivo Part.sff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Part.sff)";
            // 
            // PictureBox4
            // 
            this.PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox4.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.PictureBox4.Location = new System.Drawing.Point(494, -81);
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
            this.PictureBox1.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.PictureBox1.Location = new System.Drawing.Point(297, -81);
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
            this.imgPersonagem.Location = new System.Drawing.Point(555, -81);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // FrmAbility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 464);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmAbility";
            this.Text = "Ability - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmAbility_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).EndInit();
            this.gbBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        //[AccessedThroughProperty("StatusStrip1")]
        private StatusStrip StatusStrip1;

        //[AccessedThroughProperty("ToolStrip1")]
        private ToolStrip ToolStrip1;

        //[AccessedThroughProperty("SplitContainer1")]
        private SplitContainer SplitContainer1;

        //[AccessedThroughProperty("PictureBox1")]
        private PictureBox PictureBox1;

        //[AccessedThroughProperty("txtPesquisa")]
        //[AccessedThroughProperty("gbBotoes")]
        private GroupBox gbBotoes;

        //[AccessedThroughProperty("Panel4")]
        private Panel Panel4;

        //[AccessedThroughProperty("tabForm")]
        private TabControl tabForm;

        //[AccessedThroughProperty("TabPage1")]
        private TabPage TabPage1;

        //[AccessedThroughProperty("btnAbrirArquivo")]
        private ToolStripButton btnAbrirArquivo;

        //[AccessedThroughProperty("diagAbrirArquivo")]
        private OpenFileDialog diagAbrirArquivo;

        //[AccessedThroughProperty("ToolStripStatusLabel1")]
        private ToolStripStatusLabel ToolStripStatusLabel1;

        //[AccessedThroughProperty("lbTotalItens")]
        private ToolStripStatusLabel lbTotalItens;

        //[AccessedThroughProperty("btnReabrir")]
        private Button btnReabrir;

        //[AccessedThroughProperty("btnNovo")]
        private Button btnNovo;

        //[AccessedThroughProperty("btnRemover")]
        private Button btnRemover;

        //[AccessedThroughProperty("btnBackup")]
        private Button btnBackup;

        //[AccessedThroughProperty("btnSalvar")]
        private Button btnSalvar;

        //[AccessedThroughProperty("ToolStripStatusLabel2")]
        private ToolStripStatusLabel ToolStripStatusLabel2;

        //[AccessedThroughProperty("lbStatus")]
        private ToolStripStatusLabel lbStatus;

        //[AccessedThroughProperty("diagSalvarArquivo")]
        private SaveFileDialog diagSalvarArquivo;

        //[AccessedThroughProperty("menuSalvarComo")]
        private ToolStripButton menuSalvarComo;

        //[AccessedThroughProperty("ToolStripStatusLabel4")]
        private ToolStripStatusLabel ToolStripStatusLabel4;

        //[AccessedThroughProperty("lbIndices")]
        private ToolStripStatusLabel lbIndices;

        //[AccessedThroughProperty("pbStatus")]
        private ToolStripProgressBar pbStatus;

        //[AccessedThroughProperty("imgPersonagem")]
        private PictureBox imgPersonagem;

        //[AccessedThroughProperty("bwSalvar")]
        private BackgroundWorker bwSalvar;

        //[AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        //[AccessedThroughProperty("Label36")]
        private Label Label36;

        //[AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;

        //[AccessedThroughProperty("imgResultado")]
        private PictureBox imgResultado;

        public string Arquivo;

        public IFFFile<Ability> lsItens;

        public IFFFile<Ability> lsTemp;
                                         
        private bool Alterado;

        private BindingSource bs;

        private int lastRow;

        public long qtdItem;      
        #endregion
        private Panel Panel3;
        private Panel Panel2;
        private PictureBox PictureBox2;
        private Label lbArquivo;
        public DataGridView ListaItem;
        private Panel Panel1;
        private Label Label39;
        private PictureBox BtnSearch;
        private PictureBox pictureBox5;
        private TextBox txtPesquisa;
        private Label lblSearchCount;
        private ToolTip toolTip1;
        private Label Label6;
        private TextBox txtTypeID;
        private ComboBox cbType2;
        private ComboBox cbType;
        private Label label12;
        private TextBox txtFlag2;
        private Label label13;
        private TextBox txtFlag;
        private Label label8;
        private TextBox txtEffectRate3;
        private Label label10;
        private TextBox txtEffectRate2;
        private Label label11;
        private TextBox txtEffectRate;
        private Label label5;
        private Label label9;
        private Label label14;
        private GroupBox groupBox2;
        private CheckBox txtEffectActive3;
        private CheckBox txtEffectActive2;
        private ComboBox cbType3;
        private CheckBox txtEffectActive;
        private Label label1;
        private TextBox txtName;
        private ToolStripButton menuBackup;
        private Label label2;
        private ComboBox cbEffect;
        private PictureBox imgStatus;
    }
}