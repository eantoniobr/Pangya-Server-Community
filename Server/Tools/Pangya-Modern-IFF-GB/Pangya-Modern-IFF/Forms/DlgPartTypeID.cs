using PangyaAPI.IFF.Extensions;
using PangyaAPI.IFF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class DlgPartTypeID : Form
    {
        public uint NewItemTypeID;
        public DlgPartTypeID()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            NewItemTypeID = newTypeid((uint)cbPersonagem.SelectedIndex, uint.Parse(txtPos.Text), (uint)cbTipo.SelectedIndex, uint.Parse(txtSerial.Text));

            txtResultado.Text = NewItemTypeID.ToString();
            MessageBox.Show("new id create", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        uint newTypeid(uint CharacterType, uint Pos, uint Category, uint serial)
        {
            return IFFHandleExtension.GenerateNewTypeID(CharacterType, Pos, 2, Category, serial);
        }
    }
}
