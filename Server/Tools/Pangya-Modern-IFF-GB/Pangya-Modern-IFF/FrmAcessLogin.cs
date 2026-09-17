using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PangyaSuiteFiles
{
    public partial class FrmAcessLogin : Form
    {
        [DllImport("iphlpapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int SendARP(uint DestIP, uint SrcIP, byte[] pMacAddr, ref int PhyAddrLen);
        public bool FileIsExist;
        public string GetMAC(string adress)
        {
            adress = GetIPLocal();
            var iPAddress = System.Net.IPAddress.Parse(adress);
            byte[] array = new byte[7];
            int PhyAddrLen = array.Length;
#pragma warning disable CS0618 // "IPAddress.Address" é obsoleto: "This property has been deprecated. It is address family dependent. Please use IPAddress.Equals method to perform comparisons. http://go.microsoft.com/fwlink/?linkid=14202"
            SendARP(checked((uint)iPAddress.Address), 0u, array, ref PhyAddrLen);
#pragma warning restore CS0618 // "IPAddress.Address" é obsoleto: "This property has been deprecated. It is address family dependent. Please use IPAddress.Equals method to perform comparisons. http://go.microsoft.com/fwlink/?linkid=14202"
            return BitConverter.ToString(array, 0, PhyAddrLen);
        }
        public static string GetIPLocal()
        {
            string hostName = Dns.GetHostName();
#pragma warning disable CS0618 // "Dns.Resolve(string)" é obsoleto: "Resolve is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202"
            return Dns.Resolve(hostName).AddressList[0].ToString();
#pragma warning restore CS0618 // "Dns.Resolve(string)" é obsoleto: "Resolve is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202"
        }
        string GetIP()
        {
#pragma warning disable CS0168 // A variável "projectError" está declarada, mas nunca é usada
            try
            {
                WebClient webClient = new WebClient();
                string input = webClient.DownloadString("http://pangyabrasil.com.br/getip.php");
                string pattern = "<h3>(.+)</h3>";
                MatchCollection matchCollection = Regex.Matches(input, pattern);
                string text = matchCollection[0].ToString();
                text = text.Remove(0, 4);
                text = text.Replace("</h3>", "");
                text = text.Replace(" ", "");
                return IPAddress.Parse(text).ToString();
            }
            catch (Exception projectError)
            {
                string result = "000.000.000.000";
                return result;
            }
#pragma warning restore CS0168 // A variável "projectError" está declarada, mas nunca é usada
        }
        public FrmAcessLogin()
        {
            InitializeComponent();
           
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if (this.countErro > 2)
            {
                this.flag = true;
                this.Close();
               My. MyProject.Forms.MainApp.Close();
            }
            if (!((this.UsernameTextBox.Text.Length > 1) & (this.PasswordTextBox.Text.Length > 1)))
            {
                MessageBox.Show("Verifique os campos e tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!((this.txtMac.Text.Length == 0) | (this.txtMac.Text == "00-00-00-00-00-00")))
            {
                DBConnection conn = new DBConnection();
                string[] strArray = new string[] { "SELECT * FROM ADM_USUARIOS_IFF WHERE ( LOGIN = '", this.UsernameTextBox.Text, "' OR  LOGIN = '", this.UsernameTextBox.Text.ToLower(), "') AND  SENHA = '", this.PasswordTextBox.Text, "'" };
                conn.Query = string.Concat(strArray);
                DataTable table = new DataTable();
                try
                {
                    table = (DataTable)conn.executarQuery("S", "");
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    MessageBox.Show("Ocorreu um erro ao tentar validar o usu\x00e1rio. Tente novamente mais tarde: " + exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ProjectData.ClearProjectError();
                    return;
                }
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show("Login ou senha inv\x00e1lida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.PasswordTextBox.Clear();
                    this.flag = false;
                    this.countErro++;
                }
                else
                {
                    int num = Conversions.ToInteger(table.Rows[0]["ATIVO"].ToString());
                    int num2 = Conversions.ToInteger(table.Rows[0]["ID"].ToString());
                    string str = table.Rows[0]["LOGIN"].ToString();
                    DateTime time2 = Conversions.ToDate(table.Rows[0]["SENHAALTERADA"].ToString());
                    if (num != 0)
                    {
                        if (num == 2)
                        {
                            if (MessageBox.Show("Este computador ser\x00e1 cadastrado e o acesso ser\x00e1 limitado a esta maquina, deseja continuar?", "Informa\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                            else
                            {
                                DBConnection conn2 = new DBConnection()
                                {
                                    Query = "DELETE FROM ADM_USUARIOS_IFF_MAC WHERE USUARIO_ID = " + Conversions.ToString(num2) + " ;"
                                };
                                DBConnection conn4 = conn2;
                                conn4.Query = conn4.Query + $"INSERT INTO ADM_USUARIOS_IFF_MAC (USUARIO_ID,MAC,ATIVO) VALUES ({num2},'{this.txtMac.Text}',{1});";
                                if (!Conversions.ToBoolean(conn2.executarQuery("I", "")))
                                {
                                    MessageBox.Show("Ocorreu um erro ao gravar as informa\x00e7\x00f5es", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Informa\x00e7\x00f5es adicionadas com sucesso!", "Informa\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    conn2.Query = $"UPDATE ADM_USUARIOS_IFF SET ATIVO = 1 WHERE LOGIN = '{table.Rows[0]["LOGIN"].ToString()}' AND ATIVO = 2";
                                    conn2.executarQuery("U", "");
                                }
                            }
                        }
                        bool flag = false;
                        if (DateTime.Compare(time2, DateAndTime.Now.AddDays(-15.0)) < 0)
                        {
                            flag = true;
                        }
                        if ((num == 3) | flag)
                        {
                            if (MessageBox.Show("\x00c9 necess\x00e1rio atualizar sua senha, deseja continuar?", "Informa\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                            else
                            {
                                DBConnection conn3 = new DBConnection();
                                string str3 = Interaction.InputBox("Informe a nova senha de no m\x00edmino 6 caracteres", "Altera\x00e7\x00e3o de senha", "", -1, -1);
                                if (str3.Length >= 6)
                                {
                                    if (str3.Length <= 20)
                                    {
                                        if (!str3.Contains("'"))
                                        {
                                            conn3.Query = string.Format("UPDATE ADM_USUARIOS_IFF SET SENHA = '{0}',SENHAALTERADA = '{2}' , ATIVO = 1 WHERE LOGIN = '{1}'", str3, str, DateAndTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                                            if (!Conversions.ToBoolean(conn3.executarQuery("U", "")))
                                            {
                                                MessageBox.Show("Ocorreu um erro ao gravar as informa\x00e7\x00f5es", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                return;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Informa\x00e7\x00f5es alteradas com sucesso!", "Informa\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Existem caracteres n\x00e3o permitidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("A senha deve conter no m\x00e1ximo 20 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A senha deve conter no m\x00ednimo 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                        }
                        if (!this.verificarMac(num2, this.txtMac.Text))
                        {
                            MessageBox.Show("Acesso negado: Mac-Adress inv\x00e1lido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            int num3 = Conversions.ToInteger(table.Rows[0]["TIPO"].ToString());
                            if ((num3 != 2) && ((num3 != 4) && ((num3 != 5) && (num3 != 6))))
                            {
                                MessageBox.Show("Tipo de usu\x00e1rio desconhecido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            else
                            {
                                this.flag = true;
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Conta desabilitada pelo administrador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Endere\x00e7o fisico inv\x00e1lido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Conversions.ToString(e.KeyChar) == "'")
            {
                e.Handled = true;
            }
        }
        private string criarChave()
        {
            string[] strArray = new string[] { Conversions.ToString(DateAndTime.Now.Day), "^", Conversions.ToString(DateAndTime.Now.Month), "^", Conversions.ToString(DateAndTime.Now.Year), "^", Conversions.ToString(DateAndTime.Now.Hour), "^", Conversions.ToString(DateAndTime.Now.Minute) };
            strArray[9] = "^";
            strArray[10] = Conversions.ToString(DateAndTime.Now.Second);
            return string.Concat(strArray);
        }
        private bool verificarMac(int Usuario, string Mac)
        {
            bool flag;
            DBConnection conn = new DBConnection();
            DataTable table = new DataTable();
            conn.Query = "SELECT * FROM ADM_USUARIOS_IFF_MAC WHERE USUARIO_ID = " + Conversions.ToString(Usuario);
            try
            {
                table = (DataTable)conn.executarQuery("S", "");
                if (table.Rows.Count <= 0)
                {
                    flag = false;
                }
                else
                {
                    int num = 0;
                    int num3 = table.Rows.Count - 1;
                    int num2 = 0;
                    while (true)
                    {
                        int num4 = num3;
                        if (num2 > num4)
                        {
                            flag = num > 0;
                            break;
                        }
                        if (table.Rows[num2]["MAC"].Equals(Mac.ToString()))
                        {
                            num++;
                        }
                        num2++;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception local2 = ex;
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
        private void FrmAcessLogin_Load(object sender, EventArgs e)
        {
            //D8-FB-5E-E5-49-29 renato
            //64-32-A8-42-E0-A0 meu
            txtMac.Text = GetMAC("000.000.000.000".ToString());
            if (txtMac.Text == "64-32-A8-42-E0-A0")
            {
                this.flag = true;
                new FrmMain().Show();
            }
            //var rest = Program.time - DateTime.Now;
            //DateTime timeUtc = DateTime.UtcNow;
            //var kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            //var horaBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
            //var rest2 = Program.time - horaBrasilia;
            //if (rest.Days > 0 && rest2.Days > 0)
            //{
            //}
            else
            {
                MessageBox.Show("ACESSO NAO PERMITIDO !", "Thanks by LuisMK");
                Close();
                //MessageBox.Show("Seu teste chegou ao fim, obrigado por usar meu app ! \npara conseguir a versao full fale comigo no discord", "Read-me");
                //MessageBox.Show("discord: LuisMK#2116", "Thanks by LuisMK");
                Application.Exit();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
