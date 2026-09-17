using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.General;
using Pangya_Modern_Editor.Extensions;

namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmDesc : Form
    {
        public int PositionKey;
        public int PostionClickMouse;
        public bool sfile = false;
        public FrmDesc()
        {
            InitializeComponent();
        }
        public FrmDesc(IFFFile<Desc> Descs)
        {
            bs = new BindingSource();
            InitializeComponent();
            this.lsItens = Descs;
        }

        private void FrmDesc_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "Desc.iff";
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
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
            {
                return;
            }
            lsItens = new IFFFile<Desc>();
            lsTemp = new IFFFile<Desc>();
            Arquivo = diagAbrirArquivo.FileName;
            try
            {
                lsItens.Load(File.ReadAllBytes(Arquivo));

            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                MessageBox.Show("Damaged or unknown file", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
                return;
            }
            this.lsTemp.AddRange(lsItens.GetRange(0, lsItens.Count));
            nomeArquivo();
            
            CarregarGrid(lsTemp);
            lbIndices.Text = Conversions.ToString(qtdItem);
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

        public void CarregarGrid(IFFFile<Desc> Lista)
        {
            if (ListaItem.InvokeRequired)
            {
                ListaItem.Invoke(new Action(() => CarregarGrid(Lista)));
                return;
            }
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("index", typeof(int));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            int num3 = 0;
            foreach (var item in Lista)
            {
                Image accept = Properties.Resources.BtnApply_Mini;
                if (string.IsNullOrEmpty(item.Description))
                {
                    accept = Properties.Resources.BtnRemove_Mini;
                }
                var string_ = "Unknown Name";
                if (sIff.getInstance() != null)
                {
                    IFFCommon common = sIff.getInstance().FindCommonItem(item.ID);
                    if (common != null)
                    {
                        string_ = common.Name;
                    }

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
                table.Rows.Add(item.ID,string_,num3, accept, alterado);
                num3++;
            }
            ListaItem.Invoke((MethodInvoker)delegate
            {
                
                bs = new BindingSource(table, null);
                ListaItem.DataSource = bs;
                lbTotalItens.Text = ListaItem.Rows.Count.ToString();
                ListaItem.Columns[0].Width = 0x2d;
                ListaItem.Columns[3].Width = 30;
                ListaItem.Columns[0].ValueType = typeof(int);
                ListaItem.Columns[2].HeaderText = "   ";
                ListaItem.Columns[3].HeaderText = "   ";
                ListaItem.Columns[1].HeaderText = "   ";
                ListaItem.Columns[0].HeaderText = "   ";
                ListaItem.Columns[2].Visible = false;
                ListaItem.Columns[4].Visible = false;
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
            ListaItem.Columns[0].Width = 0x2d;
            ListaItem.Columns[3].Width = 30;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[3].HeaderText = "   ";
            ListaItem.Columns[1].HeaderText = "   ";
            ListaItem.Columns[0].HeaderText = "   ";
            ListaItem.Columns[2].Visible = false;
            ListaItem.Columns[4].Visible = false;
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
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                txtTypeID.Text = Conversions.ToString(lsTemp[index].ID);
                txtDesc.MaxLength = 512;
                txtDesc.Text = Conversions.ToString(lsTemp[index].Description);
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    BtnTranslation.Enabled = false;
                }

                else
                {
                    BtnTranslation.Enabled = true;
                }        
            }
            Alterado = false;
            ListaItem.Refresh(); // Atualização final
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
                    tabForm.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = false;
                    menuSalvarComo.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    btnNovo.Enabled = true;
                    btnBackup.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnReabrir.Enabled = true;
                    gbBotoes.Enabled = true;
                    tabForm.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    menuSalvarComo.Enabled = false;
                }
                if (bwSalvar.IsBusy)
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
            int index = 0;
            try
            {
                index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            lsTemp[index].ID = Conversions.ToUInteger(txtTypeID.Text);
            lsTemp[index].Description = txtDesc.Text;
            try
            {
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                ListaItem.SelectedRows[0].Cells["ID"].Value = txtTypeID.Text;
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                ProjectData.ClearProjectError();
            }
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
        }

        private void Alterou()
        {
            Alterado = true;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ListaItem.SelectedRows.Count > 1)
                {
                    lastRow = ListaItem.SelectedRows[0].Index - 1;
                    if (MessageBox.Show("Do you want to remove the " + Conversions.ToString(ListaItem.SelectedRows.Count) + " selected items?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
                            lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[num2].Cells[2].Value)]);
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
                    if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Do you want to remove the item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                        lsTemp.Remove(lsTemp[index]);
                        CarregarGrid(lsTemp);
                    }
                }
            }
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add a new item?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
             var item = new Desc();
            item.ID = 999;
            item.Description = "[NOVO ITEM]";
            try
            {
                lsTemp.Add(item);
                
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            CarregarGrid(lsTemp);
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {    
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
             var item = lsTemp.First(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)).Clone() as  Desc;
            item.ID = 999;
            try
            {
                lsTemp.Add(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            CarregarGrid(lsTemp);
        }      
                 
        private void frmDesc_FormClosing(object sender, FormClosingEventArgs e)
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
            try
            {
                organizarColunas();
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }                                            

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            organizarColunas();
            pintarLinhas();
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
            //string img = Conversions.ToString(Util.getImage(txtTypeID.Text));
            //PictureBox obj = imgResultado;
            //carregarImagem(img, ref obj);
            //imgResultado = obj;
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

        private void btnInsertColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int Posicao = txtDesc.SelectionStart;
                var txt = txtDesc.Text;
                this.txtDesc.Text = txt.Insert(Posicao, @"\c0x" + ColorToHexString(dialog.Color) + @"FF\c ");
            }
        }
        string ColorToHexString(Color color)
        {
            char[] chArray = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            byte[] buffer = new byte[] { color.R, color.G, color.B };
            char[] chArray2 = new char[buffer.Length * 2];
            for (int i = 0; i < buffer.Length; i++)
            {
                int num2 = buffer[i];
                chArray2[i * 2] = chArray[num2 >> 4];
                chArray2[(i * 2) + 1] = chArray[num2 & 15];
            }
            return new string(chArray2);
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

        private async void BtnTranslation_Click(object sender, EventArgs e)
        {
            try
            {

                if (ListaItem.SelectedCells[0].RowIndex != -1 && !string.IsNullOrEmpty(txtDesc.Text))
                {
                    int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value);
                    var translation = PangyaAPI.IFF.JP.Extensions.Utils.TranslateText(lsTemp[index].Description, "ja", "en");
                    lsTemp[index].Description = translation;
                     ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                    pintarLinhas();
                    CarregarItem(); //recarrega o item logo 
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
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

        private void SearchItem_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
