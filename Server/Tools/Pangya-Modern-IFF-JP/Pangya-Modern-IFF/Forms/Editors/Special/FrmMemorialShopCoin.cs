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
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmMemorialShopCoin : Form
    {
        private bool sfile;

        public FrmMemorialShopCoin()
        {
            InitializeComponent();
        }

        public FrmMemorialShopCoin(IFFFile<MemorialShopCoinItem> coin)
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

            this.lsItens = new IFFFile<MemorialShopCoinItem>();
            this.lsTemp = new IFFFile<MemorialShopCoinItem>();
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

        public void CarregarGrid(IFFFile<MemorialShopCoinItem> Lista)
        {
            new List<string>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Status", typeof(Image));
            dataTable.Columns.Add("Personagem", typeof(string));
            dataTable.Columns.Add("Status2", typeof(string));
            dataTable.Columns.Add("Alterado", typeof(int));
            int num3 = 0;

            foreach (var oIff in Lista)
            {
                Image accept = (oIff.Active == 0) ? Properties.Resources.BtnRemove_Mini : Properties.Resources.BtnApply_Mini;
                int num6 = 0;
                try
                {
                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                        num6 = Conversions.ToInteger(ListaItem["Alterado", num3].Value);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    num6 = 0;
                    ProjectData.ClearProjectError();
                }
                var record = sIff.getInstance().FindCommonItem(oIff.ID);
                string Name = "Name Unknown";
                if (record != null)
                {
                    Name = record.Name;
                }
                dataTable.Rows.Add(num3, Name, accept, (int)oIff.ItemType, oIff.Active, num6);
                num3++;
            }
            bs = new BindingSource();
            bs.DataSource = dataTable;
            ListaItem.DataMember = dataTable.TableName;
            ListaItem.DataSource = bs;
            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
            int num7 = ListaItem.Rows.Count - 1;
            int num8 = 0;
            while (true)
            {
                int num9 = num8;
                int num5 = num7;
                if (num9 > num5)
                {
                    break;
                }
                ListaItem.Rows[num8].Selected = false;
                num8++;
            }
            organizarColunas();
            filtrar();
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
            organizarColunas();

        }

        public void organizarColunas()
        {
            this.ListaItem.Columns[0].Width = 0x2d;
            this.ListaItem.Columns[2].Width = 30;
            this.ListaItem.Columns[0].ValueType = typeof(int);
            this.ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[5].Visible = false;
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


                var record = sIff.getInstance().FindCommonItem(shoprare.ID);
                if (record != null)
                {
                    this.txtName.Text = record.Name;
                }
                ckAtivo.Checked = lsTemp[index].Active != 0 ? true : false;
                this.txtTypeID.Text = shoprare.ID.ToString();
                this.cbItemType.SelectedIndex = (int)shoprare.ItemType;
                this.cbTipoCoin.SelectedIndex = (int)shoprare.CoinType;
                this.txtProbs.Text = shoprare.Probabilities.ToString();
                this.txtCounter.Text = shoprare.gacha_range.Number_Max.ToString();
                this.txtNumber.Text = shoprare.gacha_range.Number_Min.ToString();
                this.cbCharacter.SelectedIndex = (int)shoprare.CharacterType;
                this.cbItem.SelectedIndex = (int)shoprare.Item;
                this.cbSex.SelectedIndex = (int)shoprare.Sex;
                this.cbValue.SelectedIndex = (int)shoprare.Value_1;
                carregarImagem();
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
        private void carregarImagem()
        {
            try
            {
                imgResultado.Image = sIff.getInstance() != null ? Util.getImage(sIff.getInstance().FindCommonItem(uint.Parse(txtTypeID.Text)).ShopIcon) : Resources.ajax_loader;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
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
                    tbsGenerateSql.Enabled = false;

                    btnReabrir.Enabled = false;
                    menuSalvarComo.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    tbsGenerateSql.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    tbsGenerateSql.Enabled = false;
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                }
                if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
                {
                    btnSalvar.Enabled = false;
                }
            }
            catch { }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox1.SelectedIndex = 0;
            salvarAlteracoes();
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "MemorialShopCoinItem.sff";
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
            int index = 0;
            try
            {
                index =  Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            lsTemp[index].ID = Conversions.ToUInteger(this.txtTypeID.Text);
            lsTemp[index].ItemType = (FilterType)Conversions.ToUInteger(this.cbItemType.SelectedIndex);
            lsTemp[index].CoinType = (FilterCoinType)Conversions.ToUInteger(this.cbTipoCoin.SelectedIndex);
            lsTemp[index].Sex = Conversions.ToUInteger(this.cbSex.SelectedIndex);
            lsTemp[index].Probabilities = Conversions.ToUInteger(this.txtProbs.Text);
            lsTemp[index].gacha_range.Number_Max = Conversions.ToUInteger(this.txtCounter.Text);
            lsTemp[index].gacha_range.Number_Min = (uint)Conversions.ToUInteger(this.txtNumber.Text);
            lsTemp[index].Active = (uint)Conversions.ToUInteger(this.ckAtivo.Checked);

            try
            {
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                ListaItem.SelectedRows[0].Cells["Item"].Value = txtName.Text;
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
                    MessageBox.Show(
    @"To create a new coin for the memorial, you need to:

- Create a new item with a new Index, the item must be of the ""MemorialSystem"" Type

- Add this new Index to MemorialShopCoinItem.sff

Apply the changes",
    "Instructions for Creating a New Coin",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information);
                    var coin = lsTemp.Last().Clone() as MemorialShopCoinItem;
                    if (sIff.getInstance() != null)
                    {
                        var item = sIff.getInstance().Item.First(c => c.ItemType == 16);
                        item.Name = "Item New";
                        item.ShopIcon = "Icon Shop";
                        item.GenerateID(6, 0, 0);

                        for (uint i = 0; i < sIff.getInstance().Item.Count; i++)
                        {
                            if (sIff.getInstance().Item.Any(c => c.ID == item.ID))
                            {
                                item.GenerateID(6, i, i);
                            }
                            else
                            {
                                break;
                            }
                        }
                        sIff.getInstance().Item.Add(item);

                        coin.ID = item.ID;
                    }
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
                var coin = lsTemp.Last().Clone() as MemorialShopCoinItem;
                if (sIff.getInstance() != null)
                {
                    var item = sIff.getInstance().Item.First(c => c.ItemType == 16);
                    item.Name = "Item New";
                    item.ShopIcon = "Icon Shop";
                    item.GenerateID(6, 0, 0);
                    for (uint i = 0; i < sIff.getInstance().Item.Count; i++)
                    {
                        if (sIff.getInstance().Item.Any(c => c.ID == item.ID))
                        {
                            item.GenerateID(6, i, i);
                        }
                        else
                        {
                            break;
                        }
                    }
                    sIff.getInstance().Item.Add(item);

                    coin.ID = item.ID;
                }
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


        public void filtrar()
        {
            checked
            {
                try
                {
                    int num = 0;
                    num = ((ComboBox2.SelectedIndex == 1) ? 1 : 0);
                    int num2 = -1;
                    if (ComboBox1.SelectedIndex > 0)
                    {
                        num2 = (ComboBox1.SelectedIndex - 1);
                    }
                    else if (ComboBox1.Text == "ALL")
                    {
                        num2 = -1;
                    }

                    if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(num2) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(num2);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((comboBox3.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Coin LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(num2) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(num2);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {
                        bs.Filter = "Status2 = " + Conversions.ToString(num);
                    }
                    else
                    {
                        bs.Filter = "";
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
        }


        private void FrmMemorialShopCoin_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "MemorialShopCoinItem.sff";
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
        private void menuSalvarComo_Click(object sender, EventArgs e)
        {
            sfile = true;
            diagSalvarArquivo.ShowDialog();
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                ComboBox1.SelectedIndex = 0;
                salvarAlteracoes();
                btnSalvar.Enabled = false;
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }

        private void tbsGenerateSql_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog
            {
                Title = "Save SQL Query",
                Filter = "SQL Queries (*.sql)|*.sql"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbsGenerateSql.Enabled = false;
                bwGerarSql.RunWorkerAsync();
                TextWriter textWriter;
                textWriter = new StreamWriter(saveFileDialog.FileName, append: false);
                textWriter.WriteLine("-- --- /Create By LuisMK :D --- --\r\n");
                textWriter.WriteLine("USE [pangya]");
                textWriter.WriteLine("GO\r\n");
                foreach (var item in lsTemp)
                {
                    var record = sIff.getInstance().FindCommonItem(item.ID);

                    if (record != null)
                    {
                        textWriter.WriteLine("-- Item: {0}", record.Name);
                    }
                    else
                    {
                        textWriter.WriteLine("-- Item: {0}", "Not have name");
                    }
                    var coin_type = Convert.ToInt32(item.CoinType);
                    textWriter.WriteLine("IF EXISTS ( SELECT _typeid FROM pangya.pangya_new_memorial_coin_item WHERE _typeid = {0})", item.ID);
                    textWriter.WriteLine("BEGIN");
                    textWriter.WriteLine("    UPDATE pangya.pangya_new_memorial_coin_item");
                    textWriter.WriteLine("    SET [tipo] = N'{0}'", coin_type.ToString());
                    textWriter.WriteLine("    , [_typeid] = N'{0}'", item.ID);
                    textWriter.WriteLine("    WHERE _typeid = {0}", item.ID);
                    textWriter.WriteLine("END");
                    textWriter.WriteLine("ELSE");
                    textWriter.WriteLine("BEGIN");
                    textWriter.WriteLine("    INSERT INTO pangya.pangya_new_memorial_coin_item");
                    textWriter.WriteLine("    ([tipo], [_typeid], [probabilidade])");
                    textWriter.WriteLine($"    VALUES (N'{coin_type}',N'{item.ID}',N'{item.Probabilities}')");
                    textWriter.WriteLine("END");
                }
                textWriter.WriteLine("GO");
                textWriter.Close();
                MessageBox.Show("File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbsGenerateSql.Enabled = true;
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
