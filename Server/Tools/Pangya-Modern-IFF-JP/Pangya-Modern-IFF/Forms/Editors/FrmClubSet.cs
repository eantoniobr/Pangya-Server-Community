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
using System.Runtime.InteropServices;
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
using static PangyaAPI.IFF.JP.Models.Data.GrandPrixData;

namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmClubSet : Form
    {
        public FrmClubSet()
        {
            InitializeComponent();
        }

        public FrmClubSet(IFFFile<ClubSet> ClubSets)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = ClubSets;
        }

        private void FrmClubSet_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "ClubSet.iff";
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
            // this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<ClubSet>();
                this.lsTemp = new IFFFile<ClubSet>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                
                try
                {
                    this.lsItens = new IFFFile<ClubSet>(Arquivo);
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

        public void CarregarGrid(IFFFile<ClubSet> Lista)
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
                oIff = Lista[num3];
                Image tipoImage = Resources.Disable;   //Tipo
                var item_type = 0;
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

                table.Rows.Add(new object[] { oIff.ID, oIff.Name.Replace("\0", ""), oIff.Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini, item_type, item_type2, tipoImage, num4 });
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
                    if (lastRow < ListaItem.Rows.Count)
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
        public void AtualizarGrid(ClubSet item)
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
                newRow["Personagem"] = 0;
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
        if (ListaItem.SelectedRows.Count > 0)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                var item = lsTemp.First(c => c.ID == index);
                this.lbIndices.Text = Conversions.ToString(lsTemp.FindIndex(c => c.ID == index));

                txtNome.Text = item.Name;
                txtTypeID.Text = item.ID.ToString();
                ckAtivo.Checked = item.Active;
                txtIcone.Text = item.ShopIcon;
                txtPreco.Text = item.Shop.Price.ToString();
                txtDesconto.Text = item.Shop.DiscountPrice.ToString();
                attForca.Value = item.Stats.Power;
                att2Forca.Value = item.SlotStats.PowerSlot;
                att2Controle.Value = item.SlotStats.ControlSlot;
                attControle.Value = item.Stats.Control;
                att2Precisao.Value = item.SlotStats.ImpactSlot;
                attPrecisao.Value = item.Stats.Impact;
                att2Spin.Value = item.SlotStats.SpinSlot;
                attSpin.Value = item.Stats.Spin;
                att2Curva.Value = item.SlotStats.CurveSlot;
                attCurva.Value = item.Stats.Curve;
                txtWood.Text = item.Clubs.Wood.ToString();
                txtIron.Text = item.Clubs.Iron.ToString();
                txtWedge.Text = item.Clubs.Wedge.ToString();
                txtPutter.Text = item.Clubs.Putter.ToString();
                txtTotalRecovery.Text = item.total_recovery.ToString();
                txtRate.Text = item.Rate.ToString();
               cbRankType.SelectedIndex = (int)item.Rank_WorkShop;
                cbRankSlot.SelectedIndex =(int) item.rank_s_stat;
                txtFlag.Text = item. flag_transformar.ToString();
                txtSkinClub.Text = item.text_pangya.ToString();
                txtUn.Text = item.ulUnknown.ToString();
                setWorkType(item.ClubType);
                if (sIff.getInstance().Desc.Any(c => c.ID == item.ID))
                {
                    var desc = sIff.getInstance().FindDesc(item.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
                if (item.Level.level <= 72)
                {

                    cbLevel.SelectedIndex = item.Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = item.Level.level - 128;
                    rbLevelMax.Checked = true;
                }
                cbTipo.SelectedIndex = item.GetTypeCash();
                dtInicio.Value = item.date.Start.Time;
                dtTermino.Value = item.date.End.Time;
                ckTempoAtivo.Checked = item.date.Check();
                ckNormal.Checked = item.IsNormal();
                ckNew.Checked = item.IsNew();
                ckGift.Checked = item.IsGiftItem();
                ckHot.Checked = item.IsHot();
                ckPSQ.Checked = item.IsPSQ();
                ckDisplay.Checked = item.IsOnlyDisplay();
                ckSpecial.Checked = item.Shop.flag_shop.IsSpecial;
                ckDesativado.Checked = item.IsHide;
                if (!ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckPSQ.Checked && !ckDesativado.Checked)
                    ckDesativado.Checked = true;
                 ckTimeShopActive.Checked = item.Shop.flag_shop.time_shop.active;
                nrDay.Value = item.Shop.flag_shop.time_shop.getDay();
                ckSpecial.Checked = item.Shop.flag_shop.IsSpecial;

                if (sIff.getInstance().FindAbility(item.ID) != null)
                {
                    var abiltiy = sIff.getInstance().FindAbility(item.ID);
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
                obj.Image = Resources.bg_transparent;
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
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuMassa.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                    menuBackup.Enabled = false;
                    menuGerarSql.Enabled = false;
                }    
                if (ListaItem.SelectedRows.Count > 1 && verificarTYPEID())
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
                // Get stack trace for the exception with source file information
                var st = new StackTrace(projectError, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            var img = Util.getImage(txtIcone.Text);
            PictureBox obj = imgIcone;
            carregarImagem(img, ref obj);
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
            if (ListaItem.SelectedRows.Count == 1)
            {
                int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value));
                lsTemp[index].Active = (this.ckAtivo.Checked);  
                lsTemp[index].Name = txtNome.Text;
                lsTemp[index].Shop.Price = Conversions.ToUInteger(txtPreco.Text);
                lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
                lsTemp[index].ShopIcon = txtIcone.Text;
                lsTemp[index].Shop.flag_shop.time_shop.active = ckTimeShopActive.Checked;
                lsTemp[index].Shop.flag_shop.time_shop.SetDay(nrDay.Value);
                lsTemp[index].Level.level = (byte)cbLevel.SelectedIndex;
                lsTemp[index].Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                lsTemp[index].Stats.Power = Convert.ToUInt16(attForca.Value);
                lsTemp[index].Stats.Control = Convert.ToUInt16(attControle.Value);
                lsTemp[index].Stats.Impact = Convert.ToUInt16(attPrecisao.Value);
                lsTemp[index].Stats.Spin = Convert.ToUInt16(attSpin.Value);
                lsTemp[index].Stats.Curve = Convert.ToUInt16(attCurva.Value);
                lsTemp[index].SlotStats.PowerSlot = Convert.ToUInt16(att2Forca.Value);
                lsTemp[index].SlotStats.ControlSlot = Convert.ToUInt16(att2Controle.Value);
                lsTemp[index].SlotStats.ImpactSlot = Convert.ToUInt16(att2Precisao.Value);
                lsTemp[index].SlotStats.SpinSlot = Convert.ToUInt16(att2Spin.Value);
                lsTemp[index].SlotStats.CurveSlot = Convert.ToUInt16(att2Curva.Value);
                lsTemp[index].Clubs.Wood = Conversions.ToUInteger(txtWood.Text);
                lsTemp[index].Clubs.Iron = Conversions.ToUInteger(txtIron.Text);
                lsTemp[index].Clubs.Putter = Conversions.ToUInteger(txtPutter.Text);
                lsTemp[index].Clubs.Wedge = Conversions.ToUInteger(txtWedge.Text);
                lsTemp[index].ClubType = getWorkType();
                lsTemp[index].total_recovery = uint.Parse(txtTotalRecovery.Text);
                lsTemp[index].Rate = float.Parse(txtRate.Text);
                lsTemp[index]. flag_transformar = ushort.Parse(txtFlag.Text);      
                lsTemp[index].rank_s_stat = (uint)cbRankSlot.SelectedIndex;
                lsTemp[index].Rank_WorkShop = (uint)cbRankType.SelectedIndex;
                 lsTemp[index].text_pangya = uint.Parse(txtSkinClub.Text);
                lsTemp[index].ulUnknown = uint.Parse(txtUn.Text);
                var item = lsTemp[index];
                var check1 = item.IsNormal();
                var check2 = item.IsNew();
                var check3 = item.IsGiftItem();
                var check4 = item.IsHot();
                var check5 = item.IsOnlyDisplay();
                var check6 = item.IsPSQ();
                var check7 = item.IsHide;
                var check8 = item.GetTypeCash(); 
                if (cbTipo.SelectedIndex != check8 || ckPSQ.Checked != check6 || ckNormal.Checked != check1 || ckNew.Checked != check2 || ckGift.Checked != check3 || ckHot.Checked != check4 || ckDisplay.Checked != check5 || ckDesativado.Checked != check7)
                    lsTemp[index].SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked, ckPSQ.Checked, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);

                lsTemp[index].Shop.flag_shop.time_shop.active = ckTimeShopActive.Checked;
                lsTemp[index].Shop.flag_shop.time_shop.SetDay(nrDay.Value);
                if (rbLevelMin.Checked)
                {
                    lsTemp[index].Level.level = Convert.ToByte(cbLevel.SelectedIndex);
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
                this.ListaItem.SelectedRows[0].Cells[1].Value = this.txtNome.Text;
                this.ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
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

                switch (lsTemp[index].Active)
                {
                    case false:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnRemove_Mini;
                        break;
                    case true:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnApply_Mini;
                        break;
                }
            }
            else
            {
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int num = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(row.Cells[0].Value));
                    this.lsTemp[num].Active = this.ckAtivo.Checked;    

                    if (lsTemp[num].Shop.DiscountPrice != Convert.ToUInt32(txtDesconto.Text))
                    {
                        lsTemp[num].Shop.DiscountPrice = Convert.ToUInt32(txtDesconto.Text);
                    }
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
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
            if (Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value) > 0) CarregarItem();
        }

        private void att2Curva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), att2Curva);
        }

        private void att2Spin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), att2Spin);
        }

        private void att2Precisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), att2Precisao);
        }

        private void att2Controle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), att2Controle);
        }

        private void att2Forca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), att2Forca);
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

            var item = lsTemp[lsTemp.Count - 1].Clone() as ClubSet;
            item.Name = "New Item";
            item.ShopIcon = "icon_club";                     
            try
            {     
                 for (uint i = 0; i < lsTemp.Count; i++)
                { 
			        item.GenerateID(4, i, i);
                    if (lsTemp.Count(c => c.ID == item.ID) == 0) 
                    {
                        break;
                    }
                }
                item.Clubs.Iron = 0;
                item.Clubs.Wood = 0;
                item.Clubs.Putter = 0;
                item.Clubs.Wedge = 0;
                lsTemp.Add(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                 ProjectData.ClearProjectError();
            }
            lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
            AtualizarGrid(item);
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
            var item = lsTemp.FirstOrDefault(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as ClubSet;
            item.Name = "Item Clone";
            try
            { 
				for (uint i = 0; i < lsTemp.Count; i++)
                { 
			        item.GenerateID(4, i, i);
                    if (lsTemp.Count(c => c.ID == item.ID) == 0) 
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

        private void FrmClubSetFormClosing(object sender, FormClosingEventArgs e)
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
            else if (Conversions.ToBoolean(Util.ClubSet_gerarSql(lsTemp, sIff.getInstance() == null? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL Create With Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("File Write With Error !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
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

        private void BtnWood_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance() != null)
            {     
                if (sIff.getInstance().Club.Any(c=> c.ID == uint.Parse(txtWood.Text)))
                {
                    var iffclub = sIff.getInstance().Club.Where(c => c.ID == uint.Parse(txtWood.Text));
                    if (iffclub.Count() > 1)
                    {
                        MessageBox.Show("Club Wood Index Duplication", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var club = iffclub.First();
                        var img = Util.getImage(club.ShopIcon);
                        PictureBox obj = imgIcone;
                        carregarImagem(img as Image, ref obj);
                        tabForm.SelectedIndex = 0;
                    }
                }
            }
        }

        private void BtnIron_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance() != null)
            {
                if (sIff.getInstance().Club.Any(c => c.ID == uint.Parse(txtIron.Text)))
                {
                    var iffclub = sIff.getInstance().Club.Where(c => c.ID == uint.Parse(txtIron.Text));
                    if (iffclub.Count() > 1)
                    {
                        MessageBox.Show("Club Iron Index Duplication", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var club = iffclub.First();
                        var img = Util.getImage(club.ShopIcon);
                        PictureBox obj = imgIcone;
                        carregarImagem(img as Image, ref obj);
                        tabForm.SelectedIndex = 0;
                    }
                }
            }
        }

        private void BtnWedge_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance() != null)
            {
                if (sIff.getInstance().Club.Any(c => c.ID == uint.Parse(txtWedge.Text)))
                {
                    var iffclub = sIff.getInstance().Club.Where(c => c.ID == uint.Parse(txtWedge.Text));
                    if (iffclub.Count() > 1)
                    {
                        MessageBox.Show("Club Wedge Index Duplication", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var club = iffclub.First();
                        var img = Util.getImage(club.ShopIcon);
                        PictureBox obj = imgIcone;
                        carregarImagem(img as Image, ref obj);
                        tabForm.SelectedIndex = 0;
                    }
                }
            }
        }

        private void BtnPutter_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance() != null)
            {
                if (sIff.getInstance().Club.Any(c => c.ID == uint.Parse(txtPutter.Text)))
                {
                    var iffclub = sIff.getInstance().Club.Where(c => c.ID == uint.Parse(txtPutter.Text));
                    if (iffclub.Count() > 1)
                    {
                        MessageBox.Show("Club Puttter Index Duplication", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var club = iffclub.First();
                        var img = Util.getImage(club.ShopIcon);
                        PictureBox obj = imgIcone;
                        carregarImagem(img as Image, ref obj);
                        tabForm.SelectedIndex = 0;
                    }
                }
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

        public void setWorkType(uint type)
        {
            switch (type)
            {
                case 4294967295:
                    cbWorkType.SelectedIndex = 5;
                    break;
                case 0:      
                case 1:       
                case 2:        
                case 3:         
                case 4:
                    cbWorkType.SelectedIndex = (int)type;
                    break;
                default:
                    break;
            }
        }

        public uint getWorkType()
        {
            return cbWorkType.SelectedIndex != 5 ? Convert.ToUInt32(cbWorkType.SelectedIndex) : 4294967295;
        }

        private void BtnNewAbility_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create New Ability?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (!sIff.getInstance().ItemAbility.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
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
                if (sIff.getInstance().ItemAbility.Any(c => c.ID == uint.Parse(txtTypeID.Text)))
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

                        ability.Efeito.Rate[0] = rate0;
                        ability.Efeito.Rate[1] = rate1;
                        ability.Efeito.Rate[2] = rate2;

                        ability.Efeito.Type[0] = type0;
                        ability.Efeito.Type[1] = type1;
                        ability.Efeito.Type[2] = type2;

                        ability.Flag1 = flag1;
                        ability.Flag2 = flag2;
                        ability.ID = uint.Parse(txtTypeID.Text); 
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
            var iff = new IFFFile<ClubSet>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                iff.Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / iff.Header.Count;//se for 304
                if (size == 236)
                {
                    iff.Header.Version = 13;
                    for (int i = 0; i < iff.Header.Count; i++)
                    {
                        var item = new ClubSet(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\GB";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\ClubSet.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("ClubSet.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\ClubSet.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var iff = new IFFFile<ClubSet>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 236)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new ClubSet(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\TH";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\ClubSet.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("ClubSet.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\ClubSet.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            writer.WriteLine("ID|Name|Power|Control|Impact|Spin|Curve|PowerSlot|ControlSlot|ImpactSlot|SpinSlot|CurveSlot");
                            foreach (var item in this.lsTemp)
                            {
                                writer.WriteLine($"{item.ID}|{item.Name}|{item.Stats.Power}|{item.Stats.Control}|{item.Stats.Impact}|{item.Stats.Spin}|{item.Stats.Curve}|{item.SlotStats.PowerSlot}|{item.SlotStats.ControlSlot}|{item.SlotStats.ImpactSlot}|{item.SlotStats.SpinSlot}|{item.SlotStats.CurveSlot}");
                            }
                        }
                    }
                    else
                    {
                        if (ListaItem.SelectedCells.Count > 0)
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                            {
                                ListaItem.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                                // Itera sobre as células selecionadas
                                writer.WriteLine("ID|Name|Power|Control|Impact|Spin|Curve|PowerSlot|ControlSlot|ImpactSlot|SpinSlot|CurveSlot");
                                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                                {
                                    var item = this.lsTemp.FirstOrDefault(c => c.ID == Convert.ToUInt32(row.Cells[0].Value));
                                    if (item != null)
                                        writer.WriteLine($"{item.ID}|{item.Name}|{item.Stats.Power}|{item.Stats.Control}|{item.Stats.Impact}|{item.Stats.Spin}|{item.Stats.Curve}|{item.SlotStats.PowerSlot}|{item.SlotStats.ControlSlot}|{item.SlotStats.ImpactSlot}|{item.SlotStats.SpinSlot}|{item.SlotStats.CurveSlot}");
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

        private void sQLInsertInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ListaItem.SelectedCells.Count > 0)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var iff = new IFFFile<ClubSet>
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
    }
}
