using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class FrmPakEditor
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "SubName",
            "SubSize",
            "SubPacked"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPakEditor));
            this.txtBox_LocalPak = new System.Windows.Forms.TextBox();
            this.diagAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.HeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderPacked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newPakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.convertToPakFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lbFile_xtea = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox_LocalPak
            // 
            this.txtBox_LocalPak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_LocalPak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_LocalPak.Location = new System.Drawing.Point(30, 40);
            this.txtBox_LocalPak.Name = "txtBox_LocalPak";
            this.txtBox_LocalPak.ReadOnly = true;
            this.txtBox_LocalPak.Size = new System.Drawing.Size(770, 20);
            this.txtBox_LocalPak.TabIndex = 3;
            // 
            // diagAbrirArquivo
            // 
            this.diagAbrirArquivo.FileName = "ProjectG*.pak";
            this.diagAbrirArquivo.Title = "Pangya Pak File Manager";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HeaderName,
            this.HeaderSize,
            this.HeaderPacked});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(0, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 364);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.listView1_ColumnReordered);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // HeaderName
            // 
            this.HeaderName.Text = "Name";
            this.HeaderName.Width = 322;
            // 
            // HeaderSize
            // 
            this.HeaderSize.Text = "Size";
            this.HeaderSize.Width = 57;
            // 
            // HeaderPacked
            // 
            this.HeaderPacked.Text = "Packed Size";
            this.HeaderPacked.Width = 83;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 25);
            this.button1.TabIndex = 4;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.newPakToolStripMenuItem,
            this.toolStripSeparator2,
            this.convertToPakFileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.btnAbrir_Image;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "&Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // newPakToolStripMenuItem
            // 
            this.newPakToolStripMenuItem.Name = "newPakToolStripMenuItem";
            this.newPakToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newPakToolStripMenuItem.Text = "&New Pak";
            this.newPakToolStripMenuItem.Click += new System.EventHandler(this.newPakToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // convertToPakFileToolStripMenuItem
            // 
            this.convertToPakFileToolStripMenuItem.Name = "convertToPakFileToolStripMenuItem";
            this.convertToPakFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertToPakFileToolStripMenuItem.Text = "&Update PakFile";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalhesToolStripMenuItem,
            this.listaToolStripMenuItem,
            this.tileToolStripMenuItem});
            this.viewToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.search_plus;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // detalhesToolStripMenuItem
            // 
            this.detalhesToolStripMenuItem.Name = "detalhesToolStripMenuItem";
            this.detalhesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detalhesToolStripMenuItem.Text = "Detalhes";
            this.detalhesToolStripMenuItem.Click += new System.EventHandler(this.detalhesToolStripMenuItem_Click);
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaToolStripMenuItem.Text = "Lista";
            this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // encodingToolStripMenuItem
            // 
            this.encodingToolStripMenuItem.Name = "encodingToolStripMenuItem";
            this.encodingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.encodingToolStripMenuItem.Text = "Encoding";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(180, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lbFile_xtea
            // 
            this.lbFile_xtea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFile_xtea.AutoSize = true;
            this.lbFile_xtea.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFile_xtea.Location = new System.Drawing.Point(684, 434);
            this.lbFile_xtea.Name = "lbFile_xtea";
            this.lbFile_xtea.Size = new System.Drawing.Size(52, 14);
            this.lbFile_xtea.TabIndex = 8;
            this.lbFile_xtea.Text = "XTEA File";
            // 
            // FrmPakEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbFile_xtea);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBox_LocalPak);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPakEditor";
            this.Text = "PangYa Pak Maker";
            this.MaximumSizeChanged += new System.EventHandler(this.FrmPakEditor_MaximumSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBox_LocalPak;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog diagAbrirArquivo;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader HeaderSize;
        private System.Windows.Forms.ColumnHeader HeaderPacked;
        private ToolStripMenuItem setItemStatusToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem newPakToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem convertToPakFileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem detalhesToolStripMenuItem;
        private ToolStripMenuItem listaToolStripMenuItem;
        private ToolStripMenuItem tileToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem encodingToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Label lbFile_xtea;
        private ColumnHeader HeaderName;
    }
}

