namespace EditorIFF
{
    using EditorIFF.My;
    using EditorIFF.My.Resources;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class frmCaddie : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private IContainer components;
        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip _StatusStrip1;
        [AccessedThroughProperty("ToolStrip1")]
        private ToolStrip _ToolStrip1;
        [AccessedThroughProperty("SplitContainer1")]
        private SplitContainer _SplitContainer1;
        [AccessedThroughProperty("Panel3")]
        private Panel _Panel3;
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("txtPesquisa")]
        private TextBox _txtPesquisa;
        [AccessedThroughProperty("gbBotoes")]
        private GroupBox _gbBotoes;
        [AccessedThroughProperty("Panel4")]
        private Panel _Panel4;
        [AccessedThroughProperty("tabForm")]
        private TabControl _tabForm;
        [AccessedThroughProperty("TabPage1")]
        private TabPage _TabPage1;
        [AccessedThroughProperty("TabPage2")]
        private TabPage _TabPage2;
        [AccessedThroughProperty("rbLevelMax")]
        private RadioButton _rbLevelMax;
        [AccessedThroughProperty("rbLevelMin")]
        private RadioButton _rbLevelMin;
        [AccessedThroughProperty("cbLevel")]
        private ComboBox _cbLevel;
        [AccessedThroughProperty("ckAtivo")]
        private CheckBox _ckAtivo;
        [AccessedThroughProperty("imgIcone")]
        private PictureBox _imgIcone;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("txtNome")]
        private TextBox _txtNome;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("lbContNome")]
        private Label _lbContNome;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("btnAbrirArquivo")]
        private ToolStripButton _btnAbrirArquivo;
        [AccessedThroughProperty("diagAbrirArquivo")]
        private OpenFileDialog _diagAbrirArquivo;
        [AccessedThroughProperty("txtIcone")]
        private TextBox _txtIcone;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("ToolStripStatusLabel1")]
        private ToolStripStatusLabel _ToolStripStatusLabel1;
        [AccessedThroughProperty("lbTotalItens")]
        private ToolStripStatusLabel _lbTotalItens;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("txtPreco")]
        private TextBox _txtPreco;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("btnReabrir")]
        private Button _btnReabrir;
        [AccessedThroughProperty("btnNovo")]
        private Button _btnNovo;
        [AccessedThroughProperty("btnRemover")]
        private Button _btnRemover;
        [AccessedThroughProperty("btnBackup")]
        private Button _btnBackup;
        [AccessedThroughProperty("btnSalvar")]
        private Button _btnSalvar;
        [AccessedThroughProperty("cbTipo")]
        private ComboBox _cbTipo;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("ckNew")]
        private CheckBox _ckNew;
        [AccessedThroughProperty("ckNormal")]
        private CheckBox _ckNormal;
        [AccessedThroughProperty("ckGift")]
        private CheckBox _ckGift;
        [AccessedThroughProperty("ckHot")]
        private CheckBox _ckHot;
        [AccessedThroughProperty("ToolStripStatusLabel2")]
        private ToolStripStatusLabel _ToolStripStatusLabel2;
        [AccessedThroughProperty("lbStatus")]
        private ToolStripStatusLabel _lbStatus;
        [AccessedThroughProperty("Label18")]
        private Label _Label18;
        [AccessedThroughProperty("txtDesconto")]
        private TextBox _txtDesconto;
        [AccessedThroughProperty("Panel2")]
        private Panel _Panel2;
        [AccessedThroughProperty("txtSprite")]
        private TextBox _txtSprite;
        [AccessedThroughProperty("labeladd")]
        private Label _labeladd;
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;
        [AccessedThroughProperty("Label23")]
        private Label _Label23;
        [AccessedThroughProperty("txtSalary")]
        private TextBox _txtSalary;
        [AccessedThroughProperty("Label29")]
        private Label _Label29;
        [AccessedThroughProperty("gbTempoVenda")]
        private GroupBox _gbTempoVenda;
        [AccessedThroughProperty("ckTempoAtivo")]
        private CheckBox _ckTempoAtivo;
        [AccessedThroughProperty("dtTermino")]
        private DateTimePicker _dtTermino;
        [AccessedThroughProperty("dtInicio")]
        private DateTimePicker _dtInicio;
        [AccessedThroughProperty("Label28")]
        private Label _Label28;
        [AccessedThroughProperty("Label27")]
        private Label _Label27;
        [AccessedThroughProperty("ckDesativado")]
        private CheckBox _ckDesativado;
        [AccessedThroughProperty("ListaItem")]
        private DataGridView _ListaItem;
        [AccessedThroughProperty("diagSalvarArquivo")]
        private SaveFileDialog _diagSalvarArquivo;
        [AccessedThroughProperty("menuSalvarComo")]
        private ToolStripButton _menuSalvarComo;
        [AccessedThroughProperty("PictureBox2")]
        private PictureBox _PictureBox2;
        [AccessedThroughProperty("lbArquivo")]
        private Label _lbArquivo;
        [AccessedThroughProperty("ToolStripStatusLabel4")]
        private ToolStripStatusLabel _ToolStripStatusLabel4;
        [AccessedThroughProperty("lbIndices")]
        private ToolStripStatusLabel _lbIndices;
        [AccessedThroughProperty("pbStatus")]
        private ToolStripProgressBar _pbStatus;
        [AccessedThroughProperty("menuGerarSql")]
        private ToolStripButton _menuGerarSql;
        [AccessedThroughProperty("txtTypeID")]
        private TextBox _txtTypeID;
        [AccessedThroughProperty("diagSalvarSql")]
        private SaveFileDialog _diagSalvarSql;
        [AccessedThroughProperty("menuMassa")]
        private ToolStripDropDownButton _menuMassa;
        [AccessedThroughProperty("menuBackup")]
        private ToolStripButton _menuBackup;
        [AccessedThroughProperty("AlterarPre\x00e7oToolStripMenuItem")]
        private ToolStripMenuItem toolStripMenuItem_0;
        [AccessedThroughProperty("DesativarTodosToolStripMenuItem")]
        private ToolStripMenuItem _DesativarTodosToolStripMenuItem;
        [AccessedThroughProperty("AtivarTodosToolStripMenuItem")]
        private ToolStripMenuItem _AtivarTodosToolStripMenuItem;
        [AccessedThroughProperty("MudarMarca\x00e7\x00e3oToolStripMenuItem")]
        private ToolStripMenuItem toolStripMenuItem_1;
        [AccessedThroughProperty("RemoverMarca\x00e7\x00e3oToolStripMenuItem")]
        private ToolStripMenuItem toolStripMenuItem_2;
        [AccessedThroughProperty("LevelMinimoToolStripMenuItem")]
        private ToolStripMenuItem _LevelMinimoToolStripMenuItem;
        [AccessedThroughProperty("ToolStripMenuItem1")]
        private ToolStripSeparator _ToolStripMenuItem1;
        [AccessedThroughProperty("ApagarTodosToolStripMenuItem")]
        private ToolStripMenuItem _ApagarTodosToolStripMenuItem;
        [AccessedThroughProperty("bwSalvar")]
        private BackgroundWorker _bwSalvar;
        [AccessedThroughProperty("bwGerarSql")]
        private BackgroundWorker _bwGerarSql;
        [AccessedThroughProperty("PictureBox4")]
        private PictureBox _PictureBox4;
        [AccessedThroughProperty("Label33")]
        private Label _Label33;
        [AccessedThroughProperty("ImageList1")]
        private ImageList _ImageList1;
        [AccessedThroughProperty("imgStatus")]
        private PictureBox _imgStatus;
        [AccessedThroughProperty("ComboBox2")]
        private ComboBox _ComboBox2;
        [AccessedThroughProperty("Label37")]
        private Label _Label37;
        [AccessedThroughProperty("Label39")]
        private Label _Label39;
        [AccessedThroughProperty("menuTypeid")]
        private ToolStripButton _menuTypeid;
        [AccessedThroughProperty("ImageList2")]
        private ImageList _ImageList2;
        [AccessedThroughProperty("menuDividir")]
        private ToolStripDropDownButton _menuDividir;
        [AccessedThroughProperty("DividirArquivoToolStripMenuItem")]
        private ToolStripMenuItem _DividirArquivoToolStripMenuItem;
        [AccessedThroughProperty("UnirArquivoToolStripMenuItem")]
        private ToolStripMenuItem _UnirArquivoToolStripMenuItem;
        [AccessedThroughProperty("diagPasta")]
        private FolderBrowserDialog _diagPasta;
        [AccessedThroughProperty("AlterarDescontoToolStripMenuItem")]
        private ToolStripMenuItem _AlterarDescontoToolStripMenuItem;
        [AccessedThroughProperty("btnVerificarTYPEID")]
        private Button _btnVerificarTYPEID;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("menuGerarCache")]
        private ToolStripButton _menuGerarCache;
        [AccessedThroughProperty("imgPersonagem")]
        private PictureBox _imgPersonagem;
        [AccessedThroughProperty("Label36")]
        private Label _Label36;
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("Panel10")]
        private Panel _Panel10;
        [AccessedThroughProperty("attCurva")]
        private NumericUpDown _attCurva;
        [AccessedThroughProperty("attSpin")]
        private NumericUpDown _attSpin;
        [AccessedThroughProperty("attPrecisao")]
        private NumericUpDown _attPrecisao;
        [AccessedThroughProperty("attControle")]
        private NumericUpDown _attControle;
        [AccessedThroughProperty("attForca")]
        private NumericUpDown _attForca;
        [AccessedThroughProperty("Panel9")]
        private Panel _Panel9;
        [AccessedThroughProperty("barraCurva")]
        private Panel _barraCurva;
        [AccessedThroughProperty("Panel8")]
        private Panel _Panel8;
        [AccessedThroughProperty("barraSpin")]
        private Panel _barraSpin;
        [AccessedThroughProperty("Panel7")]
        private Panel _Panel7;
        [AccessedThroughProperty("barraPrecisao")]
        private Panel _barraPrecisao;
        [AccessedThroughProperty("Panel6")]
        private Panel _Panel6;
        [AccessedThroughProperty("barraControle")]
        private Panel _barraControle;
        [AccessedThroughProperty("Panel5")]
        private Panel _Panel5;
        [AccessedThroughProperty("barraForca")]
        private Panel _barraForca;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("Label14")]
        private Label _Label14;
        [AccessedThroughProperty("Label13")]
        private Label _Label13;
        [AccessedThroughProperty("Label12")]
        private Label _Label12;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label15")]
        private Label _Label15;
        public string Arquivo;
        private Caddie oIff;
        private List<List<string>> ls;
        public List<Caddie> lsItens;
        public List<Caddie> lsTemp;
        public byte[] bStart;
        private bool Alterado;
        private BindingSource bs;
        private int lastRow;
        public long qtdItem;
        private string arquivog;
        private string caminho;

        public frmCaddie()
        {
            base.Load += new EventHandler(this.frmClubSet_Load);
            base.FormClosing += new FormClosingEventHandler(this.frmClubSet_FormClosing);
            __ENCAddToList(this);
            this.Arquivo = "";
            this.lsItens = new List<Caddie>();
            this.lsTemp = new List<Caddie>();
            this.Alterado = false;
            this.lastRow = 0;
            this.qtdItem = 0L;
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            lock (__ENCList)
            {
                if (__ENCList.Count == __ENCList.Capacity)
                {
                    int index = 0;
                    int num3 = __ENCList.Count - 1;
                    int num2 = 0;
                    while (true)
                    {
                        int num4 = num3;
                        if (num2 > num4)
                        {
                            __ENCList.RemoveRange(index, __ENCList.Count - index);
                            __ENCList.Capacity = __ENCList.Count;
                            break;
                        }
                        WeakReference reference = __ENCList[num2];
                        if (reference.IsAlive)
                        {
                            if (num2 != index)
                            {
                                __ENCList[index] = __ENCList[num2];
                            }
                            index++;
                        }
                        num2++;
                    }
                }
                __ENCList.Add(new WeakReference(value));
            }
        }

        [CompilerGenerated, DebuggerStepThrough]
        private void _Lambda$__5(object sender, EventArgs e)
        {
            this.Alterou();
        }

        [DebuggerStepThrough, CompilerGenerated]
        private void _Lambda$__6(object sender, EventArgs e)
        {
            this.Alterou();
        }

        [DebuggerStepThrough, CompilerGenerated]
        private void _Lambda$__7(object sender, EventArgs e)
        {
            this.Alterou();
        }

        [CompilerGenerated, DebuggerStepThrough]
        private void _Lambda$__8(object sender, EventArgs e)
        {
            this.Alterou();
        }

        private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyProject.Forms.frmItemMassaDesconto.Show();
        }

        private void Alterou()
        {
            this.Alterado = true;
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraControle, sender);
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraCurva, sender);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraForca, sender);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraPrecisao, sender);
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraSpin, sender);
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new List<Caddie>();
                this.lsTemp = new List<Caddie>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                MySettingsProperty.Settings.ArquivoIff = this.Arquivo;
                try
                {
                    this.ls = Util.dividirArquivo((List<string>) Util.lerArquivo(this.Arquivo, ref this.bStart, ref this.qtdItem, 200), 200);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ProjectData.ClearProjectError();
                    return;
                }
                this.lsItens = new List<Caddie>();
                int num2 = this.ls.Count - 1;
                int num = 0;
                while (true)
                {
                    int num3 = num2;
                    if (num > num3)
                    {
                        this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                        this.nomeArquivo();
                        this.ListaItem.DataSource = null;
                        this.CarregarGrid(this.lsTemp);
                        this.lbIndices.Text = Conversions.ToString(this.qtdItem);
                        this.ls.Clear();
                        break;
                    }
                    this.oIff = new Caddie(this.ls[num]);
                    this.lsItens.Add(this.oIff);
                    num++;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Caddie item = new Caddie();
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                item = (Caddie) this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value)].Clone();
                try
                {
                    this.lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(this.ListaItem.SelectedRows[0].Cells[0].Value, 1)), item);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lsTemp.Insert(Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value), item);
                    ProjectData.ClearProjectError();
                }
                this.CarregarGrid(this.lsTemp);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja adicionar um novo item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Caddie item = new Caddie {
                    ItemName = "[NOVO ITEM]"
                };
                Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                try
                {
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex + 1, item);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex, item);
                    ProjectData.ClearProjectError();
                }
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                this.CarregarGrid(this.lsTemp);
                try
                {
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                    this.ListaItem.Rows[this.lastRow].Selected = true;
                }
                catch (Exception exception3)
                {
                    Exception ex = exception3;
                    ProjectData.SetProjectError(ex);
                    Exception local4 = ex;
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow - 1;
                    this.ListaItem.Rows[this.lastRow - 1].Selected = true;
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            this.salvarAlteracoes();
            this.pintarLinhas();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.ListaItem.SelectedRows.Count <= 1)
            {
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", this.ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num2 = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                    this.lsTemp.Remove(this.lsTemp[num2]);
                    this.CarregarGrid(this.lsTemp);
                }
            }
            else
            {
                this.lastRow = this.ListaItem.SelectedRows[0].Index - 1;
                if (MessageBox.Show("Deseja remover os " + Conversions.ToString(this.ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num3 = this.ListaItem.SelectedRows.Count - 1;
                    int num = 0;
                    while (true)
                    {
                        int num4 = num3;
                        if (num > num4)
                        {
                            this.CarregarGrid(this.lsTemp);
                            break;
                        }
                        try
                        {
                            this.lsTemp.Remove(this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[num].Cells[0].Value)]);
                        }
                        catch (Exception exception1)
                        {
                            Exception ex = exception1;
                            ProjectData.SetProjectError(ex);
                            Exception local2 = ex;
                            ProjectData.ClearProjectError();
                        }
                        num++;
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.bs.Filter = "";
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
            this.salvarAlteracoes();
            this.btnSalvar.Enabled = false;
            this.ToolStrip1.Enabled = false;
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.bwSalvar.RunWorkerAsync();
        }

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (this.verificarTYPEID(0))
            {
                MessageBox.Show("Este TYPEID j\x00e1 est\x00e1 em uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID dispon\x00edvel para uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.White;
            }
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker) sender;
            this.gerarSql(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Value = e.ProgressPercentage;
            this.lbStatus.Text = "Gerando arquivo SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Value = 0;
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbStatus.Text = "parado";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker) sender;
            this.lbStatus.Text = "Salvando...";
            this.salvar(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Blocks;
            this.pbStatus.Value = 0;
            this.lbStatus.Text = "parado";
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            this.nomeArquivo();
        }

        public void CarregarGrid(List<Caddie> Lista)
        {
            List<string> list1 = new List<string>();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            int num = 0;
            int num2 = 0;
            int num6 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                int num8 = num6;
                if (num3 > num8)
                {
                    this.ListaItem.DataSource = null;
                    this.bs = new BindingSource();
                    this.bs.DataSource = table;
                    this.ListaItem.DataMember = table.TableName;
                    this.ListaItem.DataSource = this.bs;
                    this.lbTotalItens.Text = Conversions.ToString(this.ListaItem.Rows.Count);
                    this.ListaItem.Columns[0].Width = 0x2d;
                    this.ListaItem.Columns[2].Width = 30;
                    this.ListaItem.Columns[5].Width = 30;
                    this.ListaItem.Columns[0].ValueType = typeof(int);
                    this.ListaItem.Columns[2].HeaderText = "   ";
                    this.ListaItem.Columns[5].HeaderText = "   ";
                    int num7 = this.ListaItem.Rows.Count - 1;
                    int num5 = 0;
                    while (true)
                    {
                        num8 = num7;
                        if (num5 > num8)
                        {
                            this.ListaItem.Columns[3].Visible = false;
                            this.ListaItem.Columns[4].Visible = false;
                            this.ListaItem.Columns[6].Visible = false;
                            this.filtrar();
                            try
                            {
                                this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                                this.ListaItem.Rows[this.lastRow].Selected = true;
                            }
                            catch (Exception exception3)
                            {
                                Exception ex = exception3;
                                ProjectData.SetProjectError(ex);
                                Exception local4 = ex;
                                ProjectData.ClearProjectError();
                            }
                            this.pintarLinhas();
                            return;
                        }
                        this.ListaItem.Rows[num5].Selected = false;
                        num5++;
                    }
                }
                this.oIff = Lista[num3];
                Image image = (this.oIff.isValid != 1) ? EditorIFF.My.Resources.Resources.delete1 : EditorIFF.My.Resources.Resources.accept1;
                Image image2 = (this.oIff.shopFlag != 1) ? ((this.oIff.shopFlag != 2) ? EditorIFF.My.Resources.Resources.eye__minus : EditorIFF.My.Resources.Resources.Pang) : EditorIFF.My.Resources.Resources.points;
                num2 = 0;
                int num4 = 0;
                try
                {
                    num4 = Conversions.ToInteger(this.ListaItem["Alterado", num].Value);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    num4 = 0;
                    ProjectData.ClearProjectError();
                }
                object[] values = new object[] { num3, this.oIff.ItemName.Replace("\0", ""), image, num2, this.oIff.isValid, image2, num4 };
                table.Rows.Add(values);
                num++;
                num3++;
            }
        }

        private void carregarImagem(string img, ref PictureBox obj)
        {
            try
            {
                obj.Image = EditorIFF.My.Resources.Resources.ajax_loader;
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                ProjectData.ClearProjectError();
            }
            try
            {
                obj.ImageLocation = img;
            }
            catch (Exception exception3)
            {
                Exception ex = exception3;
                ProjectData.SetProjectError(ex);
                Exception local4 = ex;
                obj.Image = EditorIFF.My.Resources.Resources._error;
                ProjectData.ClearProjectError();
            }
        }

        private void CarregarItem()
        {
            if (this.ListaItem.SelectedCells[0].RowIndex > -1)
            {
                DateTime time;
                DateTime time2;
                int num2 = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                int lvlReq = 0;
                this.txtNome.Text = this.lsTemp[num2].ItemName;
                this.txtTypeID.Text = Conversions.ToString(this.lsTemp[num2].ItemID);
                this.ckAtivo.Checked = this.lsTemp[num2].isValid != 0;
                this.txtIcone.Text = this.lsTemp[num2].Icon;
                this.txtPreco.Text = Conversions.ToString(this.lsTemp[num2].ItemPrice);
                this.txtDesconto.Text = Conversions.ToString(this.lsTemp[num2].DiscountPrice);
                this.attForca.Value = new decimal(this.lsTemp[num2].statForce);
                this.attControle.Value = new decimal(this.lsTemp[num2].statControl);
                this.attPrecisao.Value = new decimal(this.lsTemp[num2].statImpact);
                this.attSpin.Value = new decimal(this.lsTemp[num2].statSpin);
                this.attCurva.Value = new decimal(this.lsTemp[num2].statCurve);
                this.txtSprite.Text = this.lsTemp[num2].SpriteName;
                this.txtSalary.Text = Conversions.ToString(this.lsTemp[num2].Salary);
                if (this.lsTemp[num2].lvlReq <= 0x48)
                {
                    lvlReq = this.lsTemp[num2].lvlReq;
                    this.rbLevelMin.Checked = true;
                }
                else
                {
                    lvlReq = this.lsTemp[num2].lvlReq - 0x80;
                    this.rbLevelMax.Checked = true;
                }
                this.cbLevel.SelectedIndex = lvlReq;
                string str = Util.ByteToString(this.lsTemp[num2].moneyFlag);
                Util.ByteToString(this.lsTemp[num2].shopFlag);
                this.cbTipo.SelectedIndex = this.lsTemp[num2].shopFlag;
                if (str == "01")
                {
                    this.ckNormal.Checked = true;
                    this.ckGift.Checked = true;
                }
                else if (str == "03")
                {
                    this.ckGift.Checked = false;
                    this.ckNormal.Checked = true;
                }
                else if (str == "13")
                {
                    this.ckGift.Checked = false;
                    this.ckNew.Checked = true;
                }
                else if (str == "23")
                {
                    this.ckGift.Checked = false;
                    this.ckHot.Checked = true;
                }
                else if (str == "11")
                {
                    this.ckNew.Checked = true;
                    this.ckGift.Checked = true;
                }
                else if (str != "21")
                {
                    this.ckDesativado.Checked = true;
                }
                else
                {
                    this.ckHot.Checked = true;
                    this.ckGift.Checked = true;
                }
                Caddie caddie = this.lsTemp[num2];
                caddie = null;
                Caddie caddie2 = this.lsTemp[num2];
                caddie2 = null;
                string[] strArray = new string[] { Conversions.ToString((int) caddie.fDay), "/", Conversions.ToString((int) caddie.fMonth), "/", Conversions.ToString((int) caddie.fYear), " ", Conversions.ToString((int) caddie.fHour), ":", Conversions.ToString((int) caddie.fMinute) };
                strArray[9] = ":";
                strArray[10] = Conversions.ToString((int) caddie.fSecond);
                DateTime.TryParse(string.Concat(strArray), out time);
                strArray = new string[] { Conversions.ToString((int) caddie2.tDay), "/", Conversions.ToString((int) caddie2.tMonth), "/", Conversions.ToString((int) caddie2.tYear), " ", Conversions.ToString((int) caddie2.tHour), ":", Conversions.ToString((int) caddie2.tMinute) };
                strArray[9] = ":";
                strArray[10] = Conversions.ToString((int) caddie2.tSecond);
                DateTime.TryParse(string.Concat(strArray), out time2);
                try
                {
                    this.dtInicio.Value = time;
                    this.dtTermino.Value = time2;
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.dtInicio.Value = DateAndTime.Now.AddYears(-3);
                    this.dtTermino.Value = DateAndTime.Now.AddYears(-3);
                    ProjectData.ClearProjectError();
                }
                this.ckTempoAtivo.Checked = (DateTime.Compare(time, DateAndTime.Now) < 0) & (DateTime.Compare(time2, DateAndTime.Now) > 0);
            }
            this.Alterado = false;
            try
            {
                Conversions.ToInteger(Operators.AddObject(this.ListaItem.Rows[this.ListaItem.SelectedRows[0].Index].Cells[3].Value, 1));
            }
            catch (Exception exception3)
            {
                Exception ex = exception3;
                ProjectData.SetProjectError(ex);
                Exception local4 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void ckDesativado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckDesativado.Checked)
            {
                this.ckNew.Checked = false;
                this.ckNormal.Checked = false;
                this.ckHot.Checked = false;
                this.ckGift.Checked = false;
                this.ckNew.Enabled = false;
                this.ckNormal.Enabled = false;
                this.ckHot.Enabled = false;
                this.ckGift.Enabled = false;
            }
            else
            {
                this.ckNew.Checked = true;
                this.ckNormal.Checked = true;
                this.ckHot.Checked = true;
                this.ckGift.Checked = true;
                this.ckNew.Enabled = true;
                this.ckNormal.Enabled = true;
                this.ckHot.Enabled = true;
                this.ckGift.Enabled = true;
            }
        }

        private void ckHot_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckHot.Checked)
            {
                this.ckNew.Checked = false;
                this.ckNormal.Checked = false;
                this.ckDesativado.Checked = false;
            }
        }

        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckNew.Checked)
            {
                this.ckHot.Checked = false;
                this.ckNormal.Checked = false;
                this.ckDesativado.Checked = false;
            }
        }

        private void ckNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckNormal.Checked)
            {
                this.ckHot.Checked = false;
                this.ckNew.Checked = false;
                this.ckDesativado.Checked = false;
            }
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            this.gbTempoVenda.Enabled = this.ckTempoAtivo.Checked;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrar();
            this.imgPersonagem.Image = this.ImageList1.Images[this.ComboBox1.SelectedIndex];
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrar();
            this.imgStatus.Image = (this.ComboBox2.SelectedIndex != 0) ? ((this.ComboBox2.SelectedIndex != 1) ? this.ImageList2.Images[2] : this.ImageList2.Images[1]) : this.ImageList2.Images[0];
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (((!disposing || (this.components == null)) ? 0 : 1) != 0)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public void filtrar()
        {
            try
            {
                int num = 0;
                num = (this.ComboBox2.SelectedIndex != 1) ? 0 : 1;
                if (!(((this.ComboBox1.SelectedIndex > 0) & (this.ComboBox2.SelectedIndex > 0)) & (this.txtPesquisa.Text.Length > 0)))
                {
                    this.bs.Filter = !((this.ComboBox1.SelectedIndex > 0) & (this.txtPesquisa.Text.Length > 0)) ? (!((this.ComboBox2.SelectedIndex > 0) & (this.txtPesquisa.Text.Length > 0)) ? (!((this.ComboBox1.SelectedIndex > 0) & (this.ComboBox2.SelectedIndex > 0)) ? ((this.txtPesquisa.Text.Length <= 0) ? ((this.ComboBox1.SelectedIndex <= 0) ? ((this.ComboBox2.SelectedIndex <= 0) ? "" : ("Status2 = " + Conversions.ToString(num))) : ("Personagem = " + Conversions.ToString((int) (this.ComboBox1.SelectedIndex - 1)))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%'")) : ("Personagem = " + Conversions.ToString((int) (this.ComboBox1.SelectedIndex - 1)) + " AND Status2 = " + Conversions.ToString(num))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString((int) (this.ComboBox1.SelectedIndex - 1)));
                }
                else
                {
                    string[] strArray = new string[] { "Item LIKE '%", this.txtPesquisa.Text, "%' AND Personagem = ", Conversions.ToString((int) (this.ComboBox1.SelectedIndex - 1)), " AND Status2 = ", Conversions.ToString(num) };
                    this.bs.Filter = string.Concat(strArray);
                }
                this.Label33.Text = Conversions.ToString(this.bs.Count);
                this.ListaItem.Columns[0].Width = 0x2d;
                this.ListaItem.Columns[2].Width = 30;
                this.ListaItem.Columns[5].Width = 30;
                this.ListaItem.Columns[0].ValueType = typeof(int);
                this.ListaItem.Columns[2].HeaderText = "   ";
                this.ListaItem.Columns[5].HeaderText = "   ";
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void frmClubSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execu\x00e7\x00e3o, \x00e9 necess\x00e1rio aguardar o t\x00e9rmino destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            MyProject.Forms.frmPrincipal.Show();
        }

        private void frmClubSet_Load(object sender, EventArgs e)
        {
            if (this.Arquivo == "")
            {
                goto TR_0002;
            }
            else
            {
                try
                {
                    this.ls = Util.dividirArquivo((List<string>) Util.lerArquivo(this.Arquivo, ref this.bStart, ref this.qtdItem, 200), 200);
                    this.lsItens = new List<Caddie>();
                    int num3 = this.ls.Count - 1;
                    int num2 = 0;
                    while (true)
                    {
                        int num4 = num3;
                        if (num2 > num4)
                        {
                            this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                            int length = 0x19;
                            this.lbArquivo.Text = (Strings.Len(this.Arquivo) <= 0x19) ? this.Arquivo : ("..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length));
                            this.ListaItem.DataSource = null;
                            this.CarregarGrid(this.lsTemp);
                            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
                            break;
                        }
                        this.oIff = new Caddie(this.ls[num2]);
                        this.lsItens.Add(this.oIff);
                        num2++;
                    }
                    goto TR_0002;
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    Interaction.MsgBox("Tipo de arquivo descnhecido", MsgBoxStyle.ApplicationModal, null);
                    ProjectData.ClearProjectError();
                }
            }
            return;
        TR_0002:
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
        }

        private void gerarBarra(Control Barra, object sender1)
        {
            // Invalid method body.
        }

        public void gerarSql(BackgroundWorker BW)
        {
            if (this.Arquivo == null)
            {
                MessageBox.Show("Arquivo inv\x00e1lido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.Caddie_gerarSql(this.lsTemp, this.Arquivo, ref BW)))
            {
                MessageBox.Show("SQL gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Arquivo salvo com erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmCaddie));
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.StatusStrip1 = new StatusStrip();
            this.ToolStripStatusLabel1 = new ToolStripStatusLabel();
            this.lbTotalItens = new ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new ToolStripStatusLabel();
            this.lbIndices = new ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new ToolStripStatusLabel();
            this.lbStatus = new ToolStripStatusLabel();
            this.pbStatus = new ToolStripProgressBar();
            this.ToolStrip1 = new ToolStrip();
            this.btnAbrirArquivo = new ToolStripButton();
            this.menuSalvarComo = new ToolStripButton();
            this.menuGerarSql = new ToolStripButton();
            this.menuTypeid = new ToolStripButton();
            this.menuBackup = new ToolStripButton();
            this.menuDividir = new ToolStripDropDownButton();
            this.DividirArquivoToolStripMenuItem = new ToolStripMenuItem();
            this.UnirArquivoToolStripMenuItem = new ToolStripMenuItem();
            this.menuMassa = new ToolStripDropDownButton();
            this.ToolStripMenuItem_0 = new ToolStripMenuItem();
            this.AlterarDescontoToolStripMenuItem = new ToolStripMenuItem();
            this.DesativarTodosToolStripMenuItem = new ToolStripMenuItem();
            this.AtivarTodosToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripMenuItem_1 = new ToolStripMenuItem();
            this.ToolStripMenuItem_2 = new ToolStripMenuItem();
            this.LevelMinimoToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripMenuItem1 = new ToolStripSeparator();
            this.ApagarTodosToolStripMenuItem = new ToolStripMenuItem();
            this.menuGerarCache = new ToolStripButton();
            this.SplitContainer1 = new SplitContainer();
            this.Panel3 = new Panel();
            this.ListaItem = new DataGridView();
            this.Panel2 = new Panel();
            this.PictureBox2 = new PictureBox();
            this.lbArquivo = new Label();
            this.Panel1 = new Panel();
            this.Label39 = new Label();
            this.imgStatus = new PictureBox();
            this.PictureBox4 = new PictureBox();
            this.PictureBox1 = new PictureBox();
            this.ComboBox2 = new ComboBox();
            this.txtPesquisa = new TextBox();
            this.Label33 = new Label();
            this.Label37 = new Label();
            this.Panel4 = new Panel();
            this.tabForm = new TabControl();
            this.TabPage1 = new TabPage();
            this.btnVerificarTYPEID = new Button();
            this.ckTempoAtivo = new CheckBox();
            this.GroupBox1 = new GroupBox();
            this.ckNew = new CheckBox();
            this.ckDesativado = new CheckBox();
            this.ckNormal = new CheckBox();
            this.ckHot = new CheckBox();
            this.ckGift = new CheckBox();
            this.Label29 = new Label();
            this.Label2 = new Label();
            this.rbLevelMax = new RadioButton();
            this.rbLevelMin = new RadioButton();
            this.cbLevel = new ComboBox();
            this.cbTipo = new ComboBox();
            this.ckAtivo = new CheckBox();
            this.imgIcone = new PictureBox();
            this.txtIcone = new TextBox();
            this.txtTypeID = new TextBox();
            this.Label6 = new Label();
            this.Label8 = new Label();
            this.txtDesconto = new TextBox();
            this.txtPreco = new TextBox();
            this.txtNome = new TextBox();
            this.Label7 = new Label();
            this.Label3 = new Label();
            this.lbContNome = new Label();
            this.Label18 = new Label();
            this.Label4 = new Label();
            this.Label1 = new Label();
            this.gbTempoVenda = new GroupBox();
            this.dtTermino = new DateTimePicker();
            this.dtInicio = new DateTimePicker();
            this.Label28 = new Label();
            this.Label27 = new Label();
            this.TabPage2 = new TabPage();
            this.imgPersonagem = new PictureBox();
            this.Label36 = new Label();
            this.ComboBox1 = new ComboBox();
            this.GroupBox3 = new GroupBox();
            this.Label23 = new Label();
            this.txtSalary = new TextBox();
            this.labeladd = new Label();
            this.txtSprite = new TextBox();
            this.gbBotoes = new GroupBox();
            this.btnReabrir = new Button();
            this.btnNovo = new Button();
            this.btnRemover = new Button();
            this.btnBackup = new Button();
            this.btnSalvar = new Button();
            this.bwSalvar = new BackgroundWorker();
            this.bwGerarSql = new BackgroundWorker();
            this.ImageList1 = new ImageList(this.components);
            this.ImageList2 = new ImageList(this.components);
            this.diagSalvarArquivo = new SaveFileDialog();
            this.diagAbrirArquivo = new OpenFileDialog();
            this.diagSalvarSql = new SaveFileDialog();
            this.diagPasta = new FolderBrowserDialog();
            this.ToolTip1 = new ToolTip(this.components);
            this.Label15 = new Label();
            this.Label10 = new Label();
            this.Label11 = new Label();
            this.Label12 = new Label();
            this.Label13 = new Label();
            this.Label14 = new Label();
            this.Label9 = new Label();
            this.Panel5 = new Panel();
            this.barraForca = new Panel();
            this.Panel6 = new Panel();
            this.barraControle = new Panel();
            this.Panel7 = new Panel();
            this.barraPrecisao = new Panel();
            this.Panel8 = new Panel();
            this.barraSpin = new Panel();
            this.Panel9 = new Panel();
            this.barraCurva = new Panel();
            this.attForca = new NumericUpDown();
            this.attControle = new NumericUpDown();
            this.attPrecisao = new NumericUpDown();
            this.attSpin = new NumericUpDown();
            this.attCurva = new NumericUpDown();
            this.Panel10 = new Panel();
            this.StatusStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((ISupportInitialize) this.ListaItem).BeginInit();
            this.Panel2.SuspendLayout();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            this.Panel1.SuspendLayout();
            ((ISupportInitialize) this.imgStatus).BeginInit();
            ((ISupportInitialize) this.PictureBox4).BeginInit();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.Panel4.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((ISupportInitialize) this.imgIcone).BeginInit();
            this.gbTempoVenda.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((ISupportInitialize) this.imgPersonagem).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.gbBotoes.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel9.SuspendLayout();
            this.attForca.BeginInit();
            this.attControle.BeginInit();
            this.attPrecisao.BeginInit();
            this.attSpin.BeginInit();
            this.attCurva.BeginInit();
            this.Panel10.SuspendLayout();
            this.SuspendLayout();
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.ToolStripStatusLabel1, this.lbTotalItens, this.ToolStripStatusLabel4, this.lbIndices, this.ToolStripStatusLabel2, this.lbStatus, this.pbStatus };
            this.StatusStrip1.Items.AddRange(toolStripItems);
            Point point2 = new Point(0, 0x20e);
            this.StatusStrip1.Location = point2;
            this.StatusStrip1.Name = "StatusStrip1";
            Size size2 = new Size(0x329, 0x16);
            this.StatusStrip1.Size = size2;
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "StatusStrip1";
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            size2 = new Size(0x51, 0x11);
            this.ToolStripStatusLabel1.Size = size2;
            this.ToolStripStatusLabel1.Text = "Total de Itens:";
            this.lbTotalItens.Name = "lbTotalItens";
            size2 = new Size(13, 0x11);
            this.lbTotalItens.Size = size2;
            this.lbTotalItens.Text = "0";
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            size2 = new Size(0x2f, 0x11);
            this.ToolStripStatusLabel4.Size = size2;
            this.ToolStripStatusLabel4.Text = "Indices:";
            this.lbIndices.Name = "lbIndices";
            size2 = new Size(13, 0x11);
            this.lbIndices.Size = size2;
            this.lbIndices.Text = "0";
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            size2 = new Size(0x1ee, 0x11);
            this.ToolStripStatusLabel2.Size = size2;
            this.ToolStripStatusLabel2.Spring = true;
            this.lbStatus.Name = "lbStatus";
            size2 = new Size(0x2c, 0x11);
            this.lbStatus.Size = size2;
            this.lbStatus.Text = "Parado";
            this.pbStatus.Name = "pbStatus";
            size2 = new Size(100, 0x10);
            this.pbStatus.Size = size2;
            this.pbStatus.Style = ProgressBarStyle.Continuous;
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = Color.White;
            toolStripItems = new ToolStripItem[] { this.btnAbrirArquivo, this.menuSalvarComo, this.menuGerarSql, this.menuTypeid, this.menuBackup, this.menuDividir, this.menuMassa, this.menuGerarCache };
            this.ToolStrip1.Items.AddRange(toolStripItems);
            point2 = new Point(0, 0);
            this.ToolStrip1.Location = point2;
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = ToolStripRenderMode.Professional;
            size2 = new Size(0x329, 40);
            this.ToolStrip1.Size = size2;
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            this.btnAbrirArquivo.Image = (Image) manager.GetObject("btnAbrirArquivo.Image");
            this.btnAbrirArquivo.ImageScaling = ToolStripItemImageScaling.None;
            this.btnAbrirArquivo.ImageTransparentColor = Color.Magenta;
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            size2 = new Size(0x24, 0x25);
            this.btnAbrirArquivo.Size = size2;
            this.btnAbrirArquivo.ToolTipText = "Abrir arquivo";
            this.menuSalvarComo.Enabled = false;
            this.menuSalvarComo.Image = EditorIFF.My.Resources.Resources.disk_multiple;
            this.menuSalvarComo.ImageScaling = ToolStripItemImageScaling.None;
            this.menuSalvarComo.ImageTransparentColor = Color.Magenta;
            this.menuSalvarComo.Name = "menuSalvarComo";
            size2 = new Size(0x24, 0x25);
            this.menuSalvarComo.Size = size2;
            this.menuSalvarComo.ToolTipText = "Salvar como";
            this.menuGerarSql.Enabled = false;
            this.menuGerarSql.Image = EditorIFF.My.Resources.Resources.database_lightning;
            this.menuGerarSql.ImageScaling = ToolStripItemImageScaling.None;
            this.menuGerarSql.ImageTransparentColor = Color.Magenta;
            this.menuGerarSql.Name = "menuGerarSql";
            size2 = new Size(0x24, 0x25);
            this.menuGerarSql.Size = size2;
            this.menuGerarSql.ToolTipText = "Gerar arquivo de SQL";
            this.menuTypeid.Enabled = false;
            this.menuTypeid.Image = EditorIFF.My.Resources.Resources.textfield_key;
            this.menuTypeid.ImageScaling = ToolStripItemImageScaling.None;
            this.menuTypeid.ImageTransparentColor = Color.Magenta;
            this.menuTypeid.Name = "menuTypeid";
            size2 = new Size(0x24, 0x25);
            this.menuTypeid.Size = size2;
            this.menuTypeid.ToolTipText = "Gerar TYPEID";
            this.menuTypeid.Visible = false;
            this.menuBackup.Enabled = false;
            this.menuBackup.Image = EditorIFF.My.Resources.Resources.backup_manager;
            this.menuBackup.ImageScaling = ToolStripItemImageScaling.None;
            this.menuBackup.ImageTransparentColor = Color.Magenta;
            this.menuBackup.Name = "menuBackup";
            size2 = new Size(0x24, 0x25);
            this.menuBackup.Size = size2;
            this.menuBackup.ToolTipText = "Backup";
            this.menuDividir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripItems = new ToolStripItem[] { this.DividirArquivoToolStripMenuItem, this.UnirArquivoToolStripMenuItem };
            this.menuDividir.DropDownItems.AddRange(toolStripItems);
            this.menuDividir.Enabled = false;
            this.menuDividir.Image = EditorIFF.My.Resources.Resources.plugin;
            this.menuDividir.ImageScaling = ToolStripItemImageScaling.None;
            this.menuDividir.ImageTransparentColor = Color.Magenta;
            this.menuDividir.Name = "menuDividir";
            size2 = new Size(0x2d, 0x25);
            this.menuDividir.Size = size2;
            this.menuDividir.ToolTipText = "Dividir Arquivo";
            this.menuDividir.Visible = false;
            this.DividirArquivoToolStripMenuItem.Image = EditorIFF.My.Resources.Resources.plugin_delete;
            this.DividirArquivoToolStripMenuItem.Name = "DividirArquivoToolStripMenuItem";
            size2 = new Size(0x97, 0x16);
            this.DividirArquivoToolStripMenuItem.Size = size2;
            this.DividirArquivoToolStripMenuItem.Text = "Dividir arquivo";
            this.UnirArquivoToolStripMenuItem.Image = EditorIFF.My.Resources.Resources.plugin_add;
            this.UnirArquivoToolStripMenuItem.Name = "UnirArquivoToolStripMenuItem";
            size2 = new Size(0x97, 0x16);
            this.UnirArquivoToolStripMenuItem.Size = size2;
            this.UnirArquivoToolStripMenuItem.Text = "Unir arquivo";
            this.menuMassa.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripItems = new ToolStripItem[] { this.ToolStripMenuItem_0, this.AlterarDescontoToolStripMenuItem, this.DesativarTodosToolStripMenuItem, this.AtivarTodosToolStripMenuItem, this.ToolStripMenuItem_1, this.ToolStripMenuItem_2, this.LevelMinimoToolStripMenuItem, this.ToolStripMenuItem1, this.ApagarTodosToolStripMenuItem };
            this.menuMassa.DropDownItems.AddRange(toolStripItems);
            this.menuMassa.Enabled = false;
            this.menuMassa.Image = EditorIFF.My.Resources.Resources.chart_organisation;
            this.menuMassa.ImageScaling = ToolStripItemImageScaling.None;
            this.menuMassa.ImageTransparentColor = Color.Magenta;
            this.menuMassa.Name = "menuMassa";
            size2 = new Size(0x2d, 0x25);
            this.menuMassa.Size = size2;
            this.menuMassa.Text = "ToolStripDropDownButton1";
            this.menuMassa.ToolTipText = "Opera\x00e7\x00f5es em massa";
            this.menuMassa.Visible = false;
            this.ToolStripMenuItem_0.Image = (Image) manager.GetObject("AlterarPre\x00e7oToolStripMenuItem.Image");
            this.ToolStripMenuItem_0.Name = "AlterarPre\x00e7oToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.ToolStripMenuItem_0.Size = size2;
            this.ToolStripMenuItem_0.Text = "Alterar pre\x00e7o";
            this.AlterarDescontoToolStripMenuItem.Image = EditorIFF.My.Resources.Resources.money_delete;
            this.AlterarDescontoToolStripMenuItem.Name = "AlterarDescontoToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.AlterarDescontoToolStripMenuItem.Size = size2;
            this.AlterarDescontoToolStripMenuItem.Text = "Alterar Desconto";
            this.DesativarTodosToolStripMenuItem.Enabled = false;
            this.DesativarTodosToolStripMenuItem.Image = (Image) manager.GetObject("DesativarTodosToolStripMenuItem.Image");
            this.DesativarTodosToolStripMenuItem.Name = "DesativarTodosToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.DesativarTodosToolStripMenuItem.Size = size2;
            this.DesativarTodosToolStripMenuItem.Text = "Desativar todos";
            this.AtivarTodosToolStripMenuItem.Enabled = false;
            this.AtivarTodosToolStripMenuItem.Image = (Image) manager.GetObject("AtivarTodosToolStripMenuItem.Image");
            this.AtivarTodosToolStripMenuItem.Name = "AtivarTodosToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.AtivarTodosToolStripMenuItem.Size = size2;
            this.AtivarTodosToolStripMenuItem.Text = "Ativar todos";
            this.ToolStripMenuItem_1.Enabled = false;
            this.ToolStripMenuItem_1.Image = (Image) manager.GetObject("MudarMarca\x00e7\x00e3oToolStripMenuItem.Image");
            this.ToolStripMenuItem_1.Name = "MudarMarca\x00e7\x00e3oToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.ToolStripMenuItem_1.Size = size2;
            this.ToolStripMenuItem_1.Text = "Mudar marca\x00e7\x00e3o";
            this.ToolStripMenuItem_2.Enabled = false;
            this.ToolStripMenuItem_2.Image = (Image) manager.GetObject("RemoverMarca\x00e7\x00e3oToolStripMenuItem.Image");
            this.ToolStripMenuItem_2.Name = "RemoverMarca\x00e7\x00e3oToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.ToolStripMenuItem_2.Size = size2;
            this.ToolStripMenuItem_2.Text = "Remover marca\x00e7\x00e3o";
            this.LevelMinimoToolStripMenuItem.Enabled = false;
            this.LevelMinimoToolStripMenuItem.Image = (Image) manager.GetObject("LevelMinimoToolStripMenuItem.Image");
            this.LevelMinimoToolStripMenuItem.Name = "LevelMinimoToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.LevelMinimoToolStripMenuItem.Size = size2;
            this.LevelMinimoToolStripMenuItem.Text = "Alterar Level";
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            size2 = new Size(0xad, 6);
            this.ToolStripMenuItem1.Size = size2;
            this.ApagarTodosToolStripMenuItem.Enabled = false;
            this.ApagarTodosToolStripMenuItem.Image = (Image) manager.GetObject("ApagarTodosToolStripMenuItem.Image");
            this.ApagarTodosToolStripMenuItem.Name = "ApagarTodosToolStripMenuItem";
            size2 = new Size(0xb0, 0x16);
            this.ApagarTodosToolStripMenuItem.Size = size2;
            this.ApagarTodosToolStripMenuItem.Text = "Apagar todos";
            this.menuGerarCache.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.menuGerarCache.Enabled = false;
            this.menuGerarCache.Image = EditorIFF.My.Resources.Resources.package_add;
            this.menuGerarCache.ImageScaling = ToolStripItemImageScaling.None;
            this.menuGerarCache.ImageTransparentColor = Color.Magenta;
            this.menuGerarCache.Name = "menuGerarCache";
            size2 = new Size(0x24, 0x25);
            this.menuGerarCache.Size = size2;
            this.menuGerarCache.Text = "ToolStripDropDownButton1";
            this.menuGerarCache.ToolTipText = "Gerar Cache de Imagens";
            this.SplitContainer1.BackColor = Color.Silver;
            this.SplitContainer1.Dock = DockStyle.Fill;
            this.SplitContainer1.IsSplitterFixed = true;
            point2 = new Point(0, 40);
            this.SplitContainer1.Location = point2;
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Panel1.Controls.Add(this.Panel3);
            this.SplitContainer1.Panel1.Controls.Add(this.Panel2);
            this.SplitContainer1.Panel1.Controls.Add(this.Panel1);
            this.SplitContainer1.Panel1MinSize = 200;
            this.SplitContainer1.Panel2.BackColor = Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.Panel4);
            Padding padding2 = new Padding(3);
            this.SplitContainer1.Panel2.Padding = padding2;
            this.SplitContainer1.Panel2MinSize = 0;
            size2 = new Size(0x329, 0x1e6);
            this.SplitContainer1.Size = size2;
            this.SplitContainer1.SplitterDistance = 0x115;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 3;
            this.Panel3.Controls.Add(this.ListaItem);
            this.Panel3.Dock = DockStyle.Fill;
            point2 = new Point(0, 0x1b);
            this.Panel3.Location = point2;
            this.Panel3.Name = "Panel3";
            size2 = new Size(0x115, 390);
            this.Panel3.Size = size2;
            this.Panel3.TabIndex = 2;
            this.ListaItem.AllowUserToAddRows = false;
            this.ListaItem.AllowUserToDeleteRows = false;
            this.ListaItem.AllowUserToResizeColumns = false;
            this.ListaItem.AllowUserToResizeRows = false;
            this.ListaItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.ListaItem.DefaultCellStyle = style;
            this.ListaItem.Dock = DockStyle.Fill;
            point2 = new Point(0, 0);
            this.ListaItem.Location = point2;
            this.ListaItem.Name = "ListaItem";
            this.ListaItem.ReadOnly = true;
            this.ListaItem.RowHeadersVisible = false;
            this.ListaItem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ListaItem.ScrollBars = ScrollBars.Vertical;
            this.ListaItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ListaItem.ShowCellErrors = false;
            this.ListaItem.ShowEditingIcon = false;
            this.ListaItem.ShowRowErrors = false;
            size2 = new Size(0x115, 390);
            this.ListaItem.Size = size2;
            this.ListaItem.TabIndex = 0;
            this.Panel2.BackColor = Color.DimGray;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Controls.Add(this.lbArquivo);
            this.Panel2.Dock = DockStyle.Top;
            point2 = new Point(0, 0);
            this.Panel2.Location = point2;
            this.Panel2.Name = "Panel2";
            size2 = new Size(0x115, 0x1b);
            this.Panel2.Size = size2;
            this.Panel2.TabIndex = 1;
            this.PictureBox2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.PictureBox2.BackColor = Color.Transparent;
            this.PictureBox2.Image = EditorIFF.My.Resources.Resources.document_editing;
            point2 = new Point(3, 4);
            this.PictureBox2.Location = point2;
            this.PictureBox2.Name = "PictureBox2";
            size2 = new Size(20, 20);
            this.PictureBox2.Size = size2;
            this.PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox2.TabIndex = 1;
            this.PictureBox2.TabStop = false;
            this.lbArquivo.AutoSize = true;
            this.lbArquivo.BackColor = Color.Transparent;
            this.lbArquivo.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lbArquivo.ForeColor = Color.White;
            point2 = new Point(0x18, 6);
            this.lbArquivo.Location = point2;
            this.lbArquivo.Name = "lbArquivo";
            size2 = new Size(140, 0x10);
            this.lbArquivo.Size = size2;
            this.lbArquivo.TabIndex = 0;
            this.lbArquivo.Text = "Nenhum arquivo aberto";
            this.Panel1.BackColor = Color.White;
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.imgStatus);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.ComboBox2);
            this.Panel1.Controls.Add(this.txtPesquisa);
            this.Panel1.Controls.Add(this.Label33);
            this.Panel1.Controls.Add(this.Label37);
            this.Panel1.Dock = DockStyle.Bottom;
            point2 = new Point(0, 0x1a1);
            this.Panel1.Location = point2;
            this.Panel1.Name = "Panel1";
            size2 = new Size(0x115, 0x45);
            this.Panel1.Size = size2;
            this.Panel1.TabIndex = 0;
            this.Label39.BorderStyle = BorderStyle.Fixed3D;
            point2 = new Point(4, 0x1b);
            this.Label39.Location = point2;
            this.Label39.Name = "Label39";
            size2 = new Size(270, 2);
            this.Label39.Size = size2;
            this.Label39.TabIndex = 0x16;
            this.imgStatus.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStatus.BackColor = Color.Transparent;
            this.imgStatus.Image = EditorIFF.My.Resources.Resources.fred;
            point2 = new Point(5, 30);
            this.imgStatus.Location = point2;
            this.imgStatus.Name = "imgStatus";
            size2 = new Size(0x23, 0x23);
            this.imgStatus.Size = size2;
            this.imgStatus.SizeMode = PictureBoxSizeMode.CenterImage;
            this.imgStatus.TabIndex = 1;
            this.imgStatus.TabStop = false;
            this.PictureBox4.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.PictureBox4.BackColor = Color.Transparent;
            this.PictureBox4.Image = EditorIFF.My.Resources.Resources.search_plus;
            point2 = new Point(0xca, 5);
            this.PictureBox4.Location = point2;
            this.PictureBox4.Name = "PictureBox4";
            size2 = new Size(20, 20);
            this.PictureBox4.Size = size2;
            this.PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox4.TabIndex = 1;
            this.PictureBox4.TabStop = false;
            this.PictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.PictureBox1.BackColor = Color.Transparent;
            this.PictureBox1.Image = EditorIFF.My.Resources.Resources.zoom;
            point2 = new Point(5, 5);
            this.PictureBox1.Location = point2;
            this.PictureBox1.Name = "PictureBox1";
            size2 = new Size(20, 20);
            this.PictureBox1.Size = size2;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            this.ComboBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.ItemHeight = 13;
            object[] items = new object[] { "Todos", "Ativos", "Desativados" };
            this.ComboBox2.Items.AddRange(items);
            point2 = new Point(0x2e, 0x2c);
            this.ComboBox2.Location = point2;
            this.ComboBox2.Name = "ComboBox2";
            size2 = new Size(0xdf, 0x15);
            this.ComboBox2.Size = size2;
            this.ComboBox2.TabIndex = 1;
            this.txtPesquisa.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.txtPesquisa.BorderStyle = BorderStyle.FixedSingle;
            this.txtPesquisa.Enabled = false;
            point2 = new Point(0x1b, 5);
            this.txtPesquisa.Location = point2;
            this.txtPesquisa.Name = "txtPesquisa";
            size2 = new Size(0xad, 20);
            this.txtPesquisa.Size = size2;
            this.txtPesquisa.TabIndex = 0;
            this.Label33.AutoSize = true;
            this.Label33.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0xe0, 7);
            this.Label33.Location = point2;
            this.Label33.Name = "Label33";
            size2 = new Size(15, 0x10);
            this.Label33.Size = size2;
            this.Label33.TabIndex = 10;
            this.Label33.Text = "0";
            this.Label37.AutoSize = true;
            point2 = new Point(0x2e, 30);
            this.Label37.Location = point2;
            this.Label37.Name = "Label37";
            size2 = new Size(0x25, 13);
            this.Label37.Size = size2;
            this.Label37.TabIndex = 10;
            this.Label37.Text = "Status";
            this.Panel4.Controls.Add(this.tabForm);
            this.Panel4.Controls.Add(this.gbBotoes);
            this.Panel4.Dock = DockStyle.Fill;
            point2 = new Point(3, 3);
            this.Panel4.Location = point2;
            this.Panel4.Name = "Panel4";
            padding2 = new Padding(5, 3, 5, 3);
            this.Panel4.Padding = padding2;
            size2 = new Size(0x20c, 480);
            this.Panel4.Size = size2;
            this.Panel4.TabIndex = 2;
            this.tabForm.Controls.Add(this.TabPage1);
            this.tabForm.Controls.Add(this.TabPage2);
            this.tabForm.Dock = DockStyle.Fill;
            this.tabForm.Enabled = false;
            point2 = new Point(5, 3);
            this.tabForm.Location = point2;
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            size2 = new Size(0x202, 0x194);
            this.tabForm.Size = size2;
            this.tabForm.TabIndex = 0;
            this.TabPage1.BackColor = Color.White;
            this.TabPage1.Controls.Add(this.btnVerificarTYPEID);
            this.TabPage1.Controls.Add(this.ckTempoAtivo);
            this.TabPage1.Controls.Add(this.Panel10);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.Label29);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.rbLevelMax);
            this.TabPage1.Controls.Add(this.rbLevelMin);
            this.TabPage1.Controls.Add(this.cbLevel);
            this.TabPage1.Controls.Add(this.cbTipo);
            this.TabPage1.Controls.Add(this.ckAtivo);
            this.TabPage1.Controls.Add(this.imgIcone);
            this.TabPage1.Controls.Add(this.txtIcone);
            this.TabPage1.Controls.Add(this.txtTypeID);
            this.TabPage1.Controls.Add(this.Label6);
            this.TabPage1.Controls.Add(this.Label8);
            this.TabPage1.Controls.Add(this.txtDesconto);
            this.TabPage1.Controls.Add(this.txtPreco);
            this.TabPage1.Controls.Add(this.txtNome);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.lbContNome);
            this.TabPage1.Controls.Add(this.Label18);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.gbTempoVenda);
            this.TabPage1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(4, 0x16);
            this.TabPage1.Location = point2;
            this.TabPage1.Name = "TabPage1";
            padding2 = new Padding(3);
            this.TabPage1.Padding = padding2;
            size2 = new Size(0x1fa, 0x17a);
            this.TabPage1.Size = size2;
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Informa\x00e7\x00f5es B\x00e1sicas";
            this.btnVerificarTYPEID.Image = EditorIFF.My.Resources.Resources.search_plus;
            point2 = new Point(0x101, 0x29);
            this.btnVerificarTYPEID.Location = point2;
            this.btnVerificarTYPEID.Name = "btnVerificarTYPEID";
            size2 = new Size(0x19, 0x19);
            this.btnVerificarTYPEID.Size = size2;
            this.btnVerificarTYPEID.TabIndex = 0x1c;
            this.ToolTip1.SetToolTip(this.btnVerificarTYPEID, "Verificar TYPEID");
            this.btnVerificarTYPEID.UseVisualStyleBackColor = true;
            this.ckTempoAtivo.AutoSize = true;
            this.ckTempoAtivo.BackColor = Color.Transparent;
            point2 = new Point(0x13e, 0x9f);
            this.ckTempoAtivo.Location = point2;
            this.ckTempoAtivo.Name = "ckTempoAtivo";
            size2 = new Size(0x33, 0x13);
            this.ckTempoAtivo.Size = size2;
            this.ckTempoAtivo.TabIndex = 0x1b;
            this.ckTempoAtivo.Text = "Ativo";
            this.ckTempoAtivo.UseVisualStyleBackColor = false;
            this.GroupBox1.Controls.Add(this.ckNew);
            this.GroupBox1.Controls.Add(this.ckDesativado);
            this.GroupBox1.Controls.Add(this.ckNormal);
            this.GroupBox1.Controls.Add(this.ckHot);
            this.GroupBox1.Controls.Add(this.ckGift);
            point2 = new Point(0x17b, 0x94);
            this.GroupBox1.Location = point2;
            this.GroupBox1.Name = "GroupBox1";
            size2 = new Size(0x76, 0x9a);
            this.GroupBox1.Size = size2;
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Marca\x00e7\x00e3o";
            this.ckNew.AutoSize = true;
            point2 = new Point(11, 0x17);
            this.ckNew.Location = point2;
            this.ckNew.Name = "ckNew";
            size2 = new Size(0x51, 0x13);
            this.ckNew.Size = size2;
            this.ckNew.TabIndex = 0;
            this.ckNew.Text = "Item Novo";
            this.ckNew.UseVisualStyleBackColor = true;
            this.ckDesativado.AutoSize = true;
            point2 = new Point(11, 0x7f);
            this.ckDesativado.Location = point2;
            this.ckDesativado.Name = "ckDesativado";
            size2 = new Size(0x3d, 0x13);
            this.ckDesativado.Size = size2;
            this.ckDesativado.TabIndex = 5;
            this.ckDesativado.Text = "Oculto";
            this.ckDesativado.UseVisualStyleBackColor = true;
            this.ckNormal.AutoSize = true;
            point2 = new Point(11, 0x65);
            this.ckNormal.Location = point2;
            this.ckNormal.Name = "ckNormal";
            size2 = new Size(0x5e, 0x13);
            this.ckNormal.Size = size2;
            this.ckNormal.TabIndex = 5;
            this.ckNormal.Text = "Item Normal";
            this.ckNormal.UseVisualStyleBackColor = true;
            this.ckHot.AutoSize = true;
            point2 = new Point(11, 0x31);
            this.ckHot.Location = point2;
            this.ckHot.Name = "ckHot";
            size2 = new Size(0x5d, 0x13);
            this.ckHot.Size = size2;
            this.ckHot.TabIndex = 1;
            this.ckHot.Text = "Item Quente";
            this.ckHot.UseVisualStyleBackColor = true;
            this.ckGift.AutoSize = true;
            point2 = new Point(11, 0x4b);
            this.ckGift.Location = point2;
            this.ckGift.Name = "ckGift";
            size2 = new Size(0x4c, 0x13);
            this.ckGift.Size = size2;
            this.ckGift.TabIndex = 3;
            this.ckGift.Text = "Presente";
            this.ckGift.UseVisualStyleBackColor = true;
            this.Label29.BorderStyle = BorderStyle.Fixed3D;
            point2 = new Point(13, 0x8f);
            this.Label29.Location = point2;
            this.Label29.Name = "Label29";
            size2 = new Size(0x1e3, 2);
            this.Label29.Size = size2;
            this.Label29.TabIndex = 0x15;
            this.Label2.BorderStyle = BorderStyle.Fixed3D;
            point2 = new Point(13, 0x6b);
            this.Label2.Location = point2;
            this.Label2.Name = "Label2";
            size2 = new Size(0x1e3, 2);
            this.Label2.Size = size2;
            this.Label2.TabIndex = 0x15;
            this.rbLevelMax.AutoSize = true;
            point2 = new Point(0x18d, 0x4d);
            this.rbLevelMax.Location = point2;
            this.rbLevelMax.Name = "rbLevelMax";
            size2 = new Size(0x63, 0x13);
            this.rbLevelMax.Size = size2;
            this.rbLevelMax.TabIndex = 7;
            this.rbLevelMax.Text = "Level M\x00e1ximo";
            this.rbLevelMax.UseVisualStyleBackColor = true;
            this.rbLevelMin.AutoSize = true;
            this.rbLevelMin.Checked = true;
            point2 = new Point(0x129, 0x4d);
            this.rbLevelMin.Location = point2;
            this.rbLevelMin.Name = "rbLevelMin";
            size2 = new Size(0x61, 0x13);
            this.rbLevelMin.Size = size2;
            this.rbLevelMin.TabIndex = 6;
            this.rbLevelMin.TabStop = true;
            this.rbLevelMin.Text = "Level M\x00ednimo";
            this.rbLevelMin.UseVisualStyleBackColor = true;
            this.cbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbLevel.FormattingEnabled = true;
            items = new object[] { "00 - Rookie F", "01 - Rookie E", "02 - Rookie D", "03 - Rookie C", "04 - Rookie B", "05 - Rookie A", "06 - Beginner E", "07 - Beginner D", "08 - Beginner C" };
            items[9] = "09 - Beginner B";
            items[10] = "10 - Beginner A";
            items[11] = "11 - Junior E";
            items[12] = "12 - Junior D";
            items[13] = "13 - Junior C";
            items[14] = "14 - Junior B";
            items[15] = "15 - Junior A";
            items[0x10] = "16 - Senior E";
            items[0x11] = "17 - Senior D";
            items[0x12] = "18 - Senior C";
            items[0x13] = "19 - Senior B";
            items[20] = "20 - Senior A";
            items[0x15] = "21 - Amateur E";
            items[0x16] = "22 - Amateur D";
            items[0x17] = "23 - Amateur C";
            items[0x18] = "24 - Amateur B";
            items[0x19] = "25 - Amateur A";
            items[0x1a] = "26 - Semi-Pro E";
            items[0x1b] = "27 - Semi-Pro D";
            items[0x1c] = "28 - Semi-Pro C";
            items[0x1d] = "29 - Semi-Pro B";
            items[30] = "30 - Semi-Pro A";
            items[0x1f] = "31 - Pro E";
            items[0x20] = "32 - Pro D";
            items[0x21] = "33 - Pro C";
            items[0x22] = "34 - Pro B";
            items[0x23] = "35 - Pro A";
            items[0x24] = "36 - National Pro E";
            items[0x25] = "37 - National Pro D";
            items[0x26] = "38 - National Pro C";
            items[0x27] = "39 - National Pro B";
            items[40] = "40 - National Pro A";
            items[0x29] = "41 - World Pro E";
            items[0x2a] = "42 - World Pro D";
            items[0x2b] = "43 - World Pro C";
            items[0x2c] = "44 - World Pro B";
            items[0x2d] = "45 - World Pro A";
            items[0x2e] = "46 - Master E";
            items[0x2f] = "47 - Master D";
            items[0x30] = "48 - Master C";
            items[0x31] = "49 - Master B";
            items[50] = "50 - Master A";
            items[0x33] = "51 - Top Master E";
            items[0x34] = "52 - Top Master D";
            items[0x35] = "53 - Top Master C";
            items[0x36] = "54 - Top Master B";
            items[0x37] = "55 - Top Master A";
            items[0x38] = "56 - Jungle Master E";
            items[0x39] = "57 - Jungle Master D";
            items[0x3a] = "58 - Jungle Master C";
            items[0x3b] = "59 - Jungle Master B";
            items[60] = "60 - Jungle Master A";
            items[0x3d] = "61 - Legend E";
            items[0x3e] = "62 - Legend D";
            items[0x3f] = "63 - Legend C";
            items[0x40] = "64 - Legend B";
            items[0x41] = "65 - Legend A";
            items[0x42] = "66 - Infinity Legend E";
            items[0x43] = "67 - Infinity Legend D";
            items[0x44] = "68 - Infinity Legend C";
            items[0x45] = "69 - Infinity Legend B";
            items[70] = "70 - Infinity Legend A ";
            this.cbLevel.Items.AddRange(items);
            point2 = new Point(0x9a, 0x4a);
            this.cbLevel.Location = point2;
            this.cbLevel.Name = "cbLevel";
            size2 = new Size(0x7f, 0x17);
            this.cbLevel.Size = size2;
            this.cbLevel.TabIndex = 5;
            this.cbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            items = new object[] { "Oculto", "Points", "Pangs" };
            this.cbTipo.Items.AddRange(items);
            point2 = new Point(0x18b, 0x72);
            this.cbTipo.Location = point2;
            this.cbTipo.Name = "cbTipo";
            size2 = new Size(0x65, 0x17);
            this.cbTipo.Size = size2;
            this.cbTipo.TabIndex = 9;
            this.ckAtivo.AutoSize = true;
            point2 = new Point(0x1bc, 0x2d);
            this.ckAtivo.Location = point2;
            this.ckAtivo.Name = "ckAtivo";
            size2 = new Size(0x3a, 0x13);
            this.ckAtivo.Size = size2;
            this.ckAtivo.TabIndex = 4;
            this.ckAtivo.Text = "ATIVO";
            this.ckAtivo.UseVisualStyleBackColor = true;
            this.imgIcone.BackgroundImage = EditorIFF.My.Resources.Resources.bg_transparent;
            this.imgIcone.BorderStyle = BorderStyle.FixedSingle;
            this.imgIcone.ErrorImage = EditorIFF.My.Resources.Resources._error;
            this.imgIcone.InitialImage = EditorIFF.My.Resources.Resources.ajax_loader;
            point2 = new Point(0x11, 14);
            this.imgIcone.Location = point2;
            this.imgIcone.Name = "imgIcone";
            size2 = new Size(0x55, 0x55);
            this.imgIcone.Size = size2;
            this.imgIcone.SizeMode = PictureBoxSizeMode.CenterImage;
            this.imgIcone.TabIndex = 14;
            this.imgIcone.TabStop = false;
            point2 = new Point(0x143, 0x2b);
            this.txtIcone.Location = point2;
            this.txtIcone.Name = "txtIcone";
            size2 = new Size(0x73, 0x15);
            this.txtIcone.Size = size2;
            this.txtIcone.TabIndex = 3;
            point2 = new Point(0x9a, 0x2b);
            this.txtTypeID.Location = point2;
            this.txtTypeID.Name = "txtTypeID";
            size2 = new Size(0x65, 0x15);
            this.txtTypeID.Size = size2;
            this.txtTypeID.TabIndex = 2;
            this.Label6.AutoSize = true;
            point2 = new Point(0x6d, 0x4e);
            this.Label6.Location = point2;
            this.Label6.Name = "Label6";
            size2 = new Size(0x24, 15);
            this.Label6.Size = size2;
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Level";
            this.Label8.AutoSize = true;
            point2 = new Point(0x159, 0x75);
            this.Label8.Location = point2;
            this.Label8.Name = "Label8";
            size2 = new Size(0x2c, 15);
            this.Label8.Size = size2;
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Moeda";
            point2 = new Point(0xee, 0x74);
            this.txtDesconto.Location = point2;
            this.txtDesconto.MaxLength = 40;
            this.txtDesconto.Name = "txtDesconto";
            size2 = new Size(0x60, 0x15);
            this.txtDesconto.Size = size2;
            this.txtDesconto.TabIndex = 8;
            point2 = new Point(0x31, 0x74);
            this.txtPreco.Location = point2;
            this.txtPreco.MaxLength = 40;
            this.txtPreco.Name = "txtPreco";
            size2 = new Size(100, 0x15);
            this.txtPreco.Size = size2;
            this.txtPreco.TabIndex = 8;
            point2 = new Point(0x9a, 11);
            this.txtNome.Location = point2;
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            size2 = new Size(0x138, 0x15);
            this.txtNome.Size = size2;
            this.txtNome.TabIndex = 0;
            this.Label7.AutoSize = true;
            point2 = new Point(0x11b, 0x2e);
            this.Label7.Location = point2;
            this.Label7.Name = "Label7";
            size2 = new Size(0x25, 15);
            this.Label7.Size = size2;
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Icone";
            this.Label3.AutoSize = true;
            point2 = new Point(0x6d, 0x2e);
            this.Label3.Location = point2;
            this.Label3.Name = "Label3";
            size2 = new Size(0x2c, 15);
            this.Label3.Size = size2;
            this.Label3.TabIndex = 11;
            this.Label3.Text = "TypeID";
            this.lbContNome.AutoSize = true;
            this.lbContNome.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lbContNome.ForeColor = Color.Gray;
            point2 = new Point(0x1d4, 14);
            this.lbContNome.Location = point2;
            this.lbContNome.Name = "lbContNome";
            size2 = new Size(0x1c, 14);
            this.lbContNome.Size = size2;
            this.lbContNome.TabIndex = 9;
            this.lbContNome.Text = "0/40";
            this.Label18.AutoSize = true;
            point2 = new Point(0xb1, 0x77);
            this.Label18.Location = point2;
            this.Label18.Name = "Label18";
            size2 = new Size(60, 15);
            this.Label18.Size = size2;
            this.Label18.TabIndex = 10;
            this.Label18.Text = "Desconto";
            this.Label4.AutoSize = true;
            point2 = new Point(10, 0x77);
            this.Label4.Location = point2;
            this.Label4.Name = "Label4";
            size2 = new Size(0x27, 15);
            this.Label4.Size = size2;
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Pre\x00e7o";
            this.Label1.AutoSize = true;
            point2 = new Point(0x6d, 14);
            this.Label1.Location = point2;
            this.Label1.Name = "Label1";
            size2 = new Size(0x29, 15);
            this.Label1.Size = size2;
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Nome";
            this.gbTempoVenda.Controls.Add(this.dtTermino);
            this.gbTempoVenda.Controls.Add(this.dtInicio);
            this.gbTempoVenda.Controls.Add(this.Label28);
            this.gbTempoVenda.Controls.Add(this.Label27);
            this.gbTempoVenda.Enabled = false;
            point2 = new Point(13, 0x94);
            this.gbTempoVenda.Location = point2;
            this.gbTempoVenda.Name = "gbTempoVenda";
            size2 = new Size(0x167, 0x49);
            this.gbTempoVenda.Size = size2;
            this.gbTempoVenda.TabIndex = 10;
            this.gbTempoVenda.TabStop = false;
            this.gbTempoVenda.Text = "Venda Programada";
            this.dtTermino.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTermino.Format = DateTimePickerFormat.Custom;
            point2 = new Point(0xb9, 0x2a);
            this.dtTermino.Location = point2;
            this.dtTermino.Name = "dtTermino";
            size2 = new Size(0xa4, 0x15);
            this.dtTermino.Size = size2;
            this.dtTermino.TabIndex = 0x1a;
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicio.Format = DateTimePickerFormat.Custom;
            point2 = new Point(13, 0x2a);
            this.dtInicio.Location = point2;
            this.dtInicio.Name = "dtInicio";
            size2 = new Size(0xa6, 0x15);
            this.dtInicio.Size = size2;
            this.dtInicio.TabIndex = 0x1a;
            this.Label28.AutoSize = true;
            point2 = new Point(0xb7, 0x17);
            this.Label28.Location = point2;
            this.Label28.Name = "Label28";
            size2 = new Size(0x6b, 15);
            this.Label28.Size = size2;
            this.Label28.TabIndex = 10;
            this.Label28.Text = "T\x00e9rmino da Venda";
            this.Label27.AutoSize = true;
            point2 = new Point(0x24, 0x18);
            this.Label27.Location = point2;
            this.Label27.Name = "Label27";
            size2 = new Size(90, 15);
            this.Label27.Size = size2;
            this.Label27.TabIndex = 10;
            this.Label27.Text = "In\x00edcio da Venda";
            this.TabPage2.Controls.Add(this.imgPersonagem);
            this.TabPage2.Controls.Add(this.Label36);
            this.TabPage2.Controls.Add(this.ComboBox1);
            this.TabPage2.Controls.Add(this.GroupBox3);
            point2 = new Point(4, 0x16);
            this.TabPage2.Location = point2;
            this.TabPage2.Name = "TabPage2";
            padding2 = new Padding(3);
            this.TabPage2.Padding = padding2;
            size2 = new Size(0x1fa, 0x17a);
            this.TabPage2.Size = size2;
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Avan\x00e7ado";
            this.TabPage2.UseVisualStyleBackColor = true;
            this.imgPersonagem.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgPersonagem.BackColor = Color.Transparent;
            this.imgPersonagem.Image = EditorIFF.My.Resources.Resources.fred;
            point2 = new Point(9, 0x152);
            this.imgPersonagem.Location = point2;
            this.imgPersonagem.Name = "imgPersonagem";
            size2 = new Size(0x23, 0x23);
            this.imgPersonagem.Size = size2;
            this.imgPersonagem.SizeMode = PictureBoxSizeMode.CenterImage;
            this.imgPersonagem.TabIndex = 15;
            this.imgPersonagem.TabStop = false;
            this.imgPersonagem.Visible = false;
            this.Label36.AutoSize = true;
            point2 = new Point(0x2e, 0x14f);
            this.Label36.Location = point2;
            this.Label36.Name = "Label36";
            size2 = new Size(0x42, 13);
            this.Label36.Size = size2;
            this.Label36.TabIndex = 0x10;
            this.Label36.Text = "Personagem";
            this.Label36.Visible = false;
            this.ComboBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.ItemHeight = 13;
            items = new object[] { "Todos", "Nico", "Hana", "Fred", "Cecilia", "Max", "Kooh", "Arin", "Kaz" };
            items[9] = "Lucia";
            items[10] = "Nell";
            this.ComboBox1.Items.AddRange(items);
            point2 = new Point(0x31, 0x15f);
            this.ComboBox1.Location = point2;
            this.ComboBox1.Name = "ComboBox1";
            size2 = new Size(0x59, 0x15);
            this.ComboBox1.Size = size2;
            this.ComboBox1.TabIndex = 14;
            this.ComboBox1.Visible = false;
            this.GroupBox3.Controls.Add(this.Label23);
            this.GroupBox3.Controls.Add(this.txtSalary);
            this.GroupBox3.Controls.Add(this.labeladd);
            this.GroupBox3.Controls.Add(this.txtSprite);
            point2 = new Point(6, 4);
            this.GroupBox3.Location = point2;
            this.GroupBox3.Name = "GroupBox3";
            size2 = new Size(0x1ed, 0x58);
            this.GroupBox3.Size = size2;
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.Label23.AutoSize = true;
            point2 = new Point(9, 0x34);
            this.Label23.Location = point2;
            this.Label23.Name = "Label23";
            size2 = new Size(0x27, 13);
            this.Label23.Size = size2;
            this.Label23.TabIndex = 12;
            this.Label23.Text = "Salario";
            point2 = new Point(60, 0x30);
            this.txtSalary.Location = point2;
            this.txtSalary.MaxLength = 40;
            this.txtSalary.Name = "txtSalary";
            size2 = new Size(0x87, 20);
            this.txtSalary.Size = size2;
            this.txtSalary.TabIndex = 11;
            this.txtSalary.Text = "0";
            this.labeladd.AutoSize = true;
            point2 = new Point(9, 0x16);
            this.labeladd.Location = point2;
            this.labeladd.Name = "labeladd";
            size2 = new Size(0x1c, 13);
            this.labeladd.Size = size2;
            this.labeladd.TabIndex = 12;
            this.labeladd.Text = "PET";
            point2 = new Point(60, 0x12);
            this.txtSprite.Location = point2;
            this.txtSprite.MaxLength = 40;
            this.txtSprite.Name = "txtSprite";
            size2 = new Size(0x1ab, 20);
            this.txtSprite.Size = size2;
            this.txtSprite.TabIndex = 11;
            this.gbBotoes.Controls.Add(this.btnReabrir);
            this.gbBotoes.Controls.Add(this.btnNovo);
            this.gbBotoes.Controls.Add(this.btnRemover);
            this.gbBotoes.Controls.Add(this.btnBackup);
            this.gbBotoes.Controls.Add(this.btnSalvar);
            this.gbBotoes.Dock = DockStyle.Bottom;
            this.gbBotoes.Enabled = false;
            point2 = new Point(5, 0x197);
            this.gbBotoes.Location = point2;
            this.gbBotoes.Name = "gbBotoes";
            size2 = new Size(0x202, 70);
            this.gbBotoes.Size = size2;
            this.gbBotoes.TabIndex = 1;
            this.gbBotoes.TabStop = false;
            this.btnReabrir.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnReabrir.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnReabrir.Image = EditorIFF.My.Resources.Resources.accept;
            this.btnReabrir.ImageAlign = ContentAlignment.MiddleRight;
            point2 = new Point(0x134, 14);
            this.btnReabrir.Location = point2;
            this.btnReabrir.Name = "btnReabrir";
            size2 = new Size(0x61, 0x30);
            this.btnReabrir.Size = size2;
            this.btnReabrir.TabIndex = 0;
            this.btnReabrir.TabStop = false;
            this.btnReabrir.Text = "Aplicar";
            this.btnReabrir.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnReabrir.UseVisualStyleBackColor = true;
            this.btnNovo.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnNovo.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnNovo.Image = EditorIFF.My.Resources.Resources.add;
            this.btnNovo.ImageAlign = ContentAlignment.MiddleRight;
            point2 = new Point(8, 14);
            this.btnNovo.Location = point2;
            this.btnNovo.Name = "btnNovo";
            size2 = new Size(0x61, 0x30);
            this.btnNovo.Size = size2;
            this.btnNovo.TabIndex = 0;
            this.btnNovo.TabStop = false;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnRemover.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnRemover.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnRemover.Image = EditorIFF.My.Resources.Resources.delete;
            this.btnRemover.ImageAlign = ContentAlignment.MiddleRight;
            point2 = new Point(0x6c, 14);
            this.btnRemover.Location = point2;
            this.btnRemover.Name = "btnRemover";
            size2 = new Size(0x61, 0x30);
            this.btnRemover.Size = size2;
            this.btnRemover.TabIndex = 0;
            this.btnRemover.TabStop = false;
            this.btnRemover.Text = "Remover";
            this.btnRemover.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnBackup.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnBackup.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnBackup.Image = EditorIFF.My.Resources.Resources.stamp_pattern;
            this.btnBackup.ImageAlign = ContentAlignment.MiddleRight;
            point2 = new Point(0xd0, 14);
            this.btnBackup.Location = point2;
            this.btnBackup.Name = "btnBackup";
            size2 = new Size(0x61, 0x30);
            this.btnBackup.Size = size2;
            this.btnBackup.TabIndex = 0;
            this.btnBackup.TabStop = false;
            this.btnBackup.Text = "Clonar";
            this.btnBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnSalvar.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnSalvar.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnSalvar.Image = EditorIFF.My.Resources.Resources.disk;
            this.btnSalvar.ImageAlign = ContentAlignment.MiddleRight;
            point2 = new Point(0x198, 14);
            this.btnSalvar.Location = point2;
            this.btnSalvar.Name = "btnSalvar";
            size2 = new Size(0x61, 0x30);
            this.btnSalvar.Size = size2;
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.bwSalvar.WorkerReportsProgress = true;
            this.bwSalvar.WorkerSupportsCancellation = true;
            this.bwGerarSql.WorkerReportsProgress = true;
            this.bwGerarSql.WorkerSupportsCancellation = true;
            this.ImageList1.ImageStream = (ImageListStreamer) manager.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "nenhum.png");
            this.ImageList1.Images.SetKeyName(1, "nuri.png");
            this.ImageList1.Images.SetKeyName(2, "hana.png");
            this.ImageList1.Images.SetKeyName(3, "fred.png");
            this.ImageList1.Images.SetKeyName(4, "cecilia.png");
            this.ImageList1.Images.SetKeyName(5, "max.png");
            this.ImageList1.Images.SetKeyName(6, "kooh.png");
            this.ImageList1.Images.SetKeyName(7, "arin.png");
            this.ImageList1.Images.SetKeyName(8, "kaz.png");
            this.ImageList1.Images.SetKeyName(9, "lucia.png");
            this.ImageList1.Images.SetKeyName(10, "nell.png");
            this.ImageList2.ImageStream = (ImageListStreamer) manager.GetObject("ImageList2.ImageStream");
            this.ImageList2.TransparentColor = Color.Transparent;
            this.ImageList2.Images.SetKeyName(0, "fred.png");
            this.ImageList2.Images.SetKeyName(1, "accept.png");
            this.ImageList2.Images.SetKeyName(2, "delete.png");
            this.diagSalvarArquivo.DefaultExt = "iff";
            this.diagSalvarArquivo.FileName = MySettings.Default.ArquivoIff;
            this.diagSalvarArquivo.Filter = "Imagem (*.iff)|*.iff";
            this.diagSalvarArquivo.InitialDirectory = MySettings.Default.DiretorioIff;
            this.diagSalvarArquivo.RestoreDirectory = true;
            this.diagSalvarArquivo.Title = "Salvar arquivo Caddie.iff";
            this.diagAbrirArquivo.DefaultExt = "iff";
            this.diagAbrirArquivo.FileName = MySettings.Default.ArquivoIff;
            this.diagAbrirArquivo.Filter = "Pangya (*.iff)|*.iff";
            this.diagAbrirArquivo.InitialDirectory = MySettings.Default.DiretorioIff;
            this.diagAbrirArquivo.RestoreDirectory = true;
            this.diagAbrirArquivo.Title = "Abrir arquivo (Caddie.iff)";
            this.diagSalvarSql.DefaultExt = "sql";
            this.diagSalvarSql.FileName = "Caddie.iff.sql";
            this.diagSalvarSql.Filter = "SQL (*.sql)|*.sql";
            this.diagSalvarSql.InitialDirectory = MySettings.Default.DiretorioIff;
            this.diagSalvarSql.RestoreDirectory = true;
            this.diagSalvarSql.Title = "Salvar arquivo SQL";
            this.diagPasta.Description = "Selecione a pasta de arquivos";
            this.diagPasta.SelectedPath = MySettings.Default.DiretorioDividir;
            this.Label15.AutoSize = true;
            point2 = new Point(320, 8);
            this.Label15.Location = point2;
            this.Label15.Name = "Label15";
            size2 = new Size(0x30, 15);
            this.Label15.Size = size2;
            this.Label15.TabIndex = 10;
            this.Label15.Text = "Atributo";
            this.Label10.AutoSize = true;
            point2 = new Point(0x1c, 0x1a);
            this.Label10.Location = point2;
            this.Label10.Name = "Label10";
            size2 = new Size(0x30, 15);
            this.Label10.Size = size2;
            this.Label10.TabIndex = 7;
            this.Label10.Text = "FOR\x00c7A";
            this.Label11.AutoSize = true;
            point2 = new Point(2, 0x34);
            this.Label11.Location = point2;
            this.Label11.Name = "Label11";
            size2 = new Size(0x4a, 15);
            this.Label11.Size = size2;
            this.Label11.TabIndex = 7;
            this.Label11.Text = "CONTROLE";
            this.Label12.AutoSize = true;
            point2 = new Point(8, 0x4d);
            this.Label12.Location = point2;
            this.Label12.Name = "Label12";
            size2 = new Size(0x44, 15);
            this.Label12.Size = size2;
            this.Label12.TabIndex = 7;
            this.Label12.Text = "PRECIS\x00c3O";
            this.Label13.AutoSize = true;
            point2 = new Point(0x29, 0x66);
            this.Label13.Location = point2;
            this.Label13.Name = "Label13";
            size2 = new Size(0x23, 15);
            this.Label13.Size = size2;
            this.Label13.TabIndex = 7;
            this.Label13.Text = "SPIN";
            this.Label14.AutoSize = true;
            point2 = new Point(0x1d, 0x7f);
            this.Label14.Location = point2;
            this.Label14.Name = "Label14";
            size2 = new Size(0x2f, 15);
            this.Label14.Size = size2;
            this.Label14.TabIndex = 7;
            this.Label14.Text = "CURVA";
            this.Label9.BorderStyle = BorderStyle.Fixed3D;
            point2 = new Point(12, 3);
            this.Label9.Location = point2;
            this.Label9.Name = "Label9";
            size2 = new Size(0x164, 2);
            this.Label9.Size = size2;
            this.Label9.TabIndex = 0x15;
            this.Panel5.BackColor = Color.WhiteSmoke;
            this.Panel5.BorderStyle = BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.barraForca);
            point2 = new Point(0x4e, 0x19);
            this.Panel5.Location = point2;
            this.Panel5.Name = "Panel5";
            size2 = new Size(0xed, 0x12);
            this.Panel5.Size = size2;
            this.Panel5.TabIndex = 0x18;
            this.barraForca.BackColor = Color.Red;
            this.barraForca.BorderStyle = BorderStyle.FixedSingle;
            point2 = new Point(0, 0);
            this.barraForca.Location = point2;
            this.barraForca.Name = "barraForca";
            size2 = new Size(0, 0x12);
            this.barraForca.Size = size2;
            this.barraForca.TabIndex = 0x18;
            this.Panel6.BackColor = Color.WhiteSmoke;
            this.Panel6.BorderStyle = BorderStyle.FixedSingle;
            this.Panel6.Controls.Add(this.barraControle);
            point2 = new Point(0x4e, 50);
            this.Panel6.Location = point2;
            this.Panel6.Name = "Panel6";
            size2 = new Size(0xed, 0x12);
            this.Panel6.Size = size2;
            this.Panel6.TabIndex = 0x18;
            this.barraControle.BackColor = Color.Orange;
            this.barraControle.BorderStyle = BorderStyle.FixedSingle;
            point2 = new Point(0, 0);
            this.barraControle.Location = point2;
            this.barraControle.Name = "barraControle";
            size2 = new Size(0, 0x12);
            this.barraControle.Size = size2;
            this.barraControle.TabIndex = 0x18;
            this.Panel7.BackColor = Color.WhiteSmoke;
            this.Panel7.BorderStyle = BorderStyle.FixedSingle;
            this.Panel7.Controls.Add(this.barraPrecisao);
            point2 = new Point(0x4e, 0x4b);
            this.Panel7.Location = point2;
            this.Panel7.Name = "Panel7";
            size2 = new Size(0xed, 0x12);
            this.Panel7.Size = size2;
            this.Panel7.TabIndex = 0x18;
            this.barraPrecisao.BackColor = Color.LimeGreen;
            this.barraPrecisao.BorderStyle = BorderStyle.FixedSingle;
            point2 = new Point(0, 0);
            this.barraPrecisao.Location = point2;
            this.barraPrecisao.Name = "barraPrecisao";
            size2 = new Size(0, 0x12);
            this.barraPrecisao.Size = size2;
            this.barraPrecisao.TabIndex = 0x18;
            this.Panel8.BackColor = Color.WhiteSmoke;
            this.Panel8.BorderStyle = BorderStyle.FixedSingle;
            this.Panel8.Controls.Add(this.barraSpin);
            point2 = new Point(0x4e, 100);
            this.Panel8.Location = point2;
            this.Panel8.Name = "Panel8";
            size2 = new Size(0xed, 0x12);
            this.Panel8.Size = size2;
            this.Panel8.TabIndex = 0x18;
            this.barraSpin.BackColor = Color.MediumTurquoise;
            this.barraSpin.BorderStyle = BorderStyle.FixedSingle;
            point2 = new Point(0, 0);
            this.barraSpin.Location = point2;
            this.barraSpin.Name = "barraSpin";
            size2 = new Size(0, 0x12);
            this.barraSpin.Size = size2;
            this.barraSpin.TabIndex = 0x18;
            this.Panel9.BackColor = Color.WhiteSmoke;
            this.Panel9.BorderStyle = BorderStyle.FixedSingle;
            this.Panel9.Controls.Add(this.barraCurva);
            point2 = new Point(0x4e, 0x7d);
            this.Panel9.Location = point2;
            this.Panel9.Name = "Panel9";
            size2 = new Size(0xed, 0x12);
            this.Panel9.Size = size2;
            this.Panel9.TabIndex = 0x18;
            this.barraCurva.BackColor = Color.SlateBlue;
            this.barraCurva.BorderStyle = BorderStyle.FixedSingle;
            point2 = new Point(0, 0);
            this.barraCurva.Location = point2;
            this.barraCurva.Name = "barraCurva";
            size2 = new Size(0, 0x12);
            this.barraCurva.Size = size2;
            this.barraCurva.TabIndex = 0x18;
            this.attForca.BorderStyle = BorderStyle.FixedSingle;
            this.attForca.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x141, 0x18);
            this.attForca.Location = point2;
            decimal num = new decimal(new int[] { 30, 0, 0, 0 });
            this.attForca.Maximum = num;
            this.attForca.Name = "attForca";
            size2 = new Size(0x2c, 0x15);
            this.attForca.Size = size2;
            this.attForca.TabIndex = 11;
            this.attForca.TextAlign = HorizontalAlignment.Center;
            this.attControle.BorderStyle = BorderStyle.FixedSingle;
            this.attControle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x141, 0x30);
            this.attControle.Location = point2;
            num = new decimal(new int[] { 30, 0, 0, 0 });
            this.attControle.Maximum = num;
            this.attControle.Name = "attControle";
            size2 = new Size(0x2c, 0x15);
            this.attControle.Size = size2;
            this.attControle.TabIndex = 13;
            this.attControle.TextAlign = HorizontalAlignment.Center;
            this.attPrecisao.BorderStyle = BorderStyle.FixedSingle;
            this.attPrecisao.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x141, 0x49);
            this.attPrecisao.Location = point2;
            num = new decimal(new int[] { 30, 0, 0, 0 });
            this.attPrecisao.Maximum = num;
            this.attPrecisao.Name = "attPrecisao";
            size2 = new Size(0x2c, 0x15);
            this.attPrecisao.Size = size2;
            this.attPrecisao.TabIndex = 15;
            this.attPrecisao.TextAlign = HorizontalAlignment.Center;
            this.attSpin.BorderStyle = BorderStyle.FixedSingle;
            this.attSpin.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x141, 0x62);
            this.attSpin.Location = point2;
            num = new decimal(new int[] { 30, 0, 0, 0 });
            this.attSpin.Maximum = num;
            this.attSpin.Name = "attSpin";
            size2 = new Size(0x2c, 0x15);
            this.attSpin.Size = size2;
            this.attSpin.TabIndex = 0x11;
            this.attSpin.TextAlign = HorizontalAlignment.Center;
            this.attCurva.BorderStyle = BorderStyle.FixedSingle;
            this.attCurva.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x141, 0x7b);
            this.attCurva.Location = point2;
            num = new decimal(new int[] { 30, 0, 0, 0 });
            this.attCurva.Maximum = num;
            this.attCurva.Name = "attCurva";
            size2 = new Size(0x2c, 0x15);
            this.attCurva.Size = size2;
            this.attCurva.TabIndex = 0x13;
            this.attCurva.TextAlign = HorizontalAlignment.Center;
            this.Panel10.Controls.Add(this.attCurva);
            this.Panel10.Controls.Add(this.attSpin);
            this.Panel10.Controls.Add(this.attPrecisao);
            this.Panel10.Controls.Add(this.attControle);
            this.Panel10.Controls.Add(this.attForca);
            this.Panel10.Controls.Add(this.Panel9);
            this.Panel10.Controls.Add(this.Panel8);
            this.Panel10.Controls.Add(this.Panel7);
            this.Panel10.Controls.Add(this.Panel6);
            this.Panel10.Controls.Add(this.Panel5);
            this.Panel10.Controls.Add(this.Label9);
            this.Panel10.Controls.Add(this.Label14);
            this.Panel10.Controls.Add(this.Label13);
            this.Panel10.Controls.Add(this.Label12);
            this.Panel10.Controls.Add(this.Label11);
            this.Panel10.Controls.Add(this.Label10);
            this.Panel10.Controls.Add(this.Label15);
            point2 = new Point(0, 0xdf);
            this.Panel10.Location = point2;
            this.Panel10.Name = "Panel10";
            size2 = new Size(0x174, 0x9a);
            this.Panel10.Size = size2;
            this.Panel10.TabIndex = 0x19;
            SizeF ef2 = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef2;
            this.AutoScaleMode = AutoScaleMode.Font;
            size2 = new Size(0x329, 0x224);
            this.ClientSize = size2;
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "frmCaddie";
            this.Text = "Caddie - Editor IFF ";
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((ISupportInitialize) this.ListaItem).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((ISupportInitialize) this.imgStatus).EndInit();
            ((ISupportInitialize) this.PictureBox4).EndInit();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.Panel4.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((ISupportInitialize) this.imgIcone).EndInit();
            this.gbTempoVenda.ResumeLayout(false);
            this.gbTempoVenda.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((ISupportInitialize) this.imgPersonagem).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.gbBotoes.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel6.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel8.ResumeLayout(false);
            this.Panel9.ResumeLayout(false);
            this.attForca.EndInit();
            this.attControle.EndInit();
            this.attPrecisao.EndInit();
            this.attSpin.EndInit();
            this.attCurva.EndInit();
            this.Panel10.ResumeLayout(false);
            this.Panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                this.pintarLinhas();
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void ListaItem_MouseHover(object sender, EventArgs e)
        {
            if (this.Alterado)
            {
                if (MessageBox.Show("Existem altera\x00e7\x00f5es que n\x00e3o foram salvas, desaja salva-las agora?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.salvarAlteracoes();
                }
                else
                {
                    this.Alterado = false;
                }
            }
        }

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            this.pintarLinhas();
        }

        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                if (this.ListaItem.SelectedRows.Count > 1)
                {
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.btnNovo.Enabled = false;
                    this.btnBackup.Enabled = false;
                    this.btnSalvar.Enabled = false;
                    this.btnReabrir.Enabled = false;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                    this.menuMassa.Enabled = true;
                    this.menuDividir.Enabled = true;
                    this.menuGerarCache.Enabled = true;
                }
                else if (this.ListaItem.SelectedCells[0].RowIndex < 0)
                {
                    this.gbBotoes.Enabled = false;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.menuSalvarComo.Enabled = false;
                    this.menuTypeid.Enabled = false;
                    this.menuBackup.Enabled = false;
                    this.menuGerarSql.Enabled = false;
                    this.menuMassa.Enabled = false;
                    this.menuDividir.Enabled = false;
                    this.menuGerarCache.Enabled = false;
                }
                else
                {
                    this.btnNovo.Enabled = true;
                    this.btnBackup.Enabled = true;
                    this.btnSalvar.Enabled = true;
                    this.btnReabrir.Enabled = true;
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = true;
                    this.txtPesquisa.Enabled = true;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                    this.menuMassa.Enabled = true;
                    this.menuDividir.Enabled = true;
                    this.menuGerarCache.Enabled = true;
                    this.CarregarItem();
                }
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                this.txtTypeID.BackColor = !this.verificarTYPEID(0) ? Color.White : Color.LightSalmon;
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            this.pintarLinhas();
        }

        private void menuGerarCache_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            List<string> list2 = new List<string>();
            foreach (Caddie caddie in this.lsTemp)
            {
                list.Add((int) caddie.ItemID);
                list2.Add(caddie.Icon);
            }
            new frmCache { 
                ls = list,
                ls1 = list2,
                tipo = 1,
                TopMost = true
            }.Show();
        }

        public void nomeArquivo()
        {
            int length = 0x19;
            this.lbArquivo.Text = (Strings.Len(this.Arquivo) <= 0x19) ? this.Arquivo : ("..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length));
        }

        public void pintarLinhas()
        {
            int num2 = this.ListaItem.Rows.Count - 1;
            int num = 0;
            while (true)
            {
                int num3 = num2;
                if (num > num3)
                {
                    this.ListaItem.Columns[0].Width = 0x2d;
                    this.ListaItem.Columns[2].Width = 30;
                    this.ListaItem.Columns[5].Width = 30;
                    return;
                }
                this.ListaItem.Rows[num].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", num].Value, 1, false))
                {
                    this.ListaItem.Rows[num].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                }
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", num].Value, 2, false))
                {
                    this.ListaItem.Rows[num].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                }
                num++;
            }
        }

        public void salvar(BackgroundWorker BW)
        {
            byte[] bs = (byte[]) Util.setValues(this.lsItens, this.bStart, (long) this.lsItens.Count, true);
            Util.gravarArquivo((byte[]) Util.setValues(this.lsTemp, this.bStart, this.qtdItem, true), this.Arquivo, ref BW);
            Util.gerarBackup(bs, this.Arquivo, ref false, ref 0);
        }

        private void salvarAlteracoes()
        {
            int num = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
            this.lsTemp[num].isValid = !this.ckAtivo.Checked ? ((byte) Conversions.ToLong("&H00")) : ((byte) Conversions.ToLong("&H01"));
            this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H00");
            if (this.ckNew.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H11");
            }
            else if (this.ckNew.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H13");
            }
            if (this.ckHot.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H21");
            }
            else if (this.ckHot.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H23");
            }
            if (this.ckNormal.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H01");
            }
            else if (this.ckNormal.Checked)
            {
                this.lsTemp[num].moneyFlag = (byte) Conversions.ToLong("&H03");
            }
            this.lsTemp[num].ItemName = this.txtNome.Text;
            this.lsTemp[num].ItemPrice = Conversions.ToLong(this.txtPreco.Text);
            this.lsTemp[num].ItemID = Conversions.ToLong(this.txtTypeID.Text);
            this.lsTemp[num].Icon = this.txtIcone.Text;
            this.lsTemp[num].lvlReq = (byte) this.cbLevel.SelectedIndex;
            this.lsTemp[num].DiscountPrice = Conversions.ToLong(this.txtDesconto.Text);
            this.lsTemp[num].statForce = Convert.ToInt16(this.attForca.Value);
            this.lsTemp[num].statControl = Convert.ToInt16(this.attControle.Value);
            this.lsTemp[num].statImpact = Convert.ToInt16(this.attPrecisao.Value);
            this.lsTemp[num].statSpin = Convert.ToInt16(this.attSpin.Value);
            this.lsTemp[num].statCurve = Convert.ToInt16(this.attCurva.Value);
            this.lsTemp[num].Salary = Conversions.ToLong(this.txtSalary.Text);
            this.lsTemp[num].SpriteName = this.txtSprite.Text;
            this.lsTemp[num].lvlReq = !this.rbLevelMin.Checked ? ((byte) (Conversions.ToLong("&H80") + this.cbLevel.SelectedIndex)) : ((byte) this.cbLevel.SelectedIndex);
            switch (this.cbTipo.SelectedIndex)
            {
                case 0:
                    this.lsTemp[num].shopFlag = (byte) Conversions.ToLong("&H00");
                    break;

                case 1:
                    this.lsTemp[num].shopFlag = (byte) Conversions.ToLong("&H01");
                    break;

                case 2:
                    this.lsTemp[num].shopFlag = (byte) Conversions.ToLong("&H02");
                    break;

                default:
                    break;
            }
            if (this.ckTempoAtivo.Checked)
            {
                Caddie caddie = this.lsTemp[num];
                caddie.tDay = (short) this.dtTermino.Value.Day;
                caddie.tMonth = (short) this.dtTermino.Value.Month;
                caddie.tYear = (short) this.dtTermino.Value.Year;
                caddie.tHour = (short) this.dtTermino.Value.Hour;
                caddie.tMinute = (short) this.dtTermino.Value.Minute;
                caddie.tSecond = (short) this.dtTermino.Value.Second;
                caddie.tZero = 1;
                caddie = null;
                Caddie caddie2 = this.lsTemp[num];
                caddie2.fDay = (short) this.dtInicio.Value.Day;
                caddie2.fMonth = (short) this.dtInicio.Value.Month;
                caddie2.fYear = (short) this.dtInicio.Value.Year;
                caddie2.fHour = (short) this.dtInicio.Value.Hour;
                caddie2.fMinute = (short) this.dtInicio.Value.Minute;
                caddie2.fSecond = (short) this.dtInicio.Value.Second;
                caddie2.fZero = 1;
                caddie2 = null;
            }
            this.ListaItem.SelectedRows[0].Cells[1].Value = this.txtNome.Text;
            this.ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            this.Alterado = false;
            this.qtdItem = this.ListaItem.Rows.Count;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int) this.diagSalvarArquivo.ShowDialog());
            this.Arquivo = this.diagSalvarArquivo.FileName;
            if (this.Arquivo != null)
            {
                this.bs.Filter = "";
                this.ComboBox1.SelectedIndex = 0;
                this.ComboBox2.SelectedIndex = 0;
                this.salvarAlteracoes();
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bs.Filter = "";
                this.pbStatus.Style = ProgressBarStyle.Marquee;
                this.bwSalvar.RunWorkerAsync();
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int) this.diagSalvarSql.ShowDialog());
            this.Arquivo = this.diagSalvarSql.FileName;
            if (this.Arquivo != null)
            {
                if (File.Exists(this.Arquivo))
                {
                    File.Delete(this.Arquivo);
                }
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bwGerarSql.RunWorkerAsync();
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Util.gerarBackup((byte[]) Util.setValues(this.lsTemp, this.bStart, this.qtdItem, true), MySettingsProperty.Settings.ArquivoIff, ref true, ref 0)))
            {
                MessageBox.Show("Backup gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Erro ao gerar o backup", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            PictureBox imgIcone = this.imgIcone;
            this.carregarImagem(Conversions.ToString(Util.getImage(this.txtTypeID.Text, this.txtIcone.Text)), ref imgIcone);
            this.imgIcone = imgIcone;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            this.lbContNome.Text = Conversions.ToString(this.txtNome.Text.Length) + "/40";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
        }

        private bool verificarTYPEID(int typeid = 0)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0)
            {
                typeid = Conversions.ToInteger(this.txtTypeID.Text);
            }
            else
            {
                flag = true;
            }
            foreach (Caddie caddie in this.lsTemp)
            {
                if (caddie.ItemID == typeid)
                {
                    num++;
                }
            }
            return (!flag ? (num > 1) : (num >= 1));
        }

        internal virtual StatusStrip StatusStrip1
        {
            [DebuggerNonUserCode]
            get => 
                this._StatusStrip1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._StatusStrip1 = value;
        }

        internal virtual ToolStrip ToolStrip1
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolStrip1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolStrip1 = value;
        }

        internal virtual SplitContainer SplitContainer1
        {
            [DebuggerNonUserCode]
            get => 
                this._SplitContainer1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._SplitContainer1 = value;
        }

        internal virtual Panel Panel3
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel3;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel3 = value;
        }

        internal virtual Panel Panel1
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel1 = value;
        }

        internal virtual PictureBox PictureBox1
        {
            [DebuggerNonUserCode]
            get => 
                this._PictureBox1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._PictureBox1 = value;
        }

        internal virtual TextBox txtPesquisa
        {
            [DebuggerNonUserCode]
            get => 
                this._txtPesquisa;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.txtPesquisa_TextChanged);
                if (!ReferenceEquals(this._txtPesquisa, null))
                {
                    this._txtPesquisa.TextChanged -= handler;
                }
                this._txtPesquisa = value;
                if (!ReferenceEquals(this._txtPesquisa, null))
                {
                    this._txtPesquisa.TextChanged += handler;
                }
            }
        }

        internal virtual GroupBox gbBotoes
        {
            [DebuggerNonUserCode]
            get => 
                this._gbBotoes;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._gbBotoes = value;
        }

        internal virtual Panel Panel4
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel4;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel4 = value;
        }

        internal virtual TabControl tabForm
        {
            [DebuggerNonUserCode]
            get => 
                this._tabForm;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._tabForm = value;
        }

        internal virtual TabPage TabPage1
        {
            [DebuggerNonUserCode]
            get => 
                this._TabPage1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._TabPage1 = value;
        }

        internal virtual TabPage TabPage2
        {
            [DebuggerNonUserCode]
            get => 
                this._TabPage2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._TabPage2 = value;
        }

        internal virtual RadioButton rbLevelMax
        {
            [DebuggerNonUserCode]
            get => 
                this._rbLevelMax;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._rbLevelMax = value;
        }

        internal virtual RadioButton rbLevelMin
        {
            [DebuggerNonUserCode]
            get => 
                this._rbLevelMin;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._rbLevelMin = value;
        }

        internal virtual ComboBox cbLevel
        {
            [DebuggerNonUserCode]
            get => 
                this._cbLevel;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._cbLevel = value;
        }

        internal virtual CheckBox ckAtivo
        {
            [DebuggerNonUserCode]
            get => 
                this._ckAtivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ckAtivo = value;
        }

        internal virtual PictureBox imgIcone
        {
            [DebuggerNonUserCode]
            get => 
                this._imgIcone;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._imgIcone = value;
        }

        internal virtual Label Label6
        {
            [DebuggerNonUserCode]
            get => 
                this._Label6;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label6 = value;
        }

        internal virtual TextBox txtNome
        {
            [DebuggerNonUserCode]
            get => 
                this._txtNome;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this._Lambda$__5);
                EventHandler handler2 = new EventHandler(this.txtNome_TextChanged);
                if (!ReferenceEquals(this._txtNome, null))
                {
                    this._txtNome.TextChanged -= handler;
                    this._txtNome.TextChanged -= handler2;
                }
                this._txtNome = value;
                if (!ReferenceEquals(this._txtNome, null))
                {
                    this._txtNome.TextChanged += handler;
                    this._txtNome.TextChanged += handler2;
                }
            }
        }

        internal virtual Label Label3
        {
            [DebuggerNonUserCode]
            get => 
                this._Label3;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label3 = value;
        }

        internal virtual Label lbContNome
        {
            [DebuggerNonUserCode]
            get => 
                this._lbContNome;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._lbContNome = value;
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get => 
                this._Label1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label1 = value;
        }

        internal virtual ToolStripButton btnAbrirArquivo
        {
            [DebuggerNonUserCode]
            get => 
                this._btnAbrirArquivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnAbrirArquivo_Click);
                if (!ReferenceEquals(this._btnAbrirArquivo, null))
                {
                    this._btnAbrirArquivo.Click -= handler;
                }
                this._btnAbrirArquivo = value;
                if (!ReferenceEquals(this._btnAbrirArquivo, null))
                {
                    this._btnAbrirArquivo.Click += handler;
                }
            }
        }

        internal virtual OpenFileDialog diagAbrirArquivo
        {
            [DebuggerNonUserCode]
            get => 
                this._diagAbrirArquivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._diagAbrirArquivo = value;
        }

        internal virtual TextBox txtIcone
        {
            [DebuggerNonUserCode]
            get => 
                this._txtIcone;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this._Lambda$__6);
                EventHandler handler2 = new EventHandler(this.txtIcone_TextChanged);
                if (!ReferenceEquals(this._txtIcone, null))
                {
                    this._txtIcone.TextChanged -= handler;
                    this._txtIcone.TextChanged -= handler2;
                }
                this._txtIcone = value;
                if (!ReferenceEquals(this._txtIcone, null))
                {
                    this._txtIcone.TextChanged += handler;
                    this._txtIcone.TextChanged += handler2;
                }
            }
        }

        internal virtual Label Label7
        {
            [DebuggerNonUserCode]
            get => 
                this._Label7;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label7 = value;
        }

        internal virtual ToolStripStatusLabel ToolStripStatusLabel1
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolStripStatusLabel1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolStripStatusLabel1 = value;
        }

        internal virtual ToolStripStatusLabel lbTotalItens
        {
            [DebuggerNonUserCode]
            get => 
                this._lbTotalItens;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._lbTotalItens = value;
        }

        internal virtual Label Label2
        {
            [DebuggerNonUserCode]
            get => 
                this._Label2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label2 = value;
        }

        internal virtual TextBox txtPreco
        {
            [DebuggerNonUserCode]
            get => 
                this._txtPreco;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this._Lambda$__7);
                if (!ReferenceEquals(this._txtPreco, null))
                {
                    this._txtPreco.TextChanged -= handler;
                }
                this._txtPreco = value;
                if (!ReferenceEquals(this._txtPreco, null))
                {
                    this._txtPreco.TextChanged += handler;
                }
            }
        }

        internal virtual Label Label4
        {
            [DebuggerNonUserCode]
            get => 
                this._Label4;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label4 = value;
        }

        internal virtual Button btnReabrir
        {
            [DebuggerNonUserCode]
            get => 
                this._btnReabrir;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnReabrir_Click);
                if (!ReferenceEquals(this._btnReabrir, null))
                {
                    this._btnReabrir.Click -= handler;
                }
                this._btnReabrir = value;
                if (!ReferenceEquals(this._btnReabrir, null))
                {
                    this._btnReabrir.Click += handler;
                }
            }
        }

        internal virtual Button btnNovo
        {
            [DebuggerNonUserCode]
            get => 
                this._btnNovo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnNovo_Click);
                if (!ReferenceEquals(this._btnNovo, null))
                {
                    this._btnNovo.Click -= handler;
                }
                this._btnNovo = value;
                if (!ReferenceEquals(this._btnNovo, null))
                {
                    this._btnNovo.Click += handler;
                }
            }
        }

        internal virtual Button btnRemover
        {
            [DebuggerNonUserCode]
            get => 
                this._btnRemover;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnRemover_Click);
                if (!ReferenceEquals(this._btnRemover, null))
                {
                    this._btnRemover.Click -= handler;
                }
                this._btnRemover = value;
                if (!ReferenceEquals(this._btnRemover, null))
                {
                    this._btnRemover.Click += handler;
                }
            }
        }

        internal virtual Button btnBackup
        {
            [DebuggerNonUserCode]
            get => 
                this._btnBackup;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnBackup_Click);
                if (!ReferenceEquals(this._btnBackup, null))
                {
                    this._btnBackup.Click -= handler;
                }
                this._btnBackup = value;
                if (!ReferenceEquals(this._btnBackup, null))
                {
                    this._btnBackup.Click += handler;
                }
            }
        }

        internal virtual Button btnSalvar
        {
            [DebuggerNonUserCode]
            get => 
                this._btnSalvar;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnSalvar_Click);
                if (!ReferenceEquals(this._btnSalvar, null))
                {
                    this._btnSalvar.Click -= handler;
                }
                this._btnSalvar = value;
                if (!ReferenceEquals(this._btnSalvar, null))
                {
                    this._btnSalvar.Click += handler;
                }
            }
        }

        internal virtual ComboBox cbTipo
        {
            [DebuggerNonUserCode]
            get => 
                this._cbTipo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._cbTipo = value;
        }

        internal virtual Label Label8
        {
            [DebuggerNonUserCode]
            get => 
                this._Label8;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label8 = value;
        }

        internal virtual GroupBox GroupBox1
        {
            [DebuggerNonUserCode]
            get => 
                this._GroupBox1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._GroupBox1 = value;
        }

        internal virtual CheckBox ckNew
        {
            [DebuggerNonUserCode]
            get => 
                this._ckNew;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ckNew_CheckedChanged);
                if (!ReferenceEquals(this._ckNew, null))
                {
                    this._ckNew.CheckStateChanged -= handler;
                }
                this._ckNew = value;
                if (!ReferenceEquals(this._ckNew, null))
                {
                    this._ckNew.CheckStateChanged += handler;
                }
            }
        }

        internal virtual CheckBox ckNormal
        {
            [DebuggerNonUserCode]
            get => 
                this._ckNormal;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ckNormal_CheckedChanged);
                if (!ReferenceEquals(this._ckNormal, null))
                {
                    this._ckNormal.CheckStateChanged -= handler;
                }
                this._ckNormal = value;
                if (!ReferenceEquals(this._ckNormal, null))
                {
                    this._ckNormal.CheckStateChanged += handler;
                }
            }
        }

        internal virtual CheckBox ckGift
        {
            [DebuggerNonUserCode]
            get => 
                this._ckGift;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ckGift = value;
        }

        internal virtual CheckBox ckHot
        {
            [DebuggerNonUserCode]
            get => 
                this._ckHot;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ckHot_CheckedChanged);
                if (!ReferenceEquals(this._ckHot, null))
                {
                    this._ckHot.CheckStateChanged -= handler;
                }
                this._ckHot = value;
                if (!ReferenceEquals(this._ckHot, null))
                {
                    this._ckHot.CheckStateChanged += handler;
                }
            }
        }

        internal virtual ToolStripStatusLabel ToolStripStatusLabel2
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolStripStatusLabel2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolStripStatusLabel2 = value;
        }

        internal virtual ToolStripStatusLabel lbStatus
        {
            [DebuggerNonUserCode]
            get => 
                this._lbStatus;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._lbStatus = value;
        }

        internal virtual Label Label18
        {
            [DebuggerNonUserCode]
            get => 
                this._Label18;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label18 = value;
        }

        internal virtual TextBox txtDesconto
        {
            [DebuggerNonUserCode]
            get => 
                this._txtDesconto;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._txtDesconto = value;
        }

        internal virtual Panel Panel2
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel2 = value;
        }

        internal virtual TextBox txtSprite
        {
            [DebuggerNonUserCode]
            get => 
                this._txtSprite;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._txtSprite = value;
        }

        internal virtual Label labeladd
        {
            [DebuggerNonUserCode]
            get => 
                this._labeladd;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._labeladd = value;
        }

        internal virtual GroupBox GroupBox3
        {
            [DebuggerNonUserCode]
            get => 
                this._GroupBox3;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._GroupBox3 = value;
        }

        internal virtual Label Label23
        {
            [DebuggerNonUserCode]
            get => 
                this._Label23;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label23 = value;
        }

        internal virtual TextBox txtSalary
        {
            [DebuggerNonUserCode]
            get => 
                this._txtSalary;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._txtSalary = value;
        }

        internal virtual Label Label29
        {
            [DebuggerNonUserCode]
            get => 
                this._Label29;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label29 = value;
        }

        internal virtual GroupBox gbTempoVenda
        {
            [DebuggerNonUserCode]
            get => 
                this._gbTempoVenda;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._gbTempoVenda = value;
        }

        internal virtual CheckBox ckTempoAtivo
        {
            [DebuggerNonUserCode]
            get => 
                this._ckTempoAtivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ckTempoAtivo_CheckedChanged);
                if (!ReferenceEquals(this._ckTempoAtivo, null))
                {
                    this._ckTempoAtivo.CheckedChanged -= handler;
                }
                this._ckTempoAtivo = value;
                if (!ReferenceEquals(this._ckTempoAtivo, null))
                {
                    this._ckTempoAtivo.CheckedChanged += handler;
                }
            }
        }

        internal virtual DateTimePicker dtTermino
        {
            [DebuggerNonUserCode]
            get => 
                this._dtTermino;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._dtTermino = value;
        }

        internal virtual DateTimePicker dtInicio
        {
            [DebuggerNonUserCode]
            get => 
                this._dtInicio;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._dtInicio = value;
        }

        internal virtual Label Label28
        {
            [DebuggerNonUserCode]
            get => 
                this._Label28;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label28 = value;
        }

        internal virtual Label Label27
        {
            [DebuggerNonUserCode]
            get => 
                this._Label27;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label27 = value;
        }

        internal virtual CheckBox ckDesativado
        {
            [DebuggerNonUserCode]
            get => 
                this._ckDesativado;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ckDesativado_CheckedChanged);
                EventHandler handler2 = new EventHandler(this.ckNormal_CheckedChanged);
                if (!ReferenceEquals(this._ckDesativado, null))
                {
                    this._ckDesativado.CheckedChanged -= handler;
                    this._ckDesativado.CheckStateChanged -= handler2;
                }
                this._ckDesativado = value;
                if (!ReferenceEquals(this._ckDesativado, null))
                {
                    this._ckDesativado.CheckedChanged += handler;
                    this._ckDesativado.CheckStateChanged += handler2;
                }
            }
        }

        internal virtual DataGridView ListaItem
        {
            [DebuggerNonUserCode]
            get => 
                this._ListaItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.listaItem_SelectedIndexChanged);
                EventHandler handler2 = new EventHandler(this.ListaItem_DefaultCellStyleChanged);
                EventHandler handler3 = new EventHandler(this.ListaItem_RowsDefaultCellStyleChanged);
                EventHandler handler4 = new EventHandler(this.ListaItem_Sorted);
                if (!ReferenceEquals(this._ListaItem, null))
                {
                    this._ListaItem.SelectionChanged -= handler;
                    this._ListaItem.DefaultCellStyleChanged -= handler2;
                    this._ListaItem.RowsDefaultCellStyleChanged -= handler3;
                    this._ListaItem.Sorted -= handler4;
                }
                this._ListaItem = value;
                if (!ReferenceEquals(this._ListaItem, null))
                {
                    this._ListaItem.SelectionChanged += handler;
                    this._ListaItem.DefaultCellStyleChanged += handler2;
                    this._ListaItem.RowsDefaultCellStyleChanged += handler3;
                    this._ListaItem.Sorted += handler4;
                }
            }
        }

        internal virtual SaveFileDialog diagSalvarArquivo
        {
            [DebuggerNonUserCode]
            get => 
                this._diagSalvarArquivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._diagSalvarArquivo = value;
        }

        internal virtual ToolStripButton menuSalvarComo
        {
            [DebuggerNonUserCode]
            get => 
                this._menuSalvarComo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ToolStripButton1_Click);
                if (!ReferenceEquals(this._menuSalvarComo, null))
                {
                    this._menuSalvarComo.Click -= handler;
                }
                this._menuSalvarComo = value;
                if (!ReferenceEquals(this._menuSalvarComo, null))
                {
                    this._menuSalvarComo.Click += handler;
                }
            }
        }

        internal virtual PictureBox PictureBox2
        {
            [DebuggerNonUserCode]
            get => 
                this._PictureBox2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._PictureBox2 = value;
        }

        internal virtual Label lbArquivo
        {
            [DebuggerNonUserCode]
            get => 
                this._lbArquivo;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._lbArquivo = value;
        }

        internal virtual ToolStripStatusLabel ToolStripStatusLabel4
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolStripStatusLabel4;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolStripStatusLabel4 = value;
        }

        internal virtual ToolStripStatusLabel lbIndices
        {
            [DebuggerNonUserCode]
            get => 
                this._lbIndices;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._lbIndices = value;
        }

        internal virtual ToolStripProgressBar pbStatus
        {
            [DebuggerNonUserCode]
            get => 
                this._pbStatus;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._pbStatus = value;
        }

        internal virtual ToolStripButton menuGerarSql
        {
            [DebuggerNonUserCode]
            get => 
                this._menuGerarSql;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ToolStripButton2_Click);
                if (!ReferenceEquals(this._menuGerarSql, null))
                {
                    this._menuGerarSql.Click -= handler;
                }
                this._menuGerarSql = value;
                if (!ReferenceEquals(this._menuGerarSql, null))
                {
                    this._menuGerarSql.Click += handler;
                }
            }
        }

        public virtual TextBox txtTypeID
        {
            [DebuggerNonUserCode]
            get => 
                this._txtTypeID;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this._Lambda$__8);
                if (!ReferenceEquals(this._txtTypeID, null))
                {
                    this._txtTypeID.TextChanged -= handler;
                }
                this._txtTypeID = value;
                if (!ReferenceEquals(this._txtTypeID, null))
                {
                    this._txtTypeID.TextChanged += handler;
                }
            }
        }

        internal virtual SaveFileDialog diagSalvarSql
        {
            [DebuggerNonUserCode]
            get => 
                this._diagSalvarSql;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._diagSalvarSql = value;
        }

        internal virtual ToolStripDropDownButton menuMassa
        {
            [DebuggerNonUserCode]
            get => 
                this._menuMassa;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._menuMassa = value;
        }

        internal virtual ToolStripButton menuBackup
        {
            [DebuggerNonUserCode]
            get => 
                this._menuBackup;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ToolStripButton4_Click);
                if (!ReferenceEquals(this._menuBackup, null))
                {
                    this._menuBackup.Click -= handler;
                }
                this._menuBackup = value;
                if (!ReferenceEquals(this._menuBackup, null))
                {
                    this._menuBackup.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ToolStripMenuItem_0
        {
            [DebuggerNonUserCode]
            get => 
                this.toolStripMenuItem_0;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this.toolStripMenuItem_0 = value;
        }

        internal virtual ToolStripMenuItem DesativarTodosToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._DesativarTodosToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._DesativarTodosToolStripMenuItem = value;
        }

        internal virtual ToolStripMenuItem AtivarTodosToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._AtivarTodosToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._AtivarTodosToolStripMenuItem = value;
        }

        internal virtual ToolStripMenuItem ToolStripMenuItem_1
        {
            [DebuggerNonUserCode]
            get => 
                this.toolStripMenuItem_1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this.toolStripMenuItem_1 = value;
        }

        internal virtual ToolStripMenuItem ToolStripMenuItem_2
        {
            [DebuggerNonUserCode]
            get => 
                this.toolStripMenuItem_2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this.toolStripMenuItem_2 = value;
        }

        internal virtual ToolStripMenuItem LevelMinimoToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._LevelMinimoToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._LevelMinimoToolStripMenuItem = value;
        }

        internal virtual ToolStripSeparator ToolStripMenuItem1
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolStripMenuItem1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolStripMenuItem1 = value;
        }

        internal virtual ToolStripMenuItem ApagarTodosToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._ApagarTodosToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ApagarTodosToolStripMenuItem = value;
        }

        internal virtual BackgroundWorker bwSalvar
        {
            [DebuggerNonUserCode]
            get => 
                this._bwSalvar;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                RunWorkerCompletedEventHandler handler = new RunWorkerCompletedEventHandler(this.bwSalvar_RunWorkerCompleted);
                ProgressChangedEventHandler handler2 = new ProgressChangedEventHandler(this.bwSalvar_ProgressChanged);
                DoWorkEventHandler handler3 = new DoWorkEventHandler(this.bwSalvar_DoWork);
                if (!ReferenceEquals(this._bwSalvar, null))
                {
                    this._bwSalvar.RunWorkerCompleted -= handler;
                    this._bwSalvar.ProgressChanged -= handler2;
                    this._bwSalvar.DoWork -= handler3;
                }
                this._bwSalvar = value;
                if (!ReferenceEquals(this._bwSalvar, null))
                {
                    this._bwSalvar.RunWorkerCompleted += handler;
                    this._bwSalvar.ProgressChanged += handler2;
                    this._bwSalvar.DoWork += handler3;
                }
            }
        }

        internal virtual BackgroundWorker bwGerarSql
        {
            [DebuggerNonUserCode]
            get => 
                this._bwGerarSql;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                RunWorkerCompletedEventHandler handler = new RunWorkerCompletedEventHandler(this.bwGerarSql_RunWorkerCompleted);
                ProgressChangedEventHandler handler2 = new ProgressChangedEventHandler(this.bwGerarSql_ProgressChanged);
                DoWorkEventHandler handler3 = new DoWorkEventHandler(this.bwGerarSql_DoWork);
                if (!ReferenceEquals(this._bwGerarSql, null))
                {
                    this._bwGerarSql.RunWorkerCompleted -= handler;
                    this._bwGerarSql.ProgressChanged -= handler2;
                    this._bwGerarSql.DoWork -= handler3;
                }
                this._bwGerarSql = value;
                if (!ReferenceEquals(this._bwGerarSql, null))
                {
                    this._bwGerarSql.RunWorkerCompleted += handler;
                    this._bwGerarSql.ProgressChanged += handler2;
                    this._bwGerarSql.DoWork += handler3;
                }
            }
        }

        internal virtual PictureBox PictureBox4
        {
            [DebuggerNonUserCode]
            get => 
                this._PictureBox4;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._PictureBox4 = value;
        }

        internal virtual Label Label33
        {
            [DebuggerNonUserCode]
            get => 
                this._Label33;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label33 = value;
        }

        internal virtual ImageList ImageList1
        {
            [DebuggerNonUserCode]
            get => 
                this._ImageList1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ImageList1 = value;
        }

        internal virtual PictureBox imgStatus
        {
            [DebuggerNonUserCode]
            get => 
                this._imgStatus;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._imgStatus = value;
        }

        internal virtual ComboBox ComboBox2
        {
            [DebuggerNonUserCode]
            get => 
                this._ComboBox2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.ComboBox2_SelectedIndexChanged);
                if (!ReferenceEquals(this._ComboBox2, null))
                {
                    this._ComboBox2.SelectedIndexChanged -= handler;
                }
                this._ComboBox2 = value;
                if (!ReferenceEquals(this._ComboBox2, null))
                {
                    this._ComboBox2.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual Label Label37
        {
            [DebuggerNonUserCode]
            get => 
                this._Label37;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label37 = value;
        }

        internal virtual Label Label39
        {
            [DebuggerNonUserCode]
            get => 
                this._Label39;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label39 = value;
        }

        internal virtual ToolStripButton menuTypeid
        {
            [DebuggerNonUserCode]
            get => 
                this._menuTypeid;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._menuTypeid = value;
        }

        internal virtual ImageList ImageList2
        {
            [DebuggerNonUserCode]
            get => 
                this._ImageList2;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ImageList2 = value;
        }

        internal virtual ToolStripDropDownButton menuDividir
        {
            [DebuggerNonUserCode]
            get => 
                this._menuDividir;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._menuDividir = value;
        }

        internal virtual ToolStripMenuItem DividirArquivoToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._DividirArquivoToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._DividirArquivoToolStripMenuItem = value;
        }

        internal virtual ToolStripMenuItem UnirArquivoToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._UnirArquivoToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._UnirArquivoToolStripMenuItem = value;
        }

        internal virtual FolderBrowserDialog diagPasta
        {
            [DebuggerNonUserCode]
            get => 
                this._diagPasta;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._diagPasta = value;
        }

        internal virtual ToolStripMenuItem AlterarDescontoToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get => 
                this._AlterarDescontoToolStripMenuItem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.AlterarDescontoToolStripMenuItem_Click);
                if (!ReferenceEquals(this._AlterarDescontoToolStripMenuItem, null))
                {
                    this._AlterarDescontoToolStripMenuItem.Click -= handler;
                }
                this._AlterarDescontoToolStripMenuItem = value;
                if (!ReferenceEquals(this._AlterarDescontoToolStripMenuItem, null))
                {
                    this._AlterarDescontoToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual Button btnVerificarTYPEID
        {
            [DebuggerNonUserCode]
            get => 
                this._btnVerificarTYPEID;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnVerificarTYPEID_Click);
                if (!ReferenceEquals(this._btnVerificarTYPEID, null))
                {
                    this._btnVerificarTYPEID.Click -= handler;
                }
                this._btnVerificarTYPEID = value;
                if (!ReferenceEquals(this._btnVerificarTYPEID, null))
                {
                    this._btnVerificarTYPEID.Click += handler;
                }
            }
        }

        internal virtual ToolTip ToolTip1
        {
            [DebuggerNonUserCode]
            get => 
                this._ToolTip1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ToolTip1 = value;
        }

        internal virtual ToolStripButton menuGerarCache
        {
            [DebuggerNonUserCode]
            get => 
                this._menuGerarCache;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.menuGerarCache_Click);
                if (!ReferenceEquals(this._menuGerarCache, null))
                {
                    this._menuGerarCache.Click -= handler;
                }
                this._menuGerarCache = value;
                if (!ReferenceEquals(this._menuGerarCache, null))
                {
                    this._menuGerarCache.Click += handler;
                }
            }
        }

        internal virtual PictureBox imgPersonagem
        {
            [DebuggerNonUserCode]
            get => 
                this._imgPersonagem;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._imgPersonagem = value;
        }

        internal virtual Label Label36
        {
            [DebuggerNonUserCode]
            get => 
                this._Label36;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label36 = value;
        }

        internal virtual ComboBox ComboBox1
        {
            [DebuggerNonUserCode]
            get => 
                this._ComboBox1;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._ComboBox1 = value;
        }

        internal virtual Panel Panel10
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel10;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel10 = value;
        }

        internal virtual NumericUpDown attCurva
        {
            [DebuggerNonUserCode]
            get => 
                this._attCurva;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.attCurva_ValueChanged);
                if (!ReferenceEquals(this._attCurva, null))
                {
                    this._attCurva.ValueChanged -= handler;
                }
                this._attCurva = value;
                if (!ReferenceEquals(this._attCurva, null))
                {
                    this._attCurva.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown attSpin
        {
            [DebuggerNonUserCode]
            get => 
                this._attSpin;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.attSpin_ValueChanged);
                if (!ReferenceEquals(this._attSpin, null))
                {
                    this._attSpin.ValueChanged -= handler;
                }
                this._attSpin = value;
                if (!ReferenceEquals(this._attSpin, null))
                {
                    this._attSpin.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown attPrecisao
        {
            [DebuggerNonUserCode]
            get => 
                this._attPrecisao;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.attPrecisao_ValueChanged);
                if (!ReferenceEquals(this._attPrecisao, null))
                {
                    this._attPrecisao.ValueChanged -= handler;
                }
                this._attPrecisao = value;
                if (!ReferenceEquals(this._attPrecisao, null))
                {
                    this._attPrecisao.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown attControle
        {
            [DebuggerNonUserCode]
            get => 
                this._attControle;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.attControle_ValueChanged);
                if (!ReferenceEquals(this._attControle, null))
                {
                    this._attControle.ValueChanged -= handler;
                }
                this._attControle = value;
                if (!ReferenceEquals(this._attControle, null))
                {
                    this._attControle.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown attForca
        {
            [DebuggerNonUserCode]
            get => 
                this._attForca;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.attForca_ValueChanged);
                if (!ReferenceEquals(this._attForca, null))
                {
                    this._attForca.ValueChanged -= handler;
                }
                this._attForca = value;
                if (!ReferenceEquals(this._attForca, null))
                {
                    this._attForca.ValueChanged += handler;
                }
            }
        }

        internal virtual Panel Panel9
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel9;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel9 = value;
        }

        internal virtual Panel barraCurva
        {
            [DebuggerNonUserCode]
            get => 
                this._barraCurva;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._barraCurva = value;
        }

        internal virtual Panel Panel8
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel8;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel8 = value;
        }

        internal virtual Panel barraSpin
        {
            [DebuggerNonUserCode]
            get => 
                this._barraSpin;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._barraSpin = value;
        }

        internal virtual Panel Panel7
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel7;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel7 = value;
        }

        internal virtual Panel barraPrecisao
        {
            [DebuggerNonUserCode]
            get => 
                this._barraPrecisao;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._barraPrecisao = value;
        }

        internal virtual Panel Panel6
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel6;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel6 = value;
        }

        internal virtual Panel barraControle
        {
            [DebuggerNonUserCode]
            get => 
                this._barraControle;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._barraControle = value;
        }

        internal virtual Panel Panel5
        {
            [DebuggerNonUserCode]
            get => 
                this._Panel5;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Panel5 = value;
        }

        internal virtual Panel barraForca
        {
            [DebuggerNonUserCode]
            get => 
                this._barraForca;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._barraForca = value;
        }

        internal virtual Label Label9
        {
            [DebuggerNonUserCode]
            get => 
                this._Label9;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label9 = value;
        }

        internal virtual Label Label14
        {
            [DebuggerNonUserCode]
            get => 
                this._Label14;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label14 = value;
        }

        internal virtual Label Label13
        {
            [DebuggerNonUserCode]
            get => 
                this._Label13;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label13 = value;
        }

        internal virtual Label Label12
        {
            [DebuggerNonUserCode]
            get => 
                this._Label12;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label12 = value;
        }

        internal virtual Label Label11
        {
            [DebuggerNonUserCode]
            get => 
                this._Label11;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label11 = value;
        }

        internal virtual Label Label10
        {
            [DebuggerNonUserCode]
            get => 
                this._Label10;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label10 = value;
        }

        internal virtual Label Label15
        {
            [DebuggerNonUserCode]
            get => 
                this._Label15;
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set => 
                this._Label15 = value;
        }
    }
}

