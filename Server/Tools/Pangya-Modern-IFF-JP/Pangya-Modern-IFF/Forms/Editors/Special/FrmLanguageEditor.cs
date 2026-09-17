using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmLanguageEditor : Form
    {
        public IFF_REGION RegionSelected = IFF_REGION.Default;
        public FrmLanguageEditor()
        {
            InitializeComponent();
            menuSalvarComo.Enabled = false;
            BtnSaveExcel.Enabled = false;
            btnAbrirArquivo.Enabled = false;
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            lsTemp = new Language();
            Arquivo = diagAbrirArquivo.FileName;
            try
            {
                lsTemp.LoadFile(Arquivo, RegionSelected);
                qtdItem = lsTemp.Count;
                nomeArquivo();
                ListaItem.DataSource = null;
                CarregarGrid(lsTemp);
                lbIndices.Text = Conversions.ToString(qtdItem);
                menuSalvarComo.Enabled = true;
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
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
        public void CarregarGrid(Language Lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Alterado", typeof(int));
            var num3 = 0;
            foreach (var item in Lista)
            {
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

                object[] values = new object[] { item.ID, item.Line, alterado };

                table.Rows.Add(values);
                num3++;
            }
            ListaItem.Invoke((MethodInvoker)delegate
            {

                bs = new BindingSource(table, null);
                ListaItem.DataSource = bs;
                lbTotalItens.Text = ListaItem.Rows.Count.ToString();

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

        public void organizarColunas()
        {
            ListaItem.Columns[1].Width = 45;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[1].ValueType = typeof(string);
            ListaItem.Columns[2].Visible = false;
            ListaItem.Columns[0].Visible = false;
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
                txtLine.Text = lsTemp[index].Line;
            }
            try
            {

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
                if (ListaItem.SelectedRows.Count > 1)
                {
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;

                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = true;

                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;

                }
            }
            catch { }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
        public void filtrar()
        {
            try
            {
                if (txtPesquisa.Text.Length > 0)
                {
                    string searchTerm = txtPesquisa.Text.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");

                    bs.Filter = "Text LIKE '%" + searchTerm + "%'";
                }
                else/* if (bs.Count ==0)*/
                {
                    bs.Filter = "";
                }
                label2.Text = Convert.ToString(bs.Count);
                organizarColunas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }


        private void btnReabrir_Click(object sender, EventArgs e)
        {
            salvarAlteracoes();
            pintarLinhas();
        }
        private void salvarAlteracoes()
        {
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            checked
            {
                lsTemp[index].Line = txtLine.Text;

                ListaItem.SelectedRows[0].Cells[1].Value = txtLine.Text;
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                qtdItem = ListaItem.Rows.Count;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 1)
                {
                    lastRow = ListaItem.SelectedRows[0].Index - 1;
                    if (MessageBox.Show("Deseja remover os " + Conversions.ToString(ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                        lsTemp.Remove(lsTemp[index]);
                        CarregarGrid(lsTemp);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox1.SelectedIndex = 0;
            salvarAlteracoes();
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            lbStatus.Text = "Salvando...";
            salvar(backgroundWorker);
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Marquee;
            lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            lbStatus.Text = "Stop";
            ToolStrip1.Enabled = true;
            lbIndices.Text = Conversions.ToString(qtdItem);
            nomeArquivo();
        }

        public void salvar(BackgroundWorker BW)
        {
            BW.ReportProgress(0, "Write File DAT");
            lsTemp.Save(Arquivo);
            BW.ReportProgress(100, "Save File DAT Sucess");
            MessageBox.Show("The language edited have been saved", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private void menuSalvarComo_Click(object sender, EventArgs e)
        {
            diagSalvarArquivo.ShowDialog();
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                ComboBox1.SelectedIndex = 0;
                salvarAlteracoes();
                ToolStrip1.Enabled = false;
                bs.Filter = "";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwSalvar.RunWorkerAsync();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (ListaItem.SelectedRows.Count == 1)
            {
                if (ListaItem.SelectedCells[0].RowIndex != -1 && !string.IsNullOrEmpty(txtLine.Text))
                {
                    try
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);

                        var translation = PangyaAPI.IFF.JP.Extensions.Utils.TranslateText(txtLine.Text, "ko", "en");
                        if (txtLine.Text != translation)
                        {
                            lsTemp[index].Line = translation;
                            ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                            ListaItem.SelectedRows[0].Cells["Text"].Value = translation;
                            pintarLinhas();
                            CarregarItem(); //recarrega o item logo
                        }
                        else
                            MessageBox.Show($"Ocorreu um erro durante a tradução: Código [1]", "[API.TranslateText]");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro durante a tradução: {ex.Message}", "[API.TranslateText]");
                    }
                }
            }
            else
            {
                try
                { 
                    foreach (DataGridViewRow row in ListaItem.SelectedRows)
                    {
                        var index = Convert.ToInt32(row.Cells[0].Value);
                        var translation = PangyaAPI.IFF.JP.Extensions.Utils.TranslateText(row.Cells[1].Value as string, "ko", "en");
                        if (txtLine.Text != translation)
                        {
                            lsTemp[index].Line = translation;
                            row.Cells["Alterado"].Value = 1;
                            row.Cells["Text"].Value = translation;
                            pintarLinhas();
                            CarregarItem(); //recarrega o item logo
                        }
                        else
                            MessageBox.Show($"Ocorreu um erro durante a tradução: Código [1]", "[API.TranslateText]");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro durante a tradução: {ex.Message}", "[API.TranslateText]");
                }
            }
        }
        private void Uncheck_all_encoding(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = false;
            jAPANToolStripMenuItem.Checked = false;
            tHAIToolStripMenuItem.Checked = false;
            oTHERToolStripMenuItem.Checked = false;
            autoToolStripMenuItem.Checked = false;
            kOREANToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Image = null;
            jAPANToolStripMenuItem.Image = null;
            tHAIToolStripMenuItem.Image = null;
            oTHERToolStripMenuItem.Image = null;
            autoToolStripMenuItem.Image = null;
            kOREANToolStripMenuItem.Image = null;
            if (menuSalvarComo.Enabled == false && btnAbrirArquivo.Enabled == false)
            {
                BtnSaveExcel.Enabled = true;
                menuSalvarComo.Enabled = true;
                btnAbrirArquivo.Enabled = true;
            }
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Default;
            autoToolStripMenuItem.Checked = true;
            autoToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private void eNGLISHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Usa;
            englishToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private void jAPANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Japan;
            jAPANToolStripMenuItem.Checked = true;
            jAPANToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private void tHAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Thaiwan;
            tHAIToolStripMenuItem.Checked = true;
            tHAIToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private void oTHERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Default;
            oTHERToolStripMenuItem.Checked = true;
            oTHERToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private void kOREANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uncheck_all_encoding(sender, e);
            RegionSelected = IFF_REGION.Korea;
            kOREANToolStripMenuItem.Checked = true;
            kOREANToolStripMenuItem.Image = Resources.BtnApply_Mini;
        }

        private async void ListaItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells.Count <= 10)
                {
                    try
                    {
                        // Itera sobre as células selecionadas
                        foreach (DataGridViewRow row in ListaItem.SelectedRows)
                        {
                            var index = Convert.ToInt32(row.Cells[0].Value);
                            var translation = PangyaAPI.IFF.JP.Extensions.Utils.TranslateText(row.Cells[1].Value as string, "ko", "en");
                            lsTemp[index].Line = translation;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro durante a tradução: {ex.Message}", "[API.TranslateText]");
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.K)
            {
                try
                {
                    // Itera sobre as células selecionadas
                    foreach (var row in lsTemp)
                    { 
                            row.Line = PangyaAPI.IFF.JP.Extensions.Utils.TranslateText(row.Line as string, "ja", "en");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro durante a tradução: {ex.Message}", "[API.TranslateText]");
                }
            }
            ListaItem.Refresh(); // Atualização final
        }

        private void BtnSaveExcel_Click(object sender, EventArgs e)
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
                                writer.WriteLine($"{lang.ID},{lang.Line}");
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
                                writer.WriteLine("ID,Line");
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
    }
}
