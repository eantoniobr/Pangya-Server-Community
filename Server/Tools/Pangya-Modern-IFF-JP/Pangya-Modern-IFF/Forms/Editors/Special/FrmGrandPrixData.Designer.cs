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
    partial class FrmGrandPrixData
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.imgEvent = new System.Windows.Forms.PictureBox();
            this.imgMap = new System.Windows.Forms.PictureBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.ckShot = new System.Windows.Forms.CheckBox();
            this.ckNatural = new System.Windows.Forms.CheckBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbContNome = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbAba = new System.Windows.Forms.ComboBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbTempoVenda = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtAbre = new System.Windows.Forms.DateTimePicker();
            this.Label28 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.imgTicketID = new System.Windows.Forms.PictureBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.label67 = new System.Windows.Forms.Label();
            this.txtTrophyIDOne = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.cbClass = new System.Windows.Forms.TextBox();
            this.txtCondition1 = new System.Windows.Forms.TextBox();
            this.txtCondition0 = new System.Windows.Forms.TextBox();
            this.txtLevelMax = new System.Windows.Forms.TextBox();
            this.txtLevelMin = new System.Windows.Forms.TextBox();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.txtUn1 = new System.Windows.Forms.TextBox();
            this.txtUn = new System.Windows.Forms.TextBox();
            this.txtClearGP = new System.Windows.Forms.TextBox();
            this.txtLocker = new System.Windows.Forms.CheckBox();
            this.nmrPangReward = new System.Windows.Forms.NumericUpDown();
            this.cbHoleSize = new System.Windows.Forms.ComboBox();
            this.txt_Ticket_TypeID = new System.Windows.Forms.TextBox();
            this.txtTimeHole = new System.Windows.Forms.ComboBox();
            this.txt_Ticket_Qntd = new System.Windows.Forms.TextBox();
            this.cbTotalHole = new System.Windows.Forms.ComboBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.txtScore1 = new System.Windows.Forms.TextBox();
            this.txtScore2 = new System.Windows.Forms.TextBox();
            this.txtScore3 = new System.Windows.Forms.TextBox();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ckTempoAtivo = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
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
            this.label68 = new System.Windows.Forms.Label();
            this.txtTrophyIDTwoo = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.txtTrophyIDTree = new System.Windows.Forms.TextBox();
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
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMap)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbTempoVenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTicketID)).BeginInit();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPangReward)).BeginInit();
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
            this.lbArquivo.Size = new System.Drawing.Size(105, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "GrandPrixData.iff";
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
            this.tabForm.Controls.Add(this.tabPage2);
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
            this.TabPage1.Controls.Add(this.GroupBox1);
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
            this.GroupBox2.Location = new System.Drawing.Point(6, 318);
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
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.label23);
            this.GroupBox3.Controls.Add(this.txtItem5);
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
            this.GroupBox3.Location = new System.Drawing.Point(4, 128);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(521, 189);
            this.GroupBox3.TabIndex = 1;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "GP Items Reward";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Quantity";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(82, 157);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 15);
            this.label23.TabIndex = 35;
            this.label23.Text = "Item 5:";
            // 
            // txtItem5
            // 
            this.txtItem5.Location = new System.Drawing.Point(131, 154);
            this.txtItem5.Name = "txtItem5";
            this.txtItem5.Size = new System.Drawing.Size(110, 21);
            this.txtItem5.TabIndex = 32;
            // 
            // txtItem5Qtd
            // 
            this.txtItem5Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem5Qtd.Location = new System.Drawing.Point(340, 154);
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
            this.Label16.Location = new System.Drawing.Point(287, 132);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(51, 15);
            this.Label16.TabIndex = 11;
            this.Label16.Text = "Quantity";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(287, 108);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(51, 15);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "Quantity";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(287, 84);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(51, 15);
            this.Label12.TabIndex = 11;
            this.Label12.Text = "Quantity";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(287, 60);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(51, 15);
            this.Label10.TabIndex = 11;
            this.Label10.Text = "Quantity";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(259, 23);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(79, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Total Reward";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(82, 132);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(44, 15);
            this.Label15.TabIndex = 11;
            this.Label15.Text = "Item 4:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(82, 108);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(44, 15);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "Item 3:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(82, 84);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(44, 15);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Item 2:";
            // 
            // txtItem4
            // 
            this.txtItem4.Location = new System.Drawing.Point(131, 129);
            this.txtItem4.Name = "txtItem4";
            this.txtItem4.Size = new System.Drawing.Size(110, 21);
            this.txtItem4.TabIndex = 8;
            this.txtItem4.TextChanged += new System.EventHandler(this.txtItem4_TextChanged);
            // 
            // txtItem3
            // 
            this.txtItem3.Location = new System.Drawing.Point(131, 105);
            this.txtItem3.Name = "txtItem3";
            this.txtItem3.Size = new System.Drawing.Size(110, 21);
            this.txtItem3.TabIndex = 6;
            this.txtItem3.TextChanged += new System.EventHandler(this.txtItem3_TextChanged);
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(131, 81);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(110, 21);
            this.txtItem2.TabIndex = 4;
            this.txtItem2.TextChanged += new System.EventHandler(this.txtItem2_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(82, 60);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(44, 15);
            this.Label9.TabIndex = 11;
            this.Label9.Text = "Item 1:";
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(131, 57);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(110, 21);
            this.txtItem1.TabIndex = 2;
            this.txtItem1.TextChanged += new System.EventHandler(this.txtItem1_TextChanged);
            // 
            // txtItem4Qtd
            // 
            this.txtItem4Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem4Qtd.Location = new System.Drawing.Point(340, 129);
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
            this.txtItem3Qtd.Location = new System.Drawing.Point(340, 105);
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
            this.txtItem2Qtd.Location = new System.Drawing.Point(340, 81);
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
            this.Label6.Location = new System.Drawing.Point(87, 24);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 15);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "GP ID";
            // 
            // txtItem1Qtd
            // 
            this.txtItem1Qtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItem1Qtd.Location = new System.Drawing.Point(340, 57);
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
            this.txtTypeID.Location = new System.Drawing.Point(132, 21);
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(110, 21);
            this.txtTypeID.TabIndex = 0;
            this.txtTypeID.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // txtItemProdQtd
            // 
            this.txtItemProdQtd.Font = new System.Drawing.Font("Arial", 10F);
            this.txtItemProdQtd.Location = new System.Drawing.Point(339, 19);
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
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.imgEvent);
            this.GroupBox1.Controls.Add(this.imgMap);
            this.GroupBox1.Controls.Add(this.txtImage);
            this.GroupBox1.Controls.Add(this.label45);
            this.GroupBox1.Controls.Add(this.ckShot);
            this.GroupBox1.Controls.Add(this.ckNatural);
            this.GroupBox1.Controls.Add(this.txtNome);
            this.GroupBox1.Controls.Add(this.lbContNome);
            this.GroupBox1.Controls.Add(this.label18);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cbAba);
            this.GroupBox1.Controls.Add(this.ckAtivo);
            this.GroupBox1.Controls.Add(this.txtIndex);
            this.GroupBox1.Location = new System.Drawing.Point(4, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(521, 122);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // imgEvent
            // 
            this.imgEvent.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgEvent.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgEvent.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.bg_transparent;
            this.imgEvent.Location = new System.Drawing.Point(4, 10);
            this.imgEvent.Name = "imgEvent";
            this.imgEvent.Size = new System.Drawing.Size(119, 107);
            this.imgEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEvent.TabIndex = 22;
            this.imgEvent.TabStop = false;
            this.toolTip1.SetToolTip(this.imgEvent, "image event");
            // 
            // imgMap
            // 
            this.imgMap.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgMap.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgMap.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.bg_transparent;
            this.imgMap.Location = new System.Drawing.Point(443, 26);
            this.imgMap.Name = "imgMap";
            this.imgMap.Size = new System.Drawing.Size(65, 59);
            this.imgMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgMap.TabIndex = 21;
            this.imgMap.TabStop = false;
            this.toolTip1.SetToolTip(this.imgMap, "image map");
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(166, 43);
            this.txtImage.MaxLength = 64;
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(228, 21);
            this.txtImage.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtImage, "img for event");
            this.txtImage.TextChanged += new System.EventHandler(this.txtImage_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(124, 46);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(40, 15);
            this.label45.TabIndex = 19;
            this.label45.Text = "E-Img";
            // 
            // ckShot
            // 
            this.ckShot.AutoSize = true;
            this.ckShot.Location = new System.Drawing.Point(266, 96);
            this.ckShot.Name = "ckShot";
            this.ckShot.Size = new System.Drawing.Size(84, 19);
            this.ckShot.TabIndex = 17;
            this.ckShot.Text = "Shot Mode";
            this.ckShot.UseVisualStyleBackColor = true;
            // 
            // ckNatural
            // 
            this.ckNatural.AutoSize = true;
            this.ckNatural.Location = new System.Drawing.Point(266, 69);
            this.ckNatural.Name = "ckNatural";
            this.ckNatural.Size = new System.Drawing.Size(99, 19);
            this.ckNatural.TabIndex = 16;
            this.ckNatural.Text = "Natural Mode";
            this.ckNatural.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(166, 20);
            this.txtNome.MaxLength = 64;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(228, 21);
            this.txtNome.TabIndex = 12;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lbContNome
            // 
            this.lbContNome.AutoSize = true;
            this.lbContNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContNome.ForeColor = System.Drawing.Color.Gray;
            this.lbContNome.Location = new System.Drawing.Point(396, 24);
            this.lbContNome.Name = "lbContNome";
            this.lbContNome.Size = new System.Drawing.Size(28, 14);
            this.lbContNome.TabIndex = 13;
            this.lbContNome.Text = "0/64";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(123, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 15);
            this.label18.TabIndex = 14;
            this.label18.Text = "Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(130, 69);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Link";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(127, 95);
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
            this.cbAba.Location = new System.Drawing.Point(166, 91);
            this.cbAba.Name = "cbAba";
            this.cbAba.Size = new System.Drawing.Size(94, 23);
            this.cbAba.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbAba, "type, event, rookie, beginer, advance");
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.Location = new System.Drawing.Point(365, 69);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(57, 19);
            this.ckAtivo.TabIndex = 2;
            this.ckAtivo.Text = "Active";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(166, 66);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(94, 21);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TextChanged += new System.EventHandler(this.Alterou);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbTempoVenda);
            this.tabPage2.Controls.Add(this.GroupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 425);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "GrandPrix";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbTempoVenda
            // 
            this.gbTempoVenda.Controls.Add(this.label2);
            this.gbTempoVenda.Controls.Add(this.dtTermino);
            this.gbTempoVenda.Controls.Add(this.label5);
            this.gbTempoVenda.Controls.Add(this.dtInicio);
            this.gbTempoVenda.Controls.Add(this.dtAbre);
            this.gbTempoVenda.Controls.Add(this.Label28);
            this.gbTempoVenda.Controls.Add(this.label4);
            this.gbTempoVenda.Controls.Add(this.txtInfo);
            this.gbTempoVenda.Controls.Add(this.imgTicketID);
            this.gbTempoVenda.Location = new System.Drawing.Point(4, 245);
            this.gbTempoVenda.Name = "gbTempoVenda";
            this.gbTempoVenda.Size = new System.Drawing.Size(519, 178);
            this.gbTempoVenda.TabIndex = 25;
            this.gbTempoVenda.TabStop = false;
            this.gbTempoVenda.Text = "Config. Time and Others";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Text Info:";
            // 
            // dtTermino
            // 
            this.dtTermino.CustomFormat = "HH:MM:ss";
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTermino.Location = new System.Drawing.Point(43, 71);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(67, 20);
            this.dtTermino.TabIndex = 28;
            this.toolTip1.SetToolTip(this.dtTermino, "end grand room");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "End:";
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "HH:MM:ss";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(43, 45);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(67, 20);
            this.dtInicio.TabIndex = 26;
            this.toolTip1.SetToolTip(this.dtInicio, "init grand room");
            // 
            // dtAbre
            // 
            this.dtAbre.CustomFormat = "HH:MM:ss";
            this.dtAbre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAbre.Location = new System.Drawing.Point(43, 19);
            this.dtAbre.Name = "dtAbre";
            this.dtAbre.Size = new System.Drawing.Size(67, 20);
            this.dtAbre.TabIndex = 26;
            this.toolTip1.SetToolTip(this.dtAbre, "open grand room");
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(9, 48);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(32, 13);
            this.Label28.TabIndex = 10;
            this.Label28.Text = "Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Open:";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(172, 16);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(342, 154);
            this.txtInfo.TabIndex = 37;
            this.toolTip1.SetToolTip(this.txtInfo, "text info in game");
            // 
            // imgTicketID
            // 
            this.imgTicketID.BackgroundImage = global::Pangya_Modern_Editor.Properties.Resources.item_preview_bg;
            this.imgTicketID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgTicketID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgTicketID.ErrorImage = global::Pangya_Modern_Editor.Properties.Resources.ErrorImage;
            this.imgTicketID.InitialImage = global::Pangya_Modern_Editor.Properties.Resources.bg_transparent;
            this.imgTicketID.Location = new System.Drawing.Point(43, 97);
            this.imgTicketID.Name = "imgTicketID";
            this.imgTicketID.Size = new System.Drawing.Size(51, 53);
            this.imgTicketID.TabIndex = 39;
            this.imgTicketID.TabStop = false;
            this.toolTip1.SetToolTip(this.imgTicketID, "image ticket id enter");
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.label69);
            this.GroupBox5.Controls.Add(this.txtTrophyIDTree);
            this.GroupBox5.Controls.Add(this.label68);
            this.GroupBox5.Controls.Add(this.txtTrophyIDTwoo);
            this.GroupBox5.Controls.Add(this.label67);
            this.GroupBox5.Controls.Add(this.txtTrophyIDOne);
            this.GroupBox5.Controls.Add(this.label61);
            this.GroupBox5.Controls.Add(this.label62);
            this.GroupBox5.Controls.Add(this.label63);
            this.GroupBox5.Controls.Add(this.label64);
            this.GroupBox5.Controls.Add(this.label65);
            this.GroupBox5.Controls.Add(this.label66);
            this.GroupBox5.Controls.Add(this.label54);
            this.GroupBox5.Controls.Add(this.label55);
            this.GroupBox5.Controls.Add(this.label56);
            this.GroupBox5.Controls.Add(this.label57);
            this.GroupBox5.Controls.Add(this.label58);
            this.GroupBox5.Controls.Add(this.label59);
            this.GroupBox5.Controls.Add(this.label60);
            this.GroupBox5.Controls.Add(this.label52);
            this.GroupBox5.Controls.Add(this.label53);
            this.GroupBox5.Controls.Add(this.label50);
            this.GroupBox5.Controls.Add(this.label51);
            this.GroupBox5.Controls.Add(this.label33);
            this.GroupBox5.Controls.Add(this.label27);
            this.GroupBox5.Controls.Add(this.label19);
            this.GroupBox5.Controls.Add(this.cbMap);
            this.GroupBox5.Controls.Add(this.cbClass);
            this.GroupBox5.Controls.Add(this.txtCondition1);
            this.GroupBox5.Controls.Add(this.txtCondition0);
            this.GroupBox5.Controls.Add(this.txtLevelMax);
            this.GroupBox5.Controls.Add(this.txtLevelMin);
            this.GroupBox5.Controls.Add(this.txtRule);
            this.GroupBox5.Controls.Add(this.txtUn1);
            this.GroupBox5.Controls.Add(this.txtUn);
            this.GroupBox5.Controls.Add(this.txtClearGP);
            this.GroupBox5.Controls.Add(this.txtLocker);
            this.GroupBox5.Controls.Add(this.nmrPangReward);
            this.GroupBox5.Controls.Add(this.cbHoleSize);
            this.GroupBox5.Controls.Add(this.txt_Ticket_TypeID);
            this.GroupBox5.Controls.Add(this.txtTimeHole);
            this.GroupBox5.Controls.Add(this.txt_Ticket_Qntd);
            this.GroupBox5.Controls.Add(this.cbTotalHole);
            this.GroupBox5.Controls.Add(this.cbMode);
            this.GroupBox5.Controls.Add(this.txtScore1);
            this.GroupBox5.Controls.Add(this.txtScore2);
            this.GroupBox5.Controls.Add(this.txtScore3);
            this.GroupBox5.Location = new System.Drawing.Point(4, 3);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(518, 236);
            this.GroupBox5.TabIndex = 99;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Config General";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(0, 204);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(66, 13);
            this.label67.TabIndex = 103;
            this.label67.Text = "Trophy One:";
            // 
            // txtTrophyIDOne
            // 
            this.txtTrophyIDOne.Location = new System.Drawing.Point(67, 201);
            this.txtTrophyIDOne.Name = "txtTrophyIDOne";
            this.txtTrophyIDOne.Size = new System.Drawing.Size(88, 20);
            this.txtTrophyIDOne.TabIndex = 102;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(384, 157);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(49, 13);
            this.label61.TabIndex = 101;
            this.label61.Text = "Obj Un2:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(391, 131);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(43, 13);
            this.label62.TabIndex = 100;
            this.label62.Text = "Obj Un:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(373, 104);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(59, 13);
            this.label63.TabIndex = 99;
            this.label63.Text = "Level Max:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(374, 76);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(59, 13);
            this.label64.TabIndex = 98;
            this.label64.Text = "Level Req:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(385, 50);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(48, 13);
            this.label65.TabIndex = 97;
            this.label65.Text = "ID Clear:";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(387, 23);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(46, 13);
            this.label66.TabIndex = 96;
            this.label66.Text = "ID Rule:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(199, 178);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(55, 13);
            this.label54.TabIndex = 95;
            this.label54.Text = "AVG Max:";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(184, 152);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(69, 13);
            this.label55.TabIndex = 94;
            this.label55.Text = "Bot Score[2]:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(185, 129);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(69, 13);
            this.label56.TabIndex = 93;
            this.label56.Text = "Bot Score[1]:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(185, 104);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(69, 13);
            this.label57.TabIndex = 92;
            this.label57.Text = "Bot Score[0]:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(202, 79);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(53, 13);
            this.label58.TabIndex = 91;
            this.label58.Text = "GP Class:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(185, 52);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(68, 13);
            this.label59.TabIndex = 90;
            this.label59.Text = "Game Mode:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(210, 25);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(43, 13);
            this.label60.TabIndex = 89;
            this.label60.Text = "Course:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(12, 178);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(52, 13);
            this.label52.TabIndex = 88;
            this.label52.Text = "AVG Min:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(4, 155);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(62, 13);
            this.label53.TabIndex = 87;
            this.label53.Text = "Pangs Win:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(4, 128);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 13);
            this.label50.TabIndex = 86;
            this.label50.Text = "Ticket Qnt:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(10, 104);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(54, 13);
            this.label51.TabIndex = 85;
            this.label51.Text = "Ticket ID:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 77);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(58, 13);
            this.label33.TabIndex = 84;
            this.label33.Text = "Time Hole:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 50);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 13);
            this.label27.TabIndex = 83;
            this.label27.Text = "Total Hole:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "Hole Size:";
            // 
            // cbMap
            // 
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Items.AddRange(new object[] {
            "Blue Lagoon",
            "Blue Water",
            "Blue Moon",
            "Sepia Wind",
            "Wind Hill",
            "Wiz Wiz",
            "West Wiz",
            "Silva Canoon",
            "White Wiz",
            "Shining Sand",
            "Ice Canoon",
            "Pink Wind",
            "Deep Inferno",
            "Ice Spa",
            "Lost Seaway",
            "Eastern Valley",
            "Special Shuffle",
            "Ice Inferno",
            "Wiz City",
            "Abbot Mine",
            "Mystic Ruins",
            "Random"});
            this.cbMap.Location = new System.Drawing.Point(256, 21);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(88, 21);
            this.cbMap.TabIndex = 82;
            this.toolTip1.SetToolTip(this.cbMap, "map in grandprix room");
            this.cbMap.SelectedValueChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // cbClass
            // 
            this.cbClass.Location = new System.Drawing.Point(256, 75);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(88, 20);
            this.cbClass.TabIndex = 78;
            this.toolTip1.SetToolTip(this.cbClass, "class 1-9 grand room");
            // 
            // txtCondition1
            // 
            this.txtCondition1.Location = new System.Drawing.Point(256, 175);
            this.txtCondition1.Name = "txtCondition1";
            this.txtCondition1.Size = new System.Drawing.Size(88, 20);
            this.txtCondition1.TabIndex = 76;
            // 
            // txtCondition0
            // 
            this.txtCondition0.Location = new System.Drawing.Point(67, 175);
            this.txtCondition0.Name = "txtCondition0";
            this.txtCondition0.Size = new System.Drawing.Size(116, 20);
            this.txtCondition0.TabIndex = 74;
            // 
            // txtLevelMax
            // 
            this.txtLevelMax.Location = new System.Drawing.Point(435, 100);
            this.txtLevelMax.Name = "txtLevelMax";
            this.txtLevelMax.Size = new System.Drawing.Size(71, 20);
            this.txtLevelMax.TabIndex = 72;
            this.toolTip1.SetToolTip(this.txtLevelMax, "exemple: for Junior A");
            // 
            // txtLevelMin
            // 
            this.txtLevelMin.Location = new System.Drawing.Point(435, 73);
            this.txtLevelMin.Name = "txtLevelMin";
            this.txtLevelMin.Size = new System.Drawing.Size(71, 20);
            this.txtLevelMin.TabIndex = 70;
            this.toolTip1.SetToolTip(this.txtLevelMin, "exemple: for rookie A");
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(436, 19);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(70, 20);
            this.txtRule.TabIndex = 68;
            this.toolTip1.SetToolTip(this.txtRule, "rules in room");
            // 
            // txtUn1
            // 
            this.txtUn1.Location = new System.Drawing.Point(436, 154);
            this.txtUn1.Name = "txtUn1";
            this.txtUn1.Size = new System.Drawing.Size(70, 20);
            this.txtUn1.TabIndex = 64;
            // 
            // txtUn
            // 
            this.txtUn.Location = new System.Drawing.Point(437, 127);
            this.txtUn.Name = "txtUn";
            this.txtUn.Size = new System.Drawing.Size(69, 20);
            this.txtUn.TabIndex = 58;
            // 
            // txtClearGP
            // 
            this.txtClearGP.Location = new System.Drawing.Point(435, 46);
            this.txtClearGP.Name = "txtClearGP";
            this.txtClearGP.Size = new System.Drawing.Size(71, 20);
            this.txtClearGP.TabIndex = 56;
            // 
            // txtLocker
            // 
            this.txtLocker.AutoSize = true;
            this.txtLocker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtLocker.Location = new System.Drawing.Point(435, 180);
            this.txtLocker.Name = "txtLocker";
            this.txtLocker.Size = new System.Drawing.Size(78, 17);
            this.txtLocker.TabIndex = 20;
            this.txtLocker.Text = "Room Lock";
            this.txtLocker.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.txtLocker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.txtLocker, "locker or unlocker");
            this.txtLocker.UseVisualStyleBackColor = true;
            // 
            // nmrPangReward
            // 
            this.nmrPangReward.Location = new System.Drawing.Point(67, 151);
            this.nmrPangReward.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nmrPangReward.Name = "nmrPangReward";
            this.nmrPangReward.Size = new System.Drawing.Size(116, 20);
            this.nmrPangReward.TabIndex = 52;
            this.toolTip1.SetToolTip(this.nmrPangReward, "pangs get for play");
            // 
            // cbHoleSize
            // 
            this.cbHoleSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoleSize.FormattingEnabled = true;
            this.cbHoleSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cbHoleSize.Location = new System.Drawing.Point(67, 19);
            this.cbHoleSize.Name = "cbHoleSize";
            this.cbHoleSize.Size = new System.Drawing.Size(116, 21);
            this.cbHoleSize.TabIndex = 48;
            // 
            // txt_Ticket_TypeID
            // 
            this.txt_Ticket_TypeID.Location = new System.Drawing.Point(67, 100);
            this.txt_Ticket_TypeID.Name = "txt_Ticket_TypeID";
            this.txt_Ticket_TypeID.Size = new System.Drawing.Size(116, 20);
            this.txt_Ticket_TypeID.TabIndex = 33;
            this.toolTip1.SetToolTip(this.txt_Ticket_TypeID, "ticket id for enter room");
            // 
            // txtTimeHole
            // 
            this.txtTimeHole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTimeHole.FormattingEnabled = true;
            this.txtTimeHole.Items.AddRange(new object[] {
            "0",
            "90",
            "120",
            "180"});
            this.txtTimeHole.Location = new System.Drawing.Point(67, 73);
            this.txtTimeHole.Name = "txtTimeHole";
            this.txtTimeHole.Size = new System.Drawing.Size(116, 21);
            this.txtTimeHole.TabIndex = 81;
            // 
            // txt_Ticket_Qntd
            // 
            this.txt_Ticket_Qntd.Location = new System.Drawing.Point(67, 125);
            this.txt_Ticket_Qntd.Name = "txt_Ticket_Qntd";
            this.txt_Ticket_Qntd.Size = new System.Drawing.Size(116, 20);
            this.txt_Ticket_Qntd.TabIndex = 35;
            this.toolTip1.SetToolTip(this.txt_Ticket_Qntd, "qnty item for enter grand room");
            // 
            // cbTotalHole
            // 
            this.cbTotalHole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTotalHole.FormattingEnabled = true;
            this.cbTotalHole.Items.AddRange(new object[] {
            "3 Holes",
            "6 Holes",
            "9 Holes ",
            "12 Holes",
            "18 Holes"});
            this.cbTotalHole.Location = new System.Drawing.Point(67, 46);
            this.cbTotalHole.Name = "cbTotalHole";
            this.cbTotalHole.Size = new System.Drawing.Size(116, 21);
            this.cbTotalHole.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cbTotalHole, "total holes in grand room");
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "FRONT",
            "BACK",
            "RANDOM",
            "SHUFFLE",
            "REPEAT",
            "SHUFFLE_COURSE"});
            this.cbMode.Location = new System.Drawing.Point(256, 48);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(88, 21);
            this.cbMode.TabIndex = 30;
            this.toolTip1.SetToolTip(this.cbMode, "mode \'front, back, others\' grand room");
            // 
            // txtScore1
            // 
            this.txtScore1.Location = new System.Drawing.Point(256, 101);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(88, 20);
            this.txtScore1.TabIndex = 53;
            this.toolTip1.SetToolTip(this.txtScore1, "bot record min");
            // 
            // txtScore2
            // 
            this.txtScore2.Location = new System.Drawing.Point(256, 126);
            this.txtScore2.Name = "txtScore2";
            this.txtScore2.Size = new System.Drawing.Size(88, 20);
            this.txtScore2.TabIndex = 54;
            this.toolTip1.SetToolTip(this.txtScore2, "bot record medium");
            // 
            // txtScore3
            // 
            this.txtScore3.Location = new System.Drawing.Point(256, 149);
            this.txtScore3.Name = "txtScore3";
            this.txtScore3.Size = new System.Drawing.Size(88, 20);
            this.txtScore3.TabIndex = 55;
            this.toolTip1.SetToolTip(this.txtScore3, "bot record hard");
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
            this.btnReabrir.Location = new System.Drawing.Point(320, 14);
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
            this.btnNovo.Location = new System.Drawing.Point(20, 14);
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
            this.btnRemover.Location = new System.Drawing.Point(120, 14);
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
            this.btnBackup.Location = new System.Drawing.Point(220, 14);
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
            this.btnSalvar.Location = new System.Drawing.Point(420, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 48);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Update";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // ckTempoAtivo
            // 
            this.ckTempoAtivo.AutoSize = true;
            this.ckTempoAtivo.BackColor = System.Drawing.Color.Transparent;
            this.ckTempoAtivo.Enabled = false;
            this.ckTempoAtivo.Location = new System.Drawing.Point(21, 22);
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            this.ckTempoAtivo.Size = new System.Drawing.Size(83, 17);
            this.ckTempoAtivo.TabIndex = 29;
            this.ckTempoAtivo.Text = "Check Time";
            this.toolTip1.SetToolTip(this.ckTempoAtivo, "time  (automatic)");
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(214, 128);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 13);
            this.label35.TabIndex = 79;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(227, 177);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(0, 13);
            this.label48.TabIndex = 77;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(33, 178);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(0, 13);
            this.label49.TabIndex = 75;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(374, 104);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(0, 13);
            this.label46.TabIndex = 73;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(377, 76);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(0, 13);
            this.label47.TabIndex = 71;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(389, 23);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(0, 13);
            this.label44.TabIndex = 69;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(409, 158);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(0, 13);
            this.label43.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(410, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 59;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(384, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 57;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(229, 76);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 13);
            this.label42.TabIndex = 49;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(33, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(0, 13);
            this.label29.TabIndex = 34;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(30, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 13);
            this.label26.TabIndex = 32;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(28, 128);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(0, 13);
            this.label30.TabIndex = 36;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(233, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 13);
            this.label24.TabIndex = 27;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(28, 50);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 13);
            this.label34.TabIndex = 10;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(228, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 13);
            this.label25.TabIndex = 29;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(32, 23);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(0, 13);
            this.label41.TabIndex = 47;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(15, 155);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(0, 13);
            this.label40.TabIndex = 46;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(213, 150);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(0, 13);
            this.label32.TabIndex = 44;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(213, 103);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(0, 13);
            this.label38.TabIndex = 40;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(133, 35);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 13);
            this.label31.TabIndex = 38;
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
            this.diagSalvarArquivo.Title = "Save File GrandPrixData.iff";
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Open File (GrandPrixData.iff)";
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
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(188, 204);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(67, 13);
            this.label68.TabIndex = 105;
            this.label68.Text = "Trophy Two:";
            // 
            // txtTrophyIDTwoo
            // 
            this.txtTrophyIDTwoo.Location = new System.Drawing.Point(256, 201);
            this.txtTrophyIDTwoo.Name = "txtTrophyIDTwoo";
            this.txtTrophyIDTwoo.Size = new System.Drawing.Size(88, 20);
            this.txtTrophyIDTwoo.TabIndex = 104;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(350, 204);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(68, 13);
            this.label69.TabIndex = 107;
            this.label69.Text = "Trophy Tree:";
            // 
            // txtTrophyIDTree
            // 
            this.txtTrophyIDTree.Location = new System.Drawing.Point(421, 201);
            this.txtTrophyIDTree.Name = "txtTrophyIDTree";
            this.txtTrophyIDTree.Size = new System.Drawing.Size(88, 20);
            this.txtTrophyIDTree.TabIndex = 106;
            // 
            // FrmGrandPrixData
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
            this.Name = "FrmGrandPrixData";
            this.Text = "GrandPrixData - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmGrandPrixData_Load);
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
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMap)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTicketID)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPangReward)).EndInit();
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

        [AccessedThroughProperty("PictureBox4")]
        private PictureBox PictureBox4;

        [AccessedThroughProperty("Label36")]
        private Label Label36;

        public string Arquivo;

        private GrandPrixData oIff;
        private bool sfile;
        public IFFFile<GrandPrixData> lsItens;

        public IFFFile<GrandPrixData> lsTemp;

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
        private ToolStripButton btnAbrirArquivo;
        private ToolStripButton menuSalvarComo;
        private ToolStrip ToolStrip1;
        private BackgroundWorker bwSalvar;
        private ToolStripButton menuBackup;
        private PictureBox pictureBox9;
        private PictureBox pictureBox5;
        private ToolTip toolTip1;
        private TabControl tabForm;
        private TabPage TabPage1;
        private GroupBox GroupBox2;
        private TextBox textBox2;
        private PictureBox pictureBox8;
        private TextBox txtRes4;
        private TextBox txtRes3;
        private TextBox txtRes2;
        private TextBox txtRes1;
        private PictureBox img4;
        private PictureBox img3;
        private PictureBox img2;
        private PictureBox img1;
        private GroupBox GroupBox3;
        private Label label8;
        private Label label23;
        private TextBox txtItem5;
        private NumericUpDown txtItem5Qtd;
        private Label Label16;
        private Label Label14;
        private Label Label12;
        private Label Label10;
        private Label Label7;
        private Label Label15;
        private Label Label13;
        private Label Label11;
        private TextBox txtItem4;
        private TextBox txtItem3;
        private TextBox txtItem2;
        private Label Label9;
        private TextBox txtItem1;
        private NumericUpDown txtItem4Qtd;
        private NumericUpDown txtItem3Qtd;
        private NumericUpDown txtItem2Qtd;
        private Label Label6;
        private NumericUpDown txtItem1Qtd;
        private TextBox txtTypeID;
        private NumericUpDown txtItemProdQtd;
        private GroupBox GroupBox1;
        private PictureBox imgEvent;
        private Label Label1;
        private Label Label3;
        private ComboBox cbAba;
        private CheckBox ckAtivo;
        private TextBox txtIndex;
        private PictureBox imgMap;
        private CheckBox txtLocker;
        private TextBox txtImage;
        private Label label45;
        private CheckBox ckShot;
        private CheckBox ckNatural;
        private TextBox txtNome;
        private Label lbContNome;
        private Label label18;
        private TabPage tabPage2;
        private GroupBox GroupBox5;
        private Label label38;
        private Label label32;
        private Label label40;
        private Label label41;
        private Label label25;
        private ComboBox cbMode;
        private Label label34;
        private ComboBox cbTotalHole;
        private Label label24;
        private Label label30;
        private Label label26;
        private TextBox txt_Ticket_Qntd;
        private Label label29;
        private TextBox txt_Ticket_TypeID;
        private ComboBox cbHoleSize;
        private NumericUpDown nmrPangReward;
        private TextBox txtScore3;
        private Label label42;
        private TextBox txtScore1;
        private TextBox txtScore2;
        private Label label20;
        private TextBox txtClearGP;
        private Label label17;
        private TextBox txtUn;
        private Label label43;
        private TextBox txtUn1;
        private Label label44;
        private TextBox txtRule;
        private Label label47;
        private TextBox txtLevelMin;
        private Label label46;
        private TextBox txtLevelMax;
        private Label label49;
        private TextBox txtCondition0;
        private Label label48;
        private TextBox txtCondition1;
        private TextBox cbClass;
        private Label label35;
        private ComboBox txtTimeHole;
        private ComboBox cbMap;
        private Label label31;
        private TextBox txtInfo;
        private Label label4;
        private Label Label28;
        private DateTimePicker dtAbre;
        private DateTimePicker dtInicio;
        private Label label5;
        private DateTimePicker dtTermino;
        private CheckBox ckTempoAtivo;
        private PictureBox imgTicketID;
        private GroupBox gbTempoVenda;
        private Label label2;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label60;
        private Label label52;
        private Label label53;
        private Label label50;
        private Label label51;
        private Label label33;
        private Label label27;
        private Label label19;
        private Label label67;
        private TextBox txtTrophyIDOne;
        private Label label69;
        private TextBox txtTrophyIDTree;
        private Label label68;
        private TextBox txtTrophyIDTwoo;
    }
}