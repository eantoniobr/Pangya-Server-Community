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
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
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
namespace Pangya_Modern_Editor.Forms.Editors.Special
{
    public partial class FrmGrandPrixData : Form
    {
        public FrmGrandPrixData()
        {
            InitializeComponent();
        }
        public FrmGrandPrixData(IFFFile<GrandPrixData> GP)
        {
            bs = new BindingSource();
            InitializeComponent();
            ConfigureTimePickers();
            for (int i = 0; i < GP.Count; i++)
            {
                var item = GP[i];
                item.FixBug();
                GP[i] = item;
            }
            this.lsItens = GP;
        }

        private void FrmGrandPrixData_Load(object sender, EventArgs e)
        {
            if (lsItens != null)
            {
                this.lsTemp = this.lsItens;
                this.Arquivo = "GrandPrixData.iff";
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
                this.CarregarGrid(lsTemp);
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<GrandPrixData>();
                this.lsTemp = new IFFFile<GrandPrixData>();
                this.Arquivo = this.diagAbrirArquivo.FileName;

                try
                {
                    this.lsItens = new IFFFile<GrandPrixData>(Arquivo);
                    //for (int i = 0; i < lsItens.Count; i++)
                    //{
                    //    var item = lsItens[i];
                    //    if (string.IsNullOrEmpty(item.Event_Icon))
                    //    {
                    //        Debug.WriteLine($"GP ID: {item.ID}");
                    //        Debug.WriteLine($"GP Open: {item.Open.GPToString()}, GP Start: {item.Start.GPToString()}, GP End: {item.End.GPToString()}");
                    //        Debug.WriteLine("");
                    //    }
                    //}
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

        public void CarregarGrid(IFFFile<GrandPrixData> Lista)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Status", typeof(Image));
            dataTable.Columns.Add("Alterado", typeof(int));
            dataTable.Columns.Add("Page", typeof(int));
            int num3 = 0;
            foreach (var item in Lista)
            {
                oIff = item;

                Image image = ((oIff.Active) ? Resources.BtnRemove_Mini : Resources.BtnApply_Mini);
                if (Lista.Count(c => c.ID == item.ID) > 1)
                    image = Resources.BtnRemove_Mini;
                int num6 = 0;
                try
                {

                    if (ListaItem.Rows.Count > num3 && ListaItem["Alterado", num3].Value != null)
                    {
                        num6 = Convert.ToInt32(ListaItem["Alterado", num3].Value);
                    }
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    num6 = 0;
                    ProjectData.ClearProjectError();
                }

                dataTable.Rows.Add(num3, oIff.Name, oIff.ID, image, num6, (int)oIff.TypeGP + 1);
                num3++;
            }
            ListaItem.DataSource = null;
            bs = new BindingSource
            {
                DataSource = dataTable
            };
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

        public void AtualizarGrid(GrandPrixData item)
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
                    table.Columns.Add("Index", typeof(int));
                    table.Columns.Add("Item", typeof(string));
                    table.Columns.Add("ID", typeof(int));
                    table.Columns.Add("Status", typeof(Image));
                    table.Columns.Add("Alterado", typeof(int));
                    table.Columns.Add("Page", typeof(int));

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
                ? Resources.BtnRemove_Mini
                : Resources.BtnApply_Mini;

            // Adicionar valores específicos ao item
            int alterado = 0; // Ajustar se necessário
            int index = dataTable.Rows.Count; // O novo índice será o último da tabela

            // Verifique se a linha com o ID já existe
            var existingRow = dataTable.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("ID") == item.ID);

            if (existingRow == null)
            {
                // Adicione uma nova linha se a linha não existir
                var newRow = dataTable.NewRow();
                newRow["Index"] = index;
                newRow["Item"] = item.Name;
                newRow["ID"] = item.ID;
                newRow["Status"] = statusImage;
                newRow["Alterado"] = alterado;
                newRow["Page"] = (int)item.TypeGP; // Ajuste conforme necessário

                dataTable.Rows.Add(newRow);
            }

            // Atualize o contador total de itens
            lbTotalItens.Text = dataTable.Rows.Count.ToString();

            // Aplicar estilo e filtros adicionais
            organizarColunas(); // Ajuste conforme a necessidade
            filtrar(); // Ajuste conforme a necessidade
            pintarLinhas(); // Ajuste conforme a necessidade

            // Garantir que a nova linha seja visível
            if (ListaItem.Rows.Count > 0)
            {
                ListaItem.FirstDisplayedScrollingRowIndex = ListaItem.Rows.Count - 1;
                ListaItem.Rows[ListaItem.Rows.Count - 1].Selected = true;
            }
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


        public void organizarColunas()
        {
            ListaItem.Columns[2].Width = 0x2d;
            ListaItem.Columns[3].Width = 30;
            ListaItem.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[3].HeaderText = "   ";

            ListaItem.Columns[0].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[5].Visible = false;
            ListaItem.Columns[1].Visible = false;
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
            try
            {
                if (ListaItem.SelectedCells[0].RowIndex != -1)
                {
                    int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
                    lbIndices.Text = index.ToString();
                    var item = lsTemp[index];
                    ckAtivo.Checked = item.Active;
                    txtNome.Text = Conversions.ToString(item.Name);
                    txtTypeID.Text = Conversions.ToString(item.ID);
                    txtItemProdQtd.Value = new decimal(item.reward.GetQuantity());
                    txtIndex.Text = Convert.ToString(item.TypeID_Link);
                    ckNatural.Checked = item.flag.Natural_Mode;
                    ckShot.Checked = item.flag.Shot_Mode;
                    cbMap.SelectedItem = GetMap(item.course_info.Course);
                    cbMode.SelectedIndex = (int)item.course_info.Modo;
                    cbHoleSize.SelectedIndex = item.flag.Hole_cup_x2;
                    txtRule.Text = item.rule.ToString();
                    cbClass.Text = item._class.ToString();
                    txtLocker.Checked = item.Lock_YN > 0;
                    txtUn.Text = item.Unknown0.ToString();
                    txtUn1.Text = item.Unknown1.ToString();
                    txtClearGP.Text = item.Clear_GP_TypeID.ToString();
                    txtLevelMin.Text = item.MinLevel.ToString();
                    txtLevelMax.Text = item.MaxLevel.ToString();
                    txtCondition0.Text = item.condition[0].ToString();
                    txtCondition1.Text = item.condition[1].ToString();
                    nmrPangReward.Value = item.pang;
                    txtImage.Text = item.Event_Icon;
                    var typeGP = item.TypeGP;
                    switch (typeGP)
                    {
                        case 0:
                            cbAba.SelectedIndex = 0;
                            break;
                        case 1:
                            cbAba.SelectedIndex = 1;
                            break;
                        case 2:
                            cbAba.SelectedIndex = 2;
                            break;
                        case 3:
                            cbAba.SelectedIndex = 3;
                            break;
                        default:
                            cbAba.SelectedItem = null;
                            break;
                    }
                    txtTimeHole.Text = item.TimeHole.ToString();
                    txt_Ticket_TypeID.Text = item.ticket._typeid.ToString();
                    txt_Ticket_Qntd.Text = item.ticket.qntd.ToString();
                    txtScore1.Text = item.bot.ScoreBotMin.ToString();
                    txtScore2.Text = item.bot.ScoreBotMed.ToString();
                    txtScore3.Text = item.bot.ScoreBotMax.ToString();
                    var rank = sIff.getInstance().FindGrandPrixRankReward(item.TypeID_Link); 
                    if (rank != null)
                    {
                        // Rank 1 (Índice 0)
                        if (rank.Count > 0)
                            txtTrophyIDOne.Text = rank[0].Trophy.ToString();
                        else
                            txtTrophyIDOne.Text = "0";
                        // Rank 2 (Índice 1)
                        if (rank.Count > 1)
                            txtTrophyIDTwoo.Text = rank[1].Trophy.ToString();
                        else
                            txtTrophyIDTwoo.Text = "0";
                        // Rank 3 (Índice 2)
                        if (rank.Count > 2)
                            txtTrophyIDTree.Text = rank[2].Trophy.ToString();
                        else
                            txtTrophyIDTree.Text = "0";
                    }
                    txtInfo.Text = item.Info;
                    txtItem1.Text = Conversions.ToString(item.reward._typeid[0]);
                    txtItem2.Text = Conversions.ToString(item.reward._typeid[1]);
                    txtItem3.Text = Conversions.ToString(item.reward._typeid[2]);
                    txtItem4.Text = Conversions.ToString(item.reward._typeid[3]);
                    txtItem5.Text = Conversions.ToString(item.reward._typeid[4]);
                    txtItem1Qtd.Text = Conversions.ToString(item.reward.qntd[0]);
                    txtItem2Qtd.Text = Conversions.ToString(item.reward.qntd[1]);
                    txtItem3Qtd.Text = Conversions.ToString(item.reward.qntd[2]);
                    txtItem4Qtd.Text = Conversions.ToString(item.reward.qntd[3]);
                    txtItem5Qtd.Text = Conversions.ToString(item.reward.qntd[4]);
                    switch (item.course_info.Qntd_hole)
                    {
                        case 3:
                            cbTotalHole.SelectedIndex = 0;
                            break;
                        case 6:
                            cbTotalHole.SelectedIndex = 1;
                            break;
                        case 9:
                            cbTotalHole.SelectedIndex = 2;
                            break;
                        case 12:
                            cbTotalHole.SelectedIndex = 3;
                            break;
                        case 18:
                            cbTotalHole.SelectedIndex = 4;
                            break;
                        default:
                            cbTotalHole.SelectedIndex = -1;
                            break;
                    }
                    dtAbre.Value = item.Open.TimeGP;
                    dtInicio.Value = item.Start.TimeGP;
                    dtTermino.Value = item.End.TimeGP;
                    if (item.Check())
                    {
                        ckTempoAtivo.Checked = true;
                    }
                    else
                    {
                        ckTempoAtivo.Checked = false;
                    }
                    imgMap.Image = Util.getImage(GetIconMap(item.course_info.Course));

                    var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txt_Ticket_TypeID.Text));
                    if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
                    {
                        imgTicketID.Image = Util.getImage(iffCommon.ShopIcon);
                    }
                }
            }
            catch (Exception projectError2)
            {
                ProjectData.SetProjectError(projectError2);
                ProjectData.ClearProjectError();
            }

        }

