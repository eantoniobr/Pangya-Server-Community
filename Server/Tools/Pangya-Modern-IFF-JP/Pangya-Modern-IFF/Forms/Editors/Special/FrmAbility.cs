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
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
using PangyaAPI.IFF.JP.Extensions;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmAbility : Form
    {
        private bool sfile;

        public FrmAbility()
        {
            InitializeComponent();
        }

        public FrmAbility(IFFFile<Ability> coin)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = coin;
            lsTemp = coin;
        }


        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }

            this.lsItens = new IFFFile<Ability>();
            this.lsTemp = new IFFFile<Ability>();
            this.Arquivo = this.diagAbrirArquivo.FileName;
            try
            {
                lsItens.Load(File.ReadAllBytes(Arquivo));
            }
            catch
            {

                MessageBox.Show("File Incorrect", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            this.lsTemp = lsItens;

            this.nomeArquivo();
            
            this.CarregarGrid(this.lsTemp);
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

        public void CarregarGrid(IFFFile<Ability> Lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("IDX", typeof(int));
            dataTable.Columns.Add("ItemType", typeof(int));
            dataTable.Columns.Add("ItemType2", typeof(int));
            dataTable.Columns.Add("ItemType3", typeof(int));
            dataTable.Columns.Add("Alterado", typeof(int));
            int num3 = 0;
            foreach (var item in Lista)
            {
                int num6 = 0;
                try
                {
                 if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                {
                    num6 = Convert.ToInt32(ListaItem["Alterado", num3].Value);
                } 
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    num6 = 0;
                    ProjectData.ClearProjectError();
                }
                var record = sIff.getInstance().FindCommonItem(item.ID);
                string Name = "Name Unknown";
                if (record != null)
                {
                    Name = record.Name;
                }
                dataTable.Rows.Add(item.ID, Name, num3, item.Efeito.Type[0] + 1, item.Efeito.Type[1] + 1, item.Efeito.Type[2] + 1, num6);

                num3++;
            }
            
            bs = new BindingSource();
            bs.DataSource = dataTable;
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;
            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
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
        }
        public void AtualizarGrid(Ability item)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => AtualizarGrid(item)));
                return;
            }

            // Verifique se o DataSource é um BindingSource
            var bindingSource = ListaItem.DataSource as BindingSource;
            if (bindingSource == null)
            {
                // Se não for BindingSource, verifique se é DataTable
                var _dataTable = ListaItem.DataSource as DataTable;
                if (_dataTable == null)
                {
                    // Inicialize um novo DataTable
                    _dataTable = new DataTable();
                    _dataTable.Columns.Add("ID", typeof(int));
                    _dataTable.Columns.Add("Item", typeof(string));
                    _dataTable.Columns.Add("IDX", typeof(int));
                    _dataTable.Columns.Add("ItemType", typeof(int));
                    _dataTable.Columns.Add("ItemType2", typeof(int));
                    _dataTable.Columns.Add("ItemType3", typeof(int));
                    _dataTable.Columns.Add("Alterado", typeof(int));

                    // Crie um novo BindingSource e defina como DataSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = _dataTable;
                    ListaItem.DataSource = bindingSource;
                }
                else
                {
                    // Se for DataTable, crie um novo BindingSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = _dataTable;
                    ListaItem.DataSource = bindingSource;
                }
            }

            // Pegue o DataTable do BindingSource
            var dataTable = bindingSource.DataSource as DataTable;

             

            int alterado = 0;
            // Verifique se a linha com o ID já existe
            var existingRow = dataTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ID") == item.ID);

            if (existingRow == null)
            {
                // Adicione uma nova linha se a linha não existir
                var newRow = dataTable.NewRow();
                newRow["ID"] = item.ID;
                newRow["Item"] = sIff.getInstance() != null? sIff.getInstance().GetItemName(item.ID): "Name";
                newRow["IDX"] = this.lsItens.FindIndex(c=> c.ID == item.ID);
                newRow["ItemType"] = item.Efeito.Type[0] + 1;
                newRow["ItemType2"] = item.Efeito.Type[1] + 1;
                newRow["ItemType3"] = item.Efeito.Type[2] + 1;
                newRow["Alterado"] = alterado;
                dataTable.Rows.Add(newRow);
            }

            // Atualize o contador total de itens         
            lbTotalItens.Text = dataTable.Rows.Count.ToString();
            lblSearchCount.Text = dataTable.Rows.Count.ToString();
            // Aplicar estilo e filtros adicionais
            ListaItem.Columns[0].Width = 45;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[5].HeaderText = "   ";

            // Garantir que a nova linha seja visível
            if (ListaItem.Rows.Count > 0)
            {
                ListaItem.FirstDisplayedScrollingRowIndex = ListaItem.Rows.Count - 1;
                ListaItem.Rows[ListaItem.Rows.Count - 1].Selected = true;
            }

            pintarLinhas();
        }

        public void RemoverItem(uint ID)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => RemoverItem(ID)));
                return;
            }

            // Verifique se o DataSource é um BindingSource
            var bindingSource = ListaItem.DataSource as BindingSource;
            if (bindingSource == null)
            {
                // Se não for BindingSource, verifique se é DataTable
                var table = ListaItem.DataSource as DataTable;
                if (table == null)
                {
                    // Se não houver DataSource, não há nada para remover
                    return;
                }
                else
                {
                    // Crie um novo BindingSource e defina como DataSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = table;
                    ListaItem.DataSource = bindingSource;
                }
            }

            // Pegue o DataTable do BindingSource
            var dataTable = bindingSource.DataSource as DataTable;

            // Encontre a linha com o ID especificado
            var rowToRemove = dataTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ID") == ID);

            if (rowToRemove != null)
            {
                // Remova a linha encontrada
                dataTable.Rows.Remove(rowToRemove);
            }

            // Atualizar o contador total de itens
            lbTotalItens.Text = dataTable.Rows.Count.ToString();
            lblSearchCount.Text = dataTable.Rows.Count.ToString();
            // Garantir que a lista permaneça limpa
            ListaItem.ClearSelection();
            pintarLinhas();
        }

        public void organizarColunas()
        {
            this.ListaItem.Columns[0].Width = 0x2d;
            this.ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].Visible = false;
            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[5].Visible = false;
            ListaItem.Columns[6].Visible = false;
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
            this.txtEffectActive.Checked = false;
            this.txtEffectActive2.Checked = false;
            this.txtEffectActive3.Checked = false;
            this.txtEffectRate.Text = "";
            this.txtEffectRate2.Text = "";
            this.txtEffectRate3.Text = "";
            this.txtFlag.Text = "";
            this.txtFlag2.Text = "";
            if (ListaItem.SelectedCells[0].RowIndex != -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);   
                lbIndices.Text = index.ToString();
                var shoprare = lsTemp[index];
                this.txtEffectActive.Checked = this.lsTemp[index].Efeito.EffectOrNo[0] > 0;
                this.txtEffectActive2.Checked = this.lsTemp[index].Efeito.EffectOrNo[1] > 0;
                this.txtEffectActive3.Checked = this.lsTemp[index].Efeito.EffectOrNo[2] > 0;
                this.txtEffectRate.Text = this.lsTemp[index].Efeito.Rate[0].ToString();
                this.txtEffectRate2.Text = this.lsTemp[index].Efeito.Rate[1].ToString();
                this.txtEffectRate3.Text = this.lsTemp[index].Efeito.Rate[2].ToString();
                this.cbType.SelectedIndex = (int)this.lsTemp[index].Efeito.Type[0];
                this.cbType2.SelectedIndex = (int)this.lsTemp[index].Efeito.Type[1];
                this.cbType3.SelectedIndex = (int)this.lsTemp[index].Efeito.Type[2];
                this.txtFlag.Text = this.lsTemp[index].Flag1.ToString();
                this.txtFlag2.Text = this.lsTemp[index].Flag2.ToString();
                var record = sIff.getInstance().FindCommonItem(shoprare.ID);
                if (record != null)
                {
                    this.txtName.Text = record.Name;
                }
                this.txtTypeID.Text = shoprare.ID.ToString();
                carregarImagem();
            }
            Alterado = false;
            try
            {

            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }
        private void carregarImagem()
        {
            try
            {
                imgResultado.Image = sIff.getInstance() != null ? Util.getImage(sIff.getInstance().FindCommonItem(uint.Parse(txtTypeID.Text)).ShopIcon) : Resources.ajax_loader;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bwSalvar.IsBusy)
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
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                }
            }
            catch { }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "Ability.iff";
            }
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
            CarregarGrid(lsTemp);
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            salvarAlteracoes();
            pintarLinhas();
        }

        private void salvarAlteracoes()
        {
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
            var ID = Conversions.ToUInteger(this.txtTypeID.Text);

            uint effectOrNo0 = Convert.ToUInt32(txtEffectActive.Checked);
            uint effectOrNo1 = Convert.ToUInt32(txtEffectActive2.Checked);
            uint effectOrNo2 = Convert.ToUInt32(txtEffectActive3.Checked);

            float rate0 = float.Parse(txtEffectRate.Text);
            float rate1 = float.Parse(txtEffectRate2.Text);
            float rate2 = float.Parse(txtEffectRate3.Text);

            uint type0 = (uint)cbType.SelectedIndex;
            uint type1 = (uint)cbType2.SelectedIndex;
            uint type2 = (uint)cbType3.SelectedIndex;

            uint flag1 = uint.Parse(txtFlag.Text);
            uint flag2 = uint.Parse(txtFlag2.Text);

            Ability ability = lsTemp[index];
            ability.ID = ID;
            ability.Efeito.EffectOrNo[0] = effectOrNo0;
            ability.Efeito.EffectOrNo[1] = effectOrNo1;
            ability.Efeito.EffectOrNo[2] = effectOrNo2;

            ability.Efeito.Rate[0] = rate0;
            ability.Efeito.Rate[1] = rate1;
            ability.Efeito.Rate[2] = rate2;

            ability.Efeito.Type[0] = type0;
            ability.Efeito.Type[1] = type1;
            ability.Efeito.Type[2] = type2;

            ability.Flag1 = flag1;
            ability.Flag2 = flag2;
            lsTemp[index] = ability;
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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 1)
                {
                    lastRow = ListaItem.SelectedRows[0].Index - 1;
                    if (MessageBox.Show("Do you want to remove the" + Conversions.ToString(ListaItem.SelectedRows.Count) + " selected items?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
                            lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[2].Value)]);
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
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
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
                if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var coin = lsTemp.Last().Clone() as Ability;
                    coin.ID = 0;
                    try
                    {
                        lsTemp.Add(coin);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        ProjectData.ClearProjectError();
                    }
                    if (MessageBox.Show("new Index no created, Index insert in Item.iff ", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                    }
                    CarregarGrid(lsTemp);
                }
            }
        }



        private void ListaItem_MouseHover(object sender, EventArgs e)
        {
            if (Alterado)
            {
                if (MessageBox.Show("There are unsaved changes, do you want to save them now?", "Pangya Modern Editor", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            if (MessageBox.Show("Do you want to clone the selected item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var coin = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value)].Clone() as Ability;
                coin.ID =coin.ID+ 999;
                try
                {
                    lsTemp.Add(coin);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
                if (MessageBox.Show("new Index no created, Index insert in Item.iff ", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                }
                CarregarGrid(lsTemp);
            }
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Saving...";
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            lbStatus.Text = "Generating SQL file - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbStatus.Text = "Stop";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker)sender;
            this.lbStatus.Text = "Saving...";
            this.salvar(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Saving...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbIndices.Text = Conversions.ToString(qtdItem);
            nomeArquivo();
        }

        public void salvar(BackgroundWorker BW)
        {
            BW.ReportProgress(0, "Write File IFF");
            lsTemp.Update = true;
            if (sIff.getInstance() != null)
                sIff.getInstance().UpdateType(lsTemp);  //atualiza
            if (sfile)
            {
                lsTemp.Save(Arquivo);
            }
            else
            {
                if (sIff.getInstance() != null)
                {
                    sIff.getInstance().UpdateIFF();//save in iff/stream/sfile
                }
                else
                {
                    MessageBox.Show("Use 'MenuSave' Save File IFF!", "Pangya Modern Editor");
                }
            }
            Util.gerarBackup(lsItens.GetBytes(), Arquivo); //gera um automatico 
            BW.ReportProgress(100, "Save File IFF Sucess");
            sfile = false;
            lsItens = lsTemp;
        }

        public void filtrar()
        {
            try
            {
                // Se o texto de pesquisa não for vazio
                if (!string.IsNullOrEmpty(txtPesquisa.Text))
                {
                    string searchTerm = SanitizeSearchTerm(txtPesquisa.Text);

                    // Filtro com base no texto de pesquisa e na seleção de ItemType
                    if (cbEffect.SelectedIndex > 0)
                    {
                        // Construção do filtro com a seleção de ItemType
                        bs.Filter = $"(Item LIKE '%{searchTerm}%') AND (" +
                                    $"ItemType = {cbEffect.SelectedIndex} OR " +
                                    $"ItemType2 = {cbEffect.SelectedIndex} OR " +
                                    $"ItemType3 = {cbEffect.SelectedIndex})";
                    }
                    else
                    {
                        // Filtro apenas baseado no texto de pesquisa
                        bs.Filter = $"(Item LIKE '%{searchTerm}%')";
                    }
                }
                // Se o texto de pesquisa estiver vazio, mas o ItemType for selecionado
                else if (cbEffect.SelectedIndex > 0)
                {
                    // Filtro apenas baseado no ItemType
                    bs.Filter = $"ItemType = {cbEffect.SelectedIndex} OR " +
                                $"ItemType2 = {cbEffect.SelectedIndex} OR " +
                                $"ItemType3 = {cbEffect.SelectedIndex}";
                }
                // Caso contrário, remove o filtro
                else
                {
                    bs.Filter = string.Empty;
                }

                // Atualiza a contagem de itens filtrados
                lblSearchCount.Text = bs.Count.ToString();

                // Se não houver itens após o filtro, limpa o filtro
                if (bs.Count == 0)
                {
                    bs.Filter = string.Empty;
                }

                // Organiza as colunas após o filtro
                organizarColunas();
            }
            catch (Exception ex)
            {
                // Registra a exceção de maneira adequada
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        /// <summary>
        /// Método para limpar e formatar o termo de pesquisa para evitar SQL Injection.
        /// </summary>
        private string SanitizeSearchTerm(string term)
        {
            return term.Replace("'", "''")
                       .Replace("[", "[[]")
                       .Replace("%", "[%]")
                       .Replace("_", "[_]");
        }


        private void FrmAbility_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Ability.iff";
                int length = 0x19;
                if (Strings.Len(this.Arquivo) > 0x19)
                {
                    this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
                }
                else
                {
                    this.lbArquivo.Text = this.Arquivo;
                }
                this.ListaItem.DataSource = new object();
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsTemp.Count);
                this.CarregarGrid(this.lsTemp);
            }
        }
        private void menuSalvarComo_Click(object sender, EventArgs e)
        {
            sfile = true;
            diagSalvarArquivo.ShowDialog();
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                salvarAlteracoes();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }


        private void txtTypeID_TextChanged(object sender, EventArgs e)
        {
            Alterou(sender, e);
        }

        private void Alterou(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Verifica se o texto do TextBox realmente mudou
            if (textBox != null && textBox.Modified)
            {
                Alterado = true;
                textBox.Modified = false; // Reinicia o sinal de alteração para evitar detectar mudanças futuras sem intenção
            }
        }

        private void menuBackup_Click(object sender, EventArgs e)
        {
            if (Util.gerarBackup(lsItens.GetBytes(), Arquivo))
            {
                MessageBox.Show("Backup generated successfully!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Error generating backup", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }       
    }
}
