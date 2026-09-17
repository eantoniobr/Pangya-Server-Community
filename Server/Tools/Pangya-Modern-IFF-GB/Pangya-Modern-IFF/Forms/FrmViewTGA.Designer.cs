using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    partial class FrmViewTGA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewTGA));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.rbAchatar = new System.Windows.Forms.RadioButton();
            this.rbAjustar = new System.Windows.Forms.RadioButton();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.boxImagem = new System.Windows.Forms.PictureBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.BtnSalvarMassa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImagemMassa = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtImagem = new System.Windows.Forms.TextBox();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BuscarArquivo = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImagem)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.RadioButton1);
            this.GroupBox1.Controls.Add(this.rbAchatar);
            this.GroupBox1.Controls.Add(this.rbAjustar);
            this.GroupBox1.Controls.Add(this.rbOriginal);
            this.GroupBox1.Location = new System.Drawing.Point(12, 316);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(289, 52);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Opções";
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(212, 23);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(74, 17);
            this.RadioButton1.TabIndex = 0;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "Centralizar";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton1.CheckedChanged += new System.EventHandler(this.rbAchatar_CheckedChanged);
            // 
            // rbAchatar
            // 
            this.rbAchatar.AutoSize = true;
            this.rbAchatar.Location = new System.Drawing.Point(144, 23);
            this.rbAchatar.Name = "rbAchatar";
            this.rbAchatar.Size = new System.Drawing.Size(62, 17);
            this.rbAchatar.TabIndex = 0;
            this.rbAchatar.Text = "Achatar";
            this.rbAchatar.UseVisualStyleBackColor = true;
            this.rbAchatar.CheckedChanged += new System.EventHandler(this.rbAchatar_CheckedChanged);
            // 
            // rbAjustar
            // 
            this.rbAjustar.AutoSize = true;
            this.rbAjustar.Location = new System.Drawing.Point(81, 23);
            this.rbAjustar.Name = "rbAjustar";
            this.rbAjustar.Size = new System.Drawing.Size(57, 17);
            this.rbAjustar.TabIndex = 0;
            this.rbAjustar.Text = "Ajustar";
            this.rbAjustar.UseVisualStyleBackColor = true;
            this.rbAjustar.CheckedChanged += new System.EventHandler(this.rbAjustar_CheckedChanged);
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Location = new System.Drawing.Point(15, 23);
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.Size = new System.Drawing.Size(60, 17);
            this.rbOriginal.TabIndex = 0;
            this.rbOriginal.Text = "Original";
            this.rbOriginal.UseVisualStyleBackColor = true;
            this.rbOriginal.CheckedChanged += new System.EventHandler(this.rbOriginal_CheckedChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Image = global::PangyaSuiteFiles.Properties.Resources.btnAlterar_Image;
            this.btnSalvar.Location = new System.Drawing.Point(277, 7);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(26, 26);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // boxImagem
            // 
            this.boxImagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxImagem.BackgroundImage = global::PangyaSuiteFiles.Properties.Resources.bg_transparent;
            this.boxImagem.ErrorImage = global::PangyaSuiteFiles.Properties.Resources._error;
            this.boxImagem.Location = new System.Drawing.Point(0, 63);
            this.boxImagem.Name = "boxImagem";
            this.boxImagem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.boxImagem.Size = new System.Drawing.Size(313, 247);
            this.boxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.boxImagem.TabIndex = 1;
            this.boxImagem.TabStop = false;
            this.boxImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.boxImagem_MouseMove);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.BtnSalvarMassa);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.txtImagemMassa);
            this.Panel1.Controls.Add(this.btnSalvar);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.btnAbrir);
            this.Panel1.Controls.Add(this.txtImagem);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.boxImagem);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(0, 70, 0, 70);
            this.Panel1.Size = new System.Drawing.Size(313, 380);
            this.Panel1.TabIndex = 2;
            // 
            // BtnSalvarMassa
            // 
            this.BtnSalvarMassa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalvarMassa.Image = global::PangyaSuiteFiles.Properties.Resources.btnAlterar_Image;
            this.BtnSalvarMassa.Location = new System.Drawing.Point(249, 33);
            this.BtnSalvarMassa.Name = "BtnSalvarMassa";
            this.BtnSalvarMassa.Size = new System.Drawing.Size(26, 26);
            this.BtnSalvarMassa.TabIndex = 46;
            this.BtnSalvarMassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalvarMassa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSalvarMassa.UseVisualStyleBackColor = true;
            this.BtnSalvarMassa.Click += new System.EventHandler(this.BtnSalvarMassa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Img Massa";
            // 
            // txtImagemMassa
            // 
            this.txtImagemMassa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagemMassa.Location = new System.Drawing.Point(65, 37);
            this.txtImagemMassa.Name = "txtImagemMassa";
            this.txtImagemMassa.Size = new System.Drawing.Size(178, 20);
            this.txtImagemMassa.TabIndex = 44;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(1, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(44, 13);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Imagem";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrir.Image = global::PangyaSuiteFiles.Properties.Resources.btnAbrir_Image;
            this.btnAbrir.Location = new System.Drawing.Point(249, 8);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(25, 25);
            this.btnAbrir.TabIndex = 42;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtImagem
            // 
            this.txtImagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagem.Location = new System.Drawing.Point(65, 11);
            this.txtImagem.Name = "txtImagem";
            this.txtImagem.ReadOnly = true;
            this.txtImagem.Size = new System.Drawing.Size(178, 20);
            this.txtImagem.TabIndex = 2;
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.DefaultExt = "png";
            this.SaveFileDialog1.Filter = "Imagens|*.png|*.gif|*.jpg";
            // 
            // BuscarArquivo
            // 
            this.BuscarArquivo.DefaultExt = "tga";
            this.BuscarArquivo.Filter = "Imagens tga|*.tga";
            // 
            // FrmViewTGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 380);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(329, 418);
            this.Name = "FrmViewTGA";
            this.Text = "Visualizar Imagens TGA";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImagem)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

		}
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox GroupBox1;
        [AccessedThroughProperty("btnSalvar")]
        private Button btnSalvar;
        [AccessedThroughProperty("rbAchatar")]
        private RadioButton rbAchatar;
        [AccessedThroughProperty("rbAjustar")]
        private RadioButton rbAjustar;
        [AccessedThroughProperty("rbOriginal")]
        private RadioButton rbOriginal;
        [AccessedThroughProperty("boxImagem")]
        private PictureBox boxImagem;
        [AccessedThroughProperty("Panel1")]
        private Panel Panel1;
        [AccessedThroughProperty("txtImagem")]
        private TextBox txtImagem;
        [AccessedThroughProperty("Label1")]
        private Label Label1;
        [AccessedThroughProperty("btnAbrir")]
        private Button btnAbrir;
        [AccessedThroughProperty("SaveFileDialog1")]
        private SaveFileDialog SaveFileDialog1;
        [AccessedThroughProperty("BuscarArquivo")]
        private OpenFileDialog BuscarArquivo;
        [AccessedThroughProperty("RadioButton1")]
        private RadioButton RadioButton1;
        #endregion

        private Button BtnSalvarMassa;
        private Label label2;
        private TextBox txtImagemMassa;
    }
}