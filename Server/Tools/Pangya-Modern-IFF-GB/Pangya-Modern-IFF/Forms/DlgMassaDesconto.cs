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
	public partial class DlgMassaDesconto : Form
	{
		public DlgMassaDesconto()
		{
			InitializeComponent();
		}

		private void DlgMassaDesconto_Load(object sender, EventArgs e)
		{
            this.Top = FrmMain.frmPart.Top;
            this.Left = FrmMain.frmPart.Left + FrmMain.frmPart.Width;
        }
		private void btnAplicar_Click(object sender, EventArgs e)
		{
			Verificar(simular: false);
		}

		public void Aplicar(ref Part Item)
		{
			int selectedIndex = cbOperacao.SelectedIndex;
			double num = Item.ItemPrice;
			switch (selectedIndex)
			{
				case 0:
					num += Conversions.ToDouble(txxtVariavel.Text);
					break;
				case 1:
					num -= Conversions.ToDouble(txxtVariavel.Text);
					break;
				case 2:
					num *= Conversions.ToDouble(txxtVariavel.Text);
					break;
				case 3:
					num /= Conversions.ToDouble(txxtVariavel.Text);
					break;
			}
			Item.ItemPrice = checked((uint)Math.Round(num));
		}

		public void Verificar(bool simular)
		{
			int num = -1;
			foreach (Part item in FrmMain.frmPart.lsTemp)
			{
				Part Item = item;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				num = checked(num + 1);
				if (ckStatus.Checked)
				{
					if (cbStatus.SelectedIndex >= 0)
					{
						int num2 = 0;
						num2 = (ckAtivo.Checked ? 1 : 0);
						if (cbStatus.SelectedIndex == 0)
						{
							if (Item.Enabled == num2)
							{
								flag = true;
							}
						}
						else if (Item.Enabled != num2)
						{
							flag = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (ckPreco.Checked)
				{
					if (cbPreco.SelectedIndex >= 0)
					{
						switch (cbPreco.SelectedIndex)
						{
							case 0:
								if ((double)Item.ItemPrice > Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
							case 1:
								if ((double)Item.ItemPrice >= Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
							case 2:
								if ((double)Item.ItemPrice < Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
							case 3:
								if ((double)Item.ItemPrice <= Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
							case 4:
								if ((double)Item.ItemPrice == Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
							case 5:
								if ((double)Item.ItemPrice != Conversions.ToDouble(txtPreco.Text))
								{
									flag2 = true;
								}
								break;
						}
					}
				}
				else
				{
					flag2 = true;
				}
				if (ckDesconto.Checked)
				{
					if (cbDesconto.SelectedIndex >= 0)
					{
						switch (cbDesconto.SelectedIndex)
						{
							case 0:
								if ((double)Item.DiscountPrice > Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
							case 1:
								if ((double)Item.DiscountPrice >= Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
							case 2:
								if ((double)Item.DiscountPrice < Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
							case 3:
								if ((double)Item.DiscountPrice <= Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
							case 4:
								if ((double)Item.DiscountPrice == Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
							case 5:
								if ((double)Item.DiscountPrice != Conversions.ToDouble(txtDesconto.Text))
								{
									flag3 = true;
								}
								break;
						}
					}
				}
				else
				{
					flag3 = true;
				}
				if (!ckTipo.Checked)
				{
					flag4 = true;
				}
				if (ckMoeda.Checked)
				{
					if (cbMoeda.SelectedIndex >= 0)
					{
						switch (cbMoeda.SelectedIndex)
						{
							case 0:
								if (Item.PriceType == (ShopFlag)cbMoeda2.SelectedIndex)
								{
									flag2 = true;
								}
								break;
							case 1:
								if (Item.PriceType != (ShopFlag)cbMoeda2.SelectedIndex)
								{
									flag2 = true;
								}
								break;
						}
					}
				}
				else
				{
					flag5 = true;
				}
				if (ckMarcacao.Checked)
				{
					string left = ((int)Item.MoneyFlag).ToString();
					if (cbMarcacao.SelectedIndex == 0)
					{
						switch (cbMarcacao2.SelectedIndex)
						{
							case 0:
								if (Operators.CompareString(left, "01", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 1:
								if (Operators.CompareString(left, "03", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 2:
								if (Operators.CompareString(left, "11", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 3:
								if (Operators.CompareString(left, "13", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 4:
								if (Operators.CompareString(left, "21", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 5:
								if (Operators.CompareString(left, "23", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
							case 6:
								if (Operators.CompareString(left, "00", TextCompare: false) == 0)
								{
									flag6 = true;
								}
								break;
						}
					}
					else if (cbMarcacao.SelectedIndex == 1)
					{
						switch (cbMarcacao2.SelectedIndex)
						{
							case 0:
								if (Operators.CompareString(left, "01", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 1:
								if (Operators.CompareString(left, "03", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 2:
								if (Operators.CompareString(left, "11", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 3:
								if (Operators.CompareString(left, "13", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 4:
								if (Operators.CompareString(left, "21", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 5:
								if (Operators.CompareString(left, "23", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
							case 6:
								if (Operators.CompareString(left, "00", TextCompare: false) != 0)
								{
									flag6 = true;
								}
								break;
						}
					}
				}
				else
				{
					flag6 = true;
				}
				if (ckPersonagem.Checked)
				{
					if (cbPersonagem.SelectedIndex >= 0)
					{
						uint personagem = Item.getPersonagem();
						switch (cbPersonagem2.SelectedIndex)
						{
							case 0:
								if (personagem == 0)
								{
									flag7 = true;
								}
								break;
							case 1:
								if (personagem == 1)
								{
									flag7 = true;
								}
								break;
							case 2:
								if (personagem == 2)
								{
									flag7 = true;
								}
								break;
							case 3:
								if (personagem == 3)
								{
									flag7 = true;
								}
								break;
							case 4:
								if (personagem == 4)
								{
									flag7 = true;
								}
								break;
							case 5:
								if (personagem == 5)
								{
									flag7 = true;
								}
								break;
							case 6:
								if (personagem == 6)
								{
									flag7 = true;
								}
								break;
							case 7:
								if (personagem == 7)
								{
									flag7 = true;
								}
								break;
							case 8:
								if (personagem == 8)
								{
									flag7 = true;
								}
								break;
							case 9:
								if (personagem == 9)
								{
									flag7 = true;
								}
								break;
						}
					}
				}
				else
				{
					flag7 = true;
				}
				if (!simular)
				{
					if (flag && flag2 && flag3 && flag4 && flag5 && flag6 && flag7)
					{
						Aplicar(ref Item);
						FrmMain.frmPart.ListaItem["Alterado", num].Value = 1;
					}
				}
				else if (flag && flag2 && flag3 && flag4 && flag5 && flag6 && flag7)
				{
					FrmMain.frmPart.ListaItem["Alterado", num].Value = 2;
				}
			}
			FrmMain.frmPart.CarregarGrid(FrmMain.frmPart.lsTemp);
			MessageBox.Show(Conversions.ToString(num) + " itens encontrados", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void btnSimular_Click(object sender, EventArgs e)
		{
			checked
			{
				int num = FrmMain.frmPart.ListaItem.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					FrmMain.frmPart.ListaItem.Rows[num2].Selected = false;
					num2++;
				}
				Verificar(simular: true);
			}
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			checked
			{
				int num = FrmMain.frmPart.ListaItem.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (Operators.ConditionalCompareObjectEqual(FrmMain.frmPart.ListaItem["Alterado", num2].Value, 2, TextCompare: false))
						{
							FrmMain.frmPart.ListaItem["Alterado", num2].Value = 0;
						}
						num2++;
						continue;
					}
					break;
				}
			}

		}
	}
}
