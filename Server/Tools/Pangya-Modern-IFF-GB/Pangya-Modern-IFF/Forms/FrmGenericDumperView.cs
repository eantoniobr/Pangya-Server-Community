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

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmGenericDumperView : Form
    {
        public FrmGenericDumperView()
        {
            InitializeComponent();
        }

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
			{
				return;
			}
			lsTemp = new List<IFFCommon>();
			Arquivo = diagAbrirArquivo.FileName;
			try
			{
				PangyaBinaryReader Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(diagAbrirArquivo.FileName)));
				var Header = (IFFHeader)Reader.Read(new IFFHeader());
				long recordLength = (Reader.GetSize() - 8L) / Header.Count;
				for (int i = 0; i < Header.Count; i++)
				{
				 Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
					var item = new IFFCommon();
					item.Load(ref Reader, 1);
					lsTemp.Add(item);
				}
				qtdItem = Header.Count;
				nomeArquivo();
				ListaItem.DataSource = null;
				FirstLoadGrid(lsTemp);
				lbIndices.Text = Conversions.ToString(qtdItem);
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

		private void FirstLoadGrid(List<IFFCommon> Lista)
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
					Image image = (this.oIff.Enabled != 1) ? Properties.Resources.delete1 : Properties.Resources.accept1;
					Image image2 = Properties.Resources.eye__minus;
					var tipo = (int)oIff.PriceType;

					num2 = 0;

#pragma warning disable CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado
					int num4 = 0;
#pragma warning restore CS0219 // A variável "num4" é atribuída, mas seu valor nunca é usado

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

		public void CarregarGrid(List<IFFCommon> Lista)
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
				txtIndex.Text = Conversions.ToString(lsTemp[index].Name);
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
	}
}