        private string GetIconMap(uint mapId)
        {
            switch (GetMap(mapId))
            {
                case "Blue Lagoon":
                case "Blue Water":
                case "Blue Moon":
                case "Sepia Wind":
                case "Wind Hill":
                case "Wiz Wiz":
                case "West Wiz":
                case "Silva Canoon":
                case "White Wiz":
                    return $"room_map_0{mapId}"; //outros
                case "Shining Sand":
                    return $"room_map_09"; //outros
                case "Ice Canoon":
                    return $"room_map_10"; //outros
                case "Pink Wind":
                case "Deep Inferno":
                case "Ice Spa":
                case "Lost Seaway":
                case "Eastern Valley":
                case "Special Shuffle":
                case "Ice Inferno":
                case "Wiz City":
                case "Abbot Mine":
                case "Mystic Ruins":
                case "Grand Zodiac":
                case "Random":
                    return $"room_map_{mapId}"; //outros
                default:
                    return $"room_map_127"; //padrao
            }
        }
        private string GetMap(uint mapId)
        {
            switch (mapId)
            {
                case 0:
                    return "Blue Lagoon";
                case 1u:
                    return "Blue Water";
                case 2u:
                    return "Sepia Wind";
                case 3u:
                    return "Wind Hill";
                case 4u:
                    return "Wiz Wiz";
                case 5u:
                    return "West Wiz";
                case 6u:
                    return "Blue Moon";
                case 7u:
                    return "Silva Canoon";
                case 8u:
                    return "Ice Canoon";
                case 9u:
                    return "White Wiz";
                case 10u:
                    return "Shining Sand";
                case 11u:
                    return "Pink Wind";
                case 13u:
                    return "Deep Inferno";
                case 14u:
                    return "Ice Spa";
                case 15u:
                    return "Lost Seaway";
                case 16u:
                    return "Eastern Valley";
                case 17u:
                    return "Special Shuffle";
                case 18u:
                    return "Ice Inferno";
                case 19u:
                    return "Wiz City";
                case 20u:
                    return "Abbot Mine";
                case 21u:
                    return "Mystic Ruins";
                case 64:
                    return "Grand Zodiac";
                case 127:
                    return "Random";
                default:
                    return "Unknown";
            }
        }

