using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Models;
using PangyaSuiteFiles.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
namespace PangyaSuiteFiles.Forms
{
    public partial class FrmDescEditor : Form
    {
		public int PositionKey;
		public int PostionClickMouse;
        public FrmDescEditor()
        {
            InitializeComponent();
        }

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
			{
				return;
			}
			lsItens = new DescCollection();
			lsTemp = new DescCollection();
			Arquivo = diagAbrirArquivo.FileName;
			try
			{
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
				return;
			}
			lsItens = new DescCollection();
			checked
			{
				int num = lsItens.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					oIff = new Desc();
					lsItens.Add(oIff);
					num2++;
				}
				lsTemp.AddRange(lsItens.GetRange(0, lsItens.Count));
				nomeArquivo();
				ListaItem.DataSource = null;
				CarregarGrid(lsTemp);
				lbIndices.Text = Conversions.ToString(qtdItem);
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

		public void CarregarGrid(DescCollection Lista)
		{
			new List<string>();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("TypeID", typeof(int));
			dataTable.Columns.Add("Status", typeof(Image));
			dataTable.Columns.Add("Alterado", typeof(int));
			int num = 0;
			checked
			{
				int num2 = Lista.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					oIff = Lista[num3];
					Image accept = Resources.accept1;
					int num6 = 0;
					try
					{
						num6 = Conversions.ToInteger(ListaItem["Alterado", num].Value);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						num6 = 0;
						ProjectData.ClearProjectError();
					}
					dataTable.Rows.Add(num3, oIff.TypeID, accept, num6);
					num++;
					num3++;
				}
				ListaItem.DataSource = null;
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
		}

