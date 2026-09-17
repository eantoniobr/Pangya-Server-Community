using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PangyaAPI.GameGuard;
using PangyaAPI.GameGuard.GuardCrypt;
namespace PangyaSuiteFiles.Forms
{
    public partial class FrmGGEditor : Form
    {
        public Crypts Maker;
        public OpenFileDialog OpenFile;
        public FrmGGEditor()
        {
            InitializeComponent();
            Maker = new Crypts();
        }

        private void BtnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            if (OpenFile == null)
            {
                MessageBox.Show("Please Open your file \n example: pangya.ini", "Pangya Suite Tools", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (OpenFile != null && OpenFile.ShowDialog() == DialogResult.OK)
            {
                var result = Maker.DecryptEncryptFile(OpenFile.FileName);
                if (result == Crypts.Result.Sucess)
                { MessageBox.Show("Sucess ! \n try save file now in Button Save IFF", "Pangya Suite Tools", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                if (result == Crypts.Result.Key_Not_Found)
                {
                    MessageBox.Show("Key  for file not exists", "Pangya Suite Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveIFF_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Pangya IFF File (*.ini)|*.ini",
                Title = "Save INI File"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (Maker.GGData.OldBytes.Count() > 0)
                {
                    Maker.SaveResult(dialog.FileName);
                }
                else
                {
                    MessageBox.Show("Please Open your file \n example: pangya.ini", "Pangya Suite Tools", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnOpenIFF_Click(object sender, EventArgs e)
        {
            OpenFile = new OpenFileDialog
            {
                Filter = "Pangya IFF File (*.ini)|*.ini",
                Title = "Open IFF File"
            };
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("now Try Decrypt or Encrypt file \r\n\n Click Buttons Decrypt.iff or Encrypt.iff", "Pangya Suite Tools", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }
    }
}
