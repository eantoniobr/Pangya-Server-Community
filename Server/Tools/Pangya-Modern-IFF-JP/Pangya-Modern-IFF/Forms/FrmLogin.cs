using System;
using System.Windows.Forms;
using Pangya_Modern_Editor.Extensions;
using Pangya_Modern_Editor.Network;

namespace Pangya_Modern_Editor.Forms
{
    public partial class FrmLogin : Form
    {
        private NetworkClient _networkClient;
        private string _macAddress = "";
        private string _hwid = "";
        private int _errorCount = 0;
        private bool _isLoggedIn = false;
        private bool isFirst;
        public Login LoginResponse { get; private set; }

        public FrmLogin()
        {
            if (Properties.Settings.Default.user == "pangya" &&
                  Properties.Settings.Default.pass == "pangya")
            {
                isFirst = true;
            }
            InitializeComponent();
            
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                MyProject.Forms.FrmMenu.Show();

                //if (_errorCount > 2)
                //{
                //    var result = MessageBox.Show(
                //        "Do you want to continue? The user is not logged in!",
                //        "Pangya Modern Editor",
                //        MessageBoxButtons.OKCancel,
                //        MessageBoxIcon.Exclamation);

                //    if (result == DialogResult.OK)
                //    {
                //        MyProject.Forms.FrmMenu.Show();
                //        _isLoggedIn = true;
                //        Hide();
                //    }
                //    else
                //    {
                //        _isLoggedIn = false;
                //        Close();
                //    }
                //    return;
                //}

                //if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                //    string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                //{
                //    ShowMessage("Check the fields and try again.");
                //    return;
                //}

                //LoginResponse = _networkClient.Login(new Login(
                //    UsernameTextBox.Text,
                //    PasswordTextBox.Text,
                //    _macAddress, _hwid));

                //HandleLoginResponse(LoginResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing login: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _isLoggedIn = false;
            Close();
            Application.Exit();
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //_networkClient = new NetworkClient("104.248.10.228", 8888);
                //Visible = false;

                //_macAddress = Util.GetMAC();
                //_hwid = Util.GetHWID();

                //if (Properties.Settings.Default.user != "pangya" &&
                //    Properties.Settings.Default.pass != "pangya")
                //{
                //    PasswordTextBox.Text = Properties.Settings.Default.pass;
                //    UsernameTextBox.Text = Properties.Settings.Default.user;
                //}
                //else
                //{
                //Show();
                // }
                
            }
            catch (Exception ex)
            { ShowMessage(ex.Message); }
        }

        private void HandleLoginResponse(Login response)
        {
            switch (response.Code)
            {
                case LoginCode.Sucess:
                    if (response.IsAuthenticated)
                    {                                        
                        SaveCredentials();
                        HandleSuccessLogin(response);
                    }
                    break;

                case LoginCode.UserNoExist:
                    ShowMessage("User does not exist!");
                    break;

                case LoginCode.UserOrPWD_Invalid:
                    ShowMessage("Login or Password invalid!");
                    break;

                case LoginCode.Time_Expired:
                    ShowMessage("Time Expired!");
                    break;

                case LoginCode.User_Test:
                    ShowMessage("User Invalid! [0]");
                    Application.Exit();
                    break;

                case LoginCode.Dev:
                    ShowMessage("Mod Dev");
                    Application.Exit();
                    break;
                case LoginCode.Ban:
                    ShowMessage("User Banned by Admin");
                    Application.Exit();
                    break;

                case LoginCode.System_OFF:
                    ShowMessage("System under maintenance!");
                    Application.Exit();
                    break;

                case LoginCode.UserBlock:
                    ShowMessage("User blocked!");
                    Application.Exit();
                    break;

                case LoginCode.MacAdressInvalid:
                    ShowMessage("Invalid MAC Address!");
                    Application.Exit();
                    break;

                default:
                    ShowMessage("Unknown error.");
                    break;
            }
        }

        private void HandleSuccessLogin(Login response)
        {
            switch (response.Tipo)
            {
                case 1:
                case 2:
                case 4:
                    {
                        if (isFirst)
                        {
                            ShowMessage("Welcome to Pangya Modern Editor!");
                        }
                        SaveCredentials();
                        Hide();
                        MyProject.Forms.FrmMenu.Show();
                    }
                    break;
                default:
                    ShowMessage("Account disabled by administrator.");
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void SaveCredentials()
        {
            Properties.Settings.Default.user = UsernameTextBox.Text;
            Properties.Settings.Default.pass = PasswordTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void ShowMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Exclamation)
        {
            MessageBox.Show(message, "Pangya Modern Editor", MessageBoxButtons.OK, icon);
            if (icon == MessageBoxIcon.Exclamation)
            {
                _isLoggedIn = false;
                _errorCount++;
            }
            else
            {
                _errorCount = 0;
                _isLoggedIn = true;
            }
        }     
    }
}
