using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PangyaAPI.PAK.Definitions;
using PangyaAPI.PAK;
using PangyaAPI.PAK.Maker;
using PangyaAPI.PAK.Models;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmPakEditor : Form
    {
        HandlePakMaker PakMaker { get; set; }
        public string Arquivo = "";
        private int lastRow;
        public PakFile pakFile { get; set; }
        public ListView GetListView;
        public List<ListViewItem> ListViews { get; set; } = new List<ListViewItem>();
        public int Current_Index { get; set; } = 2;
        public FrmPakEditor()
        {
            InitializeComponent();
            PakMaker = new HandlePakMaker();
            GetListView = listView1;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (diagAbrirArquivo.ShowDialog() != DialogResult.OK || string.Compare(diagAbrirArquivo.FileName, "") == 0)
            {
                return;
            }
            this.Arquivo = this.diagAbrirArquivo.FileName;
            try
            {
                PakMaker.PakFiles.Clear();
                txtBox_LocalPak.Text = Arquivo;
                var result = PakMaker.OpenPak(Arquivo);
                listView1.Items.Clear();
                ListViews.Clear();
                Current_Index = 1;
                if (result == PakResultEnum.Sucess)
                {
                    lbFile_xtea.Text = $"XTEA File: ({PakMaker.PakType})";
                    CarregarListItem();
                }
            }
            catch (Exception)
            {

            }
        }


        public void CarregarListItem()
        {
            for (int i = 0; i < PakMaker.PakFiles.Count; i++)
            {
                var file = PakMaker.PakFiles;
                ListViewItem item1 = null;
                if (file[i].IsFolder && file[i].FolderSource != "..." && file[i].FolderSub == "...")
                {
                    item1 = new ListViewItem("...");//name
                    item1.SubItems.Add("");//size somar tudo e pegar o resultado 
                    item1.SubItems.Add("");//packed size, somar tudo e pegar o resultado
                    item1.Tag = file[i];
                    ListViews.Add(item1);

                    item1 = new ListViewItem(file[i].FolderSource);//name
                    item1.SubItems.Add(file.Size.ToString());//size somar tudo e pegar o resultado 
                    item1.SubItems.Add(file.Packed_Size.ToString());//packed size, somar tudo e pegar o resultado
                    item1.Tag = file[i];
                    ListViews.Add(item1);
                }

                else if (file[i].IsFolder && file[i].IsSubFolder && file[i].FolderSource == "..." && file[i].FolderSub != "...")
                {
                    item1 = new ListViewItem(file[i].FolderSub);//name

                    item1.SubItems.Add(file.Size.ToString());//size somar tudo e pegar o resultado 
                    item1.SubItems.Add(file.Packed_Size.ToString());//packed size, somar tudo e pegar o resultado
                    item1.Tag = file[i];
                    ListViews.Add(item1);
                }
                else if (file[i].IsFile)
                {
                    item1 = new ListViewItem(file[i].FileName);//name
                    item1.SubItems.Add(file[i].RealFileSize.ToString());//size somar tudo e pegar o resultado 
                    item1.SubItems.Add(file[i].FileSize.ToString());//packed size, somar tudo e pegar o resultado
                    item1.Tag = file[i];
                    ListViews.Add(item1);
                }
            }
            listView1.Items.Add(ListViews[1]);
        }

        private void detalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void listView1_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            listView1.Columns[e.Header.Index].ListView.Sorting = SortOrder.Ascending;
            listView1.Sort();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = listView1.SelectedItems[0];

            Selected(firstSelectedItem, (PakFileEx)firstSelectedItem.Tag);
        }

        private void FrmPakEditor_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void newPakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("em fase de testes finais !");
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            MessageBox.Show("em fase de testes finais !", e.Column.ToString());

        }

        public void Selected(ListViewItem firstSelectedItem, PakFileEx pak)
        {
            //data ou inicio
            if (firstSelectedItem.Index == 0 && pak.IsFolder)
            {
                if (firstSelectedItem.Text == "...")
                {
                    Current_Index = Current_Index - 1;
                    if (Current_Index == 1)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add(ListViews[1]);
                        return;
                    }
                    else
                    {
                        listView1.Items.Clear();

                        listView1.Items.Add(ListViews[0]);
                        listView1.Items.Add(ListViews[Current_Index]);
                    }
                }
                if (firstSelectedItem.Text != "...")
                {
                    listView1.Items.Clear();

                    listView1.Items.Add(ListViews[0]);
                    listView1.Items.Add(ListViews[Current_Index]);
                    Current_Index++;
                    if (Current_Index == ListViews.Count)
                    {
                        Current_Index = 1;
                        listView1.Items.Clear();

                        listView1.Items.Add(ListViews[1]);
                    }
                }
            }


            if (pak.Index == Current_Index)
            {
                Current_Index++;
            }
            pak = PakMaker.PakFiles[Current_Index + 1];

            //sub pasta
            if (firstSelectedItem.Index == 1)
            {
                if (pak.IsSubFolder)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add(ListViews[0]);
                    listView1.Items.Add(ListViews[Current_Index + 1]);
                    Current_Index++;
                    if (Current_Index == ListViews.Count)
                    {
                        Current_Index = 1;
                        listView1.Items.Clear();

                        listView1.Items.Add(ListViews[1]);
                    }
                }

                if (firstSelectedItem.Text == "...")
                {
                    Current_Index = Current_Index - 1;
                    if (Current_Index == 1)
                    {
                        listView1.Items.Clear();
                        listView1.Items.Add(ListViews[1]);
                        return;
                    }
                }
                if (firstSelectedItem.Text != "..." && pak.IsFile)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add(ListViews[0]);
                    foreach (var item in ListViews.Where(c => ((PakFileEx)c.Tag).IsFile == true && c.Text != ListViews[Current_Index].Text))
                    {
                        listView1.Items.Add(item);

                        if (pak.FolderSub == item.Name)
                        {
                        }
                    }
                }

                //if ((int)ListViews[Current_Index].Tag == 0)
                //{
                //    return;
                //}
                //if ((int)ListViews[Current_Index].Tag == 1)
                //{
                //    return;
                //}
                //listView1.Items.Add(ListViews[0]);
                //listView1.Items.Add(ListViews[Current_Index]);
                //Current_Index++;
                //if ((int)ListViews[Current_Index].Tag == 2)
                //{
                //    listView1.Items.Clear();
                //    listView1.Items.Add(ListViews[0]);
                //    Current_Index = ListViews.Where(c => (int)c.Tag == 2).Count();

                //    var rest = ListViews.Count - Current_Index;
                //    for (int i = rest; i < ListViews.Count; i++)
                //    {
                //        listView1.Items.Add(ListViews[i]);
                //    }
                //    Current_Index = ListViews.Count;
                //}
                //if (Current_Index == ListViews.Count)
                //{
                //    Current_Index = ListViews.Where(c => (int)c.Tag == 2).Count();
                //}
            }

            if (firstSelectedItem.Index == 1 && pak.IsOthersFolder)
            {

            }
        }
    }
}