		public void organizarColunas()
		{
			ListaItem.Columns[1].Width = 45;
			ListaItem.Columns[2].Width = 30;
			ListaItem.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			ListaItem.Columns[0].ValueType = typeof(int);
			ListaItem.Columns[2].HeaderText = "   ";
			ListaItem.Columns[0].Visible = false;
			ListaItem.Columns[3].Visible = false;
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
			if (ListaItem.SelectedCells[0].RowIndex > -1)
			{
				int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
				txtTypeID.Text = Conversions.ToString(lsTemp[index].TypeID);
				txtIndex.MaxLength = 512;
				txtIndex.Text = Conversions.ToString(lsTemp[index].Description);

			}
			Alterado = false;
			try
			{
				Conversions.ToInteger(Operators.AddObject(ListaItem.Rows[ListaItem.SelectedRows[0].Index].Cells[3].Value, 1));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		private void carregarImagem(string img, ref PictureBox obj)
		{
			try
			{
				obj.ImageLocation = Application.StartupPath + "\\Cache\\ajax-loader.gif";
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				obj.ImageLocation = img;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				obj.ImageLocation = Application.StartupPath + "\\Cache\\error.png";
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
					CarregarItem();
				}
				else
				{
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
			catch (Exception projectError)
			{
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
				index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			lsTemp[index].TypeID = Conversions.ToUInteger(txtTypeID.Text);
			lsTemp[index].Description = txtIndex.Text;
			try
			{
				ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
				ListaItem.SelectedRows[0].Cells["TypeID"].Value = txtTypeID.Text;
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
			checked
			{
				if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					Desc item = new Desc();
					Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
					try
					{
						lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex + 1, item);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex, item);
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
		}

		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			caminho = Conversions.ToString((int)diagSalvarArquivo.ShowDialog());
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

		private void frmPart_Load(object sender, EventArgs e)
		{
			checked
			{
				if (Operators.CompareString(Arquivo, "", TextCompare: false) != 0)
				{
					try
					{
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						Interaction.MsgBox("Tipo de arquivo desconhecido");
						ProjectData.ClearProjectError();
						return;
					}
					lsItens = new DescCollection();
					int num = lsItens.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						oIff = new Desc();
						lsItens.Add(oIff);
						num2++;
					}
					lsTemp.AddRange(lsItens.GetRange(0, lsItens.Count));
					int num5 = 25;
					if (Arquivo.Length > 25)
					{
						lbArquivo.Text = "..." + Arquivo.Substring(Arquivo.Length - num5, num5);
					}
					else
					{
						lbArquivo.Text = Arquivo;
					}
					ListaItem.DataSource = null;
					CarregarGrid(lsTemp);
					lbIndices.Text = Conversions.ToString(qtdItem);
				}
				ComboBox1.SelectedIndex = 0;
			}
		}

		private void btnBackup_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				Desc Desc = new Desc();
				try
				{
					lastRow = checked(ListaItem.SelectedCells[0].RowIndex + 1);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					lastRow = 0;
					ProjectData.ClearProjectError();
				}
				Desc = (Desc)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];
				try
				{
					lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), Desc);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), Desc);
					ProjectData.ClearProjectError();
				}
				CarregarGrid(lsTemp);
			}
		}

		private void ToolStripButton2_Click(object sender, EventArgs e)
		{
			caminho = Conversions.ToString((int)diagSalvarSql.ShowDialog());
			Arquivo = diagSalvarSql.FileName;
			if (Operators.CompareString(Arquivo, null, TextCompare: false) != 0)
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

		private void ToolStripButton3_Click(object sender, EventArgs e)
		{
			//frmPartTypeid frmPartTypeid2 = new frmPartTypeid();
			//frmPartTypeid2.Show();
		}

		private void frmPart_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bwGerarSql.IsBusy | bwSalvar.IsBusy)
			{
				MessageBox.Show("Existem tarefas ainda em execução, é necessário aguardar o término destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Cancel = true;
			}
		}

		private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			if (backgroundWorker.CancellationPending)
			{
				e.Cancel = true;
			}
		}

		private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbStatus.Value = e.ProgressPercentage;
			lbStatus.Text = "Gerando arquivo SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
		}

		private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			pbStatus.Value = 0;
			btnSalvar.Enabled = true;
			ToolStrip1.Enabled = true;
			lbStatus.Text = "parado";
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

		private void method_0(object sender, EventArgs e)
		{
		}

		private void ListaItem_Sorted(object sender, EventArgs e)
		{
			organizarColunas();
			pintarLinhas();
		}

		private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
		{
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

		private void btnCima_Click(object sender, EventArgs e)
		{
			alterarPos(1);
		}

		public void alterarPos(int Valor)
		{
			checked
			{
				if (ListaItem.SelectedRows.Count > 0)
				{
					Desc Desc = new Desc();
					int num;
					try
					{
						num = ListaItem.SelectedRows[0].Index;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						num = 0;
						ProjectData.ClearProjectError();
					}
					Desc = (Desc)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];
					lsTemp.Remove(lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)]);
					try
					{
						lsTemp.Insert(num - Valor, Desc);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						lsTemp.Insert(num, Desc);
						ProjectData.ClearProjectError();
					}
					lastRow = ListaItem.SelectedRows[0].Index - Valor;
					CarregarGrid(lsTemp);
				}
				else
				{
					ListaItem.Rows[0].Selected = true;
				}
			}
		}

		private void btnBaixo_Click(object sender, EventArgs e)
		{
			alterarPos(-1);
		}

        private void FrmDescEditor_Load(object sender, EventArgs e)
        {
			this.lsItens = FrmMain.IFF.Desc;
			this.lsTemp = new DescCollection();
			this.Arquivo = "Desc.iff";
			this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
			lsTemp.Header = lsItens.Header;
			this.nomeArquivo();
			this.ListaItem.DataSource = null;
			this.FirstLoadGrid(this.lsTemp);
			this.lbIndices.Text = this.lsItens.Count.ToString();
		}

		private void FirstLoadGrid(DescCollection Lista)
		{
			DataTable table = new DataTable();
			table.Columns.Add("ID", typeof(int));
			table.Columns.Add("TypeID", typeof(int));
			table.Columns.Add("Status", typeof(Image));
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
					Image accept = Resources.accept1;


#pragma warning disable CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado
					int num4 = 0;
#pragma warning restore CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado

					table.Rows.Add(num3, oIff.TypeID, accept, 0);
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
						organizarColunas();
						filtrar();
						int num7 = this.ListaItem.Rows.Count - 1;
						int num5 = 0;
						
						while (true)
						{
							num8 = num7;
							if (num5 > num8)
							{
								organizarColunas();
								filtrar();
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
			organizarColunas();
			filtrar();
		}

        private void menuSalvarComo_Click(object sender, EventArgs e)
        {
			caminho = Conversions.ToString((int)diagSalvarArquivo.ShowDialog());
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
				int Posicao = txtIndex.SelectionStart;
				var txt = txtIndex.Text;
				this.txtIndex.Text = txt.Insert(Posicao, @"\c0x" + ColorToHexString(dialog.Color) + @"FF\c ");
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


        private void txtIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
