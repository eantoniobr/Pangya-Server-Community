//using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.CompilerServices;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Net;
//using System.Runtime.InteropServices;
//using System.Security.Cryptography;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Windows.Forms;
//namespace PangyaSuiteFiles
//{
//    public class User : DBConnection
//    {
//     public User(string name, string pass)
//    {

//        if (string.IsNullOrEmpty(name))
//        {

//        }

//        if (string.IsNullOrEmpty(pass))
//        {

//        }

//        string[] strArray = new string[] { "SELECT * FROM ADM_USUARIOS_IFF WHERE ( LOGIN = '", name, "' OR  LOGIN = '", name.ToLower(), "') AND  SENHA = '", pass, "'" };
//        Query = string.Concat(strArray);
//        DataTable table = new DataTable();
//        try
//        {
//            table = (DataTable)executarQuery("S", "");
//        }
//        catch (Exception exception1)
//        {
//            Exception ex = exception1;
//            ProjectData.SetProjectError(ex);
//            Exception exception = ex;
//            MessageBox.Show("Ocorreu um erro ao tentar validar o usu\x00e1rio. Tente novamente mais tarde: " + exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            ProjectData.ClearProjectError();
//            return;
//        }
//        if (table.Rows.Count <= 0)
//        {
//            MessageBox.Show("Login ou senha inv\x00e1lida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//        }
//        else
//        {
//            int num = Conversions.ToInteger(table.Rows[0]["ATIVO"].ToString());
//            int num2 = Conversions.ToInteger(table.Rows[0]["ID"].ToString());
//            string str = table.Rows[0]["LOGIN"].ToString();
//            DateTime time2 = Conversions.ToDate(table.Rows[0]["SENHAALTERADA"].ToString());
//            if (num != 0)
//            {
//                if (num == 2)
//                {
//                    if (MessageBox.Show("Este computador ser\x00e1 cadastrado e o acesso ser\x00e1 limitado a esta maquina, deseja continuar?", "Informa\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                    {
//                        return;
//                    }
//                    else
//                    {
//                        DBConnection conn2 = new DBConnection()
//                        {
//                            Query = "DELETE FROM ADM_USUARIOS_IFF_MAC WHERE USUARIO_ID = " + Conversions.ToString(num2) + " ;"
//                        };
//                        DBConnection conn4 = conn2;
//                        conn4.Query = conn4.Query + $"INSERT INTO ADM_USUARIOS_IFF_MAC (USUARIO_ID,MAC,ATIVO) VALUES ({num2},'{MacAdress}',{1});";
//                        if (!Conversions.ToBoolean(conn2.executarQuery("I", "")))
//                        {
//                            MessageBox.Show("Ocorreu um erro ao gravar as informa\x00e7\x00f5es", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                            return;
//                        }
//                        else
//                        {
//                            MessageBox.Show("Informa\x00e7\x00f5es adicionadas com sucesso!", "Informa\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
//                            conn2.Query = $"UPDATE ADM_USUARIOS_IFF SET ATIVO = 1 WHERE LOGIN = '{table.Rows[0]["LOGIN"].ToString()}' AND ATIVO = 2";
//                            conn2.executarQuery("U", "");
//                        }
//                    }
//                }
//                bool flag = false;
//                if (DateTime.Compare(time2, DateAndTime.Now.AddDays(-15.0)) < 0)
//                {
//                    flag = true;
//                }
//                if ((num == 3) | flag)
//                {
//                    if (MessageBox.Show("\x00c9 necess\x00e1rio atualizar sua senha, deseja continuar?", "Informa\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                    {
//                        return;
//                    }
//                    else
//                    {
//                        DBConnection conn3 = new DBConnection();
//                        string str3 = Interaction.InputBox("Informe a nova senha de no m\x00edmino 6 caracteres", "Altera\x00e7\x00e3o de senha", "", -1, -1);
//                        if (str3.Length >= 6)
//                        {
//                            if (str3.Length <= 20)
//                            {
//                                if (!str3.Contains("'"))
//                                {
//                                    conn3.Query = string.Format("UPDATE ADM_USUARIOS_IFF SET SENHA = '{0}',SENHAALTERADA = '{2}' , ATIVO = 1 WHERE LOGIN = '{1}'", str3, str, DateAndTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
//                                    if (!Conversions.ToBoolean(conn3.executarQuery("U", "")))
//                                    {
//                                        MessageBox.Show("Ocorreu um erro ao gravar as informa\x00e7\x00f5es", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                                        return;
//                                    }
//                                    else
//                                    {
//                                        MessageBox.Show("Informa\x00e7\x00f5es alteradas com sucesso!", "Informa\x00e7\x00e3o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
//                                    }
//                                }
//                                else
//                                {
//                                    MessageBox.Show("Existem caracteres n\x00e3o permitidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                                    return;
//                                }
//                            }
//                            else
//                            {
//                                MessageBox.Show("A senha deve conter no m\x00e1ximo 20 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                                return;
//                            }
//                        }
//                        else
//                        {
//                            MessageBox.Show("A senha deve conter no m\x00ednimo 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                            return;
//                        }
//                    }
//                }
//                if (!this.verificarMac(num2, MacAdress))
//                {
//                    MessageBox.Show("Acesso negado: Mac-Adress inv\x00e1lido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
//                }
//                else
//                {
//                    int num3 = Conversions.ToInteger(table.Rows[0]["TIPO"].ToString());
//                    if ((num3 != 2) && ((num3 != 4) && ((num3 != 5) && (num3 != 6))))
//                    {
//                        MessageBox.Show("Tipo de usu\x00e1rio desconhecido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
//                    }
//                    else
//                    {
//                        this.flag = true;
//                        this.Hide();
//                    }
//                }
//            }
//            else
//            {
//                MessageBox.Show("Conta desabilitada pelo administrador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }
//        }
//    }
//}
