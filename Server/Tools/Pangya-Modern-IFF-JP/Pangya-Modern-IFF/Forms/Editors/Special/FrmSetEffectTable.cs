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
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmSetEffectTable : Form
    {
        private bool sfile;

        public FrmSetEffectTable()
        {
            InitializeComponent();
        }

        public FrmSetEffectTable(IFFFile<SetEffectTable> coin)
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

            this.lsItens = new IFFFile<SetEffectTable>();
            this.lsTemp = new IFFFile<SetEffectTable>();
            this.Arquivo = this.diagAbrirArquivo.FileName;
            try
            {
                lsItens.Load(File.ReadAllBytes(Arquivo));
            }
            catch
            {

                MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        public void CarregarGrid(IFFFile<SetEffectTable> Lista)
        {
             DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Alterado", typeof(int));
            int num3 = 0;
            foreach (var item in Lista)
            {
                int num6 = 0;
                string DBName = "Name Unknown";
                try
                {

                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                    {
                        num6 = Convert.ToInt32(ListaItem["Alterado", num3].Value);
				DBName = Conversions.ToString(ListaItem["Item", num3].Value);
                } 
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                     ProjectData.ClearProjectError();
                    DBName = "Name Unknown";
                }
                var record = sIff.getInstance().FindCommonItem(item.getID(0));
                if (DBName != "Name Unknown")
                {
                    record = sIff.getInstance().FindCommonItem(item.getID(1));
                    Name = record.Name;
                }
                if (DBName == "Name Unknown")
                {
                    Name = record.Name;
                }
               
                dataTable.Rows.Add(item.Index, Name, num6);

                num3++;
            }
            
            bs = new BindingSource();
            bs.DataSource = dataTable;
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;
            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
            organizarColunas();  
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
        public void AtualizarGrid(Part item)
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
                var table = ListaItem.DataSource as DataTable;
                if (table == null)
                {
                    // Inicialize um novo DataTable
                    table = new DataTable();
                    table.Columns.Add("ID", typeof(int));
                    table.Columns.Add("Item", typeof(string));
                    table.Columns.Add("Status", typeof(Image));
                    table.Columns.Add("Personagem", typeof(string));
                    table.Columns.Add("Status2", typeof(string));
                    table.Columns.Add("Tipo", typeof(Image));
                    table.Columns.Add("Alterado", typeof(int));

                    // Crie um novo BindingSource e defina como DataSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = table;
                    ListaItem.DataSource = bindingSource;
                }
                else
                {
                    // Se for DataTable, crie um novo BindingSource
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = table;
                    ListaItem.DataSource = bindingSource;
                }
            }

            // Pegue o DataTable do BindingSource
            var dataTable = bindingSource.DataSource as DataTable;

            // Prepare as imagens e valores
            Image statusImage = (item.Active)
                ? (string.IsNullOrEmpty(item.ShopIcon) ? Resources.BtnRemove_Mini : Properties.Resources.BtnApply_Mini)
                : Properties.Resources.BtnRemove_Mini;

            Image tipoImage = Resources.Disable;
            var item_type2 = 0;



            switch (item.GetTypeCash())
            {
                case 0:
                    if (item.IsOnlyDisplay())
                    {
                        tipoImage = Resources.Display;
                        item_type2 = 4;// fake
                    }
                    else
                    {
                        item_type2 = 4;
                        tipoImage = Resources.Disable;
                    }
                    break;
                case 1:
                    if (item.IsOnlyDisplay())
                    {
                        tipoImage = Resources.Display;
                        item_type2 = 3;// fake
                    }
                    else
                    {
                        item_type2 = 3;
                        tipoImage = Resources.points;
                    }
                    break;
                case 2:
                    if (item.IsOnlyDisplay())
                    {
                        tipoImage = Resources.Display;
                        item_type2 = 2;// fake
                    }
                    else
                    {
                        item_type2 = 2;
                        tipoImage = Resources.Pang;
                    }
                    break;
            }


            int alterado = 0;
            var id = item.getCharacter(true);

            // Verifique se a linha com o ID já existe
            var existingRow = dataTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ID") == item.ID);

            if (existingRow == null)
            {
                // Adicione uma nova linha se a linha não existir
                var newRow = dataTable.NewRow();
                newRow["ID"] = item.ID;
                newRow["Item"] = item.Name;
                newRow["Status"] = statusImage;
                newRow["Personagem"] = id;
                newRow["Status2"] = item_type2;
                newRow["Tipo"] = tipoImage;
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
            //ListaItem.Columns[3].Visible = false;
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
           
            if (ListaItem.SelectedCells[0].RowIndex != -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);

                var shoprare = lsTemp[index];
                setFlag((int)this.lsTemp[index].effect.Type[0], (int)this.lsTemp[index].effect.Type[1], (int)this.lsTemp[index].effect.Type[2]);
                this.cbEffect.SelectedIndex = (int)this.lsTemp[index].effect.effect[0];
                this.cbEffect2.SelectedIndex = (int)this.lsTemp[index].effect.effect[1];
                this.cbEffect3.SelectedIndex = (int)this.lsTemp[index].effect.effect[2];   
                this.txtAddPower.Text = this.lsTemp[index].Effect_Add_Power.ToString();
                this.txtItem1.Text = this.lsTemp[index].item.ID[0].ToString();
                this.txtItem2.Text = this.lsTemp[index].item.ID[1].ToString();
                this.txtItem3.Text = this.lsTemp[index].item.ID[2].ToString();
                this.txtItem4.Text = this.lsTemp[index].item.ID[3].ToString();
                this.txtItem5.Text = this.lsTemp[index].item.ID[4].ToString();
                this.txtItem5.Text = this.lsTemp[index].item.ID[4].ToString();
                this.ckItem1.Checked = this.lsTemp[index].item.Active[0] > 0 ;
                this.ckItem2.Checked = this.lsTemp[index].item.Active[1] > 0;
                this.ckItem3.Checked = this.lsTemp[index].item.Active[2] > 0;
                this.ckItem4.Checked = this.lsTemp[index].item.Active[3] > 0;
                this.ckItem5.Checked = this.lsTemp[index].item.Active[4] > 0;
                this.nrSlot1.Value = (int)this.lsTemp[index].Slot[0];
                this.nrSlot2.Value = (int)this.lsTemp[index].Slot[1];
                this.nrSlot3.Value = (int)this.lsTemp[index].Slot[2];
                this.nrSlot4.Value = (int)this.lsTemp[index].Slot[3];
                this.nrSlot5.Value = (int)this.lsTemp[index].Slot[4];           
                txtIndex.Text = this.lsTemp[index].Index.ToString();
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

        private void setFlag(int v1, int v2, int v3)
        {
            switch (v1)
            {
                case 0:
                    cbType.SelectedIndex = 0;
                    break;
                case 1:
                    cbType.SelectedIndex = 1;
                    break;
                case 2:
                    cbType.SelectedIndex = 2;
                    break;
                case 4:
                    cbType.SelectedIndex = 3;
                    break;
                case 8:
                    cbType.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

            switch (v2)
            {
                case 0:
                    cbType2.SelectedIndex = 0;
                    break;
                case 1:
                    cbType2.SelectedIndex = 1;
                    break;
                case 2:
                    cbType2.SelectedIndex = 2;
                    break;
                case 4:
                    cbType2.SelectedIndex = 3;
                    break;
                case 8:
                    cbType2.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

            switch (v3)
            {
                case 0:
                    cbType3.SelectedIndex = 0;
                    break;
                case 1:
                    cbType3.SelectedIndex = 1;
                    break;
                case 2:
                    cbType3.SelectedIndex = 2;
                    break;
                case 4:
                    cbType3.SelectedIndex = 3;
                    break;
                case 8:
                    cbType3.SelectedIndex = 4;
                    break;
                default:
                    break;
            }
        }


        private uint getFlag(int v1)
        {
            switch (v1)
            {
                case 0:
                    return 0; 
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 4;             
                case 4:
                    return 8; 
                default:
                    return 0;                             
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
                    menuSalvarComo.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                     menuSalvarComo.Enabled = false;
                }
            }
            catch { }
        }
                            

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "SetEffectTable.iff";
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
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);

            // Atualizar o item da lista com os valores dos controles
            var item = lsTemp[index];

            // Atualizar os valores de Effect

            item.effect.effect[0] = (uint)cbEffect.SelectedIndex;
            item.effect.effect[1] = (uint)cbEffect2.SelectedIndex;
            item.effect.effect[2] = (uint)cbEffect3.SelectedIndex;

            item.effect.Type[0] = getFlag(cbType.SelectedIndex);
            item.effect.Type[1] = getFlag(cbType2.SelectedIndex);
            item.effect.Type[2] = getFlag(cbType3.SelectedIndex);
            item.Effect_Add_Power = short.Parse(txtAddPower.Text);

            // Atualizar os IDs dos itens
            item.item.ID[0] = uint.Parse(txtItem1.Text);
            item.item.ID[1] = uint.Parse(txtItem2.Text);
            item.item.ID[2] = uint.Parse(txtItem3.Text);
            item.item.ID[3] = uint.Parse(txtItem4.Text);
            item.item.ID[4] = uint.Parse(txtItem5.Text);

            // Atualizar o status dos itens
            item.item.Active[0] = ckItem1.Checked ? (byte)1u : (byte)0u;
            item.item.Active[1] = ckItem2.Checked ? (byte)1u : (byte)0u;
            item.item.Active[2] = ckItem3.Checked ? (byte)1u : (byte)0u;
            item.item.Active[3] = ckItem4.Checked ? (byte)1u : (byte)0u;
            item.item.Active[4] = ckItem5.Checked ? (byte)1u : (byte)0u;

            // Atualizar os valores dos slots
            item.Slot[0] = (short)nrSlot1.Value;
            item.Slot[1] = (short)nrSlot2.Value;
            item.Slot[2] = (short)nrSlot3.Value;
            item.Slot[3] = (short)nrSlot4.Value;
            item.Slot[4] = (short)nrSlot5.Value;

            // Atualizar o índice
            item.Index = uint.Parse(txtIndex.Text);
            lsTemp[index] = item;
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
                    var coin = lsTemp.Last().Clone() as SetEffectTable;
                    coin.Index = 0;
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


        private void FrmSetEffectTable_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "SetEffectTable.iff";
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

    }
}
