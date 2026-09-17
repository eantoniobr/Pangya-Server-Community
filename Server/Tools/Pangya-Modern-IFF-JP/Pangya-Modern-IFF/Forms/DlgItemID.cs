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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangyaAPI.IFF.JP;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Properties;
namespace Pangya_Modern_Editor.Forms
{
    public partial class DlgItemID : Form
    {
        public uint NewItemTypeID;
         public DlgItemID()
        {
            InitializeComponent();
            cbPersonagem.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
            cbIffTyp.SelectedIndex = 1;
        }   

        private void btnGerar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            uint id = (uint)(cbPersonagem.SelectedIndex);
            NewItemTypeID = GenerateNewTypeID((uint)cbIffTyp.SelectedIndex, id, uint.Parse(txtPos.Text), 2, (uint)cbTipo.SelectedIndex, uint.Parse(txtSerial.Text));
            txtResultado.Text = NewItemTypeID.ToString();
            MessageBox.Show("Copy new Index Created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
        uint GenerateNewTypeID(uint iffType, uint characterId, uint pos, uint group, uint type, uint serial)
        {
            if (group - 1 < 0)
            {
                group = 0;
            }
            return (uint)Convert.ToUInt64((iffType * Math.Pow(2.0, 26.0)) + (characterId * Math.Pow(2.0, 18.0)) + (pos * Math.Pow(2.0, 13.0)) + (group * Math.Pow(2.0, 11.0)) + (type * Math.Pow(2.0, 9.0)) + serial);
        }

        private void cbPersonagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Character = (CharacterType)cbPersonagem.SelectedIndex;
            Debug.WriteLine(Character.ToString().Replace("_", " "));
        }
    }
}
