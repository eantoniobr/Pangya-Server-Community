using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class FrmAbilityEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbilityEditor));
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
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label39 = new System.Windows.Forms.Label();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFlag2 = new System.Windows.Forms.TextBox();
            this.txtFlag1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nrAtivo3 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nrAtivo1 = new System.Windows.Forms.NumericUpDown();
            this.nrAtivo2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cbEfeito3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEfeito2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEfeito1 = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFlagPercent3 = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTypeID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFlagPercent1 = new System.Windows.Forms.NumericUpDown();
            this.txtFlagPercent2 = new System.Windows.Forms.NumericUpDown();
            this.Label17 = new System.Windows.Forms.Label();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent2)).BeginInit();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 485);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(921, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(608, 17);
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
            this.ToolStrip1.Size = new System.Drawing.Size(921, 40);
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
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 6);
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
            this.SplitContainer1.Size = new System.Drawing.Size(921, 445);
            this.SplitContainer1.SplitterDistance = 315;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 27);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(315, 349);
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
            this.ListaItem.Size = new System.Drawing.Size(315, 349);
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
            this.Panel2.Size = new System.Drawing.Size(315, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(140, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "nenhum arquivo aberto!";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.Label33);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 376);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(315, 69);
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
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            this.txtPesquisa.Location = new System.Drawing.Point(27, 5);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(169, 20);
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
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(598, 439);
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
            this.tabForm.Size = new System.Drawing.Size(588, 363);
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
            this.TabPage1.Size = new System.Drawing.Size(580, 337);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Informacoes Basicas";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label11);
            this.GroupBox1.Controls.Add(this.label12);
            this.GroupBox1.Controls.Add(this.txtFlag2);
            this.GroupBox1.Controls.Add(this.txtFlag1);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.nrAtivo3);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.nrAtivo1);
            this.GroupBox1.Controls.Add(this.nrAtivo2);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.cbEfeito3);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.cbEfeito2);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.cbEfeito1);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.txtFlagPercent3);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtTypeID);
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Controls.Add(this.txtFlagPercent1);
            this.GroupBox1.Controls.Add(this.txtFlagPercent2);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Location = new System.Drawing.Point(6, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(568, 325);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(257, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "Flag1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "Flag2";
            // 
            // txtFlag2
            // 
            this.txtFlag2.Location = new System.Drawing.Point(304, 180);
            this.txtFlag2.Name = "txtFlag2";
            this.txtFlag2.Size = new System.Drawing.Size(137, 21);
            this.txtFlag2.TabIndex = 31;
            // 
            // txtFlag1
            // 
            this.txtFlag1.Location = new System.Drawing.Point(304, 154);
            this.txtFlag1.Name = "txtFlag1";
            this.txtFlag1.Size = new System.Drawing.Size(137, 21);
            this.txtFlag1.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Efeito_Ativo3";
            // 
            // nrAtivo3
            // 
            this.nrAtivo3.Font = new System.Drawing.Font("Arial", 10F);
            this.nrAtivo3.Location = new System.Drawing.Point(84, 128);
            this.nrAtivo3.Name = "nrAtivo3";
            this.nrAtivo3.Size = new System.Drawing.Size(137, 23);
            this.nrAtivo3.TabIndex = 29;
            this.nrAtivo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Efeito_Ativo2";
            // 
            // nrAtivo1
            // 
            this.nrAtivo1.Font = new System.Drawing.Font("Arial", 10F);
            this.nrAtivo1.Location = new System.Drawing.Point(84, 70);
            this.nrAtivo1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrAtivo1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrAtivo1.Name = "nrAtivo1";
            this.nrAtivo1.Size = new System.Drawing.Size(137, 23);
            this.nrAtivo1.TabIndex = 25;
            this.nrAtivo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nrAtivo1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nrAtivo2
            // 
            this.nrAtivo2.Font = new System.Drawing.Font("Arial", 10F);
            this.nrAtivo2.Location = new System.Drawing.Point(84, 99);
            this.nrAtivo2.Name = "nrAtivo2";
            this.nrAtivo2.Size = new System.Drawing.Size(137, 23);
            this.nrAtivo2.TabIndex = 26;
            this.nrAtivo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Efeito_Ativo1";
            // 
            // cbEfeito3
            // 
            this.cbEfeito3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEfeito3.FormattingEnabled = true;
            this.cbEfeito3.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL_BY_WIND_NO_ITEM",
            "PIXEL_OVER_WIND_NO_ITEM",
            "PIXEL_BY_WIND",
            "PIXEL_2",
            "PIXEL_WITH_WEAK_WIND",
            "POWER_GAUGE_TO_START_HOLE",
            "POWER_GAUGE_MORE_ONE",
            "POWER_GUAGE_TO_START_GAME",
            "PAWS_NOT_ACCUMULATE",
            "SWITCH_TWO_EFFECT",
            "EARCUFF_DIRECTION_WIND",
            "COMBINE_ITEM_EFFECT",
            "SAFETY_CLIENT_RANDOM",
            "PIXEL_RANDOM",
            "WIND_1M_RANDOM",
            "PIXEL_BY_WIND_MIDDLE_DOUBLE",
            "GROUND_100_PERCENT_RONDOM",
            "ASSIST_MIRACLE_SIGN",
            "VECTOR_SIGN",
            "ASSIST_TRAJECTORY_SHOT",
            "PAWS_ACCUMULATE",
            "POWER_GAUGE_FREE ",
            "SAFETY_RANDOM ",
            "ONE_IN_ALL_STATS       ",
            "POWER_GAUGE_BY_MISS_SHOT",
            "PIXEL_BY_WIND_2",
            "PIXEL_WITH_RAIN",
            "NO_RAIN_EFFECT",
            "PUTT_MORE_10Y_RANDOM",
            "UNKNOWN_31",
            "MIRACLE_SIGN_RANDOM",
            "UNKNOWN_33",
            "DECREASE_1M_OF_WIND"});
            this.cbEfeito3.Location = new System.Drawing.Point(304, 128);
            this.cbEfeito3.Name = "cbEfeito3";
            this.cbEfeito3.Size = new System.Drawing.Size(241, 23);
            this.cbEfeito3.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Efeito_Tipo3";
            // 
            // cbEfeito2
            // 
            this.cbEfeito2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEfeito2.FormattingEnabled = true;
            this.cbEfeito2.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL_BY_WIND_NO_ITEM",
            "PIXEL_OVER_WIND_NO_ITEM",
            "PIXEL_BY_WIND",
            "PIXEL_2",
            "PIXEL_WITH_WEAK_WIND",
            "POWER_GAUGE_TO_START_HOLE",
            "POWER_GAUGE_MORE_ONE",
            "POWER_GUAGE_TO_START_GAME",
            "PAWS_NOT_ACCUMULATE",
            "SWITCH_TWO_EFFECT",
            "EARCUFF_DIRECTION_WIND",
            "COMBINE_ITEM_EFFECT",
            "SAFETY_CLIENT_RANDOM",
            "PIXEL_RANDOM",
            "WIND_1M_RANDOM",
            "PIXEL_BY_WIND_MIDDLE_DOUBLE",
            "GROUND_100_PERCENT_RONDOM",
            "ASSIST_MIRACLE_SIGN",
            "VECTOR_SIGN",
            "ASSIST_TRAJECTORY_SHOT",
            "PAWS_ACCUMULATE",
            "POWER_GAUGE_FREE ",
            "SAFETY_RANDOM ",
            "ONE_IN_ALL_STATS       ",
            "POWER_GAUGE_BY_MISS_SHOT",
            "PIXEL_BY_WIND_2",
            "PIXEL_WITH_RAIN",
            "NO_RAIN_EFFECT",
            "PUTT_MORE_10Y_RANDOM",
            "UNKNOWN_31",
            "MIRACLE_SIGN_RANDOM",
            "UNKNOWN_33",
            "DECREASE_1M_OF_WIND"});
            this.cbEfeito2.Location = new System.Drawing.Point(304, 98);
            this.cbEfeito2.Name = "cbEfeito2";
            this.cbEfeito2.Size = new System.Drawing.Size(241, 23);
            this.cbEfeito2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Efeito_Tipo2";
            // 
            // cbEfeito1
            // 
            this.cbEfeito1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEfeito1.FormattingEnabled = true;
            this.cbEfeito1.ItemHeight = 15;
            this.cbEfeito1.Items.AddRange(new object[] {
            "NONE",
            "PIXEL",
            "PIXEL_BY_WIND_NO_ITEM",
            "PIXEL_OVER_WIND_NO_ITEM",
            "PIXEL_BY_WIND",
            "PIXEL_2",
            "PIXEL_WITH_WEAK_WIND",
            "POWER_GAUGE_TO_START_HOLE",
            "POWER_GAUGE_MORE_ONE",
            "POWER_GUAGE_TO_START_GAME",
            "PAWS_NOT_ACCUMULATE",
            "SWITCH_TWO_EFFECT",
            "EARCUFF_DIRECTION_WIND",
            "COMBINE_ITEM_EFFECT",
            "SAFETY_CLIENT_RANDOM",
            "PIXEL_RANDOM",
            "WIND_1M_RANDOM",
            "PIXEL_BY_WIND_MIDDLE_DOUBLE",
            "GROUND_100_PERCENT_RONDOM",
            "ASSIST_MIRACLE_SIGN",
            "VECTOR_SIGN",
            "ASSIST_TRAJECTORY_SHOT",
            "PAWS_ACCUMULATE",
            "POWER_GAUGE_FREE ",
            "SAFETY_RANDOM ",
            "ONE_IN_ALL_STATS       ",
            "POWER_GAUGE_BY_MISS_SHOT",
            "PIXEL_BY_WIND_2",
            "PIXEL_WITH_RAIN",
            "NO_RAIN_EFFECT",
            "PUTT_MORE_10Y_RANDOM",
            "UNKNOWN_31",
            "MIRACLE_SIGN_RANDOM",
            "UNKNOWN_33",
            "DECREASE_1M_OF_WIND"});
            this.cbEfeito1.Location = new System.Drawing.Point(304, 69);
            this.cbEfeito1.Name = "cbEfeito1";
            this.cbEfeito1.Size = new System.Drawing.Size(241, 23);
            this.cbEfeito1.TabIndex = 20;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(224, 74);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(76, 15);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "Efeito_Tipo1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Efeito_Flag3";
            // 
            // txtFlagPercent3
            // 
            this.txtFlagPercent3.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFlagPercent3.Location = new System.Drawing.Point(84, 215);
            this.txtFlagPercent3.Name = "txtFlagPercent3";
            this.txtFlagPercent3.Size = new System.Drawing.Size(137, 23);
            this.txtFlagPercent3.TabIndex = 17;
            this.txtFlagPercent3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(3, 189);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(76, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Efeito_Flag2";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Nome";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(44, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "TypeID";
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(84, 46);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(137, 21);
            this.txtTypeID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 21);
            this.txtName.TabIndex = 0;
            // 
            // txtFlagPercent1
            // 
            this.txtFlagPercent1.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFlagPercent1.Location = new System.Drawing.Point(84, 157);
            this.txtFlagPercent1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtFlagPercent1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFlagPercent1.Name = "txtFlagPercent1";
            this.txtFlagPercent1.Size = new System.Drawing.Size(137, 23);
            this.txtFlagPercent1.TabIndex = 1;
            this.txtFlagPercent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFlagPercent1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtFlagPercent2
            // 
            this.txtFlagPercent2.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFlagPercent2.Location = new System.Drawing.Point(84, 186);
            this.txtFlagPercent2.Name = "txtFlagPercent2";
            this.txtFlagPercent2.Size = new System.Drawing.Size(137, 23);
            this.txtFlagPercent2.TabIndex = 1;
            this.txtFlagPercent2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(3, 160);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(76, 15);
            this.Label17.TabIndex = 11;
            this.Label17.Text = "Efeito_Flag1";
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 366);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(588, 70);
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
            // diagPasta
            // 
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            // 
            // FrmAbilityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 507);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAbilityEditor";
            this.Text = "Ability - Editor IFF ";
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
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrAtivo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlagPercent2)).EndInit();
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
        [AccessedThroughProperty("Panel2")]
        private Panel Panel2;
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
        private ToolStripSeparator ToolStripSeparator1;
        [AccessedThroughProperty("bwSalvar")]
        private BackgroundWorker bwSalvar;
        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;
        [AccessedThroughProperty("Label33")]
        private Label Label33;
        [AccessedThroughProperty("ImageList1")]
        private ImageList ImageList1;
        [AccessedThroughProperty("Label39")]
        private Label Label39;
        [AccessedThroughProperty("ImageList2")]
        private ImageList ImageList2;
        [AccessedThroughProperty("diagPasta")]
        private FolderBrowserDialog diagPasta;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip ToolTip1;
        public string Arquivo;
        private Ability oIff;
        public AbilityCollection lsItens;
        public AbilityCollection lsTemp;
        public byte[] bStart;
        private bool Alterado;
        private BindingSource bs;
        private int lastRow;
        public long qtdItem;
#pragma warning disable CS0169 // O campo "FrmAbilityEditor.arquivog" nunca é usado
        private string arquivog;
#pragma warning restore CS0169 // O campo "FrmAbilityEditor.arquivog" nunca é usado
        private string caminho;
        #endregion

        private TabPage TabPage1;
        private GroupBox GroupBox1;
        private ComboBox cbEfeito1;
        private Label Label8;
        private Label label2;
        private NumericUpDown txtFlagPercent3;
        private Label Label7;
        private Label Label1;
        private Label Label6;
        private TextBox txtTypeID;
        private TextBox txtName;
        private NumericUpDown txtFlagPercent1;
        private NumericUpDown txtFlagPercent2;
        private Label Label17;
        private ComboBox cbEfeito3;
        private Label label4;
        private ComboBox cbEfeito2;
        private Label label3;
        private Label label11;
        private Label label12;
        private TextBox txtFlag2;
        private TextBox txtFlag1;
        private Label label5;
        private NumericUpDown nrAtivo3;
        private Label label9;
        private NumericUpDown nrAtivo1;
        private NumericUpDown nrAtivo2;
        private Label label10;
    }
}