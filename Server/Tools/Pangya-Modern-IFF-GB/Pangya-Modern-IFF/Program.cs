using Microsoft.VisualBasic.ApplicationServices;
using PangyaSuiteFiles.My;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PangyaAPI.Translation;
namespace PangyaSuiteFiles
{
    internal class Program : WindowsFormsApplicationBase
    {
        public static DateTime time = new DateTime(2022, 8, 10);
        static DateTime time2 = new DateTime(2022, 4, 16);
        static DateTime time3 = new DateTime(2022, 4, 16);
        static DateTime time4 = new DateTime(2022, 4, 16);
        public Program() : base(AuthenticationMode.Windows)
        {
            this.IsSingleInstance = false;
            this.EnableVisualStyles = true;
            this.SaveMySettingsOnExit = true;
            this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        [STAThread]
        internal static void Main(string[] args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(UseCompatibleTextRendering);
                MyProject.Application.Run(args);

            }
            catch
            { }
        }

        static string[] Macs = new string[]
        {
            //"D8-FB-5E-E5-49-29",
            "64-32-A8-42-E0-A0",
            //"00-1A-3F-66-69-87",
            // "00-05-16-61-5D-D5",
            //"E4-B3-18-A0-CB-BB",
            // "1C-39-47-57-C7-50",
            //"00-05-16-61-5D-D5",
            //"BC-5F-F4-9C-12-3E",
            //"28-D0-EA-02-80-FF",
            //"DC-2E-6A-96-88-7F"
            "2C-F0-5D-A3-CD-E8"
        };
        public static bool ExistMac => Macs.Any(c => c == GetMAC("000.000.000.000".ToString()));
        protected override void OnCreateMainForm()
        {
            var dtime = new DTime();
          TranslationAPI.GetV2("hello");

            if (dtime.CheckTime())
            {
                Directory.CreateDirectory("new_iffs");
                Directory.CreateDirectory("pangya_jp");
                Directory.CreateDirectory("backup_iffs");
                this.MainForm = new FrmMain();
            }
            else
            {
                System.Diagnostics.Process.Start("https://discord.gg/DD3GHaVBQh");
                Directory.Delete("pangya_gb.iff");
                MessageBox.Show("[Pangya_Suite_Tools]: Code 200 ", "Message Box: app is version free ^^ ");
                Application.Exit();
            }
        }


        [DllImport("iphlpapi.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int SendARP(uint DestIP, uint SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

        private static string GetMAC(string IPAddress)
        {
            IPAddress = GetIPLocal();
            IPAddress iPAddress = System.Net.IPAddress.Parse(IPAddress);
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
    }
}
