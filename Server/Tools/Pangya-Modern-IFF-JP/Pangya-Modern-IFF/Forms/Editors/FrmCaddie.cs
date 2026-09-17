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
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
using PangyaAPI.IFF.JP.Extensions;

namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmCaddie : Form
    {
        private bool sfile;

        public FrmCaddie()
        {
            this.bs = new BindingSource();
            InitializeComponent();
        }

        public FrmCaddie(IFFFile<Caddie> items)
        {
            this.bs = new BindingSource();
            InitializeComponent();
            this.lsItens = items;
        }

        private void FrmCaddie_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Caddie.iff";
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

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraControle, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraCurva, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraForca, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraPrecisao, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraSpin, RuntimeHelpers.GetObjectValue(sender));
        }

        private void FrmCaddies_Closing(object sender, FormClosingEventArgs e)
        {
            if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
            {
                MessageBox.Show("There are tasks still running, it is necessary to wait for these tasks to finish.", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }            

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<Caddie>();
                this.lsTemp = new IFFFile<Caddie>();
                this.Arquivo = this.diagAbrirArquivo.FileName;

                try
                {
                    this.lsItens = new IFFFile<Caddie>(Arquivo);
                }
                catch
                {
                    MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
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
			// 2. Clone the last item as a template
        if (lsTemp.Count == 0) return; // Guard clause if list is empty
		
            if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            var item = lsTemp[lsTemp.Count - 1].Clone() as Caddie;
            item.ShopIcon = "Icon Shop";
            item.Name = "New Item";
            try
            {
                for (uint i = 0; i < lsTemp.Count; i++)
                { 
			        item.GenerateID(7, i, i);
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clone the selected item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as Caddie;
            item.Name = "Item Clone";
            try
            {
				for (uint i = 0; i < lsTemp.Count; i++)
                { 
			        item.GenerateID(7, i, i);
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

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            this.SaveAlter();
            this.pintarLinhas();
        }
                     
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.bs.Filter = "";
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
            this.SaveAlter();
            this.btnSalvar.Enabled = false;
            this.ToolStrip1.Enabled = false;
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.bwSalvar.RunWorkerAsync();
        }

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (this.verificarTYPEID(0))
            {
                MessageBox.Show("This TYPEID is already in use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID available for use!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.White;
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
            this.lbStatus.Text = "stopped";
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            this.nomeArquivo();
        }

        public void CarregarGrid(List<Caddie> Lista)
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
                Image statusImage = (oIff.Active) ? Resources.BtnApply_Mini : Resources.BtnRemove_Mini;
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

                object[] values = new object[] { oIff.ID, oIff.Name, statusImage, 0, item_type2, tipoImage, alterado };

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
        public void AtualizarGrid(Caddie item)
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
            var id = 0;
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

        private void resetFlags()
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
            this.txtFlagAbility.Text = "0";
            this.txtFlagAbility2.Text = "0";
            this.cbType.SelectedIndex = 0;
            this.cbType2.SelectedIndex = 0;
            this.cbType3.SelectedIndex = 0;
        }
        private void CarregarItem()
        {
            resetFlags();  // sempre manter assim
            if (this.ListaItem.SelectedCells[0].RowIndex > -1)
            {
                var item = lsTemp.First(c=> c.ID == Convert.ToUInt32(ListaItem.SelectedRows[0].Cells[0].Value));
                if (sIff.getInstance().Desc.Any(c => c.ID == item.ID))
                {
                    var desc = sIff.getInstance().FindDesc(item.ID).Description;
                    if (!string.IsNullOrEmpty(desc))
                        txtDesc.Text = desc;
                }
                this.lbIndices.Text = Conversions.ToString(lsTemp.FindIndex(c => c.ID == item.ID));
                this.txtNome.Text = item.Name;
                this.txtTypeID.Text = Conversions.ToString(item.ID);
                this.ckAtivo.Checked = item.Active;
                this.txtIcone.Text = item.ShopIcon;
                nrDay.Value = new decimal(((int)item.Shop.flag_shop.time_shop.getDay()));
                ckTimeShopActive.Checked = item.Shop.flag_shop.time_shop.active;
                this.txtPreco.Text = Conversions.ToString(item.Price);
                this.txtDesconto.Text = Conversions.ToString(item.DiscountPrice);
                this.attForca.Value = new decimal(item.Stats.Power);
                this.attControle.Value = new decimal(item.Stats.Control);
                this.attPrecisao.Value = new decimal(item.Stats.Impact);
                this.attSpin.Value = new decimal(item.Stats.Spin);
                this.attCurva.Value = new decimal(item.Stats.Curve);
                this.txtSprite.Text = item.MPet;
                txtUn.Text = Conversions.ToString(item.Point);
                this.txtSalary.Text = Conversions.ToString(item.Salary);
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
                if (!item.Level.is_max)
                {

                    cbLevel.SelectedIndex = item.Level.level;
                    rbLevelMin.Checked = true;
                }
                else
                {
                    cbLevel.SelectedIndex = item.Level.level;
                    rbLevelMax.Checked = true;
                }

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
            this.Alterado = false;

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

                ckDisplay.Checked = false;  ckSpecial.Checked = false;
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

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            this.gbTempoVenda.Enabled = this.ckTempoAtivo.Checked;
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

        private void gerarBarra(Control Barra, object sender1)
        {
            try
            {
                double num6 = 5.9;

                // Calculando a largura da barra com base no valor fornecido
                Barra.Width = Conversions.ToInteger(Operators.MultiplyObject(
                    NewLateBinding.LateGet(sender1, null, "value", new object[0], null, null, null), num6));

            }
            catch (Exception ex)
            {
                // Lidando com exceções, se ocorrerem
                Console.WriteLine("Ocorreu uma exceção: " + ex.Message);
            }
        }


        public void gerarSql(BackgroundWorker BW)
        {
            if (this.Arquivo == null)
            {
                MessageBox.Show("Arquivo inv\x00e1lido!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (Convert.ToBoolean(Util.Caddie_gerarSql(lsTemp, sIff.getInstance() == null ? new List<Desc>() : sIff.getInstance().Desc, Arquivo, ref BW)))
            {
                MessageBox.Show("SQL Create With Sucess!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("File Write With Error !", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                this.pintarLinhas();
            }
            catch (Exception exception1)
            {
                MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);

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

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            this.pintarLinhas();
        }

        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                if (this.ListaItem.SelectedRows.Count > 1)
                {
                    menuMassa.Enabled = true;
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.btnNovo.Enabled = false;
                    this.btnBackup.Enabled = false;
                    this.btnSalvar.Enabled = false;
                    this.btnReabrir.Enabled = false;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    menuMassa.Enabled = true;
                    this.btnNovo.Enabled = true;
                    this.btnBackup.Enabled = true;
                    this.btnSalvar.Enabled = true;
                    this.btnReabrir.Enabled = true;
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = true;
                    this.txtPesquisa.Enabled = true;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                    this.CarregarItem();
                }
                else
                {
                    menuMassa.Enabled = false;
                    this.gbBotoes.Enabled = false;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.menuSalvarComo.Enabled = false;
                    this.menuTypeid.Enabled = false;
                    this.menuBackup.Enabled = false;
                    this.menuGerarSql.Enabled = false;
                }
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                if (this.verificarTYPEID(0))
                {
                    this.txtTypeID.BackColor = Color.LightSalmon;
                }
                else
                {
                    this.txtTypeID.BackColor = Color.White;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }              

        public void nomeArquivo()
        {
            int length = 0x19;
            if (Strings.Len(this.Arquivo) > 0x19)
            {
                this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
            }
            else
            {
                this.lbArquivo.Text = this.Arquivo;
            }
        }

        public void pintarLinhas()
        {
            int num2 = this.ListaItem.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", i].Value, 1, false))
                {
                    this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                }
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", i].Value, 2, false))
                {
                    this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                }
            }
            this.ListaItem.Columns[0].Width = 0x2d;
            this.ListaItem.Columns[2].Width = 30;
            this.ListaItem.Columns[5].Width = 30;
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
                    if (ListaItem.SelectedRows.Count == 1)
                    { 
                        item.Active = ckAtivo.Checked;
                        item.Name = txtNome.Text;
                        item.ID = Conversions.ToUInteger(txtTypeID.Text);
                        item.ShopIcon = txtIcone.Text;
                        item.Point = Convert.ToUInt16(txtUn.Text);
                        item.MPet = txtSprite.Text; 
                        item.Shop.Price = Conversions.ToUInteger(txtPreco.Text);
                        item.Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                        item.Salary = Convert.ToUInt16(txtSalary.Text); 
                        item.Level.level = (byte)cbLevel.SelectedIndex;
                        AtualizarStats(item);
                        AtualizarFlags(item);
                        AtualizarTikiETempo(item);
                    }
                    else
                    {   
                        AtualizarStats(item);
                        AtualizarFlags(item);
                        AtualizarTikiETempo(item); 
                    }
                    AtualizarRowInterface(row, item);
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

        private void AtualizarStats(Caddie item)
        {
            item.Stats.Power = Convert.ToByte(attForca.Value);
            item.Stats.Control = Convert.ToByte(attControle.Value);
            item.Stats.Impact = Convert.ToByte(attPrecisao.Value);
            item.Stats.Spin = Convert.ToByte(attSpin.Value);
            item.Stats.Curve = Convert.ToByte(attCurva.Value); 
        }

        private void AtualizarFlags(Caddie item)
        {
            bool mudou = (cbTipo.SelectedIndex != item.GetTypeCash() || ckNormal.Checked != item.IsNormal() ||
                          ckNew.Checked != item.IsNew() || ckDesativado.Checked != item.IsHide);
            if (mudou)
            {
                item.SetFlagShop(cbTipo.SelectedIndex, ckNew.Checked, ckHot.Checked, ckNormal.Checked,
                                 false, ckDesativado.Checked, ckDisplay.Checked, ckGift.Checked, ckSpecial.Checked);
            }
        } 

        private void AtualizarTikiETempo(Caddie item)
        { 
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
            item.Point = Convert.ToUInt16(txtUn.Text);
        }

        private void AtualizarRowInterface(DataGridViewRow row, Caddie item)
        {
            row.Cells["Alterado"].Value = 1;
            row.Cells[1].Value = item.Name;
            row.Cells["ID"].Value = item.ID;

            // Atualiza Ícone de Tipo
            switch (item.GetTypeCash())
            {
                case 1: row.Cells["Tipo"].Value = Resources.points; break;
                case 2: row.Cells["Tipo"].Value = Resources.Pang; break;
                case 3: row.Cells["Tipo"].Value = Resources.Display; break;
                default: row.Cells["Tipo"].Value = Resources.Disable; break;
            }

            // Atualiza Ícone de Status
            row.Cells["Status"].Value = (item.Active) ? Resources.BtnApply_Mini : Resources.BtnRemove_Mini;
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
                SaveAlter();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }

        private void MenuSalvarSQL_Click(object sender, EventArgs e)
        {
            diagSalvarArquivo.ShowDialog();
            this.Arquivo = this.diagSalvarSql.FileName;
            if (this.Arquivo != null)
            {
                if (File.Exists(this.Arquivo))
                {
                    File.Delete(this.Arquivo);
                }
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bwGerarSql.RunWorkerAsync();
            }
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            this.carregarImagem(this.txtIcone.Text, ref imgIcone);
            Alterou(sender, e);
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            this.lbContNome.Text = Conversions.ToString(this.txtNome.Text.Length) + "/64";
            Alterou(sender, e);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
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

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
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
                            writer.WriteLine("ID|Name|Power|Control|Impact|Spin|Curve");
                            foreach (var item in this.lsTemp)
                            {
                                writer.WriteLine($"{item.ID}|{item.Name}|{item.Stats.Power}|{item.Stats.Control}|{item.Stats.Impact}|{item.Stats.Spin}|{item.Stats.Curve}");
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
                                writer.WriteLine("ID|Name|Power|Control|Impact|Spin|Curve"); 
                                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                                {
                                    var item = this.lsTemp.FirstOrDefault(c => c.ID == Convert.ToUInt32(row.Cells[0].Value));
                                    if (item != null)
                                        writer.WriteLine($"{item.ID}|{item.Name}|{item.Stats.Power}|{item.Stats.Control}|{item.Stats.Impact}|{item.Stats.Spin}|{item.Stats.Curve}");
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
                var iff = new IFFFile<Caddie>
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
                            file += $"  INSERT INTO [pangya].[pangya_caddie_information] ([UID], [typeid], [parts_typeid], [gift_flag], [cLevel], [Exp], [RegDate], [Period], [EndDate], [RentFlag], [Purchase], [parts_EndDate], [CheckEnd], [Valid]) VALUES('meuid', '{item.ID}', 0, 0, 1, 636, CAST(N'2026-03-13T12:50:51.0000000' AS DateTime2), 30, CAST(N'2026-06-10T18:01:22.0000000' AS DateTime2), 2, 0, NULL, 1, 1)\n";
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
