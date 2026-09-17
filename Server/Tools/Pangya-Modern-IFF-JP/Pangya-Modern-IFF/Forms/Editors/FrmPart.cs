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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmPart : Form
    {
        private bool sfile;
        uint[] motion_item = { 0x08026800, 0x08026801, 0x08026802, 0x08064800, 0x08064801, 0x08064802, 0x08064803, 0x080A2800, 0x080A2801, 0x080A2802, 0x080E4800, 0x080E4801, 0x080E4802, 0x08122800, 0x08122801, 0x08122802, 0x0816E801, 0x0816E802, 0x0816E803, 0x0816E805, 0x816E806, 0x081A4800, 0x081A4801, 0x081EA800, 0x08228800, 0x08228801, 0x08228802, 0x08228803, 0x08268800, 0x082A6800, 0x082E4800, 0x082E4801, 0x08320800, 0x08320801, 0x08320802, 0x083A4800, 0x083A4801, 0x083A4802 };
        public FrmPart()
        {
            bs = new BindingSource();
            InitializeComponent();
        }

        public FrmPart(IFFFile<Part> parts)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = parts;
            lsTemp = parts;
        }

        private void FrmPart_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Part.iff";
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
                CarregarGrid(this.lsTemp);
                this.cmbCharacter.SelectedIndex = 0;
                this.ComboBox2.SelectedIndex = 0;
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<Part>();
                this.lsTemp = new IFFFile<Part>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                try
                {
                    this.lsItens = new IFFFile<Part>(Arquivo);
                }
                catch
                {
                    MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = new object();
                CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsItens.Count);
            }
        }

        public bool IsDefaultItem(IFFCommon item)
        {
            if (item  == null)
                return false;

            for (uint i = 0; i < 24; ++i)
            {
                uint part_typeid = (((item.ID << 5 /*CharIdentify*/) | i) << 13 /*PartNum*/) | 0x8000400;
                var part_find = sIff.getInstance().findPart(part_typeid);
                if (part_find != null && part_find.ID == part_typeid) 
                    return false;
            }
            return true;
        }
        public void CarregarGrid(List<Part> Lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }

            // Cache de imagens para evitar carregamentos repetidos
            var resourcesCache = new Dictionary<string, Image>
    {
        { "BtnRemove_Mini", Resources.BtnRemove_Mini },
        { "BtnApply_Mini", Properties.Resources.BtnApply_Mini },
        { "Disable", Resources.Disable },
        { "Display", Resources.Display },
        { "Points", Resources.points },
        { "Pang", Resources.Pang }, 
        { "Rental", Resources.points }//pra ser 2
    };

            // Criação do DataTable fora do loop
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            // Adiciona as linhas ao DataTable
            var rows = Lista.Where(item=> !string.IsNullOrEmpty(item.ShopIcon)).Select((item, index) =>
     {
         // 2. Imagem de Status
         Image statusImage = (item.Active)
             ? (string.IsNullOrEmpty(item.ShopIcon) ? resourcesCache["BtnRemove_Mini"] : resourcesCache["BtnApply_Mini"])
             : resourcesCache["BtnRemove_Mini"];

         // 3. Tipo / Cash
         Image tipoImage = resourcesCache["Disable"];
         int item_type2 = 0;

         if (!(string.IsNullOrEmpty(item.ShopIcon)))
         {
             switch (item.GetTypeCash())
             {
                 case 0:
                     tipoImage = item.IsOnlyDisplay() ? resourcesCache["Display"] : resourcesCache["Disable"];
                     item_type2 = 5; // Fake
                     break;

                 case 1:
                     if (item.RentPang == 0)
                     {
                         tipoImage = item.IsOnlyDisplay() ? resourcesCache["Display"] : resourcesCache["Points"];
                         item_type2 = 3; // Fake
                     }
                     else if (item.RentPang > 0)
                     {
                         tipoImage = item.IsOnlyDisplay() ? resourcesCache["Display"] : resourcesCache["Rental"];
                         item_type2 = 4; // Fake
                     }
                     break;

                 case 2:
                     tipoImage = item.IsOnlyDisplay() ? resourcesCache["Display"] : resourcesCache["Pang"];
                     item_type2 = 2; // Fake
                     break;
             }
         }
         else
         {
             item_type2 = 6; // Fake
         }
         // 4. Checa coluna 'Alterado' no DataGridView
         int alterado = 0;
         if (ListaItem.Rows.Count > index && ListaItem["Alterado", index].Value != null)
         {
             int.TryParse(ListaItem["Alterado", index].Value.ToString(), out alterado);
         }

         // 5. Cria a DataRow preenchida e a retorna
         DataRow row = table.NewRow();
         row.ItemArray = new object[]
         {
            item.ID,
            item.Name,
            statusImage,
            item.getCharacter(true),
            item_type2,
            tipoImage,
            alterado
         };

         return row;
     });
            // Adiciona todas as linhas ao DataTable de uma vez
            foreach (var row in rows)
                table.Rows.Add(row);

            // Atualiza a fonte de dados do DataGridView
            bs = new BindingSource(table, null);
            ListaItem.DataSource = bs;

            // Configurações da interface
            ListaItem.Columns[0].Width = 45; // Use valores constantes ou configuráveis
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[5].HeaderText = "   ";
            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[6].Visible = false;

            // Rola para a última linha
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
                MessageBox.Show($"Erro ao carregar a grid: {exception.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Atualiza informações adicionais
            lbTotalItens.Text = ListaItem.Rows.Count.ToString();
            filtrar();
            PintarLinhas();
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
                        item_type2 = 5;// fake
                    }
                    else
                    {
                        item_type2 = 5;
                        tipoImage = Resources.Disable;
                    }
                    break;
                case 1:
                    if (item.RentPang > 0)
                    {
                        if (item.IsOnlyDisplay())
                        {
                            tipoImage = Resources.Display;
                            item_type2 = 4;// fake
                        }
                        else
                        {
                            item_type2 = 4;
                            tipoImage = Resources.points;
                        }
                    }
                    else
                    {
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
                newRow["Personagem"] = item.getCharacter(true);
                newRow["Status2"] = item_type2;
                newRow["Tipo"] = tipoImage;
                newRow["Alterado"] = 0;
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

            PintarLinhas();
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
            PintarLinhas();
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

        public void PintarLinhas()
        {
            // Define as cores padrão                                                              
            // Itera sobre as linhas do DataGridView
            for (int i = 0; i < ListaItem.Rows.Count; i++)
            {
                // Define a cor padrão
                ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                // Obtém o valor da célula "Alterado"
                var valorAlterado = ListaItem["Alterado", i].Value;

                // Altera a cor de fundo com base no valor da célula
                if (valorAlterado != null)
                {
                    int valor = Convert.ToInt32(valorAlterado);

                    if (valor == 1)
                    {
                        ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                }
            }
            ListaItem.Columns[0].Width = 45;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;
        }

        public void ErrorFlag(bool check)
        {
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));

            if (check && item.Price >= 10000000)
                MessageBox.Show($"\nBe careful, you activated an item, but did not change its price({item.Price})\n check this item({item.ID})", "Pangya Modern Editor");
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
            this.txtEffectActive.Checked = false;
            this.txtEffectActive2.Checked = false;
            this.txtEffectActive3.Checked = false;
            this.txtEffectRate.Text = "0";
            this.txtEffectRate2.Text = "0";
            this.txtEffectRate3.Text = "0";
            this.txtFlag.Text = "0";
            this.txtFlag2.Text = "0";
            this.cbType.SelectedIndex = 0;
            this.cbType2.SelectedIndex = 0;
            this.cbType3.SelectedIndex = 0;
        }
        private void CarregarItem()
        {
            resetFlags();  // sempre manter assim
            if (ListaItem.SelectedRows.Count > 0)
            {
                try
                {
                    int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
                    int CharacterType = (int)lsTemp[index].getCharacter(true);
                    if (sIff.getInstance() != null && sIff.getInstance().Desc.Any(c => c.ID == lsTemp[index].ID))
                    {
                        var desc = sIff.getInstance().Desc.FirstOrDefault(c => c.ID == lsTemp[index].ID).Description;
                        if (!string.IsNullOrEmpty(desc))
                            txtDesc.Text = desc;
                    }
                    this.lbIndices.Text = index.ToString();
                    txtNome.Text = lsTemp[index].Name;
                    txtTypeID.Text = Conversions.ToString(lsTemp[index].ID);
                    ckAtivo.Checked = lsTemp[index].Active;
                    txtIcone.Text = lsTemp[index].ShopIcon;
                    txtPreco.Text = Conversions.ToString(lsTemp[index].Price);
                    txtDesconto.Text = Conversions.ToString(lsTemp[index].DiscountPrice);
                    attForca.Value = new decimal(lsTemp[index].Stats.Power);
                    att2Forca.Value = new decimal(lsTemp[index].SlotStats.PowerSlot);
                    attControle.Value = new decimal(lsTemp[index].Stats.Control);
                    att2Controle.Value = new decimal(lsTemp[index].SlotStats.ControlSlot);
                    attPrecisao.Value = new decimal(lsTemp[index].Stats.Impact);
                    att2Precisao.Value = new decimal(lsTemp[index].SlotStats.ImpactSlot);
                    attSpin.Value = new decimal(lsTemp[index].Stats.Spin);
                    att2Spin.Value = new decimal(lsTemp[index].SlotStats.SpinSlot);
                    attCurva.Value = new decimal(lsTemp[index].Stats.Curve);
                    att2Curva.Value = new decimal(lsTemp[index].SlotStats.CurveSlot);
                    ckSlotCaddie.Checked = Convert.ToBoolean(lsTemp[index]._CardSlot.CaddieSlot);
                    ckSlotCharacter.Checked = Convert.ToBoolean(lsTemp[index]._CardSlot.CharSlot);
                    ckSlotNPC.Checked = Convert.ToBoolean(lsTemp[index]._CardSlot.NPCSlot);
                    txtSubParte1.Text = Conversions.ToString(lsTemp[index].SubPart[0]);
                    txtSubParte2.Text = Conversions.ToString(lsTemp[index].SubPart[1]);
                    txtTextura1.Text = lsTemp[index].Texture1;
                    txtTextura2.Text = lsTemp[index].Texture2;
                    txtTextura3.Text = lsTemp[index].Texture3;
                    txtTextura4.Text = lsTemp[index].Texture4;
                    txtTextura5.Text = lsTemp[index].Texture5;
                    txtTextura6.Text = lsTemp[index].Texture6;
                    txtPos.Text = lsTemp[index].PosMask.ToString();
                    txtHide.Text = lsTemp[index].HideMask.ToString();
                    txtModelo.Text = lsTemp[index].MPet;
                    cbTipo.SelectedIndex = lsTemp[index].GetTypeCash();
                    ckRental.Checked = lsTemp[index].RentPang > 0;
                    txtRentValue.Text = lsTemp[index].RentPang.ToString();
                    dtInicio.Value = lsTemp[index].date.Start.Time;
                    dtTermino.Value = lsTemp[index].date.End.Time;
                    ckTempoAtivo.Checked = lsTemp[index].date.Check();
                    ckNormal.Checked = lsTemp[index].IsNormal();
                    ckNew.Checked = lsTemp[index].IsNew();
                    ckGift.Checked = lsTemp[index].IsGiftItem();
                    ckHot.Checked = lsTemp[index].IsHot();
                    ckDisplay.Checked = lsTemp[index].IsOnlyDisplay();
                    ckPSQ.Checked = lsTemp[index].IsPSQ();
                    ckDesativado.Checked = lsTemp[index].IsHide;
                    nrDay.Value = (decimal)lsTemp[index].Shop.flag_shop.time_shop.getDay();
                    ckTimeShopActive.Checked = lsTemp[index].Shop.flag_shop.time_shop.active;
                    txtPoints.Text = lsTemp[index].Points.ToString();
                    txtUn.Text = lsTemp[index].Unk.ToString();
                    if (!ckPSQ.Checked && !ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckDesativado.Checked)
                    {
                        ckDesativado.Checked = true;
                    }
                    else
                    {
                        if (ckDesativado.Checked && lsTemp[index].IsPSQ())
                        {
                            ckDesativado.Checked = false;
                            ckPSQ.Checked = lsTemp[index].IsPSQ();
                        }
                    }
                    if (ckRental.Checked && ckNew.Checked)
                    {
                        ckNew.Checked = false;
                    }
                    if (ckRental.Checked && ckPSQ.Checked)
                    {
                        ErrorFlag(true);
                    }
                    if (ckNew.Checked && ckHot.Checked)
                    {
                        if (lsTemp[index].IsHot())
                        {
                            ckNew.Checked = false;
                        }
                    }
                    ckTikiActived.Checked = lsTemp[index].tiki.IsActived();
                    cbRarity.SelectedIndex = (int)lsTemp[index].tiki.Type_TikiShop;
                    txtTPItemCount.Text = lsTemp[index].tiki.Tiki_Qnt_Pts.ToString();
                    txtTikiPts.Text = lsTemp[index].tiki.Tiki_Pts.ToString();
                    txtMileagePts.Text = lsTemp[index].tiki.Mileage_Pts.ToString();
                    txtBonusProb.Text = lsTemp[index].tiki.Bonus_Prob.ToString();
                    txtBonusMin.Text = lsTemp[index].tiki.Bonus[0].ToString();
                    txtBonusMax.Text = lsTemp[index].tiki.Bonus[1].ToString();
                    txtTikiPang.Text = lsTemp[index].tiki.Tiki_Pang.ToString();
                    txtTypeTikiShop.Text = lsTemp[index].tiki.Type_TikiShop.ToString();
                    txtAddWith.Text = lsTemp[index].addWith;
                    if (lsTemp[index].Level.level <= 72)
                    {

                        cbLevel.SelectedIndex = lsTemp[index].Level.level;
                        rbLevelMin.Checked = true;
                    }
                    else
                    {
                        cbLevel.SelectedIndex = lsTemp[index].Level.level - 128;
                        rbLevelMax.Checked = true;
                    }
                    int itemType = (int)lsTemp[index].type_item;
                    if (itemType > 7)
                    {
                        Debug.WriteLine("Part(itemType): " + itemType);
                        cbCategoria.SelectedIndex = unchecked((int)lsTemp[index].type_item) - 2;
                    }
                    else if (unchecked(itemType < 6 && itemType < 7))
                    {
                        cbCategoria.SelectedIndex = (int)lsTemp[index].type_item;
                    }
                    else
                    {
                        cbCategoria.SelectedIndex = -1;
                    }

                    Alterado = false;
                    try
                    {
                        if (cmbCharacter.SelectedIndex != 0 || cmbCharacter.SelectedIndex != -1)
                        {

                            imgPersonagem.Image = ImageList1.Images[CharacterType];
                            imgPersonagem.SizeMode = PictureBoxSizeMode.CenterImage;
                            imgPersonagem2.Image = ImageList1.Images[CharacterType];
                            imgPersonagem2.SizeMode = PictureBoxSizeMode.CenterImage;
                        }

                    }
                    catch (Exception projectError2)
                    {
                        ProjectData.SetProjectError(projectError2);
                        imgPersonagem2.Image = ImageList1.Images[0];
                        imgPersonagem.Image = ImageList1.Images[0];
                        ProjectData.ClearProjectError();
                    }
                    if (sIff.getInstance() != null && sIff.getInstance().FindAbility(lsTemp[index].ID) != null)
                    {
                        var abiltiy = sIff.getInstance().FindAbility(lsTemp[index].ID);
                        this.txtEffectActive.Checked = abiltiy.Efeito.EffectOrNo[0] > 0;
                        this.txtEffectActive2.Checked = abiltiy.Efeito.EffectOrNo[1] > 0;
                        this.txtEffectActive3.Checked = abiltiy.Efeito.EffectOrNo[2] > 0;
                        this.txtEffectRate.Text = abiltiy.Efeito.Rate[0].ToString();
                        this.txtEffectRate2.Text = abiltiy.Efeito.Rate[1].ToString();
                        this.txtEffectRate3.Text = abiltiy.Efeito.Rate[2].ToString();
                        this.cbType.SelectedIndex = (int)abiltiy.Efeito.Type[0];
                        this.cbType2.SelectedIndex = (int)abiltiy.Efeito.Type[1];
                        this.cbType3.SelectedIndex = (int)abiltiy.Efeito.Type[2];
                        this.txtFlag.Text = abiltiy.Flag1.ToString();
                        this.txtFlag2.Text = abiltiy.Flag2.ToString();
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    imgPersonagem2.Image = ImageList1.Images[0];
                    imgPersonagem.Image = ImageList1.Images[0];
                    ProjectData.ClearProjectError();
                }
            }

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
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;//menuMassa.Active = true;
                    //menuDividir.Active = true;
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
                                             // menuDividir.Active = true;
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

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            var img = Util.getImage(txtIcone.Text);
            PictureBox obj = imgIcone;
            carregarImagem(img as Image, ref obj);
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
            cmbCharacter.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            SaveAlter();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            SaveAlter();
            PintarLinhas();
        }

        private void SaveAlter()
        {
            if (ListaItem.SelectedRows.Count == 0) return;

            // Aviso para evitar sobreposição acidental em massa
            if (ListaItem.SelectedRows.Count > 1)
            {
                var confirm = MessageBox.Show($"Você selecionou {ListaItem.SelectedRows.Count} itens. " +
                    "As alterações de Stats, Desconto e Flags serão aplicadas a TODOS. Deseja continuar?",
                    "Aviso de Edição em Massa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            try
            {
                ListaItem.SuspendLayout();

                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(row.Cells[0].Value));
                    if (index == -1 && lsTemp.Count > index) continue;

                    var item = lsTemp[index];
                    if (!motion_item.Any(c=> c == item.ID))
                    {
                        if (ListaItem.SelectedRows.Count == 1)
                        {
                            // 1. Lógica de Aluguel (Rental)
                            AtualizarRental(item);
                            item.Name = txtNome.Text;
                            item.ID = Conversions.ToUInteger(txtTypeID.Text);
                            item.ShopIcon = txtIcone.Text;
                        }
                        else
                        {
                            if (item.RentPang > 0)
                            {
                                txtRentValue.Text = "0";
                                item.RentPang = 0;
                            }
                            item.SetFlagShop(2, ckNew.Checked, false,true, false, false, false, false, false);

                            //AtualizarRental(item);
                            item.Active = ckAtivo.Checked;
                            item.Shop.Price = item.Shop.Price * 80;
                            item.Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                            //AtualizarStats(item);
                           // AtualizarFlags(item);
                            //AtualizarTikiETempo(item);

                        }
                        AtualizarRowInterface(row, item);
                    }
                }

                Alterado = false;
                qtdItem = ListaItem.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
            finally
            {
                ListaItem.ResumeLayout();
                MessageBox.Show("Alterações aplicadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CarregarItem();
        }

        // --- MÉTODOS AUXILIARES PARA ORGANIZAÇÃO ---

        private void AtualizarStats(Part item)
        {
            item.Stats.Power = Convert.ToByte(attForca.Value);
            item.Stats.Control = Convert.ToByte(attControle.Value);
            item.Stats.Impact = Convert.ToByte(attPrecisao.Value);
            item.Stats.Spin = Convert.ToByte(attSpin.Value);
            item.Stats.Curve = Convert.ToByte(attCurva.Value);

            item.SlotStats.PowerSlot = Convert.ToByte(att2Forca.Value);
            item.SlotStats.ControlSlot = Convert.ToByte(att2Controle.Value);
            item.SlotStats.ImpactSlot = Convert.ToByte(att2Precisao.Value);
            item.SlotStats.SpinSlot = Convert.ToByte(att2Spin.Value);
            item.SlotStats.CurveSlot = Convert.ToByte(att2Curva.Value);
        }

        private void AtualizarFlags(Part item)
        {
            bool mudou = (cbTipo.SelectedIndex != item.GetTypeCash() || ckNormal.Checked != item.IsNormal() ||
                          ckNew.Checked != item.IsNew() || ckDesativado.Checked != item.IsHide);
            if (mudou)
            {
                item.SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked,
                                 ckPSQ.Checked, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);
            }
        }

        private void AtualizarRental(Part item)
        {
            if (ckRental.Checked)
            {
                var ispsq = item.Shop.flag_shop.ShopFlag == ShopFlag.BannerNew && item.Shop.flag_shop.MoneyFlag == MoneyFlag.None;

                // Lógica anti-bug do seu código original
                if (!item.IsNormal() && !item.IsNew() && !item.IsGiftItem() && !item.IsHot() && !item.IsOnlyDisplay() && ispsq)
                {
                    item.RentPang = 0;
                }
                else
                {
                    uint novoValorRent = (uint)Conversions.ToLong(txtRentValue.Text);
                    if (item.RentPang != novoValorRent)
                        item.RentPang = novoValorRent;
                }
            }
            else
            {
                item.RentPang = (uint)Conversions.ToLong(txtRentValue.Text);
            }
        }

        private void AtualizarTikiETempo(Part item)
        {
            // Tiki Shop e Bonus
            item.tiki.Tiki_Qnt_Pts = Convert.ToUInt32(txtTPItemCount.Text);
            item.tiki.Tiki_Pts = Convert.ToUInt32(txtTikiPts.Text);
            item.tiki.Mileage_Pts = Convert.ToUInt16(txtMileagePts.Text);
            item.tiki.Bonus_Prob = Convert.ToUInt16(txtBonusProb.Text);
            item.tiki.Bonus[0] = Convert.ToInt16(txtBonusMin.Text);
            item.tiki.Bonus[1] = Convert.ToInt16(txtBonusMax.Text);
            item.tiki.Tiki_Pang = Convert.ToUInt32(txtTikiPang.Text);

            // Rarity / Type Tiki
            uint typeTikiTxt = Convert.ToUInt32(txtTypeTikiShop.Text);
            if (typeTikiTxt != item.tiki.Type_TikiShop)
                item.tiki.Type_TikiShop = typeTikiTxt;
            else
                item.tiki.Type_TikiShop = (uint)cbRarity.SelectedIndex;

            // Card Slots
            item._CardSlot.CaddieSlot = Convert.ToUInt16(ckSlotCaddie.Checked);
            item._CardSlot.CharSlot = Convert.ToUInt16(ckSlotCharacter.Checked);
            item._CardSlot.NPCSlot = Convert.ToUInt16(ckSlotNPC.Checked);

            // Tempo de Loja (Time Shop)
            item.Shop.flag_shop.time_shop.SetDay(nrDay.Value);
            item.Shop.flag_shop.time_shop.active = ckTimeShopActive.Checked;

            // Validade do Item (Data)
            if (ckTempoAtivo.Checked)
            {
                item.date.active = true;
                DateTime dataBase = new DateTime(1997, 1, 1, 0, 0, 0);

                if (dtInicio.Value != dataBase && dtInicio.Value < dtTermino.Value)
                    item.date.Start = new IFFTime(dtInicio.Value);

                if (dtTermino.Value != dataBase && dtTermino.Value > dtInicio.Value)
                    item.date.End = new IFFTime(dtTermino.Value);
            }
            else
            {
                item.date.active = false;
                item.date.Clear();
            }

            // Outros campos genéricos
            item.Points = Convert.ToUInt16(txtPoints.Text);
            item.Unk = Convert.ToUInt32(txtUn.Text);
        }

        private void AtualizarRowInterface(DataGridViewRow row, Part item)
        {
            row.Cells["Alterado"].Value = 1;
            row.Cells[1].Value = item.Name;
            row.Cells["ID"].Value = item.ID;

            // Atualiza Ícone de Tipo
            switch (item.GetTypeCash())
            {
                case 1: row.Cells["Tipo"].Value = Resources.points; break;
                case 2: row.Cells["Tipo"].Value = Resources.Pang; break;
                default: row.Cells["Tipo"].Value = Resources.Disable; break;
            }

            // Atualiza Ícone de Status
            row.Cells["Status"].Value = (item.Active) ? Resources.BtnApply_Mini : Resources.BtnRemove_Mini;
        }

        private void Alterou(object sender, EventArgs e)
        {
            if (sender is TextBox)
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

        private void att2Curva_ValueChanged(object sender, EventArgs e)
        {
            Alterou(sender, e);
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), att2Curva);
            Alterou(sender, e);
        }

        private void att2Spin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
            Alterou(sender, e);
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), att2Spin);
            Alterou(sender, e);
        }

        private void att2Precisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
            Alterou(sender, e);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), att2Precisao);
            Alterou(sender, e);
        }

        private void att2Controle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
            Alterou(sender, e);
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), att2Controle);
            Alterou(sender, e);
        }

        private void att2Forca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
            Alterou(sender, e);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), att2Forca);
            Alterou(sender, e);
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
            var item = lsTemp[lsTemp.Count - 1].Clone() as Part;
            item.ShopIcon = "Icon Shop";
            item.Name = "New Item";
            item.GenerateID(2, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID(item.ID))
                    {
                        item.GenerateID(2, i, i);
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
            if (Operators.CompareString(Arquivo, null, false) != 0)
            {
                bs.Filter = "";
                cmbCharacter.SelectedIndex = 0;
                ComboBox2.SelectedIndex = 0;
                SaveAlter();
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
                    SaveAlter();
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
            var item = (Part)lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value))._Clone();

            item.Name = "Item Clone";
            item.GenerateID(2, item.CharacterType, 1, (uint)cbCategoria.SelectedIndex, 1);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (!verificarTYPEID(item.ID))
                    {
                        item.GenerateID(2, item.CharacterType, i, (uint)cbCategoria.SelectedIndex, 1);
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
            //mais rapido agora?
            AtualizarGrid(item);
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
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

        private void FrmPartFormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(Arquivo))
            {
                MessageBox.Show("File Invalid !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Conversions.ToBoolean(Util.Part_gerarSql(lsTemp, sIff.getInstance() == null ? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            if (cmbCharacter.SelectedIndex < 15)
            {
                var _img = ImageList1.Images[cmbCharacter.SelectedIndex];
                imgPersonagem.Image = _img;
            }
        }

        public void filtrar()
        {
            try
            {
                List<string> conditions = new List<string>();

                int charIdx = cmbCharacter.SelectedIndex;
                int typeIdx = ComboBox2.SelectedIndex;
                string searchText = txtPesquisa.Text.Trim();

                // 1. Filtro por Personagem
                if (charIdx > 0)
                {
                    if (charIdx == 15) // Exemplo: Homens
                    {
                        conditions.Add("(Personagem = 12 OR Personagem = 8 OR Personagem = 5 OR Personagem = 3 OR Personagem = 1)");
                    }
                    else if (charIdx == 16) // Exemplo: Mulheres
                    {
                        conditions.Add("(Personagem = 14 OR Personagem = 13 OR Personagem = 11 OR Personagem = 10 OR Personagem = 9 OR Personagem = 7 OR Personagem = 6 OR Personagem = 4 OR Personagem = 2)");
                    }
                    else
                    {
                        conditions.Add($"Personagem = {charIdx}");
                    }
                }

                // 2. Filtro por Tipo/Moeda (ComboBox2)
                if (typeIdx > 0)
                {
                    switch (typeIdx)
                    {
                        case 1: // Active
                            conditions.Add("(Status2 = '2' OR Status2 = '3')");
                            break;
                        case 6: // NoIcon (Mapeado para Status2 = 0 ou valor sem ícone)
                            conditions.Add("Status2 = '6'");
                            break;
                        case 7: // NoIcon (Mapeado para Status2 = 0 ou valor com ícone)
                            conditions.Add("Status2 = '7'");
                            break;
                        default: // Pangs (2), Points (3), Rental (4), Hide (5)
                            conditions.Add($"Status2 = '{typeIdx}'");
                            break;
                    }
                }

                // 3. Filtro por Pesquisa (Texto ou ID)
                if (!string.IsNullOrEmpty(searchText))
                {
                    if (uint.TryParse(searchText, out uint searchId))
                    {
                        // Pesquisa Numérica (Procura por ID exato ou contido)
                        conditions.Add($"(ID = {searchId} OR CONVERT(ID, 'System.String') LIKE '%{searchId}%')");
                    }
                    else
                    {
                        // Pesquisa por Texto (Escape de caracteres especiais da DataView)
                        string escapedTerm = searchText
                            .Replace("'", "''")
                            .Replace("[", "[[]")
                            .Replace("%", "[%]")
                            .Replace("_", "[_]");

                        conditions.Add($"Item LIKE '%{escapedTerm}%'");
                    }
                }

                // Unifica todas as condições com AND
                string finalFilter = string.Join(" AND ", conditions);
                bs.Filter = finalFilter;

                // Se nenhum resultado for encontrado, reseta os filtros
                if (bs.Count == 0 && (charIdx > 0 || typeIdx > 0 || !string.IsNullOrEmpty(searchText)))
                {
                    bs.Filter = "";
                    cmbCharacter.SelectedIndex = 0;
                    ComboBox2.SelectedIndex = 0;
                    txtPesquisa.Clear();
                }

                // Atualização dos visuais
                lblSearchCount.Text = bs.Count.ToString();

                if (ListaItem.Columns.Count >= 6)
                {
                    ListaItem.Columns[0].Width = 45;
                    ListaItem.Columns[2].Width = 30;
                    ListaItem.Columns[5].Width = 30;
                    ListaItem.Columns[0].ValueType = typeof(int);
                    ListaItem.Columns[2].HeaderText = "   ";
                    ListaItem.Columns[5].HeaderText = "   ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar dados: {ex.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            switch (ComboBox2.SelectedIndex)
            {
                case 1:
                    imgStatus.Image = Resources.BtnApply;
                    break;
                case 2:
                    imgStatus.Image = Resources.none;
                    break;
                case 3:
                    imgStatus.Image = Resources.none;
                    break;
                case 4:
                    imgStatus.Image = Resources.none;
                    break;
                default:
                    imgStatus.Image = Resources.none;
                    break;
            }
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            PintarLinhas();
        }

        private bool verificarTYPEID(uint typeid = 0)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0 && !string.IsNullOrEmpty(txtTypeID.Text))
            {
                typeid = Conversions.ToUInteger(this.txtTypeID.Text);
            }
            else
            {
                flag = true;
            }
            foreach (var item in lsTemp)
            {
                if (item.ID == typeid)
                {
                    num++;
                }
            }
            if (flag)
            {
                return num >= 1;
            }
            return num > 1;
        }

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (verificarTYPEID())
            {
                MessageBox.Show("TYPEID available for use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("This TYPEID is already in use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.LightSalmon;
                if (MessageBox.Show("Deseja criar um novo Index?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var frm = new DlgItemID();
                    frm.Show();
                }
            }
        }

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            PintarLinhas();
        }

        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                PintarLinhas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void DividirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.diagPasta.ShowDialog() == DialogResult.OK)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                bool flag2 = this.diagPasta.SelectedPath != "";
                if (flag2)
                {
                    IFFFile<Part> itens = new IFFFile<Part>();
                    IFFFile<Part> list2 = new IFFFile<Part>();
                    IFFFile<Part> list3 = new IFFFile<Part>();
                    IFFFile<Part> list4 = new IFFFile<Part>();
                    IFFFile<Part> list5 = new IFFFile<Part>();
                    IFFFile<Part> list6 = new IFFFile<Part>();
                    IFFFile<Part> list7 = new IFFFile<Part>();
                    IFFFile<Part> list8 = new IFFFile<Part>();
                    IFFFile<Part> list9 = new IFFFile<Part>();
                    IFFFile<Part> list10 = new IFFFile<Part>();
                    IFFFile<Part> list11 = new IFFFile<Part>();
                    IFFFile<Part> list12 = new IFFFile<Part>();
                    IFFFile<Part> list13 = new IFFFile<Part>();
                    IFFFile<Part> list14 = new IFFFile<Part>();

                    string selectedPath = this.diagPasta.SelectedPath;
                    try
                    {
                        int num5;
                        using (List<Part>.Enumerator enumerator = this.lsTemp.GetEnumerator())
                        {
                            while (true)
                            {
                                flag2 = enumerator.MoveNext();
                                if (!flag2)
                                {
                                    break;
                                }
                                Part current = enumerator.Current;
                                num5 = (int)current.CharacterType;
                                switch (num5)
                                {
                                    case 0:
                                        {
                                            itens.Add(current);
                                            continue;
                                        }
                                    case 1:
                                        {
                                            list2.Add(current);
                                            continue;
                                        }
                                    case 2:
                                        {
                                            list3.Add(current);
                                            continue;
                                        }
                                    case 3:
                                        {
                                            list4.Add(current);
                                            continue;
                                        }
                                    case 4:
                                        {
                                            list5.Add(current);
                                            continue;
                                        }
                                    case 5:
                                        {
                                            list6.Add(current);
                                            continue;
                                        }
                                    case 6:
                                        {
                                            list7.Add(current);
                                            continue;
                                        }
                                    case 7:
                                        {
                                            list8.Add(current);
                                            continue;
                                        }
                                    case 8:
                                        {
                                            list9.Add(current);
                                            continue;
                                        }
                                    case 9:
                                        {
                                            list10.Add(current);
                                            continue;
                                        }
                                    case 10:
                                        {
                                            list10.Add(current);
                                            continue;
                                        }
                                    case 11:
                                        {
                                            list11.Add(current);
                                            continue;
                                        }
                                    case 12:
                                        {
                                            list12.Add(current);
                                            continue;
                                        }
                                    case 13:
                                        {
                                            continue;
                                        }
                                    case 14:
                                        {
                                            list14.Add(current);
                                            continue;
                                        }
                                }
                            }
                        }
                        int num2 = 0;
                        while (true)
                        {
                            switch (num2)
                            {
                                case 0:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(itens as IFFFile<Part>, itens.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", itens[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 1:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list2 as IFFFile<Part>, list2.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list2[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 2:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list3 as IFFFile<Part>, list3.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list3[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 3:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list4 as IFFFile<Part>, list4.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list4[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 4:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list5 as IFFFile<Part>, list5.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list5[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 5:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list6 as IFFFile<Part>, list6.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list6[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 6:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list7 as IFFFile<Part>, list7.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list7[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 7:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list8 as IFFFile<Part>, list8.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list8[0].getCharacterNome()), "_Part.iff")));
                                    break;

                                case 8:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list9 as IFFFile<Part>, list9.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list9[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                case 9:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list10 as IFFFile<Part>, list10.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                case 10:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list11 as IFFFile<Part>, list11.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                case 11:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list12 as IFFFile<Part>, list12.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                case 12:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list13 as IFFFile<Part>, list10.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                case 13:
                                    Util.gravarArquivoDividido((byte[])Util.setValuesDividido(list14 as IFFFile<Part>, list10.Count), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((selectedPath + @"\") + Conversions.ToString(num2) + "_", list10[0].getCharacterNome()), "_Part.iff")));
                                    break;
                                default:
                                    break;
                            }
                            num2++;
                            num5 = 14;
                            if (num2 > num5)
                            {
                                if (MessageBox.Show("Arquivo dividido com sucesso, deseja vizualizar a pasta?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    Process.Start(selectedPath);
                                }
                                break;
                            }
                        }
                        pbStatus.Style = ProgressBarStyle.Blocks;
                        pbStatus.Value = 0;
                        lbStatus.Text = "Stop";
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        MessageBox.Show("Error splitting file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ProjectData.ClearProjectError();
                    }
                }
            }

        }

        private void UnirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.diagPasta.ShowDialog() == DialogResult.OK)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                bool flag2 = this.diagPasta.SelectedPath != "";
                if (flag2)
                {
                    try
                    {
                        this.lsItens = new IFFFile<Part>();
                        string selectedPath = this.diagPasta.SelectedPath;
                        int num = 0;
                        this.qtdItem = 0L;
                        string[] files = Directory.GetFiles(selectedPath);
                        int index = 0;
                        string[] strArray = new string[2];
                        while (true)
                        {
                            flag2 = index < files.Length;
                            if (!flag2)
                            {
                                this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                                int length = 0x19;
                                this.Arquivo = selectedPath + @"\" + strArray[2];
                                this.lbArquivo.Text = (Strings.Len(this.Arquivo) <= length) ? this.Arquivo : ("..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length));

                                this.CarregarGrid(this.lsTemp);
                                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
                                break;
                            }
                            string path = files[index];
                            if (Path.GetExtension(path) == ".iff")
                            {
                                strArray = Path.GetFileName(path).Split(new char[] { '_' });
                                long qtd = num;
                                num = (int)qtd;
                                lsItens.Load(File.ReadAllBytes(path));
                                this.qtdItem += num;
                            }
                            index++;
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception ex = exception1;
                        ProjectData.SetProjectError(ex);
                        Exception exception = ex;
                        MessageBox.Show("Error splitting file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ProjectData.ClearProjectError();
                    }
                }

                pbStatus.Style = ProgressBarStyle.Blocks;
                pbStatus.Value = 0;
                lbStatus.Text = "stopped";
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
                            MessageBox.Show($"Unable to convert '{idStr}' to an integer (Index).", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid format in line: '{line}'", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                lbStatus.Text = "Stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while pasting the data: " + ex.Message, "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lbStatus.Text = "Stop";
            PintarLinhas();
        }

        private void menuTypeid_Click(object sender, EventArgs e)
        {
            new DlgItemID().Show();
        }

        private void ApagarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedCells.Count > 0)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var iff = new IFFFile<Part>
                {
                    Header = lsTemp.Header
                };
                iff.Header.Count = 0;
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    var item = lsTemp.First(c => c.ID == Conversions.ToInteger(row.Cells[0].Value));

                    iff.Add(item);
                }
                if (this.diagSalvarArquivo.ShowDialog() == DialogResult.OK)
                {
                    bool flag2 = this.diagSalvarArquivo.FileName != "";
                    if (flag2)
                    {
                        string selectedPath = this.diagSalvarArquivo.FileName;
                        iff.Save(selectedPath);
                    }
                }
                lbStatus.Text = "Stop";
                pbStatus.Style = ProgressBarStyle.Blocks;
            }
        }

        private void sQLInsertInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedCells.Count > 0)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var iff = new IFFFile<Part>
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
                            file += $"INSERT INTO pangya.pangya_item_warehouse(UID, typeid, valid, regdate, Gift_flag, flag, C0, Purchase, ItemType) VALUES('meuid', '{item.ID}', 1, getdate(), '0', 0, 1, 0, 2)\n";
                        }
                        File.WriteAllText(selectedPath, file);
                        MessageBox.Show("Sucess to save file SQL!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                lbStatus.Text = "Stop";
                pbStatus.Style = ProgressBarStyle.Blocks;
            }
        }

        private void getItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Count = lsTemp.Where(c => c.IsPSQ() == true).ToList().Count;
            if (Count > 0)
            {
                CarregarGrid(lsTemp.Where(c => c.IsPSQ() == true).ToList());
                ListaItem.Refresh();
            }
            else
            {
                MessageBox.Show("Pang Modern IFF", "Get Item Shop Active no Found ");
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarGrid(lsTemp);
            ListaItem.Refresh();
        }

        private void cSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export to CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (MessageBox.Show("Do you want to save everyone?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("ID,Name");
                            foreach (var lang in this.lsTemp)
                            {
                                if (sIff.getInstance().ItemDef(lang.CharacterType, lang.ID))
                                    writer.WriteLine($"{lang.ID},{lang.Name}");
                            }
                        }
                    }
                    else
                    {
                        if (ListaItem.SelectedCells.Count > 0)
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                            {
                                writer.WriteLine("ID,Name");

                                ListaItem.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                                // Itera sobre as células selecionadas
                                writer.WriteLine("ID,Name");

                                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                                {
                                    writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value}");
                                }
                            }
                        }
                    }
                    MessageBox.Show("Data exported to CSV successfully!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ckSpecial_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"Test Prodution", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConvertS8GB_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            var iff = new IFFFile<Part>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                iff.Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / iff.Header.Count;//se for 304
                if (size == 544)
                {
                    for (int i = 0; i < iff.Header.Count; i++)
                    {
                        var item = new Part(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\GB";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Part.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Part.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Part.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var iff = new IFFFile<Part>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 544)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new Part(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\TH";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Part.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Part.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Part.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                ckDisplay.Checked = false;
                ckPSQ.Checked = false;
                ckSpecial.Checked = false;
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

        private void ckAtivo_CheckedChanged(object sender, EventArgs e)
        {
            Alterou(sender, e);
        }

        private void ckSlotCaddie_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSlotCaddie.Checked)
            {
                ckSlotCharacter.Checked = false;
                ckSlotNPC.Checked = false;
            }
        }

        private void ckSlotCharacter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSlotCharacter.Checked)
            {
                ckSlotCaddie.Checked = false;
                ckSlotNPC.Checked = false;
            }
        }

        private void ckSlotNPC_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSlotNPC.Checked)
            {
                ckSlotCaddie.Checked = false;
                ckSlotCharacter.Checked = false;
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

        private void txtPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHide_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListaItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarItem();
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

                        uint flag1 = uint.Parse(txtFlag.Text);
                        uint flag2 = uint.Parse(txtFlag2.Text);
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

        private void addIFFFileToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                var temp = new IFFFile<Part>();
                try
                {
                    temp = new IFFFile<Part>(this.diagAbrirArquivo.FileName);
                    lsItens.AddRange(temp.ToArray());
                    MessageBox.Show("Sucess add new file");
                }
                catch
                {
                    MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = new object();
                CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem = lsItens.Count);
            }
        }
    }
}
