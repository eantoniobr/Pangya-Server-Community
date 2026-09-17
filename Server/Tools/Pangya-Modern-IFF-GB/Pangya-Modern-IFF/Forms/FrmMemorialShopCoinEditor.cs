using Microsoft.VisualBasic;
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
    public partial class FrmMemorialShopCoinEditor : Form
    {
        public FrmMemorialShopCoinEditor()
        {
            InitializeComponent();
        }

		private void btnAbrirArquivo_Click(object sender, EventArgs e)
		{
			if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || Operators.CompareString(diagAbrirArquivo.FileName, "", TextCompare: false) == 0)
			{
				return;
			}

			this.lsItens = new MemorialShopCoinItemCollection();
			this.lsTemp = new MemorialShopCoinItemCollection();
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

		public void CarregarGrid(MemorialShopCoinItemCollection Lista)
		{
			new List<string>();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Item", typeof(string));
			dataTable.Columns.Add("Status", typeof(Image));
			dataTable.Columns.Add("Personagem", typeof(string));
			dataTable.Columns.Add("Status2", typeof(string));
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
					Image accept = (this.oIff.Enable ==0) ? Properties.Resources.delete1 : Properties.Resources.accept1;
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
					var record = FrmMain.IFF.GetBase(oIff.TypeID);
					string Name = "Name Unknown";
					if (record != null)
					{
						Name = record.Name;
					}
					dataTable.Rows.Add(num3,  Name,accept, (int)oIff.ItemType, oIff.Enable, num6);
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
			this.ListaItem.Columns[0].Width = 0x2d;
			this.ListaItem.Columns[2].Width = 30;
			this.ListaItem.Columns[0].ValueType = typeof(int);
			this.ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
			ListaItem.Columns[5].Visible = false;
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
					this.txtIndex.Text = record.Name;
				}
				ckAtivo.Checked = lsTemp[index].Enable != 0? true: false;
				this.txtTypeID.Text = shoprare.TypeID.ToString();
				this.cbItemType.Text = shoprare.ItemType.ToString();
				this.cbTipoCoin.Text = shoprare.CoinType.ToString();
				this.txtProbs.Text = shoprare.Probabilities.ToString();
				this.txtCounter.Text = shoprare.NumberMax.ToString();
				this.txtNumber.Text = shoprare.Number.ToString();
				if (record != null && record.Icon != "")
				{
					carregarImagem(Directory.GetCurrentDirectory() + @"\Imagens\" + record.Icon + ".png");
				}
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
		private void carregarImagem(string path)
		{
			if (File.Exists(path))
			{
				this.imgResultado.Image = new Bitmap(path);
			}
			else
			{
				imgResultado.Image = Resources.ajax_loader;
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
			ComboBox1.SelectedIndex = 0;
			salvarAlteracoes();
			btnSalvar.Enabled = false;
			ToolStrip1.Enabled = false;
			if (string.IsNullOrEmpty(Arquivo))
			{
				Arquivo = "MemorialShopCoinItem.sff";
			}
			pbStatus.Style = ProgressBarStyle.Marquee;
			bwSalvar.RunWorkerAsync();
			CarregarGrid(lsTemp);
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
            foreach (var item in FrmMain.IFF.Item)
            {
                if (Conversions.ToUInteger(this.txtTypeID.Text) == item.TypeID)
                {
                    if (this.txtIndex.Text != "Name Unknown")
                    {
						item.Name = this.txtIndex.Text;
					}
				}
			}
			lsTemp[index].TypeID = Conversions.ToUInteger(this.txtTypeID.Text);
			lsTemp[index].ItemType = (FilterType)Conversions.ToUInteger(this.cbItemType.SelectedIndex);
			lsTemp[index].CoinType = (FilterCoinType)Conversions.ToUInteger(this.cbTipoCoin.SelectedIndex);
			lsTemp[index].Probabilities = Conversions.ToUInteger(this.txtProbs.Text);
			lsTemp[index].NumberMax = Conversions.ToUInteger(this.txtCounter.Text);
			lsTemp[index].Number = (uint)Conversions.ToUInteger(this.txtNumber.Text);
			lsTemp[index].Enable = (uint)Conversions.ToUInteger(this.ckAtivo.Checked);

			try
			{
				ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
				ListaItem.SelectedRows[0].Cells["Index"].Value = txtIndex.Text;
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
					MemorialShopCoinItem item = new MemorialShopCoinItem();
					item.UN = new byte[19];
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
					lsItens = new MemorialShopCoinItemCollection();
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
						oIff = new MemorialShopCoinItem();
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

		private void btnBackup_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				MemorialShopCoinItem MemorialShopCoinItem = new MemorialShopCoinItem();
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
				MemorialShopCoinItem = (MemorialShopCoinItem)lsTemp[Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value)];
				try
				{
					lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(ListaItem.SelectedRows[0].Cells[0].Value, 1)), MemorialShopCoinItem);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					lsTemp.Insert(Conversions.ToInteger(ListaItem.SelectedRows[0].Cells[0].Value), MemorialShopCoinItem);
					ProjectData.ClearProjectError();
				}
				CarregarGrid(lsTemp);
			}
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
					int num2 = -1;
                    if (ComboBox1.SelectedIndex >0)
                    {
						num2 = (ComboBox1.SelectedIndex - 1);
					}
                    else if( ComboBox1.Text == "ALL")
                    {
						num2 = -1;
					}

					if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(num2) + " AND Status2 = " + Conversions.ToString(num);
					}
					else if ((ComboBox1.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString(num2);
					}
					else if ((ComboBox2.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
					}
					else if ((comboBox3.SelectedIndex > 0) & (txtPesquisa.Text.Length > 0))
					{
						bs.Filter = "Coin LIKE '%" + txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num);
					}
					else if ((ComboBox1.SelectedIndex > 0) & (ComboBox2.SelectedIndex > 0))
					{
						bs.Filter = "Personagem = " + Conversions.ToString(num2) + " AND Status2 = " + Conversions.ToString(num);
					}
					else if (txtPesquisa.Text.Length > 0)
					{
						bs.Filter = "Item LIKE '%" + txtPesquisa.Text + "%'";
					}
					else if (ComboBox1.SelectedIndex > 0)
					{
						bs.Filter = "Personagem = " + Conversions.ToString(num2);
					}
					else if (ComboBox2.SelectedIndex > 0)
					{
						bs.Filter = "Status2 = " + Conversions.ToString(num);
					}
					else
					{
						bs.Filter = "";
					}
					label4.Text = Conversions.ToString(bs.Count);
					organizarColunas();
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

        private void txtItemProdQtd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmMemorialShopCoinEditor_Load(object sender, EventArgs e)
        {
			this.lsItens = FrmMain.IFF.MemorialShopCoinItem;
			this.lsTemp = new MemorialShopCoinItemCollection();
			this.Arquivo = "MemorialShopCoinItem.sff";
			this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
			lsTemp.Header = lsItens.Header;
			this.nomeArquivo();
			this.ListaItem.DataSource = null;
			this.CarregarGrid(this.lsTemp);
			this.lbIndices.Text = this.lsItens.Count.ToString();
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
    }
}
