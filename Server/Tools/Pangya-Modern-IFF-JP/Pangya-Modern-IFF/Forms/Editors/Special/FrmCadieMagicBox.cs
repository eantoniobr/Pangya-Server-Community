using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmCadieMagicBox : Form
    {
        private bool sfile;

        public FrmCadieMagicBox()
        {
            InitializeComponent();
        }

        public FrmCadieMagicBox(IFFFile<CadieMagicBox> items)
        {
            uint indexs = 1;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Index = indexs;
                indexs++;
            }
            InitializeComponent();
            this.lsItens = items;     
        }

        private void FrmCadieMagicBox_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "CadieMagicBox.iff";
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
                comboBox3.SelectedIndex = -1;
                ComboBox2.SelectedIndex = -1;
                cbPage.SelectedIndex = -1;
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<CadieMagicBox>();
                this.lsTemp = new IFFFile<CadieMagicBox>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                
                try
                {
                    this.lsItens = new IFFFile<CadieMagicBox>(Arquivo);

                    uint indexs = 1;
                    for (int i = 0; i < lsItens.Count; i++)
                    {
                        lsItens[i].Index = indexs;
                        indexs++;
                    }
                }
                catch
                {
                    MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsItens.Count);
            }
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

        public void CarregarGrid(IFFFile<CadieMagicBox> lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(lista)));
                return;
            }
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Status", typeof(Image));
            dataTable.Columns.Add("Alterado", typeof(int));
            dataTable.Columns.Add("Page", typeof(int));
            dataTable.Columns.Add("Personagem", typeof(int));
            foreach (var item in lista)
            {
                Image status = item.Active != 1L ? Resources.BtnRemove_Mini : Resources.BtnApply_Mini;
                int alterado = 0;

                // Consider using a safer approach to parse integer if necessary
                int index = (int)item.Index - 1;
                if (ListaItem.Rows.Count > index && ListaItem["Alterado", index].Value != null)
                {
                    alterado = Convert.ToInt32(ListaItem["Alterado", index].Value);
                }


                int char_ = 0;
                if (sIff.getInstance() != null)
                {
                    if (sIff.getInstance().getItemGroupIdentify(item.ID) == 2)
                    {
                        var itemPart = sIff.getInstance().Part.FirstOrDefault(c => c.ID == item.ID);
                        if (itemPart != null)
                        {
                            char_ = itemPart.getCharacter(true);
                        }
                    }
                }
                var Page = 0;
                switch (item.Page)
                {
                    case CadieBoxSetor.Unknown:
                        Page = 1;
                        break;
                    case CadieBoxSetor.Beginner:
                        Page = 2;
                        break;
                    case CadieBoxSetor.Intermediary:
                        Page = 3;
                        break;
                    case CadieBoxSetor.Advance:
                        Page = 4;
                        break;
                    case CadieBoxSetor.Special:
                        Page = 5;
                        break;
                    case CadieBoxSetor.Event:
                        Page = 6;
                        break;
                    default:
                        break;
                }
                dataTable.Rows.Add(item.ID, item.Name, index, status, alterado, Page, char_);
            }

            // Use Invoke only if necessary, and ensure thread-safety when updating UI components
            ListaItem.Invoke((MethodInvoker)delegate
            {                      
                bs = new BindingSource(dataTable, null);  
                ListaItem.DataSource = bs;
                lbTotalItens.Text = ListaItem.Rows.Count.ToString();

                // Deselect all rows
                ListaItem.ClearSelection();

                organizarColunas();

                filtrar();

                // Safely handle scrolling and row selection
                if (ListaItem.Rows.Count > 0)
                {
                    int rowIndex = Math.Max(lastRow - 3, 0);
                    ListaItem.FirstDisplayedScrollingRowIndex = rowIndex;
                    ListaItem.Rows[Math.Min(lastRow, ListaItem.Rows.Count - 1)].Selected = true;
                }

                pintarLinhas();
            });
        }

        public void AtualizarGrid(CadieMagicBox item)
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
                    table.Columns.Add("Index", typeof(int));
                    table.Columns.Add("Status", typeof(Image));
                    table.Columns.Add("Alterado", typeof(int));
                    table.Columns.Add("Page", typeof(int));
                    table.Columns.Add("Personagem", typeof(int));
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

            var status = (item.Active != 1L) ? Properties.Resources.BtnRemove_Mini : Properties.Resources.BtnApply_Mini;
            int index = (int)item.Index - 1;
            int alterado = (ListaItem.Rows.Count > index && ListaItem["Alterado", index].Value != null)
                ? Convert.ToInt32(ListaItem["Alterado", index].Value)
                : 0;

            var page = (int)GetPage(item.Page);
            var char_ = GetCharacter(item.ID);

            var newRow = dataTable.NewRow(); 
            newRow["ID"] = item.ID;
            newRow["Item"] = item.Name;
            newRow["Index"] = index;
            newRow["Status"] = status;
            newRow["Personagem"] = char_;
             newRow["Page"] = page;
            newRow["Alterado"] = 0;
            dataTable.Rows.Add(newRow);
 
            // Atualiza a fonte de dados
            ListaItem.DataSource = null;
            bs = new BindingSource();
            bs.DataSource = dataTable;
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;

            // Atualiza o total de itens
            lbTotalItens.Text = ListaItem.Rows.Count.ToString();

            // Seleciona a última linha ou mantém a rolagem
            try
            {
                if (ListaItem.Rows.Count > 0)
                {
                    int rowIndex = Math.Max(lastRow - 3, 0);
                    ListaItem.FirstDisplayedScrollingRowIndex = rowIndex;
                    ListaItem.Rows[Math.Min(lastRow, ListaItem.Rows.Count - 1)].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a rolagem: " + ex.Message);
            }

            // Atualiza o estilo das linhas, se necessário
            pintarLinhas();
        }

        // Método auxiliar para obter o valor da página
        private int GetPage(CadieBoxSetor page)
        {
            switch (page)
            {
                case CadieBoxSetor.Unknown:
                    return 1;
                case CadieBoxSetor.Beginner:
                    return 2;
                case CadieBoxSetor.Intermediary:
                    return 3;
                case CadieBoxSetor.Advance:
                    return 4;
                case CadieBoxSetor.Special:
                    return 5;
                case CadieBoxSetor.Event:
                    return 6;
                default:
                    return 0;
            }
        }

        // Método auxiliar para obter o personagem
        private int GetCharacter(uint itemId)
        {
            if (sIff.getInstance() != null && sIff.getInstance().getItemGroupIdentify(itemId) == 2)
            {
                var itemPart = sIff.getInstance().Part.FirstOrDefault(c => c.ID == itemId);
                if (itemPart != null)
                {
                    return itemPart.getCharacter(true);
                }
            }
            return 0;
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
            ListaItem.Columns[0].Width = 15;
            ListaItem.Columns[1].Width = 45; // 0x2d in decimal
            ListaItem.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ListaItem.Columns[3].Width = 30;
            ListaItem.Columns[3].HeaderText = "   ";

            // Hide unnecessary columns
            ListaItem.Columns[2].Visible = false;
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
            img1.Image = Resources.bg_transparent;
            img2.Image = Resources.bg_transparent;
            img3.Image = Resources.bg_transparent;
            img4.Image = Resources.bg_transparent;
            txtItem1.Text = "0";//Conversions.ToString(item.box_packege.Index[0]);
            txtItem2.Text = "0";//Conversions.ToString(item.box_packege.Index[1]);
            txtItem3.Text = "0";//Conversions.ToString(item.box_packege.Index[2]);
            txtItem4.Text = "0";//Conversions.ToString(item.box_packege.Index[3]);  
            if (ListaItem.SelectedCells[0].RowIndex > -1)
            {                                                                     
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                var item = lsTemp[index];
                this.lbIndices.Text = Conversions.ToString(index);
                txtNome.Text = item.Name;            
                txtTypeID.Text = Conversions.ToString(item.ID);
                txtItemProdQtd.Value = new decimal(item.Total);
                if (item.Box_Random_ID > 0L)
                {
                    ckisRandom.Checked = true;
                }
                else
                {
                    ckisRandom.Checked = false;
                }
                txtProdItem.Text = item.ProdItem.ToString();
                txtItem1.Text = Conversions.ToString(item.box_packege.ID[0]);
                txtItem2.Text = Conversions.ToString(item.box_packege.ID[1]);
                txtItem3.Text = Conversions.ToString(item.box_packege.ID[2]);
                txtItem4.Text = Conversions.ToString(item.box_packege.ID[3]);
                txtItem1Qtd.Text = Conversions.ToString(item.box_packege.Qntd[0]);
                txtItem2Qtd.Text = Conversions.ToString(item.box_packege.Qntd[1]);
                txtItem3Qtd.Text = Conversions.ToString(item.box_packege.Qntd[2]);
                txtItem4Qtd.Text = Conversions.ToString(item.box_packege.Qntd[3]);
                txtU6.Text = Conversions.ToString((int)item.BoxType);
                 txtBoxID.Text = item.Box_Random_ID.ToString();
                SetPage((int)lsTemp[index].Page);
                txtIndex.Text = Conversions.ToString(lsTemp[index].Index);
                ckAtivo.Checked = lsTemp[index].Active > 0uL;
                if (lsTemp[index].Level <= 72L)
                {
                    cbLevel.SelectedIndex = (int)lsTemp[index].Level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = (int)(lsTemp[index].Level - 128L);
                    rbLevelMax.Checked = true;
                }
                if (lsTemp[index].date.Check())
                {
                    dtInicio.Value = lsTemp[index].date.Start.Time;
                    dtTermino.Value = lsTemp[index].date.End.Time;
                    ckTimeEvent.Checked = true;
                }
                else
                {
                    dtInicio.Value = lsTemp[index].date.Start.Time;
                    dtTermino.Value = lsTemp[index].date.End.Time;
                    ckTimeEvent.Checked = false;
                }
            }
            Alterado = false;
        }

        private void SetPage(int page)
        {
            switch ((CadieBoxSetor)page)
            {
                case CadieBoxSetor.Unknown:
                    cbAba.SelectedIndex = 0;
                    break;
                case CadieBoxSetor.Beginner:
                    cbAba.SelectedIndex = 1;
                    break;
                case CadieBoxSetor.Intermediary:
                    cbAba.SelectedIndex = 2;
                    break;
                case CadieBoxSetor.Advance:
                    cbAba.SelectedIndex = 3;
                    break;
                case CadieBoxSetor.Special:
                    cbAba.SelectedIndex = 4;
                    break;
                case CadieBoxSetor.Event:
                    cbAba.SelectedIndex = 5;
                    break;
                default:
                    break;
            }
        }
        private CadieBoxSetor GetPage()
        {
            switch (cbAba.SelectedIndex)
            {
                case 0: return CadieBoxSetor.Unknown;
                case 1: return CadieBoxSetor.Beginner;
                case 2: return CadieBoxSetor.Intermediary;
                case 3: return CadieBoxSetor.Advance;
                case 4: return CadieBoxSetor.Special;
                case 5: return CadieBoxSetor.Event;
            }
            return CadieBoxSetor.Unknown;
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
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    btnCima.Enabled = false;
                    btnBaixo.Enabled = false;
                    btnIndices.Enabled = true;
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
            comboBox3.SelectedIndex = 0;
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
            if (ListaItem.SelectedRows.Count == 1)
            {

                try
                {
                    int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                    lsTemp[index].Active = ckAtivo.Checked ? (uint)1 : 0;
                    lsTemp[index].Name = txtNome.Text;
                    lsTemp[index].ID = (uint)Conversions.ToLong(txtTypeID.Text);
                    lsTemp[index].Total = Convert.ToUInt32(txtItemProdQtd.Value);
                    lsTemp[index].box_packege.ID[0] = (uint)Conversions.ToLong(txtItem1.Text);
                    lsTemp[index].box_packege.ID[1] = (uint)Conversions.ToLong(txtItem2.Text);
                    lsTemp[index].box_packege.ID[2] = (uint)Conversions.ToLong(txtItem3.Text);
                    lsTemp[index].box_packege.ID[3] = (uint)Conversions.ToLong(txtItem4.Text);
                    lsTemp[index].box_packege.Qntd[0] = (uint)Conversions.ToLong(txtItem1Qtd.Text);
                    lsTemp[index].box_packege.Qntd[1] = (uint)Conversions.ToLong(txtItem2Qtd.Text);
                    lsTemp[index].box_packege.Qntd[2] = (uint)Conversions.ToLong(txtItem3Qtd.Text);
                    lsTemp[index].box_packege.Qntd[3] = (uint)Conversions.ToLong(txtItem4Qtd.Text);
                    lsTemp[index].Page = GetPage();
                    lsTemp[index].Index = (uint)Conversions.ToLong(txtIndex.Text);
                    lsTemp[index].BoxType = (CadieBoxEnum)Conversions.ToLong(txtU6.Text);
                    lsTemp[index].ProdItem = Conversions.ToUInteger(txtProdItem.Text);

                    if (ckisRandom.Checked)
                        lsTemp[index].Box_Random_ID = Conversions.ToUInteger(txtBoxID.Text);
                    else
                        lsTemp[index].Box_Random_ID = Conversions.ToUInteger(txtBoxID.Text);

                    if (ckTimeEvent.Checked)
                    {
                        var time = DateTime.Parse("01/01/1997 00:00");
                        if (dtInicio.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) < 0)
                            lsTemp[index].date.Start = new IFFTime(dtInicio.Value);

                        if (dtTermino.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) > 0)
                            lsTemp[index].date.End = new IFFTime(dtTermino.Value);
                    }

                    switch (lsTemp[index].Active)
                    {
                        case 0:
                            ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnRemove_Mini;
                            break;
                        case 1:
                            ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnApply_Mini;
                            break;
                    }
                    ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
                    ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                    ListaItem.SelectedRows[0].Cells["ID"].Value = txtTypeID.Text;  //seta novo Index

                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
            }
            else
            {
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int num = Conversions.ToInteger(row.Cells[2].Value);
                    this.lsTemp[num].Active = Convert.ToUInt32(ckAtivo.Checked);
                    lsTemp[num].Total = Convert.ToUInt32(txtItemProdQtd.Value);
                    lsTemp[num].box_packege.ID[0] = (uint)Conversions.ToLong(txtItem1.Text);
                    lsTemp[num].box_packege.ID[1] = (uint)Conversions.ToLong(txtItem2.Text);
                    lsTemp[num].box_packege.ID[2] = (uint)Conversions.ToLong(txtItem3.Text);
                    lsTemp[num].box_packege.ID[3] = (uint)Conversions.ToLong(txtItem4.Text);
                    lsTemp[num].box_packege.Qntd[0] = (uint)Conversions.ToLong(txtItem1Qtd.Text);
                    lsTemp[num].box_packege.Qntd[1] = (uint)Conversions.ToLong(txtItem2Qtd.Text);
                    lsTemp[num].box_packege.Qntd[2] = (uint)Conversions.ToLong(txtItem3Qtd.Text);
                    lsTemp[num].box_packege.Qntd[3] = (uint)Conversions.ToLong(txtItem4Qtd.Text);

                    switch (lsTemp[num].Active)
                    {
                        case 0:
                            row.Cells["Status"].Value = Resources.BtnRemove_Mini;
                            break;
                        case 1:
                            row.Cells["Status"].Value = Resources.BtnApply_Mini;
                            break;
                    }
                    row.Cells["Alterado"].Value = 1;
                }
            }
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
            CarregarItem();

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedRows.Count > 1)
            {
                lastRow = ListaItem.SelectedRows[0].Index - 1;
                if (MessageBox.Show("Do you want to remove the " + Conversions.ToString(ListaItem.SelectedRows.Count) + " selected items?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int num = Conversions.ToInteger(row.Cells[2].Value);
                    RemoverItem(lsTemp[num].ID);
                    lsTemp.Remove(lsTemp[num]);
                }
             }
            else
            {
                lastRow = ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Do you want to remove the item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                    RemoverItem(lsTemp[index].ID);
                    lsTemp.Remove(lsTemp[index]);
                 }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            checked
            {
                if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var item = lsTemp[lsTemp.Count - 1].Clone() as CadieMagicBox;
                    item.Name = "New Item";
                    item.Index = (uint)lsTemp.Count + 1;
                    try
                    {
                        lsTemp.Add(item);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        ProjectData.ClearProjectError();
                    }                   
                    AtualizarGrid(item);
                }
            }
        }

        private void MenuSalvar_Click(object sender, EventArgs e)
        {
            sfile = true;
            diagSalvarArquivo.ShowDialog();
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
                if (MessageBox.Show("There are changes that have not been saved, do you want to save them now?", "Pangya Modern Editor", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            if (MessageBox.Show("Do you want to clone the selected item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
             var item = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value)].Clone() as CadieMagicBox;
             item.Index = (uint)lsTemp.Count + 1;
            item.Name = "Item Copy";
             try
            {
                lsTemp.Add(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            
            AtualizarGrid(item);
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Saving...";
            salvar(backgroundWorker);       
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
                if ((comboBox3.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0) && cbPage.SelectedIndex > -1)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (comboBox3.SelectedIndex).ToString() + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((comboBox3.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (comboBox3.SelectedIndex);
                }
                else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Convert.ToString(num);
                }
                else if ((cbPage.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((comboBox3.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (cbPage.SelectedIndex > 0))
                {
                    bs.Filter = "Personagem = " + Convert.ToString(comboBox3.SelectedIndex) + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if (txtPesquisa.Text.Length > 0)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                }
                else if (comboBox3.SelectedIndex > 0)
                {
                    bs.Filter = "Personagem = " + Convert.ToString(comboBox3.SelectedIndex);
                }
                else if (ComboBox2.SelectedIndex > 0)
                {
                    bs.Filter = "Status2 = " + Convert.ToString(num);
                }
                else if (cbPage.SelectedIndex >= 0)
                {
                    bs.Filter = "Page = " + Convert.ToString(cbPage.SelectedIndex);
                }

                if(bs.Count == 0)
                {
                    bs.Filter = "";
                    comboBox3.SelectedIndex = -1;
                    ComboBox2.SelectedIndex = -1;
                    cbPage.SelectedIndex =  - 1;
                }
                lblSearchCount.Text = Conversions.ToString(bs.Count);
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
            TextBox textBox = sender as TextBox;

            // Verifica se o texto do TextBox realmente mudou
            if (textBox != null && textBox.Modified)
            {
                Alterado = true;
                textBox.Modified = false; // Reinicia o sinal de alteração para evitar detectar mudanças futuras sem intenção
            }

            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtTypeID.Text));
             if (iffCommon != null && iffCommon.ShopIcon != "none")
                imgResultado.Image = Util.getImage(iffCommon.ShopIcon, false);
        }

        private void txtItem1_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtItem1.Text));
            if (iffCommon != null && iffCommon.ShopIcon != "none")
                img1.Image = Util.getImage(iffCommon.ShopIcon, false);
        }

        private void txtItem2_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtItem2.Text));
             if (iffCommon != null && iffCommon.ShopIcon != "none")
                img2.Image = Util.getImage(iffCommon.ShopIcon, false);
        }

        private void txtItem3_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtItem3.Text));
             if (iffCommon != null && iffCommon.ShopIcon != "none")
                img3.Image = Util.getImage(iffCommon.ShopIcon, false);
        }

        private void txtItem4_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtItem4.Text));
             if (iffCommon != null && iffCommon.ShopIcon != "none")
                img4.Image = Util.getImage(iffCommon.ShopIcon, false);
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
            if (ListaItem.SelectedRows.Count > 0)
            {
                var cadieMagicBox = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value)];
                lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value)]);
                try
                {
                    lsTemp.Add(cadieMagicBox);
                }
                catch (Exception projectError2)
                {
                    ProjectData.SetProjectError(projectError2);
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

        private void btnBaixo_Click(object sender, EventArgs e)
        {
            alterarPos(-1);
        }

        private void btnIndices_Click(object sender, EventArgs e)
        {
            try
            {
                // Reorganiza a lista, colocando os itens com Page igual a CadieBoxSetor.Beginner primeiro
                var reorganize = lsTemp
                    .OrderBy(c => c.Page != CadieBoxSetor.Beginner) // Primeiro coloca os "Beginner" no início
                    .ThenBy(c => (int)c.Page) // Depois ordena o restante de acordo com o valor do enum
                    .ToList();

                // Atualiza os índices
                for (int i = 0; i < reorganize.Count; i++)
                {
                    reorganize[i].Index = (uint)(i + 1);
                    if (sIff.getInstance() != null)
                    {
                        if (sIff.getInstance().FindCommonItem(reorganize[i].ID).Name != "Name Unknown")
                        {
                            reorganize[i].Name = sIff.getInstance().FindCommonItem(reorganize[i].ID).Name;
                        }
                    }   
                }

                // Atualiza a lista original com a lista reorganizada
                for (int i = 0; i < lsTemp.Count; i++)
                {
                    lsTemp[i] = reorganize[i];
                }                                    
                CarregarGrid(lsTemp);

                // Mensagem de sucesso
                MessageBox.Show("Reorganization Data!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Exibe a mensagem de erro com detalhes
                MessageBox.Show($"Failed to Reorganization Data! Erro: {ex.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/40";
            Alterou(sender, e);
        }

        private void ckTimeEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTimeEvent.Checked)
            {
                dtInicio.Enabled = true;
                dtTermino.Enabled = true;
            }
            else
            {
                dtInicio.Enabled = false;
                dtTermino.Enabled = false;
            }
        }

        private void FrmCadieMagicBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bwSalvar.IsBusy)
            {
                MessageBox.Show("There are tasks still running, it is necessary to wait for these tasks to finish.", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
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
