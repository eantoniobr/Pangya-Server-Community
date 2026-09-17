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
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmAbilityEditor : Form
    {
        public bool IsLoad;

        public FrmAbilityEditor()
        {
            InitializeComponent();
        }


        private void FrmItemEditor_Load(object sender, EventArgs e)
        {
            this.lsItens = FrmMain.IFF.Ability;
            this.lsTemp = new AbilityCollection();
            this.Arquivo = this.diagAbrirArquivo.FileName;
            this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
            lsTemp.Header = lsItens.Header;
            this.nomeArquivo();
            this.ListaItem.DataSource = null;
            this.CarregarGrid(this.lsTemp);
            this.lbIndices.Text = this.lsItens.Count.ToString();
            IsLoad = true;
        }

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
			{
				return;
			}
			lsItens = new AbilityCollection();
			lsTemp = new AbilityCollection();
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
			lsItens = new AbilityCollection();
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
					oIff = new Ability();
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

		public void CarregarGrid(AbilityCollection Lista)
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

				var shoprare = lsTemp[index];
				var record = FrmMain.IFF.GetBase(shoprare.TypeID);
                if (record != null)
                {
					this.txtName.Text = record.Name;
				}
				txtTypeID.Text = lsTemp[index].TypeID.ToString();
				nrAtivo1.Value = lsTemp[index].Effect_Active[0];
				nrAtivo2.Value = lsTemp[index].Effect_Active[1];
				nrAtivo3.Value = lsTemp[index].Effect_Active[2];
				txtFlagPercent1.Value = (uint)lsTemp[index].Effect_Flag[0];
				txtFlagPercent2.Value = (uint)lsTemp[index].Effect_Flag[1];
				txtFlagPercent3.Value = (uint)lsTemp[index].Effect_Flag[2];
				cbEfeito1.SelectedIndex = (int)lsTemp[index].Effect_Type[0];
				cbEfeito2.SelectedIndex = (int)lsTemp[index].Effect_Type[1];
				cbEfeito3.SelectedIndex = (int)lsTemp[index].Effect_Type[2];
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
				if (bwSalvar.IsBusy)
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

			//lsTemp[index].TypeID = Conversions.ToUInteger(this.txtTypeID.Text);
			//lsTemp[index].ItemType = (FilterType)Conversions.ToUInteger(this.cbItemType.SelectedValue);
			//lsTemp[index].RareType = (MemorialRareType)Conversions.ToUInteger(this.cbTipoCoin.Text);
			//lsTemp[index].Probabilities = Conversions.ToUInteger(this.txtProbs.Text);
			//lsTemp[index].Count = Conversions.ToUInteger(this.txtCounter.Text);
			//lsTemp[index].Number = (uint)Conversions.ToUInteger(this.txtNumber.Text);
			try
			{
				ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
				ListaItem.SelectedRows[0].Cells["Index"].Value = txtName.Text;
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
					Ability item = new Ability();
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
				Ability Ability = new Ability();
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
				Ability = (Ability)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];
				try
				{
					lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), Ability);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), Ability);
					ProjectData.ClearProjectError();
				}
				CarregarGrid(lsTemp);
			}
		}

		private void ToolStripButton3_Click(object sender, EventArgs e)
		{
			//frmPartTypeid frmPartTypeid2 = new frmPartTypeid();
			//frmPartTypeid2.Show();
		}

		private void frmPart_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bwSalvar.IsBusy)
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

		private void ToolStripButton4_Click(object sender, EventArgs e)
		{

		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			filtrar();
		}

		public void filtrar()
		{
			try
			{
				checked
				{
					try
					{
#pragma warning disable CS0219 // A variável "num" é atribuída, mas seu valor nunca é usado
						int num = 0;						
#pragma warning restore CS0219 // A variável "num" é atribuída, mas seu valor nunca é usado
						 if (txtPesquisa.Text.Length > 0)
						{
							bs.Filter = "TypeID LIKE '%" + txtPesquisa.Text + "%'";
						}						
						else
						{
							bs.Filter = "";
						}
						Label33.Text = Conversions.ToString(bs.Count);
						organizarColunas();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
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


		private void FrmMemorialShopCoinEditor_Load(object sender, EventArgs e)
		{
			this.lsItens = FrmMain.IFF.Ability;
			this.lsTemp = new AbilityCollection();
			this.Arquivo = this.diagAbrirArquivo.FileName;
			this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
			lsTemp.Header = lsItens.Header;
			this.nomeArquivo();
			this.ListaItem.DataSource = null;
			this.FirstLoadGrid(this.lsTemp);
			this.lbIndices.Text = this.lsItens.Count.ToString();
		}


		private void FirstLoadGrid(AbilityCollection Lista)
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
					Image image = Properties.Resources.accept1;
					table.Rows.Add(num3, oIff.TypeID, image, num6);
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
						this.ListaItem.Columns[0].ValueType = typeof(int);
						this.ListaItem.Columns[2].HeaderText = "   ";
						int num7 = this.ListaItem.Rows.Count - 1;
						int num5 = 0;
						this.ListaItem.Columns[3].Visible = false;
						while (true)
						{
							num8 = num7;
							if (num5 > num8)
							{
								this.ListaItem.Columns[3].Visible = false;

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
	}
}
