using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Forms.Editors;
using Pangya_Modern_Editor.Forms.Editors.Special;
using Pangya_Modern_Editor.Properties;
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    public partial class FrmMain : Form
    {
        public static bool AutoLoadingIFF = true;
        public static string LangTraslation = "en";
        public DateTime now = DateTime.Now;
        public int contadorHora;

        // O reprodutor de áudio para o som de fundo
        private SoundPlayer Player = null;


        public FrmMain()
        {
            InitializeComponent();

            // Inicializa todos os botões de editores como desativados até que um IFF seja carregado
            SetEditorsEnabled(false);

            // Configuração inicial do som de fundo baseado nas definições do utilizador
            if (Properties.Settings.Default.sound)
            {
                enableToolStripMenuItem.Image = Resources.BtnApply_Mini;
            }
            else
            {
                disableToolStripMenuItem.Image = Resources.BtnApply_Mini;
            }
        }

        private void StartupWindow_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            // Controle de permissões de exibição por tipo de utilizador
            var tipo = 2; // Exemplo fixado (0/1: Normal, 2: ADM, 3: Special)
            var is_special = true;

            switch (tipo)
            {
                case 0:
                case 1: // Nível Normal
                    BtnPartEditor.Enabled = true;
                    BtnMascotEditor.Enabled = true;
                    BtnBallEditor.Enabled = true;
                    BtnClubSetEditor.Enabled = true;
                    BtnCardEditor.Enabled = true;
                    BtnSetItemEditor.Enabled = true;
                    BtnCaddieEditor.Enabled = true;
                    BtnItemEditor.Enabled = true;
                    BtnCharacter.Enabled = true;
                    break;

                case 2: // Nível Administrador / Especial
                case 3:
                    BtnPartEditor.Enabled = true;
                    BtnAuxPart.Enabled = true;
                    BtnMascotEditor.Enabled = true;
                    BtnBallEditor.Enabled = true;
                    BtnClubSetEditor.Enabled = true;
                    BtnCardEditor.Enabled = true;
                    BtnSetItemEditor.Enabled = true;
                    BtnSkinEditor.Enabled = true;
                    BtnCaddieEditor.Enabled = true;
                    BtnDescEditor.Enabled = true;
                    BtnCauldron.Enabled = true;
                    BtnItemEditor.Enabled = true;
                    BtnHairStyle.Enabled = true;
                    BtnClubEditor.Enabled = true;
                    BtnCharacter.Enabled = true;
                    BtnCaddieItemEditor.Enabled = true;

                    if (is_special)
                    {
                        BtnMemorialEditor.Enabled = true;
                        BtnAbilityEditor.Enabled = true;
                        BtnGrandPrixEditor.Enabled = true;
                        BtnMemorialEditor2.Enabled = true;
                        BtnLevelUp.Enabled = true;
                        BtnPointShop.Enabled = true;
                        BtnMatch.Enabled = true;
                        BtnCauldronRandom.Enabled = true;
                        BtnSetEffectEditor.Enabled = true;
                    }
                    break;

                default:
                    SetEditorsEnabled(false);
                    break;
            }

            // Exibição de metadados da aplicação na interface
            var App_Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = $"{App_Version}";

            // Posiciona a janela no canto inferior direito do ecrã principal
            base.Left = Screen.PrimaryScreen.WorkingArea.Width - (base.Width + 5);
            base.Top = Screen.PrimaryScreen.WorkingArea.Height - (base.Height + 5);

            // Carregamento automático padrão do IFF caso ativo
            if (AutoLoadingIFF)
            {
                if (!sIff.getInstance().IsLoaded)
                {
                    sIff.getInstance().Init();
                }
            }
        }

        // Método auxiliar para ativar/desativar em lote todos os botões de editores
        private void SetEditorsEnabled(bool enabled)
        {
            BtnPartEditor.Enabled = enabled;
            BtnAuxPart.Enabled = enabled;
            BtnMascotEditor.Enabled = enabled;
            BtnBallEditor.Enabled = enabled;
            BtnClubSetEditor.Enabled = enabled;
            BtnCardEditor.Enabled = enabled;
            BtnSetItemEditor.Enabled = enabled;
            BtnSkinEditor.Enabled = enabled;
            BtnCaddieEditor.Enabled = enabled;
            BtnDescEditor.Enabled = enabled;
            BtnCauldron.Enabled = enabled;
            BtnItemEditor.Enabled = enabled;
            BtnHairStyle.Enabled = enabled;
            BtnClubEditor.Enabled = enabled;
            BtnCharacter.Enabled = enabled;
            BtnCaddieItemEditor.Enabled = enabled;
            BtnMemorialEditor.Enabled = enabled;
            BtnAbilityEditor.Enabled = enabled;
            BtnGrandPrixEditor.Enabled = enabled;
            BtnMemorialEditor2.Enabled = enabled;
            BtnLevelUp.Enabled = enabled;
            BtnPointShop.Enabled = enabled;
            BtnMatch.Enabled = enabled;
            BtnCauldronRandom.Enabled = enabled;
            BtnSetEffectEditor.Enabled = enabled;
        }

      
        private void BtnOpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Pangya IFF Main File (pangya_jp.iff)|*.iff";
                dialog.Title = "Open IFF File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sIff.getInstance().Reload(dialog.FileName);
                        sIff.getInstance().GenerationCopy();
                        AutoLoadingIFF = true;
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao abrir e processar o ficheiro IFF informado.", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        // ── Eventos de Clique dos Editores (Sincronizados com o IFFHandle Moderno) ──

        private void BtnCardClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCard(sIff.getInstance().Card).Show();
            else
                new FrmCard().Show();
        }

        private void BtnClubSetClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmClubSet(sIff.getInstance().ClubSet).Show();
            else
                new FrmClubSet().Show();
        }

        private void BtnDescClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmDesc(sIff.getInstance().Desc).Show();
            else
                new FrmDesc().Show();
        }

        private void BtnPartClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmPart(sIff.getInstance().Part).Show();
            else
                new FrmPart().Show();
        }

        private void BtnSkinClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmSkin(sIff.getInstance()._Skins).Show();
            else
                new FrmSkin().Show();
        }

        private void BtnItemClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmItem(sIff.getInstance().Item).Show();
            else
                new FrmItem().Show();
        }

        private void BtnSetItemClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmSetItem(sIff.getInstance().SetItem).Show();
            else
                new FrmSetItem().Show();
        }

        private void BtnCaddieClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCaddie(sIff.getInstance().Caddie).Show();
            else
                new FrmCaddie().Show();
        }

        private void BtnMascotClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmMascot(sIff.getInstance().Mascot).Show();
            else
                new FrmMascot().Show();
        }

        private void BtnAuxPartClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmAuxPart(sIff.getInstance().AuxPart).Show();
            else
                new FrmAuxPart().Show();
        }

        private void BtnBallClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmBall(sIff.getInstance().Ball).Show();
            else
                new FrmBall().Show();
        }

        private void BtnCauldronClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCadieMagicBox(sIff.getInstance().CadieMagicBox).Show();
            else
                new FrmCadieMagicBox().Show();
        }

        private void BtnMemorialEditor2_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmMemorialShopRare(sIff.getInstance().MemorialShopRareItem).Show();
            else
                new FrmMemorialShopRare().Show();
        }

        private void BtnCaddieItemClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCaddieItem(sIff.getInstance().CaddieItem).Show();
            else
                new FrmCaddieItem().Show();
        }

        private void BtnCauldronRandom_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCadieMagicBoxRandom(sIff.getInstance().CadieMagicBoxRandom).Show();
            else
                new FrmCadieMagicBoxRandom().Show();
        }

        private void BtnSetEffectClick(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmSetEffectTable(sIff.getInstance()._SetEffectTable).Show();
            else
                new FrmSetEffectTable().Show();
        }

        private void BtnCauldron_Click(object sender, EventArgs e)
        {
            BtnCauldronClick(sender, e);
        }

        private void BtnHairStyle_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmHairStyle(sIff.getInstance()._HairStyle).Show();
            else
                new FrmHairStyle().Show();
        }

        private void BtnClubEditor_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmClub(sIff.getInstance().Club).Show();
            else
                new FrmClub().Show();
        }

        private void BtnMemorialEditor_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmMemorialShopCoin(sIff.getInstance().MemorialShopCoinItem).Show();
            else
                new FrmMemorialShopCoin().Show();
        }

        private void BtnPointShop_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmPointShop(sIff.getInstance()._PointShop).Show();
            else
                new FrmPointShop().Show();
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmMatch(sIff.getInstance()._Match).Show();
            else
                new FrmMatch().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmErrorCodeInfo(sIff.getInstance().ErrorCodeInfo).Show();
            else
                new FrmErrorCodeInfo().Show();
        }

        private void BtnLevelUp_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmLevelUpPrizeItem(sIff.getInstance()._LevelUpPrizeItem).Show();
            else
                new FrmLevelUpPrizeItem().Show();
        }

        private void BtnAbilityEditor_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmAbility(sIff.getInstance().ItemAbility).Show();
            else
                new FrmAbility().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmGrandPrixRankReward(sIff.getInstance()._GrandPrixRankReward).Show();
            else
                new FrmGrandPrixRankReward().Show();
        }

        private void BtnGrandPrixEditor_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmGrandPrixData(sIff.getInstance()._GrandPrixData).Show();
            else
                new FrmGrandPrixData().Show();
        }

        private void BtnCharacter_Click(object sender, EventArgs e)
        {
            if (sIff.getInstance().IsLoaded && AutoLoadingIFF)
                new FrmCharacter(sIff.getInstance().Character).Show();
            else
                new FrmCharacter().Show();
        }

        private void BtnGenericDumper_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão não funcional no momento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAchiviementClick(object sender, EventArgs e)
        {
            MessageBox.Show("Botão não funcional no momento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Gestão de Janela e Barra de Tarefas (NotifyIcon) ──────────────────

        private void BtnHideApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            notify.Visible = true;
            notify.ShowBalloonTip(500);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreWindow();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            RestoreWindow();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            RestoreWindow();
        }

        private void RestoreWindow()
        {
            this.Show();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            notify.Visible = false;
        }

        private void hideAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnHideApp_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnOpenFile(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja voltar para o ecrã de login?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();

                Application.Exit();

            }
            else
            {
                Application.Exit();
            }
        }

        // ── Menu de Operações com Arquivo Extensivo ───────────────────────────

        private void saveIFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!sIff.getInstance().IsLoaded)
            {
                MessageBox.Show("Nenhum arquivo IFF carregado no sistema para salvar.", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Pangya IFF Main File (pangya_jp.iff)|*.iff";
                dialog.Title = "Save IFF File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sIff.getInstance().UpdateIFF();
                        MessageBox.Show("Seu novo arquivo estruturado está pronto e atualizado!", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro crítico ao reconstruir arquivo zip binário IFF: {ex.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("data/pangya_jp.iff") && AutoLoadingIFF)
            {
                if (MessageBox.Show("Para recarregar 100% de forma segura, precisa de fechar todas as janelas filhas abertas. Continuar?", "Pangya Modern Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sIff.getInstance().Reload();
                    sIff.getInstance().GenerationCopy();
                }
            }
            else
            {
                BtnOpenFile(sender, e);
            }
        }

        private void extractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Pangya IFF Main File (pangya_jp.iff)|*.iff";
                dialog.Title = "Open IFF File to Unpack";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] fileBytes = File.ReadAllBytes(dialog.FileName);
                        if (fileBytes.Length < 2 || fileBytes[0] != 'P' || fileBytes[1] != 'K')
                        {
                            throw new NotSupportedException("O ficheiro fornecido não possui cabeçalho ZIP nativo (PK). Descompacte-o manualmente.");
                        }

                        string text = dialog.FileName;
                        string folderDestination = Path.Combine(Path.GetDirectoryName(text), Path.GetFileNameWithoutExtension(text));

                        using (var zipFile = new ZipFileEx(text))
                        {
                            zipFile.ExtractToDirectory(folderDestination);
                        }

                        MessageBox.Show("Arquivo descompactado com sucesso na pasta de origem!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro na extração: " + ex.Message, "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        // ── Controle de Ativação / Desativação de Som de Fundo ────────────────

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.sound = false;
            disableToolStripMenuItem.Image = Resources.BtnApply_Mini;
            enableToolStripMenuItem.Image = null;
            Settings.Default.Save();
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.sound = true;
            disableToolStripMenuItem.Image = null;
            enableToolStripMenuItem.Image = Resources.BtnApply_Mini;
            Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}