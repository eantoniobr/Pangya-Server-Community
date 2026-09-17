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
    public partial class FrmMascot : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        private bool sfile;

        public FrmMascot()
        {
            bs = new BindingSource();
            InitializeComponent();
        }

        public FrmMascot(IFFFile<Mascot> items)
        {
            this.bs = new BindingSource();
            InitializeComponent();
            this.lsItens = items;
        }

        private void FrmMascot_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Mascot.iff";
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
                this.lsItens = new IFFFile<Mascot>();
                this.lsTemp = new IFFFile<Mascot>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                
                try
                {
                    this.lsItens = new IFFFile<Mascot>(Arquivo);
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

        public void CarregarGrid(List<Mascot> Lista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
                oIff = Lista[num3];
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

                table.Rows.Add(new object[] { oIff.ID, oIff.Name.Replace("\0", ""), statusImage, 0, item_type2, tipoImage, num4 });
            }

            ListaItem.Invoke((MethodInvoker)delegate
            {
                
                bs = new BindingSource();
                bs.DataSource = table;
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
                    ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                    ListaItem.Rows[lastRow].Selected = true;
                }
                catch (Exception)
                {
                    // Handle exception if needed
                }

                pintarLinhas();
            });
        }

        public void AtualizarGrid(Mascot item)
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
            var id =0;

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
                var item = lsTemp.First(c=> c.ID ==Convert.ToUInt32(ListaItem.SelectedRows[0].Cells[0].Value));
                if (sIff.getInstance() != null && sIff.getInstance().Desc.Any(c => c.ID == item.ID))
                {
                    var desc = sIff.getInstance().Desc.FirstOrDefault(c => c.ID == item.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
                txtNome.Text = item.Name;
                txtTypeID.Text = Conversions.ToString(item.ID);
                ckAtivo.Checked = item.Active;
                txtIcone.Text = item.ShopIcon;
                txtPreco.Text = Conversions.ToString(item.Shop.Price);
                txtDesconto.Text = Conversions.ToString(item.Shop.DiscountPrice);
                txtSprite1.Text = item.MPet;
                txtSprite2.Text = item.Texture1;
                txtPrice1Day.Text = Conversions.ToString((int)item.price[0]);
                txtPrice7Day.Text = Conversions.ToString((int)item.price[1]);
                txtPrice15Day.Text = Conversions.ToString((int)item.price[2]);
                txtPrice30Day.Text = Conversions.ToString((int)item.price[3]);
                txtPrice365Day.Text = Conversions.ToString((int)item.price[4]);
                Efeito_PowerDrive.Text = Conversions.ToString((int)item.efeito.power_drive);
                EfeitoGauge.Text = Conversions.ToString((int)item.efeito.power_gague);
                EfeitoDropRate.Text = Conversions.ToString((int)item.efeito.drop_rate);
                EfeitoExpRate.Text = Conversions.ToString((int)item.efeito.exp_rate);
                EfeitoPangRate.Text = Conversions.ToString((int)item.efeito.pang_rate);
                attForca.Value = new decimal(item.Power);
                attControle.Value = new decimal(item.Control);
                attPrecisao.Value = new decimal(item.Impact);
                attSpin.Value = new decimal(item.Spin);
                attCurva.Value = new decimal(item.Curve);
                txtFlagMSG.Text = Conversions.ToString((int)item.msg.flag);
                BonusPangRate.Text = Conversions.ToString((int)item.bonus_pangya.pang);
                BonusFlag.Text = Conversions.ToString((int)item.bonus_pangya.flag);
                txtChangePrice.Text = Conversions.ToString((int)item.msg.change_price);
                txtSlotItem.Text = Conversions.ToString((int)item.efeito.item_slot);
                ckActiveMSG.Checked = item.msg.active != 0;
                ckTimeShopActive.Checked = item.Shop.flag_shop.time_shop.active;
                nrDay.Value = (decimal)item.Shop.flag_shop.time_shop.getDay();
                cbTipo.SelectedIndex = item.GetTypeCash();
                dtInicio.Value = item.date.Start.Time;
                dtTermino.Value = item.date.End.Time;
                ckTempoAtivo.Checked = item.date.Check();                               
                ckNormal.Checked = item.IsNormal();
                ckNew.Checked = item.IsNew();
                ckGift.Checked = item.IsGiftItem();
                ckHot.Checked = item.IsHot();
                ckDisplay.Checked = item.IsOnlyDisplay();
                ckSpecial.Checked = item.Shop.flag_shop.IsSpecial;
                ckDesativado.Checked = item.IsHide;
                if (!ckNormal.Checked && !ckNew.Checked && !ckGift.Checked && !ckHot.Checked && !ckDisplay.Checked && !ckDesativado.Checked)
                    ckDesativado.Checked = true;
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
                if (sIff.getInstance() != null && sIff.getInstance().FindAbility(item.ID) != null)
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
                    this.txtFlag.Text = abiltiy.Flag1.ToString();
                    this.txtFlag2.Text = abiltiy.Flag2.ToString();
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
                    btnRemover.Enabled = true;
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
            var img = Util.getImage(txtIcone.Text);
            PictureBox obj = imgIcone;
            carregarImagem(img as Image, ref obj);
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
            this.bs.Filter = "";
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
            this.salvarAlteracoes();
            this.btnSalvar.Enabled = false;
            this.ToolStrip1.Enabled = false;
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.bwSalvar.RunWorkerAsync();
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
            lsTemp[index].Power = Convert.ToByte(attForca.Value);
            lsTemp[index].Control = Convert.ToByte(attControle.Value);
            lsTemp[index].Impact = Convert.ToByte(attPrecisao.Value);
            lsTemp[index].Spin = Convert.ToByte(attSpin.Value);
            lsTemp[index].Curve = Convert.ToByte(attCurva.Value);
            lsTemp[index].MPet = txtSprite1.Text;
            lsTemp[index].Texture1 = txtSprite2.Text;
            lsTemp[index].price[0] = byte.Parse(txtPrice1Day.Text);
            lsTemp[index].price[1] = byte.Parse(txtPrice7Day.Text);
            lsTemp[index].price[2] = byte.Parse(txtPrice15Day.Text);
            lsTemp[index].price[3] = byte.Parse(txtPrice30Day.Text);
            lsTemp[index].price[4] = byte.Parse(txtPrice365Day.Text);
            lsTemp[index].efeito.power_drive = byte.Parse(Efeito_PowerDrive.Text);
            lsTemp[index].efeito.power_gague = byte.Parse(EfeitoGauge.Text);
            lsTemp[index].efeito.drop_rate = byte.Parse(EfeitoDropRate.Text);
            lsTemp[index].efeito.exp_rate = byte.Parse(EfeitoExpRate.Text);
            lsTemp[index].efeito.pang_rate = byte.Parse(EfeitoPangRate.Text);
            lsTemp[index].efeito.item_slot = byte.Parse(txtSlotItem.Text);
            lsTemp[index].Power = (byte)attForca.Value;
            lsTemp[index].Control = (byte)attControle.Value;
            lsTemp[index].Impact = (byte)attPrecisao.Value;
            lsTemp[index].Spin = (byte)attSpin.Value;
            lsTemp[index].Curve = (byte)attCurva.Value;
            lsTemp[index].msg.flag = short.Parse(txtFlagMSG.Text);
            lsTemp[index].msg.active = (byte)(ckActiveMSG.Checked ? 1 : 0);
            lsTemp[index].bonus_pangya.pang = ushort.Parse(BonusPangRate.Text);
            lsTemp[index].bonus_pangya.flag = ushort.Parse(BonusFlag.Text);
            lsTemp[index].msg.change_price = ushort.Parse(txtChangePrice.Text);
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
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
            CarregarItem();
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

        private void att2Curva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }

        private void att2Spin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
        }


        private void att2Precisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
        }

        private void att2Controle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
        }

        private void att2Forca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
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
            var copy = lsTemp[lsTemp.Count - 1].Clone() as Mascot;
            var item = copy;
            item.ShopIcon = "Icon Shop";
            item.MPet = "mpet";
            item.Name = "New Item";
            item.GenerateID(16, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID(item.ID))
                    {
                        item.GenerateID(16, i, i);
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
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as Mascot;
            item.Name = "Item Clone";
            item.GenerateID(16, 0, 0);
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                {
                    if (verificarTYPEID(item.ID))
                    {
                        item.GenerateID(16, i, i);
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

        private void FrmMascotFormClosing(object sender, FormClosingEventArgs e)
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
            else if (Conversions.ToBoolean(Util.Mascot_gerarSql(lsTemp, sIff.getInstance() == null ? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
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
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
            }
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
                        Description =txtDesc.Text
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

        private void ConvertS8GB_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            var iff = new IFFFile<Mascot>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 284)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new Mascot(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\GB";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Mascot.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Mascot.iff GB convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Mascot.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var iff = new IFFFile<Mascot>();
            var _Arquivo = diagAbrirArquivo.FileName;
            try
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(_Arquivo)));
                var Header = Reader.Read<IFFHeader>();
                var size = (Reader.Size - 8L) / Header.Count;//se for 304
                if (size == 284)
                {
                    iff.Header = Header;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        var item = new Mascot(ref Reader, 40);
                        iff.Add(item);
                    }
                    var local = Directory.GetCurrentDirectory() + "\\Conversion\\TH";
                    if (!Directory.Exists(local))
                        Directory.CreateDirectory(local);

                    iff.Save(local + "\\Mascot.iff");
                    lbStatus.Text = "Stop";
                    pbStatus.Style = ProgressBarStyle.Blocks;
                    MessageBox.Show("Mascot.iff TH convert Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"save file in {local + "\\Mascot.iff"}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void sQLInsertInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ListaItem.SelectedCells.Count > 0)
            {
                pbStatus.Style = ProgressBarStyle.Marquee;
                lbStatus.Text = "Processing...";
                var iff = new IFFFile<Mascot>
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
                            file += $"INSERT INTO [pangya].[pangya_mascot_info] ([UID], [typeid], [mLevel], [mExp], [Flag], [Tipo], [RegDate], [Period], [EndDate], [Message], [IsCash], [Price], [Valid]) VALUES('meuid', '{item.ID}', 0, 0, 0, 1, CAST(N'2026-03-16T09:17:56.0000000' AS DateTime2), 4, CAST(N'2026-03-20T09:17:56.0000000' AS DateTime2), N'', '{(item.GetTypeCash() != 1 ? 0 : item.GetTypeCash()) }', 30, 1)\n";
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
