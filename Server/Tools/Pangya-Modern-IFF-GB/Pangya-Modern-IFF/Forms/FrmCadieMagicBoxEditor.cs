using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
    public partial class FrmCadieMagicBoxEditor : Form
    {
        public bool IsLoad;
        public FrmCadieMagicBoxEditor()
        {
            InitializeComponent();
        }

        private void FrmCadieMagicBoxEditor_Load(object sender, EventArgs e)
        {
            if (FrmMain.AutoLoadingIFF)
            {
                this.lsItens = FrmMain.IFF.CadieMagicBox;
                this.lsTemp = new CadieMagicBoxCollection();
                foreach (var record in FrmMain.IFF.CadieMagicBox)
                {
                    record.Name = FrmMain.IFF.GetItemName(record.TypeID);
                }
                this.Arquivo = "CadieMagicBox.iff";
                this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                lsTemp.Header = lsItens.Header;
                this.nomeArquivo();
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = this.lsItens.Count.ToString();
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }

            this.lsItens = new CadieMagicBoxCollection();
            this.lsTemp = new CadieMagicBoxCollection();
            this.Arquivo = this.diagAbrirArquivo.FileName;
#pragma warning disable CS0168 // A variável "exception1" está declarada, mas nunca é usada
            try
            {
                lsItens.Load(File.ReadAllBytes(Arquivo));
            }
            catch (Exception exception1)
            {

                MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
#pragma warning restore CS0168 // A variável "exception1" está declarada, mas nunca é usada
            this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
            lsTemp.Header = lsItens.Header;
            this.nomeArquivo();
            this.ListaItem.DataSource = null;
            CarregarGrid(this.lsTemp);
            this.lbIndices.Text = this.lsItens.Count.ToString();
        }

        public void nomeArquivo()
        {
            int num = 25;
            if (Arquivo.Length > 25)
            {
                lbArquivo.Text = "..." + Arquivo.Substring(checked(Arquivo.Length - num), num);
            }
            else
            {
                lbArquivo.Text = Arquivo;
            }
        }

        public void CarregarGrid(CadieMagicBoxCollection Lista)
        {
            new List<string>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Status", typeof(Image));
            dataTable.Columns.Add("Alterado", typeof(int));
            dataTable.Columns.Add("Page", typeof(int));

            int num = 0;
            int num2 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                int num4 = num3;
                int num5 = num2;
                if (num4 > num5)
                {
                    break;
                }
                oIff = Lista[num3];
                Image image = ((oIff.Enabled != 1L) ? Resources.delete1 : Resources.accept1);
                int num6 = 0;
                try
                {
                    if (IsLoad)
                    {
                        num6 = Conversions.ToInteger(ListaItem["Alterado", num].Value);
                    }
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    num6 = 0;
                    ProjectData.ClearProjectError();
                }
                var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(oIff.TypeID);
                if (iffCommon== null)
                {
                    iffCommon = new IFFCommon().CreateNewItem();
                    iffCommon.Name = "Unknown";
                }
                dataTable.Rows.Add(num3, iffCommon.Name,oIff.MagicID, image, num6,  (int)oIff.Page);
                num++;
                num3++;
            }
            ListaItem.DataSource = null;
            bs = new BindingSource();
            bs.DataSource = dataTable;
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;
            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
            int num7 = ListaItem.Rows.Count - 1;
            int num8 = 0;
            while (true)
            {
                int num9 = num8;
                int num5 = num7;
                if (num9 > num5)
                {
                    break;
                }
                ListaItem.Rows[num8].Selected = false;
                num8++;
            }
            organizarColunas();
            filtrar();
            try
            {
                ListaItem.FirstDisplayedScrollingRowIndex = lastRow - 3;
                ListaItem.Rows[lastRow].Selected = true;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                ProjectData.ClearProjectError();
            }
            pintarLinhas();
            organizarColunas();
        }

        public void organizarColunas()
        {
            ListaItem.Columns[2].Width = 0x2d;
            ListaItem.Columns[3].Width = 30;
            ListaItem.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[3].HeaderText = "   ";

            ListaItem.Columns[0].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[5].Visible = false;
            ListaItem.Columns[1].Visible = false;
        }

        public void pintarLinhas()
        {
            organizarColunas();
            checked
            {
                int num = ListaItem.Rows.Count - 1;
                int num2 = 0;
                while (true)
                {
                    int num3 = num2;
                    int num4 = num;
                    if (num3 > num4)
                    {
                        break;
                    }
                    ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                    }
                    num2++;
                }
                organizarColunas();
            }
        }

        private void CarregarItem()
        {
            checked
            {
                if (ListaItem.SelectedCells[0].RowIndex > -1)
                {
                    int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                    var item = lsTemp[index];
                    txtNome.Text = Conversions.ToString(item.Name);
                    txtTypeID.Text = Conversions.ToString(item.TypeID);
                    txtItemProdQtd.Value = new decimal(item.Quatity);
                    txtItem1.Text = Conversions.ToString(item.TradeID[0]);
                    txtItem2.Text = Conversions.ToString(item.TradeID[1]);
                    txtItem3.Text = Conversions.ToString(item.TradeID[2]);
                    txtItem4.Text = Conversions.ToString(item.TradeID[3]);
                    txtItem1Qtd.Text = Conversions.ToString(item.TradeQuantity[0]);
                    txtItem2Qtd.Text = Conversions.ToString(item.TradeQuantity[1]);
                    txtItem3Qtd.Text = Conversions.ToString(item.TradeQuantity[2]);
                    txtItem4Qtd.Text = Conversions.ToString(item.TradeQuantity[3]);
                    txtU6.Text = Conversions.ToString(item.BoxType);
                    if (item.TypeID > 0)
                    {

                        var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(item.TypeID);
                        if (iffCommon.Icon != "")
                        {
                            carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png");
                        }
                    }
                    if (lsTemp[index].Box_Random_ID > 0)
                    {
                        isRandom.Checked = true;
                    }
                    else
                    {
                        isRandom.Checked = false;
                    }
                    try
                    {
                        cbAba.SelectedIndex = (int)lsTemp[index].Page;
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        MessageBox.Show("Pagina do item inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cbAba.SelectedIndex = -1;
                        ProjectData.ClearProjectError();
                    }
                    txtIndex.Text = Conversions.ToString(lsTemp[index].MagicID);
                    ckAtivo.Checked = unchecked((ulong)lsTemp[index].Enabled) > 0uL;
                    int num;
                    if (lsTemp[index].Level <= 72L)
                    {
                        num = (int)lsTemp[index].Level;
                        rbLevelMin.Checked = true;
                    }
                    else
                    {
                        num = (int)(lsTemp[index].Level - 128L);
                        rbLevelMax.Checked = true;
                    }
                    cbLevel.SelectedIndex = num;


                    string text2 = Conversions.ToString((int)item.DateStart.Day);
                    string text3 = Conversions.ToString((int)item.DateStart.Month);
                    string text4 = Conversions.ToString((int)item.DateStart.Year);
                    string text5 = Conversions.ToString((int)item.DateStart.Hour);
                    string text6 = Conversions.ToString((int)item.DateStart.Minute);
                    string text7 = Conversions.ToString((int)item.DateStart.Second);

                    string text8 = Conversions.ToString((int)item.DateEnd.Day);
                    string text9 = Conversions.ToString((int)item.DateEnd.Month);
                    string text10 = Conversions.ToString((int)item.DateEnd.Year);
                    string text11 = Conversions.ToString((int)item.DateEnd.Hour);
                    string text12 = Conversions.ToString((int)item.DateEnd.Minute);
                    string text13 = Conversions.ToString((int)item.DateEnd.Second);
                    DateTime.TryParse(text2 + "/" + text3 + "/" + text4 + " " + text5 + ":" + text6 + ":" + text7, out var result);
                    DateTime.TryParse(text8 + "/" + text9 + "/" + text10 + " " + text11 + ":" + text12 + ":" + text13, out var result2);
                    try
                    {
                        if (result.Year > 1)
                            dtInicio.Value = item.DateStart.ConvertIFFToDateTime();
                        if (result2.Year > 1)
                            dtTermino.Value = result2;
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        dtInicio.Value = DateTime.Now.AddYears(-3);
                        dtTermino.Value = DateTime.Now.AddYears(-3);
                        ProjectData.ClearProjectError();
                    }
                    this.ckTempoAtivo.Checked = result.Year > 1 & result2.Year > 1;
                }
                Alterado = false;
                try
                {
                    Conversions.ToInteger(Operators.AddObject(ListaItem.Rows[ListaItem.SelectedRows[0].Index].Cells[3].Value, 1));
                }
                catch (Exception projectError2)
                {
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }
            }
        }
        private void carregarImagem(string path)
        {
            if (File.Exists(path))
            {
                this.imgIcone.Image = new Bitmap(path);
            }
            else
            {
                imgIcone.Image = Resources.ajax_loader;
            }

        }
        private void carregarImagem(string img, ref PictureBox obj)
        {
            if (File.Exists(img))
            {
                obj.Image = new Bitmap(img);
            }
            else
            {
                obj.Image = Resources.ajax_loader;
            }

        }

        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
                if (ListaItem.SelectedRows.Count > 1)
                {
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = false;
                    menuSalvarComo.Enabled = true;
                    btnCima.Enabled = false;
                    btnBaixo.Enabled = false;
                    btnIndices.Enabled = true;
                }
                else if (ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    btnCima.Enabled = true;
                    btnBaixo.Enabled = true;
                    btnIndices.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                    btnCima.Enabled = false;
                    btnBaixo.Enabled = false;
                    btnIndices.Enabled = false;
                }
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox1.SelectedIndex = 0;
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            salvarAlteracoes();
            pintarLinhas();
        }

        private void salvarAlteracoes()
        {
            int index = 0;
            try
            {
                index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            if (ckAtivo.Checked)
            {
                lsTemp[index].Enabled = (uint)Conversions.ToLong("&H01");
            }
            else
            {
                lsTemp[index].Enabled = (uint)Conversions.ToLong("&H00");
            }
            lsTemp[index].Name = txtNome.Text; 
            lsTemp[index].TypeID = (uint)Conversions.ToLong(txtTypeID.Text);
            lsTemp[index].Quatity = Convert.ToUInt32(txtItemProdQtd.Value);
            lsTemp[index].TradeID[0] = (uint)Conversions.ToLong(txtItem1.Text);
            lsTemp[index].TradeID[1] = (uint)Conversions.ToLong(txtItem2.Text);
            lsTemp[index].TradeID[2] = (uint)Conversions.ToLong(txtItem3.Text);
            lsTemp[index].TradeID[3] = (uint)Conversions.ToLong(txtItem4.Text);
            lsTemp[index].TradeQuantity[0] = (uint)Conversions.ToLong(txtItem1Qtd.Text);
            lsTemp[index].TradeQuantity[1] = (uint)Conversions.ToLong(txtItem2Qtd.Text);
            lsTemp[index].TradeQuantity[2] = (uint)Conversions.ToLong(txtItem3Qtd.Text);
            lsTemp[index].TradeQuantity[3] = (uint)Conversions.ToLong(txtItem4Qtd.Text);
            lsTemp[index].Page = (CadieBoxSetor)cbAba.SelectedIndex;
            lsTemp[index].MagicID = (uint)Conversions.ToLong(txtIndex.Text);
            lsTemp[index].BoxType = (CadieBoxEnum)Conversions.ToLong(txtU6.Text);
            if (isRandom.Checked)
            {

            }
            else
            {

            }
            if (rbLevelMin.Checked)
            {
                lsTemp[index].Level = (uint)cbLevel.SelectedIndex;
            }
            else
            {
                lsTemp[index].Level = (uint)checked(Conversions.ToLong("&H80") + cbLevel.SelectedIndex);
            }

            if (this.ckTempoAtivo.Checked)
            {
                lsTemp[index].DateEnd =lsTemp[index].DateEnd.ConvertDateTimeToIFF(dtTermino.Value);
                lsTemp[index].DateStart = lsTemp[index].DateStart.ConvertDateTimeToIFF(dtInicio.Value);
            }
            try
            {
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                ProjectData.ClearProjectError();
            }
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
        }

        private void Alterou()
        {
            Alterado = true;
        }


        private void btnRemover_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 1)
                {
                    lastRow = ListaItem.SelectedRows[0].Index - 1;
                    if (MessageBox.Show("Deseja remover os " + Conversions.ToString(ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    {
                        return;
                    }
                    int num = ListaItem.SelectedRows.Count - 1;
                    int num2 = 0;
                    while (true)
                    {
                        int num3 = num2;
                        int num4 = num;
                        if (num3 > num4)
                        {
                            break;
                        }
                        try
                        {
                            lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[0].Value)]);
                        }
                        catch (Exception projectError)
                        {
                            ProjectData.SetProjectError(projectError);
                            ProjectData.ClearProjectError();
                        }
                        num2++;
                    }
                    CarregarGrid(lsTemp);
                }
                else
                {
                    lastRow = ListaItem.SelectedCells[0].RowIndex - 1;
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                        lsTemp.Remove(lsTemp[index]);
                        CarregarGrid(lsTemp);
                    }
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            checked
            {
                if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    CadieMagicBox item = new CadieMagicBox();
                    Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                    item.Name = "";
                    item.TradeID = new uint[4];
                    item.DateEnd = new IFFTime();
                    item.DateStart = new IFFTime();
                    item.TradeQuantity = new uint[4];
                    try
                    {
                        lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex + 1, item);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex, item);
                        ProjectData.ClearProjectError();
                    }
                    lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
                    CarregarGrid(lsTemp);
                    try
                    {
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                        ListaItem.Rows[lastRow].Selected = true;
                    }
                    catch (Exception projectError2)
                    {
                        ProjectData.SetProjectError(projectError2);
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow - 1;
                        ListaItem.Rows[lastRow - 1].Selected = true;
                        ProjectData.ClearProjectError();
                    }
                }
            }
        }

        private void MenuSalvar_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int)this.diagSalvarArquivo.ShowDialog());
            this.Arquivo = this.diagSalvarArquivo.FileName;
            if (this.Arquivo != null)
            {
                this.bs.Filter = "";
                this.ComboBox2.SelectedIndex = 0;
                this.salvarAlteracoes();
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bs.Filter = "";
                this.pbStatus.Style = ProgressBarStyle.Marquee;
                this.bwSalvar.RunWorkerAsync();
            }
        }

        private void ListaItem_MouseHover(object sender, EventArgs e)
        {
            if (Alterado)
            {
                if (MessageBox.Show("Existem alterações que não foram salvas, desaja salva-las agora?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    salvarAlteracoes();
                }
                else
                {
                    Alterado = false;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                CadieMagicBox item = new CadieMagicBox();
                try
                {
                    this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lastRow = 0;
                    ProjectData.ClearProjectError();
                }
                var copy = this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value)];
                item.MagicID = copy.MagicID;
                item.TypeID = copy.TypeID;
                item.Name = copy.Name;
                item.Level = copy.Level;
                item.TradeID = copy.TradeID;
                item.TradeQuantity = copy.TradeQuantity;
                item.DateEnd = new IFFTime();
                item.DateStart = new IFFTime();
                try
                {
                    this.lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(this.ListaItem.SelectedRows[0].Cells[0].Value, 1)), item);
                }
                catch (Exception exception3)
                {
                    Exception ex = exception3;
                    ProjectData.SetProjectError(ex);
                    this.lsTemp.Insert(Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value), item);
                    ProjectData.ClearProjectError();
                }
                this.CarregarGrid(this.lsTemp);
            }
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarSql.ShowDialog());
            Arquivo = diagSalvarSql.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                if (File.Exists(Arquivo))
                {
                    File.Delete(Arquivo);
                }
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bwGerarSql.RunWorkerAsync();
            }
        }



        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            lbStatus.Text = "Gerando arquivo SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Value = 0;
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbStatus.Text = "parado";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Salvando...";
            salvar(backgroundWorker);
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "parado";
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbIndices.Text = Conversions.ToString(qtdItem);
            nomeArquivo();
        }

        public void salvar(BackgroundWorker BW)
        {

            var bck = Path.GetFileNameWithoutExtension(Arquivo) + ".bak";
            lsItens.IffSave(Directory.GetCurrentDirectory() + "\\backup_iffs\\" + bck, false);
            lsTemp.IffSave(Directory.GetCurrentDirectory() + "\\new_iffs\\" + Path.GetFileName(Arquivo), false);
            lsTemp.IffSave(Arquivo, false);
            FrmMain.IFF.Update = true;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            try
            {
                txtPesquisa = textBox1;
                int num = 0;
                num = (ComboBox2.SelectedIndex == 1) ? 1 : 0;
                if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0) && cbPage.SelectedIndex > -1)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1).ToString() + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1);
                }
                else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Convert.ToString(num);
                }
                else if ((cbPage.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (cbPage.SelectedIndex > 0))
                {
                    bs.Filter = "Personagem = " + Convert.ToString(ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if (txtPesquisa.Text.Length > 0)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                }
                else if (ComboBox1.SelectedIndex > 0)
                {
                    bs.Filter = "Personagem = " + Convert.ToString(ComboBox1.SelectedIndex - 1);
                }
                else if (ComboBox2.SelectedIndex > 0)
                {
                    bs.Filter = "Status2 = " + Convert.ToString(num);
                }
                else if (cbPage.SelectedIndex > 0)
                {
                    bs.Filter = "Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else
                {
                    bs.Filter = "";
                }
                Label19.Text = Convert.ToString(bs.Count);
                organizarColunas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            organizarColunas();
            pintarLinhas();
        }

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            pintarLinhas();
        }

        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                pintarLinhas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void Alterou(object sender, EventArgs e)
        {
            PictureBox obj = imgResultado;
            var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(uint.Parse(txtTypeID.Text));
            if (iffCommon.Icon != "")
            {
                carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png", ref obj);
            }
            imgResultado = obj;
        }

        private void txtItem1_TextChanged(object sender, EventArgs e)
        {
            
            PictureBox obj = img1;
            var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(uint.Parse(txtItem1.Text));
            if (iffCommon.Icon != "")
            {
                carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png", ref obj);
            }
            img1 = obj;
        }

        private void txtItem2_TextChanged(object sender, EventArgs e)
        {
            PictureBox obj = img2;
            var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(uint.Parse(txtItem2.Text));
            if (iffCommon.Icon != "")
            {
                carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png", ref obj);
            }
            img2 = obj;
        }

        private void txtItem3_TextChanged(object sender, EventArgs e)
        {
            //string img = Conversions.ToString(Util.getImage(txtItem3.Text));
            PictureBox obj = img3;
            var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(uint.Parse(txtItem3.Text));
            if (iffCommon.Icon != "")
            {
                carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png", ref obj);
            }
            img3 = obj;
        }

        private void txtItem4_TextChanged(object sender, EventArgs e)
        {
            //string img = Conversions.ToString(Util.getImage(txtItem4.Text));
            PictureBox obj = img4;
            var iffCommon = (IFFCommon)FrmMain.IFF.GetItem(uint.Parse(txtItem4.Text));
            if (iffCommon.Icon != "")
            {
                carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + iffCommon.Icon + ".png", ref obj);
            }
            img4 = obj;
        }

        private void txtItemProdQtd_ValueChanged(object sender, EventArgs e)
        {
            txtResultado.Text = Conversions.ToString(txtItemProdQtd.Value);
        }

        private void txtItem1Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes1.Text = Conversions.ToString(txtItem1Qtd.Value);
        }

        private void txtItem2Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes2.Text = Conversions.ToString(txtItem2Qtd.Value);
        }

        private void txtItem3Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes3.Text = Conversions.ToString(txtItem3Qtd.Value);
        }

        private void txtItem4Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes4.Text = Conversions.ToString(txtItem4Qtd.Value);
        }

        private void btnCima_Click(object sender, EventArgs e)
        {
            alterarPos(1);
        }

        public void alterarPos(int Valor)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 0)
                {
                    CadieMagicBox cadieMagicBox = new CadieMagicBox();
                    int num;
                    try
                    {
                        num = ListaItem.SelectedRows[0].Index;
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        num = 0;
                        ProjectData.ClearProjectError();
                    }
                    cadieMagicBox = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];
                    lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)]);
                    try
                    {
                        lsTemp.Insert(num - Valor, cadieMagicBox);
                    }
                    catch (Exception projectError2)
                    {
                        ProjectData.SetProjectError(projectError2);
                        lsTemp.Insert(num, cadieMagicBox);
                        ProjectData.ClearProjectError();
                    }
                    lastRow = ListaItem.SelectedRows[0].Index - Valor;
                    CarregarGrid(lsTemp);
                }
                else
                {
                    ListaItem.Rows[0].Selected = true;
                }
            }
        }

        private void btnBaixo_Click(object sender, EventArgs e)
        {
            alterarPos(-1);
        }

        private void btnIndices_Click(object sender, EventArgs e)
        {
            int count = ListaItem.Rows.Count;
            int num = 1;
            checked
            {
                while (true)
                {
                    int num2 = num;
                    int num3 = count;
                    if (num2 > num3)
                    {
                        break;
                    }
                    try
                    {
                        var ckrepeted = lsTemp.Where(c=> c.MagicID == (uint)num).Count();
                        if (ckrepeted > 1)
                        {

                        }
                        lsTemp[num - 1].MagicID = (uint)num;
                        num++;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Falha ao refazer indices!", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                }
                ListaItem.DataSource = null;
                CarregarGrid(lsTemp);
                MessageBox.Show("Indices refeitos com sucesso!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void menuGerarCache_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        public void AddNew()
        {
            var temp = new CadieMagicBoxCollection() { Header = FrmMain.IFF.CadieMagicBox.Header};
            for (int num = 1; num < lsTemp.Count ; num++)
            {
                lsTemp[num - 1].MagicID = (uint)num;
                if (lsTemp.Where(c=> c.MagicID == num).Count() > 1)
                {
                    Debug.WriteLine(lsTemp[num - 1].Name + ":"+ lsTemp[num - 1].MagicID);
                }
            }
        }
        public void AlterarIndex(uint newindex)
        {
            uint count = Convert.ToUInt32(lsTemp.Count);
            
            uint num = 1;
            checked
            {
                while (true)
                {
                    uint num2 = num;
                    uint num3 = count;
                    if (num2 > num3)
                    {
                        break;
                    }
                    try
                    {
                        lsTemp[(int)num - 1].MagicID = num + 1;
                        num++;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Falha ao refazer indices!", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                }
            }
        }
    }
}
