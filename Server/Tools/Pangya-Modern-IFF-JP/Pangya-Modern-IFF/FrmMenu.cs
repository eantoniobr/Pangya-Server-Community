using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Forms.Editors;
using Pangya_Modern_Editor.Forms.Editors.Special;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    public partial class FrmMenu : Form
    {
         public FrmMenu()
        {
            InitializeComponent();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void BtnThailandEditor_Click(object sender, EventArgs e)
        {
            new FrmLanguageEditor().Show();
        }

        private void StartupWindow_Load(object sender, EventArgs e)
        {
            base.Left = Screen.PrimaryScreen.WorkingArea.Width - (base.Width + 5);
            base.Top = Screen.PrimaryScreen.WorkingArea.Height - (base.Height + 5);
            Properties.Settings.Default.Upgrade();
        }


        private void BtnViewTGA(object sender, EventArgs e)
        {
            //new FrmViewTGA().Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;
            notifyIcon1.Visible = false;
        }


        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Upgrade();
            Application.Exit();
        }


        private void BtnBinEditor(object sender, EventArgs e)
        {
           // new FrmBinEditor().Show();
        }

        private void BtnTalkEditor(object sender, EventArgs e)
        {
          //  new FrmTalkEditor().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/luismk");
            linkLabel1.LinkVisited = true;
        }

        private void BtnIFFEditor_Click(object sender, EventArgs e)
        {

            MyProject.Forms.FrmMain.Show();
        }             
        
        private void button2_Click(object sender, EventArgs e)
        {
             Properties.Settings.Default.Upgrade();
            Application.Exit();
        }  
    }
}
