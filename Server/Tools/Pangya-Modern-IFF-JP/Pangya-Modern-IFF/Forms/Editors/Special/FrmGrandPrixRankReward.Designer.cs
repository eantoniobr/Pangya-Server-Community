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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    partial class FrmGrandPrixRankReward
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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtRes4 = new System.Windows.Forms.TextBox();
            this.txtRes3 = new System.Windows.Forms.TextBox();
            this.txtRes2 = new System.Windows.Forms.TextBox();
            this.txtRes1 = new System.Windows.Forms.TextBox();
            this.img4 = new System.Windows.Forms.PictureBox();
            this.img3 = new System.Windows.Forms.PictureBox();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.img1 = new System.Windows.Forms.PictureBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtItem5 = new System.Windows.Forms.TextBox();
            this.txtItem5Qtd = new System.Windows.Forms.NumericUpDown();
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbAba = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.txtTrophyID = new System.Windows.Forms.TextBox();
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
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.diagSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.imgPersonagem = new System.Windows.Forms.PictureBox();
            this.btnAbrirArquivo = new System.Windows.Forms.ToolStripButton();
            this.menuSalvarComo = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuBackup = new System.Windows.Forms.ToolStripButton();
            this.bwSalvar = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem5Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).BeginInit();
            this.gbBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).BeginInit();
            this.ToolStrip1.SuspendLayout();
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
            this.StatusStrip1.Size = new System.Drawing.Size(851, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(560, 17);
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
            this.SplitContainer1.Size = new System.Drawing.Size(851, 533);
            this.SplitContainer1.SplitterDistance = 297;
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
            this.Panel3.Size = new System.Drawing.Size(297, 533);
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
            this.panel5.Size = new System.Drawing.Size(297, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(151, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "GrandPrixRankReward.iff";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.pictureBox9);
            this.Panel1.Controls.Add(this.pictureBox5);
            this.Panel1.Controls.Add(this.cbPage);
            this.Panel1.Controls.Add(this.label22);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.pictureBox3);
            this.Panel1.Controls.Add(this.pictureBox6);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.textBox1);
            this.Panel1.Controls.Add(this.lblSearchCount);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 457);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(297, 76);
            this.Panel1.TabIndex = 2;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.pictureBox9.Location = new System.Drawing.Point(153, 38);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(35, 35);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox9.TabIndex = 28;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Pangya_Modern_Editor.Properties.Resources.none;
            this.pictureBox5.Location = new System.Drawing.Point(3, 37);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
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
            "Rookie",
            "Beginner",
            "Junior",
            "Senior"});
            this.cbPage.Location = new System.Drawing.Point(44, 53);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(102, 21);
            this.cbPage.TabIndex = 25;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(47, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Page";
            // 
            // Label39
            // 
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label39.Location = new System.Drawing.Point(4, 32);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(288, 2);
            this.Label39.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.pictureBox3.Location = new System.Drawing.Point(232, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSearch;
            this.pictureBox6.Location = new System.Drawing.Point(5, 6);
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
            this.ComboBox2.Location = new System.Drawing.Point(194, 53);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(97, 21);
            this.ComboBox2.TabIndex = 1;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(27, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCount.Location = new System.Drawing.Point(255, 8);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(14, 16);
            this.lblSearchCount.TabIndex = 10;
            this.lblSearchCount.Text = "0";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(194, 37);
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
            this.ListaItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.ListaItem.Size = new System.Drawing.Size(296, 430);
            this.ListaItem.TabIndex = 0;
            this.ListaItem.DefaultCellStyleChanged += new System.EventHandler(this.ListaItem_DefaultCellStyleChanged);
            this.ListaItem.RowDefaultCellStyleChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            this.ListaItem.Sorted += new System.EventHandler(this.ListaItem_Sorted);
            this.ListaItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaItem_KeyDown);
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
            this.Panel4.Size = new System.Drawing.Size(546, 527);
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
            this.tabForm.Size = new System.Drawing.Size(536, 451);
            this.tabForm.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.White;
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(528, 425);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Init Info";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.textBox2);
            this.GroupBox2.Controls.Add(this.pictureBox8);
            this.GroupBox2.Controls.Add(this.txtRes4);
            this.GroupBox2.Controls.Add(this.txtRes3);
            this.GroupBox2.Controls.Add(this.txtRes2);
            this.GroupBox2.Controls.Add(this.txtRes1);
            this.GroupBox2.Controls.Add(this.img4);
            this.GroupBox2.Controls.Add(this.img3);
            this.GroupBox2.Controls.Add(this.img2);
            this.GroupBox2.Controls.Add(this.img1);
            this.GroupBox2.Location = new System.Drawing.Point(6, 239);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(516, 100);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Reward Result";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(377, 77);
            this.textBox2.MaxLength = 20000;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(65, 21);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.pictureBox8.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.bg_transparent;
            this.pictureBox8.Location = new System.Drawing.Point(377, 20);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(65, 59);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox8.TabIndex = 18;
            this.pictureBox8.TabStop = false;
            // 
            // txtRes4
            // 
            this.txtRes4.BackColor = System.Drawing.Color.White;
            this.txtRes4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRes4.Location = new System.Drawing.Point(303, 77);
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
            this.txtRes3.Location = new System.Drawing.Point(227, 77);
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
            this.txtRes2.Location = new System.Drawing.Point(151, 77);
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
            this.txtRes1.Location = new System.Drawing.Point(75, 77);
            this.txtRes1.MaxLength = 20000;
            this.txtRes1.Name = "txtRes1";
            this.txtRes1.ReadOnly = true;
            this.txtRes1.Size = new System.Drawing.Size(65, 21);
            this.txtRes1.TabIndex = 2;
            this.txtRes1.Text = "0";
            this.txtRes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // img4
            // 
            this.img4.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img4.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img4.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img4.Location = new System.Drawing.Point(303, 20);
            this.img4.Name = "img4";
            this.img4.Size = new System.Drawing.Size(65, 59);
            this.img4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img4.TabIndex = 15;
            this.img4.TabStop = false;
            // 
            // img3
            // 
            this.img3.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img3.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img3.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img3.Location = new System.Drawing.Point(227, 20);
            this.img3.Name = "img3";
            this.img3.Size = new System.Drawing.Size(65, 59);
            this.img3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img3.TabIndex = 15;
            this.img3.TabStop = false;
            // 
            // img2
            // 
            this.img2.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img2.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img2.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img2.Location = new System.Drawing.Point(151, 20);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(65, 59);
            this.img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img2.TabIndex = 15;
            this.img2.TabStop = false;
            // 
            // img1
            // 
            this.img1.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.img1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.img1.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.img1.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.img1.Location = new System.Drawing.Point(75, 20);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(65, 59);
            this.img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img1.TabIndex = 15;
            this.img1.TabStop = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.cbAba);
            this.GroupBox3.Controls.Add(this.label23);
            this.GroupBox3.Controls.Add(this.txtTrophyID);
            this.GroupBox3.Controls.Add(this.txtItem5);
            this.GroupBox3.Controls.Add(this.ckAtivo);
            this.GroupBox3.Controls.Add(this.txtItem5Qtd);
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
            this.GroupBox3.Location = new System.Drawing.Point(4, 3);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(521, 221);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Quantity";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(81, 186);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 15);
            this.label23.TabIndex = 35;
            this.label23.Text = "Item 5:";
            // 
            // txtItem5
            // 
            this.txtItem5.Location = new System.Drawing.Point(130, 183);
            this.txtItem5.Name = "txtItem5";
            this.txtItem5.Size = new System.Drawing.Size(110, 21);
            this.txtItem5.TabIndex = 32;
            // 
            // txtItem5Qtd
            // 
            this.txtItem5Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem5Qtd.Location = new System.Drawing.Point(339, 183);
            this.txtItem5Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem5Qtd.Name = "txtItem5Qtd";
            this.txtItem5Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem5Qtd.TabIndex = 33;
            this.txtItem5Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(286, 161);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(51, 15);
            this.Label16.TabIndex = 11;
            this.Label16.Text = "Quantity";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(286, 137);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(51, 15);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "Quantity";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(286, 113);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(51, 15);
            this.Label12.TabIndex = 11;
            this.Label12.Text = "Quantity";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(286, 89);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(51, 15);
            this.Label10.TabIndex = 11;
            this.Label10.Text = "Quantity";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(258, 52);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(79, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Total Reward";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(81, 161);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(44, 15);
            this.Label15.TabIndex = 11;
            this.Label15.Text = "Item 4:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(81, 137);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(44, 15);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "Item 3:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(81, 113);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(44, 15);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Item 2:";
            // 
            // txtItem4
            // 
            this.txtItem4.Location = new System.Drawing.Point(130, 158);
            this.txtItem4.Name = "txtItem4";
            this.txtItem4.Size = new System.Drawing.Size(110, 21);
            this.txtItem4.TabIndex = 8;
            this.txtItem4.TextChanged += new System.EventHandler(this.txtItem4_TextChanged);
            // 
            // txtItem3
            // 
            this.txtItem3.Location = new System.Drawing.Point(130, 134);
            this.txtItem3.Name = "txtItem3";
            this.txtItem3.Size = new System.Drawing.Size(110, 21);
            this.txtItem3.TabIndex = 6;
            this.txtItem3.TextChanged += new System.EventHandler(this.txtItem3_TextChanged);
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(130, 110);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(110, 21);
            this.txtItem2.TabIndex = 4;
            this.txtItem2.TextChanged += new System.EventHandler(this.txtItem2_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(81, 89);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(44, 15);
            this.Label9.TabIndex = 11;
            this.Label9.Text = "Item 1:";
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(130, 86);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(110, 21);
            this.txtItem1.TabIndex = 2;
            this.txtItem1.TextChanged += new System.EventHandler(this.txtItem1_TextChanged);
            // 
            // txtItem4Qtd
            // 
            this.txtItem4Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem4Qtd.Location = new System.Drawing.Point(339, 158);
            this.txtItem4Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem4Qtd.Name = "txtItem4Qtd";
            this.txtItem4Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem4Qtd.TabIndex = 9;
            this.txtItem4Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem4Qtd.ValueChanged += new System.EventHandler(this.txtItem4Qtd_ValueChanged);
            // 
            // txtItem3Qtd
            // 
            this.txtItem3Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem3Qtd.Location = new System.Drawing.Point(339, 134);
            this.txtItem3Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem3Qtd.Name = "txtItem3Qtd";
            this.txtItem3Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem3Qtd.TabIndex = 7;
            this.txtItem3Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem3Qtd.ValueChanged += new System.EventHandler(this.txtItem3Qtd_ValueChanged);
            // 
            // txtItem2Qtd
            // 
            this.txtItem2Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem2Qtd.Location = new System.Drawing.Point(339, 110);
            this.txtItem2Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem2Qtd.Name = "txtItem2Qtd";
            this.txtItem2Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem2Qtd.TabIndex = 5;
            this.txtItem2Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem2Qtd.ValueChanged += new System.EventHandler(this.txtItem2Qtd_ValueChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(86, 53);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "ID GP";
            // 
            // txtItem1Qtd
            // 
            this.txtItem1Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem1Qtd.Location = new System.Drawing.Point(339, 86);
            this.txtItem1Qtd.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtItem1Qtd.Name = "txtItem1Qtd";
            this.txtItem1Qtd.Size = new System.Drawing.Size(72, 23);
            this.txtItem1Qtd.TabIndex = 3;
            this.txtItem1Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItem1Qtd.ValueChanged += new System.EventHandler(this.txtItem1Qtd_ValueChanged);
            // 
            // txtTypeID
            // 
            this.txtTypeID.Location = new System.Drawing.Point(131, 50);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(110, 21);
            this.txtTypeID.TabIndex = 0;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtItemProdQtd
            // 
            this.txtItemProdQtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItemProdQtd.Location = new System.Drawing.Point(338, 48);
            this.txtItemProdQtd.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtItemProdQtd.Name = "txtItemProdQtd";
            this.txtItemProdQtd.ReadOnly = true;
            this.txtItemProdQtd.Size = new System.Drawing.Size(72, 23);
            this.txtItemProdQtd.TabIndex = 1;
            this.txtItemProdQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(66, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Trophy ID";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(261, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 15);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Page";
            // 
            // cbAba
            // 
            this.cbAba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAba.FormattingEnabled = true;
            this.cbAba.Items.AddRange(new object[] {
            "ROOKIE",
            "BEGINNER",
            "ADVANCE",
            "EVENT"});
            this.cbAba.Location = new System.Drawing.Point(300, 11);
            this.cbAba.Name = "cbAba";
            this.cbAba.Size = new System.Drawing.Size(94, 23);
            this.cbAba.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbAba, "type, event, rookie, beginer, advance");
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(409, 13);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 2;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtTrophyID
            // 
            this.txtTrophyID.Location = new System.Drawing.Point(131, 15);
            this.txtTrophyID.Name = "txtTrophyID";
            this.txtTrophyID.Size = new System.Drawing.Size(109, 21);
            this.txtTrophyID.TabIndex = 0;
            this.txtTrophyID.TextChanged += new System.EventHandler(this.Alterou);
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
            this.gbBotoes.Size = new System.Drawing.Size(536, 70);
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
            this.btnBackup.Enabled = false;
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
            this.PictureBox4.Image = global::Pangya_Modern_Editor.Properties.Resources.search_plus;
            this.PictureBox4.Location = new System.Drawing.Point(494, -31);
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
            this.PictureBox1.Location = new System.Drawing.Point(297, -31);
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
            this.txtPesquisa.Location = new System.Drawing.Point(319, -31);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(292, 20);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.Visible = false;
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
            this.ComboBox1.Location = new System.Drawing.Point(595, 16);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(131, 21);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.Visible = false;
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
            // diagSalvarArquivo
            // 
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Save File GrandPrixRankReward.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (GrandPrixRankReward.iff)";
            // 
            // imgPersonagem
            // 
            this.imgPersonagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.imgPersonagem.Image = global::Pangya_Modern_Editor.Properties.Resources.nuri;
            this.imgPersonagem.Location = new System.Drawing.Point(555, 0);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Image = global::Pangya_Modern_Editor.Properties.Resources.BntOpenFile;
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
            this.menuSalvarComo.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMenuSave;
            this.menuSalvarComo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalvarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSalvarComo.Name = "menuSalvarComo";
            this.menuSalvarComo.Size = new System.Drawing.Size(36, 37);
            this.menuSalvarComo.ToolTipText = "Salvar como";
            this.menuSalvarComo.Click += new System.EventHandler(this.MenuSalvar_Click);
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
            this.ToolStrip1.Size = new System.Drawing.Size(851, 40);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
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
            // bwSalvar
            // 
            this.bwSalvar.WorkerReportsProgress = true;
            this.bwSalvar.WorkerSupportsCancellation = true;
            this.bwSalvar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSalvar_DoWork);
            this.bwSalvar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSalvar_ProgressChanged);
            this.bwSalvar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSalvar_RunWorkerCompleted);
            // 
            // FrmGrandPrixRankReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 600);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmGrandPrixRankReward";
            this.Text = "GrandPrixRankReward - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmGrandPrixRankReward_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaItem)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem5Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem4Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem3Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem2Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem1Qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemProdQtd)).EndInit();
            this.gbBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPersonagem)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip StatusStrip1;

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

        [AccessedThroughProperty("ckAtivo")]
        private CheckBox ckAtivo;

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

        [AccessedThroughProperty("diagSalvarArquivo")]
        private SaveFileDialog diagSalvarArquivo;

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

        [AccessedThroughProperty("ComboBox1")]
        private ComboBox ComboBox1;

        [AccessedThroughProperty("txtTypeID")]
        private TextBox txtTypeID;

        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        [AccessedThroughProperty("Label36")]
        private Label Label36;

        [AccessedThroughProperty("Label1")]
        private Label Label1;

        [AccessedThroughProperty("GroupBox2")]
        private GroupBox GroupBox2;

        [AccessedThroughProperty("txtRes1")]
        private TextBox txtRes1;

        [AccessedThroughProperty("img1")]
        private PictureBox img1;

        [AccessedThroughProperty("txtRes4")]
        private TextBox txtRes4;

        [AccessedThroughProperty("txtRes3")]
        private TextBox txtRes3;

        [AccessedThroughProperty("txtRes2")]
        private TextBox txtRes2;

        [AccessedThroughProperty("img4")]
        private PictureBox img4;

        [AccessedThroughProperty("img3")]
        private PictureBox img3;

        [AccessedThroughProperty("img2")]
        private PictureBox img2;

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

        [AccessedThroughProperty("txtIndex")]
        private TextBox txtTrophyID;

        public string Arquivo;

        private GrandPrixRankReward oIff;
        private bool sfile;
        public IFFFile<GrandPrixRankReward> lsItens;

        public IFFFile<GrandPrixRankReward> lsTemp;

        public byte[] bStart;

        private bool Alterado;

        private BindingSource bs;

        private int lastRow;

        public long qtdItem;    
        #endregion
        private DataGridView ListaItem;
        private Panel Panel1;
        private Label Label39;
        private PictureBox pictureBox3;
        private PictureBox pictureBox6;
        private ComboBox ComboBox2;
        private TextBox textBox1;
        private Label lblSearchCount;
        private Label Label37;
        private Panel panel5;
        private PictureBox pictureBox7;
        private Label label21;                                                           
        private ComboBox cbPage;
        private Label label22;
        private Label label8;
        private Label label23;
        private TextBox txtItem5;
        private NumericUpDown txtItem5Qtd;
        private TextBox textBox2;
        private PictureBox pictureBox8;
        private ToolStripButton btnAbrirArquivo;
        private ToolStripButton menuSalvarComo;
        private ToolStrip ToolStrip1;
        private BackgroundWorker bwSalvar;
        private ToolStripButton menuBackup;
        private PictureBox pictureBox9;
        private PictureBox pictureBox5;
        private ToolTip toolTip1;
    }
}