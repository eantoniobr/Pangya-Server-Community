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
using System.IO;
using System.Windows.Forms;
using PangyaAPI.IFF.StructModels;
using System.Runtime.InteropServices;
using PangyaAPI.Utilities.BinaryModels;
using PangyaAPI.ZIP;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmBinEditor : Form
    {
		private FrmConfigShitList FrmConfig;
		private int int_0 =0;
		private int int_1 =0;
		public FrmBinEditor()
        {
            InitializeComponent();
			FrmConfig = new FrmConfigShitList();
		}

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
			{
				return;
			}
			lsTemp = new List<string>();
			Arquivo = diagAbrirArquivo.FileName;

			var string_0 = Path.GetTempFileName();
			bool flag = false;
			using (var file = ZipFile.Read(diagAbrirArquivo.FileName))
			{
				if (File.Exists(string_0))
				{
					File.Delete(string_0);
				}
				file.ExtractSelectedEntries("contents.dat", null, Path.GetTempPath(), ExtractExistingFileAction.OverwriteSilently);
				if (File.Exists(Path.GetTempPath() + @"\contents.dat"))
				{
					File.Move(Path.GetTempPath() + @"\contents.dat", string_0);
					flag = true;
				}
			}
			try
			{
				if (flag)
				{
					this.method_2();
					PangyaBinaryReader reader = new PangyaBinaryReader(File.Open(string_0, FileMode.Open, FileAccess.Read));
					byte[] buffer = new byte[reader.BaseStream.Length];
					for (int i = 0; i < reader.BaseStream.Length; i++)
					{
						buffer[i] = reader.ReadByte();
					}
					reader.Close();
					this.method_0(ref buffer);
					int num2 = 0;
					for (int j = int_1; j < buffer.Length; j += int_0)
					{
						string item = System.Text.Encoding.GetEncoding(932).GetString(buffer, j, this.int_0 - 1).Replace("\0", "");
						this.lsTemp.Add(item);
						num2++;
					}
					this.Text = $"Pangya Editor Word - Chat/Nick Bin ({num2} words)";
				}
				qtdItem = lsTemp.Count;
				nomeArquivo();
				ListaItem.DataSource = null;
				FirstLoadGrid(lsTemp);
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

        private void method_2()
        {
			this.int_0 = FrmConfig.int_0;
			this.int_1 = FrmConfig.int_1;
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
		private void method_0(ref byte[] byte_0)
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				byte_0[i] = (byte)(0xff - byte_0[i]);
			}
		}
		private void FirstLoadGrid(List<string> Lista)
		{
			DataTable table = new DataTable();
			table.Columns.Add("ID", typeof(int));
			table.Columns.Add("Text", typeof(string));
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
					
					num2 = 0;

#pragma warning disable CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado
					int num4 = 0;
#pragma warning restore CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado

					table.Rows.Add(num3, oIff, num6);
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
								return;
							}
							this.ListaItem.Rows[num5].Selected = false;
							num5++;

							organizarColunas();
							filtrar();
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

		public void CarregarGrid(List<string> Lista)
		{
			new List<string>();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Text", typeof(string));
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
					dataTable.Rows.Add(num3, oIff, num6);
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
			if (ListaItem.SelectedCells[0].RowIndex > -1)
			{
				int index = Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
				txtIndex.Text = Conversions.ToString(lsTemp[index]);
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
				if (ListaItem.SelectedRows.Count > 1)
				{
					gbBotoes.Enabled = true;
					tabForm.Enabled = false;
					txtPesquisa.Enabled = false;
					
				}
				else if (ListaItem.SelectedCells[0].RowIndex >= 0)
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

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
			FrmConfig.Show();
			btnAbrirArquivo.Enabled = true;
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
				lsTemp[index] = txtIndex.Text;

				ListaItem.SelectedRows[0].Cells[1].Value = txtIndex.Text;
				ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
				Alterado = false;
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

		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
			{
				return;
			}
			string part = "NEW WORD TEXT";
#pragma warning disable CS0219 // A variável "flag" é atribuída, mas seu valor nunca é usado
			bool flag = false;
#pragma warning restore CS0219 // A variável "flag" é atribuída, mas seu valor nunca é usado
			checked
			{
				
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

        private void btnSalvar_Click(object sender, EventArgs e)
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
			lbStatus.Text = "parado";
			ToolStrip1.Enabled = true;
			lbIndices.Text = Conversions.ToString(qtdItem);
			nomeArquivo();
		}

		public void salvar(BackgroundWorker BW)
		{
			this.method_2();
			string tempFileName = Path.GetTempFileName();
			if (File.Exists(tempFileName))
			{
				File.Delete(tempFileName);
			}
			byte[] buffer = new byte[(this.lsTemp.Count * this.int_0) + this.int_1];
			using (BinaryWriter writer = new BinaryWriter(File.Open(tempFileName, FileMode.Create, FileAccess.Write), System.Text.Encoding.GetEncoding(0x36a)))
			{
				writer.Write(buffer);
				writer.Seek(0, SeekOrigin.Begin);
				ushort num = ushort.Parse(this.lsTemp.Count.ToString());
				writer.Write(num);
				writer.Seek(this.int_1, SeekOrigin.Begin);
				foreach (string str2 in this.lsTemp)
				{
					if (str2.Length >= this.int_0)
					{
						str2.Substring(0, this.int_0 - 1);
					}
					writer.Write(str2.ToCharArray());
					writer.Seek(this.int_0 - str2.Length, SeekOrigin.Current);
				}
			}
			this.method_1(tempFileName);
			using (ZipFile file = new ZipFile(diagSalvarArquivo.FileName))
			{
				string path = Path.GetTempPath() + @"\contents.dat";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				File.Move(tempFileName, path);
				file.AddFile(path, string.Empty);
				file.Save();
				File.Delete(path);
			}
			
		}
		private void method_1(string string_1)
		{
			BinaryReader reader = new BinaryReader(File.Open(string_1, FileMode.Open, FileAccess.Read));
			byte[] buffer = new byte[reader.BaseStream.Length ];
			for (int i = 0; i < reader.BaseStream.Length; i++)
			{
				buffer[i] = reader.ReadByte();
			}
			reader.Close();
			this.method_0(ref buffer);
			BinaryWriter writer = new BinaryWriter(File.Open(string_1, FileMode.Create, FileAccess.Write));
			foreach (byte num2 in buffer)
			{
				writer.Write(num2);
			}
			writer.Close();
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
				ToolStrip1.Enabled = false;
				bs.Filter = "";
				pbStatus.Style = ProgressBarStyle.Marquee;
				bwSalvar.RunWorkerAsync();
			}
		}
    }
}
