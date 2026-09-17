using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Models;
using PangyaSuiteFiles.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmCardEditor : Form
    {
        public bool IsLoad;
        public FrmCardEditor()
        {
            InitializeComponent();
            IsLoad = false;
        }
        private void FrmCardEditor_Load(object sender, EventArgs e)
        {
            this.lsItens = FrmMain.IFF.Card;
            this.lsTemp = new CardCollection();
            this.Arquivo = this.diagAbrirArquivo.FileName;           
            this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
            lsTemp.Header = lsItens.Header;
            this.nomeArquivo();
            this.ListaItem.DataSource = null;
            this.FirstLoadGrid(this.lsTemp);
            this.lbIndices.Text = this.lsItens.Count.ToString();
            IsLoad = true;
        }
        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new CardCollection();
                this.lsTemp = new CardCollection();
                this.Arquivo = this.diagAbrirArquivo.FileName;
#pragma warning disable CS0168 // A variável "exception1" está declarada, mas nunca é usada
                try
                {
                    lsItens.Load(File.ReadAllBytes(Arquivo));
                }
                catch (Exception exception1)
                {

                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
#pragma warning restore CS0168 // A variável "exception1" está declarada, mas nunca é usada
                this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
                lsTemp.Header = lsItens.Header;
                this.nomeArquivo();
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = this.lsItens.Count.ToString();
            }
        }
        private void FirstLoadGrid(CardCollection Lista)
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
            int num2 = 0;
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
                        case 1:
                        case 97:
                            image2 = Resources.points;
                            break;
                        default:
                            break;
                    }
                    num2 = 0;

                    int num4 = 0;

                    object[] values = new object[] { num3, this.oIff.Name.Replace("\0", ""), image, num2, this.oIff.Enabled, image2, num4 };
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

        public void CarregarGrid(CardCollection Lista)
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
            int num2 = 0;
            int num6 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                int num8 = num6;
                if (num3 > num8)
                {
                    this.ListaItem.DataSource = null;
                    this.bs = new BindingSource();
                    this.bs.DataSource = table;
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
                    case 32:
                    case 34:
                    case 0:
                    case 2:
                    case 6:
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
#pragma warning disable CS0168 // A variável "exception1" está declarada, mas nunca é usada
                try
                {
                    num4 = Convert.ToInt32(this.ListaItem["Alterado", num].Value);
                }
                catch (Exception exception1)
                {

                }
#pragma warning restore CS0168 // A variável "exception1" está declarada, mas nunca é usada
                object[] values = new object[] { num3, this.oIff.Name.Replace("\0", ""), image, num2, this.oIff.Enabled, image2, num4 };
                table.Rows.Add(values);
                num++;
                num3++;
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
                txtCardImage.Text = lsTemp[index].MPet;
                attForca.Value = new decimal(lsTemp[index].PowerSlot);
                attControle.Value = new decimal(lsTemp[index].ControlSlot);
                attPrecisao.Value = new decimal(lsTemp[index].AccuracySlot);
                attSpin.Value = new decimal(lsTemp[index].SpinSlot);
                attCurva.Value = new decimal(lsTemp[index].CurveSlot);
                this.cmbEffect.Text = lsTemp[index].Effect.ToString();
                txtEffectValue.Text = this.lsTemp[num].EffectValue.ToString();
                txtFlag1.Text = this.lsTemp[num].flag1.ToString();
                txtFlag2.Text = this.lsTemp[num].flag2.ToString();

                this.txtBuffImage.Text = lsTemp[index].AdditionalTexture3;
                this.txtSlotImage.Text = lsTemp[index].AdditionalTexture2;
                this.txtSubIcon.Text = lsTemp[index].AdditionalTexture1;
                this.txtCardNo.Text = lsTemp[index].Position.ToString();
                this.txtCardVolum.Text = lsTemp[index].Volumn.ToString();
                txtRarity.Text = lsTemp[index].Rarity.ToString();
                txtEffectDuration.Text = lsTemp[index].EffectTime.ToString();
                if (lsTemp[index].Icon != "")
                {
                    carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + lsTemp[index].Icon + ".png");
                }
                Card item;
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
                    //cbTipo.SelectedIndex = tipo;

                    switch (tipo)
                    {
                        case 160:
                        case 96:
                            cbTipo.SelectedIndex = 2;
                            break;
                        case 97:
                            cbTipo.SelectedIndex = 1;
                            break;
                        case 128:
                        case 129:
                            cbTipo.SelectedIndex = 3;
                            break;
                        case 192:
                        case 1:
                            cbTipo.SelectedIndex = 0;
                            break;
                        default:
                            cbTipo.SelectedIndex = 0;
                            break;
                    }
                    switch (text)
                    {
                        case "3":
                            if (lsTemp[index].MoneyFlag == 0)
                            {
                                ckNormal.Checked = false;
                                ckGift.Checked = false;
                                ckNew.Checked = false;
                                ckItemPSQ.Checked = true;
                            }
                            break;
                        case "01":
                            ckNormal.Checked = true;
                            ckGift.Checked = true;
                            break;
                        case "2":
                            ckNormal.Checked = false;
                            ckGift.Checked = false;
                            ckNew.Checked = false;
                            ckItemPSQ.Checked = true;
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
                Card item2 = lsTemp[index];
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
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                    menuDividir.Enabled = true;
                    menuGerarCache.Enabled = true;
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
                    menuTypeid.Visible = true;
                    menuBackup.Enabled = false;
                    menuGerarSql.Enabled = true;
                    menuMassa.Enabled = true;
                    menuDividir.Enabled = true;
                    menuMassa.Visible = true;
                    menuDividir.Visible = true;

                    menuGerarCache.Enabled = true;
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
                    menuMassa.Enabled = true;
                    menuDividir.Enabled = false;
                    menuGerarCache.Enabled = false;
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
            foreach (Card item in lsTemp)
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
                    if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1).ToString() + " AND Status2 = " + Convert.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Convert.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        bs.Filter = "Personagem = " + Convert.ToString(ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Convert.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + Convert.ToString(ComboBox1.SelectedIndex - 1);
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

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            this.salvarAlteracoes();
            this.pintarLinhas();
        }

        private void salvarAlteracoes()
        {
            int num = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
            this.lsTemp[num].Enabled = !this.ckAtivo.Checked ? ((byte)Conversions.ToLong("&H00")) : ((byte)Conversions.ToLong("&H01"));
            this.lsTemp[num].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H00");
            if (this.ckNew.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H11");
            }
            else if (this.ckNew.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H13");
            }
            if (this.ckHot.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H21");
            }
            else if (this.ckHot.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H23");
            }
            if (this.ckNormal.Checked & this.ckGift.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H01");
            }
            else if (this.ckNormal.Checked)
            {
                this.lsTemp[num].MoneyFlag = (MoneyFlag)(byte)Conversions.ToLong("&H03");
            }

            this.lsTemp[num].Name = this.txtNome.Text;
            this.lsTemp[num].ItemPrice = (uint)Conversions.ToLong(this.txtPreco.Text);
            this.lsTemp[num].TypeID = (uint)Conversions.ToLong(this.txtTypeID.Text);
            this.lsTemp[num].Icon = this.txtIcone.Text;
            this.lsTemp[num].Enabled = Convert.ToUInt32(ckAtivo.Checked);
            this.lsTemp[num].Effect =(CardEffectFlag) Convert.ToUInt32(cmbEffect.SelectedIndex);
            this.lsTemp[num].EffectValue = Convert.ToUInt16(txtEffectValue.Text);
            this.lsTemp[num].flag1 = Convert.ToUInt32(txtFlag1.Text);
            this.lsTemp[num].flag2 = Convert.ToUInt32(txtFlag2.Text);
            this.lsTemp[num].MinLevel = (ItemLevelEnum)(byte)this.cbLevel.SelectedIndex;
            this.lsTemp[num].DiscountPrice = (uint)Conversions.ToLong(this.txtDesconto.Text);
            this.lsTemp[num].MPet = this.txtCardImage.Text;
            this.lsTemp[num].MinLevel = (ItemLevelEnum)(!rbLevelMin.Checked ? ((byte)(Conversions.ToLong("&H80") + this.cbLevel.SelectedIndex)) : ((byte)this.cbLevel.SelectedIndex));
            lsTemp[num].AdditionalTexture1 = this.txtSubIcon.Text;
            lsTemp[num].AdditionalTexture2 = this.txtSlotImage.Text;
            lsTemp[num].AdditionalTexture3 = this.txtBuffImage.Text;
            lsTemp[num].Volumn = ushort.Parse(this.txtCardVolum.Text);
            lsTemp[num].Position = ushort.Parse(this.txtCardNo.Text);
            lsTemp[num].PowerSlot = ushort.Parse(this.attForca.Text);
            lsTemp[num].ControlSlot = ushort.Parse(this.attControle.Text);
            lsTemp[num].AccuracySlot = ushort.Parse(this.attPrecisao.Text);
            lsTemp[num].SpinSlot = ushort.Parse(this.attSpin.Text);
            lsTemp[num].Rarity = byte.Parse(txtRarity.Text);
            lsTemp[num].CurveSlot = ushort.Parse(this.attSpin.Text);
            lsTemp[num].EffectTime = ushort.Parse(this.txtEffectDuration.Text);

            switch (this.cbTipo.SelectedIndex)
            {
                case 0:
                    this.lsTemp[num].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H00");
                    break;

                case 1:
                    this.lsTemp[num].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H01");
                    break;

                case 2:
                    this.lsTemp[num].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H02");
                    break;

                default:
                    break;
            }
            if (this.ckTempoAtivo.Checked)
            {
                Card item = this.lsTemp[num];
                item.DateEnd.Day = (ushort)this.dtTermino.Value.Day;
                item.DateEnd.Month = (ushort)this.dtTermino.Value.Month;
                item.DateEnd.Year = (ushort)this.dtTermino.Value.Year;
                item.DateEnd.Hour = (ushort)this.dtTermino.Value.Hour;
                item.DateEnd.Minute = (ushort)this.dtTermino.Value.Minute;
                item.DateEnd.Second = (ushort)this.dtTermino.Value.Second;
                item.Active_Item_Time = 1;
                item = null;
                Card item2 = this.lsTemp[num];
                item2.DateStart.Day = (ushort)this.dtInicio.Value.Day;
                item2.DateStart.Month = (ushort)this.dtInicio.Value.Month;
                item2.DateStart.Year = (ushort)this.dtInicio.Value.Year;
                item2.DateStart.Hour = (ushort)this.dtInicio.Value.Hour;
                item2.DateStart.Minute = (ushort)this.dtInicio.Value.Minute;
                item2.DateStart.Second = (ushort)this.dtInicio.Value.Second;

                item2 = null;
            }
            this.ListaItem.SelectedRows[0].Cells[1].Value = this.txtNome.Text;
            this.ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            this.Alterado = false;
            this.qtdItem = this.ListaItem.Rows.Count;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                var item = this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value)];
                try
                {
                    this.lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(this.ListaItem.SelectedRows[0].Cells[0].Value, 1)), item);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lsTemp.Insert(Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value), item);
                    ProjectData.ClearProjectError();
                }
                this.CarregarGrid(this.lsTemp);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja adicionar um novo item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Card item = new Card
                {
                    Name = "[NOVO ITEM]", Icon = "[NOVO ICON]", Bonus = new short[2], MPet = "[NOVO MPET]", DateStart = new PangyaAPI.IFF.StructModels.IFFTime(), DateEnd = new PangyaAPI.IFF.StructModels.IFFTime()
                    
                };
                Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                try
                {
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex + 1, item);
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex, item);
                    ProjectData.ClearProjectError();
                }
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                this.CarregarGrid(this.lsTemp);
                try
                {
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                    this.ListaItem.Rows[this.lastRow].Selected = true;
                }
                catch (Exception exception3)
                {
                    Exception ex = exception3;
                    ProjectData.SetProjectError(ex);
                    Exception local4 = ex;
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow - 1;
                    this.ListaItem.Rows[this.lastRow - 1].Selected = true;
                    ProjectData.ClearProjectError();
                }
            }
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "Card.iff";
            }
            this.bs.Filter = "";
            this.ComboBox2.SelectedIndex = 0;
            this.salvarAlteracoes();
            this.btnSalvar.Enabled = false;
            this.ToolStrip1.Enabled = false;
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.bwSalvar.RunWorkerAsync();
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker)sender;
            this.lbStatus.Text = "Salvando...";
            this.salvar(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Blocks;
            this.pbStatus.Value = 0;
            this.lbStatus.Text = "parado";
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            this.nomeArquivo();
        }

        private void menuSalvarComo_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int)this.diagSalvarArquivo.ShowDialog());
            this.Arquivo = this.diagSalvarArquivo.FileName;
            if (this.Arquivo != null)
            {
                this.bs.Filter = "";
                this.ComboBox2.SelectedIndex = 0;
                this.salvarAlteracoes();
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bs.Filter = "";
                this.pbStatus.Style = ProgressBarStyle.Marquee;
                this.bwSalvar.RunWorkerAsync();
            }
        }

        public void salvar(BackgroundWorker BW)
        {
            var bck = Path.GetFileNameWithoutExtension(Arquivo) + ".bak";
            lsItens.IffSave(Directory.GetCurrentDirectory() + "\\backup_iffs\\" + bck, false);
            lsTemp.IffSave(Directory.GetCurrentDirectory() + "\\new_iffs\\" + Path.GetFileName(Arquivo), false);
            lsTemp.IffSave(Arquivo, false);
            FrmMain.IFF.Update = true;
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

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void gerarBarra(Control Barra, object sender1, object sender2)
        {
            int try0001_dispatch = -1;
            int num3 = default(int);
            int num2 = default(int);
            int num = default(int);
            double num5 = default(double);
            while (true)
            {
                try
                {
                    /*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/

                    switch (try0001_dispatch)
                    {
                        default:
                            ProjectData.ClearProjectError();
                            num3 = -2;
                            goto IL_0009;
                        case 135:
                            {
                                num2 = num;
                                if (num3 > -2)
                                {
                                    switch (num3)
                                    {
                                        case 1:
                                            break;
                                        default:
                                            goto end_IL_0001;
                                    }
                                }
                                int num4 = num2 + 1;
                                num2 = 0;
                                switch (num4)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        goto IL_0009;
                                    case 3:
                                        goto IL_000c;
                                    case 4:
                                        goto end_IL_0001_2;
                                    default:
                                        goto end_IL_0001;
                                    case 5:
                                        goto end_IL_0001_3;
                                }
                                goto default;
                            }
                        IL_000c:
                            num = 3;
                            num5 = 5.9;
                            break;
                        IL_0009:
                            num = 2;
                            goto IL_000c;
                        end_IL_0001_2:
                            break;
                    }
                    num = 4;
                    Barra.Width = Conversions.ToInteger(Operators.MultiplyObject(Operators.AddObject(NewLateBinding.LateGet(sender1, null, "value", new object[0], null, null, null), NewLateBinding.LateGet(sender2, null, "value", new object[0], null, null, null)), num5));
                    break;
                end_IL_0001:;
                }
                catch (Exception obj)
                {
                    ProjectData.SetProjectError((Exception)obj);
                    try0001_dispatch = 135;
                    continue;
                }
                throw ProjectData.CreateProjectError(-2146828237);
#pragma warning disable CS0162 // Código inacessível detectado
                continue;
#pragma warning restore CS0162 // Código inacessível detectado
            end_IL_0001_3:
                break;
            }
            if (num2 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }
        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraCurva, RuntimeHelpers.GetObjectValue(sender), attCurva);
        }
        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraSpin, RuntimeHelpers.GetObjectValue(sender), attSpin);
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraPrecisao, RuntimeHelpers.GetObjectValue(sender), attPrecisao);
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraControle, RuntimeHelpers.GetObjectValue(sender), attControle);
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            gerarBarra(barraForca, RuntimeHelpers.GetObjectValue(sender), attForca);
        }

        private void activeAllItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtrar();
            if (bs.Count > 0)
            {
                for (int i = 0; i < bs.Count; i++)
                {
                    var index = Convert.ToInt32(ListaItem.Rows[i].Cells[0].Value);
                    var tipo = (CARD_SUB_TYPE)lsTemp[index].GetTypeCard();
                    if (lsTemp[index].Icon != "" && tipo != CARD_SUB_TYPE.T_PACK)
                    {
                        lsTemp[index].MoneyFlag = MoneyFlag.None;
                        lsTemp[index].PriceType = ShopFlag.Unknown03;
                        lsTemp[index].DiscountPrice = 0;
                        if (lsTemp[index].ItemPrice >= 10000000)
                        {
                            lsTemp[index].ItemPrice = 123;
                        }
                    }
                }
            }
            pintarLinhas();
            MessageBox.Show("Todos os itens listados na barra de pequisa \n foram ativados no PSQ shop !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirstLoadGrid(lsTemp);
        }
    }
}
