using PangyaAPI.IFF.Handle;
using PangyaSuiteFiles.Forms;
using PangyaSuiteFiles.My;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace PangyaSuiteFiles
{
    public partial class FrmMain : Form
    {
        public static IFFHandle IFF;
        public static bool AutoLoadingIFF = true;
        public DateTime now = DateTime.Now;
        public static FrmPartEditor frmPart;

        public List<Form> ListFormsOpens { get; set; }
        
        public FrmMain()
        {
            InitializeComponent();
            var dtime = new DTime();
            if (dtime.CheckTime())
            {
                IFF = new IFFHandle();
                
                this.Text = $"Pangya Suite Tools [GB] Version Free !";

                ON_LoadIFF.Checked = MySettings.Default.AutoLoadIFF;
                OFF_LoadIFF.Checked = ON_LoadIFF.Checked == false ? true : false;
                openToolStripMenuItem.Enabled = ON_LoadIFF.Checked == true ? false : true;
                extractionToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
                reloadToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
                ListFormsOpens = new List<Form>();
                if (ON_LoadIFF.Checked)
                {
                    if (File.Exists("pangya_gb.iff"))
                    {
                        IFF.LoadAll("pangya_gb.iff");
                    }
                    else
                    {
                        MessageBox.Show("for the program to work, it is necessary the file 'pangya_gb.iff', was developed for the use of this file");
                        Environment.Exit(0);
                    }
                }
                MessageBox.Show("I am not responsible for any errors made by the user \nthe application works 'perfectly' when the user knows what he is doing \nif you found bugs or want to send feedback \nyou can contact me on discord", "Pangya Suite Tools !");
            }
            else
            {
                System.Diagnostics.Process.Start("https://discord.gg/DD3GHaVBQh");
            }  }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            new FrmAboutBox().ShowDialog();
        }

        private void BtnCardEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCardEditor().Show();
        }

        private void BtnClubSetEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmClubSetEditor().Show();
        }

        private void BtnDescEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmDescEditor().Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGenericDumper_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmGenericDumperView().Show();
        }

        private void BtnPartEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
            {
                frmPart = new FrmPartEditor();
                frmPart.Show();
            }
        }


        private void BtnMatchEditor_Click(object sender, EventArgs e)
        {

        }

        private void BtnSkinEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmSkinEditor().Show();
        }

        private void BtnThailandEditor_Click(object sender, EventArgs e)
        {
              new FrmLanguageEditor().ShowDialog();
        }


        private void BtnMemorialEditor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja abrir o editor memorialshoprare?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (IFF.Zip.IsLoad())
                    new FrmMemorialShopRareEditor().Show();
                return;
            }
            if (MessageBox.Show("Deseja abrir o editor memorialshopcoin?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (IFF.Zip.IsLoad())
                    new FrmMemorialShopCoinEditor().Show();
                return;
            }
        }

        private void BtnItemEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmItemEditor().Show();
        }


        private void BtnSetItemEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmSetItemEditor().Show();
        }
        private void StartupWindow_Load(object sender, EventArgs e)
        {
            base.Left = Screen.PrimaryScreen.WorkingArea.Width - (base.Width + 5);
            base.Top = Screen.PrimaryScreen.WorkingArea.Height - (base.Height + 5);
            Properties.Settings.Default.Upgrade();
        }


        private void BtnCutinEditor_Click(object sender, EventArgs e)
        {
            //new CutinEditor().Show();
        }

        private void BtnCaddieEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCaddieEditor().Show();
        }

        private void BtnMascotEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmMascotEditor().Show();
        }

        private void BtnAuxPartEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCharacterEditor().Show();
        }

        private void BtnBallEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmBallEditor().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Pangya IFF File (pangya_gb.iff)|pangya_gb.iff",
                Title = "Open IFF File"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IFF.LoadAll(dialog.FileName);
            }
        }

        private void BtnCauldronEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCadieMagicBoxEditor().Show();
        }

        private void BtnHideApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(0);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Visible = true;
            notifyIcon1.Visible = false;
        }

        private void BtnViewTGA(object sender, EventArgs e)
        {
            new FrmViewTGA().Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;
            notifyIcon1.Visible = false;
        }

        private void BtnCauldronRandomEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCadieMagicBoxRandomEditor().Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Upgrade();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmClubEditor().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void BtnCaddieItemEditor_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmCaddieItemEditor().Show();
        }

        private void BtnAuxPart_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmAuxPartEditor().Show();
        }

        private void BtnHairStyle_Click(object sender, EventArgs e)
        {
            if (IFF.Zip.IsLoad())
                new FrmHairStyleEditor().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IFF.Update)
            {
                IFF.UpdateIFF();
                MessageBox.Show("Seu novo [pangya_gb.iff] esta pronto !", "Pangya Suite Tools");
                MessageBox.Show("eu fiz uma copia do antigo para voce nao ter possiveis erros ;) !", "Pangya Suite Tools");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ON_LoadIFF.Checked && IFF.Zip.IsLoad())
                IFF.Zip.ExtractAll(Directory.GetCurrentDirectory() +"\\pangya_jp");
        }

        private void BtnAbilityEditor(object sender, EventArgs e)
        {
            if(IFF.Zip.IsLoad())
            new FrmAbilityEditor().Show();
        }

        private void BtnBinEditor(object sender, EventArgs e)
        {
            new FrmBinEditor().Show();
        }

        private void BtnTalkEditor(object sender, EventArgs e)
        {
            new FrmTalkEditor().Show();
        }

        private void saveIFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IFF.Update)
            {
                IFF.UpdateIFF();
                MessageBox.Show("Seu novo [pangya_gb.iff] esta pronto !", "Pangya Suite Tools");
                MessageBox.Show("eu fiz uma copia do antigo para voce nao ter possiveis erros ;) !", "Pangya Suite Tools");
            }
        }

        private void ON_LoadIFF_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Default.AutoLoadIFF = ON_LoadIFF.Checked;
            MySettingsProperty.Settings.Save();
            this.ON_LoadIFF.Image = ON_LoadIFF.Checked == true ? global::PangyaSuiteFiles.Properties.Resources.accept1 : null;
            openToolStripMenuItem.Enabled = ON_LoadIFF.Checked == true ? false : true;
            extractionToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
            reloadToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
        }

        private void OFF_LoadIFF_CheckedChanged(object sender, EventArgs e)
        {
            MySettings.Default.AutoLoadIFF = OFF_LoadIFF.Checked == true ? false: true;
            MySettingsProperty.Settings.Save();
            openToolStripMenuItem.Enabled = ON_LoadIFF.Checked == true ? false : true;
            extractionToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
            reloadToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled;
            this.OFF_LoadIFF.Image = OFF_LoadIFF.Checked == true ? global::PangyaSuiteFiles.Properties.Resources.accept1 : null;
        }

        private void ON_LoadIFF_Click(object sender, EventArgs e)
        {
            if (ON_LoadIFF.Checked)
            {
                ON_LoadIFF.Checked = false;
                OFF_LoadIFF.Checked = true;
            }
            else
            {
                ON_LoadIFF.Checked = true;
                OFF_LoadIFF.Checked = false;
            }
        }
        private void OFF_LoadIFF_Click(object sender, EventArgs e)
        {
            if (OFF_LoadIFF.Checked)
            {
                OFF_LoadIFF.Checked = false;
                ON_LoadIFF.Checked = true;
            }
            else
            {
                OFF_LoadIFF.Checked = true;
                ON_LoadIFF.Checked = false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnAbout_Click(sender, e);
        }

        private void hideAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnHideApp_Click(sender, e);
        }

        private void extractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button9_Click(sender,  e);
        }

        private void OFF_LoadIFF_Click_1(object sender, EventArgs e)
        {
            OFF_LoadIFF_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button12_Click(sender, e);
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("pangya_gb.iff"))
            {
                if (IFF.Zip.IsLoad())
                {
                    IFF.ReloadIff();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/DD3GHaVBQh");
            System.Diagnostics.Process.Start("https://github.com/luismk");
            linkLabel1.LinkVisited = true;
        }

        private void BtnGrandPrixEditor_Click(object sender, EventArgs e)
        {
            new FrmGrandPrixDataEditor().Show();
        }

        private void BtnCreateOrExtractPak_Click(object sender, EventArgs e)
        {
       //     new FrmPakEditor().Show();
        }

        private void BtnGGEditor_Click(object sender, EventArgs e)
        {
            new FrmGGEditor().Show();
        }

        private void BtnWikipedia_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"PangWikipedia";
            process.StartInfo.Arguments = "";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.LoadUserProfile = true;
            process.StartInfo.Verb = "runas";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
        }

        private void BtnSDConvert(object sender, EventArgs e)
        {
            new FrmSDConvert().Show();
        }
    }
}
