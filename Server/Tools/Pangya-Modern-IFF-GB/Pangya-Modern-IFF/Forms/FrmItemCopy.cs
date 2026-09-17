using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using PangyaSuiteFiles.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmItemCopy : Form
    {
        public bool IsLoad;
        public bool copied = false;
        public IFFValues IFFValues = new IFFValues(); 
        public FrmItemCopy()
        {
            InitializeComponent();
        }


        private void FrmItemEditor_Load(object sender, EventArgs e)
        {
            this.lsItens = new List<IFFCommon>();
            this.lsTemp = new List<IFFCommon>();
           
            IsLoad = false;
        }
        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != "") && IsLoad == false)
            {
                this.lsItens =new List<IFFCommon>();
                this.lsTemp = new List<IFFCommon>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
#pragma warning disable CS0168 // A variável "exception1" está declarada, mas nunca é usada
                try
                {
                    PangyaBinaryReader Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(diagAbrirArquivo.FileName)));
                    var Header = (IFFHeader)Reader.Read(new IFFHeader());
                    long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                    for (int i = 0; i < Header.Count; i++)
                    {
                        _ = Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                        var item = new IFFCommon();
                        item.Load(ref Reader, 40);
                        lsItens.Add(item);
                    }
                }
                catch (Exception exception1)
                {
                   
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
#pragma warning restore CS0168 // A variável "exception1" está declarada, mas nunca é usada
                this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                lsTemp = lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = null;
                this.FirstLoadGrid(this.lsTemp);
                this.lbIndices.Text = this.lsItens.Count.ToString();
            }   
        }
        public void CarregarGrid(List<IFFCommon> Lista)
        {
            List<string> list1 = new List<string>();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            int num = 0;
#pragma warning disable CS0219 // A variável "num2" é atribuída, mas seu valor nunca é usado
            int num2 = 0;
#pragma warning restore CS0219 // A variável "num2" é atribuída, mas seu valor nunca é usado
            int num6 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                int num8 = num6;
                if (num3 > num8)
                {
                    this.ListaItem.DataSource = null;
                    this.bs = new BindingSource
                    {
                        DataSource = table
                    };
                    this.ListaItem.DataMember = table.TableName;
                    this.ListaItem.DataSource = this.bs;
                    this.lbTotalItens.Text = this.ListaItem.Rows.Count.ToString();
                    this.ListaItem.Columns[0].Width = 0x2d;
                    this.ListaItem.Columns[2].Width = 30;
                    this.ListaItem.Columns[5].Width = 30;
                    this.ListaItem.Columns[0].ValueType = typeof(int);
                    this.ListaItem.Columns[2].HeaderText = "   ";
                    this.ListaItem.Columns[5].HeaderText = "   ";
                    int num7 = this.ListaItem.Rows.Count - 1;
                    int num5 = 0;
                    while (true)
                    {
                        num8 = num7;
                        if (num5 > num8)
                        {
                            this.ListaItem.Columns[3].Visible = false;
                            this.ListaItem.Columns[4].Visible = false;
                            this.ListaItem.Columns[6].Visible = false;
                            this.filtrar();
#pragma warning disable CS0168 // A variável "exception3" está declarada, mas nunca é usada
                            try
                            {
                                this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                                this.ListaItem.Rows[this.lastRow].Selected = true;
                            }
                            catch (Exception exception3)
                            {
                               
                            }
#pragma warning restore CS0168 // A variável "exception3" está declarada, mas nunca é usada
                            this.pintarLinhas();
                            return;
                        }
                        this.ListaItem.Rows[num5].Selected = false;
                        num5++;
                    }
                }
                this.oIff = Lista[num3];
                Image image = (this.oIff.Enabled != 1) ? Properties.Resources.delete1 : Properties.Resources.accept1;
                Image image2 = Properties.Resources.eye__minus;
                var tipo = (int)oIff.PriceType;
                switch (tipo)
                {
                    case 0:
                    case 6:
                    case 32:
                    case 2:
                    case 34:
                    case 160:
                    case 96:
                        image2 = Properties.Resources.Pang;
                        break;
                    case 192:
                    case 33:
                    case 37:
                    case 1:
                    case 97:
                        image2 = Properties.Resources.points;
                        break;
                    default:
                        break;
                }
                num2 = 0;
                int num4 = 0;
                try
                {
                    num4 = Convert.ToInt32(this.ListaItem["Alterado", num].Value);
                }
                catch (Exception exception1)
                {
                    System.Diagnostics.Debug.WriteLine(exception1.Message); 
                }
                object[] values = new object[] { num3, this.oIff.Name.Replace("\0", ""), image, oIff.TypeItem(), this.oIff.Enabled, image2, num4 };
                table.Rows.Add(values);
                num++;
                num3++;
            }
        }
        private void FirstLoadGrid(List<IFFCommon> Lista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));
            int num = 0;
