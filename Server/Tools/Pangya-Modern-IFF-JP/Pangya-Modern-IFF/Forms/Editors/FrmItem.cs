using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class FrmItem : Form
    {
        bool sfile;
        public FrmItem()
        {
            InitializeComponent();
        }

        public FrmItem(IFFFile<Item> items)
        {
            InitializeComponent();
            this.lsItens = items;
            sfile = false;
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Item.iff";
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
                this.lsItens = new IFFFile<Item>();
                this.lsTemp = new IFFFile<Item>();
                this.Arquivo = this.diagAbrirArquivo.FileName;

                try
                {
                    this.lsItens = new IFFFile<Item>(Arquivo);
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
            if (Strings.Len(Arquivo) > 25)
            {
                lbArquivo.Text = "..." + Arquivo.Substring(checked(Strings.Len(Arquivo) - num), num);
            }
            else
            {
                lbArquivo.Text = Arquivo;
            }
        }

        public void CarregarGrid(List<Item> Lista)
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
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
               var item = Lista[num3];
                Image tipoImage = Resources.Disable;   //Tipo
                var item_type = 0;
                var item_type2 = 0; // hide, cookie, pangs, sale
                switch (item.GetTypeCash()) //get shop sale now !
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
                switch (item.ItemType)
                {
                    case 0:
                        item_type = 1;     //active =0
                        break;
                    case 1:
                        item_type = 2;//box
                        break;
                    case 2:
                        item_type = 3;
                        break;
                    case 4:
                        item_type = 4; //artifact
                        break;
                    case 10:
                        item_type = 5; //mana
                        break;
                    case 16:
                        item_type = 6;       //memorial
                        break;
                    case 128:
                        item_type = 7;//item gm
                        break;
                    default:
                        sIff.getInstance().Log($"[Item.iff][Unknown] => nome: {item.Name}, code: {item.ItemType}");
                        break;
                }
                int alterado = 0;

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

                table.Rows.Add(new object[] { item.ID, item.Name, item.Active ? Resources.BtnApply_Mini : Resources.BtnRemove_Mini, item_type, item_type2, tipoImage, alterado });
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
      
        public void AtualizarGrid(Item item)
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
            Image tipoImage = Resources.Disable;   //Tipo
            var item_type = 0;
            var item_type2 = 0; // hide, cookie, pangs, sale
            switch (item.GetTypeCash()) //get shop sale now !
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
            switch (item.ItemType)
            {
                case 0:
                    item_type = 1;     //active =0
                    break;
                case 1:
                    item_type = 2;//box
                    break;
                case 2:
                    item_type = 3;
                    break;
                case 4:
                    item_type = 4; //artifact
                    break;
                case 10:
                    item_type = 5; //mana
                    break;
                case 16:
                    item_type = 6;       //memorial
                    break;
                case 128:
                    item_type = 7;//item gm
                    break;
                default:
                    sIff.getInstance().Log($"[Item.iff][Unknown] => nome: {item.Name}, code: {item.ItemType}");
                    break;
            }

            var newRow = dataTable.NewRow();
            newRow["ID"] = item.ID;
            newRow["Item"] = item.Name;
            newRow["Status"] = item.Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini;
            newRow["Personagem"] = item_type;
            newRow["Status2"] = item_type2;
            newRow["Tipo"] = tipoImage;
            newRow["Alterado"] = 0;
            dataTable.Rows.Add(newRow);

            // Atualize o contador total de itens         
            lbTotalItens.Text = dataTable.Rows.Count.ToString();
            lblSearchCount.Text = dataTable.Rows.Count.ToString();
            // Ajustar colunas visíveis e largura
            ListaItem.Columns[0].Width = 45;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;

            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[5].HeaderText = "   ";

            // Garantir que a nova linha seja visível
            ListaItem.FirstDisplayedScrollingRowIndex = ListaItem.Rows.Count - 1;
            ListaItem.Rows[ListaItem.Rows.Count - 1].Selected = true;

            // Aplicar qualquer outro estilo ou filtro necessário
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
                ListaItem.Columns[0].Width = 45;
                ListaItem.Columns[2].Width = 30;
                ListaItem.Columns[5].Width = 30;
            }
        }

        public void resetFlags()
        {
            ckNormal.Checked = false;
            ckNew.Checked = false;
            ckGift.Checked = false;
            ckHot.Checked = false;
            ckDisplay.Checked = false;
            ckPSQ.Checked = false;
            ckDesativado.Checked = false;
            txtDesc.Text = "";
            this.txtEffectActive.Checked = false;
            this.txtEffectActive2.Checked = false;
            this.txtEffectActive3.Checked = false;
            this.txtEffectRate.Text = "0";
            this.txtEffectRate2.Text = "0";
            this.txtEffectRate3.Text = "0";
            this.txtFlagAbility.Text = "0";
            this.txtFlagAbility2.Text = "0";
            this.cbType.SelectedIndex = 0;
            this.cbType2.SelectedIndex = 0;
            this.cbType3.SelectedIndex = 0;
        }
        private void CarregarItem()
        {
            resetFlags();  // sempre manter assim
            if (ListaItem.SelectedCells[0].RowIndex > -1)
            {
                var selectedItem = lsTemp.First(c => c.ID == Convert.ToUInt32(ListaItem.SelectedRows[0].Cells[0].Value));
                this.lbIndices.Text = Conversions.ToString(lsTemp.FindIndex(c => c.ID == selectedItem.ID));
                txtNome.Text = selectedItem.Name;
                txtTypeID.Text = Conversions.ToString(selectedItem.ID);
                ckAtivo.Checked = selectedItem.Active;
                txtIcone.Text = selectedItem.ShopIcon;
                txtPreco.Text = Conversions.ToString(selectedItem.Price);
                txtDesconto.Text = Conversions.ToString(selectedItem.DiscountPrice);
                txtQtd.Value = new decimal(selectedItem.Stats.Power);
                if (selectedItem.Shop.flag_shop.time_shop.active)
                {
                    txtPrice1Day.Value = new decimal(selectedItem.Price1Day);
                    txtPrice7Day.Value = new decimal(selectedItem.Price7Day);
                    txtPrice15Day.Value = new decimal(selectedItem.Price15Day);
                    txtPrice30Day.Value = new decimal(selectedItem.Price30Day);
                    txtPrice365Day.Value = new decimal(selectedItem.Price365Day);
                }
                else
                {
                    txtPrice1Day.Value = 0;
                    txtPrice7Day.Value = 0;
                    txtPrice15Day.Value = 0;
                    txtPrice30Day.Value = 0;
                    txtPrice365Day.Value = 0;
                }
                txtSprite.Text = selectedItem.Model;
                txtTPItemCount.Text = selectedItem.tiki.Tiki_Qnt_Pts.ToString();
                txtTikiPts.Text = selectedItem.tiki.Tiki_Pts.ToString();
                txtMileagePts.Text = selectedItem.tiki.Mileage_Pts.ToString();
                txtBonusProb.Text = selectedItem.tiki.Bonus_Prob.ToString();
                txtBonusMin.Text = selectedItem.tiki.Bonus[0].ToString();
                txtBonusMax.Text = selectedItem.tiki.Bonus[1].ToString();
                txtTikiPang.Text = selectedItem.tiki.Tiki_Pang.ToString();
                txtTypeTikiShop.Text = selectedItem.tiki.Type_TikiShop.ToString();
                nrDay.Value = (decimal)selectedItem.Shop.flag_shop.time_shop.getDay();
                ckTimeShopActive.Checked = selectedItem.Shop.flag_shop.time_shop.active;
                if (sIff.getInstance() != null && sIff.getInstance().Desc.Any(c => c.ID == selectedItem.ID))
                {
                    var desc = sIff.getInstance().Desc.FirstOrDefault(c => c.ID == selectedItem.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
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

                switch (selectedItem.ItemType)
                {
                    case 0:
                        cbTipo2.SelectedIndex = 0;//normal
                        break;
                    case 1:
                        cbTipo2.SelectedIndex = 1;//box
                        break;
                    case 2:
                        cbTipo2.SelectedIndex = 2;//artifact
                        break;
                    case 4:
                        cbTipo2.SelectedIndex = 3;//artifact mana
                        break;
                    case 10:
                        cbTipo2.SelectedIndex = 4;//special rules
                        break;
                    case 16:
                        cbTipo2.SelectedIndex = 5; // memorial
                        break;
                    case 128:
                        cbTipo2.SelectedIndex = 6;//item gm
                        break;
                    default:
                        cbTipo2.Items.AddRange(new object[] { $"Unknown - {selectedItem.ItemType}" });
                        break;
                }
                cbTipo.SelectedIndex = selectedItem.GetTypeCash();
                dtInicio.Value = selectedItem.date.Start.Time;
                dtTermino.Value = selectedItem.date.End.Time;
                ckTempoAtivo.Checked = selectedItem.date.Check();
                ckNormal.Checked = selectedItem.IsNormal();
                ckNew.Checked = selectedItem.IsNew();
                ckGift.Checked = selectedItem.IsGiftItem();
                ckHot.Checked = selectedItem.IsHot();
                ckDisplay.Checked = selectedItem.IsOnlyDisplay();
                ckPSQ.Checked = selectedItem.IsPSQ();
                txtUnk.Text = selectedItem.Point.ToString();
                ckDesativado.Checked = selectedItem.IsHide;
                if (!ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckPSQ.Checked && !ckDesativado.Checked)
                    ckDesativado.Checked = true;
                var test = selectedItem.Shop.flag_shop.IsSpecial;

                if (sIff.getInstance() != null && sIff.getInstance().FindAbility(selectedItem.ID) != null)
                {
                    var abiltiy = sIff.getInstance().FindAbility(selectedItem.ID);
                    this.txtEffectActive.Checked = abiltiy.Efeito.EffectOrNo[0] > 0;
                    this.txtEffectActive2.Checked = abiltiy.Efeito.EffectOrNo[1] > 0;
                    this.txtEffectActive3.Checked = abiltiy.Efeito.EffectOrNo[2] > 0;
                    this.txtEffectRate.Text = abiltiy.Efeito.Rate[0].ToString();
                    this.txtEffectRate2.Text = abiltiy.Efeito.Rate[1].ToString();
                    this.txtEffectRate3.Text = abiltiy.Efeito.Rate[2].ToString();
                    this.cbType.SelectedIndex = (int)abiltiy.Efeito.Type[0];
                    this.cbType2.SelectedIndex = (int)abiltiy.Efeito.Type[1];
                    this.cbType3.SelectedIndex = (int)abiltiy.Efeito.Type[2];
                    this.txtFlagAbility.Text = abiltiy.Flag1.ToString();
                    this.txtFlagAbility2.Text = abiltiy.Flag2.ToString();
                }
            }
            Alterado = false;
        }

        private void carregarImagem(Image img, ref PictureBox obj)
        {
            try
            {
                obj.Image = Resources.ajax_loader;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            try
            {
                obj.Image = img;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                obj.Image = Resources.ErrorImage;
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
                    menuMassa.Enabled = true;//menuMassa.Active = true;
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
                    menuMassa.Enabled = true;//menuMassa.Active = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                    menuTypeid.Enabled = false;
                    menuBackup.Enabled = false;
                    menuGerarSql.Enabled = false;
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

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            var img = Util.getImage(txtIcone.Text) as Image;
            PictureBox obj = imgIcone;
            carregarImagem(img, ref obj);
            imgIcone = obj;
            Alterou(sender, e);
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
            sfile = false;
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
            int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
            lsTemp[index].Active = ckAtivo.Checked == true;
            lsTemp[index].Name = txtNome.Text;
            lsTemp[index].Shop.Price = Conversions.ToUInteger(txtPreco.Text);
            lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
            lsTemp[index].ShopIcon = txtIcone.Text;
            lsTemp[index].Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
            lsTemp[index].Stats.Power = Convert.ToByte(txtQtd.Value);
            if (ckTimeShopActive.Checked)
            {
                lsTemp[index].Price1Day = (ushort)Conversions.ToShort(txtPrice1Day.Value);
                lsTemp[index].Price7Day = (ushort)Conversions.ToShort(txtPrice7Day.Value);
                lsTemp[index].Price15Day = (ushort)Conversions.ToShort(txtPrice15Day.Value);
                lsTemp[index].Price30Day = (ushort)Conversions.ToShort(txtPrice30Day.Value);
                lsTemp[index].Price365Day = (ushort)Conversions.ToShort(txtPrice365Day.Value);
            }
            lsTemp[index].tiki.Tiki_Qnt_Pts = Convert.ToUInt32(txtTPItemCount.Text);
            lsTemp[index].tiki.Tiki_Pts = Convert.ToUInt32(txtTikiPts.Text);
            lsTemp[index].tiki.Mileage_Pts = Convert.ToUInt16(txtMileagePts.Text);
            lsTemp[index].tiki.Bonus_Prob = Convert.ToUInt16(txtBonusProb.Text);
            lsTemp[index].Point = Convert.ToUInt16(txtUnk.Text);
            lsTemp[index].tiki.Bonus[0] = Convert.ToInt16(txtBonusMin.Text);
            lsTemp[index].tiki.Bonus[1] = Convert.ToInt16(txtBonusMax.Text);
            lsTemp[index].tiki.Tiki_Pang = Convert.ToUInt32(txtTikiPang.Text);
            lsTemp[index].tiki.Type_TikiShop = Convert.ToUInt32(txtTypeTikiShop.Text);
            lsTemp[index].Shop.flag_shop.time_shop.SetDay(nrDay.Value);
            lsTemp[index].Shop.flag_shop.time_shop.active = ckTimeShopActive.Checked;
            lsTemp[index].Model = txtSprite.Text;
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
                lsTemp[index].date.active = true;
                var time = DateTime.Parse("01/01/1997 00:00");
                if (dtInicio.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) < 0)
                    lsTemp[index].date.Start = new IFFTime(dtInicio.Value);

                if (dtTermino.Value != time && DateTime.Compare(dtInicio.Value, dtTermino.Value) > 0)
                    lsTemp[index].date.End = new IFFTime(dtTermino.Value);
            }
            else
            {
                lsTemp[index].date.active = false;
                lsTemp[index].date.Clear();
            }
            uint ItemType = 0;
            switch (cbTipo2.SelectedIndex)
            {
                case 0:
                    ItemType = 0; //normal
                    break;
                case 1:
                    ItemType = 1; //box
                    break;
                case 2:
                    ItemType = 2; //artifact
                    break;
                case 3:
                    ItemType = 4; //artifact mana
                    break;
                case 4:
                    ItemType = 10; //special rules 
                    break;
                case 5:
                    ItemType = 16; //memorial gacha system 
                    break;
                case 6:
                    ItemType = 128; //item special for GM!
                    break;
                case 7: //nao tem
                    ItemType = 0;
                    break;
                case 8: //nao tem
                    ItemType = 252;
                    break;
            }

            lsTemp[index].ItemType = ItemType;
            var item = lsTemp[index];
            var check1 = item.IsNormal();
            var check2 = item.IsNew();
            var check3 = item.IsGiftItem();
            var check4 = item.IsHot();
            var check5 = item.IsOnlyDisplay();
            var check6 = item.IsPSQ();
            var check7 = lsTemp[index].IsHide;
            var check8 = item.GetTypeCash();
            if (cbTipo.SelectedIndex != check8 || ckNormal.Checked != check1 || ckNew.Checked != check2 || ckGift.Checked != check3 || ckHot.Checked != check4 || ckDisplay.Checked != check5 || ckPSQ.Checked != check6 || ckDesativado.Checked != check7)
                lsTemp[index].SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked, ckPSQ.Checked, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);

            ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
            ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            ListaItem.SelectedRows[0].Cells["ID"].Value = txtTypeID.Text;  //seta novo Index
            switch (lsTemp[index].GetTypeCash())
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
            ListaItem.SelectedRows[0].Cells["Status"].Value = lsTemp[index].Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini;
            switch (ItemType)
            {
                case 0:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 1;     //active =0
                    break;
                case 1:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 2;//box
                    break;
                case 2:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 3;//
                    break;
                case 4:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 4; //artifact
                    break;
                case 10:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 5; //mana
                    break;
                case 16:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 6; //memorial
                    break;
                case 128:
                    ListaItem.SelectedRows[0].Cells["Personagem"].Value = 7;//item gm
                    break;
            }
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
            ListaItem.Update();
            CarregarItem();

            filtrar();
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
            var copy = lsTemp[lsTemp.Count - 1].Clone() as Item;
            var item = copy;
            item.ShopIcon = "Icon Shop";
            item.Model = "mpet";
            item.Name = "New Item";
            item.GenerateID(6, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID(item.ID))
                    {
                        item.GenerateID(6, i, i);
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
        private void MenuSalvar_Click(object sender, EventArgs e)
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
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as Item;
            item.Name = "Item Clone";
            item.GenerateID(6, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (!verificarTYPEID(item.ID))
                    {
                        item.GenerateID(6, i, i);
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

        private void MenuSalvarSQL_Click(object sender, EventArgs e)
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

        private void FrmItemFormClosing(object sender, FormClosingEventArgs e)
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
            if (Operators.CompareString(Arquivo, null, TextCompare: false) == 0)
            {
                MessageBox.Show("File Invalid !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.Item_gerarSql(lsTemp, sIff.getInstance() == null ? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL Create With Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("File Write With Error !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void menuTypeid_Click(object sender, EventArgs e)
        {
            new DlgItemID().Show();
        }

        private void MenuBackup_Click(object sender, EventArgs e)
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            checked
            {
                try
                {
                    if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index = ComboBox1.SelectedIndex;
                        var index2 = ComboBox2.SelectedIndex;

                        if (index2 == 1)
                        {
                            bs.Filter = $"Item LIKE '%{txtPesquisa.Text}%' AND Personagem = {index} AND (Status2 = 2 OR Status2 = 3)";
                        }
                        else
                        {
                            bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(index) + " AND Status2 = " + Conversions.ToString(ComboBox2.SelectedIndex);
                        }
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index = ComboBox1.SelectedIndex;

                        bs.Filter = $"Item LIKE '%{txtPesquisa.Text}%' AND Personagem = {index}";
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        var index2 = ComboBox2.SelectedIndex;

                        if (index2 == 1)
                            bs.Filter = $"Item LIKE '%{txtPesquisa.Text}%' AND (Status2 = 2 OR Status2 = 3)";

                        else
                            bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(index2);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        var index = ComboBox1.SelectedIndex;
                        var index2 = ComboBox2.SelectedIndex;
                        if (index2 == 1)
                            bs.Filter = "Personagem = " + Conversions.ToString(index) + " AND (Status2 = 2 OR Status2 = 3)";
                        else
                            bs.Filter = "Personagem = " + Conversions.ToString(index) + " AND Status2 = " + Conversions.ToString(index2);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        var index = ComboBox1.SelectedIndex;
                        bs.Filter = "Personagem = " + Conversions.ToString(index);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {
                        var index2 = ComboBox2.SelectedIndex;

                        if (index2 == 1)
                            bs.Filter = $"Status2 = 2 or Status2 = 3";//code é 1
                        else
                            bs.Filter = "Status2 = " + Conversions.ToString(index2);
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

        private bool verificarTYPEID(uint typeid = 0)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0)
            {
                typeid = Conversions.ToUInteger(txtTypeID.Text);
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
                    return false;
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



        private void setItemHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedRows.Count > 1)
            {
                lastRow = ListaItem.SelectedRows[0].Index - 1;
                if (MessageBox.Show("Deseja desativa os " + Conversions.ToString(ListaItem.SelectedRows.Count) + " selected items?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
                        var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[0].Value));
                        var idx = lsTemp.FindLastIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[0].Value));
                        item.SetItemDesativado();
                        lsTemp[idx] = item;
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

        private void BtnNewAbility_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create New Ability?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (sIff.getInstance() != null && !sIff.getInstance().ItemAbility.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
                {
                    var desc = new Ability
                    {
                        ID = uint.Parse(txtTypeID.Text)
                    };
                    sIff.getInstance().ItemAbility.Add(desc);
                    sIff.getInstance().ItemAbility.Update = true;
                }
            }
        }

        private void BtnApplyAbility_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apply New Ability?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (sIff.getInstance() != null && sIff.getInstance().ItemAbility.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
                {
                    var index = sIff.getInstance().ItemAbility.FindIndex(c => c.ID == uint.Parse(txtTypeID.Text));
                    if (index != -1)
                    {
                        uint effectOrNo0 = Convert.ToUInt32(txtEffectActive.Checked);
                        uint effectOrNo1 = Convert.ToUInt32(txtEffectActive2.Checked);
                        uint effectOrNo2 = Convert.ToUInt32(txtEffectActive3.Checked);

                        float rate0 = float.Parse(txtEffectRate.Text);
                        float rate1 = float.Parse(txtEffectRate2.Text);
                        float rate2 = float.Parse(txtEffectRate3.Text);
                        uint type0 = (uint)cbType.SelectedIndex;
                        uint type1 = (uint)cbType2.SelectedIndex;
                        uint type2 = (uint)cbType3.SelectedIndex;

                        uint flag1 = uint.Parse(txtFlagAbility.Text);
                        uint flag2 = uint.Parse(txtFlagAbility2.Text);
                        Ability ability = sIff.getInstance().ItemAbility[index];
                        ability.Efeito.EffectOrNo[0] = effectOrNo0;
                        ability.Efeito.EffectOrNo[1] = effectOrNo1;
                        ability.Efeito.EffectOrNo[2] = effectOrNo2;
                        ability.ID = uint.Parse(txtTypeID.Text);
                        ability.Efeito.Rate[0] = rate0;
                        ability.Efeito.Rate[1] = rate1;
                        ability.Efeito.Rate[2] = rate2;

                        ability.Efeito.Type[0] = type0;
                        ability.Efeito.Type[1] = type1;
                        ability.Efeito.Type[2] = type2;

                        ability.Flag1 = flag1;
                        ability.Flag2 = flag2;
                        sIff.getInstance().ItemAbility[index] = ability;
                        sIff.getInstance().ItemAbility.Update = true;
                    }
                }
            }
        }


        private void ConvertS8GB_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            var iff = new IFFFile<Item>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                iff.Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / iff.Header.Count;//se for 304
                if (size == 224)
                {
                    for (int i = 0; i < iff.Header.Count; i++)
                    {
                        var item = new Item(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\GB";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Item.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Item.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Item.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var iff = new IFFFile<Item>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 224)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new Item(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\TH";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Item.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Item.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Item.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
