using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    partial class FrmSetEffectTable
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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.ListaItem = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddPower = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbType2 = new System.Windows.Forms.ComboBox();
            this.cbType3 = new System.Windows.Forms.ComboBox();
            this.nrSlot5 = new System.Windows.Forms.NumericUpDown();
            this.nrSlot4 = new System.Windows.Forms.NumericUpDown();
            this.nrSlot3 = new System.Windows.Forms.NumericUpDown();
            this.nrSlot2 = new System.Windows.Forms.NumericUpDown();
            this.nrSlot1 = new System.Windows.Forms.NumericUpDown();
            this.Label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEffect = new System.Windows.Forms.ComboBox();
            this.cbEffect3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbEffect2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ckItem5 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItem5 = new System.Windows.Forms.TextBox();
            this.ckItem4 = new System.Windows.Forms.CheckBox();
            this.ckItem3 = new System.Windows.Forms.CheckBox();
            this.ckItem2 = new System.Windows.Forms.CheckBox();
            this.ckItem1 = new System.Windows.Forms.CheckBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtItem4 = new System.Windows.Forms.TextBox();
            this.txtItem3 = new System.Windows.Forms.TextBox();
            this.txtItem2 = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtItem1 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.gbBotoes = new System.Windows.Forms.GroupBox();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblSearchCount = new System.Windows.Forms.Label();
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
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot1)).BeginInit();
            this.GroupBox2.SuspendLayout();
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 572);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(895, 22);
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
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(604, 17);
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
            this.menuSalvarComo});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(895, 40);
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
            this.SplitContainer1.Size = new System.Drawing.Size(895, 532);
            this.SplitContainer1.SplitterDistance = 305;
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
            this.Panel3.Size = new System.Drawing.Size(305, 505);
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
            this.ListaItem.Size = new System.Drawing.Size(305, 478);
            this.ListaItem.TabIndex = 1;
            this.ListaItem.SelectionChanged += new System.EventHandler(this.listaItem_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 478);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(305, 27);
            this.Panel1.TabIndex = 2;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Controls.Add(this.lbArquivo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(305, 27);
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
            this.lbArquivo.Size = new System.Drawing.Size(103, 16);
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "SetEffectTable.iff";
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Panel4.Size = new System.Drawing.Size(582, 526);
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
            this.tabForm.Size = new System.Drawing.Size(572, 450);
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
            this.TabPage1.Size = new System.Drawing.Size(564, 424);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Basic Info";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.groupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Location = new System.Drawing.Point(4, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(554, 237);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Effect Add P.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddPower
            // 
            this.txtAddPower.Location = new System.Drawing.Point(95, 41);
            this.txtAddPower.Name = "txtAddPower";
            this.txtAddPower.Size = new System.Drawing.Size(137, 21);
            this.txtAddPower.TabIndex = 44;
            this.toolTip1.SetToolTip(this.txtAddPower, "Index conected with Item.iff");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbType);
            this.groupBox3.Controls.Add(this.cbType2);
            this.groupBox3.Controls.Add(this.cbType3);
            this.groupBox3.Controls.Add(this.nrSlot5);
            this.groupBox3.Controls.Add(this.nrSlot4);
            this.groupBox3.Controls.Add(this.nrSlot3);
            this.groupBox3.Controls.Add(this.nrSlot2);
            this.groupBox3.Controls.Add(this.nrSlot1);
            this.groupBox3.Controls.Add(this.Label16);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbEffect);
            this.groupBox3.Controls.Add(this.cbEffect3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cbEffect2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(272, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 199);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Config Effect";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "NONE",
            "UNKNOWN_V1",
            "GAME",
            "ROOM",
            "LOUNGE"});
            this.cbType.Location = new System.Drawing.Point(95, 45);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(98, 22);
            this.cbType.TabIndex = 49;
            // 
            // cbType2
            // 
            this.cbType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbType2.FormattingEnabled = true;
            this.cbType2.Items.AddRange(new object[] {
            "NONE",
            "UNKNOWN_V1",
            "GAME",
            "ROOM",
            "LOUNGE"});
            this.cbType2.Location = new System.Drawing.Point(95, 107);
            this.cbType2.Name = "cbType2";
            this.cbType2.Size = new System.Drawing.Size(98, 22);
            this.cbType2.TabIndex = 48;
            // 
            // cbType3
            // 
            this.cbType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbType3.FormattingEnabled = true;
            this.cbType3.Items.AddRange(new object[] {
            "NONE",
            "UNKNOWN_V1",
            "GAME",
            "ROOM",
            "LOUNGE"});
            this.cbType3.Location = new System.Drawing.Point(95, 171);
            this.cbType3.Name = "cbType3";
            this.cbType3.Size = new System.Drawing.Size(98, 22);
            this.cbType3.TabIndex = 47;
            // 
            // nrSlot5
            // 
            this.nrSlot5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nrSlot5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrSlot5.Location = new System.Drawing.Point(218, 138);
            this.nrSlot5.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrSlot5.Name = "nrSlot5";
            this.nrSlot5.Size = new System.Drawing.Size(44, 21);
            this.nrSlot5.TabIndex = 46;
            this.nrSlot5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nrSlot4
            // 
            this.nrSlot4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nrSlot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrSlot4.Location = new System.Drawing.Point(218, 113);
            this.nrSlot4.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrSlot4.Name = "nrSlot4";
            this.nrSlot4.Size = new System.Drawing.Size(44, 21);
            this.nrSlot4.TabIndex = 45;
            this.nrSlot4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nrSlot3
            // 
            this.nrSlot3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nrSlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrSlot3.Location = new System.Drawing.Point(218, 88);
            this.nrSlot3.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrSlot3.Name = "nrSlot3";
            this.nrSlot3.Size = new System.Drawing.Size(44, 21);
            this.nrSlot3.TabIndex = 44;
            this.nrSlot3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nrSlot2
            // 
            this.nrSlot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nrSlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrSlot2.Location = new System.Drawing.Point(218, 63);
            this.nrSlot2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrSlot2.Name = "nrSlot2";
            this.nrSlot2.Size = new System.Drawing.Size(44, 21);
            this.nrSlot2.TabIndex = 43;
            this.nrSlot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nrSlot1
            // 
            this.nrSlot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nrSlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrSlot1.Location = new System.Drawing.Point(218, 39);
            this.nrSlot1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nrSlot1.Name = "nrSlot1";
            this.nrSlot1.Size = new System.Drawing.Size(44, 21);
            this.nrSlot1.TabIndex = 42;
            this.nrSlot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(218, 23);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(28, 15);
            this.Label16.TabIndex = 41;
            this.Label16.Text = "Slot";
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
            // cbEffect
            // 
            this.cbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEffect.FormattingEnabled = true;
            this.cbEffect.Items.AddRange(new object[] {
            "ANIMATION",
            "UNKNOWN_V2",
            "CUTIN",
            "PIXEL",
            "BASE",
            "ONE_ALL_STAT",
            "WIND_DECREASE",
            "PATINHA"});
            this.cbEffect.Location = new System.Drawing.Point(95, 15);
            this.cbEffect.Name = "cbEffect";
            this.cbEffect.Size = new System.Drawing.Size(110, 22);
            this.cbEffect.TabIndex = 35;
            // 
            // cbEffect3
            // 
            this.cbEffect3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffect3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbEffect3.FormattingEnabled = true;
            this.cbEffect3.Items.AddRange(new object[] {
            "ANIMATION",
            "UNKNOWN_V2",
            "CUTIN",
            "PIXEL",
            "BASE",
            "ONE_ALL_STAT",
            "WIND_DECREASE",
            "PATINHA"});
            this.cbEffect3.Location = new System.Drawing.Point(95, 142);
            this.cbEffect3.Name = "cbEffect3";
            this.cbEffect3.Size = new System.Drawing.Size(110, 22);
            this.cbEffect3.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Effect Nº 2";
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
            // cbEffect2
            // 
            this.cbEffect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffect2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cbEffect2.FormattingEnabled = true;
            this.cbEffect2.Items.AddRange(new object[] {
            "ANIMATION",
            "UNKNOWN_V2",
            "CUTIN",
            "PIXEL",
            "BASE",
            "ONE_ALL_STAT",
            "WIND_DECREASE",
            "PATINHA"});
            this.cbEffect2.Location = new System.Drawing.Point(95, 79);
            this.cbEffect2.Name = "cbEffect2";
            this.cbEffect2.Size = new System.Drawing.Size(110, 22);
            this.cbEffect2.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Type";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.ckItem5);
            this.GroupBox2.Controls.Add(this.txtAddPower);
            this.GroupBox2.Controls.Add(this.label7);
            this.GroupBox2.Controls.Add(this.txtItem5);
            this.GroupBox2.Controls.Add(this.ckItem4);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.ckItem3);
            this.GroupBox2.Controls.Add(this.txtIndex);
            this.GroupBox2.Controls.Add(this.ckItem2);
            this.GroupBox2.Controls.Add(this.ckItem1);
            this.GroupBox2.Controls.Add(this.Label15);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.txtItem4);
            this.GroupBox2.Controls.Add(this.txtItem3);
            this.GroupBox2.Controls.Add(this.txtItem2);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.txtItem1);
            this.GroupBox2.Location = new System.Drawing.Point(15, 20);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(245, 199);
            this.GroupBox2.TabIndex = 19;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Item";
            // 
            // ckItem5
            // 
            this.ckItem5.AutoSize = true;
            this.ckItem5.Location = new System.Drawing.Point(175, 169);
            this.ckItem5.Name = "ckItem5";
            this.ckItem5.Size = new System.Drawing.Size(57, 19);
            this.ckItem5.TabIndex = 34;
            this.ckItem5.Text = "Active";
            this.ckItem5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Item 5";
            // 
            // txtItem5
            // 
            this.txtItem5.Location = new System.Drawing.Point(81, 167);
            this.txtItem5.Name = "txtItem5";
            this.txtItem5.Size = new System.Drawing.Size(88, 21);
            this.txtItem5.TabIndex = 32;
            // 
            // ckItem4
            // 
            this.ckItem4.AutoSize = true;
            this.ckItem4.Location = new System.Drawing.Point(175, 144);
            this.ckItem4.Name = "ckItem4";
            this.ckItem4.Size = new System.Drawing.Size(57, 19);
            this.ckItem4.TabIndex = 31;
            this.ckItem4.Text = "Active";
            this.ckItem4.UseVisualStyleBackColor = true;
            // 
            // ckItem3
            // 
            this.ckItem3.AutoSize = true;
            this.ckItem3.Location = new System.Drawing.Point(175, 122);
            this.ckItem3.Name = "ckItem3";
            this.ckItem3.Size = new System.Drawing.Size(57, 19);
            this.ckItem3.TabIndex = 30;
            this.ckItem3.Text = "Active";
            this.ckItem3.UseVisualStyleBackColor = true;
            // 
            // ckItem2
            // 
            this.ckItem2.AutoSize = true;
            this.ckItem2.Location = new System.Drawing.Point(175, 97);
            this.ckItem2.Name = "ckItem2";
            this.ckItem2.Size = new System.Drawing.Size(57, 19);
            this.ckItem2.TabIndex = 29;
            this.ckItem2.Text = "Active";
            this.ckItem2.UseVisualStyleBackColor = true;
            // 
            // ckItem1
            // 
            this.ckItem1.AutoSize = true;
            this.ckItem1.Location = new System.Drawing.Point(175, 70);
            this.ckItem1.Name = "ckItem1";
            this.ckItem1.Size = new System.Drawing.Size(57, 19);
            this.ckItem1.TabIndex = 28;
            this.ckItem1.Text = "Active";
            this.ckItem1.UseVisualStyleBackColor = true;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(34, 144);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(41, 15);
            this.Label15.TabIndex = 24;
            this.Label15.Text = "Item 4";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(34, 121);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(41, 15);
            this.Label13.TabIndex = 25;
            this.Label13.Text = "Item 3";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(34, 100);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(41, 15);
            this.Label11.TabIndex = 26;
            this.Label11.Text = "Item 2";
            // 
            // txtItem4
            // 
            this.txtItem4.Location = new System.Drawing.Point(81, 142);
            this.txtItem4.Name = "txtItem4";
            this.txtItem4.Size = new System.Drawing.Size(88, 21);
            this.txtItem4.TabIndex = 23;
            // 
            // txtItem3
            // 
            this.txtItem3.Location = new System.Drawing.Point(81, 118);
            this.txtItem3.Name = "txtItem3";
            this.txtItem3.Size = new System.Drawing.Size(88, 21);
            this.txtItem3.TabIndex = 22;
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(81, 94);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(88, 21);
            this.txtItem2.TabIndex = 21;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(34, 74);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(41, 15);
            this.Label9.TabIndex = 27;
            this.Label9.Text = "Item 1";
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(81, 70);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(88, 21);
            this.txtItem1.TabIndex = 20;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(53, 17);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(36, 15);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Index";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(95, 14);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(137, 21);
            this.txtIndex.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtIndex, "Index conected with Item.iff");
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
            this.gbBotoes.Location = new System.Drawing.Point(5, 453);
            this.gbBotoes.Name = "gbBotoes";
            this.gbBotoes.Size = new System.Drawing.Size(572, 70);
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
            this.btnReabrir.Location = new System.Drawing.Point(339, 14);
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
            this.btnNovo.Location = new System.Drawing.Point(39, 14);
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
            this.btnRemover.Location = new System.Drawing.Point(139, 14);
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
            this.btnBackup.Location = new System.Drawing.Point(239, 14);
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
            this.btnSalvar.Location = new System.Drawing.Point(439, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 48);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Update";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            this.PictureBox4.Location = new System.Drawing.Point(494, 49);
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
            this.PictureBox1.Location = new System.Drawing.Point(297, 49);
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
            this.imgPersonagem.Location = new System.Drawing.Point(555, 49);
            this.imgPersonagem.Name = "imgPersonagem";
            this.imgPersonagem.Size = new System.Drawing.Size(35, 35);
            this.imgPersonagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 1;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            // 
            // FrmSetEffectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 594);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.lblSearchCount);
            this.Controls.Add(this.imgPersonagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MaximizeBox = false;
            this.Name = "FrmSetEffectTable";
            this.Text = "SetEffectTable - Editor IFF ";
            this.Load += new System.EventHandler(this.FrmSetEffectTable_Load);
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
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrSlot1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
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

        //[AccessedThroughProperty("lblSearchCount")]
        private Label lblSearchCount;

        //[AccessedThroughProperty("Label36")]
        private Label Label36;

        //[AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;

        public string Arquivo;

        public IFFFile<SetEffectTable> lsItens;

        public IFFFile<SetEffectTable> lsTemp;
                                         
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
        private ToolTip toolTip1;
        private Label Label6;
        private TextBox txtIndex;
        private GroupBox GroupBox2;
        private Label Label15;
        private Label Label13;
        private Label Label11;
        private TextBox txtItem4;
        private TextBox txtItem3;
        private TextBox txtItem2;
        private Label Label9;
        private TextBox txtItem1;
        private Label label1;
        private TextBox txtAddPower;
        private GroupBox groupBox3;
        private Label label5;
        private ComboBox cbEffect;
        private ComboBox cbEffect3;
        private Label label8;
        private Label label2;
        private Label label14;
        private ComboBox cbEffect2;
        private Label label3;
        private Label label10;
        private NumericUpDown nrSlot5;
        private NumericUpDown nrSlot4;
        private NumericUpDown nrSlot3;
        private NumericUpDown nrSlot2;
        private NumericUpDown nrSlot1;
        private Label Label16;
        private ComboBox cbType;
        private ComboBox cbType2;
        private ComboBox cbType3;
        private CheckBox ckItem5;
        private Label label7;
        private TextBox txtItem5;
        private CheckBox ckItem4;
        private CheckBox ckItem3;
        private CheckBox ckItem2;
        private CheckBox ckItem1;
    }
}