using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Extensions;
using PangyaAPI.IFF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
    public partial class FrmPartEditor : Form
    {
        public bool IsLoad;
        FrmItemCopy ItemCopy;
        DlgPartTypeID frmPartTypeid2;
        public FrmPartEditor()
        {
            InitializeComponent();
            ItemCopy = new FrmItemCopy();
            frmPartTypeid2 = new DlgPartTypeID();
        }


        private void FrmPartEditor_Load(object sender, EventArgs e)
        {
            this.lsItens = FrmMain.IFF.Part;
            this.lsTemp = new PartCollection();
            this.Arquivo = "Part.iff";
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
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0 && IsLoad == false)
            {
                return;
            }

            this.lsItens = new PartCollection();
            this.lsTemp = new PartCollection();
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
            //this.CarregarGrid(this.lsTemp);
            FirstLoadGrid(this.lsTemp);
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

        private void FirstLoadGrid(PartCollection Lista)
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
            uint num2 = 0;
            int num6 = Lista.Count - 1;
            int num3 = 0;
            while (true)
            {
                if (num6 >= num3)
                {
                    this.oIff = Lista[num3];
                    Image image = (this.oIff.Enabled != 1) ? Properties.Resources.delete1 : Properties.Resources.accept1;
                    Image image2 = Resources.eye__minus;
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
                    num2 = oIff.getPersonagem();

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

        public void CarregarGrid(PartCollection Lista)
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
            uint num2 = 0;
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
                    case 32:
                    case 34:
                    case 0:
                    case 2:
                    case 6:
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
                num2 = oIff.getPersonagem();
                int num4 = 0;
                try
                {
                    num4 = Convert.ToInt32(this.ListaItem["Alterado", num].Value);
                }
                catch (Exception exception1)
                {
                    Debug.WriteLine(exception1.Message);
                }
                object[] values = new object[] { num3, this.oIff.Name.Replace("\0", ""), image, num2, this.oIff.Enabled, image2, num4 };
                table.Rows.Add(values);
                num++;
                num3++;
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
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                    }
                    if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, TextCompare: false))
                    {
                        ListaItem.Rows[num2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                    }
                    //if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 1, TextCompare: true))
                    //{
                    //	ListaItem.Rows[num2].DefaultCellStyle.BackColor = Color.Empty;
                    //}
                    //if (Operators.ConditionalCompareObjectEqual(ListaItem["Alterado", num2].Value, 2, TextCompare: true))
                    //{
                    //	ListaItem.Rows[num2].DefaultCellStyle.BackColor = Color.Empty;
                    //}
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
                att2Forca.Value = new decimal(lsTemp[index].PowerSlot);
                attForca.Value = new decimal(lsTemp[index].Power);
                att2Controle.Value = new decimal(lsTemp[index].ControlSlot);
                attControle.Value = new decimal(lsTemp[index].Control);
                att2Precisao.Value = new decimal(lsTemp[index].ImpactSlot);
                attPrecisao.Value = new decimal(lsTemp[index].Impact);
                att2Spin.Value = new decimal(lsTemp[index].SpinSlot);
                attSpin.Value = new decimal(lsTemp[index].Spin);
                att2Curva.Value = new decimal(lsTemp[index].CurveSlot);
                attCurva.Value = new decimal(lsTemp[index].Curve);
                txtSubParte1.Text = Conversions.ToString(lsTemp[index].SubPart1);
                txtSubParte2.Text = Conversions.ToString(lsTemp[index].SubPart1);
                txtTextura1.Text = lsTemp[index].Texture1;
                txtTextura2.Text = lsTemp[index].Texture2;
                txtTextura3.Text = lsTemp[index].Texture3;
                txtTextura4.Text = lsTemp[index].Texture4;
                txtTextura5.Text = lsTemp[index].Texture5;
                txtTextura6.Text = lsTemp[index].Texture6;
                txtModelo.Text = lsTemp[index].MPet;
                var values = lsTemp[index].Values();
                if (lsTemp[index].Icon != "")
                {
                    carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + lsTemp[index].Icon + ".png");
                }
                Part part;
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
                    int itemType = (int)lsTemp[index].EquipmentCategory;
                    if (itemType > 7)
                    {
                        cbCategoria.SelectedIndex = unchecked((int)lsTemp[index].EquipmentCategory) - 2;
                    }
                    else if (unchecked(itemType < 6 && itemType < 7))
                    {
                        cbCategoria.SelectedIndex = (int)lsTemp[index].EquipmentCategory;
                    }
                    else
                    {
                        cbCategoria.SelectedIndex = -1;
                    }
                    var tipo = (int)lsTemp[index].PriceType;
                    cbPerso.Text = (lsTemp[index].Values().CharacterType).ToString();

                    switch (tipo)
                    {
                        case 0:
                        case 6:
                        case 32:
                        case 34:
                        case 2:
                        case 160:
                        case 96:
                            cbTipo.SelectedIndex = 2;
                            if (text == "2")
                            {
                                ckPSQ2.Checked = true;
                            }
                            break;
                        case 97:
                            cbTipo.SelectedIndex = 1;
                            break;
                        case 128:
                        case 129:
                            cbTipo.SelectedIndex = 3;
                            break;
                        case 33:
                        case 192:
                        case 1:
                            cbTipo.SelectedIndex = 1;
                            break;
                        default:
                            cbTipo.SelectedIndex = 0;
                            break;
                    }

                    ckRentalItem.Checked = lsTemp[index].RentPang > 0;
                    txtRentValue.Text = lsTemp[index].RentPang.ToString();
                    switch (text)
                    {

                        case "32":
                            ckNormal.Checked = true;
                            ckGift.Checked = false;//pode ser gift
                            break;
                        case "33":
                            ckNormal.Checked = true;
                            ckGift.Checked = true;
                            break;
                        case "1":
                            ckNormal.Checked = true;
                            break;
                        case "01":
                            ckNormal.Checked = true;
                            ckGift.Checked = true;
                            break;
                        case "2":
                            ckNormal.Checked = true;
                            break;
                        case "03":
                            ckNormal.Checked = true;
                            break;
                        case "13":
                            ckNew.Checked = true;
                            break;
                        case "23":
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
                    part = lsTemp[index];
                }
                string text2 = Conversions.ToString((int)part.DateStart.Day);
                string text3 = Conversions.ToString((int)part.DateStart.Month);
                string text4 = Conversions.ToString((int)part.DateStart.Year);
                string text5 = Conversions.ToString((int)part.DateStart.Hour);
                string text6 = Conversions.ToString((int)part.DateStart.Minute);
                string text7 = Conversions.ToString((int)part.DateStart.Second);
                part = null;
                Part part2 = lsTemp[index];
                string text8 = Conversions.ToString((int)part2.DateEnd.Day);
                string text9 = Conversions.ToString((int)part2.DateEnd.Month);
                string text10 = Conversions.ToString((int)part2.DateEnd.Year);
                string text11 = Conversions.ToString((int)part2.DateEnd.Hour);
                string text12 = Conversions.ToString((int)part2.DateEnd.Minute);
                string text13 = Conversions.ToString((int)part2.DateEnd.Second);
                part2 = null;
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
                int index2 = Conversions.ToInteger(Operators.AddObject(ListaItem.Rows[ListaItem.SelectedRows[0].Index].Cells[3].Value, 1));
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                ProjectData.ClearProjectError();
            }
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
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = false;
                    menuSalvarComo.Enabled = true;
                    menuTypeid.Enabled = true;
                    menuBackup.Enabled = true;
                    menuMassa.Enabled = true;
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
                    menuMassa.Enabled = true;
                    BtnCreateCopy.Enabled = true;
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
                    BtnCreateCopy.Enabled = false;
                    menuMassa.Enabled = true;
                }
                if (bwSalvar.IsBusy)
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
            //string img = Conversions.ToString(Util.getImage(txtTypeID.Text, txtIcone.Text));
            //PictureBox obj = imgIcone;
            //carregarImagem(img, ref obj);
            //imgIcone = obj;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/64";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bs.Filter = "";
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            salvarAlteracoes();
            if (string.IsNullOrEmpty(Arquivo))
            {
                Arquivo = "Part.iff";
            }
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            checked
            {
                lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
                var itemnew = new Part();

                var part = (Part)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)].Clone();
                itemnew = part;
                bool flag = false;
                uint pos = 0;
                uint serial = 0;
                while (!flag)
                {
                    serial++;
                    uint num3 = Conversions.ToUInteger(itemnew.newTypeid(pos, serial));
                    if (serial < 999)
                    {
                        if (!verificarTYPEID(num3))
                        {
                            flag = true;
                            itemnew.TypeID = Convert.ToUInt32(num3);
                        }
                        else
                        {
                            flag = false;
                        }
                        continue;
                    }
                    MessageBox.Show("Não foi possivel gerar um novo ID unico para o item automaticamente, tenta novamente ou faça manualmente!", "Erro ao gerar um novo ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                }
                try
                {
                    lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), itemnew);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), part);
                    ProjectData.ClearProjectError();
                }
                CarregarGrid(lsTemp);
            }
        }

        private void salvarAlteracoes()
        {
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            checked
            {
                if (ckAtivo.Checked)
                {
                    lsTemp[index].Enabled = (byte)Conversions.ToLong("&H01");
                }
                else
                {
                    lsTemp[index].Enabled = (byte)Conversions.ToLong("&H00");
                }

                switch (cbTipo.SelectedIndex)
                {
                    case 0:
                        lsTemp[index].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H00");
                        break;
                    case 1:
                        lsTemp[index].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H01");
                        if (ckNormal.Checked & ckGift.Checked)
                        {
                            lsTemp[index].PriceType = ShopFlag.Unknown33;
                            lsTemp[index].MoneyFlag = (MoneyFlag.None);
                        }
                        break;
                    case 2:
                        lsTemp[index].PriceType = (ShopFlag)(byte)Conversions.ToLong("&H02");
                        if (ckNormal.Checked & ckGift.Checked)
                        {
                            lsTemp[index].PriceType = ShopFlag.Unknown32;
                            lsTemp[index].MoneyFlag = (MoneyFlag.None);
                        }
                        break;
                }

                if (ckRentalItem.Checked)
                {
                    lsTemp[index].RentPang = (uint)Conversions.ToLong(txtRentValue.Text);
                }
                else
                {
                    lsTemp[index].RentPang = (uint)Conversions.ToLong(txtRentValue.Text);
                }

                lsTemp[index].MoneyFlag = (MoneyFlag)(byte)0;
                if (ckNew.Checked & ckGift.Checked)
                {
                    lsTemp[index].MoneyFlag = (MoneyFlag.Active);
                    lsTemp[index].PriceType = ShopFlag.Unknown33;
                }
                else if (ckNew.Checked)
                {
                    lsTemp[index].MoneyFlag = MoneyFlag.BannerNew;
                }
                if (ckHot.Checked & ckGift.Checked)
                {
                    lsTemp[index].MoneyFlag = MoneyFlag.BannerHot;
                }
                else if (ckHot.Checked)
                {
                    lsTemp[index].MoneyFlag = MoneyFlag.BannerHot;
                }
                if (ckNormal.Checked & ckGift.Checked)
                {
                    lsTemp[index].MoneyFlag = (MoneyFlag)(byte)0x21;
                    //convert em cookies, pois é uma combinação
                    if (cbTipo.SelectedIndex == 2)
                    {
                        cbTipo.SelectedIndex = 1;
                    }
                }
                else if (ckNormal.Checked)
                {
                    //convert em pangs
                    if (cbTipo.SelectedIndex == 1 && cbTipo.SelectedIndex == 0)
                    {
                        cbTipo.SelectedIndex = 2;
                    }
                    lsTemp[index].MoneyFlag = (MoneyFlag)(byte)0x20;
                }
                else if (ckPSQ.Checked)
                {
                    lsTemp[index].MoneyFlag = MoneyFlag.None;
                    lsTemp[index].PriceType = ShopFlag.NonGiftable;
                }
                else if (ckPSQ2.Checked)
                {
                    lsTemp[index].MoneyFlag = MoneyFlag.BannerNew;
                    lsTemp[index].PriceType = ShopFlag.Unknown03;
                }
                lsTemp[index].Name = txtNome.Text;
                lsTemp[index].ItemPrice = Conversions.ToUInteger(txtPreco.Text);
                lsTemp[index].TypeID = Conversions.ToUInteger(txtTypeID.Text);
                lsTemp[index].Icon = txtIcone.Text;
                lsTemp[index].MinLevel = (ItemLevelEnum)(byte)cbLevel.SelectedIndex;
                lsTemp[index].DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
                lsTemp[index].Power = Convert.ToByte(attForca.Value);
                lsTemp[index].Control = Convert.ToByte(attControle.Value);
                lsTemp[index].Impact = Convert.ToByte(attPrecisao.Value);
                lsTemp[index].Spin = Convert.ToByte(attSpin.Value);
                lsTemp[index].Curve = Convert.ToByte(attCurva.Value);
                lsTemp[index].PowerSlot = Convert.ToByte(att2Forca.Value);
                lsTemp[index].ControlSlot = Convert.ToByte(att2Controle.Value);
                lsTemp[index].ImpactSlot = Convert.ToByte(att2Precisao.Value);
                lsTemp[index].SpinSlot = Convert.ToByte(att2Spin.Value);
                lsTemp[index].CurveSlot = Convert.ToByte(att2Curva.Value);

                lsTemp[index].SubPart1 = Conversions.ToUInteger(txtSubParte1.Text);
                lsTemp[index].SubPart2 = Conversions.ToUInteger(txtSubParte2.Text);
                lsTemp[index].Texture1 = txtTextura1.Text;
                lsTemp[index].Texture1 = txtTextura2.Text;
                lsTemp[index].Texture3 = txtTextura3.Text;
                lsTemp[index].Texture4 = txtTextura4.Text;
                lsTemp[index].Texture5 = txtTextura5.Text;
                lsTemp[index].Texture6 = txtTextura6.Text;
                lsTemp[index].MPet = txtModelo.Text;
                if (rbLevelMin.Checked)
                {
                    lsTemp[index].MinLevel = (ItemLevelEnum)(byte)cbLevel.SelectedIndex;
                }
                else
                {
                    lsTemp[index].MinLevel = (ItemLevelEnum)(byte)(Conversions.ToLong("&H80") + cbLevel.SelectedIndex);
                }
                if (cbCategoria.SelectedIndex == 0)
                {
                    lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H01");
                }
                else if (cbCategoria.SelectedIndex == 1)
                {
                    lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H02");
                }
                else
                {
                    lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H03");
                }
                switch (cbCategoria.SelectedIndex)
                {
                    case 0:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H00");
                        break;
                    case 1:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H01");
                        break;
                    case 2:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H02");
                        break;
                    case 3:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H03");
                        break;
                    case 4:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H04");
                        break;
                    case 5:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H05");
                        break;
                    case 6:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H08");
                        break;
                    case 7:
                        lsTemp[index].EquipmentCategory = (byte)Conversions.ToLong("&H09");
                        break;
                }

                if (ckTempoAtivo.Checked)
                {
                    Part item = this.lsTemp[index];
                    item.DateEnd.Day = (ushort)this.dtTermino.Value.Day;
                    item.DateEnd.Month = (ushort)this.dtTermino.Value.Month;
                    item.DateEnd.Year = (ushort)this.dtTermino.Value.Year;
                    item.DateEnd.Hour = (ushort)this.dtTermino.Value.Hour;
                    item.DateEnd.Minute = (ushort)this.dtTermino.Value.Minute;
                    item.DateEnd.Second = (ushort)this.dtTermino.Value.Second;
                    item.Active_Item_Time = 1;
                    item = null;
                    Part item2 = this.lsTemp[index];
                    item2.DateStart.Day = (ushort)this.dtInicio.Value.Day;
                    item2.DateStart.Month = (ushort)this.dtInicio.Value.Month;
                    item2.DateStart.Year = (ushort)this.dtInicio.Value.Year;
                    item2.DateStart.Hour = (ushort)this.dtInicio.Value.Hour;
                    item2.DateStart.Minute = (ushort)this.dtInicio.Value.Minute;
                    item2.DateStart.Second = (ushort)this.dtInicio.Value.Second;

                    item2 = null;
                }
                ListaItem.SelectedRows[0].Cells[1].Value = txtNome.Text;
                ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
                Alterado = false;
                qtdItem = ListaItem.Rows.Count;
            }
        }

        private void Alterou()
        {
            Alterado = true;
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

        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                ckHot.Checked = false;

                ckNormal.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNormal.Checked)
            {
                ckHot.Checked = false;
                ckNew.Checked = false;
                ckDesativado.Checked = false;
            }
        }

        private void ckHot_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHot.Checked)
            {
                ckNew.Checked = false;
                ckNormal.Checked = false;
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
                ckNew.Enabled = false;
                ckNormal.Enabled = false;
                ckHot.Enabled = false;
                ckGift.Enabled = false;
            }
            else
            {

                ckNew.Checked = true;
                ckHot.Checked = true;
                ckGift.Checked = false;
                ckNew.Enabled = true;
                ckNormal.Enabled = true;
                ckHot.Enabled = true;
                ckGift.Enabled = true;
                ckNormal.Checked = true;
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            Part part = new Part
            {
                Name = "[NOVO ITEM]"
            };
            part.CreateNewItem();
            bool flag = false;
#pragma warning disable CS0219 // A variável "num" é atribuída, mas seu valor nunca é usado
            int num = 0;
#pragma warning restore CS0219 // A variável "num" é atribuída, mas seu valor nunca é usado
            int num2 = 0;
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            checked
            {
                while (!flag)
                {
                    num2++;
                    var TypeIDValues = IFFHandleExtension.GetTypeIDValues(lsTemp[index].TypeID);
                    var ItemSerial = TypeIDValues.Serial;
                    var ItemGroup = TypeIDValues.Group;
                    var ItemType = TypeIDValues.Type;
                    var ItemPos = TypeIDValues.Pos;
                    ItemSerial = TypeIDValues.Serial;
                    var PartCharacter = TypeIDValues.CharacterType;

                    uint num3 = IFFHandleExtension.GenerateNewTypeID(2, (int)PartCharacter, ItemPos, ItemGroup, ItemType, ItemSerial);
                    if (num2 < 999)
                    {
                        if (!verificarTYPEID(num3))
                        {
                            flag = true;
                            part.TypeID = num3;
                        }
                        else
                        {
                            flag = false;
                        }
                        continue;
                    }
                    MessageBox.Show("Não foi possivel gerar um novo ID unico para o item automaticamente, tenta novamente ou faça manualmente!", "Erro ao gerar um novo ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                }
                try
                {
                    lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex + 1, part);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex, part);
                    ProjectData.ClearProjectError();
                }
                lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
                CarregarGrid(lsTemp);
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
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            caminho = Conversions.ToString((int)diagSalvarArquivo.ShowDialog());
            Arquivo = diagSalvarArquivo.FileName;
            if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
            {
                bs.Filter = "";
                ComboBox1.SelectedIndex = 0;
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
                if (MessageBox.Show("Existem alterações que não foram salvas, desaja salva-las agora?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    salvarAlteracoes();
                }
                else
                {
                    Alterado = false;
                }
            }
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            gbTempoVenda.Enabled = ckTempoAtivo.Checked;
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            frmPartTypeid2.Show();
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
            lbStatus.Text = "parado";
            btnSalvar.Enabled = true;
            ToolStrip1.Enabled = true;
            lbIndices.Text = Conversions.ToString(qtdItem);
            nomeArquivo();
        }

        public void salvar(BackgroundWorker BW)
        {

            var bck = Path.GetFileNameWithoutExtension(Arquivo) + ".bak";
            lsItens.IffSave(Directory.GetCurrentDirectory() + "\\backup_iffs\\" + bck, false);
            lsTemp.IffSave(Directory.GetCurrentDirectory() + "\\new_iffs\\" + Path.GetFileName(Arquivo), false);
            lsTemp.IffSave(Arquivo, false);
            FrmMain.IFF.Update = true;
        }


        private void ToolStripButton4_Click(object sender, EventArgs e)
        {

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
                    int num = 0;
                    num = ((ComboBox2.SelectedIndex == 1) ? 1 : 0);
                    if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex == 14 ? ComboBox1.SelectedIndex : ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex == 14 ? ComboBox1.SelectedIndex : ComboBox1.SelectedIndex - 1);
                    }
                    else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
                    }
                    else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex == 14 ? ComboBox1.SelectedIndex : ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Conversions.ToString(num);
                    }
                    else if (txtPesquisa.Text.Length > 0)
                    {
                        bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
                    }
                    else if (ComboBox1.SelectedIndex > 0)
                    {
                        bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex == 14 ? ComboBox1.SelectedIndex : ComboBox1.SelectedIndex - 1);
                    }
                    else if (ComboBox2.SelectedIndex > 0)
                    {
                        bs.Filter = "Status2 = " + Conversions.ToString(num);
                    }
                    else
                    {
                        bs.Filter = "";
                    }
                    Label33.Text = Conversions.ToString(bs.Count);
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
            if (ComboBox2.SelectedIndex == 0)
            {
            }
            else if (ComboBox2.SelectedIndex == 1)
            {
            }
            else
            {
            }
        }

        private void method_0(object sender, EventArgs e)
        {
            //MyProject.Forms.frmPartMassaPreco.Show();
        }

        private void DividirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void UnirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void ListaItem_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            pintarLinhas();
        }

        private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain.frmPart = this;
            new DlgMassaDesconto().Show();
            FrmMain.frmPart = this;
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
            foreach (Part item in lsTemp)
            {
                if (item.TypeID == typeid)
                {
                    if (frmPartTypeid2.NewItemTypeID != 0)
                    {
                        item.TypeID = frmPartTypeid2.NewItemTypeID;
                        frmPartTypeid2.NewItemTypeID = 0;
                        frmPartTypeid2.Hide();
                    }
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

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (verificarTYPEID())
            {
                MessageBox.Show("Este TYPEID já está em uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID disponível para uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void MenuAtivarTodosPSQ_Click(object sender, EventArgs e)
        {
            filtrar();
            if (bs.Count > 0)
            {
                for (int i = 0; i < bs.Count; i++)
                {
                    var index = Convert.ToInt32(ListaItem.Rows[i].Cells[0].Value);
                    var entry = lsTemp[index];

                    if (entry.Name.Contains("Game Pot"))
                    {
                        entry.PriceType = 0;
                        entry.MoneyFlag = 0;
                        entry.DiscountPrice = 0;
                        entry.ItemPrice = 0;
                    }
                    else if (entry.Icon != "" && entry.PriceType == 0 && entry.Name.Contains("Game Pot") == false)
                    {
                        if (entry.Personal_Shop_Active())
                        {

                        }
                    }
                    if (entry.DiscountPrice >= 58928)
                    {
                        entry.DiscountPrice = 0;
                    }
                }
                MessageBox.Show("Todos os itens listados na barra de pequisa \nforam ativados no personal shop com suceso !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pintarLinhas();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ItemCopy.Show();
            BtnCopyResult.Visible = true;
            BtnCopyResult.Enabled = true;
        }

        private void copyResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" deseja criar um novo id para o item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && ItemCopy.copied && frmPartTypeid2.NewItemTypeID == 0 && ItemCopy.oIff_Copy_List.Count == 0)
            {
                ToolStripButton3_Click(sender, e);
            }
            if (MessageBox.Show("Deseja copia o item selecionado?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && ItemCopy.copied && frmPartTypeid2.NewItemTypeID != 0 && ItemCopy.oIff_Copy_List.Count == 0)
            {
                var part = new Part();

                part.SetValue(ItemCopy.oIff_Copy);
                part.TypeID = frmPartTypeid2.NewItemTypeID;
                lastRow = ListaItem.SelectedCells[0].RowIndex + 1;
                var itemnew = part;
                try
                {
                    lsTemp.Add(itemnew);
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), part);
                    ProjectData.ClearProjectError();
                }
                BtnCopyResult.Visible = false;
                FirstLoadGrid(lsTemp);
            }
            if (MessageBox.Show("Deseja copia os itens selecionados?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes && ItemCopy.copied && ItemCopy.oIff_Copy_List.Count > 0)
            {
                for (int i = 0; i < ItemCopy.oIff_Copy_List.Count; i++)
                {
                    var part = new Part();
                    part.SetValue(ItemCopy.oIff_Copy_List[i]);
                    part.TypeID = ItemCopy.oIff_Copy_List[i].TypeID;
                    var itemnew = part;
                    try
                    {
                        lsTemp.Add(itemnew);
                    }
                    catch (Exception projectError)
                    {
                        ProjectData.SetProjectError(projectError);
                        lsTemp.Add(itemnew);
                        ProjectData.ClearProjectError();
                    }
                }
                ItemCopy.oIff_Copy_List.Clear();
                BtnCopyResult.Visible = false;
                FirstLoadGrid(lsTemp);
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
        }

        private void AtivarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtrar();
            if (bs.Count > 0)
            {
                for (int i = 0; i < bs.Count; i++)
                {
                    var index = Convert.ToInt32(ListaItem.Rows[i].Cells[0].Value);
                    if (lsTemp[index].Icon != "" && lsTemp[index].RentPang == 0 && lsTemp[index].PriceType == 0)
                    {
                        if ((lsTemp[index].TypeID != 134242460) || (lsTemp[index].TypeID != 134496450) || (lsTemp[index].TypeID != 134758496) || (lsTemp[index].TypeID != 135020731) || (lsTemp[index].TypeID != 135282841) || (lsTemp[index].TypeID != 135545039) || (lsTemp[index].TypeID != 135807197) || (lsTemp[index].TypeID != 136069229) || (lsTemp[index].TypeID != 136331425) || (lsTemp[index].TypeID != 136593667) || (lsTemp[index].TypeID != 136855606))
                        {
                            lsTemp[index].PriceType = ShopFlag.Active;
                            lsTemp[index].MoneyFlag = 0;
                            lsTemp[index].DiscountPrice = 0;
                            lsTemp[index].TimeFlag = 0x15;
                            if (lsTemp[index].ItemPrice >= 10000000)
                            {
                                lsTemp[index].ItemPrice = 99999;
                            }
                        }
                    }
                }
            }
            pintarLinhas();
            MessageBox.Show("Todos os itens listados na barra de pequisa \n foram ativados no shop !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirstLoadGrid(lsTemp);
        }

        private void DesativarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var count = lsTemp.Count;
            for (int i = 0; i < count; i++)
            {
                if (lsTemp[i].Enabled == 1)
                {
                    lsTemp[i].Enabled = 0;
                }
            }
            MessageBox.Show("Todos os itens foram desativados !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirstLoadGrid(lsTemp);
        }

        private void salvarTodosOsDaLisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaItem.RowCount > 1)
            {
                int num = ListaItem.RowCount - 1;
                string data = "";
                int num2 = 0;
                while (true)
                {
                    int num3 = num2;
                    int num4 = num;
                    if (num3 > num4)
                    {
                        break;
                    }


                    var test = lsTemp[Conversions.ToInteger(ListaItem.Rows[num2].Cells[0].Value)];
                    data += ($"\nItemName: {test.Name}, TypeID: {test.TypeID}");
                    num2++;
                }
                File.WriteAllText("ItemList.txt", data);
            }
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
