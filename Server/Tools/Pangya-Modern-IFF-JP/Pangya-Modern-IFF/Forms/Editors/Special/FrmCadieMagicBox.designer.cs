using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    partial class FrmCadieMagicBox
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
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCima = new System.Windows.Forms.ToolStripButton();
            this.btnBaixo = new System.Windows.Forms.ToolStripButton();
            this.btnIndices = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
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
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtRes4 = new System.Windows.Forms.TextBox();
            this.txtRes3 = new System.Windows.Forms.TextBox();
            this.txtRes2 = new System.Windows.Forms.TextBox();
            this.txtRes1 = new System.Windows.Forms.TextBox();
            this.imgResultado = new System.Windows.Forms.PictureBox();
            this.img4 = new System.Windows.Forms.PictureBox();
            this.img3 = new System.Windows.Forms.PictureBox();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.img1 = new System.Windows.Forms.PictureBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.ckTimeEvent = new System.Windows.Forms.CheckBox();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.Label28 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.Label27 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
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
            this.label24 = new System.Windows.Forms.Label();
            this.txtProdItem = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbContNome = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.rbLevelMax = new System.Windows.Forms.RadioButton();
            this.cbAba = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.rbLevelMin = new System.Windows.Forms.RadioButton();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtU6 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ckisRandom = new System.Windows.Forms.CheckBox();
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
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).BeginInit();
            this.GroupBox1.SuspendLayout();
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
            this.menuBackup,
            this.ToolStripSeparator1,
            this.btnCima,
            this.btnBaixo,
            this.btnIndices});
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
            this.menuSalvarComo.Click += new System.EventHandler(this.MenuSalvar_Click);
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
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnCima
            // 
            this.btnCima.Enabled = false;
            this.btnCima.Image = global::Pangya_Modern_Editor.Properties.Resources.HandUp;
            this.btnCima.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCima.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCima.Name = "btnCima";
            this.btnCima.Size = new System.Drawing.Size(36, 37);
            this.btnCima.ToolTipText = "Move to up";
            this.btnCima.Click += new System.EventHandler(this.btnCima_Click);
            // 
            // btnBaixo
            // 
            this.btnBaixo.Enabled = false;
            this.btnBaixo.Image = global::Pangya_Modern_Editor.Properties.Resources.HandDown;
            this.btnBaixo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBaixo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaixo.Name = "btnBaixo";
            this.btnBaixo.Size = new System.Drawing.Size(36, 37);
            this.btnBaixo.ToolTipText = "Move to down";
            this.btnBaixo.Click += new System.EventHandler(this.btnBaixo_Click);
            // 
            // btnIndices
            // 
            this.btnIndices.Enabled = false;
            this.btnIndices.Image = global::Pangya_Modern_Editor.Properties.Resources.flag;
            this.btnIndices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIndices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndices.Name = "btnIndices";
            this.btnIndices.Size = new System.Drawing.Size(36, 37);
            this.btnIndices.ToolTipText = "Reorganize data";
            this.btnIndices.Click += new System.EventHandler(this.btnIndices_Click);
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
            this.SplitContainer1.Size = new System.Drawing.Size(809, 533);
            this.SplitContainer1.SplitterDistance = 283;
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
            this.Panel3.Size = new System.Drawing.Size(283, 533);
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
            this.panel5.Size = new System.Drawing.Size(283, 27);
            this.panel5.TabIndex = 3;
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
            this.lbArquivo.Size = new System.Drawing.Size(111, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "CadieMagicBox.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.cbPage);
            this.Panel1.Controls.Add(this.label22);
            this.Panel1.Controls.Add(this.comboBox3);
            this.Panel1.Controls.Add(this.label20);
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
            this.Panel1.Size = new System.Drawing.Size(283, 76);
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
            "All",
            "Unknown",
            "Beginner",
            "Inter.",
            "Advanced",
            "Special",
            "Event"});
            this.cbPage.Location = new System.Drawing.Point(103, 54);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(88, 21);
            this.cbPage.TabIndex = 25;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(100, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Page";
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 13;
            this.comboBox3.Items.AddRange(new object[] {
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
            "Cecilia R"});
            this.comboBox3.Location = new System.Drawing.Point(5, 53);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(84, 21);
            this.comboBox3.TabIndex = 23;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Character";
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 32);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(274, 2);
            this.Label39.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.pictureBox3.Location = new System.Drawing.Point(204, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
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
            "All",
            "Enable",
            "Disable"});
            this.ComboBox2.Location = new System.Drawing.Point(202, 53);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(76, 21);
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
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 0;
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
            this.Label37.Location = new System.Drawing.Point(203, 38);
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
            this.ListaItem.RowsDefaultCellStyleChanged += new System.EventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            this.ListaItem.Sorted += new System.EventHandler(this.ListaItem_Sorted);
            this.ListaItem.MouseHover += new System.EventHandler(this.ListaItem_MouseHover);
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
            this.Panel4.Size = new System.Drawing.Size(518, 527);
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
            this.tabForm.Size = new System.Drawing.Size(508, 451);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.ckisRandom);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(500, 425);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.PictureBox5);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtResultado);
            this.GroupBox2.Controls.Add(this.txtRes4);
            this.GroupBox2.Controls.Add(this.txtRes3);
            this.GroupBox2.Controls.Add(this.txtRes2);
            this.GroupBox2.Controls.Add(this.txtRes1);
            this.GroupBox2.Controls.Add(this.imgResultado);
            this.GroupBox2.Controls.Add(this.img4);
            this.GroupBox2.Controls.Add(this.img3);
            this.GroupBox2.Controls.Add(this.img2);
            this.GroupBox2.Controls.Add(this.img1);
            this.GroupBox2.Location = new System.Drawing.Point(5, 278);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(492, 119);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Combine and Result";
            // 
            // PictureBox5
            // 
            this.PictureBox5.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnCauldron;
            this.PictureBox5.Location = new System.Drawing.Point(337, 20);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(36, 36);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox5.TabIndex = 16;
            this.PictureBox5.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(324, 59);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(59, 14);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Item Result";
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.White;
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultado.Location = new System.Drawing.Point(399, 92);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(65, 21);
            this.txtResultado.TabIndex = 2;
            this.txtResultado.Text = "0";
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // imgResultado
            // 
            this.imgResultado.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgResultado.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgResultado.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.imgResultado.Location = new System.Drawing.Point(399, 20);
            this.imgResultado.Name = "imgResultado";
            this.imgResultado.Size = new System.Drawing.Size(65, 73);
            this.imgResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgResultado.TabIndex = 15;
            this.imgResultado.TabStop = false;
            // 
            // img4
            // 
            this.img4.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img4.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img4.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img4.Location = new System.Drawing.Point(231, 20);
            this.img4.Name = "img4";
            this.img4.Size = new System.Drawing.Size(65, 75);
            this.img4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img4.TabIndex = 15;
            this.img4.TabStop = false;
            // 
            // img3
            // 
            this.img3.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img3.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img3.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img3.Location = new System.Drawing.Point(155, 20);
            this.img3.Name = "img3";
            this.img3.Size = new System.Drawing.Size(65, 75);
            this.img3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img3.TabIndex = 15;
            this.img3.TabStop = false;
            // 
            // img2
            // 
            this.img2.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img2.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img2.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img2.Location = new System.Drawing.Point(79, 20);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(65, 75);
            this.img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img2.TabIndex = 15;
            this.img2.TabStop = false;
            // 
            // img1
            // 
            this.img1.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img1.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img1.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img1.Location = new System.Drawing.Point(3, 20);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(65, 75);
            this.img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img1.TabIndex = 15;
            this.img1.TabStop = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.ckTimeEvent);
            this.GroupBox3.Controls.Add(this.dtTermino);
            this.GroupBox3.Controls.Add(this.Label28);
            this.GroupBox3.Controls.Add(this.dtInicio);
            this.GroupBox3.Controls.Add(this.Label27);
            this.GroupBox3.Controls.Add(this.button5);
            this.GroupBox3.Controls.Add(this.button1);
            this.GroupBox3.Controls.Add(this.Button4);
            this.GroupBox3.Controls.Add(this.Button3);
            this.GroupBox3.Controls.Add(this.Button2);
            this.GroupBox3.Controls.Add(this.Label8);
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
            this.GroupBox3.Location = new System.Drawing.Point(6, 107);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(498, 161);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            // 
            // ckTimeEvent
            // 
            this.ckTimeEvent.AutoSize = true;
            this.ckTimeEvent.Location = new System.Drawing.Point(406, 42);
            this.ckTimeEvent.Name = "ckTimeEvent";
            this.ckTimeEvent.Size = new System.Drawing.Size(87, 19);
            this.ckTimeEvent.TabIndex = 44;
            this.ckTimeEvent.Text = "Time Event";
            this.ckTimeEvent.UseVisualStyleBackColor = true;
            this.ckTimeEvent.CheckedChanged += new System.EventHandler(this.ckTimeEvent_CheckedChanged);
            // 
            // dtTermino
            // 
            this.dtTermino.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTermino.Location = new System.Drawing.Point(321, 125);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(158, 21);
            this.dtTermino.TabIndex = 37;
            this.dtTermino.Value = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(319, 106);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(91, 15);
            this.Label28.TabIndex = 36;
            this.Label28.Text = "Date End Event";
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(320, 83);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(159, 21);
            this.dtInicio.TabIndex = 35;
            this.dtInicio.Value = new System.DateTime(1982, 1, 1, 0, 0, 0, 0);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(320, 67);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(94, 15);
            this.Label27.TabIndex = 34;
            this.Label27.Text = "Date Start Event";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.button5.Location = new System.Drawing.Point(188, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 24);
            this.button5.TabIndex = 33;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.button1.Location = new System.Drawing.Point(190, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 24);
            this.button1.TabIndex = 32;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.Button4.Location = new System.Drawing.Point(190, 127);
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
            this.Button3.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.Button3.Location = new System.Drawing.Point(190, 103);
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
            this.Button2.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.Button2.Location = new System.Drawing.Point(190, 79);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(25, 24);
            this.Button2.TabIndex = 31;
            this.Button2.TabStop = false;
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label8.Location = new System.Drawing.Point(10, 38);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(483, 2);
            this.Label8.TabIndex = 30;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(216, 131);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(36, 15);
            this.Label16.TabIndex = 11;
            this.Label16.Text = "Qntd:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(216, 107);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(36, 15);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "Qntd:";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(216, 83);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(36, 15);
            this.Label12.TabIndex = 11;
            this.Label12.Text = "Qntd:";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(216, 59);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(36, 15);
            this.Label10.TabIndex = 11;
            this.Label10.Text = "Qntd:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(214, 17);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(36, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Qntd:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(57, 131);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(44, 15);
            this.Label15.TabIndex = 11;
            this.Label15.Text = "Item 4:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(57, 107);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(44, 15);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "Item 3:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(57, 83);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(44, 15);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Item 2:";
            // 
            // txtItem4
            // 
            this.txtItem4.Location = new System.Drawing.Point(102, 128);
            this.txtItem4.Name = "txtItem4";
            this.txtItem4.Size = new System.Drawing.Size(88, 21);
            this.txtItem4.TabIndex = 8;
            this.txtItem4.TextChanged += new System.EventHandler(this.txtItem4_TextChanged);
            // 
            // txtItem3
            // 
            this.txtItem3.Location = new System.Drawing.Point(102, 104);
            this.txtItem3.Name = "txtItem3";
            this.txtItem3.Size = new System.Drawing.Size(88, 21);
            this.txtItem3.TabIndex = 6;
            this.txtItem3.TextChanged += new System.EventHandler(this.txtItem3_TextChanged);
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(102, 80);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(88, 21);
            this.txtItem2.TabIndex = 4;
            this.txtItem2.TextChanged += new System.EventHandler(this.txtItem2_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(57, 59);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(44, 15);
            this.Label9.TabIndex = 11;
            this.Label9.Text = "Item 1:";
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(102, 56);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(88, 21);
            this.txtItem1.TabIndex = 2;
            this.txtItem1.TextChanged += new System.EventHandler(this.txtItem1_TextChanged);
            // 
            // txtItem4Qtd
            // 
            this.txtItem4Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem4Qtd.Location = new System.Drawing.Point(255, 126);
            this.txtItem4Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem4Qtd.Name = "txtItem4Qtd";
            this.txtItem4Qtd.Size = new System.Drawing.Size(59, 23);
            this.txtItem4Qtd.TabIndex = 9;
            this.txtItem4Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem4Qtd.ValueChanged += new System.EventHandler(this.txtItem4Qtd_ValueChanged);
            // 
            // txtItem3Qtd
            // 
            this.txtItem3Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem3Qtd.Location = new System.Drawing.Point(255, 102);
            this.txtItem3Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem3Qtd.Name = "txtItem3Qtd";
            this.txtItem3Qtd.Size = new System.Drawing.Size(59, 23);
            this.txtItem3Qtd.TabIndex = 7;
            this.txtItem3Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem3Qtd.ValueChanged += new System.EventHandler(this.txtItem3Qtd_ValueChanged);
            // 
            // txtItem2Qtd
            // 
            this.txtItem2Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem2Qtd.Location = new System.Drawing.Point(255, 78);
            this.txtItem2Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem2Qtd.Name = "txtItem2Qtd";
            this.txtItem2Qtd.Size = new System.Drawing.Size(59, 23);
            this.txtItem2Qtd.TabIndex = 5;
            this.txtItem2Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem2Qtd.ValueChanged += new System.EventHandler(this.txtItem2Qtd_ValueChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(25, 17);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Result Item:";
            // 
            // txtItem1Qtd
            // 
            this.txtItem1Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem1Qtd.Location = new System.Drawing.Point(255, 54);
            this.txtItem1Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem1Qtd.Name = "txtItem1Qtd";
            this.txtItem1Qtd.Size = new System.Drawing.Size(59, 23);
            this.txtItem1Qtd.TabIndex = 3;
            this.txtItem1Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem1Qtd.ValueChanged += new System.EventHandler(this.txtItem1Qtd_ValueChanged);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(101, 14);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(87, 21);
            this.txtTypeID.TabIndex = 0;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtItemProdQtd
            // 
            this.txtItemProdQtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItemProdQtd.Location = new System.Drawing.Point(252, 12);
            this.txtItemProdQtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItemProdQtd.Name = "txtItemProdQtd";
            this.txtItemProdQtd.Size = new System.Drawing.Size(62, 23);
            this.txtItemProdQtd.TabIndex = 1;
            this.txtItemProdQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemProdQtd.ValueChanged += new System.EventHandler(this.txtItemProdQtd_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label24);
            this.GroupBox1.Controls.Add(this.txtProdItem);
            this.GroupBox1.Controls.Add(this.label23);
            this.GroupBox1.Controls.Add(this.txtBoxID);
            this.GroupBox1.Controls.Add(this.txtNome);
            this.GroupBox1.Controls.Add(this.lbContNome);
            this.GroupBox1.Controls.Add(this.label18);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.rbLevelMax);
            this.GroupBox1.Controls.Add(this.cbAba);
            this.GroupBox1.Controls.Add(this.ckAtivo);
            this.GroupBox1.Controls.Add(this.cbLevel);
            this.GroupBox1.Controls.Add(this.rbLevelMin);
            this.GroupBox1.Controls.Add(this.txtIndex);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.txtU6);
            this.GroupBox1.Location = new System.Drawing.Point(6, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(495, 102);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(248, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 15);
            this.label24.TabIndex = 43;
            this.label24.Text = "Prod. Item:";
            // 
            // txtProdItem
            // 
            this.txtProdItem.Location = new System.Drawing.Point(317, 37);
            this.txtProdItem.Name = "txtProdItem";
            this.txtProdItem.Size = new System.Drawing.Size(81, 21);
            this.txtProdItem.TabIndex = 42;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(252, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 15);
            this.label23.TabIndex = 41;
            this.label23.Text = "Box Index:";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(317, 11);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(81, 21);
            this.txtBoxID.TabIndex = 40;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(49, 11);
            this.txtNome.MaxLength = 64;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(164, 21);
            this.txtNome.TabIndex = 12;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lbContNome
            // 
            this.lbContNome.AutoSize = true;
            this.lbContNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContNome.ForeColor = System.Drawing.Color.Gray;
            this.lbContNome.Location = new System.Drawing.Point(213, 14);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 13;
            this.lbContNome.Text = "0/40";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Seq.";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(287, 67);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(30, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Tab:";
            this.ToolTip1.SetToolTip(this.Label3, "Page in Cauldron");
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 69);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(36, 15);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Level";
            // 
            // rbLevelMax
            // 
            this.rbLevelMax.AutoSize = true;
            this.rbLevelMax.Location = new System.Drawing.Point(193, 79);
            this.rbLevelMax.Name = "rbLevelMax";
            this.rbLevelMax.Size = new System.Drawing.Size(81, 19);
            this.rbLevelMax.TabIndex = 5;
            this.rbLevelMax.Text = "Level Max.";
            this.rbLevelMax.UseVisualStyleBackColor = true;
            // 
            // cbAba
            // 
            this.cbAba.DisplayMember = "Intermediario";
            this.cbAba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAba.FormattingEnabled = true;
            this.cbAba.Items.AddRange(new object[] {
            "Unknown",
            "Beg.",
            "Int.",
            "Adv.",
            "Special",
            "Event"});
            this.cbAba.Location = new System.Drawing.Point(317, 63);
            this.cbAba.Name = "cbAba";
            this.cbAba.Size = new System.Drawing.Size(81, 23);
            this.cbAba.TabIndex = 1;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(431, 11);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 2;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
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
            this.cbLevel.Location = new System.Drawing.Point(49, 65);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(140, 23);
            this.cbLevel.TabIndex = 3;
            this.ToolTip1.SetToolTip(this.cbLevel, "request level for get item");
            // 
            // rbLevelMin
            // 
            this.rbLevelMin.AutoSize = true;
            this.rbLevelMin.Checked = true;
            this.rbLevelMin.Location = new System.Drawing.Point(194, 63);
            this.rbLevelMin.Name = "rbLevelMin";
            this.rbLevelMin.Size = new System.Drawing.Size(79, 19);
            this.rbLevelMin.TabIndex = 4;
            this.rbLevelMin.TabStop = true;
            this.rbLevelMin.Text = "Level Min.";
            this.rbLevelMin.UseVisualStyleBackColor = true;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(49, 38);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(79, 21);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(131, 41);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(32, 15);
            this.Label17.TabIndex = 11;
            this.Label17.Text = "Type";
            // 
            // txtU6
            // 
            this.txtU6.Location = new System.Drawing.Point(164, 38);
            this.txtU6.Name = "txtU6";
            this.txtU6.Size = new System.Drawing.Size(63, 21);
            this.txtU6.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.txtU6, " NURI = 0, HANA = 1, AZER = 2, CESILLIA = 3, MAX = 4, KOOH = 5, ARIN = 6, KAZ = 7" +
        ", LUCIA = 8, NELL = 9, SPIKA = 10, NURI_R = 11, HANA_R = 12, AZER_R = 13, CESILL" +
        "IA_R = 14");
            this.txtU6.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(11, 273);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(483, 2);
            this.Label2.TabIndex = 21;
            // 
            // ckisRandom
            // 
            this.ckisRandom.AutoSize = true;
            this.ckisRandom.Location = new System.Drawing.Point(299, 403);
            this.ckisRandom.Name = "ckisRandom";
            this.ckisRandom.Size = new System.Drawing.Size(170, 19);
            this.ckisRandom.TabIndex = 2;
            this.ckisRandom.Text = "Result are random items?";
            this.ckisRandom.UseVisualStyleBackColor = true;
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
            this.gbBotoes.Size = new System.Drawing.Size(508, 70);
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
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::Pangya_Modern_Editor.Properties.Resources.document_editing;
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
            this.txtPesquisa.Size = new System.Drawing.Size(250, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.Visible = false;
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(516, 5);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(14, 16);
            this.lblSearchCount.TabIndex = 10;
            this.lblSearchCount.Text = "0";
            this.lblSearchCount.Visible = false;
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
            this.diagSalvarArquivo.Title = "Save File Part.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (Part.iff)";
            // 
            // diagPasta
            // 
            this.diagPasta.Description = "Select the file folder";
            // 
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Location = new System.Drawing.Point(555, 55);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // FrmCadieMagicBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 600);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.lblSearchCount);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmCadieMagicBox";
            this.Text = "CadieMagicBox - Editor IFF ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadieMagicBox_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadieMagicBox_Load);
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
            this.TabPage1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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

		[AccessedThroughProperty("rbLevelMax")]
		private RadioButton rbLevelMax;

		[AccessedThroughProperty("rbLevelMin")]
		private RadioButton rbLevelMin;

		[AccessedThroughProperty("cbLevel")]
		private ComboBox cbLevel;

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

		[AccessedThroughProperty("txtTypeID")]
		private TextBox txtTypeID;

		[AccessedThroughProperty("bwSalvar")]
		private BackgroundWorker bwSalvar;

		[AccessedThroughProperty("PictureBox4")]
		private PictureBox PictureBox4;

		[AccessedThroughProperty("lblSearchCount")]
		private Label lblSearchCount;

		[AccessedThroughProperty("Label36")]
		private Label Label36;

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

		[AccessedThroughProperty("PictureBox5")]
		private PictureBox PictureBox5;

		[AccessedThroughProperty("Label5")]
		private Label Label5;

		[AccessedThroughProperty("txtResultado")]
		private TextBox txtResultado;

		[AccessedThroughProperty("txtRes4")]
		private TextBox txtRes4;

		[AccessedThroughProperty("txtRes3")]
		private TextBox txtRes3;

		[AccessedThroughProperty("txtRes2")]
		private TextBox txtRes2;

		[AccessedThroughProperty("imgResultado")]
		private PictureBox imgResultado;

		[AccessedThroughProperty("img4")]
		private PictureBox img4;

		[AccessedThroughProperty("img3")]
		private PictureBox img3;

		[AccessedThroughProperty("img2")]
		private PictureBox img2;

		[AccessedThroughProperty("Label4")]
		private Label Label4;

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

		[AccessedThroughProperty("Label8")]
		private Label Label8;

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

		[AccessedThroughProperty("btnBaixo")]
		private ToolStripButton btnBaixo;

		[AccessedThroughProperty("btnCima")]
		private ToolStripButton btnCima;

		[AccessedThroughProperty("btnIndices")]
		private ToolStripButton btnIndices;

		[AccessedThroughProperty("txtIndex")]
		private TextBox txtIndex;

		[AccessedThroughProperty("Button4")]
		private Button Button4;

		[AccessedThroughProperty("Button3")]
		private Button Button3;

		[AccessedThroughProperty("Button2")]
		private Button Button2;
		private ToolStripSeparator ToolStripSeparator1;   
		private Label Label17;               
		private TextBox txtU6;
                                                       
		private CheckBox ckisRandom;

		public string Arquivo;

		public IFFFile<CadieMagicBox> lsItens;

		public IFFFile<CadieMagicBox> lsTemp;

		public byte[] bStart;

		private bool Alterado;

		private BindingSource bs;

		private int lastRow;

		public long qtdItem;  
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
        private Panel panel5;
        private PictureBox pictureBox7;
        private Label label21;
        private ComboBox comboBox3;
        private Label label20;
#pragma warning disable CS0169 // O campo "FrmCadieMagicBoxEditor.Clonagem" nunca é usado
        private CadieMagicBox Clonagem;
#pragma warning restore CS0169 // O campo "FrmCadieMagicBoxEditor.Clonagem" nunca é usado
        private ComboBox cbPage;
        private Label label22;
        private DateTimePicker dtInicio;
        private Label Label27;
        private Button button5;
        private Button button1;
        private DateTimePicker dtTermino;
        private Label Label28;
        private CheckBox ckTimeEvent;
        private Label label24;
        private TextBox txtProdItem;
        private Label label23;
        private TextBox txtBoxID;
        private ToolStripButton menuBackup;
    }
}