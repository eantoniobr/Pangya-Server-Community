using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models;
using PangyaAPI.IFF.JP.Models.Data;
using PangyaAPI.IFF.JP.Models.Flags;
using Pangya_Modern_Editor.Properties;

namespace Pangya_Modern_Editor.Extensions
{                   
    public class ExportarCSV
    {
        private char _TextoDelimitador;

        private char _TextoQualificadores;

        private bool _ColunaTemHeaders;

        public char TextoDelimitador
        {
            get
            {
                return this._TextoDelimitador;
            }
            set
            {
                this._TextoDelimitador = value;
            }
        }

        public char TextoQualificadores
        {
            get
            {
                return this._TextoQualificadores;
            }
            set
            {
                this._TextoQualificadores = value;
            }
        }

        public bool ColunaTemHeaders
        {
            get
            {
                return this._ColunaTemHeaders;
            }
            set
            {
                this._ColunaTemHeaders = value;
            }
        }
       public StringBuilder stringBuilder = new StringBuilder();
        public ExportarCSV()
        {
            this.TextoDelimitador = ';';
            this.TextoQualificadores = '"';
            this.ColunaTemHeaders = true;
        }

        public ExportarCSV(string txtDelimitador, string txtQualificador, bool temHeaders)
        {
            this.TextoDelimitador = Conversions.ToChar(txtQualificador);
            this.TextoQualificadores = Conversions.ToChar(txtQualificador);
            this.ColunaTemHeaders = temHeaders;
        }

        public string CsvDoDataTable(DataTable tabelaEntrada)
        {
            try
            {                                         
                if (this.ColunaTemHeaders)
                {
                    this.CriaHeader(tabelaEntrada, stringBuilder);
                }
                this.CriaLinhas(tabelaEntrada, stringBuilder);
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                throw ex;
            }
        }

