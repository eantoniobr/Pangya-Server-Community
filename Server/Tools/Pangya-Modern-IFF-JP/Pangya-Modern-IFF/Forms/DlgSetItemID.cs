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
    public partial class DlgSetItemID : Form
    {
        public uint NewItemTypeID;
         public DlgSetItemID()
        {
            InitializeComponent();
            cbPersonagem.SelectedIndex = 0;      
        }   

        private void btnGerar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            uint id = (uint)(cbPersonagem.SelectedIndex);
            NewItemTypeID = setItemSubGroupIdentify21(id, uint.Parse(txtPos.Text));
            txtResultado.Text = NewItemTypeID.ToString();
            MessageBox.Show("Copy new Index Created", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public uint setItemSubGroupIdentify21(uint group, uint nextId)
        {
            // Verifica se o valor do grupo está dentro do intervalo válido
            if (group > 0x3F) // 0x3F é 63 em decimal, o limite para 6 bits
            {
                throw new ArgumentOutOfRangeException(nameof(group), "O valor do grupo está fora do intervalo permitido.");
            }

            // Define a baseTypeId, mantendo o valor fixo dos bits mais significativos
            uint baseTypeId = 622829568 & 0xFC000000;

            // Incrementa o próximo identificador específico
            uint specificId = nextId++;

            // Cria o novo Index combinando o identificador específico e o grupo
            uint newTypeId = baseTypeId | ((specificId & 0xFFFFF) | ((group << 21) & 0x03FFFFE0));

            return newTypeId;
        }

        private void cbPersonagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Character = (CharacterType)cbPersonagem.SelectedIndex;
            Debug.WriteLine(Character.ToString().Replace("_", " "));
        }
    }
}
