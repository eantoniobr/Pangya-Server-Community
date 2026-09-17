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
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }

        public FrmClub(IFFFile<Club> Clubs)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = Clubs;
        }

        private void FrmClub_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Club.iff";
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
                this.lsItens = new IFFFile<Club>();
                this.lsTemp = new IFFFile<Club>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                
                try
                {
                    this.lsItens = new IFFFile<Club>(Arquivo);
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

        public void CarregarGrid(IFFFile<Club> Lista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(int));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            table.Columns.Add("IDX", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
                oIff = Lista[num3];
                Image tipoImage = Resources.Disable;   //Tipo
                var item_type = 0;
                var item_type2 = 0;
                item_type2 = 4;
                tipoImage = Resources.Disable;
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


                table.Rows.Add(new object[] { oIff.ID, oIff.Name, oIff.Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini, item_type, item_type2, tipoImage, num4, num3 });
            }

            ListaItem.Invoke((MethodInvoker)delegate
            {
                // Efficient DataSource update
                ListaItem.SuspendLayout(); // Suspend layout to improve performance
                
                bs = new BindingSource(table, null);
                ListaItem.DataSource = bs;

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
                ListaItem.Columns[7].Visible = false;

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
                }                 // Resume layout
                ListaItem.ResumeLayout();
                lbTotalItens.Text = ListaItem.Rows.Count.ToString();
                filtrar();
                pintarLinhas();
            });
        }

        public void AtualizarGrid(Club item)
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
            // Verifique se a linha com o ID já existe
            var existingRow = dataTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ID") == item.ID);

            if (existingRow == null)
            {
                // Adicione uma nova linha se a linha não existir   
                dataTable.Rows.Add(new object[] {
                    item.ID, item.Name,
                    item.Active ? Properties.Resources.BtnApply_Mini : Properties.Resources.BtnRemove_Mini,
                    0, item_type2, tipoImage, alterado, 0 });
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
        private void CarregarItem()
        {
            if (ListaItem.SelectedRows.Count > 0)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value);
                var selectedItem = lsTemp[index];
                this.lbIndices.Text = index.ToString();         
                txtNome.Text = selectedItem.Name;
                txtTypeID.Text = selectedItem.ID.ToString();
                ckAtivo.Checked = selectedItem.Active;
                txtIcone.Text = selectedItem.ShopIcon;
                txtPreco.Text = selectedItem.Shop.Price.ToString();
                txtDesconto.Text = selectedItem.Shop.DiscountPrice.ToString();
                attForca.Value = selectedItem.Stats.Power;
                attControle.Value = selectedItem.Stats.Control;
                attPrecisao.Value = selectedItem.Stats.Impact;
                attSpin.Value = selectedItem.Stats.Spin;
                attCurva.Value = selectedItem.Stats.Curve;
                txtModel.Text = selectedItem.MPet;
                cbClub.SelectedIndex = selectedItem.ClubType;
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
                    menuTypeid.Enabled = true;
                    CarregarItem();
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
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value);
                lsTemp[index].Active = this.ckAtivo.Checked;
                lsTemp[index].Name = txtNome.Text;
                lsTemp[index].Shop.Price = Conversions.ToUInteger(txtPreco.Text);
                lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
                lsTemp[index].ShopIcon = txtIcone.Text;
                lsTemp[index].Shop.DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                lsTemp[index].Stats.Power = Convert.ToUInt16(attForca.Value);
                lsTemp[index].Stats.Control = Convert.ToUInt16(attControle.Value);
                lsTemp[index].Stats.Impact = Convert.ToUInt16(attPrecisao.Value);
                lsTemp[index].Stats.Spin = Convert.ToUInt16(attSpin.Value);
                lsTemp[index].Stats.Curve = Convert.ToUInt16(attCurva.Value);
                lsTemp[index].ClubType = Conversions.ToUShort(cbClub.SelectedIndex);
                lsTemp[index].MPet = txtModel.Text;
                switch (lsTemp[index].Active)
                {
                    case false:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnRemove_Mini;
                        break;
                    case true:
                        ListaItem.SelectedRows[0].Cells["Status"].Value = Resources.BtnApply_Mini;
                        break;
                }

                ListaItem.SelectedRows[0].Cells["Item"].Value = txtNome.Text;
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
             }
            else
            {
                foreach (DataGridViewRow row in ListaItem.SelectedRows)
                {
                    int num = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value);
                    this.lsTemp[num].Active = ckAtivo.Checked;
                    if (lsTemp[num].Shop.Price != Convert.ToUInt32(txtPreco.Text))
                    {
                        lsTemp[num].Shop.Price = Convert.ToUInt32(txtPreco.Text);
                    }
                    if (lsTemp[num].Shop.DiscountPrice != Convert.ToUInt32(txtDesconto.Text))
                    {
                        lsTemp[num].Shop.DiscountPrice = Convert.ToUInt32(txtDesconto.Text);
                    }
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
            if (Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value) > 0) CarregarItem();
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

            var item = lsTemp.Last().Clone() as Club;
            for (ushort c = 0; c < 4; c++)
            {
                try
                {                                 
                    item.ClubType = c;
                    item.Name = $"New Club Item {c}";
                    item.ShopIcon = $"icon_club_{c}";
                    item.ID++; //avança para o proximo
                    lsTemp.Add(item);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
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
            if (MessageBox.Show("want to copy the complete set?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (ushort c = 0; c < 4; c++)
                {
                    var item = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value)].Clone() as Club;
                    item.GenerateID(3, 0, 0);
                    item.ClubType = c;
                    try
                    {
                        for (uint i = 0; i < lsTemp.Count; i++)
                        {
                            if (!verificarTYPEID(item.ID))
                            {
                                item.GenerateID(3, i, i);
                            }
                            else
                            {
                                break;
                            }
                        }
                        lsTemp.Add(item);
                        AtualizarGrid(item);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        ProjectData.ClearProjectError();
                    }
                }
            }
            else
            {
                var item = lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[7].Value)].Clone() as Club;
                item.GenerateID(3, 0, 0);
                try
                {
                    for (uint i = 0; i < lsTemp.Count; i++)
                    {
                        if (verificarTYPEID(item.ID))
                        {
                            item.GenerateID(3, i, i);
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
                    ProjectData.ClearProjectError();
                }
            }
        }            

        private void FrmClubFormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwSalvar.IsBusy)
            {
                MessageBox.Show("There are tasks still running, you need to wait for these tasks to finish", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
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
    }
}
