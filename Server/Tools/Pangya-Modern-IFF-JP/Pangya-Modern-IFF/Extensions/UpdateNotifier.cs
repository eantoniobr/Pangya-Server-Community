using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Extensions
{
    public class UpdateNotifier
    {
        public void ShowUpdateMessage()
        {
            string caption = "Pangya Modern Editor";

            // Verifica se a codificação "Shift_JIS" está disponível
            if (!Encoding.GetEncodings().Any(e => e.Name == "shift_jis"))
            {
                // Se a codificação não estiver disponível, ajusta a mensagem
               var message = GetFallbackMessage();
                Application.Exit();
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Verifica se a mensagem já foi exibida
            if (Properties.Settings.Default.Message)
            {
                string message = GetLocalizedMessage();
                // Exibindo o MessageBox
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza a configuração para marcar que a mensagem foi exibida
                Properties.Settings.Default.Message = false;
                Properties.Settings.Default.Save();
            }
        }

        private string GetLocalizedMessage()
        {
            string cultureName = CultureInfo.CurrentCulture.Name;
            string message;

            // Define mensagens para diferentes culturas
            switch (cultureName)
            {
                case "pt-BR":
                    message = "Olá!\n\nEstamos constantemente trabalhando para melhorar seu aplicativo. Nossa equipe está sempre atualizando e aprimorando a estrutura para garantir que você tenha a melhor experiência possível.\n\nSeu feedback é muito importante para nós e ajuda a tornar o aplicativo ainda melhor. Fique atento a atualizações e melhorias!\n\nObrigado por usar nosso aplicativo e pelo seu contínuo apoio!";
                    break;
                case "fr-FR":
                    message = "Bonjour!\n\nNous travaillons constamment à améliorer votre application. Notre équipe met toujours à jour et améliore la structure pour vous garantir la meilleure expérience possible.\n\nVos retours sont très importants pour nous et nous aident à rendre l'application encore meilleure. Restez à l'écoute pour les mises à jour et améliorations!\n\nMerci d'utiliser notre application et pour votre soutien continu !";
                    break;
                case "en-US":
                default:
                    message = "Hello!\n\nWe are constantly working to improve your application. Our team is always updating and enhancing the structure to ensure you have the best experience possible.\n\nYour feedback is very important to us and helps us make the application even better. Stay tuned for updates and improvements!\n\nThank you for using our application and for your continued support!";
                    break;
            }

            return message;
        }

        private string GetFallbackMessage()
        {
            // Mensagem padrão para quando "Shift_JIS" não está disponível
            return "Hello!\n\nWe are constantly working to improve your application. Our team is always updating and enhancing the structure to ensure you have the best experience possible.\n\nYour feedback is very important to us and helps us make the application even better. Stay tuned for updates and improvements!\n\nThank you for using our application and for your continued support!";
        }
    }
}
