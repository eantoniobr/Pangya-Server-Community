using Pangya_Modern_Editor.Extensions;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Pangya_Modern_Editor
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.Update)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Update = false;
            }
            Properties.Settings.Default.Save();
            // Verifica se o aplicativo está sendo executado com permissões elevadas
            if (!IsRunAsAdmin())
            {
                // Se não estiver, reinicie o aplicativo com permissões elevadas
                try
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas" // Solicita execução como administrador
                    };
                    Process.Start(procInfo);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se a solicitação falhar
                    MessageBox.Show($"Failed to restart application as administrator: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Encerra o processo atual
                Environment.Exit(0);
            }
            else
            {
                // Código principal do aplicativo
                try
                {
                    new UpdateNotifier().ShowUpdateMessage();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(MyProject.Forms.FrmMenu);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção
                    MessageBox.Show($"An error occurred: {ex.Message}", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para verificar se o aplicativo está sendo executado como administrador
        private static bool IsRunAsAdmin()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        // Método para verificar se um debugger está presente
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsDebuggerPresent();
    }
}
