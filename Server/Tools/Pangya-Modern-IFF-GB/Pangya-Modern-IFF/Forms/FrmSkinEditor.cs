using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.Collections;
using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Resources = PangyaSuiteFiles.Properties.Resources;
namespace PangyaSuiteFiles.Forms
{
	public partial class FrmSkinEditor : Form
	{
		public bool IsLoad { get; private set; }

		public FrmSkinEditor()
		{
			InitializeComponent();
		}

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0 && IsLoad == false)
			{
				return;
			}

			this.lsItens = new SkinCollection();
			this.lsTemp = new SkinCollection();
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
			if (Strings.Len(Arquivo) > 25)
			{
				lbArquivo.Text = "..." + Arquivo.Substring(checked(Strings.Len(Arquivo) - num), num);
			}
			else
			{
				lbArquivo.Text = Arquivo;
			}
		}

		public void CarregarGrid(SkinCollection Lista)
		{
			new List<string>();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Item", typeof(string));
			dataTable.Columns.Add("Status", typeof(Image));
			dataTable.Columns.Add("Personagem", typeof(string));
			dataTable.Columns.Add("Status2", typeof(string));
			dataTable.Columns.Add("Tipo", typeof(Image));
			dataTable.Columns.Add("Alterado", typeof(int));
			int num = 0;
			int num2 = 0;
			checked
			{
				int num3 = Lista.Count - 1;
				int num4 = 0;
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					oIff = Lista[num4];
					Image image = ((oIff.Enabled != 1) ? Resources.delete1 : Resources.accept1);
					Image image2 = ((oIff.PriceType == (ShopFlag)1) ? Resources.points : (((int)oIff.PriceType != 2) ? Resources.eye__minus : Resources.Pang));
					num2 = 0;
					int num7 = 0;
					try
					{
						num7 = Conversions.ToInteger(ListaItem["Alterado", num].Value);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						num7 = 0;
						ProjectData.ClearProjectError();
					}
					dataTable.Rows.Add(num4, oIff.Name.Replace("\0", ""), image, num2, oIff.Enabled, image2, num7);
					num++;
					num4++;
				}
				ListaItem.DataSource = null;
				bs = new BindingSource();
				bs.DataSource = dataTable;
				ListaItem.DataMember = dataTable.TableName;
				ListaItem.DataSource = bs;
				lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);
				ListaItem.Columns[0].Width = 45;
				ListaItem.Columns[2].Width = 30;
				ListaItem.Columns[5].Width = 30;
				ListaItem.Columns[0].ValueType = typeof(int);
				ListaItem.Columns[2].HeaderText = "   ";
				ListaItem.Columns[5].HeaderText = "   ";
				int num8 = ListaItem.Rows.Count - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num6 = num8;
					if (num10 > num6)
					{
						break;
					}
					ListaItem.Rows[num9].Selected = false;
					num9++;
				}
				ListaItem.Columns[3].Visible = false;
				ListaItem.Columns[4].Visible = false;
				ListaItem.Columns[6].Visible = false;
				filtrar();
				try
				{
					ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
					ListaItem.Rows[lastRow].Selected = true;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				pintarLinhas();
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
				txtSprite1.Text = lsTemp[index].MPet;
				txtPrice1Day.Text = Conversions.ToString((int)lsTemp[index].Price1Day);
				txtPrice7Day.Text = Conversions.ToString((int)lsTemp[index].Price7Day);
				txtPrice15Day.Text = Conversions.ToString((int)lsTemp[index].Price15Day);
				txtPrice30Day.Text = Conversions.ToString((int)lsTemp[index].Price30Day);
				txtPrice365Day.Text = Conversions.ToString((int)lsTemp[index].Price365Day);
				if (lsTemp[index].Icon != "")
				{
					carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + lsTemp[index].Icon + ".png");
				}
				Skin skin;
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
					string text = ((int)lsTemp[index].MoneyFlag).ToString();
					var tipo = (int)lsTemp[index].PriceType;
					var flag = lsTemp[index].GetFlagShop();
					cbTipo.SelectedIndex = flag.is_cash == true ? 1 : 2;

					if (text == "0")
					{
						text = tipo.ToString();
					}
					switch (text)
					{

						case "32":
							ckNormal.Checked = true;
							break;
						case "33":
							ckNormal.Checked = true;
							ckGift.Checked = true;
							break;
						case "1":
							ckNormal.Checked = true;
							//if (tipo == 33)//é cookie, então posso dizer que ele é new
							//{
							//	ckGift.Checked = true;

							//}
							//if (tipo == 32)//é pang, ele desativa o gift, então posso dizer que ele é normal new, ou sei la
							//{
							//	ckGift.Checked = false;
							//}
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
					skin = lsTemp[index];
				}
				string text2 = Conversions.ToString((int)skin.DateStart.Day);
				string text3 = Conversions.ToString((int)skin.DateStart.Month);
				string text4 = Conversions.ToString((int)skin.DateStart.Year);
				string text5 = Conversions.ToString((int)skin.DateStart.Hour);
				string text6 = Conversions.ToString((int)skin.DateStart.Minute);
				string text7 = Conversions.ToString((int)skin.DateStart.Second);
				skin = null;
				Skin skin2 = lsTemp[index];
				string text8 = Conversions.ToString((int)skin2.DateEnd.Day);
				string text9 = Conversions.ToString((int)skin2.DateEnd.Month);
				string text10 = Conversions.ToString((int)skin2.DateEnd.Year);
				string text11 = Conversions.ToString((int)skin2.DateEnd.Hour);
				string text12 = Conversions.ToString((int)skin2.DateEnd.Minute);
				string text13 = Conversions.ToString((int)skin2.DateEnd.Second);
				skin2 = null;
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
					dtInicio.Value = DateAndTime.Now.AddYears(-3);
					dtTermino.Value = DateAndTime.Now.AddYears(-3);
					ProjectData.ClearProjectError();
				}
				if ((DateTime.Compare(result, DateAndTime.Now) < 0) & (DateTime.Compare(result2, DateAndTime.Now) > 0))
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

		private void carregarImagem(string img, ref PictureBox obj)
		{
			try
			{
				obj.Image = Resources.ajax_loader;
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
				obj.Image = Resources._error;
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

		private void txtIcone_TextChanged(object sender, EventArgs e)
		{
			//string img = Conversions.ToString(Util.getImage(txtTypeID.Text, txtIcone.Text));
			//PictureBox obj = imgIcone;
			//carregarImagem(img, ref obj);
			//imgIcone = obj;
		}

		private void txtNome_TextChanged(object sender, EventArgs e)
		{
			lbContNome.Text = Conversions.ToString(txtNome.Text.Length) + "/40";
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

				lsTemp[index].Name = txtNome.Text;
				lsTemp[index].ItemPrice = Conversions.ToUInteger(txtPreco.Text);
				lsTemp[index].TypeID = Conversions.ToUInteger(txtTypeID.Text);
				lsTemp[index].Icon = txtIcone.Text;
				lsTemp[index].MinLevel = (ItemLevelEnum)(byte)cbLevel.SelectedIndex;
				lsTemp[index].DiscountPrice = Conversions.ToUInteger(txtDesconto.Text);
				lsTemp[index].MPet = txtSprite1.Text;
				lsTemp[index].Flag_Roll = (ushort)Conversions.ToShort(txtAmmount.Text);
				lsTemp[index].Price1Day = (ushort)Conversions.ToShort(txtPrice1Day.Text);
				lsTemp[index].Price7Day = (ushort)Conversions.ToShort(txtPrice7Day.Text);
				lsTemp[index].Price15Day = (ushort)Conversions.ToShort(txtPrice15Day.Text);
				lsTemp[index].Price30Day = (ushort)Conversions.ToShort(txtPrice30Day.Text);
				lsTemp[index].Price365Day = (ushort)Conversions.ToShort(txtPrice365Day.Text);

				if (rbLevelMin.Checked)
				{
					lsTemp[index].MinLevel = (ItemLevelEnum)(byte)cbLevel.SelectedIndex;
				}
				else
				{
					lsTemp[index].MinLevel = (ItemLevelEnum)(byte)(Conversions.ToLong("&H80") + cbLevel.SelectedIndex);
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
				if (ckTempoAtivo.Checked)
				{
					Skin skin = lsTemp[index];
					skin.DateEnd.Day = (ushort)dtTermino.Value.Day;
					skin.DateEnd.Month = (ushort)dtTermino.Value.Month;
					skin.DateEnd.Year = (ushort)dtTermino.Value.Year;
					skin.DateEnd.Hour = (ushort)dtTermino.Value.Hour;
					skin.DateEnd.Minute = (ushort)dtTermino.Value.Minute;
					skin.DateEnd.Second = (ushort)dtTermino.Value.Second;
					skin.Active_Item_Time = 1;
					skin = null;
					Skin skin2 = lsTemp[index];
					skin2.DateStart.Day = (ushort)dtInicio.Value.Day;
					skin2.DateStart.Month = (ushort)dtInicio.Value.Month;
					skin2.DateStart.Year = (ushort)dtInicio.Value.Year;
					skin2.DateStart.Hour = (ushort)dtInicio.Value.Hour;
					skin2.DateStart.Minute = (ushort)dtInicio.Value.Minute;
					skin2.DateStart.Second = (ushort)dtInicio.Value.Second;
					skin2 = null;
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
			checked
			{
				if (MessageBox.Show("Deseja adicionar um novo item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					Skin skin = new Skin();
					skin.Name = "[NOVO ITEM]";
					skin.CreateNewItem();
					Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value);
					try
					{
						lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex + 1, skin);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						lsTemp.Insert(ListaItem.SelectedCells[0].RowIndex, skin);
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
				Skin skin = new Skin();
				lastRow = checked(ListaItem.SelectedCells[0].RowIndex + 1);
				skin = (Skin)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)].Clone();
				try
				{
					lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), skin);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), skin);
					ProjectData.ClearProjectError();
				}
				CarregarGrid(lsTemp);
			}
		}

		private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
		{
			gbTempoVenda.Enabled = ckTempoAtivo.Checked;
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
			imgPersonagem.Image = ImageList1.Images[ComboBox1.SelectedIndex];
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
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Conversions.ToString(num);
					}
					else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex - 1);
					}
					else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
					}
					else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
					{
						bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex - 1) + " AND Status2 = " + Conversions.ToString(num);
					}
					else if (txtPesquisa.Text.Length > 0)
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
					}
					else if (ComboBox1.SelectedIndex > 0)
					{
						bs.Filter = "Personagem = " + Conversions.ToString(ComboBox1.SelectedIndex - 1);
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
				imgStatus.Image = ImageList2.Images[0];
			}
			else if (ComboBox2.SelectedIndex == 1)
			{
				imgStatus.Image = ImageList2.Images[1];
			}
			else
			{
				imgStatus.Image = ImageList2.Images[2];
			}
		}

		private void ListaItem_Sorted(object sender, EventArgs e)
		{
			pintarLinhas();
		}

		private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			foreach (Skin item in lsTemp)
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

		private void FrmSkinEditor_Load(object sender, EventArgs e)
		{
			this.lsItens = FrmMain.IFF.Skin;
			this.lsTemp = new SkinCollection();
			this.Arquivo = this.diagAbrirArquivo.FileName;
			this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
			lsTemp.Header = lsItens.Header;
			this.nomeArquivo();
			this.ListaItem.DataSource = null;
			this.FirstLoadGrid(this.lsTemp);
			this.lbIndices.Text = this.lsItens.Count.ToString();
			IsLoad = true;
		}

		private void FirstLoadGrid(SkinCollection Lista)
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
		private void GroupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void activeAllItensToolStripMenuItem_Click(object sender, EventArgs e)
		{
			filtrar();
			if (bs.Count > 0)
			{
				for (int i = 0; i < bs.Count; i++)
				{
					var index = Convert.ToInt32(ListaItem.Rows[i].Cells[0].Value);
					if (lsTemp[index].Icon != "" && lsTemp[index].PriceType == 0)
					{
						if ((lsTemp[index].TypeID != 134242460) || (lsTemp[index].TypeID != 134496450) || (lsTemp[index].TypeID != 134758496) || (lsTemp[index].TypeID != 135020731) || (lsTemp[index].TypeID != 135282841) || (lsTemp[index].TypeID != 135545039) || (lsTemp[index].TypeID != 135807197) || (lsTemp[index].TypeID != 136069229) || (lsTemp[index].TypeID != 136331425) || (lsTemp[index].TypeID != 136593667) || (lsTemp[index].TypeID != 136855606))
						{
							lsTemp[index].MoneyFlag = (MoneyFlag.Active);
							lsTemp[index].PriceType = ShopFlag.Unknown33;
							lsTemp[index].DiscountPrice = 0;
							if (lsTemp[index].ItemPrice >= 10000000)
							{
								lsTemp[index].ItemPrice = 99999;
							}
						}
					}

				}
				pintarLinhas();
				MessageBox.Show("Todos os itens listados na barra de pequisa \n foram ativados no shop !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
				FirstLoadGrid(lsTemp);
			}
		}
	}
	}