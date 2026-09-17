using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PangyaSuiteFiles
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnPartEditor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnAuxPart = new System.Windows.Forms.Button();
            this.BtnClub = new System.Windows.Forms.Button();
            this.BtnHairStyle = new System.Windows.Forms.Button();
            this.BtnCharacter = new System.Windows.Forms.Button();
            this.BtnDescEditor = new System.Windows.Forms.Button();
            this.BtnMascotEditor = new System.Windows.Forms.Button();
            this.BtnSkinEditor = new System.Windows.Forms.Button();
            this.BtnCaddieItemEditor = new System.Windows.Forms.Button();
            this.BtnCaddieEditor = new System.Windows.Forms.Button();
            this.BtnBallEditor = new System.Windows.Forms.Button();
            this.BtnClubSetEditor = new System.Windows.Forms.Button();
            this.BtnCardEditor = new System.Windows.Forms.Button();
            this.BtnSetItemEditor = new System.Windows.Forms.Button();
            this.BtnItemEditor = new System.Windows.Forms.Button();
            this.BtnMemorialEditor = new System.Windows.Forms.Button();
            this.BtnAbil = new System.Windows.Forms.Button();
            this.BtnCauldronRandomEditor = new System.Windows.Forms.Button();
            this.BtnCauldron = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveIFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLoadIFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ON_LoadIFF = new System.Windows.Forms.ToolStripMenuItem();
            this.OFF_LoadIFF = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeDevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnGrandPrixEditor = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnWikipedia = new System.Windows.Forms.Button();
            this.BtnGGEditor = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.BtnCreateOrExtractPak = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPartEditor
            // 
            this.BtnPartEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_44;
            this.BtnPartEditor.Location = new System.Drawing.Point(6, 19);
            this.BtnPartEditor.Name = "BtnPartEditor";
            this.BtnPartEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnPartEditor.TabIndex = 1;
            this.BtnPartEditor.Text = "Part.iff";
            this.BtnPartEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPartEditor.UseVisualStyleBackColor = true;
            this.BtnPartEditor.Click += new System.EventHandler(this.BtnPartEditor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.BtnAuxPart);
            this.groupBox1.Controls.Add(this.BtnClub);
            this.groupBox1.Controls.Add(this.BtnHairStyle);
            this.groupBox1.Controls.Add(this.BtnCharacter);
            this.groupBox1.Controls.Add(this.BtnDescEditor);
            this.groupBox1.Controls.Add(this.BtnMascotEditor);
            this.groupBox1.Controls.Add(this.BtnSkinEditor);
            this.groupBox1.Controls.Add(this.BtnCaddieItemEditor);
            this.groupBox1.Controls.Add(this.BtnCaddieEditor);
            this.groupBox1.Controls.Add(this.BtnBallEditor);
            this.groupBox1.Controls.Add(this.BtnClubSetEditor);
            this.groupBox1.Controls.Add(this.BtnCardEditor);
            this.groupBox1.Controls.Add(this.BtnSetItemEditor);
            this.groupBox1.Controls.Add(this.BtnItemEditor);
            this.groupBox1.Controls.Add(this.BtnPartEditor);
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 256);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Editor IFF";
            // 
            // BtnAuxPart
            // 
            this.BtnAuxPart.Image = global::PangyaSuiteFiles.Properties.Resources.icon_auxpart;
            this.BtnAuxPart.Location = new System.Drawing.Point(264, 96);
            this.BtnAuxPart.Name = "BtnAuxPart";
            this.BtnAuxPart.Size = new System.Drawing.Size(84, 71);
            this.BtnAuxPart.TabIndex = 39;
            this.BtnAuxPart.Text = "AuxPart.iff";
            this.BtnAuxPart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAuxPart.UseVisualStyleBackColor = true;
            this.BtnAuxPart.Click += new System.EventHandler(this.BtnAuxPart_Click);
            // 
            // BtnClub
            // 
            this.BtnClub.Image = global::PangyaSuiteFiles.Properties.Resources.ico_18;
            this.BtnClub.Location = new System.Drawing.Point(350, 19);
            this.BtnClub.Name = "BtnClub";
            this.BtnClub.Size = new System.Drawing.Size(84, 71);
            this.BtnClub.TabIndex = 38;
            this.BtnClub.Text = "Club.iff";
            this.BtnClub.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClub.UseVisualStyleBackColor = true;
            this.BtnClub.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnHairStyle
            // 
            this.BtnHairStyle.BackColor = System.Drawing.Color.Transparent;
            this.BtnHairStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnHairStyle.Image = global::PangyaSuiteFiles.Properties.Resources._1;
            this.BtnHairStyle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnHairStyle.Location = new System.Drawing.Point(178, 96);
            this.BtnHairStyle.Name = "BtnHairStyle";
            this.BtnHairStyle.Size = new System.Drawing.Size(84, 71);
            this.BtnHairStyle.TabIndex = 37;
            this.BtnHairStyle.Text = "HairStyle.iff";
            this.BtnHairStyle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnHairStyle.UseVisualStyleBackColor = false;
            this.BtnHairStyle.Click += new System.EventHandler(this.BtnHairStyle_Click);
            // 
            // BtnCharacter
            // 
            this.BtnCharacter.Image = global::PangyaSuiteFiles.Properties.Resources.list_arthur;
            this.BtnCharacter.Location = new System.Drawing.Point(5, 173);
            this.BtnCharacter.Name = "BtnCharacter";
            this.BtnCharacter.Size = new System.Drawing.Size(84, 71);
            this.BtnCharacter.TabIndex = 36;
            this.BtnCharacter.Text = "Character.iff";
            this.BtnCharacter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCharacter.UseVisualStyleBackColor = true;
            this.BtnCharacter.Click += new System.EventHandler(this.BtnAuxPartEditor_Click);
            // 
            // BtnDescEditor
            // 
            this.BtnDescEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.BtnDescEditor.Location = new System.Drawing.Point(91, 173);
            this.BtnDescEditor.Name = "BtnDescEditor";
            this.BtnDescEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnDescEditor.TabIndex = 33;
            this.BtnDescEditor.Text = "Desc.iff";
            this.BtnDescEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDescEditor.UseVisualStyleBackColor = true;
            this.BtnDescEditor.Click += new System.EventHandler(this.BtnDescEditor_Click);
            // 
            // BtnMascotEditor
            // 
            this.BtnMascotEditor.Image = global::PangyaSuiteFiles.Properties.Resources.mascot_02;
            this.BtnMascotEditor.Location = new System.Drawing.Point(264, 173);
            this.BtnMascotEditor.Name = "BtnMascotEditor";
            this.BtnMascotEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnMascotEditor.TabIndex = 32;
            this.BtnMascotEditor.Text = "Mascot.iff";
            this.BtnMascotEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMascotEditor.UseVisualStyleBackColor = true;
            this.BtnMascotEditor.Click += new System.EventHandler(this.BtnMascotEditor_Click);
            // 
            // BtnSkinEditor
            // 
            this.BtnSkinEditor.Image = global::PangyaSuiteFiles.Properties.Resources._2;
            this.BtnSkinEditor.Location = new System.Drawing.Point(178, 173);
            this.BtnSkinEditor.Name = "BtnSkinEditor";
            this.BtnSkinEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnSkinEditor.TabIndex = 31;
            this.BtnSkinEditor.Text = "Skin.iff";
            this.BtnSkinEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSkinEditor.UseVisualStyleBackColor = true;
            this.BtnSkinEditor.Click += new System.EventHandler(this.BtnSkinEditor_Click);
            // 
            // BtnCaddieItemEditor
            // 
            this.BtnCaddieItemEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_19;
            this.BtnCaddieItemEditor.Location = new System.Drawing.Point(350, 173);
            this.BtnCaddieItemEditor.Name = "BtnCaddieItemEditor";
            this.BtnCaddieItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCaddieItemEditor.TabIndex = 30;
            this.BtnCaddieItemEditor.Text = "CaddieItem.iff";
            this.BtnCaddieItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCaddieItemEditor.UseVisualStyleBackColor = true;
            this.BtnCaddieItemEditor.Click += new System.EventHandler(this.BtnCaddieItemEditor_Click);
            // 
            // BtnCaddieEditor
            // 
            this.BtnCaddieEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_19;
            this.BtnCaddieEditor.Location = new System.Drawing.Point(350, 96);
            this.BtnCaddieEditor.Name = "BtnCaddieEditor";
            this.BtnCaddieEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCaddieEditor.TabIndex = 29;
            this.BtnCaddieEditor.Text = "Caddie.iff";
            this.BtnCaddieEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCaddieEditor.UseVisualStyleBackColor = true;
            this.BtnCaddieEditor.Click += new System.EventHandler(this.BtnCaddieEditor_Click);
            // 
            // BtnBallEditor
            // 
            this.BtnBallEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ball_03;
            this.BtnBallEditor.Location = new System.Drawing.Point(91, 96);
            this.BtnBallEditor.Name = "BtnBallEditor";
            this.BtnBallEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnBallEditor.TabIndex = 26;
            this.BtnBallEditor.Text = "Ball.iff";
            this.BtnBallEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBallEditor.UseVisualStyleBackColor = true;
            this.BtnBallEditor.Click += new System.EventHandler(this.BtnBallEditor_Click);
            // 
            // BtnClubSetEditor
            // 
            this.BtnClubSetEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_18;
            this.BtnClubSetEditor.Location = new System.Drawing.Point(264, 19);
            this.BtnClubSetEditor.Name = "BtnClubSetEditor";
            this.BtnClubSetEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnClubSetEditor.TabIndex = 24;
            this.BtnClubSetEditor.Text = "ClubSet.iff";
            this.BtnClubSetEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClubSetEditor.UseVisualStyleBackColor = true;
            this.BtnClubSetEditor.Click += new System.EventHandler(this.BtnClubSetEditor_Click);
            // 
            // BtnCardEditor
            // 
            this.BtnCardEditor.Image = global::PangyaSuiteFiles.Properties.Resources.card_icon_pack_04;
            this.BtnCardEditor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCardEditor.Location = new System.Drawing.Point(178, 19);
            this.BtnCardEditor.Name = "BtnCardEditor";
            this.BtnCardEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCardEditor.TabIndex = 23;
            this.BtnCardEditor.Text = "Card.iff";
            this.BtnCardEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCardEditor.UseVisualStyleBackColor = true;
            this.BtnCardEditor.Click += new System.EventHandler(this.BtnCardEditor_Click);
            // 
            // BtnSetItemEditor
            // 
            this.BtnSetItemEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_11;
            this.BtnSetItemEditor.Location = new System.Drawing.Point(92, 19);
            this.BtnSetItemEditor.Name = "BtnSetItemEditor";
            this.BtnSetItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnSetItemEditor.TabIndex = 22;
            this.BtnSetItemEditor.Text = "SetItem.iff";
            this.BtnSetItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetItemEditor.UseVisualStyleBackColor = true;
            this.BtnSetItemEditor.Click += new System.EventHandler(this.BtnSetItemEditor_Click);
            // 
            // BtnItemEditor
            // 
            this.BtnItemEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_29;
            this.BtnItemEditor.Location = new System.Drawing.Point(5, 96);
            this.BtnItemEditor.Name = "BtnItemEditor";
            this.BtnItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnItemEditor.TabIndex = 25;
            this.BtnItemEditor.Text = "Item.iff";
            this.BtnItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnItemEditor.UseVisualStyleBackColor = true;
            this.BtnItemEditor.Click += new System.EventHandler(this.BtnItemEditor_Click);
            // 
            // BtnMemorialEditor
            // 
            this.BtnMemorialEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemorialEditor.Image = global::PangyaSuiteFiles.Properties.Resources.icon_memo;
            this.BtnMemorialEditor.Location = new System.Drawing.Point(91, 21);
            this.BtnMemorialEditor.Name = "BtnMemorialEditor";
            this.BtnMemorialEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnMemorialEditor.TabIndex = 35;
            this.BtnMemorialEditor.Text = "Memorial.iff";
            this.BtnMemorialEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMemorialEditor.UseVisualStyleBackColor = true;
            this.BtnMemorialEditor.Click += new System.EventHandler(this.BtnMemorialEditor_Click);
            // 
            // BtnAbil
            // 
            this.BtnAbil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbil.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.BtnAbil.Location = new System.Drawing.Point(5, 21);
            this.BtnAbil.Name = "BtnAbil";
            this.BtnAbil.Size = new System.Drawing.Size(84, 71);
            this.BtnAbil.TabIndex = 40;
            this.BtnAbil.Text = "Ability.iff";
            this.BtnAbil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAbil.UseVisualStyleBackColor = true;
            this.BtnAbil.Click += new System.EventHandler(this.BtnAbilityEditor);
            // 
            // BtnCauldronRandomEditor
            // 
            this.BtnCauldronRandomEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCauldronRandomEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_26;
            this.BtnCauldronRandomEditor.Location = new System.Drawing.Point(178, 21);
            this.BtnCauldronRandomEditor.Name = "BtnCauldronRandomEditor";
            this.BtnCauldronRandomEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCauldronRandomEditor.TabIndex = 28;
            this.BtnCauldronRandomEditor.Text = "C. Random.iff";
            this.BtnCauldronRandomEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCauldronRandomEditor.UseVisualStyleBackColor = true;
            this.BtnCauldronRandomEditor.Click += new System.EventHandler(this.BtnCauldronRandomEditor_Click);
            // 
            // BtnCauldron
            // 
            this.BtnCauldron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCauldron.Image = global::PangyaSuiteFiles.Properties.Resources.ico_26;
            this.BtnCauldron.Location = new System.Drawing.Point(264, 21);
            this.BtnCauldron.Name = "BtnCauldron";
            this.BtnCauldron.Size = new System.Drawing.Size(84, 71);
            this.BtnCauldron.TabIndex = 27;
            this.BtnCauldron.Text = "Cauldron.iff";
            this.BtnCauldron.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCauldron.UseVisualStyleBackColor = true;
            this.BtnCauldron.Click += new System.EventHandler(this.BtnCauldronEditor_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Hey Estou Aqui, Okay!?";
            this.notifyIcon1.BalloonTipTitle = "App Run";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Pangya File Suite JP";
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.logo_pangya2;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.logo_pangya2;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveIFFToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.bullet_arrow_down;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.extractionToolStripMenuItem,
            this.reloadToolStripMenuItem});
            this.openFileToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.btnAbrir_Image;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // extractionToolStripMenuItem
            // 
            this.extractionToolStripMenuItem.Name = "extractionToolStripMenuItem";
            this.extractionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.extractionToolStripMenuItem.Text = "&Extraction";
            this.extractionToolStripMenuItem.Click += new System.EventHandler(this.extractionToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // saveIFFToolStripMenuItem
            // 
            this.saveIFFToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.btnAlterar_Image;
            this.saveIFFToolStripMenuItem.Name = "saveIFFToolStripMenuItem";
            this.saveIFFToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveIFFToolStripMenuItem.Text = "&Save IFF";
            this.saveIFFToolStripMenuItem.Click += new System.EventHandler(this.saveIFFToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLoadIFFToolStripMenuItem,
            this.hideAppToolStripMenuItem,
            this.modeDevToolStripMenuItem});
            this.configurationToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.IconGroup99;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "&Configuration";
            // 
            // autoLoadIFFToolStripMenuItem
            // 
            this.autoLoadIFFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ON_LoadIFF,
            this.OFF_LoadIFF});
            this.autoLoadIFFToolStripMenuItem.Name = "autoLoadIFFToolStripMenuItem";
            this.autoLoadIFFToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.autoLoadIFFToolStripMenuItem.Text = "&Auto Load IFF";
            // 
            // ON_LoadIFF
            // 
            this.ON_LoadIFF.Checked = true;
            this.ON_LoadIFF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ON_LoadIFF.Image = global::PangyaSuiteFiles.Properties.Resources.accept1;
            this.ON_LoadIFF.Name = "ON_LoadIFF";
            this.ON_LoadIFF.Size = new System.Drawing.Size(124, 22);
            this.ON_LoadIFF.Text = "Active";
            this.ON_LoadIFF.CheckedChanged += new System.EventHandler(this.ON_LoadIFF_CheckedChanged);
            this.ON_LoadIFF.Click += new System.EventHandler(this.ON_LoadIFF_Click);
            // 
            // OFF_LoadIFF
            // 
            this.OFF_LoadIFF.Name = "OFF_LoadIFF";
            this.OFF_LoadIFF.Size = new System.Drawing.Size(124, 22);
            this.OFF_LoadIFF.Text = "Desactive";
            this.OFF_LoadIFF.CheckedChanged += new System.EventHandler(this.OFF_LoadIFF_CheckedChanged);
            this.OFF_LoadIFF.Click += new System.EventHandler(this.OFF_LoadIFF_Click_1);
            // 
            // hideAppToolStripMenuItem
            // 
            this.hideAppToolStripMenuItem.Name = "hideAppToolStripMenuItem";
            this.hideAppToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hideAppToolStripMenuItem.Text = "&Hide App";
            this.hideAppToolStripMenuItem.Click += new System.EventHandler(this.hideAppToolStripMenuItem_Click);
            // 
            // modeDevToolStripMenuItem
            // 
            this.modeDevToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.desactiveToolStripMenuItem});
            this.modeDevToolStripMenuItem.Enabled = false;
            this.modeDevToolStripMenuItem.Name = "modeDevToolStripMenuItem";
            this.modeDevToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.modeDevToolStripMenuItem.Text = "Mode Dev";
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.activeToolStripMenuItem.Text = "Active";
            // 
            // desactiveToolStripMenuItem
            // 
            this.desactiveToolStripMenuItem.Name = "desactiveToolStripMenuItem";
            this.desactiveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.desactiveToolStripMenuItem.Text = "Desactive";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.to_do_list_cheked_all;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PangyaSuiteFiles.Properties.Resources.disconnect;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.BtnGrandPrixEditor);
            this.groupBox3.Controls.Add(this.BtnAbil);
            this.groupBox3.Controls.Add(this.BtnCauldronRandomEditor);
            this.groupBox3.Controls.Add(this.BtnCauldron);
            this.groupBox3.Controls.Add(this.BtnMemorialEditor);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(5, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(441, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Special Editor IFF";
            // 
            // BtnGrandPrixEditor
            // 
            this.BtnGrandPrixEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrandPrixEditor.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.BtnGrandPrixEditor.Location = new System.Drawing.Point(351, 21);
            this.BtnGrandPrixEditor.Name = "BtnGrandPrixEditor";
            this.BtnGrandPrixEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnGrandPrixEditor.TabIndex = 41;
            this.BtnGrandPrixEditor.Text = "GP_Data.iff";
            this.BtnGrandPrixEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGrandPrixEditor.UseVisualStyleBackColor = true;
            this.BtnGrandPrixEditor.Click += new System.EventHandler(this.BtnGrandPrixEditor_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(7, 580);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Creator: LuisMK";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.BtnWikipedia);
            this.groupBox4.Controls.Add(this.BtnGGEditor);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.BtnCreateOrExtractPak);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(5, 399);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(441, 174);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other Files Editors";
            // 
            // BtnWikipedia
            // 
            this.BtnWikipedia.ForeColor = System.Drawing.Color.Black;
            this.BtnWikipedia.Image = global::PangyaSuiteFiles.Properties.Resources.IconGroup99;
            this.BtnWikipedia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnWikipedia.Location = new System.Drawing.Point(178, 96);
            this.BtnWikipedia.Name = "BtnWikipedia";
            this.BtnWikipedia.Size = new System.Drawing.Size(84, 71);
            this.BtnWikipedia.TabIndex = 15;
            this.BtnWikipedia.Text = "Generation Wikipedia";
            this.BtnWikipedia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnWikipedia.UseVisualStyleBackColor = true;
            this.BtnWikipedia.Click += new System.EventHandler(this.BtnWikipedia_Click);
            // 
            // BtnGGEditor
            // 
            this.BtnGGEditor.ForeColor = System.Drawing.Color.Black;
            this.BtnGGEditor.Image = global::PangyaSuiteFiles.Properties.Resources.icon_gg2;
            this.BtnGGEditor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGGEditor.Location = new System.Drawing.Point(92, 96);
            this.BtnGGEditor.Name = "BtnGGEditor";
            this.BtnGGEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnGGEditor.TabIndex = 14;
            this.BtnGGEditor.Text = "Pangya.ini";
            this.BtnGGEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGGEditor.UseVisualStyleBackColor = true;
            this.BtnGGEditor.Click += new System.EventHandler(this.BtnGGEditor_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.button3.Location = new System.Drawing.Point(352, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 71);
            this.button3.TabIndex = 12;
            this.button3.Text = "SD Convert";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnSDConvert);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.button5.Location = new System.Drawing.Point(265, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 71);
            this.button5.TabIndex = 11;
            this.button5.Text = "ShitList.bin";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnBinEditor);
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.button6.Location = new System.Drawing.Point(178, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 71);
            this.button6.TabIndex = 10;
            this.button6.Text = "Caddie.Talk";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BtnTalkEditor);
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.button8.Location = new System.Drawing.Point(92, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 71);
            this.button8.TabIndex = 9;
            this.button8.Text = "Imagem.tga";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.BtnViewTGA);
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Image = global::PangyaSuiteFiles.Properties.Resources.building_edit;
            this.button9.Location = new System.Drawing.Point(6, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(84, 71);
            this.button9.TabIndex = 8;
            this.button9.Text = "Language.dat";
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.BtnThailandEditor_Click);
            // 
            // BtnCreateOrExtractPak
            // 
            this.BtnCreateOrExtractPak.Enabled = false;
            this.BtnCreateOrExtractPak.ForeColor = System.Drawing.Color.Black;
            this.BtnCreateOrExtractPak.Image = global::PangyaSuiteFiles.Properties.Resources.ico_22;
            this.BtnCreateOrExtractPak.Location = new System.Drawing.Point(6, 96);
            this.BtnCreateOrExtractPak.Name = "BtnCreateOrExtractPak";
            this.BtnCreateOrExtractPak.Size = new System.Drawing.Size(84, 71);
            this.BtnCreateOrExtractPak.TabIndex = 13;
            this.BtnCreateOrExtractPak.Text = "Project*.pak";
            this.BtnCreateOrExtractPak.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnCreateOrExtractPak.UseVisualStyleBackColor = true;
            this.BtnCreateOrExtractPak.Click += new System.EventHandler(this.BtnCreateOrExtractPak_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.favpng_pangya_fantasy_golf_ini3_digital_fan_art;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(450, 599);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Pangya Suite Tools [GB] ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.StartupWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Button BtnPartEditor;
#pragma warning disable CS0169 // O campo "FrmMain.icontainer_0" nunca é usado
        private IContainer icontainer_0;
#pragma warning restore CS0169 // O campo "FrmMain.icontainer_0" nunca é usado
        #endregion
        private GroupBox groupBox1;
        private Button BtnCharacter;
        private Button BtnMemorialEditor;
        private Button BtnDescEditor;
        private Button BtnMascotEditor;
        private Button BtnSkinEditor;
        private Button BtnCaddieItemEditor;
        private Button BtnCaddieEditor;
        private Button BtnCauldronRandomEditor;
        private Button BtnCauldron;
        private Button BtnBallEditor;
        private Button BtnClubSetEditor;
        private Button BtnCardEditor;
        private Button BtnSetItemEditor;
        private Button BtnItemEditor;
        private NotifyIcon notifyIcon1;
        private Button BtnHairStyle;
        private Button BtnClub;
        private Button BtnAuxPart;
        private Button BtnAbil;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveIFFToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem autoLoadIFFToolStripMenuItem;
        private ToolStripMenuItem ON_LoadIFF;
        private ToolStripMenuItem OFF_LoadIFF;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem hideAppToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem extractionToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private GroupBox groupBox3;
        private Button BtnGrandPrixEditor;
        private ToolStripMenuItem modeDevToolStripMenuItem;
        private ToolStripMenuItem activeToolStripMenuItem;
        private ToolStripMenuItem desactiveToolStripMenuItem;
        private LinkLabel linkLabel1;
        private GroupBox groupBox4;
        private Button button3;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button9;
        private Button BtnCreateOrExtractPak;
        private Button BtnGGEditor;
        private Button BtnWikipedia;
    }
}