        private uint GetMapId(string mapName)
        {
            switch (mapName)
            {
                case "Blue Lagoon":
                    return 0u;
                case "Blue Water":
                    return 1u;
                case "Blue Moon":
                    return 6u;
                case "Sepia Wind":
                    return 2u;
                case "Wind Hill":
                    return 3u;
                case "Wiz Wiz":
                    return 4u;
                case "West Wiz":
                    return 5u;
                case "Silva Canoon":
                    return 7u;
                case "White Wiz":
                    return 9u;
                case "Shining Sand":
                    return 10u;
                case "Ice Canoon":
                    return 8u;
                case "Pink Wind":
                    return 11u;
                case "Deep Inferno":
                    return 13u;
                case "Ice Spa":
                    return 14u;
                case "Lost Seaway":
                    return 15u;
                case "Eastern Valley":
                    return 16u;
                case "Special Shuffle":
                    return 17u;
                case "Ice Inferno":
                    return 18u;
                case "Wiz City":
                    return 19u;
                case "Abbot Mine":
                    return 20u;
                case "Mystic Ruins":
                    return 21u;
                case "Grand Zodiac":
                    return 22u;
                case "Random":
                    return 23u;
                default:
                    return 0u; // Retorno padrão para "Unknown" ou valores não definidos
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
                    tabForm.Enabled = true;
                    txtPesquisa.Enabled = false;
                    btnNovo.Enabled = false;
                    btnBackup.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnReabrir.Enabled = true;
                    menuSalvarComo.Enabled = true;
                    menuBackup.Enabled = true;
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
                    CarregarItem();
                }
                else
                {
                    gbBotoes.Enabled = false;
                    tabForm.Enabled = false;
                    txtPesquisa.Enabled = false;
                    menuSalvarComo.Enabled = false;
                    menuBackup.Enabled = false;
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
                Arquivo = "GrandPrixData.iff";
            }
            btnSalvar.Enabled = false;
            ToolStrip1.Enabled = false;
            pbStatus.Style = ProgressBarStyle.Marquee;
            bwSalvar.RunWorkerAsync();
        }
        private void ConfigureTimePickers()
        {
            dtAbre.Format = DateTimePickerFormat.Time;
            dtAbre.ShowUpDown = true;
            dtInicio.Format = DateTimePickerFormat.Time;
            dtInicio.ShowUpDown = true;
            dtTermino.Format = DateTimePickerFormat.Time;
            dtTermino.ShowUpDown = true;
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            salvarAlteracoes();
            pintarLinhas();
            CarregarItem();
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

        private void salvarAlteracoes()
        {
            int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
            lsTemp[index].Active = (ckAtivo.Checked);
            lsTemp[index].Name = txtNome.Text;

            lsTemp[index].ID = uint.Parse(txtTypeID.Text);
            lsTemp[index].TypeID_Link = uint.Parse(txtIndex.Text);
            lsTemp[index].flag.Shot_Mode = ckShot.Checked;
            lsTemp[index].flag.Natural_Mode = ckNatural.Checked;
            lsTemp[index].course_info.Course = GetMapId(cbMap.Text);
            lsTemp[index].course_info.Modo = (uint)cbMode.SelectedIndex;
            lsTemp[index].flag.Hole_cup_x2 = (byte)cbHoleSize.SelectedIndex;

            lsTemp[index].TypeGP = (uint)cbAba.SelectedIndex;
            lsTemp[index].TimeHole = ushort.Parse(txtTimeHole.Text);
            lsTemp[index].ticket._typeid = uint.Parse(txt_Ticket_TypeID.Text);
            lsTemp[index].ticket.qntd = uint.Parse(txt_Ticket_Qntd.Text);
            lsTemp[index].bot.ScoreBotMin = int.Parse(txtScore1.Text);
            lsTemp[index].bot.ScoreBotMed = int.Parse(txtScore2.Text);
            lsTemp[index].bot.ScoreBotMax = int.Parse(txtScore3.Text);
            lsTemp[index].Info = txtInfo.Text;
            lsTemp[index].reward._typeid[0] = uint.Parse(txtItem1.Text);
            lsTemp[index].reward._typeid[1] = uint.Parse(txtItem2.Text);
            lsTemp[index].reward._typeid[2] = uint.Parse(txtItem3.Text);
            lsTemp[index].reward._typeid[3] = uint.Parse(txtItem4.Text);
            lsTemp[index].reward._typeid[4] = uint.Parse(txtItem5.Text);
            lsTemp[index].reward.qntd[0] = uint.Parse(txtItem1Qtd.Text);
            lsTemp[index].reward.qntd[1] = uint.Parse(txtItem2Qtd.Text);
            lsTemp[index].reward.qntd[2] = uint.Parse(txtItem3Qtd.Text);
            lsTemp[index].reward.qntd[3] = uint.Parse(txtItem4Qtd.Text);
            lsTemp[index].reward.qntd[4] = uint.Parse(txtItem5Qtd.Text);
            if (ckTempoAtivo.Checked)
            {
                if (lsTemp[index].Open.TimeGP != dtAbre.Value)
                    lsTemp[index].Open.TimeGP = dtAbre.Value;

                if (lsTemp[index].Start.TimeGP != dtInicio.Value)
                    lsTemp[index].Start.TimeGP = dtInicio.Value;

                if (lsTemp[index].End.TimeGP != dtTermino.Value)
                    lsTemp[index].End.TimeGP = dtTermino.Value;
                var item = lsTemp[index];
                item.FixBug();
                lsTemp[index] = item;
            }
            lsTemp[index].rule = uint.Parse(txtRule.Text);
            lsTemp[index]._class = Convert.ToUInt32(cbClass.Text);
            lsTemp[index].TypeGP = Convert.ToUInt32(cbAba.SelectedIndex);
            lsTemp[index].Lock_YN = (uint)(txtLocker.Checked ? 1 : 0);
            lsTemp[index].Unknown0 = Convert.ToByte(txtUn.Text);
            lsTemp[index].Unknown1 = Convert.ToUInt32(txtUn1.Text);
            lsTemp[index].Clear_GP_TypeID = uint.Parse(txtClearGP.Text);
            lsTemp[index].MinLevel = Convert.ToByte(txtLevelMin.Text);
            lsTemp[index].MaxLevel = Convert.ToByte(txtLevelMax.Text);
            lsTemp[index].condition[0] = uint.Parse(txtCondition0.Text);
            lsTemp[index].condition[1] = uint.Parse(txtCondition1.Text);
            lsTemp[index].pang = (uint)(nmrPangReward.Value);
            lsTemp[index].Event_Icon = txtImage.Text;
            switch (cbTotalHole.SelectedIndex)
            {
                case 0:
                    lsTemp[index].course_info.Qntd_hole = 3;
                    break;
                case 1:
                    lsTemp[index].course_info.Qntd_hole = 6;
                    break;
                case 2:
                    lsTemp[index].course_info.Qntd_hole = 9;
                    break;
                case 3:
                    lsTemp[index].course_info.Qntd_hole = 12;
                    break;
                case 4:
                    lsTemp[index].course_info.Qntd_hole = 18;
                    break;
            }
            ListaItem.SelectedRows[0].Cells["Item"].Value = txtNome.Text;
            ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            ListaItem.SelectedRows[0].Cells["ID"].Value = txtTypeID.Text;  //seta novo Index   
            Alterado = false;
            qtdItem = ListaItem.Rows.Count;
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
                    int num = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(row.Cells[2].Value));
                    RemoverItem(lsTemp[num].ID);
                    lsTemp.Remove(lsTemp[num]);
                }
            }
            else
            {
                lastRow = ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Do you want to remove the item: ", ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int index = lsTemp.FindIndex(c => c.ID == Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[2].Value));
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
            try
            {
                GrandPrixData item = new GrandPrixData();
                item = item.CreateEvent();
                item.ID = item.CreateNewId(2 /*tipo do evento*/, 24 /*é 16+8?*/, 96 /*course ou diferente, não sei ainda, porem é 16?*/, (uint)new Random().Next(0, 15));
                lsTemp.Add(item);
                AtualizarGrid(item);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void MenuSalvar_Click(object sender, EventArgs e)
        {
            sfile = true;
            diagSalvarArquivo.ShowDialog();
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                GrandPrixData item = new GrandPrixData();
                try
                {
                    this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception local2 = ex;
                    this.lastRow = 0;
                    ProjectData.ClearProjectError();
                }
                item = this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value)];
                var last = this.lsTemp.LastOrDefault(c => c.TypeGP == item.TypeGP);
                item.ID = last.ID + 1;
                try
                {
                    this.lsTemp.Add(item);
                }
                catch (Exception exception3)
                {
                    Exception ex = exception3;
                    ProjectData.SetProjectError(ex);
                    this.lsTemp.Add(item);
                    ProjectData.ClearProjectError();
                }
                AtualizarGrid(item);
            }
        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            try
            {
                txtPesquisa = textBox1;
                int num = 0;
                num = (ComboBox2.SelectedIndex == 1) ? 1 : 0;
                if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0) && cbPage.SelectedIndex > -1)
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1).ToString() + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + (ComboBox1.SelectedIndex - 1);
                }
                else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Convert.ToString(num);
                }
                else if ((cbPage.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
                {
                    bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (cbPage.SelectedIndex > 0))
                {
                    bs.Filter = "Personagem = " + Convert.ToString(ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Convert.ToString(num) + " AND Page = " + Convert.ToString(cbPage.SelectedIndex);
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
                else if (cbPage.SelectedIndex > 0)
                {
                    bs.Filter = "Page = " + Convert.ToString(cbPage.SelectedIndex);
                }
                else if (bs.Count == 0)
                {
                    bs.Filter = "";
                }
                else
                {
                    bs.Filter = "";
                }
                lblSearchCount.Text = Convert.ToString(bs.Count);
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
            //PictureBox obj = imgResultado;
            //var iffCommon = (IFFCommon)sIff.getInstance().FindCommonItem(uint.Parse(txtTypeID.Text));
            //if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
            //{
            //                    obj.Image = Util.getImage(iffCommon.ShopIcon);
            //}
            //imgResultado = obj;
        }

        private void txtItem1_TextChanged(object sender, EventArgs e)
        {

            PictureBox obj = img1;
            var iffCommon = sIff.getInstance().FindCommonItem(uint.Parse(txtItem1.Text));
            if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
            {
                obj.Image = Util.getImage(iffCommon.ShopIcon);
            }
            img1 = obj;
        }

        private void txtItem2_TextChanged(object sender, EventArgs e)
        {
            PictureBox obj = img2;
            var iffCommon = (IFFCommon)sIff.getInstance().FindCommonItem(uint.Parse(txtItem2.Text));
            if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
            {
                obj.Image = Util.getImage(iffCommon.ShopIcon);
            }
            img2 = obj;
        }

        private void txtItem3_TextChanged(object sender, EventArgs e)
        {
            //string img = Conversions.ToString(Util.getImage(txtItem3.Text));
            PictureBox obj = img3;
            var iffCommon = (IFFCommon)sIff.getInstance().FindCommonItem(uint.Parse(txtItem3.Text));
            if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
            {
                obj.Image = Util.getImage(iffCommon.ShopIcon);
            }
            img3 = obj;
        }

        private void txtItem4_TextChanged(object sender, EventArgs e)
        {
            //string img = Conversions.ToString(Util.getImage(txtItem4.Text));
            PictureBox obj = img4;
            var iffCommon = (IFFCommon)sIff.getInstance().FindCommonItem(uint.Parse(txtItem4.Text));
            if (!string.IsNullOrEmpty(iffCommon.ShopIcon))
            {
                obj.Image = Util.getImage(iffCommon.ShopIcon);
            }
            img4 = obj;
        }

        private void txtItem1Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes1.Text = Conversions.ToString(txtItem1Qtd.Value);
        }

        private void txtItem2Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes2.Text = Conversions.ToString(txtItem2Qtd.Value);
        }

        private void txtItem3Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes3.Text = Conversions.ToString(txtItem3Qtd.Value);
        }

        private void txtItem4Qtd_ValueChanged(object sender, EventArgs e)
        {
            txtRes4.Text = Conversions.ToString(txtItem4Qtd.Value);
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/64";
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
                        string rowData = $"{row.Cells[2].Value},{row.Cells[2].Value}";
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
                        string idStr = _line.Substring(0, spaceIndex).Trim();  //old
                        string item = _line.Substring(spaceIndex).Trim();           //new

                        // Verifica se o Index é um número válido
                        if (uint.TryParse(idStr, out uint id))
                        {
                            // Busca o índice do item na lista lstTemp com base no Index
                            int rowIndex = lsTemp.FindIndex(c => c.ID == id);
                            if (rowIndex != -1)
                            {
                                if (rowIndex < ListaItem.RowCount && uint.TryParse(item, out uint nr_id))
                                {
                                    // Atualiza o DataGridView
                                    ListaItem[2, rowIndex].Value = nr_id;
                                    lsTemp[rowIndex].ID = nr_id;
                                }
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

                lbStatus.Text = "Stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while pasting the data: " + ex.Message, "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lbStatus.Text = "Stop";
            pintarLinhas();
        }


        public string CreateNewId(uint eventType, uint classAb, uint configType, uint sequenceId)
        {
            // Validação dos parâmetros
            if (eventType > 3)
                throw new ArgumentOutOfRangeException(nameof(eventType), "eventType deve estar entre 0 e 3.");
            if (classAb < 1 || classAb > 255)
                throw new ArgumentOutOfRangeException(nameof(classAb), "classAb deve estar entre 0 e 255.");
            if (configType > 255)
                throw new ArgumentOutOfRangeException(nameof(configType), "configType deve estar entre 0 e 255.");
            if (sequenceId > 15)
                throw new ArgumentOutOfRangeException(nameof(sequenceId), "sequenceId deve estar entre 0 e 15.");

            // Criação do ID
            uint id = 0;

            // Adiciona a parte (1) - evento e tipo (4 bits totais)
            id |= (eventType & 0x3) << 24;  // 2 bits para evento e 2 bits para tipo

            // Adiciona a parte (2) - classe "Aba" (8 bits)
            id |= (classAb & 0xFF) << 16;

            // Adiciona a parte (3) - tipo de configuração (8 bits)
            id |= (configType & 0xFF) << 8;

            // Adiciona a parte (4) - sequência ou horário (4 bits)
            id |= (sequenceId & 0xF);

            return id.ToString();
        }

        private void txtImage_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImage.Text))
                imgEvent.Image = Util.getImage(txtImage.Text);
        }

        private void cbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtTypeID.Text) && lsTemp.Any(c => c.ID.ToString() == txtTypeID.Text))
            //    imgMap.Image = Util.getImage(GetIconMap(lsTemp.First(c => c.ID.ToString() == txtTypeID.Text).course_info.Course)); 
        }
    }
}
