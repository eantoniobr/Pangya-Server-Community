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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmSetItem : Form
    {
        private bool sfile;

        public FrmSetItem()
        {
            InitializeComponent();
        }

        public FrmSetItem(IFFFile<SetItem> SetItems)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = SetItems;
        }

        private void FrmSetItem_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "SetItem.iff";
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
                this.ComboBox2.SelectedIndex = 0;
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<SetItem>();
                this.lsTemp = new IFFFile<SetItem>();
                this.Arquivo = this.diagAbrirArquivo.FileName;

                try
                {
                    this.lsItens = new IFFFile<SetItem>(Arquivo);
                }
                catch
                {
                    MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = new object();
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsItens.Count);
            }
        }

        public void CarregarGrid(List<SetItem> Lista)
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
            table.Columns.Add("Status2", typeof(int));
            table.Columns.Add("tipoImage", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
                var item = Lista[num3];
                Image tipoImage = Resources.Disable;   //tipoImage
                var item_type = 0;
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
                switch (item.TypeSet)
                {
                    case 0:
                        item_type = 0;     //active =0
                        break;
                    case 1:
                        item_type = 1;//box
                        break;
                    case 2:
                        item_type = 2;
                        break;
                    case 3:
                        item_type = 3; //artifact
                        break;
                    case 4:
                        item_type = 4; //mana
                        break;
                    case 5:
                        item_type = 5;       //memorial
                        break;
                    case 6:
                        item_type = 6;//item gm
                        break;
                    case 7:
                        item_type = 7;//item gm
                        break;
                    case 8:
                        item_type = 8;//item gm
                        break;
                    case 9:
                        item_type = 9;//item gm
                        break;
                    default:
                        sIff.getInstance().Log($"[SetItem.iff][Unknown] => nome: {item.Name}, code: {item.Point}");
                        break;
                }
                int num4 = 0;

                try
                {
                    // Obtenha o valor da célula "Alterado"
                    object alteradoCellValue = null;

                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                    {
                        alteradoCellValue = ListaItem["Alterado", num3].Value;
                    }

                    if (alteradoCellValue != null)
                    {
                        if (int.TryParse(alteradoCellValue.ToString(), out int result))
                        {
                            num4 = result;
                        }
                        else
                        {
                            // Lidar com a situação em que não é possível converter para int
                            num4 = 0; // Ou outra ação apropriada
                        }
                    }
                    else
                    {
                        // Lidar com a situação em que o valor é nulo
                        num4 = 0; // Ou outra ação apropriada
                    }
                }
                catch (Exception projectError2)
                {
                    num4 = 0;
                    ProjectData.SetProjectError(projectError2);
                    ProjectData.ClearProjectError();
                }

                table.Rows.Add(new object[] { item.ID, item.Name.Replace("\0", ""), item.Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini, item_type, item_type2, tipoImage, num4 });
            }

            ListaItem.Invoke((MethodInvoker)delegate
            {

                bs = new BindingSource
                {
                    DataSource = table
                };
                ListaItem.DataMember = table.TableName;
                ListaItem.DataSource = bs;

                lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);

                ListaItem.Columns[0].Width = 0x2d;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;

                ListaItem.Columns[0].ValueType = typeof(int);
                ListaItem.Columns[2].HeaderText = "   ";
                ListaItem.Columns[5].HeaderText = "   ";

                for (int i = 0; i < ListaItem.Rows.Count; i++)
                {
                    ListaItem.Rows[i].Selected = false;
                }

                ListaItem.Columns[3].Visible = false;
                ListaItem.Columns[4].Visible = false;
                ListaItem.Columns[6].Visible = false;

                filtrar();

                try
                {
                    if (ListaItem.Rows.Count > 0 && lastRow < ListaItem.Rows.Count)
                    {
                        ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                        ListaItem.Rows[lastRow].Selected = true;
                    }
                }
                catch (Exception)
                {
                    // Lidar com a exceção, se necessário
                }

                pintarLinhas();
            });
        }

        public void AtualizarGrid(SetItem item)
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
                    table.Columns.Add("tipoImage", typeof(Image));
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

            Image tipoImage = Resources.Disable;   //tipoImage
            var item_type = 0;
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

            switch (item.TypeSet)
            {
                case 0:
                    item_type = 0;     //active =0
                    break;
                case 1:
                    item_type = 1;//box
                    break;
                case 2:
                    item_type = 2;
                    break;
                case 3:
                    item_type = 3; //artifact
                    break;
                case 4:
                    item_type = 4; //mana
                    break;
                case 5:
                    item_type = 5;       //memorial
                    break;
                case 6:
                    item_type = 6;//item gm
                    break;
                case 7:
                    item_type = 7;//item gm
                    break;
                case 8:
                    item_type = 8;//item gm
                    break;
                case 9:
                    item_type = 9;//item gm
                    break;
                default:
                    sIff.getInstance().Log($"[SetItem.iff][Unknown] => nome: {item.Name}, code: {item.Point}");
                    break;
            }                                                                                                            

            int alterado = 0;                    

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
                newRow["Personagem"] = item_type;
                newRow["Status2"] = item_type2;
                newRow["tipoImage"] = tipoImage;
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
        public void nomeArquivo()
        {
            int num = 25;
            if (Strings.Len(Arquivo) > 25)
            {
                lbArquivo.Text = "..." + Arquivo.Substring(checked(Strings.Len(Arquivo) - num), num);
            }
            else
            {
                lbArquivo.Text = Arquivo;
            }
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
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, false))
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

        public void reset()
        {
            img_2.Image = null;
            img_3.Image = null;
            img_4.Image = null;
            img_5.Image = null;
            img_6.Image = null;
            img_7.Image = null;
            img_8.Image = null;
            img_9.Image = null;
            img_10.Image = null;
            typeid_2.Text = "0";//selectedItem.GetIDSet(1);
            typeid_3.Text = "0";//selectedItem.GetIDSet(2);
            typeid_4.Text = "0";//selectedItem.GetIDSet(3);
            typeid_5.Text = "0";//selectedItem.GetIDSet(4);
            typeid_6.Text = "0";//selectedItem.GetIDSet(5);
            typeid_7.Text = "0";//selectedItem.GetIDSet(6);
            typeid_8.Text = "0";//selectedItem.GetIDSet(7);
            typeid_9.Text = "0";//selectedItem.GetIDSet(8);
            typeid_10.Text = "0";//selectedItem.GetIDSet(9);
            qtd_2.Text = "0";//selectedItem.GetQntSet(1);
            qtd_3.Text = "0";//selectedItem.GetQntSet(2);
            qtd_4.Text = "0";//selectedItem.GetQntSet(3);
            qtd_5.Text = "0";//selectedItem.GetQntSet(4);
            qtd_6.Text = "0";//selectedItem.GetQntSet(5);
            qtd_7.Text = "0";//selectedItem.GetQntSet(6);
            qtd_8.Text = "0";//selectedItem.GetQntSet(7);
            qtd_9.Text = "0";//selectedItem.GetQntSet(8);
            qtd_10.Text = "0";//selectedItem.GetQntSet(9);
            ckNormal.Checked = false;
            ckNew.Checked = false;
            ckGift.Checked = false;
            ckHot.Checked = false;
            ckDisplay.Checked = false;
            ckDesativado.Checked = false;
            txtDesc.Text = "";
        }
        private void CarregarItem()
        {
            reset();
            if (ListaItem.SelectedRows.Count > 0)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                var selectedItem = lsTemp.First(c => c.ID == index);
                this.lbIndices.Text = Conversions.ToString(lsTemp.FindIndex(c => c.ID == index));
                if (sIff.getInstance() != null && sIff.getInstance().Desc.Any(c => c.ID == selectedItem.ID))
                {
                    var desc = sIff.getInstance().Desc.FirstOrDefault(c => c.ID == selectedItem.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
                txtNome.Text = selectedItem.Name;
                txtTypeID.Text = Conversions.ToString(selectedItem.ID);
                ckAtivo.Checked = selectedItem.Active;
                txtIcone.Text = selectedItem.ShopIcon;
                txtPreco.Text = Conversions.ToString(selectedItem.Price);
                txtDesconto.Text = Conversions.ToString(selectedItem.DiscountPrice);
                cbTipo.SelectedIndex = selectedItem.GetTypeCash();
                dtInicio.Value = selectedItem.date.Start.Time;
                dtTermino.Value = selectedItem.date.End.Time;
                ckTempoAtivo.Checked = selectedItem.date.Check();
                NumItens.Value = new decimal(selectedItem.Total);
                typeid_1.Text = selectedItem.GetIDSet(0);
                typeid_2.Text = selectedItem.GetIDSet(1);
                typeid_3.Text = selectedItem.GetIDSet(2);
                typeid_4.Text = selectedItem.GetIDSet(3);
                typeid_5.Text = selectedItem.GetIDSet(4);
                typeid_6.Text = selectedItem.GetIDSet(5);
                typeid_7.Text = selectedItem.GetIDSet(6);
                typeid_8.Text = selectedItem.GetIDSet(7);
                typeid_9.Text = selectedItem.GetIDSet(8);
                typeid_10.Text = selectedItem.GetIDSet(9);
                qtd_1.Text = selectedItem.GetQntSet(0);
                qtd_2.Text = selectedItem.GetQntSet(1);
                qtd_3.Text = selectedItem.GetQntSet(2);
                qtd_4.Text = selectedItem.GetQntSet(3);
                qtd_5.Text = selectedItem.GetQntSet(4);
                qtd_6.Text = selectedItem.GetQntSet(5);
                qtd_7.Text = selectedItem.GetQntSet(6);
                qtd_8.Text = selectedItem.GetQntSet(7);
                qtd_9.Text = selectedItem.GetQntSet(8);
                qtd_10.Text = selectedItem.GetQntSet(9);
                cbSetTipo.SelectedIndex = (int)selectedItem.TypeSet;
                cbTipo.SelectedIndex = selectedItem.GetTypeCash();
                ckNormal.Checked = selectedItem.IsNormal();
                ckNew.Checked = selectedItem.IsNew();
                ckGift.Checked = selectedItem.IsGiftItem();
                ckHot.Checked = selectedItem.IsHot();
                ckDisplay.Checked = selectedItem.IsOnlyDisplay();
                ckDesativado.Checked = selectedItem.IsHide;
                if (!ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckDesativado.Checked)
                    ckDesativado.Checked = true;
                txtUnFlag.Text = selectedItem.Point.ToString();
                if (selectedItem.Level.level <= 72)
                {

                    cbLevel.SelectedIndex = selectedItem.Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = selectedItem.Level.level - 128;
                    rbLevelMax.Checked = true;
                }
                Alterado = false;
            }
            Alterado = false;
        }

        private void carregarImagem(string local, ref PictureBox obj)
        {
            try
            {
                obj.Image = Util.getImage(local);
            }
            catch
            {
                obj.Image = Resources.NoIcon;
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
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = false;
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
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                    CarregarItem();
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/64";
            Alterou(sender, e);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox2.SelectedIndex = 0;
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
            if (ListaItem.SelectedRows.Count > 0)
            {
                int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));

                lsTemp[index].Active = ckAtivo.Checked == true;
                lsTemp[index].Name = txtNome.Text;
                lsTemp[index].Shop.Price = Conversions.ToUInteger(txtPreco.Text);
                lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
                lsTemp[index].ShopIcon = txtIcone.Text;
                lsTemp[index].Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                lsTemp[index].Total = (uint)NumItens.Value;
                lsTemp[index].SetIDSet(0, typeid_1.Text);
                lsTemp[index].SetIDSet(1, typeid_2.Text);
                lsTemp[index].SetIDSet(2, typeid_3.Text);
                lsTemp[index].SetIDSet(3, typeid_4.Text);
                lsTemp[index].SetIDSet(4, typeid_5.Text);
                lsTemp[index].SetIDSet(5, typeid_6.Text);
                lsTemp[index].SetIDSet(6, typeid_7.Text);
                lsTemp[index].SetIDSet(7, typeid_8.Text);
                lsTemp[index].SetIDSet(8, typeid_9.Text);
                lsTemp[index].SetIDSet(9, typeid_10.Text);
                lsTemp[index].SetQntSet(0, qtd_1.Text);
                lsTemp[index].SetQntSet(1, qtd_2.Text);
                lsTemp[index].SetQntSet(2, qtd_3.Text);
                lsTemp[index].SetQntSet(3, qtd_4.Text);
                lsTemp[index].SetQntSet(4, qtd_5.Text);
                lsTemp[index].SetQntSet(5, qtd_6.Text);
                lsTemp[index].SetQntSet(6, qtd_7.Text);
                lsTemp[index].SetQntSet(7, qtd_8.Text);
                lsTemp[index].SetQntSet(8, qtd_9.Text);
                lsTemp[index].SetQntSet(9, qtd_10.Text);

                var item = lsTemp[index];
                var check1 = item.IsNormal();
                var check2 = item.IsNew();
                var check3 = item.IsGiftItem();
                var check4 = item.IsHot();
                var check5 = item.IsOnlyDisplay();
                var check7 = lsTemp[index].IsHide;
                var check8 = item.GetTypeCash();
                if (cbTipo.SelectedIndex != check8 || ckNormal.Checked != check1 || ckNew.Checked != check2 || ckGift.Checked != check3 || ckHot.Checked != check4 || ckDisplay.Checked != check5 || ckDesativado.Checked != check7)
                    lsTemp[index].SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked, false, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);

                if (rbLevelMin.Checked)
                {
                    lsTemp[index].Level.level = (byte)cbLevel.SelectedIndex;
                }
                else
                {
                    lsTemp[index].Level.level = (byte)(Conversions.ToLong("&H80") + cbLevel.SelectedIndex);
                }
                if (ckTempoAtivo.Checked)
                {
                    var itemDate = lsTemp[index].date;
                    itemDate.active = true;

                    // Define a data base de forma segura (01 de Janeiro de 1997)
                    DateTime dataBase = new DateTime(1997, 1, 1, 0, 0, 0);

                    // 1. Validar e atribuir Início
                    // Se o valor for diferente da base E menor que o término
                    if (dtInicio.Value != dataBase && dtInicio.Value < dtTermino.Value)
                    {
                        itemDate.Start = new IFFTime(dtInicio.Value);
                    }

                    // 2. Validar e atribuir Término
                    // Se o valor for diferente da base E maior que o início
                    if (dtTermino.Value != dataBase && dtTermino.Value > dtInicio.Value)
                    {
                        itemDate.End = new IFFTime(dtTermino.Value);
                    }
                    else if (dtTermino.Value <= dtInicio.Value && dtTermino.Value != dataBase)
                    {
                        // Opcional: Alerta caso o usuário tente colocar o fim antes do início
                        MessageBox.Show("A data de término deve ser maior que a data de início.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    lsTemp[index].date.active = false;
                    lsTemp[index].date.Clear();
                }
                ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                ListaItem.SelectedRows[0].Cells["ID"].Value = txtTypeID.Text;  //seta novo Index
                switch (lsTemp[index].GetTypeCash())
                {
                    case 0:
                        ListaItem.SelectedRows[0].Cells["tipoImage"].Value = Resources.Disable;
                        break;
                    case 1:
                        ListaItem.SelectedRows[0].Cells["tipoImage"].Value = Resources.points;
                        break;
                    case 2:
                        ListaItem.SelectedRows[0].Cells["tipoImage"].Value = Resources.Pang;
                        break;
                }

                switch (lsTemp[index].Active)
                {
                    case false:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnRemove_Mini;
                        break;
                    case true:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnApply_Mini;
                        break;
                }
                Alterado = false;
                qtdItem = ListaItem.Rows.Count;
                CarregarItem();
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
        }

        private void gerarBarra(Control barra, object sender1, object sender2)
        {
            try
            {
                double num5 = 5.9;
                double value1 = Convert.ToDouble(sender1.GetType().GetProperty("Value").GetValue(sender1, null));
                double value2 = Convert.ToDouble(sender2.GetType().GetProperty("Value").GetValue(sender2, null));

                barra.Width = (int)((value1 + value2) * num5);
            }
            catch (Exception ex)
            {
                // Lida com a exceção, se necessário
                MessageBox.Show("An error occurred: " + ex.Message, "Pangya Modern Editor");
            }
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
            var copy = lsTemp[lsTemp.Count - 1].Clone() as SetItem;
            var item = copy;
            item.ShopIcon = "Icon Shop";
            item.Name = "New Item";
            item.GenerateID(9, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID((int)item.ID))
                    {
                        item.GenerateID(9, i, i);
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

        private void MenuSalvarComo_Click(object sender, EventArgs e)
        {
            sfile = true;
            diagSalvarArquivo.ShowDialog();
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                ComboBox2.SelectedIndex = 0;
                salvarAlteracoes();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
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
            lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as SetItem;
            item.Name = "Item Clone";
            item.GenerateID(9, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (!verificarTYPEID((int)item.ID))
                    {
                        item.GenerateID(9, i, i);
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

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
        }

        private void menuGerarSql_Click(object sender, EventArgs e)
        {
            sfile = true;
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

        private void FrmSetItemFormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
            {
                MessageBox.Show("There are tasks still running, you need to wait for these tasks to finish", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            gerarSql(backgroundWorker);
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            lbStatus.Text = "Creating File SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Value = 0;
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbStatus.Text = "stopped";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Saving...";
            salvar(backgroundWorker);
            if (backgroundWorker.CancellationPending)
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
            lbStatus.Text = "stopped";
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

        public void gerarSql(BackgroundWorker BW)
        {
            if (Operators.CompareString(Arquivo, null, false) == 0)
            {
                MessageBox.Show("File Invalid !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.SetItem_gerarSql(lsTemp, sIff.getInstance() == null ? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL Create With Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("File Write With Error !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        public void filtrar()
        {
            checked
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

                    else if ((cbSet.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index2 = cbSet.SelectedIndex;
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(index2);
                    }

                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (cbSet.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + cbSet.SelectedIndex.ToString();
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
                    lblSearchCount.Text = Conversions.ToString(bs.Count);
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
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();

            imgStatus.Image = global::Pangya_Modern_Editor.Properties.Resources.none;

        }
        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            pintarLinhas();
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

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (verificarTYPEID())
            {
                MessageBox.Show("This TYPEID is already in use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void typeid_1_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_1.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_1);
        }

        private void typeid_2_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_2.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_2);
        }

        private void typeid_3_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_3.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_3);
        }

        private void typeid_4_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_4.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_4);
        }

        private void typeid_5_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_5.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_5);
        }

        private void typeid_6_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_6.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_6);
        }

        private void typeid_7_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_7.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_7);
        }

        private void typeid_8_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_8.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_8);
        }

        private void typeid_9_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_9.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_9);
        }

        private void typeid_10_TextChanged(object sender, EventArgs e)
        {
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(typeid_10.Text));
            if (iffCommon != null)
                carregarImagem(iffCommon.ShopIcon, ref img_10);
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            carregarImagem(txtIcone.Text, ref imgIcone);
            Alterou(sender, e);
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

        private void menuTypeid_Click(object sender, EventArgs e)
        {
            new DlgSetItemID().Show();
        }

        private void sQLInsertInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void getItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGrid(lsTemp);
            ListaItem.Refresh();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ConvertS8GB_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            var iff = new IFFFile<SetItem>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 244)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new SetItem(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\GB";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\SetItem.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("SetItem.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\SetItem.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Failed to convert !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
            }
        }


        private void ConvertS8TH_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            var iff = new IFFFile<SetItem>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 244)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new SetItem(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\TH";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\SetItem.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("SetItem.iff TH convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\SetItem.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Failed to convert !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
            }
        }

        private void cbSetTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"Debug SetTipo: {sIff.getInstance().setItemSubGroupIdentify21((uint)cbSetTipo.SelectedIndex, uint.Parse(txtTypeID.Text))}");
        }

        private void cbSetTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to create a new Index from the SetType?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }

            var rnd = new Random().Next(1, 9999);
            uint NewItemTypeID = 0;
            if (true)
            {
                NewItemTypeID = sIff.getInstance().setItemSubGroupIdentify21((uint)cbSetTipo.SelectedIndex, (uint)rnd);
            }
            MessageBox.Show("Create New Index Sucess! \nVerify first you new Index before apply changes", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTypeID.Text = NewItemTypeID.ToString();
            cbSetTipo.SelectedIndex = (int)sIff.getInstance().getItemSubGroupIdentify21(NewItemTypeID);
        }

        private void BtnCreateDesc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create New Desc?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (sIff.getInstance() != null && !sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
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
                if (sIff.getInstance() != null && sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
                {
                    var desc = sIff.getInstance().Desc.FindIndex(c => c.ID == uint.Parse(txtTypeID.Text));
                    if (desc != -1)
                    {
                        sIff.getInstance().Desc[desc].Description = txtDesc.Text;
                        sIff.getInstance().Desc.Update = true;
                    }
                }
                else if (sIff.getInstance() != null && !sIff.getInstance().Desc.Any(c => c.ID == uint.Parse(txtTypeID.Text)) && !string.IsNullOrEmpty(txtDesc.Text))
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
        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                ckHot.Checked = false;
                ckDisplay.Checked = false;
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

                ckDisplay.Checked = false; ckSpecial.Checked = false;
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
                ckSpecial.Checked = false;
            }
        }

        private void ckHot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHot.Checked)
            {
                ckNew.Checked = false;
                ckDisplay.Checked = false;
                ckSpecial.Checked = false;
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
    }
}