#pragma warning disable CS0219 // A variável "num2" é atribuída, mas seu valor nunca é usado
            int num2 = 0;
#pragma warning restore CS0219 // A variável "num2" é atribuída, mas seu valor nunca é usado
            int num6 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                if (num6 >= num3)
                {
                    this.oIff = Lista[num3];
                    Image image = (this.oIff.Enabled != 1) ? Properties.Resources.delete1 : Properties.Resources.accept1;
                    Image image2 = Properties.Resources.eye__minus;
                    var tipo = (int)oIff.PriceType;

                    switch (tipo)
                    {
                        case 0:
                        case 6:
                        case 32:
                        case 2:
                        case 34:
                        case 160:
                        case 96:
                            image2 = Resources.Pang;
                            break;
                        case 192:
                        case 33:
                        case 37:
                        case 1:
                        case 97:
                            image2 = Resources.points;
                            break;
                        default:
                            break;
                    }
                    num2 = 0;

                    int num4 = 0;

                    object[] values = new object[] { num3, this.oIff.Name.Replace("\0", ""), image, oIff.TypeItem(), this.oIff.Enabled, image2, num4 };
                    table.Rows.Add(values);
                    num++;
                    num3++;

                    int num8 = num6;
                    if (num3 > num8)
                    {
                        this.ListaItem.DataSource = null;
                        this.bs = new BindingSource
                        {
                            DataSource = table
                        };
                        this.ListaItem.DataMember = table.TableName;
                        this.ListaItem.DataSource = this.bs;
                        this.lbTotalItens.Text = this.ListaItem.Rows.Count.ToString();
                        this.ListaItem.Columns[0].Width = 0x2d;
                        this.ListaItem.Columns[2].Width = 30;
                        this.ListaItem.Columns[5].Width = 30;
                        this.ListaItem.Columns[0].ValueType = typeof(int);
                        this.ListaItem.Columns[2].HeaderText = "   ";
                        this.ListaItem.Columns[5].HeaderText = "   ";
                        int num7 = this.ListaItem.Rows.Count - 1;
                        int num5 = 0;
                        this.ListaItem.Columns[3].Visible = false;
                        this.ListaItem.Columns[4].Visible = false;
                        this.ListaItem.Columns[6].Visible = false;
                        while (true)
                        {
                            num8 = num7;
                            if (num5 > num8)
                            {
                                this.ListaItem.Columns[3].Visible = false;
                                this.ListaItem.Columns[4].Visible = false;
                                this.ListaItem.Columns[6].Visible = false;
                                this.filtrar();
#pragma warning disable CS0168 // A variável "exception3" está declarada, mas nunca é usada
                                try
                                {
                                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                                    this.ListaItem.Rows[this.lastRow].Selected = true;
                                }
                                catch (Exception exception3)
                                {

                                }
#pragma warning restore CS0168 // A variável "exception3" está declarada, mas nunca é usada
                                this.pintarLinhas();
                                return;
                            }
                            this.ListaItem.Rows[num5].Selected = false;
                            num5++;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void pintarLinhas()
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

        private void CarregarItem()
        {
            if (ListaItem.SelectedCells[0].RowIndex > -1)
            {
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                int num = 0;
                txtNome.Text = lsTemp[index].Name;
                txtTypeID.Text = Conversions.ToString(lsTemp[index].TypeID);
                ckAtivo.Checked = lsTemp[index].Enabled != 0;
                txtIcone.Text = lsTemp[index].Icon;
                txtPreco.Text = Conversions.ToString(lsTemp[index].ItemPrice);
                txtDesconto.Text = Conversions.ToString(lsTemp[index].DiscountPrice);
                txtQtd.Value = new decimal(1);
                txtSprite.Text = "";
                if (lsTemp[index].Icon != "")
                {
                    carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + lsTemp[index].Icon + ".png");
                }
                IFFCommon item;
                checked
                {
                    if ((int)lsTemp[index].MinLevel <= 72)
                    {
                        num = (int)lsTemp[index].MinLevel;
                        rbLevelMin.Checked = true;
                    }
                    else
                    {
                        num = unchecked((int)lsTemp[index].MinLevel) - 128;
                        rbLevelMax.Checked = true;
                    }
                    cbLevel.SelectedIndex = num;
                    string text = ((int)lsTemp[index].PriceType).ToString();
                    var tipo = (int)lsTemp[index].PriceType;

                    switch (tipo)
                    {
                        case 0:
                        case 6:
                        case 32:
                        case 2:
                        case 34:
                        case 160:
                        case 96:

                            cbTipo.SelectedIndex = 2;                            break;
                        case 192:
                        case 33:
                        case 37:
                        case 1:
                        case 97:
                            cbTipo.SelectedIndex = 1;
                            break;
                        default:
                            cbTipo.SelectedIndex = 0;
                            break;
                    }
                    
                    switch (text)
                    {
                        case "01":
                            ckNormal.Checked = true;
                            ckGift.Checked = true;
                            break;
                        case "03":
                            ckGift.Checked = false;
                            ckNormal.Checked = true;
                            break;
                        case "13":
                            ckGift.Checked = false;
                            ckNew.Checked = true;
                            break;
                        case "23":
                            ckGift.Checked = false;
                            ckHot.Checked = true;
                            break;
                        case "11":
                            ckNew.Checked = true;
                            ckGift.Checked = true;
                            break;
                        case "21":
                            ckHot.Checked = true;
                            ckGift.Checked = true;
                            break;
                        default:
                            ckDesativado.Checked = true;
                            break;
                    }
                    item = lsTemp[index];
                }
               
                string text2 = Conversions.ToString((int)item.DateStart.Day);
                string text3 = Conversions.ToString((int)item.DateStart.Month);
                string text4 = Conversions.ToString((int)item.DateStart.Year);
                string text5 = Conversions.ToString((int)item.DateStart.Hour);
                string text6 = Conversions.ToString((int)item.DateStart.Minute);
                string text7 = Conversions.ToString((int)item.DateStart.Second);
                item = null;
                IFFCommon item2 = lsTemp[index];
                string text8 = Conversions.ToString((int)item2.DateEnd.Day);
                string text9 = Conversions.ToString((int)item2.DateEnd.Month);
                string text10 = Conversions.ToString((int)item2.DateEnd.Year);
                string text11 = Conversions.ToString((int)item2.DateEnd.Hour);
                string text12 = Conversions.ToString((int)item2.DateEnd.Minute);
                string text13 = Conversions.ToString((int)item2.DateEnd.Second);
                item2 = null;
                DateTime.TryParse(text2 + "/" + text3 + "/" + text4 + " " + text5 + ":" + text6 + ":" + text7, out var result);
                DateTime.TryParse(text8 + "/" + text9 + "/" + text10 + " " + text11 + ":" + text12 + ":" + text13, out var result2);
                try
                {
                    dtInicio.Value = result;
                    dtTermino.Value = result2;
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    dtInicio.Value = DateTime.Now.AddYears(-3);
                    dtTermino.Value = DateTime.Now.AddYears(-3);
                    ProjectData.ClearProjectError();
                }
                if ((DateTime.Compare(result, DateTime.Now) < 0) & (DateTime.Compare(result2, DateTime.Now) > 0))
                {
                    ckTempoAtivo.Checked = true;
                }
                else
                {
                    ckTempoAtivo.Checked = false;
                }
            }
            Alterado = false;
            try
            {
                Conversions.ToInteger(Operators.AddObject(ListaItem.Rows[ListaItem.SelectedRows[0].Index].Cells[3].Value, 1));
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
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
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                   
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
            foreach (IFFCommon item in lsTemp)
            {
                if (item.TypeID == typeid)
                {
                    num = checked(num + 1);
                }
            }
            if (flag)
            {
                if (num >= 1)
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

        private void filtrar()
        {
            checked
            {
#pragma warning disable CS0168 // A variável "projectError" está declarada, mas nunca é usada
                try
                {
                    int num = 0;
                    num = ((ComboBox2.SelectedIndex == 1) ? 1 : 0);
                    int num2 = -1;

                    switch (cbItemType.SelectedIndex)
                    {
                        case 0:
                            num2 = -1;
                            break;
                        case 1:
                            num2 = 0;
                            break;
                        case 16: 
                            break;
                        case 2:
                            num2 = 128;
                            break;
                        case 3:
                            num2 = 252;
                            break;
                        default:
                            break;
                    }
                    if ((cbItemType.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (num2).ToString() + " AND Status2 = " + Convert.ToString(num);
                    }
                    else if ((cbItemType.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (num2);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Convert.ToString(num);
                    }
                    else if ((cbItemType.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        bs.Filter = "Personagem = " + Convert.ToString(num2) + " AND Status2 = " + Convert.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (cbItemType.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + Convert.ToString(num2);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {
                        bs.Filter = "Status2 = " + Convert.ToString(num);
                    }
                    else
                    {
                        bs.Filter = "";
                    }
                    Label33.Text = Convert.ToString(bs.Count);
                    ListaItem.Columns[0].Width = 45;
                    ListaItem.Columns[2].Width = 30;
                    ListaItem.Columns[5].Width = 30;
                    ListaItem.Columns[0].ValueType = typeof(int);
                    ListaItem.Columns[2].HeaderText = "   ";
                    ListaItem.Columns[5].HeaderText = "   ";
                }
                catch (Exception projectError)
                {
                    
                }
#pragma warning restore CS0168 // A variável "projectError" está declarada, mas nunca é usada
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

        private void ListaItem_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Copia somente um item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                oIff_Copy = new IFFCommon();
                int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                oIff_Copy = lsTemp[index];
                oIff_Copy.Enabled = 0;
                oIff_Copy.TypeID = 999;
                IFFValues = lsTemp[index].Values();
                if (oIff_Copy.Name != null || oIff_Copy.Name != "")
                {
                    MessageBox.Show("Sucess Copy object in iff !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    copied = true;
                }
                return;
            }
            if (MessageBox.Show("Deseja copia somente todos da lista item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) 
            {
                if (bs.Count > 0)
                {
                    for (int i = 0; i < bs.Count; i++)
                    {
                        var Copy = new IFFCommon();
                        var index = Convert.ToInt32(ListaItem.Rows[i].Cells[0].Value);
                        Copy = lsTemp[index];
                        Copy.Enabled = 0;
                        IFFValues = lsTemp[index].Values();
                        if (Copy.Name != null || Copy.Name != "")
                        {
                            oIff_Copy_List.Add(Copy);
                        }
                    }
                    copied = true;
                    MessageBox.Show("Todos os itens listados na barra de pequisa \nforam copiados com suceso !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.ListaItem.SelectedRows.Count <= 1)
            {
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", this.ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num2 = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                    this.lsTemp.Remove(this.lsTemp[num2]);
                    this.CarregarGrid(this.lsTemp);
                }
            }
            else
            {
                this.lastRow = this.ListaItem.SelectedRows[0].Index - 1;
                if (MessageBox.Show("Deseja remover os " + Conversions.ToString(this.ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num3 = this.ListaItem.SelectedRows.Count - 1;
                    int num = 0;
                    while (true)
                    {
                        int num4 = num3;
                        if (num > num4)
                        {
                            this.CarregarGrid(this.lsTemp);
                            break;
                        }
                        try
                        {
                            this.lsTemp.Remove(this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[num].Cells[0].Value)]);
                        }
                        catch (Exception exception1)
                        {
                            Exception ex = exception1;
                            ProjectData.SetProjectError(ex);
                            Exception local2 = ex;
                            ProjectData.ClearProjectError();
                        }
                        num++;
                    }
                }
            }
        }

        private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new DlgMassaDesconto().Show();
        }

        private void ToolStripMenuItem0_Click(object sender, EventArgs e)
        {

        }
        private void carregarImagem(string path)
        {
            if (File.Exists(path))
            {
                this.imgIcone.Image = new Bitmap(path);
            }
            else
            {
                imgIcone.Image = Resources.ajax_loader;
            }
        }

        private void carregarImagem(string img, ref PictureBox obj)
        {

            if (File.Exists(img))
            {
                obj.Image = new Bitmap(img);
            }
            else
            {
                obj.Image = Resources.ajax_loader;
            }
        }

    }
}