        private void CriaLinhas(DataTable tabelaEntrada, StringBuilder CsvBuilder)
        {
            try
            {
                IEnumerator enumerator = default(IEnumerator);
                try
                {
                    enumerator = tabelaEntrada.Rows.GetEnumerator();
                    IEnumerator enumerator2 = default(IEnumerator);
                    while (enumerator.MoveNext())
                    {
                        DataRow dataRow;
                        dataRow = (DataRow)enumerator.Current;
                        try
                        {
                            enumerator2 = tabelaEntrada.Columns.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                CsvBuilder.Append(string.Concat(str1: dataRow[((DataColumn)enumerator2.Current).ColumnName].ToString().Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores), str0: Conversions.ToString(this.TextoQualificadores), str2: Conversions.ToString(this.TextoQualificadores)));
                                CsvBuilder.Append(this.TextoDelimitador);
                            }
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                        CsvBuilder.AppendLine();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                throw ex;
            }
        }

        private void CriaHeader(DataTable tabelaEntrada, StringBuilder CsvBuilder)
        {
            try
            {
                IEnumerator enumerator = default(IEnumerator);
                try
                {
                    enumerator = tabelaEntrada.Columns.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataColumn dataColumn;
                        dataColumn = (DataColumn)enumerator.Current;
                        dataColumn.ColumnName.ToString().Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores);
                        CsvBuilder.Append(Conversions.ToString(this.TextoQualificadores) + dataColumn.ColumnName + Conversions.ToString(this.TextoQualificadores));
                        CsvBuilder.Append(this.TextoDelimitador);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                CsvBuilder.AppendLine();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                throw ex;
            }
        }
        public string CsvDasLinhasSelecionadas(DataGridView dataGridView)
        {
            try
            {                                                          
                // Verificar se há linhas selecionadas
                if (dataGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i > 0)
                                stringBuilder.Append(this.TextoDelimitador);

                            string cellValue = (string)(row.Cells[0].Value);
                            stringBuilder.Append(this.TextoQualificadores + cellValue.Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores) + this.TextoQualificadores);
                            cellValue = (string)(row.Cells[1].Value);
                            stringBuilder.Append(this.TextoQualificadores + cellValue.Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores) + this.TextoQualificadores);

                        }
                        stringBuilder.AppendLine();
                    }
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CsvDasLinhasSelecionadas(string ID, string desc)
        {
            try
            {  
                stringBuilder.Append(this.TextoDelimitador);

                stringBuilder.Append(this.TextoQualificadores + ID.Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores) + this.TextoQualificadores);

                stringBuilder.Append(this.TextoQualificadores + desc.Replace(this.TextoQualificadores.ToString(), this.TextoQualificadores.ToString() + this.TextoQualificadores) + this.TextoQualificadores);
                stringBuilder.AppendLine();
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class Util
    {
        public Util()
        {
        }
        public static LanguageRegion GetEncoding(IFF_REGION region, ref Encoding FileEncoding)
        {
            IFF_REGION iff_region = region;
            switch (iff_region)
            {
                case IFF_REGION.Japan:
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;

                case IFF_REGION.Korea:
                    FileEncoding = Encoding.GetEncoding(51949);
                    return LanguageRegion.KR;

                case IFF_REGION.Default:
                case IFF_REGION.Usa:
                    FileEncoding = Encoding.GetEncoding(874);
                    return LanguageRegion.GB;
            }

            //unknow so encoding UTF8
            FileEncoding = Encoding.UTF8;
            return LanguageRegion.GB;
        }
        /// <summary>
        /// obtem o tipo codificação/decodificação usada no arquivo
        /// </summary>
        /// <returns>retorna o encoding usado</returns>
        public static LanguageRegion GetEncoding(string filePath, ref Encoding FileEncoding)
        {
            if (filePath == null)
            {
                throw new InvalidOperationException("No file path given to get encoding from, use SetEncoding() method!");
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath).ToLower();

            switch (fileName)
            {
                case "korea":
                    FileEncoding = Encoding.GetEncoding(51949);
                    return LanguageRegion.KR;
                case "japan":
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;
                case "english":
                    {
                        FileEncoding = Encoding.GetEncoding(874);
                        return LanguageRegion.GB;
                    }

                case "thailand":
                    FileEncoding = Encoding.GetEncoding(874);
                    return LanguageRegion.ID;

                case "indonesia":

                    FileEncoding = Encoding.GetEncoding(65001);
                    return LanguageRegion.ID;

                case "brasil":
                case "spanish":
                case "german":
                case "french":
                    //FileEncoding = Encoding.GetEncoding("");//1252
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;

                default:
                    FileEncoding = Encoding.GetEncoding(65001);
                    return LanguageRegion.Default;
            }
        }

        public static string GetHWID()
        {
            try
            {
                string cpuId = GetWmiValue("Win32_Processor", "ProcessorId");
                string boardId = GetWmiValue("Win32_BaseBoard", "SerialNumber");
                string gpuId = GetWmiValue("Win32_VideoController", "PNPDeviceID");
                string diskId = GetWmiValue("Win32_LogicalDisk", "VolumeSerialNumber");

                // Monta uma string única misturando todos
                string raw = $"{cpuId}-{boardId}-{gpuId}-{diskId}";

                return ComputeSha256(raw);
            }
            catch
            {
                return "UNKNOWN-HWID";
            }
        }

        private static string GetWmiValue(string className, string property)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher($"SELECT {property} FROM {className}"))
                {
                    return searcher.Get()
                                   .Cast<ManagementObject>()
                                   .FirstOrDefault()?[property]?.ToString().Trim() ?? "";
                }
            }
            catch
            {
                return "";
            }
        }

        private static string ComputeSha256(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }
        public static string GetMAC()
        {
            try
            {
                // Passo 1: abre conexão pra descobrir qual IP local tá sendo usado pra sair na internet
                string localIP;
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530); // DNS Google
                    var endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint?.Address.ToString() ?? "0.0.0.0";
                }

                if (localIP == "0.0.0.0")
                    return "00:00:00:00:00:00";

                var targetIp = IPAddress.Parse(localIP);

                // Passo 2: percorre todas as interfaces de rede ativas
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus != OperationalStatus.Up)
                        continue;

                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                        nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                        continue;

                    var ipProps = nic.GetIPProperties();
                    foreach (var addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork &&
                            addr.Address.Equals(targetIp))
                        {
                            // Achou a interface que realmente está na rota pra internet
                            var macBytes = nic.GetPhysicalAddress().GetAddressBytes();
                            if (macBytes.Length == 6 && macBytes.Any(b => b != 0))
                                return string.Join(":", macBytes.Select(b => b.ToString("X2")));
                        }
                    }
                }

                return "00:00:00:00:00:00"; // fallback
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetMAC] Erro ao obter MAC: {ex.Message}");
                return "00:00:00:00:00:00";
            }
        }

        public static string GetIP()
    {
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ip = host.AddressList.FirstOrDefault(_ip =>
                _ip.AddressFamily == AddressFamily.InterNetwork &&
                !IPAddress.IsLoopback(_ip)
            );

            return ip?.ToString() ?? "0.0.0.0";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GetIP] Erro ao obter IP: {ex.Message}");
            return "0.0.0.0";
        }
    }
      
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder stringBuilder = new StringBuilder(checked(ba.Length * 2));
            foreach (byte b in ba)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static string ByteToString(byte ba)
        {
            StringBuilder stringBuilder = new StringBuilder(2);
            stringBuilder.AppendFormat("{0:x2}", ba);
            return stringBuilder.ToString();
        }

        public static object lerArquivo(string arquivo, ref byte[] Inicio, ref long Qtd, int totalB)
        {
            //Discarded unreachable code: IL_00ca, IL_00d6
            byte[] array = File.ReadAllBytes(arquivo);
            List<byte> list = new List<byte>();
            List<string> list2 = new List<string>();
            checked
            {
                int num3 = array.Length - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 < 8)
                    {
                        list.Add(array[num4]);
                    }
                    list2.Add(ByteToString(array[num4]));
                    num4++;
                }
                Inicio = list.ToArray();
                string value = ByteToString(list[3]) + ByteToString(list[2]) + ByteToString(list[1]) + ByteToString(list[0]);
                Qtd = Convert.ToInt32(value, 16);
                if (Conversions.ToBoolean(verificarEstrutura(array.Length, (int)Qtd, totalB)))
                {
                    return list2;
                }
                return false;
            }
        }

        public static object lerArquivoCauldron(string arquivo, ref byte[] Inicio, ref long Qtd, int totalB)
        {
            //Discarded unreachable code: IL_00b0, IL_00bc
            byte[] array = File.ReadAllBytes(arquivo);
            List<byte> list = new List<byte>();
            List<string> list2 = new List<string>();

            checked
            {
                int num3 = array.Length - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 < 8)
                    {
                        list.Add(array[num4]);
                    }
                    list2.Add(ByteToString(array[num4]));
                    num4++;
                }
                Inicio = list.ToArray();
                string value = ByteToString(list[1]) + ByteToString(list[0]);
                Qtd = Convert.ToInt32(value, 16);
                if (Conversions.ToBoolean(verificarEstrutura(array.Length, (int)Qtd, totalB)))
                {
                    return list2;
                }
                return false;
            }
        }

        public static object verificarEstrutura(int bytes, int qtd, int total)
        {
            //Discarded unreachable code: IL_0031, IL_003d
            checked
            {
                double number = (double)(bytes + 8) / (double)total;
                if ((Conversion.Int(number) < (double)(qtd + 100)) & (Conversion.Int(number) > (double)(qtd - 100)))
                {
                    return true;
                }
                return false;
            }
        }

        public static object StringToByte(string Str)
        {
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            return aSCIIEncoding.GetBytes(Str);
        }

        public static string HexToString(string hex)
        {
            string text = "";
            checked
            {
                int num = hex.Length - 2;
                int num2 = 0;
                while (true)
                {
                    int num3 = num2;
                    int num4 = num;
                    if (num3 > num4)
                    {
                        break;
                    }
                    char c = Strings.Chr(Convert.ToByte(hex.Substring(num2, 2), 16));
                    text += Conversions.ToString(c);
                    num2 += 2;
                }
                return Strings.RTrim(text.ToString());
            }
        }

        public static bool checkN(string s)
        {
            if (s == null)
            {
                return false;
            }
            s = s.Trim(Conversions.ToChar(new string('\0', 1)));
            return string.IsNullOrEmpty(s);
        }

        public static List<List<string>> dividirArquivo(List<string> Lista, int tamanho)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> list2 = new List<string>();
            List<byte> list3 = new List<byte>();
            int num = 0;
            int num2 = 0;
            checked
            {
                int num3 = Lista.Count - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 >= 8)
                    {
                        if (num < tamanho - 1)
                        {
                            num++;
                        }
                        else
                        {
                            num2++;
                            num = 0;
                        }
                        list2.Add(Lista[num4]);
                        if (unchecked(num == 0 && num2 > 0))
                        {
                            list.Add(list2);
                            list2 = new List<string>();
                        }
                    }
                    num4++;
                }
                return list;
            }
        }

        //public static object findItemName(List<Part> Lista, string Valor)
        //{

        //    List<Part> list = new List<Part>();
        //    checked
        //    {
        //        int num = Lista.Count - 1;
        //        int num2 = 0;
        //        while (true)
        //        {
        //            int num3 = num2;
        //            int num4 = num;
        //            if (num3 > num4)
        //            {
        //                break;
        //            }
        //            if (Lista[num2].ItemName.ToLower().Contains(Valor.ToLower()))
        //            {
        //                list.Add(Lista[num2]);
        //            }
        //            num2++;
        //        }
        //        return list;
        //    }
        //}

        public static bool gravarArquivo(byte[] Bs, string caminho, ref BackgroundWorker BW)
        {
            //Discarded unreachable code: IL_0053, IL_0084, IL_008b, IL_00a6
            try
            {
                BW.ReportProgress(1);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                File.WriteAllBytes(caminho, Bs);
                MessageBox.Show("Arquivo salvo com sucesso", "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show("Erro ao gravar o arquivo: " + ex2.Message, "Pangya Modern Editor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                bool result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static bool gravarArquivoDividido(byte[] Bs, string caminho)
        {
            //Discarded unreachable code: IL_0026, IL_0039, IL_0040
            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                File.WriteAllBytes(caminho, Bs);
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                bool result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }                                                        

        public static bool gerarBackup(byte[] bs, string caminho)
        {
            string sourceFilePath = caminho;
            string backupFolder = Path.Combine(Path.GetDirectoryName(sourceFilePath), "Backup");

            // Verifica se a pasta "Backup" já existe
            if (!Directory.Exists(backupFolder))
            {
                // Cria a pasta "Backup" se não existir
                Directory.CreateDirectory(backupFolder);
            }

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFilePath);
            string fileExtension = Path.GetExtension(sourceFilePath);

            string currentDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"{fileNameWithoutExtension}_{currentDate}{fileExtension}";
            string destinationFilePath = Path.Combine(backupFolder, newFileName);
                                                        
            try
            {
                 File.WriteAllBytes(destinationFilePath, bs);
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                bool result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static object String_TO_Bytes(string Str)
        {
            List<byte> list = new List<byte>();
            byte[] bytes = Encoding.Default.GetBytes(Str);
            byte[] array = bytes;
            foreach (byte b in array)
            {
                list.Add(Convert.ToByte(b.ToString("x").ToUpper(), 16));
            }
            while (list.Count < 40)
            {
                list.Add(default(byte));
            }
            return list.ToArray();
        }

        public static object Long_TO_Bytes(long Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            string text2 = "";
            string text3 = "";
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            while (Strings.Len(text) < 8)
            {
                text = "0" + text;
            }
            int num2 = Strings.Len(text);
            int num3 = 1;
            while (true)
            {
                int num4 = num3;
                int num5 = num2;
                if (num4 > num5)
                {
                    break;
                }
                text3 = Strings.Mid(text, num3, 2);
                list.Add(Convert.ToByte(text3.PadRight(2, '0'), 16));
                text2 = text3.PadRight(2, '0') + text2;
                num3 = checked(num3 + 2);
            }
            byte[] array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        public static object Short_TO_Bytes(short Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            string text2 = "";
            string text3 = "";
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            while (Strings.Len(text) < 4)
            {
                text = "0" + text;
            }
            int num2 = Strings.Len(text);
            int num3 = 1;
            while (true)
            {
                int num4 = num3;
                int num5 = num2;
                if (num4 > num5)
                {
                    break;
                }
                text3 = Strings.Mid(text, num3, 2);
                list.Add(Convert.ToByte(text3.PadRight(2, '0'), 16));
                text2 = text3.PadRight(2, '0') + text2;
                num3 = checked(num3 + 2);
            }
            byte[] array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        public static object Byte_To_Hex(byte Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            return Convert.ToByte(text.PadRight(2, '0'), 16);
        }

        public static object setValues(object Itens, byte[] Inicio, long qtdItens, bool BytesVazios = true)
        {
            List<byte> list = new List<byte>();
            string text = "";
            int num2 = 0;
            list.AddRange((IEnumerable<byte>)Long_TO_Bytes(qtdItens));
            list.Add(Convert.ToByte("0B", 16));
            list.Add(default(byte));
            list.Add(default(byte));
            list.Add(default(byte));
            int num3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(Itens, null, "Count", new object[0], null, null, null), 1));
            int num4 = 0;
            checked
            {
                short num7 = default(short);
                long num10 = default(long);
                byte b = default(byte);
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null));
                    PropertyInfo[] properties = objectValue.GetType().GetProperties();
                    PropertyInfo[] array = properties;
                    foreach (PropertyInfo propertyInfo in array)
                    {
                        if (Operators.CompareString(propertyInfo.PropertyType.Name, num7.GetType().Name, false) == 0)
                        {
                            short num8 = Conversions.ToShort(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array2 = (byte[])Short_TO_Bytes(num8);
                            byte[] array3 = array2;
                            foreach (byte item in array3)
                            {
                                list.Add(item);
                            }
                            num2 += 2;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, text.GetType().Name, false) == 0)
                        {
                            string str = Conversions.ToString(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array4 = (byte[])String_TO_Bytes(str);
                            int num9 = 0;
                            byte[] array5 = array4;
                            foreach (byte item2 in array5)
                            {
                                list.Add(item2);
                                num9++;
                            }
                            num2 += 40;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, num10.GetType().Name, false) == 0)
                        {
                            long num11 = Conversions.ToLong(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            string text2 = Conversion.Hex(num11);
                            byte[] array6 = (byte[])Long_TO_Bytes(num11);
                            byte[] array7 = array6;
                            foreach (byte item3 in array7)
                            {
                                list.Add(item3);
                            }
                            num2 += 4;
                        }
                        else
                        {
                            if (Operators.CompareString(propertyInfo.PropertyType.Name, b.GetType().Name, false) != 0)
                            {
                                throw new Exception("Tipo de propriedade não encontrada");
                            }
                            byte num12 = Conversions.ToByte(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte item4 = Conversions.ToByte(Byte_To_Hex(num12));
                            list.Add(item4);
                            num2++;
                        }
                    }
                    num4++;
                }
                return list.ToArray();
            }
        }

        public static object setValuesCalderao(object Itens, byte[] Inicio, long qtdItens, bool BytesVazios = true)
        {
            List<byte> list = new List<byte>();
            string text = "";
            int num2 = 0;
            checked
            {
                list.AddRange((IEnumerable<byte>)Short_TO_Bytes((short)qtdItens));
                list.Add(Inicio[2]);
                list.Add(Inicio[3]);
                list.Add(Inicio[4]);
                list.Add(Inicio[5]);
                list.Add(Inicio[6]);
                list.Add(Inicio[7]);
                int num3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(Itens, null, "Count", new object[0], null, null, null), 1));
                int num4 = 0;
                short num7 = default(short);
                long num10 = default(long);
                byte b = default(byte);
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null));
                    PropertyInfo[] properties = objectValue.GetType().GetProperties();
                    PropertyInfo[] array = properties;
                    foreach (PropertyInfo propertyInfo in array)
                    {
                        if (Operators.CompareString(propertyInfo.PropertyType.Name, num7.GetType().Name, false) == 0)
                        {
                            short num8 = Conversions.ToShort(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array2 = (byte[])Short_TO_Bytes(num8);
                            byte[] array3 = array2;
                            foreach (byte item in array3)
                            {
                                list.Add(item);
                            }
                            num2 += 2;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, text.GetType().Name, false) == 0)
                        {
                            string str = Conversions.ToString(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array4 = (byte[])String_TO_Bytes(str);
                            int num9 = 0;
                            byte[] array5 = array4;
                            foreach (byte item2 in array5)
                            {
                                list.Add(item2);
                                num9++;
                            }
                            num2 += 40;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, num10.GetType().Name, false) == 0)
                        {
                            long num11 = Conversions.ToLong(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            string text2 = Conversion.Hex(num11);
                            byte[] array6 = (byte[])Long_TO_Bytes(num11);
                            int num12 = 0;
                            byte[] array7 = array6;
                            foreach (byte item3 in array7)
                            {
                                if (num12 < 4)
                                {
                                    list.Add(item3);
                                    num12++;
                                }
                            }
                            num2 += 4;
                        }
                        else
                        {
                            if (Operators.CompareString(propertyInfo.PropertyType.Name, b.GetType().Name, false) != 0)
                            {
                                throw new Exception("Tipo de propriedade não encontrada");
                            }
                            byte num13 = Conversions.ToByte(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte item4 = Conversions.ToByte(Byte_To_Hex(num13));
                            list.Add(item4);
                            num2++;
                        }
                    }
                    num4++;
                }
                return list.ToArray();
            }
        }

        public static object setValuesDividido<T>(IFFFile<T> itens, int qtdItens)
        {
            List<byte> list = new List<byte>();
            list.AddRange((IEnumerable<byte>)Long_TO_Bytes(qtdItens));
            list.Add(0xD);
            list.Add(default(byte));
            list.Add(default(byte));
            list.Add(default(byte));

            if (itens is IFFFile<T>)
            {
                foreach (var item in itens.GetBytes())
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }



        internal static object Skin_gerarSql(List<Skin> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        internal static object HairStyle_gerarSql(List<HairStyle> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object Card_gerarSql(List<Card> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));                                                           
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object AuxPart_gerarSql(List<AuxPart> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {                
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object Mascot_gerarSql(List<Mascot> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }
        
        public static object Part_gerarSql(List<Part> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW,Arquivo);
            return true;
        }
              
        public static object Item_gerarSql(List<Item> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object SetItem_gerarSql(List<SetItem> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object ClubSet_gerarSql(List<ClubSet> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object Caddie_gerarSql(List<Caddie> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object CaddieItem_gerarSql(List<CaddieItem> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        public static object Ball_gerarSql(List<Ball> lista, List<Desc> Descs, string Arquivo, ref BackgroundWorker BW)
        {
            var db = new DBIFFCollection();
            foreach (var item in lista)
            {
                var Desc = Descs.Any(c => c.ID == item.ID) ? Descs.FirstOrDefault(c => c.ID == item.ID).getDesc() : "NO HAVE INFO";
                db.Add(new DBIFF(item, Desc, ""));
            }
            db.GenerateSqlFile(ref BW, Arquivo);
            return true;
        }

        static byte[] DownloadImage(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    return client.DownloadData(imageUrl);
                }
                catch
                {
                    return null;
                }
            }
        }

        static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return Resources.ErrorImage;

            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                // Cria um objeto Image a partir dos bytes
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }

        public static Image getImage(string icon = "", bool Online = false)
        {
            Image image = null;
            try
            {
                if (Online)
                {
                    // URL da imagem que você deseja baixar
                    string imageUrl = $"https://example.com/{icon}.png"; //local da imagem

                    // Baixa a imagem como bytes
                    byte[] imageBytes = DownloadImage(imageUrl);

                    // Converte os bytes em um objeto Image
                    image = ByteArrayToImage(imageBytes);

                }
                else
                {
                    var local = Directory.GetCurrentDirectory() + $@"\Icon\{icon}.png";
                    if (File.Exists(local))
                        image = Image.FromFile(local);   
                }
                return image;
            }
            catch
            {
                return Resources.NoIcon;
            }
        }

        // this method from https://www.codeproject.com/Articles/36747/Quick-and-Dirty-HexDump-of-a-Byte-Array
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            var bytesLength = bytes.Length;

            var HexChars = "0123456789ABCDEF".ToCharArray();

            var firstHexColumn =
                8 // 8 characters for the address
                + 3; // 3 spaces

            var firstCharColumn = firstHexColumn
                                  + bytesPerLine * 3 // - 2 digit for the hexadecimal value and 1 space
                                  + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                                  + 2; // 2 spaces 

            var lineLength = firstCharColumn
                             + bytesPerLine // - characters to show the ascii value
                             + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            var line = (new string(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();
            var expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            var result = new StringBuilder(expectedLines * lineLength);

            for (var i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                var hexColumn = firstHexColumn;
                var charColumn = firstCharColumn;

                for (var j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        var b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = b < 32 ? '·' : (char)b;
                    }

                    hexColumn += 3;
                    charColumn++;
                }

                result.Append(line);
            }

            return result.ToString();
        }
    }     
}
