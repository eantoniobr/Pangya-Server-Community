using Pangya_Modern_Editor.Properties;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    partial class FrmMain
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
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnPartEditor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCharacter = new System.Windows.Forms.Button();
            this.BtnMatch = new System.Windows.Forms.Button();
            this.BtnCaddieItemEditor = new System.Windows.Forms.Button();
            this.BtnClubEditor = new System.Windows.Forms.Button();
            this.BtnAuxPart = new System.Windows.Forms.Button();
            this.BtnHairStyle = new System.Windows.Forms.Button();
            this.BtnMemorialEditor = new System.Windows.Forms.Button();
            this.BtnCauldron = new System.Windows.Forms.Button();
            this.BtnDescEditor = new System.Windows.Forms.Button();
            this.BtnLevelUp = new System.Windows.Forms.Button();
            this.BtnMemorialEditor2 = new System.Windows.Forms.Button();
            this.BtnMascotEditor = new System.Windows.Forms.Button();
            this.BtnSkinEditor = new System.Windows.Forms.Button();
            this.BtnCaddieEditor = new System.Windows.Forms.Button();
            this.BtnBallEditor = new System.Windows.Forms.Button();
            this.BtnClubSetEditor = new System.Windows.Forms.Button();
            this.BtnCardEditor = new System.Windows.Forms.Button();
            this.BtnSetItemEditor = new System.Windows.Forms.Button();
            this.BtnItemEditor = new System.Windows.Forms.Button();
            this.BtnPointShop = new System.Windows.Forms.Button();
            this.BtnSetEffectEditor = new System.Windows.Forms.Button();
            this.BtnGrandPrixEditor = new System.Windows.Forms.Button();
            this.BtnAbilityEditor = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveIFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.Button9 = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnErrorCodeInfo = new System.Windows.Forms.Button();
            this.BtnCauldronRandom = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPartEditor
            // 
            this.BtnPartEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPartEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnPartEditor.Image")));
            this.BtnPartEditor.Location = new System.Drawing.Point(6, 19);
            this.BtnPartEditor.Name = "BtnPartEditor";
            this.BtnPartEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnPartEditor.TabIndex = 1;
            this.BtnPartEditor.Text = "Part.iff";
            this.BtnPartEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPartEditor.UseVisualStyleBackColor = true;
            this.BtnPartEditor.Click += new System.EventHandler(this.BtnPartClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.BtnCharacter);
            this.groupBox1.Controls.Add(this.BtnMatch);
            this.groupBox1.Controls.Add(this.BtnCaddieItemEditor);
            this.groupBox1.Controls.Add(this.BtnClubEditor);
            this.groupBox1.Controls.Add(this.BtnAuxPart);
            this.groupBox1.Controls.Add(this.BtnHairStyle);
            this.groupBox1.Controls.Add(this.BtnMemorialEditor);
            this.groupBox1.Controls.Add(this.BtnCauldron);
            this.groupBox1.Controls.Add(this.BtnDescEditor);
            this.groupBox1.Controls.Add(this.BtnLevelUp);
            this.groupBox1.Controls.Add(this.BtnMemorialEditor2);
            this.groupBox1.Controls.Add(this.BtnMascotEditor);
            this.groupBox1.Controls.Add(this.BtnSkinEditor);
            this.groupBox1.Controls.Add(this.BtnCaddieEditor);
            this.groupBox1.Controls.Add(this.BtnBallEditor);
            this.groupBox1.Controls.Add(this.BtnClubSetEditor);
            this.groupBox1.Controls.Add(this.BtnCardEditor);
            this.groupBox1.Controls.Add(this.BtnSetItemEditor);
            this.groupBox1.Controls.Add(this.BtnItemEditor);
            this.groupBox1.Controls.Add(this.BtnPartEditor);
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 326);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // BtnCharacter
            // 
            this.BtnCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCharacter.Image = global::Pangya_Modern_Editor.Properties.Resources.arin;
            this.BtnCharacter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCharacter.Location = new System.Drawing.Point(175, 251);
            this.BtnCharacter.Name = "BtnCharacter";
            this.BtnCharacter.Size = new System.Drawing.Size(84, 71);
            this.BtnCharacter.TabIndex = 50;
            this.BtnCharacter.Text = "Character.iff";
            this.BtnCharacter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCharacter.UseVisualStyleBackColor = true;
            this.BtnCharacter.Click += new System.EventHandler(this.BtnCharacter_Click);
            // 
            // BtnMatch
            // 
            this.BtnMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMatch.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnGrandPrix;
            this.BtnMatch.Location = new System.Drawing.Point(89, 251);
            this.BtnMatch.Name = "BtnMatch";
            this.BtnMatch.Size = new System.Drawing.Size(84, 71);
            this.BtnMatch.TabIndex = 48;
            this.BtnMatch.Text = "Match.iff";
            this.BtnMatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMatch.UseVisualStyleBackColor = true;
            this.BtnMatch.Click += new System.EventHandler(this.BtnMatch_Click);
            // 
            // BtnCaddieItemEditor
            // 
            this.BtnCaddieItemEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCaddieItemEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnCaddieItemEditor.Image")));
            this.BtnCaddieItemEditor.Location = new System.Drawing.Point(91, 20);
            this.BtnCaddieItemEditor.Name = "BtnCaddieItemEditor";
            this.BtnCaddieItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCaddieItemEditor.TabIndex = 41;
            this.BtnCaddieItemEditor.Text = "CaddieItem.iff";
            this.BtnCaddieItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCaddieItemEditor.UseVisualStyleBackColor = true;
            this.BtnCaddieItemEditor.Click += new System.EventHandler(this.BtnCaddieItemClick);
            // 
            // BtnClubEditor
            // 
            this.BtnClubEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClubEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnClubEditor.Image")));
            this.BtnClubEditor.Location = new System.Drawing.Point(176, 98);
            this.BtnClubEditor.Name = "BtnClubEditor";
            this.BtnClubEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnClubEditor.TabIndex = 40;
            this.BtnClubEditor.Text = "Club.iff";
            this.BtnClubEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClubEditor.UseVisualStyleBackColor = true;
            this.BtnClubEditor.Click += new System.EventHandler(this.BtnClubEditor_Click);
            // 
            // BtnAuxPart
            // 
            this.BtnAuxPart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAuxPart.Image = ((System.Drawing.Image)(resources.GetObject("BtnAuxPart.Image")));
            this.BtnAuxPart.Location = new System.Drawing.Point(260, 98);
            this.BtnAuxPart.Name = "BtnAuxPart";
            this.BtnAuxPart.Size = new System.Drawing.Size(84, 71);
            this.BtnAuxPart.TabIndex = 39;
            this.BtnAuxPart.Text = "AuxPart.iff";
            this.BtnAuxPart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAuxPart.UseVisualStyleBackColor = true;
            this.BtnAuxPart.Click += new System.EventHandler(this.BtnAuxPartClick);
            // 
            // BtnHairStyle
            // 
            this.BtnHairStyle.BackColor = System.Drawing.Color.Transparent;
            this.BtnHairStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnHairStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHairStyle.Image = ((System.Drawing.Image)(resources.GetObject("BtnHairStyle.Image")));
            this.BtnHairStyle.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnHairStyle.Location = new System.Drawing.Point(260, 252);
            this.BtnHairStyle.Name = "BtnHairStyle";
            this.BtnHairStyle.Size = new System.Drawing.Size(84, 71);
            this.BtnHairStyle.TabIndex = 37;
            this.BtnHairStyle.Text = "HairStyle.iff";
            this.BtnHairStyle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnHairStyle.UseVisualStyleBackColor = false;
            this.BtnHairStyle.Click += new System.EventHandler(this.BtnHairStyle_Click);
            // 
            // BtnMemorialEditor
            // 
            this.BtnMemorialEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMemorialEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemorialEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.item1_366;
            this.BtnMemorialEditor.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnMemorialEditor.Location = new System.Drawing.Point(348, 251);
            this.BtnMemorialEditor.Name = "BtnMemorialEditor";
            this.BtnMemorialEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnMemorialEditor.TabIndex = 35;
            this.BtnMemorialEditor.Text = "M. Coin.sff";
            this.BtnMemorialEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMemorialEditor.UseVisualStyleBackColor = true;
            this.BtnMemorialEditor.Click += new System.EventHandler(this.BtnMemorialEditor_Click);
            // 
            // BtnCauldron
            // 
            this.BtnCauldron.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCauldron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCauldron.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMagicBox;
            this.BtnCauldron.Location = new System.Drawing.Point(348, 98);
            this.BtnCauldron.Name = "BtnCauldron";
            this.BtnCauldron.Size = new System.Drawing.Size(84, 71);
            this.BtnCauldron.TabIndex = 27;
            this.BtnCauldron.Text = "Cauldron.iff";
            this.BtnCauldron.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCauldron.UseVisualStyleBackColor = true;
            this.BtnCauldron.Click += new System.EventHandler(this.BtnCauldron_Click);
            // 
            // BtnDescEditor
            // 
            this.BtnDescEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDescEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDesc;
            this.BtnDescEditor.Location = new System.Drawing.Point(260, 175);
            this.BtnDescEditor.Name = "BtnDescEditor";
            this.BtnDescEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnDescEditor.TabIndex = 33;
            this.BtnDescEditor.Text = "Desc.iff";
            this.BtnDescEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDescEditor.UseVisualStyleBackColor = true;
            this.BtnDescEditor.Click += new System.EventHandler(this.BtnDescClick);
            // 
            // BtnLevelUp
            // 
            this.BtnLevelUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLevelUp.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnLevel;
            this.BtnLevelUp.Location = new System.Drawing.Point(348, 21);
            this.BtnLevelUp.Name = "BtnLevelUp";
            this.BtnLevelUp.Size = new System.Drawing.Size(84, 71);
            this.BtnLevelUp.TabIndex = 48;
            this.BtnLevelUp.Text = "LevelUp.iff";
            this.BtnLevelUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLevelUp.UseVisualStyleBackColor = true;
            this.BtnLevelUp.Click += new System.EventHandler(this.BtnLevelUp_Click);
            // 
            // BtnMemorialEditor2
            // 
            this.BtnMemorialEditor2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMemorialEditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMemorialEditor2.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMemo_C;
            this.BtnMemorialEditor2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnMemorialEditor2.Location = new System.Drawing.Point(348, 175);
            this.BtnMemorialEditor2.Name = "BtnMemorialEditor2";
            this.BtnMemorialEditor2.Size = new System.Drawing.Size(84, 71);
            this.BtnMemorialEditor2.TabIndex = 45;
            this.BtnMemorialEditor2.Text = "M. Rare.iff";
            this.BtnMemorialEditor2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMemorialEditor2.UseVisualStyleBackColor = true;
            this.BtnMemorialEditor2.Click += new System.EventHandler(this.BtnMemorialEditor2_Click);
            // 
            // BtnMascotEditor
            // 
            this.BtnMascotEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMascotEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnMascotEditor.Image")));
            this.BtnMascotEditor.Location = new System.Drawing.Point(4, 250);
            this.BtnMascotEditor.Name = "BtnMascotEditor";
            this.BtnMascotEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnMascotEditor.TabIndex = 32;
            this.BtnMascotEditor.Text = "Mascot.iff";
            this.BtnMascotEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMascotEditor.UseVisualStyleBackColor = true;
            this.BtnMascotEditor.Click += new System.EventHandler(this.BtnMascotClick);
            // 
            // BtnSkinEditor
            // 
            this.BtnSkinEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSkinEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnSkinEditor.Image")));
            this.BtnSkinEditor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSkinEditor.Location = new System.Drawing.Point(90, 174);
            this.BtnSkinEditor.Name = "BtnSkinEditor";
            this.BtnSkinEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnSkinEditor.TabIndex = 31;
            this.BtnSkinEditor.Text = "Skin.iff";
            this.BtnSkinEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSkinEditor.UseVisualStyleBackColor = true;
            this.BtnSkinEditor.Click += new System.EventHandler(this.BtnSkinClick);
            // 
            // BtnCaddieEditor
            // 
            this.BtnCaddieEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCaddieEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnCaddieEditor.Image")));
            this.BtnCaddieEditor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCaddieEditor.Location = new System.Drawing.Point(176, 21);
            this.BtnCaddieEditor.Name = "BtnCaddieEditor";
            this.BtnCaddieEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCaddieEditor.TabIndex = 29;
            this.BtnCaddieEditor.Text = "Caddie.iff";
            this.BtnCaddieEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCaddieEditor.UseVisualStyleBackColor = true;
            this.BtnCaddieEditor.Click += new System.EventHandler(this.BtnCaddieClick);
            // 
            // BtnBallEditor
            // 
            this.BtnBallEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBallEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnBallEditor.Image")));
            this.BtnBallEditor.Location = new System.Drawing.Point(4, 173);
            this.BtnBallEditor.Name = "BtnBallEditor";
            this.BtnBallEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnBallEditor.TabIndex = 26;
            this.BtnBallEditor.Text = "Ball.iff";
            this.BtnBallEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBallEditor.UseVisualStyleBackColor = true;
            this.BtnBallEditor.Click += new System.EventHandler(this.BtnBallClick);
            // 
            // BtnClubSetEditor
            // 
            this.BtnClubSetEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClubSetEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnClubSetEditor.Image")));
            this.BtnClubSetEditor.Location = new System.Drawing.Point(90, 97);
            this.BtnClubSetEditor.Name = "BtnClubSetEditor";
            this.BtnClubSetEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnClubSetEditor.TabIndex = 24;
            this.BtnClubSetEditor.Text = "ClubSet.iff";
            this.BtnClubSetEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClubSetEditor.UseVisualStyleBackColor = true;
            this.BtnClubSetEditor.Click += new System.EventHandler(this.BtnClubSetClick);
            // 
            // BtnCardEditor
            // 
            this.BtnCardEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCardEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnCardEditor.Image")));
            this.BtnCardEditor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCardEditor.Location = new System.Drawing.Point(5, 96);
            this.BtnCardEditor.Name = "BtnCardEditor";
            this.BtnCardEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnCardEditor.TabIndex = 23;
            this.BtnCardEditor.Text = "Card.iff";
            this.BtnCardEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCardEditor.UseVisualStyleBackColor = true;
            this.BtnCardEditor.Click += new System.EventHandler(this.BtnCardClick);
            // 
            // BtnSetItemEditor
            // 
            this.BtnSetItemEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetItemEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSet;
            this.BtnSetItemEditor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetItemEditor.Location = new System.Drawing.Point(175, 175);
            this.BtnSetItemEditor.Name = "BtnSetItemEditor";
            this.BtnSetItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnSetItemEditor.TabIndex = 22;
            this.BtnSetItemEditor.Text = "SetItem.iff";
            this.BtnSetItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetItemEditor.UseVisualStyleBackColor = true;
            this.BtnSetItemEditor.Click += new System.EventHandler(this.BtnSetItemClick);
            // 
            // BtnItemEditor
            // 
            this.BtnItemEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnItemEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnItemEditor.Image")));
            this.BtnItemEditor.Location = new System.Drawing.Point(260, 21);
            this.BtnItemEditor.Name = "BtnItemEditor";
            this.BtnItemEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnItemEditor.TabIndex = 25;
            this.BtnItemEditor.Text = "Item.iff";
            this.BtnItemEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnItemEditor.UseVisualStyleBackColor = true;
            this.BtnItemEditor.Click += new System.EventHandler(this.BtnItemClick);
            // 
            // BtnPointShop
            // 
            this.BtnPointShop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPointShop.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnPoint;
            this.BtnPointShop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPointShop.Location = new System.Drawing.Point(176, 14);
            this.BtnPointShop.Name = "BtnPointShop";
            this.BtnPointShop.Size = new System.Drawing.Size(84, 71);
            this.BtnPointShop.TabIndex = 49;
            this.BtnPointShop.Text = "PointShop.iff";
            this.BtnPointShop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPointShop.UseVisualStyleBackColor = true;
            this.BtnPointShop.Click += new System.EventHandler(this.BtnPointShop_Click);
            // 
            // BtnSetEffectEditor
            // 
            this.BtnSetEffectEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetEffectEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnSetEffect;
            this.BtnSetEffectEditor.Location = new System.Drawing.Point(5, 14);
            this.BtnSetEffectEditor.Name = "BtnSetEffectEditor";
            this.BtnSetEffectEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnSetEffectEditor.TabIndex = 46;
            this.BtnSetEffectEditor.Text = "EffectTable.iff";
            this.BtnSetEffectEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetEffectEditor.UseVisualStyleBackColor = true;
            this.BtnSetEffectEditor.Click += new System.EventHandler(this.BtnSetEffectClick);
            // 
            // BtnGrandPrixEditor
            // 
            this.BtnGrandPrixEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrandPrixEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrandPrixEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMatch;
            this.BtnGrandPrixEditor.Location = new System.Drawing.Point(260, 14);
            this.BtnGrandPrixEditor.Name = "BtnGrandPrixEditor";
            this.BtnGrandPrixEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnGrandPrixEditor.TabIndex = 44;
            this.BtnGrandPrixEditor.Text = "GP_Data.iff";
            this.BtnGrandPrixEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGrandPrixEditor.UseVisualStyleBackColor = true;
            this.BtnGrandPrixEditor.Click += new System.EventHandler(this.BtnGrandPrixEditor_Click);
            // 
            // BtnAbilityEditor
            // 
            this.BtnAbilityEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAbilityEditor.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnAbility;
            this.BtnAbilityEditor.Location = new System.Drawing.Point(6, 91);
            this.BtnAbilityEditor.Name = "BtnAbilityEditor";
            this.BtnAbilityEditor.Size = new System.Drawing.Size(84, 71);
            this.BtnAbilityEditor.TabIndex = 43;
            this.BtnAbilityEditor.Text = "Ability.iff";
            this.BtnAbilityEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAbilityEditor.UseVisualStyleBackColor = true;
            this.BtnAbilityEditor.Click += new System.EventHandler(this.BtnAbilityEditor_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveIFFToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.bullet_arrow_down;
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
            this.openFileToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.document_editing;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnExplorer;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // extractionToolStripMenuItem
            // 
            this.extractionToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.winrar_extract;
            this.extractionToolStripMenuItem.Name = "extractionToolStripMenuItem";
            this.extractionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.extractionToolStripMenuItem.Text = "&Extraction";
            this.extractionToolStripMenuItem.Click += new System.EventHandler(this.extractionToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // saveIFFToolStripMenuItem
            // 
            this.saveIFFToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnDisk;
            this.saveIFFToolStripMenuItem.Name = "saveIFFToolStripMenuItem";
            this.saveIFFToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveIFFToolStripMenuItem.Text = "&Save IFF";
            this.saveIFFToolStripMenuItem.Click += new System.EventHandler(this.saveIFFToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundToolStripMenuItem});
            this.configurationToolStripMenuItem.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnConfig;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "&Configuration";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.BalloonTipText = "Hey Estou Aqui, Okay!?";
            this.notify.BalloonTipTitle = "App Run";
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Pangya Modern Editor";
            this.notify.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notify.DoubleClick += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Button9
            // 
            this.Button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button9.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnHide;
            this.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button9.Location = new System.Drawing.Point(5, 612);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(108, 41);
            this.Button9.TabIndex = 20;
            this.Button9.TabStop = false;
            this.Button9.Text = "&Hide";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button9.Click += new System.EventHandler(this.hideAppToolStripMenuItem_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnExit;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(331, 612);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(108, 41);
            this.BtnExit.TabIndex = 21;
            this.BtnExit.TabStop = false;
            this.BtnExit.Text = "&Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(348, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 71);
            this.button3.TabIndex = 49;
            this.button3.Text = "GP_IA_DATA.iff";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.BtnErrorCodeInfo);
            this.groupBox2.Controls.Add(this.BtnCauldronRandom);
            this.groupBox2.Controls.Add(this.BtnPointShop);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.BtnGrandPrixEditor);
            this.groupBox2.Controls.Add(this.BtnSetEffectEditor);
            this.groupBox2.Controls.Add(this.BtnAbilityEditor);
            this.groupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Location = new System.Drawing.Point(5, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 242);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor Special";
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(348, 168);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 71);
            this.button5.TabIndex = 56;
            this.button5.Text = "CounterItem.iff";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMatch;
            this.button6.Location = new System.Drawing.Point(260, 168);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 71);
            this.button6.TabIndex = 55;
            this.button6.Text = "QuestStuff.iff";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(348, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 71);
            this.button1.TabIndex = 54;
            this.button1.Text = "QuestItem.iff";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnMatch;
            this.button2.Location = new System.Drawing.Point(260, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 71);
            this.button2.TabIndex = 53;
            this.button2.Text = "Achievement.iff";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Pangya_Modern_Editor.Properties.Resources.BtnGrandPrix;
            this.button4.Location = new System.Drawing.Point(176, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 71);
            this.button4.TabIndex = 52;
            this.button4.Text = "GP_REWARD.iff";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnErrorCodeInfo
            // 
            this.BtnErrorCodeInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnErrorCodeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnErrorCodeInfo.Image = ((System.Drawing.Image)(resources.GetObject("BtnErrorCodeInfo.Image")));
            this.BtnErrorCodeInfo.Location = new System.Drawing.Point(91, 91);
            this.BtnErrorCodeInfo.Name = "BtnErrorCodeInfo";
            this.BtnErrorCodeInfo.Size = new System.Drawing.Size(84, 71);
            this.BtnErrorCodeInfo.TabIndex = 51;
            this.BtnErrorCodeInfo.Text = "ErrorCodeInfo.iff";
            this.BtnErrorCodeInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnErrorCodeInfo.UseVisualStyleBackColor = true;
            this.BtnErrorCodeInfo.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnCauldronRandom
            // 
            this.BtnCauldronRandom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCauldronRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCauldronRandom.Image = ((System.Drawing.Image)(resources.GetObject("BtnCauldronRandom.Image")));
            this.BtnCauldronRandom.Location = new System.Drawing.Point(91, 14);
            this.BtnCauldronRandom.Name = "BtnCauldronRandom";
            this.BtnCauldronRandom.Size = new System.Drawing.Size(84, 71);
            this.BtnCauldronRandom.TabIndex = 42;
            this.BtnCauldronRandom.Text = "C. Random.iff";
            this.BtnCauldronRandom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCauldronRandom.UseVisualStyleBackColor = true;
            this.BtnCauldronRandom.Click += new System.EventHandler(this.BtnCauldronRandom_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(160, 662);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(33, 15);
            this.lblVersion.TabIndex = 30;
            this.lblVersion.Text = "9.7.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(115, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Version:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(216, 662);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(141, 15);
            this.lblTime.TabIndex = 31;
            this.lblTime.Text = "Time: 25/08/24 14:30:45";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(35, 662);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 15);
            this.lblUser.TabIndex = 28;
            this.lblUser.Text = "adm0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 662);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "User:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(446, 680);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Pangya_Modern_Editor.Properties.Resources.Bongdari;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Pangya Modern Editor";
            this.Load += new System.EventHandler(this.StartupWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox1;
        private Button BtnPartEditor;
        private Button BtnMemorialEditor;
        private Button BtnDescEditor;
        private Button BtnMascotEditor;
        private Button BtnSkinEditor;
        private Button BtnCaddieEditor;
        private Button BtnCauldron;
        private Button BtnBallEditor;
        private Button BtnClubSetEditor;
        private Button BtnCardEditor;
        private Button BtnSetItemEditor;
        private Button BtnItemEditor;
        private Button BtnHairStyle;
        private Button BtnAuxPart;
        private Button BtnClubEditor;
        private Button BtnCaddieItemEditor;
        private Button BtnAbilityEditor;
        private Button BtnGrandPrixEditor;
        private Button BtnMemorialEditor2;
        private Button BtnLevelUp;
        private Button BtnPointShop;
        private Button BtnCharacter;
        private Button BtnMatch;
        private Button BtnCauldronRandom;
        private Button BtnSetEffectEditor;
        private NotifyIcon notify;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveIFFToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem extractionToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private Button Button9;
        private Button BtnExit;
        private Timer timer1;
        private Button button3;
        private GroupBox groupBox2;
        private Button button4;
        private Button BtnErrorCodeInfo;
        private Label lblVersion;
        private Label label3;
        private Label lblTime;
        private Label lblUser;
        private Label label1;
        private ToolStripMenuItem soundToolStripMenuItem;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private Button button5;
        private Button button6;
        private Button button1;
        private Button button2;
    }
}