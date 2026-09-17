using System;
using System.Collections;
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
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmMemorialShopRare : Form
    {
        private bool sfile;

        public FrmMemorialShopRare()
        {
            InitializeComponent();
        }

        public FrmMemorialShopRare(IFFFile<MemorialShopRareItem> coin)
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

            this.lsItens = new IFFFile<MemorialShopRareItem>();
            this.lsTemp = new IFFFile<MemorialShopRareItem>();
            this.Arquivo = this.diagAbrirArquivo.FileName;
            try
            {
                lsItens.Load(File.ReadAllBytes(Arquivo));
            }
            catch
            {
                var p = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(Arquivo)));
                p.Skip(8);
                for (int i = 0; i < lsItens.Header.Count; i++)
                {
                    lsItens.Add(new MemorialShopRareItem(ref p));
                } 
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

        public void CarregarGrid(IFFFile<MemorialShopRareItem> Lista)
        {

            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Status", typeof(Image));
            dataTable.Columns.Add("ItemType", typeof(string));
            dataTable.Columns.Add("RareType", typeof(uint));
            dataTable.Columns.Add("Status2", typeof(int));
            dataTable.Columns.Add("Alterado", typeof(int));
            int num3 = 0;

            foreach (var item in Lista)
            {
                 Image accept = (item.Active == 0) ? Properties.Resources.BtnRemove_Mini : Properties.Resources.BtnApply_Mini;
                int num6 = 0;
                try
                {
                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                        num6 = Convert.ToInt32(ListaItem["Alterado", num3].Value);
                }
                catch (Exception projectError2)
                {
                    num6 = 0;
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }
                var record = sIff.getInstance().FindCommonItem(item.ID);
                string Name = "Name Unknown";
                if (record != null)
                {
                    Name = record.Name;
                }
                if (item.Active > 1)
                {
                    Debug.WriteLine($"bug detected: {Name}:{item.ID}");
                    item.Active = 1;
                }
                dataTable.Rows.Add(num3, Name, accept, (int)item.ItemType, (int)item.RareType, item.Active == 0? 0: 1, num6);
                num3++;
            }
            bs = new BindingSource(dataTable, null);
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;
            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
            for (int i = 0; i < ListaItem.Rows.Count; i++)
            {
                ListaItem.Rows[i].Selected = false;
            }
            organizarColunas();
            filtrar();
            try
            {
                if (ListaItem.Rows.Count > 0 && lastRow < ListaItem.Rows.Count)
                {
                    ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                    ListaItem.Rows[lastRow].Selected = true;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            pintarLinhas();
            organizarColunas();

        }

        public void AtualizarGrid(MemorialShopRareItem item)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => AtualizarGrid(item)));
                return;
            }

            // Verifique se o DataSource é um BindingSource
            var bindingSource = ListaItem.DataSource as BindingSource;
            var dataTable = new DataTable();
            if (bindingSource == null)
            {
                // Se não for BindingSource, verifique se é DataTable
                dataTable = ListaItem.DataSource as DataTable;
                if (dataTable == null)
                {
                    // Inicialize um novo DataTable
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Item", typeof(string));
                    dataTable.Columns.Add("Status", typeof(Image));
                    dataTable.Columns.Add("ItemType", typeof(string));
                    dataTable.Columns.Add("RareType", typeof(uint));
                    dataTable.Columns.Add("Status2", typeof(int));
                    dataTable.Columns.Add("Alterado", typeof(int));
                    // Crie um novo BindingSource e defina como DataSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    ListaItem.DataSource = bindingSource;
                }
                else
                {
                    // Se for DataTable, crie um novo BindingSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    ListaItem.DataSource = bindingSource;
                }
            }

            // Pegue o DataTable do BindingSource
            dataTable = bindingSource.DataSource as DataTable;
            var record = sIff.getInstance().FindCommonItem(item.ID);
            string _Name = "Name Unknown";
            if (record != null)
            {
                _Name = record.Name;
            }
            // Adicione uma nova linha se a linha não existir
            var newRow = dataTable.NewRow();
            newRow["ID"] = lsTemp.Count - 1;
            newRow["Item"] = _Name;
            newRow["Status"] = (item.Active == 0) ? Properties.Resources.BtnRemove_Mini : Properties.Resources.BtnApply_Mini;
            newRow["ItemType"] = (int)item.ItemType;
            newRow["RareType"] = (int)item.RareType;
            newRow["Status2"] = item.Active;
            newRow["Alterado"] = 0;
            dataTable.Rows.Add(newRow);
            // Atualize o contador total de itens         
            lbTotalItens.Text = dataTable.Rows.Count.ToString();
            lblSearchCount.Text = dataTable.Rows.Count.ToString();

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
            this.ListaItem.Columns[0].Width = 20;
            this.ListaItem.Columns[2].Width = 30;
            this.ListaItem.Columns[0].ValueType = typeof(int);
            this.ListaItem.Columns[0].HeaderText = "   ";
            this.ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[5].Visible = false;
            ListaItem.Columns[6].Visible = false;
        }

        public void pintarLinhas()
        {
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
            }
        }

        private void CarregarItem()
        {
            if (ListaItem.SelectedCells[0].RowIndex != -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);

                var shoprare = lsTemp[index];
                lbIndices.Text = index.ToString();

                var record = sIff.getInstance().FindCommonItem(shoprare.ID);
                if (record != null)
                {
                    this.txtIndex.Text = record.Name;
                }
                ckAtivo.Checked = lsTemp[index].Active != 0 ? true : false;
                this.txtTypeID.Text = shoprare.ID.ToString();
                this.cbItemType.SelectedIndex = (int)shoprare.ItemType;
                setRareType(shoprare.RareType);
                this.txtProbs.Text = shoprare.Probabilities.ToString();
                this.txtCounter.Text = shoprare.gacha.Count.ToString();
                this.txtNumber.Text = shoprare.gacha.Number.ToString();
                this.cbCharacter.SelectedIndex = (int)shoprare.CharacterType;
                this.cbItem.SelectedIndex = (int)shoprare.Item;
                this.cbSex.SelectedIndex = (int)shoprare.Sex;
                this.cbValue.SelectedIndex = (int)shoprare.Value_1;
                carregarImagem();
            }
            Alterado = false;   
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
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
                if (ListaItem.SelectedRows.Count > 1)
                {
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    tbsGenerateSql.Enabled = false;
                    menuBackup.Enabled = false;
                    btnReabrir.Enabled = true;
                    menuSalvarComo.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    tbsGenerateSql.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuBackup.Enabled = true;
                    tbsGenerateSql.Enabled = true;
                    CarregarItem();
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
            cbItemTypeA.SelectedIndex = 0;
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "MemorialShopRareItem.iff";
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
            if (ListaItem.SelectedRows.Count == 1)
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
                lsTemp[index].ID = Conversions.ToUInteger(this.txtTypeID.Text);
                lsTemp[index].ItemType = (FilterType)Conversions.ToUInteger(this.cbItemType.SelectedIndex);
                lsTemp[index].RareType = getRareType();
                lsTemp[index].Probabilities = Conversions.ToUInteger(this.txtProbs.Text);
                lsTemp[index].gacha.Number = Conversions.ToUInteger(this.txtNumber.Text);
                lsTemp[index].gacha.Count = (uint)Conversions.ToUInteger(this.txtCounter.Text);
                lsTemp[index].Active = (uint)Conversions.ToUInteger(this.ckAtivo.Checked);
                lsTemp[index].Sex = Conversions.ToUInteger(this.cbSex.SelectedIndex);
                lsTemp[index].Value_1 = Conversions.ToUInteger(this.cbValue.SelectedIndex);
                lsTemp[index].Item = Conversions.ToUInteger(this.cbItem.SelectedIndex);
                lsTemp[index].CharacterType = Conversions.ToUInteger(this.cbCharacter.SelectedIndex);                         
                try
                {
                    ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                }
                catch (Exception projectError2)
                {
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }
            }
            else
            {
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    var index = Conversions.ToInteger(row.Cells[0].Value);                                                     
                    lsTemp[index].ItemType = (FilterType)Conversions.ToUInteger(this.cbItemType.SelectedIndex);
                    lsTemp[index].RareType = getRareType();
                    lsTemp[index].Probabilities = Conversions.ToUInteger(this.txtProbs.Text);
                    lsTemp[index].gacha.Number = Conversions.ToUInteger(this.txtNumber.Text);
                    lsTemp[index].gacha.Count = (uint)Conversions.ToUInteger(this.txtCounter.Text);
                    lsTemp[index].Active = (uint)Conversions.ToUInteger(this.ckAtivo.Checked);                                  
                    lsTemp[index].Value_1 = Conversions.ToUInteger(this.cbValue.SelectedIndex);
                    lsTemp[index].Item = Conversions.ToUInteger(this.cbItem.SelectedIndex);
                    lsTemp[index].CharacterType = Conversions.ToUInteger(this.cbCharacter.SelectedIndex);                    
                }
            }
                    Alterado = false;
            qtdItem = ListaItem.Rows.Count;
        }

        private void setRareType(MemorialRareType value)
        {
            switch (value)
            {
                case MemorialRareType.Default:
                    cbTipoCoin.SelectedIndex = 0;
                    break;
                case MemorialRareType.Normal:
                    cbTipoCoin.SelectedIndex = 1;
                    break;
                case MemorialRareType.Comum:
                    cbTipoCoin.SelectedIndex = 2;
                    break;
                case MemorialRareType.Rare:
                    cbTipoCoin.SelectedIndex = 3;
                    break;
                case MemorialRareType.Super_Rare:
                    cbTipoCoin.SelectedIndex = 4;
                    break;
                case MemorialRareType.Super_Rare2:
                    cbTipoCoin.SelectedIndex = 5;
                    break;
            }
        }

        private MemorialRareType getRareType()
        {
            switch (cbTipoCoin.SelectedIndex)
            {
                case 0:
                    return MemorialRareType.Default;
                case 1:
                    return MemorialRareType.Normal;
                case 2:
                    return MemorialRareType.Comum;
                case 3:
                    return MemorialRareType.Rare;
                case 4:
                    return MemorialRareType.Super_Rare;
                case 5:
                    return MemorialRareType.Super_Rare2;
            }
            return 0;
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
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var coin = lsTemp.Last().Clone() as MemorialShopRareItem;
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
                var coin = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];

                try
                {
                    lsTemp.Add(coin);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }       
                AtualizarGrid(coin);
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
            checked
            {
                try
                {
                    int num2 = -1;
                    if ((cbItemTypeA.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        num2 = (cbItemTypeA.SelectedIndex - 1);
                        if (ComboBox2.SelectedIndex > 0)
                        {
                            bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND ItemType = " + Conversions.ToString(num2) + " AND Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex == 2 ? 0 : 1);
                        }
                        else
                            bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND ItemType = " + Conversions.ToString(num2);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        if (ComboBox2.SelectedIndex > 0)
                        {
                            bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex == 2 ? 0 : 1);
                        }
                        else
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (cbItemTypeA.SelectedIndex > 0)
                    {
                        num2 = (cbItemTypeA.SelectedIndex - 1);
                         if (ComboBox2.SelectedIndex > 0)
                        {
                            bs.Filter = "Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex == 2 ? 0 : 1) + " AND ItemType = " + Conversions.ToString(num2);
                        }
                        else 
                        bs.Filter = "ItemType = " + Conversions.ToString(num2);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {                    
                            bs.Filter = "Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex == 2? 0: 1);
                    }
                    if (bs.Count == 0)
                        bs.Filter = "";               
                    lblSearchCount.Text = Conversions.ToString(bs.Count);

                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
            }
        }


        private void FrmMemorialShopRare_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "MemorialShopRareItem.iff";
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
                this.cbItemTypeA.SelectedIndex = 0;
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
                cbItemTypeA.SelectedIndex = 0;
                salvarAlteracoes();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }

        private void tbsGenerateSql_Click(object sender, EventArgs e)
        {
            
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
