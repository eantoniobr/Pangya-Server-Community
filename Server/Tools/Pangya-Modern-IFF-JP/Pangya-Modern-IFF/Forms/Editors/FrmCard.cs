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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmCard : Form
    {
        public bool IsLoad;
        private bool sfile;

        public FrmCard()
        {
            InitializeComponent();
            IsLoad = false;
        }

        public FrmCard(IFFFile<Card> items)
        {
            InitializeComponent();
            this.lsItens = items;
            //sfile = false;
        }

        private void FrmCard_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Card.iff";
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
                this.ComboBox1.SelectedIndex = 0;
                this.ComboBox2.SelectedIndex = 0;
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<Card>();
                this.lsTemp = new IFFFile<Card>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                
                try
                {
                    this.lsItens = new IFFFile<Card>(Arquivo);
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

        public void CarregarGrid(IFFFile<Card> Lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            var num3 = 0;
            foreach (var item in Lista)
            {
                oIff = item;
                Image statusImage = (oIff.Active) ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini;
                Image tipoImage = Resources.Disable;
                var item_type2 = 0;

                switch (oIff.GetTypeCash())
                {
                    case 0:
                        if (oIff.IsOnlyDisplay())
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
                        if (oIff.IsOnlyDisplay())
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
                        if (oIff.IsOnlyDisplay())
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

                try
                {
                    // Obtenha o valor da célula "Alterado"
                    object alteradoCellValue = null;

                    if (ListaItem.Rows.Count > 1 && ListaItem["Alterado", num3].Value != null)
                    {
                        alteradoCellValue = ListaItem["Alterado", num3].Value;
                    }

                    if (alteradoCellValue != null)
                    {
                        if (int.TryParse(alteradoCellValue.ToString(), out int result))
                        {
                            alterado = result;
                        }
                        else
                        {
                            // Lidar com a situação em que não é possível converter para int
                            alterado = 0; // Ou outra ação apropriada
                        }
                    }
                    else
                    {
                        // Lidar com a situação em que o valor é nulo
                        alterado = 0; // Ou outra ação apropriada
                    }
                }
                catch (Exception projectError2)
                {
                    alterado = 0;
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }

                var id = oIff.Rarity;

                object[] values = new object[] { oIff.ID, oIff.Name, statusImage, id, item_type2, tipoImage, alterado };

                table.Rows.Add(values);
                num3++;
            }
            ListaItem.Invoke((MethodInvoker)delegate
            {
                
                bs = new BindingSource(table, null);
                ListaItem.DataSource = bs;
                lbTotalItens.Text = ListaItem.Rows.Count.ToString();
                ListaItem.Columns[0].Width = 0x2d;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;
                ListaItem.Columns[0].ValueType = typeof(int);
                ListaItem.Columns[2].HeaderText = "   ";
                ListaItem.Columns[5].HeaderText = "   ";
                ListaItem.Columns[3].Visible = false;
                ListaItem.Columns[4].Visible = false;
                ListaItem.Columns[6].Visible = false;

                try
                {
                    if (lastRow < ListaItem.Rows.Count)
                    {
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                        ListaItem.Rows[lastRow].Selected = true;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }
                filtrar();
                pintarLinhas();
            });
        }
        public void AtualizarGrid(Card item)
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
            var id = oIff.Rarity;

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

        private void pintarLinhas()
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
                ListaItem.Columns[0].Width = 45;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;
            }
        }

        private void resetFlags()
        {
            ckNormal.Checked = false;
            ckNew.Checked = false;
            ckGift.Checked = false;
            ckHot.Checked = false;
            ckDisplay.Checked = false;
            ckPSQ.Checked = false;
            ckDesativado.Checked = false;
            txtDesc.Text = "";       
            this.txtBuffImage.Text = "";
            this.txtSlotImage.Text = "";
            this.txtSubIcon.Text = "";
            txtCardImage.Text = "";
            this.txtCardNo.Text = "";
            txtIcone.Text = "";
        }
        private void CarregarItem()
        {
            resetFlags();  // sempre manter assim
            if (ListaItem.SelectedCells[0].RowIndex != -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                var item = lsTemp.First(c => c.ID == index);
                this.lbIndices.Text = Conversions.ToString(lsTemp.FindIndex(c => c.ID == index));
                int num = 0;
                txtNome.Text = item.Name;
                txtTypeID.Text = Conversions.ToString(item.ID);
                ckAtivo.Checked = item.Active;
                txtIcone.Text = item.ShopIcon;
                txtPreco.Text = Conversions.ToString(item.Shop.Price);
                txtDesconto.Text = Conversions.ToString(item.Shop.DiscountPrice);
                txtCardImage.Text = item.MPet;
                attForca.Value = new decimal(item.Power);
                attControle.Value = new decimal(item.Control);
                attPrecisao.Value = new decimal(item.Impact);
                attSpin.Value = new decimal(item.Spin);
                attCurva.Value = new decimal(item.Curve);
                this.cmbEffect.Text = item.Effect.ToString();
                this.cmbEffect0.Text = item.GetTypeEffect();
                txtEffectValue.Text = item.EffectValue.ToString();
                txtFlag1.Text = item.flag1.ToString();
                txtFlag2.Text = item.flag2.ToString();
                ckTimeShopActive.Checked = item.Shop.flag_shop.time_shop.active;
                nrDay.Value = ((int)item.Shop.flag_shop.time_shop.getDay());
                this.txtBuffImage.Text = item.AdditionalTexture3;
                this.txtSlotImage.Text = item.AdditionalTexture2;
                this.txtSubIcon.Text = item.AdditionalTexture1;
                this.txtCardNo.Text = item.Position.ToString();
                SetVolume(item.Volumn);
                txtRarity.Text = item.Rarity.ToString();
                txtEffectDuration.Text = item.EffectTime.ToString();
                if (sIff.getInstance().Desc.Any(c => c.ID == item.ID))
                {
                    var desc = sIff.getInstance().FindDesc(item.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
                if ((int)item.Level.level <= 72)
                {
                    num = (int)item.Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    num = unchecked((int)item.Level.level) - 128;
                    rbLevelMax.Checked = true;
                }
                cbLevel.SelectedIndex = num;
                cbTipo.SelectedIndex = item.GetTypeCash();
                ckNormal.Checked = item.IsNormal();
                ckNew.Checked = item.IsNew();
                ckGift.Checked = item.IsGiftItem();
                ckHot.Checked = item.IsHot();
                ckDisplay.Checked = item.IsOnlyDisplay();
                ckPSQ.Checked = item.IsPSQ();
                ckSpecial.Checked = item.Shop.flag_shop.IsSpecial;
                ckDesativado.Checked = item.IsHide;
                if (!ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckPSQ.Checked && !ckDesativado.Checked)
                    ckDesativado.Checked = true; 
                else
                {
                    if (ckDesativado.Checked && item.IsPSQ())
                    {
                        ckDesativado.Checked = false;
                        ckPSQ.Checked = item.IsPSQ();
                    }
                }
                if (ckNew.Checked && ckHot.Checked)
                {
                    if (item.IsHot())
                    {
                        ckNew.Checked = false;
                    }
                }
                dtInicio.Value = item.date.Start.Time;
                dtTermino.Value = item.date.End.Time;
                ckTempoAtivo.Checked = item.date.Check();
            }
            Alterado = false;
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

        private void ListaItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                // Verifica se há células selecionadas
                if (ListaItem.SelectedCells.Count > 0)
                {
                    ListaItem.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

                    // Copia os dados para a área de transferência sem incluir o cabeçalho        
                    List<string> copiedDataList = new List<string>();

                    // Itera sobre as células selecionadas
                    foreach (DataGridViewRow row in ListaItem.SelectedRows)
                    {
                        string rowData = $"{row.Cells[0].Value},{row.Cells[1].Value}";
                        copiedDataList.Add(rowData);

                    }
                    // Formata todos os dados em uma única string separada por novas linhas
                    string csvData = string.Join(Environment.NewLine, copiedDataList);

                    // Define os dados CSV na área de transferência
                    Clipboard.SetData(DataFormats.Text, csvData);
                }
            }
            if (e.Control && e.KeyCode == Keys.P)   //gerar o excell
            {
                // Verifica se há células selecionadas
                if (ListaItem.SelectedCells.Count > 0)
                {
                    ListaItem.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                    // Copia os dados para a área de transferência sem incluir o cabeçalho        
                    List<string> copiedDataList = new List<string>();

                    // Itera sobre as células selecionadas
                    foreach (DataGridViewRow row in ListaItem.SelectedRows)
                    {
                        string rowData = $@"/giveitem DEV {row.Cells[0].Value} 1";
                        copiedDataList.Add(rowData);
                    }
                    // Formata todos os dados em uma única string separada por novas linhas
                    string csvData = string.Join(Environment.NewLine, copiedDataList);

                    // Define os dados CSV na área de transferência
                    Clipboard.SetData(DataFormats.Text, csvData);
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                // Verifica se há algo na área de transferência
                if (Clipboard.ContainsText())
                {
                    // Confirmação para colar os dados
                    if (MessageBox.Show("Do you want to paste the items from the clipboard?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        PasteClipboardData();
                    }
                }
            }
        }

        private void PasteClipboardData()
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                string[] lines = clipboardText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                lbStatus.Text = "Processing...";
                bs.Filter = "";
                foreach (string line in lines)
                {
                    var _line = line.Trim();
                    // Encontra o primeiro espaço para separar o Index do Item
                    int spaceIndex = _line.IndexOf("\t");
                    if (spaceIndex == -1)
                        spaceIndex = line.IndexOf(' ');

                    if (spaceIndex > -1)
                    {
                        // Extrai o Index e o Item da linha
                        string idStr = _line.Substring(0, spaceIndex).Trim();
                        string item = _line.Substring(spaceIndex).Trim();

                        // Verifica se o Index é um número válido
                        if (uint.TryParse(idStr, out uint id))
                        {
                            // Busca o índice do item na lista lstTemp com base no Index
                            int rowIndex = lsTemp.FindIndex(c => c.ID == id);
                            if (rowIndex != -1)
                            {
                                if (rowIndex < ListaItem.RowCount)
                                {
                                    // Atualiza o DataGridView
                                    ListaItem[0, rowIndex].Value = id;
                                    ListaItem[1, rowIndex].Value = item;
                                    ListaItem[6, rowIndex].Value = 1;
                                }
                                lsTemp[rowIndex].Name = item;
                                lsTemp[rowIndex].ID = id;
                            }   
                        }
                        else
                        {
                            MessageBox.Show($"Unable to convert '{idStr}' para um número inteiro (Index).", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Formato inválido na linha: '{line}'", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                lbStatus.Text = "Terminou...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while pasting the data: " + ex.Message, "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lbStatus.Text = "Parado...";
            pintarLinhas();
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
                    btnReabrir.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuGerarSql.Enabled = false;
                }
                else if (ListaItem.SelectedRows.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;                            
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                }
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
                if (verificarTYPEID())
                {
                    txtTypeID.BackColor = Color.LightSalmon;
                }
                else
                {
                    txtTypeID.BackColor = Color.White;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private bool verificarTYPEID(int typeid = 0)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0)
            {
                typeid = Conversions.ToInteger(txtTypeID.Text);
            }
            else
            {
                flag = true;
            }
            num = lsTemp.Count(item => item.ID == typeid);
            if (flag)
            {
                if (num == 1)
                {
                    return true;
                }
                return false;
            }
            if (num > 1)
            {
                return true;
            }
            return false;
        }

        private void filtrar()
        {
            try
            {
                if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    var index2 = ComboBox2.SelectedIndex;

                    if (index2 == 1)
                    {
                        bs.Filter = $"Item LIKE '%{txtPesquisa.Text}%'  AND (Status2 = 2 OR Status2 = 3)";
                    }
                    else
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex);
                    }
                }
                else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    var index2 = ComboBox2.SelectedIndex;

                    if (index2 == 1)
                        bs.Filter = $"Item LIKE '%{txtPesquisa.Text}%' AND (Status2 = 2 OR Status2 = 3)";

                    else
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(index2);
                }

                else if (txtPesquisa.Text.Length > 0)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                }
                else if (ComboBox2.SelectedIndex > 0)
                {
                    var index2 = ComboBox2.SelectedIndex;

                    if (index2 == 1)
                        bs.Filter = $"Status2 = 2 OR Status2 = 3";
                    else
                        bs.Filter = "Status2 = " + Conversions.ToString(index2);
                }
                else
                {
                    bs.Filter = "";
                }
                if (bs.Count == 0)
                {
                    bs.Filter = "";
                    MessageBox.Show("the searched string does not exist", "Pangya Modern Editor");
                }
                lblSearchCount.Text = Convert.ToString(bs.Count);
                ListaItem.Columns[0].Width = 45;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;
                ListaItem.Columns[0].ValueType = typeof(int);
                ListaItem.Columns[2].HeaderText = "   ";
                ListaItem.Columns[5].HeaderText = "   ";
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
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

     
        private void btnReabrir_Click(object sender, EventArgs e)
        {
            this.salvarAlteracoes();
            this.pintarLinhas();
        }

        private void salvarAlteracoes()
        {
            if (ListaItem.SelectedRows.Count == 1)
            {

                int num = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
                lsTemp[num].Active = (ckAtivo.Checked);
                lsTemp[num].Name = txtNome.Text;
                lsTemp[num].Shop.Price = (uint)Conversions.ToLong(txtPreco.Text);
                lsTemp[num].ID = (uint)Conversions.ToLong(txtTypeID.Text);
                lsTemp[num].ShopIcon = txtIcone.Text;
                lsTemp[num].Effect = Convert.ToUInt16(cmbEffect.Text);
                lsTemp[num].EffectValue = Convert.ToUInt16(txtEffectValue.Text);
                lsTemp[num].flag1 = Convert.ToUInt32(txtFlag1.Text);
                lsTemp[num].flag2 = Convert.ToUInt32(txtFlag2.Text);
                lsTemp[num].Level.level = (byte)cbLevel.SelectedIndex;
                lsTemp[num].Shop.DiscountPrice = (uint)Conversions.ToLong(txtDesconto.Text);
                lsTemp[num].MPet = txtCardImage.Text;
                lsTemp[num].Shop.flag_shop.time_shop.active = ckTimeShopActive.Checked;
                lsTemp[num].Shop.flag_shop.time_shop.SetDay(nrDay.Value);
                lsTemp[num].AdditionalTexture1 = txtSubIcon.Text;
                lsTemp[num].AdditionalTexture2 = txtSlotImage.Text;
                lsTemp[num].AdditionalTexture3 = txtBuffImage.Text;
                lsTemp[num].Volumn = GetVolume();
                lsTemp[num].Position = ushort.Parse(txtCardNo.Text);
                lsTemp[num].Power = byte.Parse(attForca.Text);
                lsTemp[num].Control = byte.Parse(attControle.Text);
                lsTemp[num].Impact = byte.Parse(attPrecisao.Text);
                lsTemp[num].Spin = byte.Parse(attSpin.Text);
                lsTemp[num].Curve = byte.Parse(attCurva.Text);
                lsTemp[num].Rarity = byte.Parse(txtRarity.Text);
                lsTemp[num].EffectTime = ushort.Parse(txtEffectDuration.Text);
                var item = lsTemp[num];
                var check1 = item.IsNormal();
                var check2 = item.IsNew();
                var check3 = item.IsGiftItem();
                var check4 = item.IsHot();
                var check5 = item.IsOnlyDisplay();
                var check6 = item.IsPSQ();
                var check7 =item.IsHide;
                var check8 = item.GetTypeCash();
                if (cbTipo.SelectedIndex != check8 || ckPSQ.Checked != check6 || ckNormal.Checked != check1 || ckNew.Checked != check2 || ckGift.Checked != check3 || ckHot.Checked != check4 || ckDisplay.Checked != check5 || ckDesativado.Checked != check7)
                    lsTemp[num].SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked, ckPSQ.Checked, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);

                if (ckTempoAtivo.Checked)
                {
                    lsTemp[num].date.active = true;
                    var time = DateTime.Parse("01/01/1997 00:00");
                    if (dtInicio.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) < 0)
                        lsTemp[num].date.Start = new IFFTime(dtInicio.Value);

                    if (dtTermino.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) > 0)
                        lsTemp[num].date.End = new IFFTime(dtTermino.Value);
                }
                else
                {
                    lsTemp[num].date.active = false;
                    lsTemp[num].date.Clear();
                }
                switch (lsTemp[num].GetTypeCash())
                {
                    case 0:
                        ListaItem.SelectedRows[0].Cells["Tipo"].Value = Resources.Disable;
                        break;
                    case 1:
                        ListaItem.SelectedRows[0].Cells["Tipo"].Value = Resources.points;
                        break;
                    case 2:
                        ListaItem.SelectedRows[0].Cells["Tipo"].Value = Resources.Pang;
                        break;
                }

                switch (lsTemp[num].Active)
                {
                    case false:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnRemove_Mini;
                        break;
                    case true:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnApply_Mini;
                        break;
                }
                this.ListaItem.SelectedRows[0].Cells[1].Value = this.txtNome.Text;
                this.ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;

            }
            else
            {
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int num = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(row.Cells[0].Value)); 
                    var item = lsTemp[num];
                    var check1 = item.IsNormal();
                    var check2 = item.IsNew();
                    var check3 = item.IsGiftItem();
                    var check4 = item.IsHot();
                    var check5 = item.IsOnlyDisplay();
                    var check6 = item.IsPSQ();
                    var check7 = item.IsHide;
                    var check8 = item.GetTypeCash();
                    if (cbTipo.SelectedIndex != check8 || ckNormal.Checked != check1 || ckNew.Checked != check2 || ckGift.Checked != check3 || ckHot.Checked != check4 || ckDisplay.Checked != check5 || ckPSQ.Checked != check6 || ckDesativado.Checked != check7)
                        lsTemp[num].SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked, ckPSQ.Checked, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);

                    switch (lsTemp[num].GetTypeCash())
                    {
                        case 0:
                            row.Cells["Tipo"].Value = Resources.Disable;
                            break;
                        case 1:
                            row.Cells["Tipo"].Value = Resources.points;
                            break;
                        case 2:
                            row.Cells["Tipo"].Value = Resources.Pang;
                            break;
                    }

                    switch (lsTemp[num].Active)
                    {
                        case false:
                            row.Cells["Status"].Value = Resources.BtnRemove_Mini;
                            break;
                        case true:
                            row.Cells["Status"].Value = Resources.BtnApply_Mini;
                            break;
                    }

                    row.Cells["Alterado"].Value = 1;
                }
            }
            this.Alterado = false;
            this.qtdItem = this.ListaItem.Rows.Count;
            CarregarItem();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clone the selected item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
            item.Name = "Item Clone";
            item.GenerateID(31, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (!verificarTYPEID((int)item.ID))
                    {
                        item.GenerateID(31, i, i);
                    }
                    else
                    {
                        break;
                    }
                }
                lsTemp.Add(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            AtualizarGrid(item);
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
                    int num = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(row.Cells[0].Value));
                    RemoverItem(lsTemp[num].ID);
                    lsTemp.Remove(lsTemp[num]);
                }
            }
            else
            {
                lastRow = ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Do you want to remove the item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
                    RemoverItem(lsTemp[index].ID);
                    lsTemp.Remove(lsTemp[index]);
                }
            }
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            var copy = lsTemp[lsTemp.Count - 1] as Card;
            var item = copy;
            item.ShopIcon = "Icon Shop";
            item.Name = "New Item";
            item.GenerateID(31, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID((int)item.ID))
                    {
                        item.GenerateID(31, i, i);
                    }
                    else
                    {
                        break;
                    }
                }
                lsTemp.Add(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            AtualizarGrid(item);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }

        public void gerarSql(BackgroundWorker BW)
        {
            if (this.Arquivo == null)
            {
                MessageBox.Show("Arquivo inv\x00e1lido!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Convert.ToBoolean(Util.Card_gerarSql(lsTemp, sIff.getInstance() == null? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL Create With Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("File Write With Error !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker)sender;
            this.gerarSql(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Value = e.ProgressPercentage;
            this.lbStatus.Text = "Creating File SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Value = 0;
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbStatus.Text = "stopped";
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
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.lbStatus.Text = "Saving...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Blocks;
            this.pbStatus.Value = 0;
            this.lbStatus.Text = "Stop";
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            this.nomeArquivo();
        }

        private void menuSalvarComo_Click(object sender, EventArgs e)
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
        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            pintarLinhas();
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
        private void gerarBarra(Control Barra, object sender1, object sender2)
        {
            try
            {
                double num5 = 5.9;
                Barra.Width = Conversions.ToInteger(Operators.MultiplyObject(Operators.AddObject(NewLateBinding.LateGet(sender1, null, "value", new object[0], null, null, null), NewLateBinding.LateGet(sender2, null, "value", new object[0], null, null, null)), num5));
            }
            catch (Exception ex)
            {
                // Lida com a exceção, se necessário
                MessageBox.Show("An error occurred: " + ex.Message, "Pangya Modern Editor");
            }
        }
        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }
        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
        }

        public void SetVolume(int vol)
        {
            if (vol == 100)
            {
                txtCardVolum.SelectedIndex = 5;//spc
            }

            else
            {
                txtCardVolum.SelectedIndex = vol;
            }
        }
        public ushort GetVolume()
        {
            if (txtCardVolum.SelectedIndex == 5)
            {
                return 100;//spc
            }

            else
            {
                return (ushort)txtCardVolum.SelectedIndex;//spc
            }
        }

        private void menuGerarSql_Click(object sender, EventArgs e)
        {
            diagSalvarSql.ShowDialog();
            Arquivo = diagSalvarSql.FileName;
            if (Operators.CompareString(Arquivo, null, false) != 0)
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

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (verificarTYPEID())
            {
                MessageBox.Show("Este TYPEID já está em uso!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID available for use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.White;
            }
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

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            var count = lsTemp.Count;
            for (int i = 0; i < count; i++)
            {
                if (lsTemp[i].Active)
                {
                    lsTemp[i].Active = false;
                }
            }
            MessageBox.Show("Todos os itens foram desativados no Game !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var count = lsTemp.Count;

            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            for (int i = 0; i < count; i++)
            {
                if (!lsTemp[i].Active)
                {
                    lsTemp[i].Active = true;
                }
            }
            MessageBox.Show("Todos os itens foram ativados Game !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }
        //ativa
        private void pSQuareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var count = lsTemp.Count;

            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            for (int i = 0; i < count; i++)
            {
                if (!lsTemp[i].IsPSQ())
                {
                    lsTemp[i].SetItemPSQ(2);
                }
            }
            MessageBox.Show("Todos os itens foram ativados no PSQuare !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }

        private void shoppingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            var count = lsTemp.Count;
            for (int i = 0; i < count; i++)
            {
                if (!lsTemp[i].IsNormal())
                {
                    if (lsTemp[i].Shop.Price <= 10000000) lsTemp[i].Shop.Price = 9999;
                    lsTemp[i].SetItemNormal(2);
                }
            }
            MessageBox.Show("Todos os itens foram ativados no shopping !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }

        private void ApagarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            var count = lsTemp.Count;
            lsTemp.RemoveRange(0, count);
            MessageBox.Show("Todos os itens foram apagados !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }

        private void shoppingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            var count = lsTemp.Count;
            for (int i = 0; i < count; i++)
            {
                if (lsTemp[i].IsNormal())
                {
                    lsTemp[i].SetItemDesativado();
                }
            }
            MessageBox.Show("Todos os itens foram desativados no shopping !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
        }

        private void pSQuareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Processing...";
            var count = lsTemp.Count;
            for (int i = 0; i < count; i++)
            {
                if (lsTemp[i].IsPSQ())
                {
                    lsTemp[i].SetItemDesativado();
                }
            }
            MessageBox.Show("Todos os itens foram desativados no shopping !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarGrid(lsTemp);
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/64";
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            this.gbTempoVenda.Enabled = this.ckTempoAtivo.Checked;

        }



        private void carregarImagem(string file, ref PictureBox obj)
        {
            try
            {
                obj.Image = Util.getImage(file);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            Alterou(sender, e);
            this.carregarImagem(this.txtIcone.Text, ref imgIcone);
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

        private void menuTypeid_Click(object sender, EventArgs e)
        {
            new DlgItemID().Show();
        }

        private void FrmCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execu\x00e7\x00e3o, \x00e9 necess\x00e1rio aguardar o t\x00e9rmino destas tarefas", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void cmbEffect0_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Error generating Effect", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                ckHot.Checked = false;
                ckDisplay.Checked = false;
                ckPSQ.Checked = false;
                ckSpecial.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckDesativado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDesativado.Checked)
            {
                ckNew.Checked = false;
                ckNormal.Checked = false;
                ckHot.Checked = false;
                ckGift.Checked = false;

                ckDisplay.Checked = false; ckPSQ.Checked = false; ckSpecial.Checked = false;
            }
        }

        private void ckDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDisplay.Checked)
            {
                ckDesativado.Checked = false;
                ckNew.Checked = false;
                ckNormal.Checked = false;
                ckHot.Checked = false;
                ckGift.Checked = false;
                ckPSQ.Checked = false;
                ckSpecial.Checked = false;
            }
        }

        private void ckHot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHot.Checked)
            {
                ckNew.Checked = false;
                ckDisplay.Checked = false;
                ckPSQ.Checked = false;
                ckSpecial.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckPSQ_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPSQ.Checked)
            {
                ckDisplay.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNormal.Checked)
            {
                ckDesativado.Checked = false;
                if (ckNew.Checked && ckHot.Checked)  //os dois não pode!
                {
                    ckNew.Checked = false;
                    ckHot.Checked = false;
                }
            }
        }

        private void BtnCreateDesc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create New Desc?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (!sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
                {
                    var desc = new Desc
                    {
                        ID = uint.Parse(txtTypeID.Text),
                        Description = "New Desc"
                    };
                    sIff.getInstance().Desc.Add(desc);     
                   sIff.getInstance().Desc.Update = true;
				   txtDesc.Text = desc.Description;
                }
            }
        }

        private void BtnApplyDesc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apply New Desc?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
                {
                    var desc = sIff.getInstance().Desc.FindIndex(c => c.ID == uint.Parse(txtTypeID.Text));
                    if (desc != -1)
                    {
                        sIff.getInstance().Desc[desc].Description = txtDesc.Text;
                        sIff.getInstance().Desc.Update = true;
                    }
                }
                else if (!sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)) && !string.IsNullOrEmpty(txtDesc.Text))
                {
                    var desc = new Desc
                    {
                        ID = uint.Parse(txtTypeID.Text),
                        Description = txtDesc.Text
                    };
                    sIff.getInstance().Desc.Add(desc);
                    sIff.getInstance().Desc.Update = true;
                }
            }
        }

        private void sQLInsertInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedCells.Count > 0)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var iff = new IFFFile<Card>
                {
                    Header = lsTemp.Header
                };
                iff.Header.Count = 0;
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    var item = lsTemp.First(c => c.ID == Conversions.ToInteger(row.Cells[0].Value));

                    iff.Add(item);
                }
                if (this.diagSalvarSql.ShowDialog() == DialogResult.OK)
                {
                    bool flag2 = this.diagSalvarSql.FileName != "";
                    var file = "";
                    if (flag2)
                    {
                        string selectedPath = this.diagSalvarSql.FileName;
                        var bw = new BackgroundWorker();
                        foreach (var item in iff)
                        {
                            file += $"INSERT INTO [pangya].[pangya_card] ([UID], [card_typeid], [QNTD], [GET_DT], [USE_DT], [END_DT], [Slot], [Efeito], [Efeito_Qntd], [card_type], [USE_YN]) VALUES('meuid', '{item.ID}', 0, CAST(N'2026-03-13T12:50:51.0000000' AS DateTime2), NULL, NULL, 0, 0, 0, 1, N'N')\n";
                        }
                        File.WriteAllText(selectedPath, file);
                        MessageBox.Show("Sucess to save file SQL!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                lbStatus.Text = "Stop";
                pbStatus.Style = ProgressBarStyle.Blocks;
            }
        }
    }
}
